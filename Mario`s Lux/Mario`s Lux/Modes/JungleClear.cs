using static Mario_s_Lux.SpellsManager;
using static Mario_s_Lux.Menus;

namespace Mario_s_Lux.Modes
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
