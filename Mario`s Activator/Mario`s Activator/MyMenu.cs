using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using Mario_s_Activator.Spells;
using static Mario_s_Activator.Spells.SummonerSpells;

namespace Mario_s_Activator
{
    internal class MyMenu
    {
        private static readonly Menu FirstMenu = MainMenu.AddMenu("Mario`s Activator", "marioactivatorr");
        public static Menu OffensiveMenu = FirstMenu.AddSubMenu("• Offensive Items", "activatorOffensive");
        public static Menu DefensiveMenu = FirstMenu.AddSubMenu("• Defensive Items", "activatordefensive");
        public static Menu CleansersMenu = FirstMenu.AddSubMenu("• Cleansers", "activatorcleansers");
        public static Menu ConsumablesMenu = FirstMenu.AddSubMenu("• Consumables", "activatorconsumables");
        public static Menu ProtectMenu = FirstMenu.AddSubMenu("• Protector", "activatorprotector");
        public static Menu SummonerMenu = FirstMenu.AddSubMenu("• Summoner Spells", "activatorSummonerspells");
        public static Menu DrawingMenu = FirstMenu.AddSubMenu("• Drawing", "activatordrawing");
        public static Menu SettingsMenu = FirstMenu.AddSubMenu("• Settings", "activatorsettings");
        public static Menu MiscMenu = FirstMenu.AddSubMenu("• Misc", "activatormisc");

        public static void InitializeMenu()
        {
            FirstMenu.AddGroupLabel("This addon is made by MarioGK and should not be redistributed in any way.");
            FirstMenu.AddGroupLabel("Any unauthorized redistribution without credits will result in severe consequences.");
            FirstMenu.AddGroupLabel("I hope you have fun using it and please give me feedbacks");

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
            CleansersMenu.AddGroupLabel("Cleanse settings");
            CleansersMenu.CreateSlider("Delay to use the cleanse item", "delayCleanse", 50, 0, 500);
            CleansersMenu.AddGroupLabel("What CC`s to use the items/spell ?");
            CleansersMenu.CreateCheckBox("Stun", "ccStun");
            CleansersMenu.CreateCheckBox("Blind", "ccBlind");
            CleansersMenu.CreateCheckBox("Slow", "ccSlow", false);
            CleansersMenu.CreateCheckBox("Snare", "ccSnare");
            CleansersMenu.CreateCheckBox("Supression", "ccSupression");
            CleansersMenu.CreateCheckBox("Taunt", "ccTaunt");
            CleansersMenu.CreateCheckBox("Charm", "ccCharm");
            CleansersMenu.CreateCheckBox("Polymorph", "ccPolymorph");
            CleansersMenu.AddLabel("Special spells to use cleanse");
            CleansersMenu.CreateCheckBox("Zed R", "ccZedR");
            CleansersMenu.CreateCheckBox("Vladmir R", "ccVladmirR");
            CleansersMenu.CreateCheckBox("Mordekaiser R", "ccMordekaiserR");
            CleansersMenu.CreateCheckBox("Trundle R", "ccTrundleR");
            CleansersMenu.AddGroupLabel("Items");
            CleansersMenu.CreateCheckBox("Use Dervish Blade.", "check" + "3137");
            CleansersMenu.CreateCheckBox("Use Mercurial Scimitar.", "check" + "3139");
            CleansersMenu.CreateCheckBox("Use QuickSilver.", "check" + "3140");
            CleansersMenu.AddGroupLabel("Mikael Settings");
            CleansersMenu.CreateCheckBox("Use Mikael.", "check" + "3222");
            CleansersMenu.AddSeparator();
            foreach (var ally in EntityManager.Heroes.Allies.Where(a => !a.IsMe))
            {
                CleansersMenu.CreateCheckBox("Use on "+ ally.ChampionName + "("+ally.Name+")", "check" + ally.ChampionName);
            }

            #endregion CleansersMenu

            #region ConsumableMenu
            ConsumablesMenu.AddGroupLabel("Health Potion");
            ConsumablesMenu.CreateCheckBox("Use Health Potion.", "check" + "2003");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2003" + "health", 45);
            ConsumablesMenu.AddGroupLabel("Biscuit");
            ConsumablesMenu.CreateCheckBox("Use Biscuit.", "check" + "2009");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2009" + "health", 45);
            ConsumablesMenu.CreateSlider("Use it if MY MANA is lower than ({0}%).", "slider" + "2009" + "mana", 30);
            ConsumablesMenu.AddGroupLabel("Hunter`s Potion");
            ConsumablesMenu.CreateCheckBox("Use Hunter`s Potion.", "check" + "2032");
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + "2032" + "health", 30);
            ConsumablesMenu.CreateSlider("Use it if MY MANA is lower than ({0}%).", "slider" + "2032" + "mana", 30);
            ConsumablesMenu.CreateCheckBox("Use Corrupting Potion.", "check" + (int)ItemId.Corrupting_Potion);
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + (int)ItemId.Corrupting_Potion + "health", 30);
            ConsumablesMenu.CreateSlider("Use it if MY MANA is lower than ({0}%).", "slider" + (int)ItemId.Corrupting_Potion + "mana", 30);
            ConsumablesMenu.CreateCheckBox("Use Refillable Potion.", "check" + (int)ItemId.Refillable_Potion);
            ConsumablesMenu.CreateSlider("Use it if MY HEALTH is lower than ({0}%).", "slider" + (int)ItemId.Refillable_Potion + "health", 30);
            ConsumablesMenu.AddGroupLabel("Elixirs");
            ConsumablesMenu.CreateCheckBox("Use Elixir Of Sorcery", "check" + (int) ItemId.Elixir_of_Sorcery);
            ConsumablesMenu.CreateCheckBox("Use Elixir Of Wrath", "check" + (int) ItemId.Elixir_of_Wrath);
            ConsumablesMenu.CreateCheckBox("Use Elixir Of Iron", "check" + (int) ItemId.Elixir_of_Iron);
            #endregion ConsumablesMenu

