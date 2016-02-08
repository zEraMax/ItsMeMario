using System;
using EloBuddy;

namespace Mario_sTemplate.Ultilities
{
    internal class DamageIndicator
    {
        public static void Init()
        {
            Drawing.OnEndScene += Drawing_OnEndScene;
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
