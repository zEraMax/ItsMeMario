using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;

namespace Mario_sLissandra
{
    internal class EventsManager
    {
        public static bool CanPreAttack { get; private set; }
        public static bool CanPostAttack { get; private set; }
        public static MissileClient EMissile;

        public static void InitEventManagers()
        {
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
            Drawing.OnDraw += Drawing_OnDraw;
            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
        }

        private static void GameObject_OnCreate(GameObject sender, System.EventArgs args)
        {
            var missile = sender as MissileClient;
            if(missile == null)return;

            if (missile.Team.IsAlly() && missile.SpellCaster.IsMe && missile.SData.Name.ToLower().Equals("lissandraemissile"))
            {
                EMissile = missile;
            }
        }

        private static void GameObject_OnDelete(GameObject sender, System.EventArgs args)
        {
            var missile = sender as MissileClient;
            if (missile == null) return;

            if (missile.Team.IsAlly() && missile.SpellCaster.IsMe && missile.SData.Name.ToLower().Equals("lissandraemissile"))
            {
                EMissile = null;
            }
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (sender == null || sender.IsAlly) return;

            if (Spells.W.IsReady() && sender.IsValidTarget(200) && Helpers.GetCheckBoxValue(Helpers.MenuTypes.Settings, "spellGapcloser"))
            {
                Spells.W.Cast();
            }
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || hero.IsAlly) return;

            if (Spells.R.IsReady() && hero.IsValidTarget(Spells.R.Range) && Helpers.GetCheckBoxValue(Helpers.MenuTypes.Settings, "spellInterrupt"))
            {
                Spells.R.Cast();
            }
        }

        //Dont need to change
        private static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            CanPostAttack = false;
            CanPreAttack = true;
            Core.DelayAction(() => CanPreAttack = false, 60);
        }

        private static void Orbwalker_OnPostAttack(AttackableUnit target, System.EventArgs args)
        {
            CanPreAttack = false;
            CanPostAttack = true;
            Core.DelayAction(() => CanPostAttack = false, 60);
        }

        private static void Drawing_OnDraw(System.EventArgs args)
        {
            var ready = Helpers.GetCheckBoxValue(Helpers.MenuTypes.Drawings, "readyDraw");

            if (EMissile != null)
            {
                Circle.Draw(SharpDX.Color.MediumPurple, Spells.E.Width, 2f, EMissile);
                var target = TargetSelector.GetTarget(Helpers.highestRange, Helpers.dmgType);
                if (target != null && !target.IsZombie && !target.HasUndyingBuff())
                {
                    Circle.Draw(SharpDX.Color.Peru, 50, 10f, target.Position.Extend(EMissile.EndPosition, 120).To3D());
                }
            }

            if (Helpers.GetCheckBoxValue(Helpers.MenuTypes.Drawings, "qDraw") && (ready ? Spells.Q.IsReady() : Spells.Q.IsLearned))
            {
                Circle.Draw(SharpDX.Color.Red, Spells.Q.Range, 1f, Player.Instance);
            }

            if (Helpers.GetCheckBoxValue(Helpers.MenuTypes.Drawings, "wDraw") && (ready ? Spells.W.IsReady() : Spells.W.IsLearned))
            {
                Circle.Draw(SharpDX.Color.Blue, Spells.W.Range, 1f, Player.Instance);
            }

            if (Helpers.GetCheckBoxValue(Helpers.MenuTypes.Drawings, "eDraw") && (ready ? Spells.E.IsReady() : Spells.E.IsLearned))
            {
                Circle.Draw(SharpDX.Color.Purple, Spells.E.Range, 1f, Player.Instance);
            }

            if (Helpers.GetCheckBoxValue(Helpers.MenuTypes.Drawings, "rDraw") && (ready ? Spells.R.IsReady() : Spells.R.IsLearned))
            {
                Circle.Draw(SharpDX.Color.Orange, Spells.R.Range, 1f, Player.Instance);
            }
        }
    }
}
