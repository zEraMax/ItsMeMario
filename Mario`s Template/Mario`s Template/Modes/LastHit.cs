using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class LastHit
    {
        public static void Execute()
        {
            Q.TryToCast(Q.GetLastHitMinion(), LasthitMenu);
            W.TryToCast(Q.GetLastHitMinion(), LasthitMenu);
            E.TryToCast(Q.GetLastHitMinion(), LasthitMenu);
            R.TryToCast(Q.GetLastHitMinion(), LasthitMenu);
        }
    }
}