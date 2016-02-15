using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_sGangplank.Logics
{
    internal class ComboLogics : Helpers
    {
        #region Agressive

        public static void castQ(Obj_AI_Base target)
        {
            var barrel = Barrrels.GetKillBarrel();
            if (barrel != null && barrel.CountEnemiesInRange(380) >= 1)
            {
                if (barrel.IsValidTarget(Q.Range) && Q.IsReady() && barrel.CountEnemiesInRange(380) >= 1)
                {
                    Q.Cast(barrel);
                }
            }
            
            else
            {
                if (target.IsValidTarget(Q.Range) && Q.IsReady())
                {
                    Q.Cast(target);
                }
            }
        }

        public static void castE(Obj_AI_Base target)
        {
            if (target.IsValidTarget(E.Range) && E.IsReady())
            {
                var pred = E.GetPrediction(target);
                var barrel = Barrrels.GetBarrels().FirstOrDefault(b => b.Distance(pred.CastPosition) <= 380);
                
                if (barrel == null)
                {
                    E.Cast(pred.CastPosition);
                }
            }
        }

        public static void castR(int count)
        {
            var target = TargetSelector.GetTarget(int.MaxValue, dmgType);
            if (target != null && !target.IsZombie && !target.HasUndyingBuff())
            {
                if (R.IsReady() && target.CountEnemiesInRange(520) >= count -1)
                {
                    Player.Instance.Spellbook.CastSpell(SpellSlot.R, target.Position);
                }
            }
        }

        public static void castRKS(Obj_AI_Base target)
        {
            if (R.IsReady() && target.Health <= GetRKSDamage(target))
            {
                Player.Instance.Spellbook.CastSpell(SpellSlot.R,target.Position.Extend(target.Direction.To2D().Perpendicular(), target.MoveSpeed).To3D());
            }
        }

        #endregion Agressive
    }
}
