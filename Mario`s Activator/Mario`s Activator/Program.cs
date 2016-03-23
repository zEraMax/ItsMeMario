using System;
using EloBuddy;
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
            
            DangerHandlers.Init();
            Activator.Init();
        }
    }
}
