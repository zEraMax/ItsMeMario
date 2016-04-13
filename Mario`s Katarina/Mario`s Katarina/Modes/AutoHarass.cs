using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;
using static Mario_s_Katarina.SpellsManager;
using static Mario_s_Katarina.Menus;

namespace Mario_s_Katarina.Modes
{
    /// <summary>
    ///     This mode will always run
    /// </summary>
    internal class AutoHarass
    {
        /// <summary>
        ///     Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellList.GetHighestRange(), DamageType.Mixed);

            Q.TryToCast(target, AutoHarassMenu);
            W.TryToCast(target, AutoHarassMenu);
        }
    }
}