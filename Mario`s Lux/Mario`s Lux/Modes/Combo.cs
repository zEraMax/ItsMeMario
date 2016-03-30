using EloBuddy;
using EloBuddy.SDK;
using static Mario_s_Lux.SpellsManager;
using static Mario_s_Lux.Menus;

namespace Mario_s_Lux.Modes
{
    internal class Combo
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(E.Range, DamageType.Mixed);

            Q.TryToCast(target, ComboMenu);

            if (Player.GetSpell(SpellSlot.E).ToggleState <= 0)
            {
                E.TryToCast(target, ComboMenu);
            }

            if(!ComboMenu.GetCheckBoxValue("smartCombo"))return;

            if ((target.HasBuffOfType(BuffType.Snare) && target.HasPassive()) || (target.HasBuffOfType(BuffType.Stun) && target.HasPassive()))
            {
                if (E.IsReady() && R.IsReady())
                {
                    var damage = target.GetDamage(SpellSlot.E) + target.GetDamage(SpellSlot.R) + target.GetPassiveDamage();
                    var predictedHealth = Prediction.Health.GetPrediction(target, R.CastDelay);
                    if (predictedHealth <= damage)
                    {
                        E.Cast(target.Position);
                        R.Cast(target.Position);
                    }
                }
            }
        }
    }
}
