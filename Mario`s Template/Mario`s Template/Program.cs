using System;
using System.Linq;
using System.Xml;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace Mario_s_Template
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            Modes.ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();

            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            foreach (var e in EntityManager.Heroes.Enemies.Where(e => e.IsValidTarget(1500)))
            {
                Console.WriteLine(e.ChampionName +" " + e.GetTotalDamage());
            }
        }
    }
}
