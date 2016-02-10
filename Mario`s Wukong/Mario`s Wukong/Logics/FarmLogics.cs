using EloBuddy;

using static Mario_sWukong.Spells;
using static Mario_sWukong.Helpers;

namespace Mario_sWukong.Logics
{
    internal class FarmLogics
    {
        #region LastHit

        public static void lastQ()
        {
            var minionQ = GetLastMinion(SpellSlot.Q);
            if (minionQ.IsNotNull())
            {
                Q.Cast();
            }
        }

        public static void lastE()
        {
            var minionE = GetLastMinion(SpellSlot.E);
            if (minionE.IsNotNull())
            {
                E.Cast(minionE);
            }
        }

        #endregion LastHit

        #region LaneClear

        public static void laneQ()
        {
            var minionQ = GetLaneMinion(Q.Range);
            if (minionQ.IsNotNull())
            {
                Q.Cast();
            }
        }

        public static void laneE()
        {
            var minionE = GetLaneMinion(E.Range);
            if (minionE.IsNotNull())
            {
                E.Cast(minionE);
            }
        }

        #endregion LaneClear

        #region JungleClear

        public static void jungleQ()
        {
            var minionJungle = GetJungleMinion(Q.Range);
            if (minionJungle.IsNotNull())
            {
                Q.Cast();
            }
        }

        public static void jungleE()
        {
            var minionJungle = GetJungleMinion(E.Range);
            if (minionJungle.IsNotNull())
            {
                E.Cast(minionJungle);
            }
        }
        #endregion
    }
}
