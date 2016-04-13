using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;
using static Mario_s_Katarina.SpellsManager;
using static Mario_s_Katarina.Menus;
using static Mario_s_Katarina.RHandler;

namespace Mario_s_Katarina.Modes
{
    /// <summary>
    ///     This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class Combo
    {
        /// <summary>
        ///     Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellList.GetHighestRange(), DamageType.Mixed);

            if (!CastingR)
            {
                W.TryToCast(target, ComboMenu);
                Q.TryToCast(target, ComboMenu);
                E.TryToCast(target, ComboMenu);
            }

            R.TryToCast(target, ComboMenu);
        }
    }
}