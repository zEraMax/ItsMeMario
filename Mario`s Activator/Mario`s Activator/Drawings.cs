using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Rendering;
using static Mario_s_Activator.Spells.SummonerSpells;
using static Mario_s_Activator.MyMenu;

namespace Mario_s_Activator
{
    internal class Drawings
    {
        public static void InitializeDrawings()
        {
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if(DrawingMenu.GetCheckBoxValue("disableDrawings"))return;

            if (PlayerHasSmite)
            {
                if (Smite.IsReady() && !SummonerMenu.GetKeybindValue("smiteKeybind") && SummonerMenu.GetCheckBoxValue("drawSmiteRange"))
                {
                    Circle.Draw(SharpDX.Color.Yellow, Smite.Range, Player.Instance);
                }
            }

            foreach (var item in Offensive.OffensiveItems.Where(i => i.IsReady() && i.Range > 0))
            {
                Circle.Draw(SharpDX.Color.Orange, item.Range, Player.Instance);
            }

            foreach (var item in Defensive.DefensiveItems.Where(i => i.IsReady() && i.Range > 0))
            {
                Circle.Draw(SharpDX.Color.BlueViolet, item.Range, Player.Instance);
            }

            if (SettingsMenu.GetCheckBoxValue("dev"))
            {
                Circle.Draw(SharpDX.Color.Purple, 650, 1, Player.Instance);

                foreach (var m in DangerHandler.Missiles)
                {
                    Circle.Draw(SharpDX.Color.Purple, 20f, 5f, m);
                }

                Circle.Draw(SharpDX.Color.Blue, Player.Instance.BoundingRadius + SettingsMenu.GetSliderValue("saferange"), Player.Instance);
            }
        }
    }
}
