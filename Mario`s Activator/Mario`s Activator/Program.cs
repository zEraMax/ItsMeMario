using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace Mario_s_Activator
{
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Print("Loaded!");
            /*
            foreach (var s in Player.Spells)
            {
                Chat.Print(s.Name);
            }
            */
            
            DamageHandler.Init();
            Activator.Init();
        }
    }
}
