using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Template.Menus;
using static Mario_s_Template.SpellsManager;

namespace Mario_s_Template.Modes
{
    internal class AutoHarass
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Mixed);

            if (AutoHarassMenu.GetCheckBoxValue("qUse")) Q.TryToCast(target);
            if (AutoHarassMenu.GetCheckBoxValue("wUse")) W.TryToCast(target);
            if (AutoHarassMenu.GetCheckBoxValue("eUse")) E.TryToCast(target);
            if (AutoHarassMenu.GetCheckBoxValue("rUse")) R.TryToCast(target);
        }
    }
}
