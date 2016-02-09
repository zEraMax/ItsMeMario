using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using SharpDX.Direct3D9;
using static Mario_sTemplate.Spells;
using static Mario_sTemplate.Helpers;

using Color = System.Drawing.Color;

namespace Mario_sTemplate.Ultilities
{
    internal class DamageIndicator
    {
        //Offsets
        private static readonly int YOff = 14;
        private static readonly int XOff = 0;
        private static readonly float Width = 104;
        private static readonly float Thick = 14f;
        //Offsets
        private static Font _Font, _Font2;
        private static Color color = Color.Yellow;

        public static void Init()
        {
            Drawing.OnEndScene += Drawing_OnEndScene;

            _Font = new Font(
                Drawing.Direct3DDevice,
                new FontDescription
                {
                    FaceName = "Segoi UI",
                    Height = 16,
                    Weight = FontWeight.Bold,
                    OutputPrecision = FontPrecision.Default,
                    Quality = FontQuality.ClearType,


                });

            _Font2 = new Font(
                Drawing.Direct3DDevice,
                new FontDescription
                {
                    FaceName = "Segoi UI",
                    Height = 11,
                    Weight = FontWeight.Bold,
                    OutputPrecision = FontPrecision.Default,
                    Quality = FontQuality.ClearType,

                });
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            foreach (var enemy in EntityManager.Heroes.Enemies.Where(e => e.IsValid && e.IsVisible) )
            {
                //Chat.Print(enemy.Position);
                var posX = enemy.HPBarPosition[0]+ 100 + XOff;
                var posY = enemy.HPBarPosition[1]+ 10 + YOff;
                //Maths OP Kappa
                var mathStat = "-" + Math.Round(GetTotalDamage(enemy)) + " / " +
                           Math.Round(enemy.Health - GetTotalDamage(enemy));
                var mathPercent = GetTotalDamage(enemy) / enemy.TotalShieldMaxHealth();
                var mathCurrentPercent = enemy.TotalShieldMaxHealth();
                //TODO Fix color
                var colour = Color.FromArgb(210, color);

                var initPos = new Vector2(enemy.HPBarPosition.X + mathPercent * Width, posY);
                var endPos = new Vector2(enemy.HPBarPosition.X + mathCurrentPercent * Width, posY);

                EloBuddy.SDK.Rendering.Line.DrawLine(colour, Width, initPos,endPos);
                //Drawing.DrawLine(initPos, endPos, Width, Color.Yellow);

                //Statistics
                
                var posXStat = (int)enemy.HPBarPosition[0];
                var posYStat = (int)enemy.HPBarPosition[1] +16 ;
                _Font2.DrawText(null, mathStat, posXStat, posYStat,SharpDX.Color.Yellow);
            }
        }
    }
}
