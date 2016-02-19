using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_sLissandra.Logics
{
    internal class FarmLogics : Helpers
    {
        #region LastHit

        public static void lastQ()
        {
            var minionQ = GetLastMinion(SpellSlot.Q);
            if(minionQ == null)return;

            if (minionQ.IsValidTarget(Q.Range) && Q.IsReady())
            {
                Q.Cast(minionQ);
            }

            if (minionQ.IsValidTarget(QExtended.Range) && Q.IsReady())
            {
                var predQextend = QExtended.GetPrediction(minionQ);
                if (predQextend.CollisionObjects.Length >= 2)
                {
                    QExtended.Cast(predQextend.CastPosition);
                }
            }
        }

        public static void lastW(int count)
        {
            var minionsW =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .Count(
                        m =>
                            m.IsValidTarget(W.Range) && Prediction.Health.GetPrediction(m, W.CastDelay) <= m.Health &&
                            Prediction.Health.GetPrediction(m, W.CastDelay) >= Player.Instance.GetAutoAttackDamage(m));
            if (minionsW > count && W.IsReady())
            {
                W.Cast();
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
