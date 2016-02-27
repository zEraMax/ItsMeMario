using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;

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
            if (SummonerSpells.PlayerHasSmite)
            {
                if (SummonerSpells.Smite.IsReady() && !MyMenu.SummonerMenu.GetKeybindValue("smiteKeybind"))
                {
                    Circle.Draw(SharpDX.Color.Yellow, SummonerSpells.Smite.Range, Player.Instance);
                }
            }

            foreach (var item in Offensive.OffensiveItems.Select(off => new Item(off.ItemID, off.Range)).Where(item => item.IsReady() && item.Range > 0))
            {
                Circle.Draw(SharpDX.Color.Bisque, item.Range, Player.Instance);
            }

            foreach (var item in Defensive.DefensiveItems.Select(off => new Item(off.ItemID, off.Range)).Where(item => item.IsReady() && item.Range > 0))
            {
                Circle.Draw(SharpDX.Color.Green, item.Range, Player.Instance);
            }
        }
    }
}
