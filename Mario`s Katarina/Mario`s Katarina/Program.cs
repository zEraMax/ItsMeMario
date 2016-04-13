using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using Mario_s_Katarina.Modes;

namespace Mario_s_Katarina
{
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        /// <summary>
        ///     The firs thing that runs on the template
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        /// <summary>
        ///     This event is triggered when the game loads
        /// </summary>
        /// <param name="args"></param>
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //Put the name of the champion here
            if (Player.Instance.ChampionName != "Katarina") return;

            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();
        }
    }
}