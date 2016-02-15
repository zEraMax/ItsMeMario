using EloBuddy;
using EloBuddy.SDK;

namespace Mario_sTemplate.Logics
{
    internal class ComboLogics : Helpers
    {
        #region Agressive
        public static void castQ(Obj_AI_Base target)
        {
            if (target.IsValidTarget(Q.Range) && Q.IsReady() && CanPostAttack)
            {
                Q.Cast();
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
