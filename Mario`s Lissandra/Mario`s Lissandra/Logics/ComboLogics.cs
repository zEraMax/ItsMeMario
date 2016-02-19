using EloBuddy;
using EloBuddy.SDK;

namespace Mario_sLissandra.Logics
{
    internal class ComboLogics : Helpers
    {
        public static void castQ(Obj_AI_Base target)
        {
            if (target.IsValidTarget(QExtended.Range) && Q.IsReady())
            {
                var predQextend = QExtended.GetPrediction(target);
                if (predQextend.CollisionObjects.Length >= 2 && predQextend.HitChancePercent >= 80)
                {
                    QExtended.Cast(predQextend.CastPosition);
                }
            }

            if (target.IsValidTarget(Q.Range) && Q.IsReady())
            {
                var predQ = Q.GetPrediction(target);
                if (predQ.HitChancePercent >= 70)
                {
                    Q.Cast(predQ.CastPosition);
                }
            }
        }

        public static void castW(Obj_AI_Base target)
        {
            if (target.IsValidTarget(W.Range) && W.IsReady())
            {
                W.Cast();
            }
        }

        public static void castE(Obj_AI_Base target, int count)
        {
            if (target.IsValidTarget(E.Range) && E.IsReady() && target.CountEnemiesInRange(800) <= count)
            {
                var predE = E.GetPrediction(target);
                var eTS = Player.Instance.Spellbook.GetSpell(SpellSlot.E).ToggleState;
                if(predE.HitChancePercent >= 90 && eTS == 1)
                {
                    E.Cast(predE.CastPosition);
                }
                if (eTS == 2 && E.IsReady() && EventsManager.EMissile != null)
                {
                    var Em = EventsManager.EMissile;
                    if ((Em!=null && Em.Position.CountEnemiesInRange(W.Range) >= 1 && Em.Distance(target.Position.Extend(Em.EndPosition, 120)) <= 50) || (Player.Instance.Distance(Em.EndPosition) <= 80))
                    {
                        E.Cast(Player.Instance);
                    }
                }
            }
        }

        public static void castR(Obj_AI_Base target, int count, int healthPercent)
        {
            if (target.IsValidTarget(R.Range) && R.IsReady() && target.CountEnemiesInRange(550) >= count && Prediction.Health.GetPrediction(target, R.CastDelay) <= GetDamage(SpellSlot.R, target) &&
                Prediction.Health.GetPrediction(target, R.CastDelay) >= Player.Instance.GetAutoAttackDamage(target))
            {
                R.Cast(target);
            }

            if (target.IsValidTarget(R.Range) && (Player.Instance.CountEnemiesInRange(R.Range) >= count || Player.Instance.HealthPercent <= healthPercent))
            {
                R.Cast(Player.Instance);
            }
        }

        public static void RKS(Obj_AI_Base target)
        {
            if (target.IsValidTarget(R.Range) && Prediction.Health.GetPrediction(target, R.CastDelay) <= GetDamage(SpellSlot.R, target) && R.IsReady())
            {
                R.Cast(target);
            }
        }
    }
}
