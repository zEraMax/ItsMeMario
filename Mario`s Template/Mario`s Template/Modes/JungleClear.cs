using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class JungleClear
    {
        public static void Execute()
        {
            if (LaneClearMenu.GetCheckBoxValue("qUse")) Q.TryToCast(Q.GetLastMinion());
            if (LaneClearMenu.GetCheckBoxValue("wUse")) W.TryToCast(W.GetLastMinion());
            if (LaneClearMenu.GetCheckBoxValue("eUse")) E.TryToCast(E.GetLastMinion());
            if (LaneClearMenu.GetCheckBoxValue("rUse")) R.TryToCast(R.GetLastMinion());
        }
    }
}
