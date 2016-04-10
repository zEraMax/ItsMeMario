using EloBuddy;
using EloBuddy.SDK.Menu;
using Mario_s_Lib;

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
            FirstMenu.CreateCheckBox(" - Use W", "wUse");
            FirstMenu.CreateCheckBox(" - Use E", "eUse");
            FirstMenu.CreateCheckBox(" - Use R", "rUse");
        }

    }
}
