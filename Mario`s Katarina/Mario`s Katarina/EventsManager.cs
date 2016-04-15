using System;
using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Katarina.SpellsManager;

namespace Mario_s_Katarina
{
    internal class EventsManager
    {
        public static void InitEvents()
        {
            GameObject.OnCreate += GameObject_OnCreate;
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var ward = sender as Obj_AI_Minion;

            if (ward != null && ward.BaseSkinName.ToLower().Contains("ward") && E.IsReady() && ward.IsInRange(Player.Instance, E.Range))
            {
                E.Cast(ward);
            }
        }
    }
}
