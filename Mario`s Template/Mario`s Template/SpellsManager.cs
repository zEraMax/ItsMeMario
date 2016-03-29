using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Template
{
    public static class SpellsManager
    {
        public static Spell.SpellBase Q;
        public static Spell.SpellBase W;
        public static Spell.SpellBase E;
        public static Spell.SpellBase R;

        public static void InitializeSpells()
        {
            Q = new Spell.Active(SpellSlot.Q, 000);
            W = new Spell.Active(SpellSlot.W, 000);
            E = new Spell.Active(SpellSlot.E, 000);
            R = new Spell.Active(SpellSlot.R, 000);
        }

        #region Damages
        public static float GetDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            var AD = Player.Instance.FlatPhysicalDamageMod;
            var AP = Player.Instance.FlatMagicDamageMod;
            var sLevel = Player.GetSpell(slot).Level - 1;

            //You can get the damage information easily on wikia

            switch (slot)
            {
                case SpellSlot.Q:
                    return new float[] {10, 20, 30, 40, 50}[sLevel] + 0.0f*AP + 0.0f*AD;
                case SpellSlot.W:
                    return new float[] {10, 20, 30, 40, 50}[sLevel] + 0.0f*AP + 0.0f*AD;
                case SpellSlot.E:
                    return new float[] {10, 20, 30, 40, 50}[sLevel] + 0.0f*AP + 0.0f*AD;
                case SpellSlot.R:
                    return new float[] {10, 20, 30, 40, 50}[sLevel] + 0.0f*AP + 0.0f*AD;
            }
            return 0f;
        }

        public static float GetTotalDamage(this Obj_AI_Base target)
        {
            return
                Player.Spells.Where(
                    s => (s.Slot == SpellSlot.Q) || (s.Slot == SpellSlot.W) || (s.Slot == SpellSlot.E) || (s.Slot == SpellSlot.R) && s.IsReady)
                    .Sum(s => target.GetDamage(s.Slot));
        }

        #endregion Damages
    }
}
