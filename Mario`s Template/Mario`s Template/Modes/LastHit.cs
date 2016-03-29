using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class LastHit
    {
        public static void Execute()
        {
            if (LasthitMenu.GetCheckBoxValue("qUse")) Q.TryToCast(Q.GetLastMinion());
            if (LasthitMenu.GetCheckBoxValue("wUse")) W.TryToCast(W.GetLastMinion());
            if (LasthitMenu.GetCheckBoxValue("eUse")) E.TryToCast(E.GetLastMinion());
            if (LasthitMenu.GetCheckBoxValue("rUse")) R.TryToCast(R.GetLastMinion());
        }
    }
}
