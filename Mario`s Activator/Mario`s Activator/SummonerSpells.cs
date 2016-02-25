using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Mario_s_Activator
{
    public static class SummonerSpells
    {
        public static Spell.Targeted Smite;
        public static bool PlayerHasSmite;
        public static Spell.Active Heal;

        public static string[] MonsterSmiteables =
{
            "TT_Spiderboss", "TTNGolem", "TTNWolf", "TTNWraith",
            "SRU_Blue", "SRU_Gromp", "SRU_Murkwolf", "SRU_Razorbeak",
            "SRU_Red", "SRU_Krug", "SRU_Dragon", "Sru_Crab", "SRU_Baron"
        };

        public static void Initialize()
        {
            //Smite
            var smite = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonersmite"));
            if (smite != null)
            {
                Smite = new Spell.Targeted(smite.Slot, 570);
                PlayerHasSmite = true;
                Chat.Print("Player has smite");
            }

            var heal = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("heal"));
            if (heal != null)
            {
                Heal = new Spell.Active(heal.Slot, 550);
                Chat.Print("Player has heal");
            }
        }

        public static void SmiteCast(bool useOnChampions, int keepSmite = 1)
        {
            if(!PlayerHasSmite && !Smite.IsReady())return;
            var GetJungleMinion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .FirstOrDefault(
                        m =>
                            MonsterSmiteables.Contains(m.BaseSkinName) && m.IsValidTarget(Smite.Range) &&
                            Prediction.Health.GetPrediction(m, Game.Ping + 50) <= SmiteDamage());

            if (GetJungleMinion != null)
            {
                Smite.Cast(GetJungleMinion);
            }
            var smiteGanker = Player.Spells.FirstOrDefault(s => s.Name.ToLower() == "s5_summonersmiteplayerganker");

            if(smiteGanker != null && useOnChampions && Smite.Handle.Ammo > keepSmite)
            {
                var target = EntityManager.Heroes.Enemies.FirstOrDefault(e => Prediction.Health.GetPrediction(e, Game.Ping + 50) <= e.Health && e.IsValidTarget(Smite.Range));

                if (target != null)
                {
                    Smite.Cast(target);
                }
            }

            var smiteDuel = Player.Spells.FirstOrDefault(s => s.Name.ToLower() == "s5_summonersmiteplayerduel");

            if (smiteDuel != null && useOnChampions && Smite.Handle.Ammo > keepSmite)
            {
                var target = TargetSelector.GetTarget(Smite.Range, DamageType.Mixed);

                if (target != null)
                {
                    Smite.Cast(target);
                }
            }
        }

        private static float SmiteDamage()
        {
            return 390 + 20 * (Player.Instance.Level - 1);
        }
    }
}
