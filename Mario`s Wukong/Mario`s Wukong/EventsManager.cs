using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using static Mario_sWukong.Spells;
using static Mario_sWukong.Helpers;

namespace Mario_sWukong
{
    internal class EventsManager
    {
        public static bool CanPreAttack;
        public static bool CanPostAttack;

        public static void Intitialize()
        {
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (sender == null || sender.IsAlly) return;

            if (W.IsReady() && sender.IsValidTarget(200) && GetCheckBoxValue(MenuTypes.Settings, "spellGapcloser"))
            {
                W.Cast();
            }
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || hero.IsAlly) return;

            if (R.IsReady() && hero.IsValidTarget(R.Range) && GetCheckBoxValue(MenuTypes.Settings, "spellInterrupt"))
            {
                R.Cast();
            }
        }

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
    }
}
