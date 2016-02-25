using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Activator
{
    internal class Helpers
    {
        public static Obj_AI_Base GetBestTarget(float range)
        {
            var hero = TargetSelector.GetTarget(range, DamageType.Mixed);
            return hero.IsNotNull() ? hero : null;
        }
    }
}
