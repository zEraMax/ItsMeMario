using System;
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
            Circle.Draw(SharpDX.Color.Blue, Player.Instance.BoundingRadius + SettingsMenu.GetSliderValue("saferange"), Player.Instance);

            if (PlayerHasSmite)
            {
                if (Smite.IsReady() && !SummonerMenu.GetKeybindValue("smiteKeybind"))
                {
                    Circle.Draw(SharpDX.Color.Yellow, Smite.Range, Player.Instance);
                }
            }

            /*
            foreach (var item in Offensive.OffensiveItems.Select(off => new Item(off.ItemID, off.Range)).Where(item => item.IsReady() && item.Range > 0))
            {
                Circle.Draw(SharpDX.Color.Red, item.Range, Player.Instance);
            }

            foreach (var item in Defensive.DefensiveItems.Select(off => new Item(off.ItemID, off.Range)).Where(item => item.IsReady() && item.Range > 0))
            {
                Circle.Draw(SharpDX.Color.Green, item.Range, Player.Instance);
            }
            */
        }
    }
}
