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
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.E).Ammo >= 2)
            {
                castQBarrel(target);
            }
            else
            {
                castQAlone(target);
            }
        }

        public static void castQAlone(Obj_AI_Base target)
        {
            if (target.IsValidTarget(Q.Range) && Q.IsReady())
            {
                Q.Cast(target);
            }
        }

        public static void castQBarrel(Obj_AI_Base target)
        {
            var barrel = Barrrels.GetKillBarrelWithEemyInside();
            if (barrel != null)
            {
                if (barrel.IsValidTarget(Q.Range) && Q.IsReady())
                {
                    Q.Cast(barrel);
                }
            }
            else
            {
                var barrelwithenemy = Barrrels.GetBarrelWithEemyInside();
                var ClosestkillBarrel = Barrrels.GetKillBarrelClosest();
                if (barrelwithenemy != null && ClosestkillBarrel != null)
                {
                    if (ClosestkillBarrel.IsInRange(barrelwithenemy, 850))
                    {
                        Q.Cast(ClosestkillBarrel);
                    }
                }
            }
        }

        public static void castE(Obj_AI_Base target)
        {
            if (target.IsValidTarget(E.Range + 400) && E.IsReady())
            {
                var barrelNearPlayer = Barrrels.GetBarrels().FirstOrDefault(b => b.IsInRange(Player.Instance, Q.Range + 50));
                if (barrelNearPlayer == null)
                {
                    E.Cast(!target.IsInRange(Player.Instance, 500) ? Player.Instance.Position.Extend(target, 500).To3D() : Player.Instance.Position.Extend(target, 250).To3D());
                }
                else if (barrelNearPlayer.Health <= 1 && barrelNearPlayer.Health > 0)
                {
                    var pred = E.GetPrediction(target);
                    var barrel = Barrrels.GetBarrels().FirstOrDefault(b => b.Distance(pred.CastPosition) <= 380);

                    if (barrel == null)
                    {
                        var predpos = pred.CastPosition;
                        if (predpos.IsInRange(barrelNearPlayer, 850) && Q.IsReady())
                        {
                            E.Cast(predpos);
                            Q.Cast(Barrrels.GetKillBarrelClosest());
                        }
                    }
                }
            }
        }

        public static void castR(int count)
        {
            var target = TargetSelector.GetTarget(int.MaxValue, dmgType);
            if (target != null && !target.IsZombie && !target.HasUndyingBuff())
            {
                if (R.IsReady() && target.CountEnemiesInRange(520) >= count)
                {
                    Player.Instance.Spellbook.CastSpell(SpellSlot.R, target.Position);
                }
            }
        }

        public static void castRKS(Obj_AI_Base target)
        {
            if (R.IsReady() && target.Health <= GetRKSDamage(target))
            {
                Player.Instance.Spellbook.CastSpell(SpellSlot.R, target.Position.Extend(target.Direction.To2D().Perpendicular(), target.MoveSpeed - 100).To3D());
            }
        }

        public static void castRSaveAlly(int allyHPPercent)
        {
            var ally = EntityManager.Heroes.Allies.FirstOrDefault(a => a.HealthPercent <= allyHPPercent);
            if (ally == null) return;
            var enemy = EntityManager.Heroes.Enemies.OrderBy(e => e.HealthPercent).FirstOrDefault(a => a.IsInRange(ally, 500));
            if (enemy == null) return;
            if (R.IsReady() && enemy.HealthPercent + 10 > ally.HealthPercent)
            {
                Player.Instance.Spellbook.CastSpell(SpellSlot.R, ally.Position.Extend(ally.Direction.To2D().Perpendicular(), ally.MoveSpeed - 100).To3D());
            }
        }

        #endregion Agressive
    }
}
