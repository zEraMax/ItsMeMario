using System;
using EloBuddy;
using EloBuddy.SDK;
using Mario_sTemplate.Logics;

namespace Mario_sTemplate
{
    internal class ModeManager : Helpers
    {
        internal class Modes : Helpers
        {
            public static void Active()
            {

            }

            public static void Combo()
            {
                var target = TargetSelector.GetTarget(highestRange, dmgType);
                if (target != null && !target.IsZombie && !target.HasUndyingBuff())
                {
                    //Offensive
                    if (GetComboBoxValue(MenuTypes.Combo, "comboBoxComboMode") == 0)
                    {
                        if (GetCheckBoxValue(MenuTypes.Combo, "qCombo"))
                        {
                            ComboLogics.castQ(target);
                        }
                    }
                    //Defensive
                    else
                    {
                        if (GetCheckBoxValue(MenuTypes.Combo, "qCombo"))
                        {
                            ComboLogics.castQ(target);
                        }
                    }
                }
            }

            public static void Harass()
            {

            }

            public static void Flee()
            {

            }

            public static void LaneClear()
            {
                FarmLogics.laneQ();
            }

            public static void LastHit()
            {

            }

            public static void JungleClear()
            {

            }
        }

        public static void InitModeManager()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            try
            {
                Modes.Active();

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                {
                    Modes.Combo();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                {
                    Modes.Harass();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
                {
                    Modes.Flee();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                {
                    Modes.LaneClear();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
                {
                    Modes.LastHit();
                }

                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                {
                    Modes.JungleClear();
                }
            }
            catch (Exception exp)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("============================= ERROR IN MODE =============================");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(exp);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("============================= ERROR IN MODE =============================");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
