using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
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
                var target = TargetSelector.GetTarget(HighestRange, DmgType);
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
                        if(GetCheckBoxValue(MenuTypes.Combo, "qCombo"))
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

            }

            public static void LastHit()
            {

            }

            public static void JungleClear()
            {

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
