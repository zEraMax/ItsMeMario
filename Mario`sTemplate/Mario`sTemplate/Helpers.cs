using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Mario_sTemplate.Spells;
// ReSharper disable SwitchStatementMissingSomeCases

namespace Mario_sTemplate
{
    internal class Helpers
    {

        #region GettingEnemies
        public static Obj_AI_Base GetLaneMinion(int range, float spellDMG, int spellDelay)
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderBy(m => m.Health)
                    .FirstOrDefault(mi => mi.IsValidTarget(range) && Prediction.Health.GetPrediction(mi, spellDelay) <= spellDMG &&
                    Prediction.Health.GetPrediction(mi, spellDelay) > 20);

            return minion;
        }

        public static Obj_AI_Base GetJungleMinion(int range)
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderBy(m => m.Health)
                    .FirstOrDefault(mi => mi.IsValidTarget(range));

            return minion;
        }

        public static Obj_AI_Base GetJungleMinionToKS(int range, float spellDMG, int spellDelay)
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderBy(m => m.Health)
                    .FirstOrDefault(mi => mi.IsValidTarget(range) && Prediction.Health.GetPrediction(mi, spellDelay) <= spellDMG &&
                    Prediction.Health.GetPrediction(mi, spellDelay) > 20);

            return minion;
        }
        #endregion GettingEnemies

        #region KS
        public static AIHeroClient GetBestKSHero(int range, float spellDMG, int spellDelay)
        {
            var hero =
                EntityManager.Heroes.Enemies.OrderBy(x => x.Health)
                    .FirstOrDefault(
                        e => e.IsValidTarget(range) && Prediction.Health.GetPrediction(e, spellDelay) <= spellDMG &&
                             Prediction.Health.GetPrediction(e, spellDelay) > 20);

            return hero;
        }

        //TODO FIX THIS SHIT LATER
        public static List<SpellSlot> GetBestSpellsToKS(int range, Obj_AI_Base target)
        {
            var dmg = 0f;
            var spells = new List<SpellSlot>();

            if (Q.IsReady())
            {
                dmg += GetDamage(SpellSlot.Q, target);
                spells.Add(SpellSlot.Q);
            }

            if (W.IsReady())
            {
                dmg += GetDamage(SpellSlot.W, target);
                spells.Add(SpellSlot.W);
            }

            if (E.IsReady())
            {
                dmg += GetDamage(SpellSlot.E, target);
                spells.Add(SpellSlot.E);
            }

            if (R.IsReady())
            {
                dmg += GetDamage(SpellSlot.R, target);
                spells.Add(SpellSlot.R);
            }

            return spells;
        }
        #endregion KS

        #region GettingMenuValues

        public enum MenuTypes
        {
            Combo,Harass,LaneClear,JungleClear,LastHit, Settings, Drawings
        }

        public static bool GetCheckBoxValue(MenuTypes type, string checkName)
        {
            var value = false;
            try
            {
                switch (type)
                {
                    case MenuTypes.Combo:
                        value = MenuSettings.ComboMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.Harass:
                        value = MenuSettings.HarassMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.LaneClear:
                        value = MenuSettings.LaneClearMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.JungleClear:
                        value = MenuSettings.JungleClearMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.LastHit:
                        value = MenuSettings.LastHitMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.Settings:
                        value = MenuSettings.SettingsMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                    case MenuTypes.Drawings:
                        value = MenuSettings.DrawingsMenu.Get<CheckBox>(checkName).CurrentValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Menu name is wrong please fix it");
            }

            return value;
        }

        public static int GetSliderValue(MenuTypes type, string sliderName)
        {
            var value = 0;
            try
            {
                switch (type)
                {
                    case MenuTypes.Combo:
                        value = MenuSettings.ComboMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.Harass:
                        value = MenuSettings.HarassMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.LaneClear:
                        value = MenuSettings.LaneClearMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.JungleClear:
                        value = MenuSettings.JungleClearMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.LastHit:
                        value = MenuSettings.LastHitMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.Settings:
                        value = MenuSettings.SettingsMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                    case MenuTypes.Drawings:
                        value = MenuSettings.DrawingsMenu.Get<Slider>(sliderName).CurrentValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Menu name is wrong please fix it");
            }


            return value;
        }

        public static bool GetKeyBindValue(MenuTypes type, string keyName)
        {
            var value = false;
            try
            {
                switch (type)
                {
                    case MenuTypes.Combo:
                        value = MenuSettings.ComboMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.Harass:
                        value = MenuSettings.HarassMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.LaneClear:
                        value = MenuSettings.LaneClearMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.JungleClear:
                        value = MenuSettings.JungleClearMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.LastHit:
                        value = MenuSettings.LastHitMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.Settings:
                        value = MenuSettings.SettingsMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                    case MenuTypes.Drawings:
                        value = MenuSettings.DrawingsMenu.Get<KeyBind>(keyName).CurrentValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Menu name is wrong please fix it");
            }

            return value;
        }

        public static int GetComboBoxValue(MenuTypes type, string comboBoxName)
        {
            var value = 0;
            try
            {
                switch (type)
                {
                    case MenuTypes.Combo:
                        value = MenuSettings.ComboMenu.Get<ComboBox>(comboBoxName).SelectedIndex;
                        break;
                    case MenuTypes.Harass:
                        value = MenuSettings.HarassMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.LaneClear:
                        value = MenuSettings.LaneClearMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.JungleClear:
                        value = MenuSettings.JungleClearMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.LastHit:
                        value = MenuSettings.LastHitMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.Settings:
                        value = MenuSettings.SettingsMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                    case MenuTypes.Drawings:
                        value = MenuSettings.DrawingsMenu.Get<ComboBox>(comboBoxName).CurrentValue;
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Menu name is wrong please fix it");
            }

            return value;
        }

        #endregion GettingMenuValues
    }
}
