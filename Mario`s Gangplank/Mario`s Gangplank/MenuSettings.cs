using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Notifications;

namespace Mario_sGangplank
{
    internal class MenuSettings
    {
        public static readonly string MenuName = "Mario`s Gangplank";

        #region Variables
        public static Menu ComboMenu, HarassMenu, LaneClearMenu, JungleClearMenu, LastHitMenu, DrawingsMenu, SettingsMenu;
        #endregion Variables

        public static void LoadMenu()
        {
            var startMenu = MainMenu.AddMenu(MenuName, MenuName.ToLower());

            var notStart = new SimpleNotification("Mario`s Gangplank Loaded", "Mario`s Gangplank sucessfully loaded.");
            Notifications.Show(notStart, 2500);

            #region Combo
            ComboMenu = startMenu.AddSubMenu(":-Combo Menu-:");
            ComboMenu.AddGroupLabel("-:Combo Spells:-");
            ComboMenu.Add("qCombo", new CheckBox("• Use Q."));
            ComboMenu.Add("eCombo", new CheckBox("• Use E."));
            ComboMenu.AddLabel("If the target is close to you");
            ComboMenu.Add("eComboRangeClose", new Slider("How close to put the barrel(0 on the player)", 150, 50, 600));
            ComboMenu.AddLabel("If the target is far from you");
            ComboMenu.Add("eComboRangeFar", new Slider("How close to put the barrel(0 on the player)", 350, 300, 800));
            ComboMenu.Add("rCombo", new CheckBox("• Use R."));
            ComboMenu.Add("rComboCount", new Slider("Minimun enemies to use R.(0 = Off)", 2, 0, 5));
            #endregion Combo

            #region Harass
            HarassMenu = startMenu.AddSubMenu(":-Harass Menu-:");
            HarassMenu.AddGroupLabel("-:Harass Spells:-");
            HarassMenu.Add("qHarass", new CheckBox("• Use Q."));
            HarassMenu.Add("eHarass", new CheckBox("• Use E.", false));
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
            LaneClearMenu.Add("qLane", new CheckBox("• Use Q on Barrel."));
            LaneClearMenu.Add("qLaneLast", new CheckBox("• Use Q to last hit."));
            LaneClearMenu.Add("eLane", new CheckBox("• Use E."));
            LaneClearMenu.Add("eKeep", new Slider("• Keep ({0}) barrels.", 1, 0, 4));
            LaneClearMenu.AddGroupLabel("-:LaneClear Settings:-");
            LaneClearMenu.Add("qLaneCount", new Slider("How many minions must be in range of the barrel.", 2,0,6));
            LaneClearMenu.Add("eLaneCount", new Slider("Minimun minions to place E.", 3,0,6));
            LaneClearMenu.Add("manaLane", new Slider("Mana must be greater than ({0}) to use laneclear spells", 30));
            #endregion LaneClear

            #region JungleClear
            JungleClearMenu = startMenu.AddSubMenu(":-JungleClear Menu-:");
            JungleClearMenu.AddGroupLabel("-:JungleClear Spells:-");
            JungleClearMenu.Add("qJungle", new CheckBox("• Use Q Barrel."));
            JungleClearMenu.Add("qJungleLast", new CheckBox("• Use Q to kill the minion."));
            JungleClearMenu.Add("eJungle", new CheckBox("• Use E."));
            JungleClearMenu.AddGroupLabel("-:JungleClear Settings:-");
            JungleClearMenu.Add("manaJungle", new Slider("Mana must be greater than ({0}) to use jungleclear spells.", 30));
            #endregion JungleClear

            #region Lasthit
            LastHitMenu = startMenu.AddSubMenu(":-LastHit Menu-:");
            LastHitMenu.AddGroupLabel("-:LastHit Spells:-");
            LastHitMenu.Add("qLast", new CheckBox("• Use Q."));
            LastHitMenu.AddGroupLabel("-:LastHit Settings:-");
            LastHitMenu.Add("manaLast", new Slider("Mana must be greater than ({0}) to use lasthit spells.", 30));
            #endregion Lasthit

            #region Settings
            SettingsMenu = startMenu.AddSubMenu(":-Settings Menu-:");
            SettingsMenu.AddGroupLabel("-:Q KS Settings:-");
            SettingsMenu.Add("qKS", new CheckBox("• Use Q to ks."));
            SettingsMenu.AddGroupLabel("-:R Settings:-");
            SettingsMenu.Add("rKS", new CheckBox("• Use R to ks."));
            SettingsMenu.Add("rKSOverkill", new Slider("R KS overkill, it will only ult if target health is greater than [{0}]", 150, 50, 400));
            SettingsMenu.Add("rToSaveAlly", new CheckBox("• Use R to save ally."));
            SettingsMenu.Add("rToSaveAllyPercent", new Slider("• Ally health to save him msut be less than ({0}).", 15));
            SettingsMenu.AddGroupLabel("-:W Settings:-"); 
            SettingsMenu.Add("wUsePercent", new Slider("• Use W if health is lower than ({0}).", 20));
            SettingsMenu.AddSeparator(1);
            SettingsMenu.Add("wBuffStun", new CheckBox("• Stun"));
            SettingsMenu.Add("wBuffSlow", new CheckBox("• Slow", false));
            SettingsMenu.Add("wBuffBlind", new CheckBox("• Blind"));
            SettingsMenu.Add("wBuffSupression", new CheckBox("• Supression"));
            SettingsMenu.Add("wBuffSnare", new CheckBox("• Snare"));
            SettingsMenu.Add("wBuffTaunt", new CheckBox("• Taunt"));
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
            DrawingsMenu.Add("barrelDraw", new CheckBox("• Draw Barrels."));
            #endregion Drawings
        }
    }
}
