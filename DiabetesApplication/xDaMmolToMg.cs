using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesApplication
{
    class xDaMmolToMg
    {
        public static string MmolValueAsString;
        public static int MmolValueAsInt;
        public static int MmolConvertedToMgValue;

        public static void MmolToMg()
        {
            ClearAndDisplayMmolToMgConversion();

            Console.Write("Enter mmol/L value: ");

            MmolValueAsString = string.Empty;
            MmolValueAsString = Console.ReadLine();

            while (true)
            {
                if (!int.TryParse(MmolValueAsString, out MmolValueAsInt))
                {
                    Console.Write("This is an invalid value. Please press enter to try again.");
                    Console.ReadLine();

                    ClearAndDisplayMmolToMgConversion();

                    MmolToMg();
                }
                else
                {
                    break;
                }
            }

            MmolConvertedToMgValue = xDaBloodGlucoseConverter.MmolToMgConversionRatio * MmolValueAsInt;

            Console.Write("Entered mmol/L = " + MmolValueAsString + ". Converted to mg/dL value of " + MmolConvertedToMgValue + ".\n\n");

            Console.Write("Would you like to convert a different value?\nType: 'yes' or 'no'\n\n");
            xDaBloodGlucoseConverter.YesOrNoOption = Console.ReadLine();

            if (xDaBloodGlucoseConverter.YesOrNoOption == "yes" || xDaBloodGlucoseConverter.YesOrNoOption == "Yes")
            {
                ClearAndDisplayMmolToMgConversion();

                MmolToMg();
            }
            else if (xDaBloodGlucoseConverter.YesOrNoOption == "no" || xDaBloodGlucoseConverter.YesOrNoOption == "No")
            {
                Console.Clear();

                return;
            }
            else
            {
                Console.Write("\nInvalid option. Please type 'yes' or 'no'.\n\n");
                xDaBloodGlucoseConverter.YesOrNoOption = Console.ReadLine();
            }
        }

        public static void ClearAndDisplayMmolToMgConversion()
        {
            Console.Clear();

            Console.Write("-- mmol/L to mg/dL Conversion Calculator -- \n\n");
        }
    }
}
