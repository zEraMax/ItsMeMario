using EloBuddy.SDK.Menu;

namespace Mario_s_Activator
{
    internal class MyMenu
    {
        public static string FirstMenuName;
        private static readonly Menu FirstMenu = MainMenu.AddMenu("Mario`s Activator", "marioactivator");
        public static Menu ComboMenu = FirstMenu.AddSubMenu("• Combo", FirstMenuName.ToLower() + "combo");
        public static Menu HarassMenu = FirstMenu.AddSubMenu("• Harass", FirstMenuName.ToLower() + "harass");
        public static Menu LaneClearMenu = FirstMenu.AddSubMenu("• Laneclear", FirstMenuName.ToLower() + "laneclear");
        public static Menu LastHitMenu = FirstMenu.AddSubMenu("• Lasthit", FirstMenuName.ToLower() + "lasthit");
        public static Menu FleeMenu = FirstMenu.AddSubMenu("• Flee", FirstMenuName.ToLower() + "flee");
        public static Menu MiscMenu = FirstMenu.AddSubMenu("• Misc", FirstMenuName.ToLower() + "misc");
        public static Menu KillStealMenu = FirstMenu.AddSubMenu("• Killsteal", FirstMenuName.ToLower() + "killsteal");
        public static Menu DrawMenu = FirstMenu.AddSubMenu("• Draw", FirstMenuName.ToLower() + "draw");

        public static void BuildMenu()
        {
            
        }
    }
}
