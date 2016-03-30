using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class Harass
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Mixed);

            Q.TryToCast(target, HarassMenu);
            W.TryToCast(target, HarassMenu);
            E.TryToCast(target, HarassMenu);
            R.TryToCast(target, HarassMenu);
        }
    }
}
