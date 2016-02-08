using System;
using EloBuddy;
using EloBuddy.SDK;
// ReSharper disable SwitchStatementMissingSomeCases

namespace Mario_sTemplate
{
    internal class Spells
    {
        #region Consts
        public const DamageType dmgType = DamageType.Mixed;
        #endregion Consts

        public static void Init()
        {
            SpellsSettings();
        }
        public static Spell.Active Q;
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Active R;

        private static void SpellsSettings()
        {
            Q =  new Spell.Active(SpellSlot.Q, 500);
            W =  new Spell.Active(SpellSlot.W, 500);
            E =  new Spell.Active(SpellSlot.E, 500);
            R =  new Spell.Active(SpellSlot.R, 500);
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
                        dmg += new float[] { 10, 20, 30, 40, 50 }[lvl] * AD;
                    }
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                    {
                        dmg += new float[] { 10, 20, 30, 40, 50 }[lvl] * AD;
                    }
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                    {
                        dmg += new float[] { 10, 20, 30, 40, 50 }[lvl] * AD;
                    }
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        dmg += new float[] { 10, 20, 30, 40, 50 }[lvl] * AD;
                    }
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, dmgType, dmg - 10);
        }

        public static float GetTotalDamage(Obj_AI_Base target)
        {
            var dmg = GetDamage(SpellSlot.Q, target) + GetDamage(SpellSlot.W, target) + GetDamage(SpellSlot.E, target) +
                      GetDamage(SpellSlot.R, target) + Player.Instance.GetAutoAttackDamage(target)*3;
            return dmg;
        }
        #endregion Damages
    }
}
