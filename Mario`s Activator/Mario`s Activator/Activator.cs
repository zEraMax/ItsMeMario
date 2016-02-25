using System;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Activator
{
    internal class Activator : Helpers
    {
        public static bool CanPost;
        public static void Init()
        {
            SummonerSpells.Initialize();
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnTick(EventArgs args)
        {
            Offensive.Cast();
            Consumables.Cast(40);
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            CanPost = true;
            Core.DelayAction(() => CanPost = false, 50);
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            Defensive.Cast(Player.Instance, 20);
            SummonerSpells.SmiteCast(false);
        }
    }
}
