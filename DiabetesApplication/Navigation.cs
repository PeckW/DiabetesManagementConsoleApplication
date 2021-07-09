using System;
using System.Collections.Generic;

namespace DiabetesApplication
{
    public class Navigation
    {
        public static void I_KeyPressed()
        {
            Console.Clear();
            Console.WriteLine("  -- Navigation Help Information --");
            Console.WriteLine("  Cycle through menu options by pressing the UP and DOWN arrow keys.");
            Console.WriteLine("  Select a menu option with the RIGHT arrow key.");
            Console.WriteLine("  Return to a previous menu with the LEFT arrow key\n  (Only usable in certain features)\n\n\n");
            Console.WriteLine("  Press 'enter' to return to menu");
            Console.ReadLine();
        }
    }
}
