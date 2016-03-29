using System.Drawing;
using EloBuddy;
using EloBuddy.SDK.Menu;

namespace Mario_s_Template
{
    internal class Menus
    {
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu AutoHarassMenu;
        public static Menu LaneClearMenu;
        public static Menu LasthitMenu;
        public static Menu KillStealMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;

        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu(Player.Instance.ChampionName + " Hu3", Player.Instance.ChampionName.ToLower() + "hue");
            ComboMenu = FirstMenu.AddSubMenu("• Combo", "combomenuid");
            HarassMenu = FirstMenu.AddSubMenu("• Harass", "harassmenuid");
            AutoHarassMenu = FirstMenu.AddSubMenu("• AutoHarass", "autoharassmenuid");
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear", "laneclearmenuid");
            LasthitMenu = FirstMenu.AddSubMenu("• LastHit", "lasthitmenuid");
            KillStealMenu = FirstMenu.AddSubMenu("• KillSteal", "killstealmenuid");
            MiscMenu = FirstMenu.AddSubMenu("• Misc", "miscmenuid");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", "drawingsmenuid");

            ComboMenu.AddGroupLabel("Settings");
            ComboMenu.CreateCheckBox("Use Q", "qUse");
            ComboMenu.CreateCheckBox("Use W", "wUse");
            ComboMenu.CreateCheckBox("Use E", "eUse");
            ComboMenu.CreateCheckBox("Use R", "rUse");

            HarassMenu.AddGroupLabel("Settings");
            HarassMenu.CreateCheckBox("Use Q", "qUse");
            HarassMenu.CreateCheckBox("Use W", "wUse");
            HarassMenu.CreateCheckBox("Use E", "eUse");
            HarassMenu.CreateCheckBox("Use R", "rUse");

            AutoHarassMenu.AddGroupLabel("Settings");
            AutoHarassMenu.CreateCheckBox("Use Q", "qUse");
            AutoHarassMenu.CreateCheckBox("Use W", "wUse");
            AutoHarassMenu.CreateCheckBox("Use E", "eUse");
            AutoHarassMenu.CreateCheckBox("Use R", "rUse");

            LaneClearMenu.AddGroupLabel("Settings");
            LaneClearMenu.CreateCheckBox("Use Q", "qUse");
            LaneClearMenu.CreateCheckBox("Use W", "wUse");
            LaneClearMenu.CreateCheckBox("Use E", "eUse");
            LaneClearMenu.CreateCheckBox("Use R", "rUse");

            LasthitMenu.AddGroupLabel("Settings");
            LasthitMenu.CreateCheckBox("Use Q", "qUse");
            LasthitMenu.CreateCheckBox("Use W", "wUse");
            LasthitMenu.CreateCheckBox("Use E", "eUse");
            LasthitMenu.CreateCheckBox("Use R", "rUse");

            KillStealMenu.AddGroupLabel("Settings");
            KillStealMenu.CreateCheckBox("Use Q", "qUse");
            KillStealMenu.CreateCheckBox("Use W", "wUse");
            KillStealMenu.CreateCheckBox("Use E", "eUse");
            KillStealMenu.CreateCheckBox("Use R", "rUse");

            MiscMenu.AddGroupLabel("Settings");
            

            DrawingsMenu.AddGroupLabel("Setting");
            DrawingsMenu.CreateCheckBox("Draw Spell`s range only if they are ready.", "readyDraw");
            DrawingsMenu.CreateCheckBox("Draw damage indicator.", "damageDraw");
            DrawingsMenu.CreateCheckBox("Draw damage indicator percent.", "perDraw");
            DrawingsMenu.CreateCheckBox("Draw damage indicator statistics.", "statDraw");
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.CreateCheckBox("Draw Q.", "qDraw");
            DrawingsMenu.CreateCheckBox("Draw W.", "wDraw");
            DrawingsMenu.CreateCheckBox("Draw E.", "eDraw");
            DrawingsMenu.CreateCheckBox("Draw R.", "rDraw");
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.Red, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.Purple, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Orange, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.DeepPink, "R Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.Yellow, "DamageIndicator Color:");
        }
    }
}
