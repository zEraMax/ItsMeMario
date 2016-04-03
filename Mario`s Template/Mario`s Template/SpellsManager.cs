using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Template
{
    public static class SpellsManager
    {
        public static Spell.Targeted Q;
        public static Spell.Active W;
        public static Spell.Active E;
        public static Spell.Targeted R;

        public static void InitializeSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 350);
            W = new Spell.Active(SpellSlot.W, 200);
            E = new Spell.Active(SpellSlot.E, 300);
            R = new Spell.Targeted(SpellSlot.R, 400);

            Obj_AI_Base.OnLevelUp += Obj_AI_Base_OnLevelUp;
        }

        #region Damages
        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            var damageType = DamageType.Magical;
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
                        dmg += new float[] { 20, 45, 70, 95, 120 }[sLevel] + 1f * AD;
                    }
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                    {
                        dmg += new float[] { 0, 0, 0, 0, 0 }[sLevel] + 1f * AD;
                    }
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                    {
                        dmg += new float[] { 80, 110, 140, 170, 200 }[sLevel];
                    }
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                    {
                        dmg += new float[] { 600, 840, 1080 }[sLevel] * 0.6f + 1.2f * AP;
                    }
                    break;
            }
            return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }
        #endregion Damages

        private static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            var focusSlot = SpellSlot.Q;
            var focusSlot2 = SpellSlot.Q;
            var focusSlot3 = SpellSlot.Q;
            var delay = 30;

            if (sender.IsMe && sender.Spellbook.CanSpellBeUpgraded(SpellSlot.R))
            {
                Core.DelayAction(() => Player.Instance.Spellbook.LevelSpell(SpellSlot.R), delay);
            }

            if (sender.IsMe && sender.Spellbook.CanSpellBeUpgraded(focusSlot))
            {
                Core.DelayAction(() => Player.Instance.Spellbook.LevelSpell(focusSlot), delay);
            }

            if (sender.IsMe && sender.Spellbook.CanSpellBeUpgraded(focusSlot2))
            {
                Core.DelayAction(() => Player.Instance.Spellbook.LevelSpell(focusSlot), delay);
            }

            if (sender.IsMe && sender.Spellbook.CanSpellBeUpgraded(focusSlot3))
            {
                Core.DelayAction(() => Player.Instance.Spellbook.LevelSpell(focusSlot), delay);
            }
        }
    }
}
