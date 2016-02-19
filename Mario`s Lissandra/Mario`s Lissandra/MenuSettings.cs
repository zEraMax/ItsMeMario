using System.Collections.Generic;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Notifications;

namespace Mario_sLissandra
{
    internal class MenuSettings
    {
        public static readonly string MenuName = "Mario`s Lissanda";
        #region Variables
        public static Menu ComboMenu, HarassMenu, LaneClearMenu, JungleClearMenu, LastHitMenu, DrawingsMenu, SettingsMenu;
        #endregion Variables

        public static void LoadMenu()
        {
            var startMenu = MainMenu.AddMenu(MenuName, MenuName.ToLower());

            var notStart = new SimpleNotification("Mario`s Lissanda Loaded", "Mario`s Lissanda sucessfully loaded.");
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
            ComboMenu.Add("wCombo", new CheckBox("• Use W."));
            ComboMenu.Add("eCombo", new CheckBox("• Use E."));
            ComboMenu.Add("rCombo", new CheckBox("• Use R."));
            ComboMenu.AddGroupLabel("-:Combo Settings:-");
            ComboMenu.AddLabel("• E in offensive mode");
            ComboMenu.Add("eComboCountOff", new Slider("The enemy count around the target must be equal or less than ({0})", 3, 1,5));
            ComboMenu.AddLabel("• E in defensive mode");
            ComboMenu.Add("eComboCountDef", new Slider("The enemy count around the target must be equal or less than ({0})", 2, 1,5));
            ComboMenu.AddLabel("• R Settings");
            ComboMenu.Add("rComboPercent", new Slider("Player health must be less than ({0}%) to use R", 35));
            ComboMenu.Add("rComboCount", new Slider("The enemy count around the player must be equal or less than ({0})", 2, 1, 5));
            #endregion Combo

            #region Harass
            HarassMenu = startMenu.AddSubMenu(":-Harass Menu-:");
            HarassMenu.AddGroupLabel("-:Harass Spells:-");
            HarassMenu.Add("qHarass", new CheckBox("• Use Q."));
            HarassMenu.Add("wHarass", new CheckBox("• Use W."));
            HarassMenu.AddGroupLabel("-:Harass Settings:-");
            HarassMenu.Add("manaHarass", new Slider("Mana must be greater than ({0}) to use harass spells.", 30));
            HarassMenu.AddGroupLabel("-:AutoHarass Spells:-");
            HarassMenu.Add("qAutoHarass", new CheckBox("• Use Q."));
            HarassMenu.Add("wAutoHarass", new CheckBox("• Use W."));
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
            LaneClearMenu.AddGroupLabel("-:LaneClear Settings:-");
            LaneClearMenu.Add("manaLane", new Slider("Mana must be greater than ({0}) to use laneclear spells", 30));
            #endregion LaneClear

            #region JungleClear
            JungleClearMenu = startMenu.AddSubMenu(":-JungleClear Menu-:");
            JungleClearMenu.AddGroupLabel("-:JungleClear Spells:-");
            JungleClearMenu.Add("qJungle", new CheckBox("• Use Q."));
            JungleClearMenu.Add("wJungle", new CheckBox("• Use W."));
            JungleClearMenu.Add("eJungle", new CheckBox("• Use E."));
            JungleClearMenu.AddGroupLabel("-:JungleClear Settings:-");
            JungleClearMenu.Add("manaJungle", new Slider("Mana must be greater than ({0}) to use jungleclear spells.", 30));
            #endregion JungleClear

            #region Lasthit
            LastHitMenu = startMenu.AddSubMenu(":-LastHit Menu-:");
            LastHitMenu.AddGroupLabel("-:LastHit Spells:-");
            LastHitMenu.Add("qLast", new CheckBox("• Use Q."));
            LastHitMenu.Add("wLast", new CheckBox("• Use W."));
            LastHitMenu.AddGroupLabel("-:LastHit Settings:-");
            LastHitMenu.Add("manaLast", new Slider("Mana must be greater than ({0}) to use jungleclear spells.", 30));
            LastHitMenu.Add("wLastCount", new Slider("W count", 2, 0, 6));
            #endregion Lasthit

            #region Settings
            SettingsMenu = startMenu.AddSubMenu(":-Settings Menu-:");
            SettingsMenu.AddGroupLabel("-:Interrupt/Gapcloser:-");
            SettingsMenu.Add("spellInterrupt", new CheckBox("• Use R, on interruptables spells."));
            SettingsMenu.Add("spellGapcloser", new CheckBox("• Use W, on gapcloser."));
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
            DrawingsMenu.Add("wDraw", new CheckBox("• Draw W."));
            DrawingsMenu.Add("eDraw", new CheckBox("• Draw E."));
            DrawingsMenu.Add("rDraw", new CheckBox("• Draw R."));
            #endregion Drawings
        }
    }
}