            #region ProtectMenu
            var champS = ProtectSpells.Spells.FirstOrDefault(s => s.Champ == Player.Instance.Hero);
            if (champS != null)
            {
                ProtectMenu.AddGroupLabel("Settings: ");
                ProtectMenu.CreateSlider("Ally health must be lower than {0}", "protectallyhealth", 20);
                ProtectMenu.AddGroupLabel("Spells: ");

                var spell = Player.GetSpell(champS.Slot);
                if (spell != null)
                {
                    ProtectMenu.CreateCheckBox("- Use spell " + spell.Name.Substring(spell.Name.Length - 1).ToUpper(),
                        "canUseSpell" + spell.Slot);
                }

                ProtectMenu.AddGroupLabel("WhiteList: ");
                foreach (var a in EntityManager.Heroes.Allies.Where(a => !a.IsMe))
                {
                    ProtectMenu.CreateCheckBox("- Can use on " + a.ChampionName + " (" + a.Name + ") ",
                        "canUseSpellOn" + a.ChampionName);
                }
            }
            else
            {
                ProtectMenu.AddGroupLabel("You dont have a spell to protect your allies");
            }

            #endregion ProtectMenu

            #region SummonerSpells

            if (PlayerHasSmite)
            {
                SummonerMenu.AddGroupLabel("Smite");
                SummonerMenu.CreateKeybind("Disable Smite", "smiteKeybind", 'Z');
                SummonerMenu.CreateCheckBox("Draw smite range.", "drawSmiteRange");
                SummonerMenu.AddSeparator();
                SummonerMenu.CreateCheckBox("Use smite on champions", "smiteUseOnChampions");
                SummonerMenu.CreateSlider("Keep how many smites", "smiteKeep", 1, 0, 2);

                switch (Game.MapId)
                {
                    case GameMapId.TwistedTreeline:
                        SummonerMenu.AddLabel("Epic");
                        SummonerMenu.CreateCheckBox("Smite Spider Boss", "monster" + "TT_Spiderboss");
                        SummonerMenu.AddLabel("Normal");
                        SummonerMenu.CreateCheckBox("Smite Golem", "monster" + "TTNGolem");
                        SummonerMenu.CreateCheckBox("Smite Wolf", "monster" + "TTNWolf");
                        SummonerMenu.CreateCheckBox("Smite Wraith", "monster" + "TTNWraith", false);
                        break;
                    case GameMapId.SummonersRift:
                        SummonerMenu.AddLabel("Epic");
                        SummonerMenu.CreateCheckBox("Smite Baron", "monster" + "SRU_Baron");
                        SummonerMenu.CreateCheckBox("Smite Dragon", "monster" + "SRU_Dragon");
                        SummonerMenu.CreateCheckBox("Smite RiftHearald", "monster" + "SRU_RiftHerald");
                        SummonerMenu.AddLabel("Normal");
                        SummonerMenu.CreateCheckBox("Smite Blue", "monster" + "SRU_Blue");
                        SummonerMenu.CreateCheckBox("Smite Red", "monster" + "SRU_Red");
                        SummonerMenu.CreateCheckBox("Smite Crab", "monster" + "Sru_Crab", false);
                        SummonerMenu.AddLabel("Meh...");
                        SummonerMenu.CreateCheckBox("Smite Gromp", "monster" + "SRU_Gromp", false);
                        SummonerMenu.CreateCheckBox("Smite Murkwolf", "monster" + "SRU_Murkwolf", false);
                        SummonerMenu.CreateCheckBox("Smite Razorbeak", "monster" + "SRU_Razorbeak", false);
                        SummonerMenu.CreateCheckBox("Smite Krug", "monster" + "SRU_Krug", false);
                        break;
                }
            }

            if (PlayerHasBarrier)
            {
                SummonerMenu.AddGroupLabel("Barrier");
                SummonerMenu.CreateCheckBox("Use Barrier.", "check" + "barrier");
                SummonerMenu.CreateSlider("Use it if MY health is lower than ({0}%).", "slider" + "barrier", 20);
            }

            if (PlayerHasHeal)
            {
                SummonerMenu.AddGroupLabel("Heal");
                SummonerMenu.CreateCheckBox("Use Heal.", "check" + "heal");
                SummonerMenu.CreateSlider("Use it if MY health is lower than ({0}%).", "slider" + "heal" + "me", 20);
                SummonerMenu.CreateSlider("Use it if ALLY health is lower than ({0}%).", "slider" + "heal" + "ally", 10);
            }

            if (PlayerHasIgnite)
            {
                SummonerMenu.AddGroupLabel("Ignite");
                SummonerMenu.CreateCheckBox("Use ignite.", "check" + "ignite");
            }

            #endregion SummonerSpells

            #region Drawings

            DrawingMenu.AddGroupLabel("All drawings settings");
            DrawingMenu.CreateCheckBox("Disable all drawings", "disableDrawings", false);

            #endregion Drawings

            #region Settings

            SettingsMenu.AddGroupLabel("Offensive items options");
            SettingsMenu.CreateCheckBox("Use offensive items only in combo", "combouseitems");
            SettingsMenu.AddGroupLabel("Danger Options");
            SettingsMenu.AddLabel("Dont mess with the options if you dont know what they do");
            SettingsMenu.CreateSlider("Extra range to be safe of a skillshot", "saferange", 110, 80, 180);

            SettingsMenu.CreateCheckBox("Enable developer debugging", "debug");

            #endregion Settings
        }
    }
}
