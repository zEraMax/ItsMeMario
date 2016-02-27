using System;
using EloBuddy;
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

        //Remove
        public static void DelItem(this Menu m, string uniqueId)
        {
            m.Remove("idAct" + uniqueId);
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
            return 999;
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
    }
}
