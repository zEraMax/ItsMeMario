using System;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using static Mario_s_Lux.EManager;

namespace Mario_s_Lux
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
            SpellsManager.Q.DrawSpell(Menus.QColorSlide.GetSharpColor());
            SpellsManager.W.DrawSpell(Menus.WColorSlide.GetSharpColor());
            SpellsManager.E.DrawSpell(Menus.EColorSlide.GetSharpColor());
            SpellsManager.R.DrawSpell(Menus.RColorSlide.GetSharpColor());

            if (GetE != null)
            {
                var pos = new Vector3(GetE.Position.To2D(), GetE.Position.Z - 100);
                EloBuddy.SDK.Rendering.Circle.Draw(Color.DeepPink, 350, pos);
            }
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
