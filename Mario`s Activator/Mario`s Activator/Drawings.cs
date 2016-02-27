using System;
using EloBuddy;
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
                    Circle.Draw(SharpDX.Color.DarkGreen, SummonerSpells.Smite.Range, Player.Instance);
                }
            }
        }
    }
}
