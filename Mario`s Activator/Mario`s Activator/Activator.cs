using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Activator.Spells;
using static Mario_s_Activator.Spells.SummonerSpells;
using static Mario_s_Activator.MyMenu;

namespace Mario_s_Activator
{
    internal class Activator
    {
        public static bool CanPost;
        public static void Init()
        {
            InitializeSummonerSpells();
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
            Game.OnUpdate += Game_OnUpdate;
            InitializeMenu();
            Drawings.InitializeDrawings();

            Obj_AI_Base.OnBuffGain += Obj_AI_Base_OnBuffGain;
            GameObject.OnIntegerPropertyChange += GameObject_OnIntegerPropertyChange;
        }

        private static void GameObject_OnIntegerPropertyChange(GameObject sender, GameObjectIntegerPropertyChangeEventArgs args)
        {
            var hero = sender as AIHeroClient;
            var pinkWard = new Item(ItemId.Vision_Ward);

            if (hero != null && hero.IsEnemy && pinkWard.IsOwned() && pinkWard.IsReady() && (GameObjectCharacterState)args.Value == GameObjectCharacterState.IsStealth)
            {
                pinkWard.Cast(hero.Position);
            }
        }

        private static void Obj_AI_Base_OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (sender.IsEnemy) return;

            var itemCleanse =
                Cleansers.CleansersItems.FirstOrDefault(
                    i => i.IsReady() && i.IsOwned() && CleansersMenu.GetCheckBoxValue("check" + (int)i.Id));

            var delay = CleansersMenu.GetSliderValue("delayCleanse");

            if (itemCleanse != null)
            {
                if (itemCleanse.Id == ItemId.Mikaels_Crucible)
                {
                    var ally = EntityManager.Heroes.Allies.FirstOrDefault(a => a.HasCC());
                    if (ally != null)
                    {
                        Core.DelayAction(() => itemCleanse.Cast(ally), delay);
                    }
                }

                Core.DelayAction(() => itemCleanse.Cast(), delay);
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            OffensiveOnTick();
            ConsumablesOnTick();

            if (SettingsMenu.GetCheckBoxValue("debug"))
            {
                if (Player.Instance.IsInDanger(80))
                {
                    Chat.Print("On danger");
                }
            }
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            DefensiveOnTick();
            SmiteOnTick();
        }

