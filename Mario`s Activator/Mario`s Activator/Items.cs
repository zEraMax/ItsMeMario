using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Activator
{
    public class MItem
    {
        public MItem(ItemId _itemId, float _range, ItemType _type, bool _requiresTarget, bool _afterAA = false)
        {
            ItemID = _itemId;
            Range = _range;
            IType = _type;
            RequireTarget = _requiresTarget;
            AfterAA = _afterAA;
        }

        public ItemId ItemID;
        public float Range;
        public ItemType IType;
        public bool RequireTarget;
        public bool AfterAA;

    }

    public enum ItemType
    {
        Offensive,
        Defensive,
        Consumable
    }

    internal class Offensive : Helpers
    {
        public static List<MItem> OffensiveItems = new List<MItem>
        {
            new MItem(ItemId.Bilgewater_Cutlass, 380, ItemType.Offensive, true),
            new MItem(ItemId.Blade_of_the_Ruined_King, 550, ItemType.Offensive, true),
            new MItem(ItemId.Tiamat, 380, ItemType.Offensive, false, true),
            new MItem(ItemId.Ravenous_Hydra, 380, ItemType.Offensive, false, true),
            new MItem(ItemId.Titanic_Hydra, Player.Instance.GetAutoAttackRange(), ItemType.Offensive, false, true),
            new MItem(ItemId.Youmuus_Ghostblade, 0, ItemType.Offensive, false),
            new MItem(ItemId.Hextech_Gunblade, 0, ItemType.Offensive, true),
            new MItem(ItemId.Manamune, 0, ItemType.Offensive, false),
            new MItem(ItemId.Frost_Queens_Claim, 4500, ItemType.Offensive, false),
        };

        public static void Cast()
        {
            foreach (var off in OffensiveItems)
            {
                var item = new Item(off.ItemID, off.Range);
                var target = TargetSelector.GetTarget(item.Range, DamageType.Mixed);

                if (target != null && item.IsOwned() && item.IsReady() && target.IsValidTarget())
                {
                    if (off.AfterAA)
                    {
                        if (Activator.CanPost)
                        {
                            if (off.RequireTarget)
                            {
                                Chat.Print("Casting an off item");
                                item.Cast(target);
                            }
                            else
                            {
                                Chat.Print("Casting an off item");
                                item.Cast();
                            }
                        }
                    }
                    else
                    {
                        if (off.RequireTarget)
                        {
                            Chat.Print("Casting an off item");
                            item.Cast(target);
                        }
                        else
                        {
                            Chat.Print("Casting an off item");
                            item.Cast();
                        }
                    }
                }
            }
        }
    }

    internal class Defensive : Helpers
    {
        public static List<MItem> DefensiveItems = new List<MItem>
        {
            new MItem(ItemId.Zhonyas_Hourglass, 0, ItemType.Defensive, false),
            new MItem(ItemId.Seraphs_Embrace, 0, ItemType.Defensive, false),
            new MItem(ItemId.Face_of_the_Mountain, 0, ItemType.Defensive, false),
            new MItem(ItemId.Talisman_of_Ascension, 0, ItemType.Defensive, false),
            new MItem(ItemId.Locket_of_the_Iron_Solari, 0, ItemType.Defensive, false),
            new MItem(ItemId.Randuins_Omen, 480, ItemType.Defensive, false),
            new MItem(ItemId.Ohmwrecker, 0, ItemType.Defensive, false),
        };

        public static void Cast(Obj_AI_Base target, int percent, int count = 1)
        {
            foreach (var def in DefensiveItems)
            {
                var item = new Item(def.ItemID, def.Range);

                switch (def.ItemID)
                {
                    case ItemId.Ohmwrecker:
                        if (target.IsReceivingTurretAA() && item.IsReady() && item.IsOwned())
                        {
                            item.Cast();
                        }
                        return;
                    case ItemId.Randuins_Omen:
                        if (Player.Instance.CountEnemiesInRange(item.Range) >= count && item.IsReady() && item.IsOwned())
                        {
                            item.Cast();
                        }
                        return;
                }

                if (item.IsReady() && item.IsOwned() && target != null && target.IsInDanger(percent))
                {
                    if (def.RequireTarget)
                    {
                        Chat.Print("Casting an def item");
                        item.Cast(target);
                    }
                    else
                    {
                        Chat.Print("Casting an def item");
                        item.Cast();
                    }
                }
            }
        }
    }

    internal class Cleansers : Helpers
    {
        public static List<MItem> CleansersItems = new List<MItem>
        {
            new MItem(ItemId.Mikaels_Crucible, 750, ItemType.Defensive, true),
            new MItem(ItemId.Dervish_Blade, 0, ItemType.Defensive, false),
            new MItem(ItemId.Mercurial_Scimitar, 0, ItemType.Defensive, false),
            new MItem(ItemId.Quicksilver_Sash, 0, ItemType.Defensive, false),
        };

        public static void Cast(Obj_AI_Base target)
        {
            if (target.HasBuffOfType(BuffType.Stun) || target.HasBuffOfType(BuffType.Snare) ||
                target.HasBuffOfType(BuffType.Blind))
            {
                foreach (var i in CleansersItems)
                {
                    var item = new Item(i.ItemID, i.Range);

                    if (item.IsReady() && item.IsOwned())
                    {
                        if (i.RequireTarget)
                        {
                            if (target.IsValidTarget(item.Range))
                            {
                                Chat.Print("Casting a cleanse item");
                                item.Cast(target);
                            }
                        }
                        else
                        {
                            Chat.Print("Casting a cleanse item");
                            item.Cast();
                        }
                    }
                }
            }
        }
    }

    internal class Consumables : Helpers
    {
        public static List<MItem> ComsumableItems = new List<MItem>
        {
            new MItem(ItemId.Health_Potion, 0, ItemType.Consumable, false),
            new MItem(ItemId.Total_Biscuit_of_Rejuvenation, 0, ItemType.Consumable, false),
            new MItem(ItemId.Hunters_Potion, 0, ItemType.Consumable, false),
            new MItem(ItemId.Corrupting_Potion, 0, ItemType.Consumable, false),
            new MItem(ItemId.Refillable_Potion, 0, ItemType.Consumable, false),
            new MItem(ItemId.Elixir_of_Iron, 0, ItemType.Consumable, false),
            new MItem(ItemId.Elixir_of_Wrath, 0, ItemType.Consumable, false),
            new MItem(ItemId.Elixir_of_Sorcery, 0, ItemType.Consumable, false),
        };

        public static void Cast(int percent)
        {
            foreach (var con in ComsumableItems)
            {
                var item = new Item(con.ItemID, con.Range);

                if (item.IsReady() && item.IsOwned() && Player.Instance.HealthPercent <= percent)
                {
                    switch (item.Id)
                    {
                        case ItemId.Elixir_of_Iron:
                            if (Player.Instance.CountAlliesInRange(800) >= 1 &&
                                Player.Instance.CountEnemiesInRange(800) >= 1 && item.IsReady() && item.IsOwned())
                            {
                                item.Cast();
                            }
                            return;
                        case ItemId.Elixir_of_Wrath:
                            if (Player.Instance.CountEnemiesInRange(Player.Instance.GetAutoAttackRange()) >= 1 &&
                                Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) && item.IsReady() &&
                                item.IsOwned())
                            {
                                item.Cast();
                            }
                            return;
                        case ItemId.Elixir_of_Sorcery:
                            if (Player.Instance.CountEnemiesInRange(Player.Instance.GetAutoAttackRange()) >= 1 &&
                                Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) && item.IsReady() &&
                                item.IsOwned())
                            {
                                item.Cast();
                            }
                            return;
                    }

                    Chat.Print("Casting an cons item");
                    item.Cast();
                }
            }
        }
    }
}
