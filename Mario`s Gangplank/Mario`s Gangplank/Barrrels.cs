using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_sTemplate
{
    internal class Barrrels
    {
        public static Obj_AI_Base GetKillBarrel()
        {
            var barrel =
                ObjectManager.Get<Obj_AI_Base>()
                    .OrderBy(b => b.Health)
                    .FirstOrDefault(
                        o =>
                            o.Name.ToLower().Equals("barrel") && o.CountEnemiesInRange(350) > 1 && o.Health <= 1);
            return barrel;
        }

        public static Obj_AI_Base GetBarrel()
        {
            var barrel =
                ObjectManager.Get<Obj_AI_Base>()
                    .OrderBy(b => b.Health)
                    .FirstOrDefault(o => o.Name.ToLower().Equals("barrel") && o.CountEnemiesInRange(350) > 1);
            return barrel;
        }

        public static IEnumerable<Obj_AI_Base> GetBarrels()
        {
            var barrel =
                ObjectManager.Get<Obj_AI_Base>()
                    .Where(o => o.Name.ToLower().Equals("barrel"));
            return barrel;
        }
    }
}
