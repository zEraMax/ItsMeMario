using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

// ReSharper disable SwitchStatementMissingSomeCases

namespace Mario_sLissandra
{
    internal class Spells
    {
        #region Consts
        public const DamageType dmgType = DamageType.Magical;
        public const int highestRange = 1050;
        #endregion Consts

        public static void InitSpells()
        {
            SpellsSettings();
        }
        public static Spell.Skillshot Q;
        public static Spell.Skillshot QExtended;
        public static Spell.Active W;
        public static Spell.Skillshot E;
        public static Spell.Targeted R;
        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>(); 

        private static void SpellsSettings()
        {
            //Extended Q = 825
            Q =  new Spell.Skillshot(SpellSlot.Q, 725, SkillShotType.Linear, 250, 2200, 75)
            {
                AllowedCollisionCount = int.MaxValue
            };
            SpellList.Add(Q);
            QExtended = new Spell.Skillshot(SpellSlot.Q, 825, SkillShotType.Linear, 250, 2200, 75)
            {
                AllowedCollisionCount = int.MaxValue
            };
            SpellList.Add(QExtended);
            W =  new Spell.Active(SpellSlot.W, 430);
            SpellList.Add(W);
            E =  new Spell.Skillshot(SpellSlot.E, 1050, SkillShotType.Linear, 250, 850, 125)
            {
                AllowedCollisionCount = int.MaxValue
            };
            SpellList.Add(E);
            R =  new Spell.Targeted(SpellSlot.R, 550);
            SpellList.Add(R);
        }

        #region Damages
        public static float GetDamage(SpellSlot slot,Obj_AI_Base target)
        {
            var lvl = Player.Instance.Spellbook.GetSpell(slot).Level - 1;
            var AD = Player.Instance.FlatPhysicalDamageMod;
            var AP = Player.Instance.FlatMagicDamageMod;
            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                    {
                        dmg += new float[] { 70, 100, 130, 160, 190 }[lvl]+ 0.65f * AP;
                    }
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                    {
                        dmg += new float[] { 70, 110, 150, 190, 230 }[lvl] +0.4f * AP;
                    }
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                    {
                        dmg += new float[] { 70, 115, 160, 205, 250 }[lvl] +0.6f * AP;
                    }
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        dmg += new float[] { 150, 250, 350 }[lvl] +0.7f * AP;
                    }
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, dmgType, dmg - 10);
        }

        public static float GetTotalDamage(Obj_AI_Base target)
        {
            var dmg = GetDamage(SpellSlot.Q, target) + GetDamage(SpellSlot.W, target) + GetDamage(SpellSlot.E, target) +
                      GetDamage(SpellSlot.R, target) + Player.Instance.GetAutoAttackDamage(target);
            return dmg;
        }
        #endregion Damages
    }
}
