using System.Collections.Generic;
using EloBuddy;

namespace Mario_s_Activator
{
    public class DangerousSpell
    {
        public DangerousSpell(Champion _hero, SpellSlot slot, bool defaultvalue, int delay)
        {
            Slot = slot;
            Hero = _hero;
            DefaultValue = defaultvalue;
            Delay = delay;
        }

        public SpellSlot Slot;
        public Champion Hero;
        public bool DefaultValue;
        public int Delay;
    }

    public class DangerousSpells
    {
        public static List<DangerousSpell> Spells = new List<DangerousSpell>
        {
            new DangerousSpell(Champion.Aatrox, SpellSlot.Q, false, 250),
            new DangerousSpell(Champion.Ahri, SpellSlot.E, false, 250),
            new DangerousSpell(Champion.Amumu, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Annie, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Ashe, SpellSlot.R, true, 250),
            new DangerousSpell(Champion.Azir, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Bard, SpellSlot.Q, false, 350),
            new DangerousSpell(Champion.Blitzcrank, SpellSlot.Q, true, 350),
            new DangerousSpell(Champion.Brand, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Braum, SpellSlot.R, true, 50),
            new DangerousSpell(Champion.Caitlyn, SpellSlot.R, true, 800),
            new DangerousSpell(Champion.Cassiopeia, SpellSlot.R, true, 50),
            new DangerousSpell(Champion.Chogath, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Darius, SpellSlot.R, true, 250),
            new DangerousSpell(Champion.Draven, SpellSlot.R, true, 400),
            new DangerousSpell(Champion.Ekko, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Elise, SpellSlot.E, false, 150),
            new DangerousSpell(Champion.Evelynn, SpellSlot.R, false, 0),
            new DangerousSpell(Champion.Ezreal, SpellSlot.R, true, 800),
            new DangerousSpell(Champion.FiddleSticks, SpellSlot.R, true, 1000),
            new DangerousSpell(Champion.Fiora, SpellSlot.R, true, 300),
            new DangerousSpell(Champion.Fizz, SpellSlot.R, true, 150),
            new DangerousSpell(Champion.Galio, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Garen, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Gnar, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Gragas, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Graves, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Hecarim, SpellSlot.R, true, 150),
            new DangerousSpell(Champion.Illaoi, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.JarvanIV, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Jax, SpellSlot.E, false, 350),
            new DangerousSpell(Champion.Jinx, SpellSlot.R, true, 600),
            new DangerousSpell(Champion.Kalista, SpellSlot.E, false, 0),
            new DangerousSpell(Champion.Karthus, SpellSlot.R, true, 2800),
            new DangerousSpell(Champion.Kassadin, SpellSlot.R, false, 0),
            new DangerousSpell(Champion.Katarina, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Kennen, SpellSlot.R, true, 150),
            new DangerousSpell(Champion.Leblanc, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.LeeSin, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Leona, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Lissandra, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Lux, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Lux, SpellSlot.Q, false, 350),
            new DangerousSpell(Champion.Malphite, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Malzahar, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.MissFortune, SpellSlot.R, true, 150),
            new DangerousSpell(Champion.MonkeyKing, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Mordekaiser, SpellSlot.R, true, 650),
            new DangerousSpell(Champion.Morgana, SpellSlot.R, true, 2800),
            new DangerousSpell(Champion.Nami, SpellSlot.R, true, 700),
            new DangerousSpell(Champion.Nami, SpellSlot.Q, false, 250),
            new DangerousSpell(Champion.Nautilus, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Nocturne, SpellSlot.R, true, 650),
            new DangerousSpell(Champion.Nunu, SpellSlot.R, true, 2800),
            new DangerousSpell(Champion.Olaf, SpellSlot.E, false, 350),
            new DangerousSpell(Champion.Orianna, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Poppy, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Riven, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Rumble, SpellSlot.R, true, 150),
            new DangerousSpell(Champion.Sejuani, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Skarner, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Sona, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Syndra, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Talon, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Tristana, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Trundle, SpellSlot.R, false, 350),
            new DangerousSpell(Champion.Varus, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Veigar, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Velkoz, SpellSlot.R, true, 150),
            new DangerousSpell(Champion.Vi, SpellSlot.R, true, 150),
            new DangerousSpell(Champion.Viktor, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Vladimir, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Warwick, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Yasuo, SpellSlot.R, true, 0),
            new DangerousSpell(Champion.Zed, SpellSlot.R, true, 2800),
            new DangerousSpell(Champion.Zyra, SpellSlot.R, true, 250),
        };
    }
}