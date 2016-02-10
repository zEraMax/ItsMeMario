using EloBuddy;
using EloBuddy.SDK;

using static Mario_sWukong.Spells;
using static Mario_sWukong.Helpers;
using static Mario_sWukong.EventsManager;

namespace Mario_sWukong.Logics
{
    internal class ComboLogics
    {
        #region Agressive
        public static void castQ(Obj_AI_Base target)
        {
            if (target.IsValidTarget(Q.Range) && Q.IsReady() && CanPostAttack)
            {
                Q.Cast();
            }
        }

        public static void castW()
        {
            if (Player.Instance.CountEnemiesInRange(1000) >= 2 && W.IsReady() && Player.Instance.ManaPercent >= 35)
            {
                W.Cast();
            }
        }

        public static void castE(Obj_AI_Base target)
        {
            if (target.IsValidTarget(E.Range) && E.IsReady())
            {
                E.Cast(target);
            }
        }

        public static void castR(Obj_AI_Base target, int MinEnemies)
        {
            var toggleState = Player.Instance.Spellbook.GetSpell(SpellSlot.R).ToggleState;
            if (target.IsValidTarget(R.Range) && R.IsReady() &&
                Player.Instance.CountEnemiesInRange(R.Range) >= MinEnemies && toggleState == 0)
            {
                R.Cast();
            }
        }
        #endregion Agressive

        #region Safe
        public static void castSafeE(Obj_AI_Base target)
        {
            if (target.IsValidTarget(E.Range) && E.IsReady() && target.CountEnemiesInRange(800) < 3)
            {
                E.Cast(target);
            }
        }
        #endregion Safe

    }
}
