using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class Combo
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Mixed);

            Q.TryToCast(target, ComboMenu);
            W.TryToCast(target, ComboMenu);
            E.TryToCast(target, ComboMenu);
            R.TryToCast(target, ComboMenu);
        }
    }
}