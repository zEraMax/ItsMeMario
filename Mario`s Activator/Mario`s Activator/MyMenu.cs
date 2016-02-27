using EloBuddy.SDK.Menu;

namespace Mario_s_Activator
{
    internal class MyMenu
    {
        private static readonly Menu FirstMenu = MainMenu.AddMenu("Mario`s Activator", "marioactivatorr");
        public static Menu OffensiveMenu = FirstMenu.AddSubMenu("• Offensive Items", "activatorOffensive");
        public static Menu DefensiveMenu = FirstMenu.AddSubMenu("• Defensive Items", "activatordefensive");
        public static Menu CleansersMenu = FirstMenu.AddSubMenu("• Cleansers", "activatorcleansers");
        public static Menu ConsumablesMenu = FirstMenu.AddSubMenu("• Consumables", "activatorconsumables");
        public static Menu SummonerMenu = FirstMenu.AddSubMenu("• Summoner Spells", "activatorSummonerspells");
        public static Menu SettingsMenu = FirstMenu.AddSubMenu("• Settings", "activatorsettings");
        public static Menu MiscMenu = FirstMenu.AddSubMenu("• Misc", "activatormisc");

        public static void InitializeMenu()
        {
            #region OffensiveMenu

            OffensiveMenu.AddGroupLabel("Bilgewater Cutlass");
            OffensiveMenu.CreateCheckBox("Use Bilgewater Cutlass.", "check3144");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3144", 90);
            OffensiveMenu.AddGroupLabel("Blade of the ruined kings");
            OffensiveMenu.CreateCheckBox("Use Blade of the ruined king.", "check3153");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3153", 60);
            OffensiveMenu.AddGroupLabel("Tiamat");
            OffensiveMenu.CreateCheckBox("Use tiamat.", "check3077");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3077", 90);
            OffensiveMenu.AddGroupLabel("Hydra");
            OffensiveMenu.CreateCheckBox("Use hydra.", "check3074");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3074", 90);
            OffensiveMenu.AddGroupLabel("Titanic Hydra");
            OffensiveMenu.CreateCheckBox("Use titanic hydra.", "check3053");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3053", 90);
            OffensiveMenu.AddGroupLabel("Youmuus");
            OffensiveMenu.CreateCheckBox("Use youmuus.", "check3142");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3142", 70);
            OffensiveMenu.AddGroupLabel("Hextech GunBlade");
            OffensiveMenu.CreateCheckBox("Use Hextech GunBlade.", "check3146");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3146", 40);
            OffensiveMenu.AddGroupLabel("Manamune");
            OffensiveMenu.CreateCheckBox("Use Manamune.", "check3004");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3004", 80);
            OffensiveMenu.AddGroupLabel("Frost Queens Claim");
            OffensiveMenu.CreateCheckBox("Use frost queen.", "check3092");
            OffensiveMenu.CreateSlider("Use it if the ENEMY health is lower than ({0}%).", "slider3092", 40);

            #endregion OffensiveMenu

            #region DefensiveMenu

            DefensiveMenu.AddGroupLabel("Zhonyas");
            DefensiveMenu.CreateCheckBox("Use Zhonyas.", "check" + "3157");
            DefensiveMenu.CreateSlider("Use it if MY health is lower than ({0}%).", "slider" + "3157", 20);
            DefensiveMenu.AddGroupLabel("Seraph");
            DefensiveMenu.CreateCheckBox("Use Seraph.", "check" + "3040");
            DefensiveMenu.CreateSlider("Use it if MY health is lower than ({0}%).", "slider" + "3040", 20);
            DefensiveMenu.AddGroupLabel("Face Of The Mountain");
            DefensiveMenu.CreateCheckBox("Use Face Of The Mountain.", "check" + "3401");
            DefensiveMenu.CreateSlider("Use it if MY health is lower than ({0}%).", "slider" + "3401", 10);
            DefensiveMenu.CreateSlider("Use it if ALLY health is lower than ({0}%).", "slider" + "3401" + "ally", 20);
            DefensiveMenu.AddGroupLabel("Talisman");
            DefensiveMenu.CreateCheckBox("Use Talisman.", "check" + "3069");
            DefensiveMenu.CreateSlider("Use it if MY health is lower than ({0}%).", "slider" + "3069", 20);
            DefensiveMenu.AddGroupLabel("Solari");
            DefensiveMenu.CreateCheckBox("Use Solari.", "check" + "3190");
            DefensiveMenu.CreateSlider("Use it if MY health is lower than ({0}%).", "slider" + "3190", 20);
            DefensiveMenu.AddGroupLabel("Randuins");
            DefensiveMenu.CreateCheckBox("Use Randuins.", "check" + "3143");
            DefensiveMenu.CreateSlider("Use it if there are ({0}) in range.", "slider" + "3143", 2, 0, 5);
            DefensiveMenu.AddGroupLabel("Ohmwrecker");
            DefensiveMenu.CreateCheckBox("Use Ohmwrecker.", "check" + "3056");
            DefensiveMenu.CreateSlider("Use it if MY health is lower than ({0}%).", "slider" + "3056", 60);

            #endregion DefensiveMenu

            #region CleansersMenu

            CleansersMenu.AddGroupLabel("What CC`s to use the items/spell ?");
            CleansersMenu.CreateCheckBox("Stun", "ccStun");
            CleansersMenu.CreateCheckBox("Blind", "ccBlind");
            CleansersMenu.CreateCheckBox("Slow", "ccSlow", false);
            CleansersMenu.CreateCheckBox("Snare", "ccSnare");
            CleansersMenu.CreateCheckBox("Supression", "ccSupression");
            CleansersMenu.CreateCheckBox("Taunt", "ccTaunt");
            CleansersMenu.AddLabel("Special spells to use cleanse");
            CleansersMenu.CreateCheckBox("ZedR", "ccZedR");
            CleansersMenu.CreateCheckBox("VladmirR", "ccVladmirR");
            CleansersMenu.CreateCheckBox("MordekaiserR", "ccMordekaiserR");
            CleansersMenu.AddGroupLabel("Mikael");
            CleansersMenu.CreateCheckBox("Use Mikael.", "check" + "3222");
            CleansersMenu.AddGroupLabel("Dervish Blade");
            CleansersMenu.CreateCheckBox("Use Dervish Blade.", "check" + "3137");
            CleansersMenu.AddGroupLabel("Mercurial Scimitar");
            CleansersMenu.CreateCheckBox("Use Mercurial Scimitar.", "check" + "3139");
            CleansersMenu.AddGroupLabel("QuickSilver");
            CleansersMenu.CreateCheckBox("Use QuickSilver.", "check" + "3140");
            //Has the summoner spell
            if (true)
            {
                CleansersMenu.AddGroupLabel("Summoner cleanse");
                CleansersMenu.CreateCheckBox("Use Summoner cleanse.", "check" + "cleanse");
            }

            #endregion CleansersMenu

            #region ConsumableMenu
            ConsumablesMenu.AddGroupLabel("Health Potion");
            ConsumablesMenu.CreateCheckBox("Use Health Potion.", "check" + "2003");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2003" + "health", 30);
            ConsumablesMenu.AddGroupLabel("Biscuit");
            ConsumablesMenu.CreateCheckBox("Use Biscuit.", "check" + "2010");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2010"+ "health", 30);
            ConsumablesMenu.CreateSlider("Use it if MY MANA is lower than ({0}%).", "slider" + "2010" + "mana", 30);
            ConsumablesMenu.AddGroupLabel("Hunter`s Potion");
            ConsumablesMenu.CreateCheckBox("Use Hunter`s Potion.", "check" + "2032");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2032" + "health", 30);
            ConsumablesMenu.CreateSlider("Use it if MY MANA is lower than ({0}%).", "slider" + "2032" + "mana", 30);
            ConsumablesMenu.AddGroupLabel("Health Potion");
            ConsumablesMenu.CreateCheckBox("Use Health Potion.", "check" + "2033");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2033", 30);
            ConsumablesMenu.AddGroupLabel("Health Potion");
            ConsumablesMenu.CreateCheckBox("Use Health Potion.", "check" + "2031");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2031", 30);
            ConsumablesMenu.AddGroupLabel("Health Potion");
            ConsumablesMenu.CreateCheckBox("Use Health Potion.", "check" + "2138");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2138", 30);
            ConsumablesMenu.AddGroupLabel("Health Potion");
            ConsumablesMenu.CreateCheckBox("Use Health Potion.", "check" + "2140");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2140", 30);
            ConsumablesMenu.AddGroupLabel("Health Potion");
            ConsumablesMenu.CreateCheckBox("Use Health Potion.", "check" + "2139");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2139", 30);
            #endregion ConsumablesMenu

            #region SummonerSpells

            if (SummonerSpells.PlayerHasSmite)
            {
                SummonerMenu.AddGroupLabel("Smite");
                SummonerMenu.CreateKeybind("Disable Smite", "smiteKeybind", 'Z');
                SummonerMenu.CreateCheckBox("Draw smite range.", "drawSmiteRange");
                SummonerMenu.AddLabel("Epic");
                SummonerMenu.CreateCheckBox("Smite Baron", "monster" + "SRU_Baron");
                SummonerMenu.CreateCheckBox("Smite Dragon", "monster" + "SRU_Dragon");
                SummonerMenu.AddLabel("Normal");
                SummonerMenu.CreateCheckBox("Smite Blue", "monster" + "SRU_Blue");
                SummonerMenu.CreateCheckBox("Smite Red", "monster" + "SRU_Red");
                SummonerMenu.CreateCheckBox("Smite Crab", "monster" + "Sru_Crab", false);
                SummonerMenu.AddLabel("Meh...");
                SummonerMenu.CreateCheckBox("Smite Gromp", "monster" + "SRU_Gromp", false);
                SummonerMenu.CreateCheckBox("Smite Murkwolf", "monster" + "SRU_Murkwolf", false);
                SummonerMenu.CreateCheckBox("Smite Razorbeak", "monster" + "SRU_Razorbeak", false);
            }

            #endregion SummonerSpells


        }
    }
}
