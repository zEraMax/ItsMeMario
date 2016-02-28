using System.Collections.Generic;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Notifications;

namespace Mario_sTemplate
{
    internal class MenuSettings
    {
        public static readonly string MenuName = "Mario`s Wukong";
        #region Variables
        public static Menu ComboMenu, HarassMenu, LaneClearMenu, JungleClearMenu, LastHitMenu, DrawingsMenu, SettingsMenu;
        #endregion Variables

        public static void LoadMenu()
        {
            var startMenu = MainMenu.AddMenu(MenuName, MenuName.ToLower());

            var notStart = new SimpleNotification("Mario`s Wukong Loaded", "Mario`s Wukong sucessfully loaded.");
            Notifications.Show(notStart, 2500);

            #region Combo
            ComboMenu = startMenu.AddSubMenu(":-Combo Menu-:");
            ComboMenu.AddGroupLabel("-:Combo Settings:-");
            var list = new List<string> {"Agressive", "Safe"};
            var comboBox = ComboMenu.Add("comboBoxComboMode", new ComboBox("Type of combos:", list));
            var key = ComboMenu.Add("keyBindModeCombo",
                new KeyBind("Key to change the mode", true, KeyBind.BindTypes.PressToggle, 'Z'));
            key.OnValueChange += delegate
            {
                comboBox.SelectedIndex = comboBox.SelectedIndex == 1 ? 0 : 1;
               
                var notModeChange = new SimpleNotification("Combo Mode Change", "Combo Mode changed to " + comboBox.SelectedText);
                Notifications.Show(notModeChange, 1000);
            };
            //
            ComboMenu.AddSeparator(5);
            ComboMenu.AddGroupLabel("-:Combo Spells:-");
            ComboMenu.Add("qCombo", new CheckBox("• Use Q."));
            ComboMenu.Add("eCombo", new CheckBox("• Use E."));
            ComboMenu.Add("rCombo", new CheckBox("• Use R."));
            ComboMenu.Add("rComboCount", new Slider("Only use R if there are ({0}) near.", 2, 0, 5));
            #endregion Combo

            #region Harass
            HarassMenu = startMenu.AddSubMenu(":-Harass Menu-:");
            HarassMenu.AddGroupLabel("-:Harass Spells:-");
            HarassMenu.Add("qHarass", new CheckBox("• Use Q."));
            HarassMenu.Add("eHarass", new CheckBox("• Use E."));
            HarassMenu.AddGroupLabel("-:Harass Settings:-");
            HarassMenu.Add("manaHarass", new Slider("Mana must be greater than ({0}) to use harass spells.", 30));
            HarassMenu.AddGroupLabel("-:AutoHarass Spells:-");
            HarassMenu.Add("qAutoHarass", new CheckBox("• Use Q."));
            HarassMenu.Add("eAutoHarass", new CheckBox("• Use E."));
            HarassMenu.AddGroupLabel("-:AutoHarass Settings:-");
            var keyAutoHarass = HarassMenu.Add("keyAutoHarass",
                new KeyBind("KeyBind to change on/off AutoHarass", false, KeyBind.BindTypes.PressToggle, 'T'));
            keyAutoHarass.OnValueChange += delegate
            {
                var notHarassOn = new SimpleNotification("AutoHarass Mode Change", "AutoHarass is now On. ");
                var notHarassOff = new SimpleNotification("AutoHarass Mode Change", "AutoHarass is now Off. ");

                Notifications.Show(keyAutoHarass.CurrentValue ? notHarassOn : notHarassOff, 1000);
            };
            HarassMenu.Add("manaAutoHarass", new Slider("Mana must be greater than ({0}) to use auto harass spells.", 45));
            #endregion Harass

            #region LaneClear
            LaneClearMenu = startMenu.AddSubMenu(":-LaneClear Menu-:");
            LaneClearMenu.AddGroupLabel("-:LaneClear Spells:-");
            LaneClearMenu.Add("qLane", new CheckBox("• Use Q."));
            LaneClearMenu.Add("wLane", new CheckBox("• Use W."));
            LaneClearMenu.Add("eLane", new CheckBox("• Use E."));
            LaneClearMenu.Add("rLane", new CheckBox("• Use R."));
            LaneClearMenu.AddGroupLabel("-:LaneClear Settings:-");
            LaneClearMenu.Add("manaLane", new Slider("Mana must be greater than ({0}) to use laneclear spells", 30));
            #endregion LaneClear

            #region JungleClear
            JungleClearMenu = startMenu.AddSubMenu(":-JungleClear Menu-:");
            JungleClearMenu.AddGroupLabel("-:JungleClear Spells:-");
            JungleClearMenu.Add("qJungle", new CheckBox("• Use Q."));
            JungleClearMenu.Add("wJungle", new CheckBox("• Use W."));
            JungleClearMenu.Add("eJungle", new CheckBox("• Use E."));
            JungleClearMenu.Add("rJungle", new CheckBox("• Use R."));
            JungleClearMenu.AddGroupLabel("-:JungleClear Settings:-");
            JungleClearMenu.Add("manaJungle", new Slider("Mana must be greater than ({0}) to use jungleclear spells.", 30));
            #endregion JungleClear

            #region Lasthit
            LastHitMenu = startMenu.AddSubMenu(":-LastHit Menu-:");
            LastHitMenu.AddGroupLabel("-:LastHit Spells:-");
            LastHitMenu.Add("qLast", new CheckBox("• Use Q."));
            LastHitMenu.Add("wLast", new CheckBox("• Use W."));
            LastHitMenu.Add("eLast", new CheckBox("• Use E."));
            LastHitMenu.Add("rLast", new CheckBox("• Use R."));
            LastHitMenu.AddGroupLabel("-:LastHit Settings:-");
            LastHitMenu.Add("manaLast", new Slider("Mana must be greater than ({0}) to use jungleclear spells.", 30));
            #endregion Lasthit

            #region Settings
            SettingsMenu = startMenu.AddSubMenu(":-Settings Menu-:");
            SettingsMenu.AddGroupLabel("-:Auto R:-");
            SettingsMenu.Add("rAutoCount", new Slider("Auto use R if there are ({0}) near.(0 = Off)", 3, 0, 5));
            SettingsMenu.AddGroupLabel("-:Interrupt/Gapcloser:-");
            SettingsMenu.Add("spellInterrupt", new CheckBox("• Use X, on interruptables spells."));
            SettingsMenu.Add("spellGapcloser", new CheckBox("• Use X, on gapcloser."));
            SettingsMenu.AddGroupLabel("-:Settings:-");
            LastHitMenu.Add("manaSettings", new Slider("Mana must be greater than ({0}) to use any spell in this menu.", 30));
            #endregion Settings

            #region Drawings
            DrawingsMenu = startMenu.AddSubMenu(":-Drawings Menu-:");
            DrawingsMenu.Add("readyDraw", new CheckBox("• Draw Spell`s range only if they are ready."));
            DrawingsMenu.Add("damageDraw", new CheckBox("• Draw damage indicator."));
            DrawingsMenu.Add("perDraw", new CheckBox("• Draw damage indicator percent."));
            DrawingsMenu.Add("statDraw", new CheckBox("• Draw damage indicator statistics"));
            DrawingsMenu.AddGroupLabel("-:Spells:-");
            DrawingsMenu.Add("qDraw", new CheckBox("• Draw Q."));
            DrawingsMenu.Add("eDraw", new CheckBox("• Draw E."));
            DrawingsMenu.Add("rDraw", new CheckBox("• Draw R."));
            #endregion Drawings
        }
    }
}
