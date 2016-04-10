using EloBuddy;
using EloBuddy.SDK.Menu;
using Mario_s_Lib;
using static URF_Spell_Spammer.SpellManager;

namespace URF_Spell_Spammer
{
    internal class Menus
    {
        public static Menu FirstMenu;

        public static void Init()
        {
            FirstMenu = MainMenu.AddMenu("URF Spell Spammer", Player.Instance.ChampionName.ToLower() + "hueurfspammer");
            FirstMenu.AddGroupLabel("Spells");
            FirstMenu.CreateCheckBox(" - Use Q", "qUse");
            if (Skillshots.Contains(Q))
            {
                FirstMenu.CreateSlider("Q Hitchance %", "qHitChance", 75);
            }

            FirstMenu.CreateCheckBox(" - Use W", "wUse");
            if (Skillshots.Contains(W))
            {
                FirstMenu.CreateSlider("W Hitchance %", "wHitChance", 75);
            }

            FirstMenu.CreateCheckBox(" - Use E", "eUse");
            if (Skillshots.Contains(E))
            {
                FirstMenu.CreateSlider("E Hitchance %", "eHitChance", 75);
            }

            FirstMenu.CreateCheckBox(" - Use R", "rUse");
            if (Skillshots.Contains(R))
            {
                FirstMenu.CreateSlider("R Hitchance %", "rHitChance", 90);
            }
        }
    }
}
