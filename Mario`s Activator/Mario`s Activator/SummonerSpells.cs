using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Mario_s_Activator
{
    public static class SummonerSpells
    {
        public static Spell.Active Heal;
        public static bool PlayerHasHeal;
        public static Spell.Targeted Ignite;
        public static bool PlayerHasIgnite;

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
            //Heal
            var heal = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonerheal"));
            if (heal != null)
            {
                Heal = new Spell.Active(heal.Slot, 550);
                PlayerHasHeal = true;
                Chat.Print("Player has heal");
            }
            //Ignite
            var ignite = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonerignite"));
            if (ignite != null)
            {
                Ignite = new Spell.Targeted(ignite.Slot, 000);
                PlayerHasIgnite = true;
                Chat.Print("Player has ignite");
            }
            //Poro Mark
            var poro = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonersnowball"));
            if (poro != null)
            {
                PoroThrower = new Spell.Skillshot(poro.Slot, 000, SkillShotType.Linear, 250,
                    (int) poro.SData.MissileSpeed, (int) poro.SData.LineWidth);
                PlayerHasPoroThrower = true;
                Chat.Print("Player has Poro thrower");
            }
        }

        #region Mark 

        public static Spell.Skillshot PoroThrower;
        public static bool PlayerHasPoroThrower;

        #endregion Mark

        #region Smite

        public static Spell.Targeted Smite;
        public static bool PlayerHasSmite;

        public static string[] MonsterSmiteables =
        {
            "SRU_Blue", "SRU_Gromp", "SRU_Murkwolf", "SRU_Razorbeak",
            "SRU_Red", "SRU_Krug", "SRU_Dragon", "Sru_Crab", "SRU_Baron"
        };

        public static void SmiteCast(bool useOnChampions, int keepSmite = 1)
        {
            if (!PlayerHasSmite || !Smite.IsReady() || Smite == null ||
                MyMenu.SummonerMenu.GetKeybindValue("smiteKeybind")) return;
            var GetJungleMinion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .FirstOrDefault(
                        m =>
                            MonsterSmiteables.Contains(m.BaseSkinName) && m.IsValidTarget(Smite.Range) &&
                            Prediction.Health.GetPrediction(m, Game.Ping + 50) <= SmiteDamage() &&
                            MyMenu.SummonerMenu.GetCheckBoxValue("monster" + m.BaseSkinName));

            if (GetJungleMinion != null)
            {
                Smite.Cast(GetJungleMinion);
            }
            var smiteGanker = Player.Spells.FirstOrDefault(s => s.Name.ToLower() == "s5_summonersmiteplayerganker");

            if (smiteGanker != null && useOnChampions && Smite.Handle.Ammo > keepSmite)
            {
                var target =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        e =>
                            Prediction.Health.GetPrediction(e, Game.Ping + 50) <= SmiteKSDamage() &&
                            e.IsValidTarget(Smite.Range));

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
            return
                new float[] {390, 410, 430, 450, 480, 510, 540, 570, 600, 640, 680, 720, 760, 800, 850, 900, 950, 1000}[
                    Player.Instance.Level];
        }

        private static float SmiteKSDamage()
        {
            return 20 + 8*Player.Instance.Level;
        }

        #endregion Smite
    }
}
