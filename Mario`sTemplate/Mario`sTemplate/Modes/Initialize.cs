using System;
using EloBuddy;
using EloBuddy.SDK;

// ReSharper disable SwitchStatementMissingSomeCases

namespace Mario_sTemplate.Modes
{
    internal class Initialize
    {
        public static void Init()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            try
            {
                Active.Execute();

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                {
                    Combo.Execute();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                {
                    Harass.Execute();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
                {
                    Flee.Execute();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                {
                    LaneClear.Execute();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
                {
                    LastHit.Execute();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                {
                    JungleClear.Execute();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("============================= ERROR =============================");
                Console.WriteLine(exp);
                Console.WriteLine("============================= ERROR =============================");
            }
        }
    }
}
