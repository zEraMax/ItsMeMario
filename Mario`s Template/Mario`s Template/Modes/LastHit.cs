using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class LastHit
    {
        public static void Execute()
        {
            Q.TryToCast(Q.GetLastMinion(), LasthitMenu);
            W.TryToCast(Q.GetLastMinion(), LasthitMenu);
            E.TryToCast(Q.GetLastMinion(), LasthitMenu);
            R.TryToCast(Q.GetLastMinion(), LasthitMenu);
        }
    }
}
