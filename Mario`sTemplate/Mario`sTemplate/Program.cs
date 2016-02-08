using System;
using EloBuddy.SDK.Events;

namespace Mario_sTemplate
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
            try
            {
                Spells.Init();
                MenuSettings.LoadMenu();
                Modes.Initialize.Init();
                EventsManager.Init();
            }
            catch (Exception exp)
            {
                Console.WriteLine("============================= ERROR =============================");
                Console.WriteLine(exp);
                Console.WriteLine("============================= ERROR =============================");
            }
        }
    }
}
