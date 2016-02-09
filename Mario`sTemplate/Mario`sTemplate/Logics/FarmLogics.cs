using EloBuddy;

using static Mario_sTemplate.Spells;
using static Mario_sTemplate.Helpers;

namespace Mario_sTemplate.Logics
{
    internal class FarmLogics
    {
        #region LastHit

        public static void lastQ()
        {
            var minionQ = GetLaneMinion(SpellSlot.Q);
            if (minionQ.IsNotNull())
            {
                Q.Cast(minionQ);
            }
        }

        #endregion LastHit

        #region LaneClear

        public static void laneQ(Obj_AI_Base minion)
        {

        }

        #endregion LaneClear
    }
}
