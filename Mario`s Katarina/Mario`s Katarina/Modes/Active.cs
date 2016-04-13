using System.Collections.Generic;
using EloBuddy.SDK;
using static Mario_s_Katarina.SpellsManager;
using static Mario_s_Katarina.Menus;

namespace Mario_s_Katarina.Modes

{
    /// <summary>
    ///     This mode will always run
    /// </summary>
    internal class Active
    {
        /// <summary>
        ///     Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var spellsToKS = new List<Spell.SpellBase> {Q,E,W};
            DoDynamicKillSteal(spellsToKS);
        }
    }
}