        private static void OffensiveOnTick()
        { 
            var offItem = Offensive.OffensiveItems.FirstOrDefault(i => i.IsReady() && i.IsOwned() && OffensiveMenu.GetCheckBoxValue("check" + (int)i.Id));
            
            if (offItem != null)
            {
                var anyEnemy = ObjectManager.Get<Obj_AI_Base>().FirstOrDefault(e => e.IsEnemy && e.IsValidTarget(offItem.Range));
                if (anyEnemy != null)
                {
                    switch (offItem.Id)
                    {
                        case ItemId.Tiamat:
                        case ItemId.Ravenous_Hydra:
                        case ItemId.Titanic_Hydra:
                            if (CanPost)
                            {
                                offItem.Cast();
                            }
                            return;
                    }
                }

                var target = TargetSelector.GetTarget(offItem.Range, DamageType.Mixed);
                if (target != null && offItem.IsReady() && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                {
                    offItem.Cast(target);
                }
            }
        }

        public static void ConsumablesOnTick()
        {
            var itemConsumable =
                Consumables.ComsumableItems.FirstOrDefault(
                    i => i.IsReady() && i.IsOwned() && ConsumablesMenu.GetCheckBoxValue("check" + (int) i.Id));

            if (itemConsumable != null)
            {
                var sliderHealth = ConsumablesMenu.GetSliderValue("slider" + (int)itemConsumable.Id + "health");

                switch (itemConsumable.Id)
                {
                    case ItemId.Health_Potion:
                        if (Player.Instance.HealthPercent <= sliderHealth && !Player.Instance.HasBuff("RegenerationPotion"))
                        {
                            itemConsumable.Cast();
                        }
                        return;
                    case ItemId.Total_Biscuit_of_Rejuvenation:
                        if (Player.Instance.HealthPercent <= sliderHealth &&
                            Player.Instance.ManaPercent <= ConsumablesMenu.GetSliderValue("slider" + (int) itemConsumable.Id + "mana") &&
                            !Player.Instance.HasBuff("ItemMiniRegenPotion"))
                        {
                            itemConsumable.Cast();
                        }
                        return;
                    case ItemId.Hunters_Potion:
                        if (Player.Instance.HealthPercent <= sliderHealth &&
                            Player.Instance.ManaPercent <= ConsumablesMenu.GetSliderValue("slider" + (int) itemConsumable.Id + "mana") &&
                            !Player.Instance.HasBuff("ItemCrystalFlaskJungle"))
                        {
                            itemConsumable.Cast();
                        }
                        return;
                    case ItemId.Corrupting_Potion:
                        if (Player.Instance.HealthPercent <= sliderHealth &&
                            Player.Instance.ManaPercent <= ConsumablesMenu.GetSliderValue("slider" + (int) itemConsumable.Id + "mana") &&
                            !Player.Instance.HasBuff("ItemDarkCrystalFlask"))
                        {
                            itemConsumable.Cast();
                        }
                        return;
                    case ItemId.Refillable_Potion:
                        if (Player.Instance.HealthPercent <= sliderHealth && !Player.Instance.HasBuff("ItemCrystalFlask"))
                        {
                            itemConsumable.Cast();
                        }
                        return;
                    case ItemId.Elixir_of_Sorcery:
                        if (Player.Instance.CountEnemiesInRange(850) >= 1 &&
                            Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                        {
                            itemConsumable.Cast();
                        }
                        return;
                    case ItemId.Elixir_of_Wrath:
                        if (Player.Instance.CountEnemiesInRange(Player.Instance.GetAutoAttackRange() + 150) >= 1 &&
                            Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                        {
                            itemConsumable.Cast();
                        }
                        return;
                    case ItemId.Elixir_of_Iron:
                        if (Player.Instance.CountEnemiesInRange(850) >= 1 &&
                            Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                        {
                            itemConsumable.Cast();
                        }
                        return;
                }
            }
        }

        private static Spell.Targeted _protectSpell;
        public static void ProtectorOnTick()
        {
            var champS = ProtectSpells.Spells.FirstOrDefault(s => s.Champ == Player.Instance.Hero);
            if (champS != null)
            {
                var spell = Player.GetSpell(champS.Slot);
                if (spell != null)
                {
                    var range = spell.SData.CastRadius <= 0 ? spell.SData.CastRadius : spell.SData.CastRangeDisplayOverride;

                    _protectSpell = new Spell.Targeted(spell.Slot, (uint)range);

                    var ally = EntityManager.Heroes.Allies.FirstOrDefault(a => a.IsValidTarget(_protectSpell.Range));
                    var health = ProtectMenu.GetSliderValue("protectallyhealth");

                    if (ally != null && _protectSpell != null && ally.Health >= health)
                    {
                        _protectSpell.Cast(ally);
                    }

                }
            }
        }

        public static void DefensiveOnTick()
        {
            var defItem =
                Defensive.DefensiveItems.FirstOrDefault(
                    i => i.IsReady() && i.IsOwned() && DefensiveMenu.GetCheckBoxValue("check" + (int) i.Id));

            if (defItem != null)
            {
                switch (defItem.Id)
                {
                        case ItemId.Randuins_Omen:
                        if (Player.Instance.CountEnemiesInRange(defItem.Range) >=
                            DefensiveMenu.GetSliderValue("slider" + (int) defItem.Id))
                        {
                            defItem.Cast();
                        }
                        return;
                }
                if (Player.Instance.IsInDanger(DefensiveMenu.GetSliderValue("slider" + (int) defItem.Id)))
                {
                    try
                    {
                        defItem.Cast();
                    }
                    catch (Exception)
                    {
                        try
                        {
                            defItem.Cast(Player.Instance);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error casting def item");
                        }
                    }
                }
            }
        }

        #region SummonerOnTick

        public static void SmiteOnTick()
        {
            if (!PlayerHasSmite || !Smite.IsReady() || Smite == null || SummonerMenu.GetKeybindValue("smiteKeybind")) return;
            var GetJungleMinion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .FirstOrDefault(
                        m =>
                            MonsterSmiteables.Contains(m.BaseSkinName) && m.IsValidTarget(Smite.Range) &&
                            Prediction.Health.GetPrediction(m, Game.Ping + 20) <= SmiteDamage() &&
                            SummonerMenu.GetCheckBoxValue("monster" + m.BaseSkinName));

            if (GetJungleMinion != null)
            {
                Smite.Cast(GetJungleMinion);
            }

            if(!SummonerMenu.GetCheckBoxValue("smiteUseOnChampions"))return;
            var keepSmite = SummonerMenu.GetSliderValue("smiteKeep");

            var smiteGanker = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("playerganker"));

            if (smiteGanker != null && Smite.Handle.Ammo > keepSmite)
            {
                var target =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        e =>
                            Prediction.Health.GetPrediction(e, Game.Ping) <= SmiteKSDamage() && e.IsValidTarget(Smite.Range));

                if (target != null)
                {
                    Smite.Cast(target);
                    Chat.Print("KS");
                }
            }

            var smiteDuel = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("playerduel"));

            if (smiteDuel != null && Smite.Handle.Ammo > keepSmite)
            {
                var target = TargetSelector.GetTarget(Smite.Range, DamageType.Mixed);

                if (target != null)
                {
                    Smite.Cast(target);
                }
            }
        }

        public static void IgniteOnTick()
        {
            if (PlayerHasIgnite && SummonerMenu.GetCheckBoxValue("check" + "ignite"))
            {
                var target =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        e =>
                            e.IsValidTarget(Ignite.Range) &&
                            e.Health <= GetTotalDamage(e) + IgniteDamage() && e.Health >= IgniteDamage());
                if (target != null && Ignite.IsReady())
                {
                    Ignite.Cast(target);
                }
            }
            
        }

        public static void BarrierOnTick()
        {
            if (PlayerHasBarrier && SummonerMenu.GetCheckBoxValue("check" + "barrier") &&
                Player.Instance.IsInDanger(SummonerMenu.GetSliderValue("slider" + "barrier")))
            {
                Barrier.Cast();
            }
        }

        public static void HealOnTick()
        {
            if (PlayerHasHeal && SummonerMenu.GetCheckBoxValue("check" + "heal"))
            {
                var ally = EntityManager.Heroes.Allies.OrderBy(a => a.Health).FirstOrDefault(a => a.IsValidTarget(Heal.Range));
                if (Player.Instance.IsInDanger(SummonerMenu.GetSliderValue("slider" + "heal" + "me")) ||
                    ally.IsInDanger(SummonerMenu.GetSliderValue("slider" + "heal" + "ally")))
                {
                    Heal.Cast();
                }
            }
        }

        #endregion SummonerOnTick


        private static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            CanPost = true;
            Core.DelayAction(() => CanPost = false, 50);
        }
    }
}
