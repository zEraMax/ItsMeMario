using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Spells;
using static Mario_s_Lib.Spells;

namespace URF_Spell_Spammer
{
    internal class SpellManager
    {
        public static Spell.SpellBase Q { get; private set; }
        public static Spell.SpellBase W { get; private set; }
        public static Spell.SpellBase E { get; private set; }
        public static Spell.SpellBase R { get; private set; }

        public static List<Spell.SpellBase> Skillshots = new List<Spell.SpellBase>(); 

        public static void Init()
        {
            var spellDB = SpellDatabase.GetSpellInfoList(Player.Instance);
            if (spellDB != null)
            {
                foreach (var spell in Player.Instance.Spellbook.Spells)
                {
                    var spellInfo = spellDB.FirstOrDefault(s => s.Slot == spell.Slot);
                    if (spellInfo != null)
                    {
                        switch (spell.Slot)
                        {
                            case SpellSlot.Q:
                                Q = GetSkillShotData(SpellSlot.Q, GetType(spellInfo));
                                Skillshots.Add(Q);
                                break;
                            case SpellSlot.W:
                                W = GetSkillShotData(SpellSlot.W, GetType(spellInfo));
                                Skillshots.Add(Q);
                                break;
                            case SpellSlot.E:
                                E = GetSkillShotData(SpellSlot.E, GetType(spellInfo));
                                Skillshots.Add(E);
                                break;
                            case SpellSlot.R:
                                R = GetSkillShotData(SpellSlot.R, GetType(spellInfo));
                                Skillshots.Add(R);
                                break;
                        }
                    }
                    else
                    {
                        if (Q == null)
                        {
                            switch (GetSpellType(SpellSlot.Q))
                            {
                                case Spells.Active:
                                    Q = new Spell.Active(SpellSlot.Q, GetSpellRange(SpellSlot.Q));
                                    break;
                                case Spells.Targeted:
                                    Q = new Spell.Targeted(SpellSlot.Q, GetSpellRange(SpellSlot.Q));
                                    break;
                            }
                        }
                        if (W == null)
                        {
                            switch (GetSpellType(SpellSlot.W))
                            {
                                case Spells.Active:
                                    W = new Spell.Active(SpellSlot.W, GetSpellRange(SpellSlot.W));
                                    break;
                                case Spells.Targeted:
                                    W = new Spell.Targeted(SpellSlot.W, GetSpellRange(SpellSlot.W));
                                    break;
                            }
                        }
                        if (E == null)
                        {
                            switch (GetSpellType(SpellSlot.E))
                            {
                                case Spells.Active:
                                    E = new Spell.Active(SpellSlot.E, GetSpellRange(SpellSlot.E));
                                    break;
                                case Spells.Targeted:
                                    E = new Spell.Targeted(SpellSlot.E, GetSpellRange(SpellSlot.E));
                                    break;
                            }
                        }
                        if (R == null)
                        {
                            switch (GetSpellType(SpellSlot.R))
                            {
                                case Spells.Active:
                                    R = new Spell.Active(SpellSlot.R, GetSpellRange(SpellSlot.R));
                                    break;
                                case Spells.Targeted:
                                    R = new Spell.Targeted(SpellSlot.R, GetSpellRange(SpellSlot.R));
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public enum Spells
        {
            Active,
            Targeted
        }

        public static Spells GetSpellType(SpellSlot slot)
        {
            switch (Player.Instance.Spellbook.GetSpell(slot).SData.TargettingType)
            {
                case SpellDataTargetType.Self:
                    return Spells.Active;
                case SpellDataTargetType.Unit:
                    return Spells.Targeted;
                case SpellDataTargetType.SelfAoe:
                    return Spells.Active;
                case SpellDataTargetType.SelfAndUnit:
                    return Spells.Active;
            }
            return Spells.Active;
        }

        private static SkillShotType GetType(SpellInfo info)
        {
            switch (info.Type)
            {
                case SpellType.Circle:
                    return SkillShotType.Circular;
                case SpellType.Line:
                    return SkillShotType.Linear;
                case SpellType.Cone:
                    return SkillShotType.Cone;
                case SpellType.MissileLine:
                    return SkillShotType.Linear;
                case SpellType.MissileAoe:
                    return SkillShotType.Circular;
            }
            return SkillShotType.Linear;
        }

        private static uint GetSpellRange(SpellSlot slot)
        {
            if (Player.Instance.Spellbook.GetSpell(slot).SData.CastRangeDisplayOverride >= 0)
            {
                return (uint)Player.Instance.Spellbook.GetSpell(slot).SData.CastRange;
            }
            return (uint)Player.Instance.Spellbook.GetSpell(slot).SData.CastRangeDisplayOverride;
        }

        public static float GetTheHighestRange()
        {
            var slots = new[] {SpellSlot.Q,SpellSlot.W, SpellSlot.E, SpellSlot.R};
            var spell = Player.Spells.OrderBy(s => GetSpellRange(s.Slot)).FirstOrDefault(s => slots.Contains(s.Slot));
            return spell != null ? GetSpellRange(spell.Slot) : 2000f;
        }
    }
}
