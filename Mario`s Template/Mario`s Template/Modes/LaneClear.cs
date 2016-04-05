using Mario_s_Lib;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class LaneClear
    {
        public static void Execute()
        {
            Q.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
            W.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
            E.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
            R.TryToCast(Q.GetLastHitMinion(), LaneClearMenu);
        }
    }
}