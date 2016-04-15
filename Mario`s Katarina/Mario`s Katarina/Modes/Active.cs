using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Katarina.SpellsManager;
using static Mario_s_Katarina.Menus;

namespace Mario_s_Katarina.Modes

{
    /// <summary>
    ///     This mode will always run
    /// </summary>
    internal class Active
    {
        /// <summary>
        ///     Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var target =
                EntityManager.Heroes.Enemies.OrderBy(e => e.Health)
                    .ThenBy(TargetSelector.GetPriority)
                    .ThenBy(e => e.FlatMagicReduction)
                    .Where(t => t.IsValidTarget(1200) && !t.HasUndyingBuff());

            if (target != null)
            {
                var targetQ =
                    target.FirstOrDefault(
                        t =>
                            t.IsValidTarget(Q.Range) &&
                            Prediction.Health.GetPrediction(t, Q.CastDelay) <=
                            t.GetDamage(SpellSlot.Q) + (W.IsReady() ? t.GetDamage(SpellSlot.W) + t.PassiveDamage() : 0f));

                //var targetW =

                    
            }
        }
    }
}