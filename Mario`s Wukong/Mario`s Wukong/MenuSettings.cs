using System.Collections.Generic;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Mario_sWukong
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
            };
            //
            ComboMenu.AddSeparator(5);
            ComboMenu.AddGroupLabel("-:Combo Spells:-");
            ComboMenu.Add("qCombo", new CheckBox("• Use Q."));
            ComboMenu.Add("wCombo", new CheckBox("• Use W."));
            ComboMenu.Add("eCombo", new CheckBox("• Use E."));
            ComboMenu.Add("rCombo", new CheckBox("• Use R."));
            ComboMenu.Add("rComboCount", new Slider("Min enemies to use R.", 2, 1, 5));
            #endregion Combo

            #region Harass
            HarassMenu = startMenu.AddSubMenu(":-Harass Menu-:");
            HarassMenu.AddGroupLabel("-:Harass Spells:-");
            HarassMenu.Add("qHarass", new CheckBox("• Use Q."));
            HarassMenu.Add("eHarass", new CheckBox("• Use E."));
            HarassMenu.AddGroupLabel("-:Harass Settings:-");
            HarassMenu.Add("manaHarass", new Slider("Mana must be greater than ({0}) to use harass spells.", 30));
            #endregion Harass

            #region LaneClear
            LaneClearMenu = startMenu.AddSubMenu(":-LaneClear Menu-:");
            LaneClearMenu.AddGroupLabel("-:LaneClear Spells:-");
            LaneClearMenu.Add("qLane", new CheckBox("• Use Q."));
            LaneClearMenu.Add("eLane", new CheckBox("• Use E."));
            LaneClearMenu.AddGroupLabel("-:LaneClear Settings:-");
            LaneClearMenu.Add("manaLane", new Slider("Mana must be greater than ({0}) to use laneclear spells", 30));
            #endregion LaneClear

            #region JungleClear
            JungleClearMenu = startMenu.AddSubMenu(":-JungleClear Menu-:");
            JungleClearMenu.AddGroupLabel("-:JungleClear Spells:-");
            JungleClearMenu.Add("qJungle", new CheckBox("• Use Q."));
            JungleClearMenu.Add("eJungle", new CheckBox("• Use E."));
            JungleClearMenu.AddGroupLabel("-:JungleClear Settings:-");
            JungleClearMenu.Add("manaJungle", new Slider("Mana must be greater than ({0}) to use jungleclear spells.", 30));
            #endregion JungleClear

            #region Lasthit
            LastHitMenu = startMenu.AddSubMenu(":-LastHit Menu-:");
            LastHitMenu.AddGroupLabel("-:LastHit Spells:-");
            LastHitMenu.Add("qLast", new CheckBox("• Use Q."));
            LastHitMenu.Add("eLast", new CheckBox("• Use E."));
            LastHitMenu.AddGroupLabel("-:LastHit Settings:-");
            LastHitMenu.Add("manaLast", new Slider("Mana must be greater than ({0}) to use jungleclear spells.", 30));
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
            DrawingsMenu.AddGroupLabel("-:Spells:-");
            DrawingsMenu.Add("qDraw", new CheckBox("• Draw Q."));
            DrawingsMenu.Add("wDraw", new CheckBox("• Draw W."));
            DrawingsMenu.Add("eDraw", new CheckBox("• Draw E."));
            DrawingsMenu.Add("rDraw", new CheckBox("• Draw R."));
            #endregion Drawings

        }
    }
}
