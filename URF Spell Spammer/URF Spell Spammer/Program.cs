using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Mario_s_Lib;
using static URF_Spell_Spammer.SpellManager;
using static URF_Spell_Spammer.Menus;

namespace URF_Spell_Spammer
{
    internal static class Program
    {
        private static void Main()
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            SpellManager.Init();
            Menus.Init();
            
            Game.OnUpdate += OnUpdate;
        }

        private static void OnUpdate(EventArgs args)
        {
            var target = TargetSelector.GetTarget(2000, DamageType.Mixed);
            if (target != null)
            {
                //Q
                if (Skillshots.Contains(Q))
                {
                    var qSS = Q as Spell.Skillshot;
                    qSS.TryToCast(target, FirstMenu, FirstMenu.GetSliderValue("qHitChance"));
                }
                else
                {
                    try
                    {
                        Q.TryToCast(target, FirstMenu);
                    }
                    catch (Exception)
                    {
                        Q.Cast();
                    }
                    
                }
                //W
                if (Skillshots.Contains(W))
                {
                    var wSS = W as Spell.Skillshot;
                    wSS.TryToCast(target, FirstMenu, FirstMenu.GetSliderValue("wHitChance"));
                }
                else
                {
                    try
                    {
                        W.TryToCast(target, FirstMenu);
                    }
                    catch (Exception)
                    {
                        W.Cast();
                    }
                }
                //E
                if (Skillshots.Contains(E))
                {
                    var eSS = E as Spell.Skillshot;
                    eSS.TryToCast(target, FirstMenu, FirstMenu.GetSliderValue("eHitChance"));
                }
                else
                {
                    try
                    {
                        E.TryToCast(target, FirstMenu);
                    }
                    catch (Exception)
                    {
                        E.Cast();
                    }
                }
                //R
                if (Skillshots.Contains(R))
                {
                    var rSS = R as Spell.Skillshot;
                    rSS.TryToCast(target, FirstMenu, FirstMenu.GetSliderValue("rHitChance"));
                }
                else
                {
                    try
                    {
                        R.TryToCast(target, FirstMenu);
                    }
                    catch (Exception)
                    {
                        R.Cast();
                    }
                }
            }
            else
            //No Target
            {
                //Q
                if (Skillshots.Contains(Q))
                {
                    Q.Cast(Game.CursorPos);
                }
                else
                {
                    Q.Cast();
                }
                //W
                if (Skillshots.Contains(W))
                {
                    W.Cast(Game.CursorPos);
                }
                else
                {
                    W.Cast();
                }
                //E
                if (Skillshots.Contains(W))
                {
                    E.Cast(Game.CursorPos);
                }
                else
                {
                    E.Cast();
                }
            }
        }
    }
}
