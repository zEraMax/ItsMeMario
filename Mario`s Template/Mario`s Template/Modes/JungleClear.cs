using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class JungleClear
    {
        public static void Execute()
        {
            Q.TryToCast(Q.GetLastMinion(), JungleClearMenu);
            W.TryToCast(Q.GetLastMinion(), JungleClearMenu);
            E.TryToCast(Q.GetLastMinion(), JungleClearMenu);
            R.TryToCast(Q.GetLastMinion(), JungleClearMenu);
        }
    }
}
