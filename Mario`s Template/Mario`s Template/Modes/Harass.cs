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

            if (HarassMenu.GetCheckBoxValue("qUse")) Q.TryToCast(target);
            if (HarassMenu.GetCheckBoxValue("wUse")) W.TryToCast(target);
            if (HarassMenu.GetCheckBoxValue("eUse")) E.TryToCast(target);
            if (HarassMenu.GetCheckBoxValue("rUse")) R.TryToCast(target);
        }
    }
}
