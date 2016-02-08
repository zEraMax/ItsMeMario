using EloBuddy;
using EloBuddy.SDK;
using static Mario_sTemplate.Helpers;

namespace Mario_sTemplate.Modes
{
    internal class Combo : Spells
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            if (target == null || target.IsZombie || target.HasUndyingBuff()) return;

            //Offensive COmbo
            if (GetKeyBindValue(MenuTypes.Combo, "keyBindModeCombo"))
            {
                if (GetCheckBoxValue(MenuTypes.Combo, "qCombo") && Q.IsReady() && target.IsValidTarget(Q.Range))
                {
                    Q.Cast();
                }
            }
            //Defensive Combo
            else
            {
                
            }
        }
    }
}
