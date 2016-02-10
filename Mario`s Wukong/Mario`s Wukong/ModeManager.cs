using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;

using static Mario_sWukong.Spells;
using static Mario_sWukong.Helpers;
using static Mario_sWukong.Logics.ComboLogics;
using static Mario_sWukong.Logics.FarmLogics;

namespace Mario_sWukong
{
    internal class ModeManager
    {
        internal class Modes
        {
            public static void Active()
            {
                
            }
            public static void Combo()
            {
                var target = TargetSelector.GetTarget(highestRange, dmgType);
                if (target != null && !target.IsZombie && !target.HasUndyingBuff())
                {
                    //Agressive
                    if (GetComboBoxValue(MenuTypes.Combo, "comboBoxComboMode") == 0)
                    {
                        if (GetCheckBoxValue(MenuTypes.Combo, "qCombo"))
                        {
                            castQ(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "wCombo"))
                        {
                            castW();
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "eCombo"))
                        {
                            castE(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "rCombo"))
                        {
                            var minEne = GetSliderValue(MenuTypes.Combo, "rComboCount");

                            castR(target, minEne);
                        }
                    }
                    //Safe
                    else
                    {
                        if (GetCheckBoxValue(MenuTypes.Combo, "qCombo"))
                        {
                            castQ(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "wCombo"))
                        {
                            castW();
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "eCombo"))
                        {
                            castSafeE(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "rCombo"))
                        {
                            var minEne = GetSliderValue(MenuTypes.Combo, "rComboCount");

                            castR(target, minEne);
                        }
                    }
                }
            }

            public static void Harass()
            {
                var target = TargetSelector.GetTarget(highestRange, dmgType);
                if (target != null && !target.IsZombie && !target.HasUndyingBuff())
                {
                    if (GetCheckBoxValue(MenuTypes.Harass, "qHarass"))
                    {
                        castQ(target);
                    }

                    if (GetCheckBoxValue(MenuTypes.Harass, "eHarass"))
                    {
                        castE(target);
                    }
                }
            }

            public static void Flee()
            {
                castW();
            }

            public static void LaneClear()
            {
                if (GetCheckBoxValue(MenuTypes.LaneClear, "qLane"))
                {
                    laneQ();
                }

                if (GetCheckBoxValue(MenuTypes.LaneClear, "eLane"))
                {
                    laneE();
                }
            }

            public static void LastHit()
            {
                if (GetCheckBoxValue(MenuTypes.LastHit, "qLast"))
                {
                    lastQ();
                }

                if (GetCheckBoxValue(MenuTypes.LastHit, "eLast"))
                {
                    lastE();
                }
            }

            public static void JungleClear()
            {
                if (GetCheckBoxValue(MenuTypes.JungleClear, "qJungle"))
                {
                    jungleQ();
                }

                if (GetCheckBoxValue(MenuTypes.JungleClear, "eJungle"))
                {
                    jungleE();
                }
            }
        }

        public static void Intitialize()
        {
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
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
                    Modes.JungleClear();
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

        private static void Drawing_OnDraw(EventArgs args)
        {
            var ready = GetCheckBoxValue(MenuTypes.Drawings, "readyDraw");

            if (GetCheckBoxValue(MenuTypes.Drawings, "qDraw") && (ready ? Q.IsReady() : Q.IsLearned))
            {
                Circle.Draw(SharpDX.Color.Red, Q.Range, 1f, Player.Instance);
            }

            if (GetCheckBoxValue(MenuTypes.Drawings, "wDraw") && (ready ? W.IsReady() : W.IsLearned))
            {
                Circle.Draw(SharpDX.Color.Blue, W.Range, 1f, Player.Instance);
            }

            if (GetCheckBoxValue(MenuTypes.Drawings, "eDraw") && (ready ? E.IsReady() : E.IsLearned))
            {
                Circle.Draw(SharpDX.Color.Purple, E.Range, 1f, Player.Instance);
            }

            if (GetCheckBoxValue(MenuTypes.Drawings, "rDraw") && (ready ? R.IsReady() : R.IsLearned))
            {
                Circle.Draw(SharpDX.Color.Orange, R.Range, 1f, Player.Instance);
            }
        }
    }
}
