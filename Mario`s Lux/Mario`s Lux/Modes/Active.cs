using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Lux.EManager;
using static Mario_s_Lux.SpellsManager;

namespace Mario_s_Lux.Modes
{
    internal class Active
    {
        public static void Execute()
        {
            var orbMode = Orbwalker.ActiveModesFlags;

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                if (GetE != null && GetE.CountEnemiesInRange(350) >= 1 && Player.GetSpell(SpellSlot.E).ToggleState >= 1)
                {
                    E.Cast(Player.Instance);
                }
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                if (GetE != null && GetE.CountEnemiesInRange(350) >= 1 && Player.GetSpell(SpellSlot.E).ToggleState >= 1)
                {
                    E.Cast(Player.Instance);
                }
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                LaneClear.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit))
            {
                LastHit.Execute();
            }
        }
    }
}
