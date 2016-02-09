using System;
using EloBuddy.SDK;

using static Mario_sTemplate.Spells;
using static Mario_sTemplate.Helpers;
using static Mario_sTemplate.Logics.ComboLogics;

namespace Mario_sTemplate
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
                    //Offensive
                    if (GetComboBoxValue(MenuTypes.Combo, "comboBoxComboMode") == 0)
                    {
                        if (GetCheckBoxValue(MenuTypes.Combo, "qCombo"))
                        {
                            castQ(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "wCombo"))
                        {
                            castW(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "eCombo"))
                        {
                            castE(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "rCombo"))
                        {
                            castR(target);
                        }
                    }
                    //Defensive
                    else
                    {
                        if(GetCheckBoxValue(MenuTypes.Combo, "qCombo"))
                        {
                            castQ(target);
                        }

                        if (GetCheckBoxValue(MenuTypes.Combo, "wCombo"))
                        {
                            castW(target);
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
    }
}
