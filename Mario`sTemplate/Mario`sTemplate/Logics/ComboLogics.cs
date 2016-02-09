using EloBuddy;
using EloBuddy.SDK;

using static Mario_sTemplate.Spells;
using static Mario_sTemplate.Helpers;

namespace Mario_sTemplate.Logics
{
    internal class ComboLogics
    {
        public static void castQ(Obj_AI_Base target)
        {
            if (target.IsValidTarget(Q.Range) && Q.IsReady())
            {
                Q.Cast(target);
            }
        }

        public static void castW(Obj_AI_Base target)
        {
            if (target.IsValidTarget(W.Range) && W.IsReady())
            {
                W.Cast(target);
            }
        }

        public static void castE(Obj_AI_Base target)
        {
            if (target.IsValidTarget(E.Range) && E.IsReady())
            {
                E.Cast(target);
            }
        }

        public static void castR(Obj_AI_Base target)
        {
            if (target.IsValidTarget(R.Range) && R.IsReady())
            {
                R.Cast(target);
            }
        }
    }
}
