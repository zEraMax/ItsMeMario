using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Katarina
{
    internal class RHandler
    {
        public static bool CastingR;

        public static void Init()
        {
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Player.OnIssueOrder += Player_OnIssueOrder;
            Game.OnTick += Game_OnTick;
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe && args.Slot == SpellSlot.R)
            {
                OrbMovement(false);
                CastingR = true;
            }
        }

        private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            var orders = new[] {GameObjectOrder.MoveTo, GameObjectOrder.HoldPosition, GameObjectOrder.Stop, GameObjectOrder.AutoAttack};
            if (sender.IsMe && CastingR && orders.Contains(args.Order))
            {
                args.Process = false;
            }
        }

        public static void OrbMovement(bool state)
        {
            if (state)
            {
                Orbwalker.DisableAttacking = false;
                Orbwalker.DisableMovement = false;
            }
            else
            {
                Orbwalker.DisableAttacking = true;
                Orbwalker.DisableMovement = true;
            }
        }

        public static bool HasRBuff()
        {
            return Player.Instance.Spellbook.IsChanneling && Player.Instance.HasBuff("katarinarsound");
        }

        private static int Tick;
        private static void Game_OnTick(EventArgs args)
        {
            if(Tick > Environment.TickCount)return;
            if (CastingR && !HasRBuff())
            {
                OrbMovement(true);
                CastingR = false;
            }
            Tick = Environment.TickCount + 300;
        }
    }
}
