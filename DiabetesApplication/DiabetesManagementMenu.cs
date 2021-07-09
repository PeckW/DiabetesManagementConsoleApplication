using System;
using System.Collections.Generic;
using System.IO;

namespace DiabetesApplication
{
    public class DiabetesManagementMenu
    {
        static int index = 0;
        

        public static void DiabetesManagementMenuItems()
        {
            LogIn.StreamReaderOpenAndCloseAccountDataFile();

            List<string> menuOptions = new List<string>()
            {
                "Blood Glucose Entry",
                "Blood Glucose Graph",
                "Blood Glucose Converter",
                "Insulin Requirements Calculator",
                "Log Out",
                "Exit Application"
            };

            while (true)
            {
                string selectedMenuItem = drawMenu(menuOptions);

                if (selectedMenuItem == "Blood Glucose Entry")
                {
                    Console.Clear();
                    xDaBloodGlucoseEntry.BloodGlucoseEntry();
                }
                else if (selectedMenuItem == "Blood Glucose Graph")
                {
                    Console.Clear();
                    xDaBloodGlucoseGraph.BloodGlucoseGraph();
                }
                else if (selectedMenuItem == "Blood Glucose Converter")
                {
                    Console.Clear();
                    xDaBloodGlucoseConverter.BloodGlucoseConverter();
                }
                else if (selectedMenuItem == "Insulin Requirements Calculator")
                {
                    Console.Clear();
                    xDaInsulinRequirementCalculator.InsulinRequirementsCalculator();
                }
                else if (selectedMenuItem == "Log Out")
                {
                    Console.Clear();
                    LogIn.LogOut();
                }
                else if (selectedMenuItem == "Exit Application")
                {
                    ExitApplication();
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        private static string drawMenu(List<string> menuListItems)
        {
            Console.WriteLine("  -- Diabetes Information Application --\nFor information on navigation press I\n");

            for (int i = 0; i < menuListItems.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(menuListItems[i]);
                }
                else
                {
                    Console.WriteLine(menuListItems[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo kKey = Console.ReadKey();

            if (kKey.Key == ConsoleKey.DownArrow)
            {
                if (index == menuListItems.Count - 1)
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
                }
                else
                {
                    index--;
                }
            }
            else if (kKey.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
                return menuListItems[index];
            }
            else if (kKey.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                DiabetesManagementMenu.DiabetesManagementMenuItems();
            }
            else if (kKey.Key == ConsoleKey.I)
            {
                Navigation.I_KeyPressed();
            }
            else
            {
                return "";
            }

            Console.Clear();
            
            return "";
        }

        public static void ClearAndDisplayDiabetesMagementMenu()
        {
            Console.Clear();

            Console.WriteLine("  -- Diabetes Information Application --\nFor information on navigation press I\n");
        }

        public static void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
    
}
