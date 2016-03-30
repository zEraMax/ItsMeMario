using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Lux.SpellsManager;

namespace Mario_s_Lux.Modes
{
    internal class Harass
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(E.Range, DamageType.Mixed);

            Q.TryToCast(target, Menus.HarassMenu);
            E.TryToCast(target, Menus.HarassMenu);
        }
    }
}
