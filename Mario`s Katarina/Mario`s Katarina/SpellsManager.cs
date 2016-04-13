using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Mario_s_Lib;

namespace Mario_s_Katarina
{
    public static class SpellsManager
    {
        /*
        Targeted spells are like Katarina`s Q
        Active spells are like Katarina`s W
        Skillshots are like Ezreal`s Q
        Circular Skillshots are like Lux`s E and Tristana`s W
        Cone Skillshots are like Annie`s W and ChoGath`s W
        */

        //Remenber of putting the correct type of the spell here
        public static Spell.Targeted Q;
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Skillshot R;

        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        /// <summary>
        ///     It sets the values to the spells
        /// </summary>
        public static void InitializeSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 350);
            W = new Spell.Active(SpellSlot.W, 200);
            E = new Spell.Active(SpellSlot.E, 300);
            R = SpellSlot.R.GetSkillShotData(SkillShotType.Linear);

            SpellList.Add(Q);
            SpellList.Add(W);
            SpellList.Add(E);
            SpellList.Add(R);

            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        #region Damages

        /// <summary>
        ///     It will return the damage but you need to set them before getting the damage
        /// </summary>
        /// <param name="target"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            const DamageType damageType = DamageType.Magical;
            var AD = Player.Instance.FlatPhysicalDamageMod;
            var AP = Player.Instance.FlatMagicDamageMod;
            var sLevel = Player.GetSpell(slot).Level - 1;

            //You can get the damage information easily on wikia

            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                    {
                        //Information of Q damage
                        dmg += new float[] {60, 85, 110, 135, 160}[sLevel] + 0.45f*AP;
                    }
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                    {
                        //Information of W damage
                        dmg += new float[] {40, 75, 110, 145, 180}[sLevel] + 0.25f*AP + 0.6f*AD;
                    }
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                    {
                        //Information of E damage
                        dmg += new float[] {40, 70, 100, 130, 160}[sLevel] + 0.25f*AP;
                    }
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        //Information of R damage
                        dmg += new float[] {35*8, 55*8, 75*8}[sLevel] + 0.25f*AP + 0.37f*AD;
                    }
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }

        public static bool HasPassive(this Obj_AI_Base target)
        {
            return target.HasBuff("KatarinaQMark");
        }

        public static float PassiveDamage(this Obj_AI_Base target)
        {
            var dmg = new float[] { 15, 30, 45, 60, 75 }[Player.GetSpell(SpellSlot.Q).Level - 1] + 0.2f * Player.Instance.FlatMagicDamageMod;
            return target.HasPassive() ? Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, dmg) : 0f;
        }

        #endregion Damages

        /// <summary>
        ///     This event is triggered when a unit levels up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (Menus.MiscMenu.GetCheckBoxValue("activateAutoLVL") && sender.IsMe)
            {
                var delay = Menus.MiscMenu.GetSliderValue("delaySlider");
                Core.DelayAction(LevelUPSpells, delay);
            }
        }

        /// <summary>
        ///     It will level up the spell using the values of the comboboxes on the menu as a priority
        /// </summary>
        private static void LevelUPSpells()
        {
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(SpellSlot.R))
            {
                Player.Instance.Spellbook.LevelSpell(SpellSlot.R);
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("firstFocus"))))
            {
                Player.Instance.Spellbook.LevelSpell(GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("firstFocus")));
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("secondFocus"))))
            {
                Player.Instance.Spellbook.LevelSpell(GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("secondFocus")));
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("thirdFocus"))))
            {
                Player.Instance.Spellbook.LevelSpell(GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("thirdFocus")));
            }
        }

        /// <summary>
        ///     It will transform the value of the combobox into a SpellSlot
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static SpellSlot GetSlotFromComboBox(this int value)
        {
            switch (value)
            {
                case 0:
                    return SpellSlot.Q;
                case 1:
                    return SpellSlot.W;
                case 2:
                    return SpellSlot.E;
            }
            Chat.Print("Failed getting slot");
            return SpellSlot.Unknown;
        }

        public static bool DoDynamicKillSteal(List<Spell.SpellBase> spells)
        {
            var target =
                EntityManager.Heroes.Enemies.OrderBy(e => e.Health)
                    .ThenByDescending(TargetSelector.GetPriority)
                    .ThenBy(e => e.FlatArmorMod)
                    .ThenBy(e => e.FlatMagicReduction)
                    .FirstOrDefault(e => e.IsValidTarget(spells.GetSmallestRange()) && !e.HasUndyingBuff());

            var dmg = spells.Where(spell => spell.IsReady()).Sum(spell => target.GetDamage(spell.Slot));
            var delay = spells.Where(spell => spell.IsReady()).Sum(spell => spell.CastDelay);
            var targetPredictedHealth = Prediction.Health.GetPrediction(target, delay);

            if (targetPredictedHealth <= dmg)
            {
                foreach (var spell in spells.Where(s => target.CanCastSpell(s)))
                {
                    try
                    {
                        spell.Cast();
                    }
                    catch (Exception)
                    {
                        spell.Cast(target);
                    }
                }
            }

            return false;
        }
    }
}