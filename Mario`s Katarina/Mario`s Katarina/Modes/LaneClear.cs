using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;
using static Mario_s_Katarina.SpellsManager;
using static Mario_s_Katarina.Menus;
using static Mario_s_Katarina.RHandler;

namespace Mario_s_Katarina.Modes
{
    /// <summary>
    ///     This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class LaneClear
    {
        /// <summary>
        ///     Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            if (Q.IsReady() && LaneClearMenu.GetCheckBoxValue("qUse"))
            {
                var minionQ =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .OrderBy(m => m.Health)
                        .ThenBy(m => m.Distance(Player.Instance))
                        .FirstOrDefault(
                            m =>
                                m.IsValidTarget(Q.Range) && m.IsEnemy && !m.IsDead &&
                                Prediction.Health.GetPrediction(m, Q.CastDelay) <=
                                m.GetDamage(SpellSlot.Q) + (W.IsReady() ? m.GetDamage(SpellSlot.W) + m.PassiveDamage() : 0f));
                if (minionQ != null) Q.Cast(minionQ);
            }

            if (W.IsReady() && LaneClearMenu.GetCheckBoxValue("wUse"))
            {
                var minionsW =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .OrderBy(m => m.Health)
                        .ThenBy(m => m.Distance(Player.Instance))
                        .Where(
                            m =>
                                m.IsValidTarget(1500) && m.IsEnemy && !m.IsDead &&
                                Prediction.Health.GetPrediction(m, W.CastDelay) <= m.GetDamage(SpellSlot.W) + m.PassiveDamage());
                if (minionsW != null)
                {
                    if (E.IsReady() && LaneClearMenu.GetCheckBoxValue("eUse"))
                    {
                        var minionE =
                            EntityManager.MinionsAndMonsters.GetLaneMinions()
                                .OrderBy(m => m.Health)
                                .ThenBy(m => m.Distance(Player.Instance))
                                .FirstOrDefault(
                                    m =>
                                        m.IsValidTarget(E.Range) && m.IsEnemy && !m.IsDead &&
                                        Prediction.Health.GetPrediction(m, E.CastDelay) <= m.GetDamage(SpellSlot.E) &&
                                        minionsW.Count(mW => mW.IsInRange(m, W.Range)) >= 2);

                        if (minionE != null) E.Cast(minionE);
                    }
                    var minionW = minionsW.FirstOrDefault(m => m.IsValidTarget(W.Range));
                    if(minionW != null) W.Cast();
                }
            }
        }
    }
}