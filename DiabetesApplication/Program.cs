using System;
using System.Collections.Generic;

//Console.Clear(); to reset the console.
//Close console via Environment.Exit(0).
//used list over array due to the flexability to add more in the future. array is a set number of cells. lists can be added to.

namespace DiabetesApplication
{
    class Program
    {
        static int index = 0;

        public static void Main(string[] args)
        {
            DisplayStartUpMenu();

            Environment.Exit(0);
        }

        public static void DisplayStartUpMenu()
        {
            List<string> menuOptions = new List<string>()
            {
                "Log-In",
                "Create an account",
                "Exit application"
            };

            bool IsStillDisplay = true;

            while (IsStillDisplay)
            {
                string selectedMenuItem = drawMenu(menuOptions);

                if (selectedMenuItem == "Log-In")
                {
                    Console.Clear();
                    LogIn.ExistingAccountUserLogIn();
                }

                else if (selectedMenuItem == "Create an account")
                {
                    Console.Clear();
                    LogIn.UserCreateAccount();
                }

                else if (selectedMenuItem == "Exit application")
                {
                    IsStillDisplay = false;
                }
                else
                {
                    Console.Clear();
                }
            }

        }


        public static string drawMenu(List<string> OptionSelectionList)
        {
            Console.Clear();
            Console.WriteLine("  -- Diabetes Information Application --\nFor information on navigation press I\n\n\n");

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


        //Console Graphic related methods (create a new class with these when appropriate)

        public static void ConsoleGraphicalChanges()
        {
            Console.SetWindowPosition(0, 0);

            Console.SetWindowSize(84, 40);

        }

        public static void ClearAndDisplayTitleOfApplication()
        {
            Console.Clear();

            Console.Write("Diabetes Information Application\n\n");
        }

    }
}
