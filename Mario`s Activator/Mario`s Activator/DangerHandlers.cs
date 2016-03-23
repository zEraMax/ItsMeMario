using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Spells;
using Mario_s_Activator.Spells;

namespace Mario_s_Activator
{
    public class TargetSpell
    {
        public Obj_AI_Base Target;
        public Obj_AI_Base Caster;
        public Champion Champ;
        public SpellSlot Slot;

        public TargetSpell(Obj_AI_Base target, Obj_AI_Base caster, Champion champ, SpellSlot slot)
        {
            Target = target;
            Caster = caster;
            Champ = champ;
            Slot = slot;
        }
    }
    
    public class NotMissile
    {
        public Geometry.ProjectionInfo Projection;
        public Obj_AI_Base Caster;
        public Champion Champ;
        public SpellSlot Slot;
        public string SName;

        public NotMissile(Geometry.ProjectionInfo projection, Obj_AI_Base caster, Champion champ, SpellSlot slot, string sname)
        {
            Projection = projection;
            Caster = caster;
            Champ = champ;
            Slot = slot;
            SName = sname;
        }
    }
    
    public static class DangerHandlers
    {
        public static List<MissileClient> Missiles = new List<MissileClient>();
        public static List<TargetSpell> TargettedSpells = new List<TargetSpell>();
        public static List<NotMissile> NotMissiles = new List<NotMissile>();
        public static bool ReceivingTowerAA;

        public static void Init()
        {
            //Missiles
            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
            //Targetted Spells
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            //Turrets AAs
            Obj_AI_Base.OnBasicAttack += Obj_AI_Base_OnBasicAttack;
            //Debug
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Obj_AI_Base_OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var tower = sender as Obj_AI_Turret;
            if (tower != null && args.Target.IsAlly)
            {
                ReceivingTowerAA = true;
                Core.DelayAction(() => ReceivingTowerAA = false, 100);
            }
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            foreach (var m in Missiles)
            {
                EloBuddy.SDK.Rendering.Circle.Draw(SharpDX.Color.Purple, 20f, 5f, m);
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
            }
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var target = args.Target as Obj_AI_Base;
            var senderHero = sender as AIHeroClient;
            if(args.IsAutoAttack()) return;
            if (senderHero != null && senderHero.IsEnemy)
            {
                if (target != null && target.IsAlly)
                {
                    var targettedSpell = new TargetSpell(target, senderHero, senderHero.Hero, args.Slot);
                    TargettedSpells.Add(targettedSpell);
                    Core.DelayAction(() => TargettedSpells.Remove(targettedSpell), 80);
                }
                if (target == null)
                { 
                    var projection = Player.Instance.Position.To2D().ProjectOn(args.Start.To2D(), args.End.To2D());
                    var notMissile = new NotMissile(projection, senderHero, senderHero.Hero, args.Slot, args.SData.Name);
                    NotMissiles.Add(notMissile);
                    Core.DelayAction(() => NotMissiles.Remove(notMissile), 80);
                }
            }
        }

        public static bool IsInDanger(this AIHeroClient target, int percent)
        {
            if (target == null || target.IsDead || !target.IsValid || target.IsInShopRange() || target.HealthPercent > percent) return false;
            //Missiles
            var missile = Missiles.FirstOrDefault(m => m.IsInRange(target, 2500) && m.IsValid);
            var champion = missile?.SpellCaster as AIHeroClient;

            if (champion != null)
            {
                var spell1 =
                    missile.SpellCaster.Spellbook.Spells.FirstOrDefault(
                        s => s.Name.ToLower().Equals(missile.SData.Name.ToLower()));
                var spell2 =
                    missile.SpellCaster.Spellbook.Spells.FirstOrDefault(
                        s => (s.Name.ToLower() + "missile").Equals(missile.SData.Name.ToLower()));

                var slot = SpellSlot.Unknown;
                if (spell1 != null)
                {
                    slot = spell1.Slot;
                }
                else if (spell2 != null)
                {
                    slot = spell2.Slot;
                }

                var projection = Player.Instance.Position.To2D()
                    .ProjectOn(missile.StartPosition.To2D(), missile.EndPosition.To2D());

                var boundingRadius = Player.Instance.BoundingRadius + MyMenu.SettingsMenu.GetSliderValue("saferange");

                if (projection.IsOnSegment &&
                    projection.SegmentPoint.Distance(Player.Instance.Position) <= missile.SData.CastRadius + boundingRadius)
                {
                    var DangSpell =
                        DangerousSpells.Spells.FirstOrDefault(
                            ds =>
                                ds.Slot == slot && champion.Hero == ds.Hero &&
                                missile.Distance(Player.Instance) <= boundingRadius + 300);

                    if (DangSpell != null)
                    {
                        return true;
                    }
                    return
                        missile.Distance(Player.Instance) <= boundingRadius;
                }

                if (missile.Distance(Player.Instance) <= boundingRadius)
                {
                    return true;
                }
            }

            if (TargettedSpells.Any())
            {
                var normalTargSpell = TargettedSpells.FirstOrDefault(t => t.Target == target);
                var dangTargSpell =
                    DangerousSpells.Spells.FirstOrDefault(
                        s => s.Hero == normalTargSpell?.Champ && s.Slot == normalTargSpell.Slot);
                if (dangTargSpell != null)
                {
                    return true;
                }
                if (normalTargSpell != null)
                {
                    return true;
                }
            }

            if (NotMissiles.Any())
            {
                var hueSPell = NotMissiles.FirstOrDefault(s => s.Projection.IsOnSegment);
                if (hueSPell != null)
                {
                    //If there`s a missile with the same name as the skillshot that it got from obj process cast
                    var missileSameName = Missiles.FirstOrDefault(m => m.SData.Name.ToLower().Contains(hueSPell.SName.ToLower()));
                    if (missileSameName != null) return false;
                    //
                    var spellInfo = SpellDatabase.GetSpellInfoList(hueSPell.Caster).FirstOrDefault(s => s.Slot == hueSPell.Slot);
                    if (spellInfo != null)
                    {
                        var segementPoint = hueSPell.Projection.SegmentPoint.Distance(Player.Instance.Position) <=
                                            spellInfo.Radius + Player.Instance.BoundingRadius + MyMenu.SettingsMenu.GetSliderValue("saferange");

                        if (segementPoint)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
