using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Mario_s_Template
{
    /// <summary>
    /// Vector Extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Checks if the position is solid
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static bool IsSolid(this Vector3 pos)
        {
            return pos.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Building) && pos.ToNavMeshCell().CollFlags.HasFlag(CollisionFlags.Wall);
        }
    }

    /// <summary>
    /// Spells Extensions
    /// </summary>
    public static partial class Extensions
    {
        #region CanCast

        public static bool CanCast(this Obj_AI_Base target, Spell.SpellBase spell)
        {
            if (spell == null) return false;
            return target.IsValidTarget(spell.Range) && spell.IsReady();
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Active spell)
        {
            var asBase = spell as Spell.SpellBase;
            return target.CanCast(asBase);
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Skillshot spell, int hitchancePercent = 75)
        {
            var asBase = spell as Spell.SpellBase;
            var pred = spell.GetPrediction(target);
            return target.CanCast(asBase) && pred.HitChancePercent >= 75;
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Chargeable spell)
        {
            var asBase = spell as Spell.SpellBase;
            return target.CanCast(asBase);
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Ranged spell)
        {
            var asBase = spell as Spell.SpellBase;
            return target.CanCast(asBase);
        }

        public static bool CanCast(this Obj_AI_Base target, Spell.Targeted spell)
        {
            var asBase = spell as Spell.SpellBase;
            return target.CanCast(asBase);
        }

        #endregion CanCast

        #region TryToCast

        public static bool TryToCast(this Spell.SpellBase spell, Obj_AI_Base target)
        {
            if (target == null) return false;
            return target.CanCast(spell) && spell.Cast(target);
        }

        public static bool TryToCast(this Spell.Active spell, Obj_AI_Base target)
        {
            if (target == null) return false;
            return target.CanCast(spell) && spell.Cast();
        }

        public static bool TryToCast(this Spell.Skillshot spell, Obj_AI_Base target)
        {
            if (target == null) return false;
            return target.CanCast(spell) && spell.Cast(target);
        }

        public static bool TryToCast(this Spell.Targeted spell, Obj_AI_Base target)
        {
            if (target == null) return false;
            return target.CanCast(spell) && spell.Cast(target);
        }

        public static bool TryToCast(this Spell.Chargeable spell, Obj_AI_Base target)
        {
            if (target == null) return false;
            return target.CanCast(spell) && spell.Cast(target);
        }

        public static bool TryToCast(this Spell.Ranged spell, Obj_AI_Base target)
        {
            if (target == null) return false;
            return target.CanCast(spell) && spell.Cast(target);
        }

        #endregion TryToCast

        #region Drawings

        public static bool DrawSpell(this Spell.SpellBase spell, Color color)
        {
            EloBuddy.SDK.Rendering.Circle.Draw(color, spell.Range, 1f, Player.Instance);
            return false;
        }

        #endregion Drawings
    }

    /// <summary>
    /// Menu Extensions
    /// </summary>
    public static partial class Extensions
    {
        #region Creating
        public static void CreateCheckBox(this Menu m, string displayName, string uniqueId, bool defaultValue = true)
        {
            try
            {
                m.Add(uniqueId, new CheckBox(displayName, defaultValue));
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Error creating the checkbox with the uniqueID = ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(uniqueId);
                Console.ResetColor();
            }
        }

        public static void CreateSlider(this Menu m, string displayName, string uniqueId, int defaultValue = 0, int minValue = 0, int maxValue = 100)
        {
            try
            {
                m.Add(uniqueId, new Slider(displayName, defaultValue, minValue, maxValue));
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Error creating the slider with the uniqueID = ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(uniqueId);
                Console.ResetColor();
            }
        }
        #endregion Creating

        #region Getting

        public static bool GetCheckBoxValue(this Menu m, string uniqueId)
        {
            try
            {
                return m.Get<CheckBox>(uniqueId).CurrentValue;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Error getting the checkbox with the uniqueID = ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(uniqueId);
                Console.ResetColor();
            }
            return false;
        }

        public static int GetSliderValue(this Menu m, string uniqueId)
        {
            try
            {
                return m.Get<Slider>(uniqueId).CurrentValue;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Error getting the slider with the uniqueID = ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(uniqueId);
                Console.ResetColor();
            }
            return -1;
        }
        #endregion Getting

    }

    /// <summary>
    /// Getting target extensions
    /// </summary>
    public static partial class Extensions
    {
        public static Obj_AI_Minion GetLastMinion(this Spell.SpellBase spell)
        {
            return
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .FirstOrDefault(
                        m =>
                            m.IsValidTarget(spell.Range) && Prediction.Health.GetPrediction(m, spell.CastDelay) <= m.GetDamage(spell.Slot) &&
                            m.IsEnemy);
        }

        public static AIHeroClient GetKillableHero(this Spell.SpellBase spell)
        {
            return
                EntityManager.Heroes.Enemies.FirstOrDefault(
                    e =>
                        e.IsValidTarget(spell.Range) && Prediction.Health.GetPrediction(e, spell.CastDelay) <= e.GetDamage(spell.Slot) &&
                        !e.HasUndyingBuff());
        }
    }
}
