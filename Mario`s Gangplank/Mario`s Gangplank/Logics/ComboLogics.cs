using System;
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
            if (Player.Instance.Spellbook.GetSpell(SpellSlot.E).Ammo >= 1)
            {
                castQBarrel(target);
            }
            else
            {
                var barrel = Barrrels.GetKillBarrelWithEemyInside();
                if (barrel != null)
                {
                    if (barrel.IsValidTarget(Q.Range) && Q.IsReady())
                    {
                        Q.Cast(barrel);
                    }
                }

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
            if (target.IsValidTarget(E.Range + 200) && E.IsReady())
            {
                var barrelNearPlayer = Barrrels.GetBarrels().FirstOrDefault(b => b.IsInRange(Player.Instance, Q.Range));
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
                        if (Q.IsReady())
                        {
                            E.Cast(predpos);
                            var killBC = Barrrels.GetKillBarrelClosest();
                            var buffKillableLink = killBC.Buffs.FirstOrDefault(b => b.Name.ToLower().Contains("link"));
                            if (buffKillableLink != null && killBC != null)
                            {
                                Q.Cast(killBC);
                            }
                        }
                    }
                }
            }
        }

        public static void CastEBetween()
        {
            var killBC = Barrrels.GetKillBarrelClosest();
            if (killBC != null)
            {
                var buffKillableLink = killBC.Buffs.FirstOrDefault(b => b.Name.ToLower().Contains("link"));
                var barrelWithEnemy = Barrrels.GetBarrelWithEemyInside();
                if (barrelWithEnemy != null && barrelWithEnemy.Health > 1)
                {
                    var buffWithEnemyLink = killBC.Buffs.FirstOrDefault(b => b.Name.ToLower().Contains("link"));
                    if (barrelWithEnemy != null && buffWithEnemyLink == null && buffKillableLink == null && E.IsReady())
                    {
                        var pos = killBC.Position.Extend(barrelWithEnemy, 500).To3D();
                        if (pos.Distance(barrelWithEnemy) <= 700)
                        {
                            E.Cast(pos);
                        }
                    }
                }
            }
        }

        public static void CastQMultipleBarrels()
        {
            var killBC = Barrrels.GetKillBarrelClosest();
            if (killBC != null)
            {
                var buffKillableLink = killBC.Buffs.FirstOrDefault(b => b.Name.ToLower().Contains("link"));
                var barrelWithEnemy = Barrrels.GetBarrelWithEemyInside();
                if (barrelWithEnemy != null && barrelWithEnemy.Health >= 1)
                {
                    var buffWithEnemyLink = killBC.Buffs.FirstOrDefault(b => b.Name.ToLower().Contains("link"));
                    if (barrelWithEnemy != null && buffWithEnemyLink != null && buffKillableLink != null && Q.IsReady())
                    {
                        Q.Cast(killBC);
                    }
                }
            }
        }

        public static void castR(int count)
        {
            var target = TargetSelector.GetTarget(int.MaxValue, dmgType);
            if (target != null && !target.IsZombie && !target.HasUndyingBuff())
            {
                if (R.IsReady() && target.CountEnemiesInRange(490) >= count)
                {
                    Player.Instance.Spellbook.CastSpell(SpellSlot.R, target.Position, target.Position);
                }
            }
        }

        public static void castRKS(Obj_AI_Base target)
        {
            if (R.IsReady() && Prediction.Health.GetPrediction(target, 350) <= GetRKSDamage(target) && !Player.Instance.IsInRange(target, 900))
            {
                Player.Instance.Spellbook.CastSpell(SpellSlot.R, target.ServerPosition);
            }
        }

        public static void castRSaveAlly(int allyHPPercent)
        {
            var ally = EntityManager.Heroes.Allies.FirstOrDefault(a => a.HealthPercent <= allyHPPercent && !a.IsMe);
            if (ally == null) return;
            var enemy = EntityManager.Heroes.Enemies.OrderBy(e => e.HealthPercent).FirstOrDefault(a => a.IsInRange(ally, 500));
            if (enemy == null) return;
            if (R.IsReady() && enemy.HealthPercent + 10 > ally.HealthPercent)
            {
                Player.Instance.Spellbook.CastSpell(SpellSlot.R, ally.ServerPosition.Extend(ally.Direction.To2D().Perpendicular(), ally.MoveSpeed - 100).To3D());
            }
        }

        #endregion Agressive
    }
}
