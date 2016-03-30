using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class LaneClear
    {
        public static void Execute()
        {
            Q.TryToCast(Q.GetLastMinion(), LaneClearMenu);
            W.TryToCast(Q.GetLastMinion(), LaneClearMenu);
            E.TryToCast(Q.GetLastMinion(), LaneClearMenu);
            R.TryToCast(Q.GetLastMinion(), LaneClearMenu);
        }
    }
}
