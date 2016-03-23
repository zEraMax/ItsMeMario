using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Mario_s_Activator.Spells
{
    public static class SummonerSpells
    {
        public static Spell.Active Barrier;
        public static bool PlayerHasBarrier;
        public static Spell.Active Cleanse;
        public static bool PlayerHasCleanse;
        public static Spell.Targeted Exhaust;
        public static bool PlayerHasExhaust;
        public static Spell.Skillshot Flash;
        public static bool PlayerHasFlash;
        public static Spell.Active Ghost;
        public static bool PlayerHasGhost;
        public static Spell.Targeted Ignite;
        public static bool PlayerHasIgnite;
        public static Spell.Skillshot PoroThrower;
        public static bool PlayerHasPoroThrower;
        public static Spell.Targeted Smite;
        public static bool PlayerHasSmite;
        public static Spell.Active Heal;
        public static bool PlayerHasHeal;

        public static void InitSummoner()
        {
            //Barrier
            var barrier = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonerbarrier"));
            if (barrier != null)
            {
                Barrier = new Spell.Active(barrier.Slot);
                PlayerHasBarrier = true;
                Chat.Print("Player has barrier");
            }

            //Cleanase
            var cleanse = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonercleanse"));
            if (cleanse != null)
            {
                Cleanse = new Spell.Active(cleanse.Slot);
                PlayerHasCleanse = true;
                Chat.Print("Player has cleanse");
            }

            //Exhaust
            var exhaust = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonerexhaust"));
            if (exhaust != null)
            {
                Exhaust = new Spell.Targeted(exhaust.Slot, 650);
                PlayerHasExhaust = true;
                Chat.Print("Player Has Exhaust");
            }

            //Flash
            var flash = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonerflash"));
            if (flash != null)
            {
                Flash = new Spell.Skillshot(flash.Slot, 425, SkillShotType.Circular);
                PlayerHasFlash = true;
                Chat.Print("Player has flash");
            }

            //Ghost
            var ghost = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonerghost"));
            if (ghost != null)
            {
                Ghost = new Spell.Active(ghost.Slot);
                PlayerHasGhost = true;
                Chat.Print("Player has ghost");
            }

            //Ignite
            var ignite = Player.Spells.FirstOrDefault(s => s.Name.ToLower().Contains("summonerdot"));
            if (ignite != null)
            {
                Ignite = new Spell.Targeted(ignite.Slot, 000);
                PlayerHasIgnite = true;
                Chat.Print("Player has ignite");
            }

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

        public static float IgniteDamage()
        {
            return 50 + 20 * Player.Instance.Level;
        }

        public static float SmiteDamage()
        {
            return
                new float[] { 390, 410, 430, 450, 480, 510, 540, 570, 600, 640, 680, 720, 760, 800, 850, 900, 950, 1000 }[Player.Instance.Level];
        }

        public static float SmiteKSDamage()
        {
            return 20 + 8 * Player.Instance.Level;
        }

        public static string[] SmiteablesMonster =
        {
            "SRU_Blue", "SRU_Gromp", "SRU_Murkwolf", "SRU_Razorbeak",
            "SRU_Red", "SRU_Krug", "SRU_Dragon", "Sru_Crab", "SRU_Baron"
        };
    }
}
