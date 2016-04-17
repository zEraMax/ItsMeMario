using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Mario_s_Lib;
using static Mario_s_Activator.SummonerSpells;
using static Mario_s_Activator.MyMenu;

namespace Mario_s_Activator
{
    public static class Cleanser
    {
        public static void Init()
        {
            Obj_AI_Base.OnBuffGain += Obj_AI_Base_OnBuffGain;
        }

        private static void Obj_AI_Base_OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (sender.IsEnemy) return;

            CleanseOnTick();
        }

        public static void CleanseOnTick()
        {
            var delay = CleansersMenu.GetSliderValue("delayCleanse");

            if (PlayerHasCleanse && Player.Instance.HasCC() && CleansersMenu.GetCheckBoxValue("check" + "cleanse"))
            {
                Core.DelayAction(() => Cleanse.Cast(), delay);
            }

            var itemCleanse =
                Cleansers.CleansersItems.FirstOrDefault(
                    i => i.IsReady() && i.IsOwned() && CleansersMenu.GetCheckBoxValue("check" + (int)i.Id));

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

                if (Player.Instance.HasCC())
                {
                    Core.DelayAction(() => itemCleanse.Cast(), delay);
                }
            }
        }
    }
}
