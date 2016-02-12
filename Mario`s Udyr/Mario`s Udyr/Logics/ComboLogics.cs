using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_sTemplate.Logics
{
    internal class ComboLogics : Helpers
    {
        public static List<Tuple<int, SpellSlot>> IndiceSpelList = new List<Tuple<int, SpellSlot>>();


        public static void CastSpells()
        {
            var getSlot = IndiceSpelList.OrderBy(p => p.Item1).FirstOrDefault();
            if(getSlot == null)return;

            var spell = Player.Spells.Find(s => s.Slot == getSlot.Item2);
            if (spell.IsReady)
            {
                Player.CastSpell(spell.Slot);
            }
        }

        public static void InitiateSpellsPriority()
        {
            IndiceSpelList.Add(new Tuple<int, SpellSlot>(0, SpellSlot.Q));
            IndiceSpelList.Add(new Tuple<int, SpellSlot>(1, SpellSlot.W));
            IndiceSpelList.Add(new Tuple<int, SpellSlot>(2, SpellSlot.E));
            IndiceSpelList.Add(new Tuple<int, SpellSlot>(3, SpellSlot.R));
        }

        private static void updateSpellPriority(SpellSlot spellSlot, int newPriority)
        {
            var spell = IndiceSpelList.Find(t => t.Item2 == spellSlot);
            IndiceSpelList.Remove(spell);

            IndiceSpelList.Add(new Tuple<int, SpellSlot>(newPriority, spellSlot));
        }

        public static void UpdatePriority()
        {
            var pQ = 0;
            var pW = 0;
            var pE = 0;
            var pR = 0;
            foreach (var enemy in EntityManager.Heroes.Enemies.Where(e => e.IsValidTarget(700)))
            {
                if (enemy.HealthPercent + 15 < Player.Instance.HealthPercent)
                {
                    updateSpellPriority(SpellSlot.Q, pQ++);
                }

                if (enemy.HealthPercent + 15 > Player.Instance.HealthPercent)
                {
                    updateSpellPriority(SpellSlot.Q, pW++);
                }

                if (!enemy.IsValidTarget(Player.Instance.GetAutoAttackRange() + 50))
                {
                    updateSpellPriority(SpellSlot.Q, pE++);
                }

                if (enemy.CountEnemiesInRange(110) >= 2)
                {
                    updateSpellPriority(SpellSlot.Q, pR++);
                }
            }
        }


        #region Agressive
        public static void castQ(Obj_AI_Base target)
        {
            if (target.IsValidTarget(Q.Range) && Q.IsReady() && CanPostAttack)
            {
                Q.Cast();
            }
        }

        #endregion Agressive

        #region Safe
        public static void castSafeE(Obj_AI_Base target)
        {
            if (target.IsValidTarget(E.Range) && E.IsReady() && target.CountEnemiesInRange(800) < 3)
            {
                E.Cast(target);
            }
        }
        #endregion Safe
    }
}
