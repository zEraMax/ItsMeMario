using System;
using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Template.Menus;

namespace Mario_s_Template.Modes
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;

            Active.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo.Execute();
            }
            
            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass) && playerMana > HarassMenu.GetSliderValue("manaSlider"))
            {
                Harass.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit) && playerMana > LasthitMenu.GetSliderValue("manaSlider"))
            {
                LastHit.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) && playerMana > LaneClearMenu.GetSliderValue("manaSlider"))
            {
                LaneClear.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear) && playerMana > JungleClearMenu.GetSliderValue("manaSlider"))
            {
                JungleClear.Execute();
            }

            if (playerMana > AutoHarassMenu.GetSliderValue("manaSlider"))
            {
                AutoHarass.Execute();
            }
        }
    }
}
