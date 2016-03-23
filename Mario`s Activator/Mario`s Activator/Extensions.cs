using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Mario_s_Activator
{
    public static class Extensions
    {
        public static bool IsNotNull(this Obj_AI_Base target)
        {
            return target != null;
        }

        //Add
        //Checbkox
        public static CheckBox CreateCheckBox(this Menu m, string checkboxName, string uniqueId,
            bool defaultValuecheck = true)
        {
            return m.Add("idAct" + uniqueId, new CheckBox(checkboxName, defaultValuecheck));
        }

        //Slider
        public static Slider CreateSlider(this Menu m, string sliderName, string uniqueId, int defaulValueslider = 0,
            int minValue = 0, int maxValue = 100)
        {
            return m.Add("idAct" + uniqueId, new Slider(sliderName, defaulValueslider, minValue, maxValue));
        }

        //Keybind
        public static KeyBind CreateKeybind(this Menu m, string keyName, string uniqueId, uint valueKey = 32,
            bool defaultValue = false, KeyBind.BindTypes keyType = KeyBind.BindTypes.PressToggle)
        {
            return m.Add("idAct" + uniqueId, new KeyBind(keyName, defaultValue, keyType, valueKey));
        }

        //Getting Values with INT/Numbers
        public static bool GetCheckBoxValue(this Menu menu, string uniqueId)
        {
            try
            {
                return menu.Get<CheckBox>("idAct" + uniqueId).CurrentValue;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Error getting the checkbox value with the ID = ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(uniqueId);
                Console.ResetColor();
                Console.WriteLine(" ");
            }
            return false;
        }

        public static int GetSliderValue(this Menu menu, string uniqueId)
        {
            try
            {
                return menu.Get<Slider>("idAct" + uniqueId).CurrentValue;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Error getting the slider value with the ID = ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(uniqueId);
                Console.ResetColor();
                Console.WriteLine(" ");
            }
            return -1;
        }

        public static bool GetKeybindValue(this Menu menu, string uniqueId)
        {
            try
            {
                return menu.Get<KeyBind>("idAct" + uniqueId).CurrentValue;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Error getting the keybind value with the ID = ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(uniqueId);
                Console.ResetColor();
                Console.WriteLine(" ");
            }
            return false;
        }

        public static bool HasCC(this Obj_AI_Base target)
        {
            return (target.HasBuffOfType(BuffType.Stun) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Stun")) ||
                   (target.HasBuffOfType(BuffType.Blind) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Blind")) ||
                   (target.HasBuffOfType(BuffType.Slow) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Slow")) ||
                   (target.HasBuffOfType(BuffType.Snare) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Snare")) ||
                   (target.HasBuffOfType(BuffType.Suppression) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Supression")) ||
                   (target.HasBuffOfType(BuffType.Taunt) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Taunt")) ||
                   (target.HasBuffOfType(BuffType.Charm) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Charm")) ||
                   (target.HasBuffOfType(BuffType.Polymorph) && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "Polymorph")) ||
                   (target.HasBuff("zedulttargetmark") && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "ZedR")) ||
                   (target.HasBuff("vladimirhemoplague") && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "VladmirR")) ||
                   (target.HasBuff("mordekaiserchildrenofthegrave") && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "MordekaiserR")) ||
                   (target.HasBuff("zedulttargetmark") && MyMenu.CleansersMenu.GetCheckBoxValue("cc" + "ZedR"));
        }

        public static float GetTotalDamage(this Obj_AI_Base target)
        {
            var damage = Player.Spells.Where(s => (s.Slot == SpellSlot.Q || s.Slot == SpellSlot.W || s.Slot == SpellSlot.E || s.Slot == SpellSlot.R) && s.IsReady).Sum(s => Player.Instance.GetSpellDamage(target, s.Slot));
            return (damage + Player.Instance.GetAutoAttackDamage(target)) - 10;
        }
    }
}
