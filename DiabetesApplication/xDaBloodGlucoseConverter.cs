using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesApplication
{
    class xDaBloodGlucoseConverter
    {
        public static int index = 0;
        public static string YesOrNoOption;
        public static int MmolToMgConversionRatio = 18;

        public static void BloodGlucoseConverter()
        {
            ClearAndDisplayBloodGlucoseConverter();

            List<string> OptionSelectionList = new List<string>();
            OptionSelectionList.Add("mmol/L to mg/dL");
            OptionSelectionList.Add("mg/dL to mmol/L");
            OptionSelectionList.Add("Return to menu");

            foreach (string ObjectsInOptionSelectionList in OptionSelectionList)
            {
                Console.WriteLine(ObjectsInOptionSelectionList);
            }

            bool IsStillDisplay = true;

            while (IsStillDisplay)
            {
                string selectedMenuItem = drawMenu(OptionSelectionList);

                if (selectedMenuItem == "mmol/L to mg/dL")
                {
                    Console.Clear();
                    xDaMmolToMg.MmolToMg();                     
                }
                else if (selectedMenuItem == "mg/dL to mmol/L")
                {
                    Console.Clear();
                    xDaMgToMmol.MgToMmol();                     
                }
                else if (selectedMenuItem == "Return to menu")
                {
                    Console.Clear();
                    return;
                    // need a way to close this automatically. as currently you are going in one step deeper - can cause recursion problems
                }
            }
        }

        public static string drawMenu(List<string> OptionSelectionList)
        {
            ClearAndDisplayBloodGlucoseConverter();

            for (int i = 0; i < OptionSelectionList.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(OptionSelectionList[i]);
                }
                else
                {
                    Console.WriteLine(OptionSelectionList[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo kKey = Console.ReadKey();

            if (kKey.Key == ConsoleKey.DownArrow)
            {
                if (index == OptionSelectionList.Count - 1)
                {
                    //index = 0;
                }
                else
                {
                    index++;
                }
            }
            else if (kKey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    //index = menuListItems.Count - 1;
                    // Having these removed will stop the menu from going to the last index and returning to the first
                }
                else
                {
                    index--;
                }
            }
            else if (kKey.Key == ConsoleKey.RightArrow)
            {
                return OptionSelectionList[index];
            }
            else if (kKey.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                return "";
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }

        public static void ClearAndDisplayBloodGlucoseConverter()
        {
            Console.Clear();

            Console.Write("-- Blood Glucose Converter -- \n\n");
        }
    }
}
