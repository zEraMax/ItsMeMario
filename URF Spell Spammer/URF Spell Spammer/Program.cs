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
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            var target = TargetSelector.GetTarget(GetTheHighestRange(), DamageType.Mixed);
            if (target != null)
            {
                Q.TryToCast(target, FirstMenu);
                W.TryToCast(target, FirstMenu);
                E.TryToCast(target, FirstMenu);
                R.TryToCast(target, FirstMenu);
            }
            else
            {
                Q.Cast(Game.CursorPos);
                W.Cast(Game.CursorPos);
                E.Cast(Game.CursorPos);
                R.Cast(Game.CursorPos);
            }
        }
    }
}
