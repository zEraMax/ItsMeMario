using System;
using EloBuddy;
using EloBuddy.SDK;
using Mario_sLissandra.Logics;

namespace Mario_sLissandra
{
    internal class ModeManager : Helpers
    {
        internal class Modes : Helpers
        {
            public static void Active()
            {
                var target = TargetSelector.GetTarget(highestRange, dmgType);
                if (target != null && !target.IsZombie && !target.HasUndyingBuff())
                {
                    ComboLogics.RKS(target);

                    if (GetSliderValue(MenuTypes.Harass, "manaAutoHarass") <= Player.Instance.ManaPercent && GetKeyBindValue(MenuTypes.Harass, "keyAutoHarass"))
                    {
                        if (GetCheckBoxValue(MenuTypes.Harass, "qAutoHarass"))
                        {
                            ComboLogics.castQ(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Harass, "wAutoHarass"))
                        {
                            ComboLogics.castW(target);
                        }
                    }
                }
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

                        if (GetCheckBoxValue(MenuTypes.Combo, "wCombo"))
                        {
                            ComboLogics.castW(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "eCombo"))
                        {
                            var count = GetSliderValue(MenuTypes.Combo, "eComboCountOff");
                            ComboLogics.castE(target, count);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "rCombo"))
                        {
                            var count = GetSliderValue(MenuTypes.Combo, "rComboCount");
                            var health = GetSliderValue(MenuTypes.Combo, "rComboPercent");
                            //ComboLogics.castR(target, count, health);
                        }
                    }
                    //Defensive
                    else
                    {
                        if (GetCheckBoxValue(MenuTypes.Combo, "qCombo"))
                        {
                            ComboLogics.castQ(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "wCombo"))
                        {
                            ComboLogics.castW(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "eCombo"))
                        {
                            var count = GetSliderValue(MenuTypes.Combo, "eComboCountDef");
                            ComboLogics.castE(target, count);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "rCombo"))
                        {
                            var count = GetSliderValue(MenuTypes.Combo, "rComboCount");
                            var health = GetSliderValue(MenuTypes.Combo, "rComboPercent");
                            ComboLogics.castR(target, count, health);
                        }
                    }
                }
            }

            public static void Harass()
            {
                var target = TargetSelector.GetTarget(highestRange, dmgType);
                if (target != null && !target.IsZombie && !target.HasUndyingBuff())
                {
                    if (GetSliderValue(MenuTypes.Harass, "manaHarass") <= Player.Instance.ManaPercent)
                    {
                        if (GetCheckBoxValue(MenuTypes.Harass, "qHarass"))
                        {
                            ComboLogics.castQ(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Harass, "wHarass"))
                        {
                            ComboLogics.castW(target);
                        }
                    }
                }
            }

            public static void Flee()
            {

            }

            public static void LaneClear()
            {
                if (GetSliderValue(MenuTypes.LaneClear, "manaLane") <= Player.Instance.ManaPercent)
                {
                    if (GetCheckBoxValue(MenuTypes.LaneClear, "qLane"))
                    {
                        FarmLogics.laneQ();
                    }

                    if (GetCheckBoxValue(MenuTypes.LaneClear, "wLane"))
                    {
                        var count = GetSliderValue(MenuTypes.LaneClear, "wLaneCount");
                        FarmLogics.lastW(count);
                    }
                }
            }

            public static void LastHit()
            {
                if (GetSliderValue(MenuTypes.LastHit, "manaLast") <= Player.Instance.ManaPercent)
                {
                    if (GetCheckBoxValue(MenuTypes.LastHit, "qLast"))
                    {
                        FarmLogics.lastQ();
                    }

                    if (GetCheckBoxValue(MenuTypes.LastHit, "wLast"))
                    {
                        var count = GetSliderValue(MenuTypes.LastHit, "wLastCount");
                        FarmLogics.lastW(count);
                    }
                }
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
