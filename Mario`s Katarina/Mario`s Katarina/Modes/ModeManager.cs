using System;
using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;

namespace Mario_s_Katarina.Modes
{
    internal class ModeManager
    {
        /// <summary>
        ///     Create the event on tick
        /// </summary>
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
        }

        /// <summary>
        ///     This event is triggered every tick of the game
        /// </summary>
        /// <param name="args"></param>
        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;

            Active.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                Harass.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit))
            {
                LastHit.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                LaneClear.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                JungleClear.Execute();
            }

            if (Menus.AutoHarassMenu.GetKeyBindValue("autoHarassKey"))
            {
                AutoHarass.Execute();
            }
        }
    }
}