using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Spells;

namespace Mario_s_Lib
{
    public static class Spells
    {
        public static bool CanCast(this Obj_AI_Base target, Spell.SpellBase spell, Menu m)
        {
            if (spell == null || target == null) return false;
            return target.IsValidTarget(spell.Range) && spell.IsReady() && m.GetCheckBoxValue(spell.Slot.ToString().ToLower() + "Use");
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Active spell, Menu m)
        {
            var asBase = spell as Spell.SpellBase;
            return target.CanCast(asBase, m);
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Skillshot spell, Menu m, int hitchancePercent = 75)
        {
            var asBase = spell as Spell.SpellBase;
            var pred = spell.GetPrediction(target);
            return target.CanCast(asBase, m) && pred.HitChancePercent >= 75;
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Chargeable spell, Menu m)
        {
            var asBase = spell as Spell.SpellBase;
            return target.CanCast(asBase, m);
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Ranged spell, Menu m)
        {
            var asBase = spell as Spell.SpellBase;
            return target.CanCast(asBase, m);
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Targeted spell, Menu m)
        {
            var asBase = spell as Spell.SpellBase;
            return target.CanCast(asBase, m);
        }

        public static bool TryToCast(this Spell.SpellBase spell, Obj_AI_Base target, Menu m)
        {
            if (target == null) return false;
            return target.CanCast(spell, m) && spell.Cast(target);
        }

        public static bool TryToCast(this Spell.Active spell, Obj_AI_Base target, Menu m)
        {
            if (target == null) return false;
            return target.CanCast(spell, m) && spell.Cast();
        }

        public static bool TryToCast(this Spell.Skillshot spell, Obj_AI_Base target, Menu m, int percent = 75)
        {
            if (target == null) return false;
            return target.CanCast(spell, m, percent) && spell.Cast(target);
        }

        public static bool TryToCast(this Spell.Targeted spell, Obj_AI_Base target, Menu m)
        {
            if (target == null) return false;
            return target.CanCast(spell, m) && spell.Cast(target);
        }

        public static bool TryToCast(this Spell.Chargeable spell, Obj_AI_Base target, Menu m)
        {
            if (target == null) return false;
            return target.CanCast(spell, m) && spell.Cast(target);
        }

        public static bool TryToCast(this Spell.Ranged spell, Obj_AI_Base target, Menu m)
        {
            if (target == null) return false;
            return target.CanCast(spell, m) && spell.Cast(target);
        }

        public static Spell.Skillshot GetSkillShotData(SpellSlot slot, SkillShotType skillType)
        {
            var spellData = SpellDatabase.GetSpellInfoList(Player.Instance).FirstOrDefault(s => s.Slot == slot);
            if (spellData != null)
            {
                return new Spell.Skillshot(slot, (uint)spellData.Range, skillType, (int)(1000 * spellData.Delay), (int)spellData.MissileSpeed, (int)spellData.Radius)
                {
                    AllowedCollisionCount = slot.GetCollisionCount()
                };
            }
            return null;
        }

        private static int GetCollisionCount(this SpellSlot slot)
        {
            var getDBValue = DataBases.CollisionCount.CollisionCountDB.FirstOrDefault(v => v.Slot == slot && v.Champion == Player.Instance.Hero);
            return getDBValue?.Count ?? 0;
        }
    }
}