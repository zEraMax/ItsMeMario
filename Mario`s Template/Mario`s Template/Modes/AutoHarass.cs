using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class AutoHarass
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Mixed);

            Q.TryToCast(target, AutoHarassMenu);
            W.TryToCast(target, AutoHarassMenu);
            E.TryToCast(target, AutoHarassMenu);
            R.TryToCast(target, AutoHarassMenu);
        }
    }
}