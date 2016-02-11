using EloBuddy;

namespace Mario_sTemplate.Logics
{
    internal class FarmLogics : Helpers
    {
        #region LastHit

        public static void lastQ()
        {
            var minionQ = GetLaneMinion(Q.Range);
            if (IsNotNull(minionQ))
            {
                Q.Cast(minionQ);
            }
        }

        #endregion LastHit

        #region LaneClear

        public static void laneQ()
        {
            var minionQ = GetLaneMinion(Q.Range);
            if (IsNotNull(minionQ))
            {
                Q.Cast(minionQ);
            }
        }

        #endregion LaneClear
    }
}
