using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Activator
{
    public static class DamageHandler
    {
        public static List<MissileClient> Missiles = new List<MissileClient>();
        public static List<MissileClient> TurretAttacks = new List<MissileClient>();

        public static void Init()
        {
            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            foreach (var m in Missiles)
            {
                EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.Red, 80f, 5f, m);
            }
        }

        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile != null && missile.IsEnemy && missile.SpellCaster.IsEnemy)
            {
                var champion = missile.SpellCaster as AIHeroClient;
                if (champion.IsNotNull())
                {
                    Missiles.Add(missile);
                }
                var turret = missile.SpellCaster as Obj_AI_Turret;
                if (turret.IsNotNull())
                {
                    TurretAttacks.Add(missile);
                }
            }
        }

        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile != null && missile.IsEnemy && missile.SpellCaster.IsEnemy)
            {
                var champion = missile.SpellCaster as AIHeroClient;
                if (champion.IsNotNull())
                {
                    Missiles.Remove(missile);
                }
                var turret = missile.SpellCaster as Obj_AI_Turret;
                if (turret.IsNotNull())
                {
                    TurretAttacks.Remove(missile);
                }
            }
        }
        public static bool IsInDanger(this Obj_AI_Base target, int percent)
        {
            var missile = Missiles.FirstOrDefault(m => m.IsInRange(target, 1500));
            // ReSharper disable once UseNullPropagation
            if (missile != null)
            {
                var champion = missile.SpellCaster as AIHeroClient;
                if (champion != null)
                {
                    var spell1 = missile.SpellCaster.Spellbook.Spells.FirstOrDefault(s => s.Name.ToLower().Equals(missile.SData.Name.ToLower()));
                    var spell2 = missile.SpellCaster.Spellbook.Spells.FirstOrDefault(s => (s.Name.ToLower() + "missile").Equals(missile.SData.Name.ToLower()));

                    var slot = SpellSlot.Unknown;
                    if (spell1 != null)
                    {
                        slot = spell1.Slot;
                    }
                    else if (spell2 != null)
                    {
                        slot = spell2.Slot;
                    }

                    var projection = Player.Instance.Position.To2D().ProjectOn(missile.StartPosition.To2D(), missile.EndPosition.To2D());

                    if (projection.IsOnSegment &&
                        projection.SegmentPoint.Distance(Player.Instance.Position) <= missile.SData.CastRadius + Player.Instance.BoundingRadius + 30)
                    {
                        switch (missile.SpellCaster.Name)
                        {
                            case "Lux":
                                if (slot == SpellSlot.R && target.HealthPercent <= percent)
                                {
                                    return true;
                                }
                                break;
                            case "Xerath":
                                if (slot == SpellSlot.Q && target.HealthPercent <= percent)
                                {
                                    return true;
                                }
                                break;
                        }

                        var DangSpell =
                        DangerousSpells.Spells.FirstOrDefault(
                            ds =>
                                ds.Slot == slot && champion.Hero == ds.Hero &&
                                missile.IsInRange(target, target.BoundingRadius + 600));

                        if (DangSpell != null)
                        {
                            return true;
                        }
                        return missile.IsInRange(target, target.BoundingRadius + 500) && target.HealthPercent <= percent;
                    }
                }
            }
            return false;
        }

        public static bool IsReceivingTurretAA(this Obj_AI_Base target)
        {
            return TurretAttacks.Any(aa => aa.Target == target);
        }
    }
}
