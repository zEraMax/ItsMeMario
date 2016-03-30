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
        }
    }
}
