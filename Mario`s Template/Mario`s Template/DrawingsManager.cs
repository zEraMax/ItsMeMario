using System;
using EloBuddy;
using static Mario_s_Template.SpellsManager;
using static Mario_s_Template.Menus;

namespace Mario_s_Template
{
    internal class DrawingsManager
    {
        public static void InitializeDrawings()
        {
            Drawing.OnDraw += Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
            DamageIndicator.Init();
        }

        /// <summary>
        /// Normal Drawings will not ovewrite any of LOL Sprites
        /// </summary>
        /// <param name="args"></param>
        private static void Drawing_OnDraw(EventArgs args)
        {
            Q.DrawSpell(QColorSlide.GetSharpColor());
            W.DrawSpell(WColorSlide.GetSharpColor());
            E.DrawSpell(EColorSlide.GetSharpColor());
            R.DrawSpell(RColorSlide.GetSharpColor());
        }

        /// <summary>
        /// This one will overwrite LOL sprites like menus, healthbar and etc
        /// </summary>
        /// <param name="args"></param>
        private static void Drawing_OnEndScene(EventArgs args)
        {
           
        }
    }
}
