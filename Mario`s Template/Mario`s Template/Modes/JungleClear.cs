using Mario_s_Lib;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class JungleClear
    {
        public static void Execute()
        {
            Q.TryToCast(Q.GetJungleMinion(), JungleClearMenu);
            W.TryToCast(Q.GetJungleMinion(), JungleClearMenu);
            E.TryToCast(Q.GetJungleMinion(), JungleClearMenu);
            R.TryToCast(Q.GetJungleMinion(), JungleClearMenu);
        }
    }
}