using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
// ReSharper disable SwitchStatementMissingSomeCases

namespace Mario_sTemplate
{
    internal class Helpers
    {
        #region
        //Spaghetti code because EB doesnt support C# 6 :(
        //Spells
        protected static Spell.Active Q
        {
            get { return Spells.Q; }
        }
        protected static Spell.Active W
        {
            get { return Spells.W; }
        }
        protected static Spell.Active E
        {
            get { return Spells.E; }
        }
        protected static Spell.Active R
        {
            get { return Spells.R; }
        }
        protected static int HighestRange
        {
            get { return Spells.highestRange; }
        }

        protected static DamageType DmgType
        {
            get { return Spells.dmgType; }
        }

        //EventsManager
        protected static bool CanPostAttack
        {
            get { return EventsManager.CanPostAttack; }
        }

        protected static bool CanPreAttack
        {
            get { return EventsManager.CanPreAttack; }
        }
        #endregion

        public static bool IsNotNull(Obj_AI_Base target)
        {
            return target != null;
        }

        #region GettingEnemies

        public static Obj_AI_Base GetLastMinion(SpellSlot slot)
        {
            var spell = Spells.SpellList.FirstOrDefault(s => s.Slot == slot);
            if (spell == null)return null;

            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderBy(m => m.Health)
                    .FirstOrDefault(
                        mi =>
                            mi.IsValidTarget(spell.Range) &&
                            Prediction.Health.GetPrediction(mi, spell.CastDelay) <= Spells.GetDamage(slot, mi) &&
                            Prediction.Health.GetPrediction(mi, spell.CastDelay) > 20);

            return minion;
        }

        public static Obj_AI_Base GetLaneMinion(uint Range)
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderBy(m => m.Health)
                    .FirstOrDefault(
                        mi =>
                            mi.IsValidTarget(Range));

            return minion;
        }

        public static Obj_AI_Base GetJungleMinion(uint range)
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderBy(m => m.Health)
                    .FirstOrDefault(mi => mi.IsValidTarget(range));

            return minion;
        }

        public static Obj_AI_Base GetJungleMinionToKS(SpellSlot slot)
        {
            var spell = Spells.SpellList.FirstOrDefault(s => s.Slot == slot);
            if (spell == null) return null;

            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderBy(m => m.Health)
                    .FirstOrDefault(
                        mi =>
                            mi.IsValidTarget(spell.Range) &&
                            Prediction.Health.GetPrediction(mi, spell.CastDelay) <= Spells.GetDamage(slot, mi) &&
                            Prediction.Health.GetPrediction(mi, spell.CastDelay) > 20);

            return minion;
        }
        #endregion GettingEnemies

        #region KS

        public static AIHeroClient GetBestKSHero(uint range, float spellDMG, int spellDelay)
        {
            var hero =
                EntityManager.Heroes.Enemies.OrderBy(x => x.Health).ThenBy(TargetSelector.GetPriority)
                    .FirstOrDefault(
                        e =>
                            e.IsValidTarget(range) &&
                            Prediction.Health.GetPrediction(e, spellDelay) + e.TotalShield() <= spellDMG &&
                            Prediction.Health.GetPrediction(e, spellDelay) > 20);

            return hero;
        }

        //TODO FIX THIS SHIT LATER
        public static List<SpellSlot> GetBestSpellsToKS(int range, Obj_AI_Base target)
        {
            var dmg = 0f;
            var spells = new List<SpellSlot>();

            if (Spells.Q.IsReady())
            {
                dmg += Spells.GetDamage(SpellSlot.Q, target);
                spells.Add(SpellSlot.Q);
            }

            if (Spells.W.IsReady())
            {
                dmg += Spells.GetDamage(SpellSlot.W, target);
                spells.Add(SpellSlot.W);
            }

            if (Spells.E.IsReady())
            {
                dmg += Spells.GetDamage(SpellSlot.E, target);
                spells.Add(SpellSlot.E);
            }

            if (Spells.R.IsReady())
            {
                dmg += Spells.GetDamage(SpellSlot.R, target);
                spells.Add(SpellSlot.R);
            }

            return spells;
        }
        #endregion KS

        #region GettingMenuValues

        public enum MenuTypes
        {
            Combo,Harass,LaneClear,JungleClear,LastHit, Settings, Drawings
        }


        public static bool GetCheckBoxValue(MenuTypes type, string checkName)
        {
            var value = false;
            try
            {
                switch (type)
                {
                    case MenuTypes.Combo:
                        value = MenuSettings.ComboMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.Harass:
                        value = MenuSettings.HarassMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.LaneClear:
                        value = MenuSettings.LaneClearMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.JungleClear:
                        value = MenuSettings.JungleClearMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.LastHit:
                        value = MenuSettings.LastHitMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.Settings:
                        value = MenuSettings.SettingsMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.Drawings:
                        value = MenuSettings.DrawingsMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Menu name is wrong please fix it = " + checkName);
            }

            return value;
        }

        public static int GetSliderValue(MenuTypes type, string sliderName)
        {
            var value = 0;
            try
            {
                switch (type)
                {
                    case MenuTypes.Combo:
                        value = MenuSettings.ComboMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.Harass:
                        value = MenuSettings.HarassMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.LaneClear:
                        value = MenuSettings.LaneClearMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.JungleClear:
                        value = MenuSettings.JungleClearMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.LastHit:
                        value = MenuSettings.LastHitMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.Settings:
                        value = MenuSettings.SettingsMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.Drawings:
                        value = MenuSettings.DrawingsMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Menu name is wrong please fix it = " + sliderName);
            }


            return value;
        }

        public static bool GetKeyBindValue(MenuTypes type, string keyName)
        {
            var value = false;
            try
            {
                switch (type)
                {
                    case MenuTypes.Combo:
                        value = MenuSettings.ComboMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.Harass:
                        value = MenuSettings.HarassMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.LaneClear:
                        value = MenuSettings.LaneClearMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.JungleClear:
                        value = MenuSettings.JungleClearMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.LastHit:
                        value = MenuSettings.LastHitMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.Settings:
                        value = MenuSettings.SettingsMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.Drawings:
                        value = MenuSettings.DrawingsMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Menu name is wrong please fix it = " + keyName);
            }

            return value;
        }

        public static int GetComboBoxValue(MenuTypes type, string comboBoxName)
        {
            var value = 0;
            try
            {
                switch (type)
                {
                    case MenuTypes.Combo:
                        value = MenuSettings.ComboMenu.Get<ComboBox>(comboBoxName).SelectedIndex;
                        break;
                    case MenuTypes.Harass:
                        value = MenuSettings.HarassMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.LaneClear:
                        value = MenuSettings.LaneClearMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.JungleClear:
                        value = MenuSettings.JungleClearMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.LastHit:
                        value = MenuSettings.LastHitMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.Settings:
                        value = MenuSettings.SettingsMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.Drawings:
                        value = MenuSettings.DrawingsMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Menu name is wrong please fix it = " + comboBoxName);
            }

            return value;
        }

        #endregion GettingMenuValues
    }
}
