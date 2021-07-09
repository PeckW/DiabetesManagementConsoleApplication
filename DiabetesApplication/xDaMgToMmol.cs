using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesApplication
{
    class xDaMgToMmol
    {
        public static string MgValueAsString;
        public static int MgValueAsInt;
        public static int MgConvertedToMmolValue;

        public static void MgToMmol()
        {
            ClearAndDisplayMgToMmolConversion();

            Console.Write("Enter mg/dL value: ");

            MgValueAsString = string.Empty;
            MgValueAsString = Console.ReadLine();

            while (true)
            {
                if (!int.TryParse(MgValueAsString, out MgValueAsInt))
                {
                    Console.Write("This is an invalid value. Please press enter to try again.");
                    Console.ReadLine();

                    ClearAndDisplayMgToMmolConversion();

                    MgToMmol();
                }
                else
                {
                    break;
                }
            }

            MgConvertedToMmolValue = MgValueAsInt / xDaBloodGlucoseConverter.MmolToMgConversionRatio;

            Console.Write("Entered mg/dL = " + MgValueAsString + ". Converted to mmol/L value of " + MgConvertedToMmolValue + ".\n\n");

            Console.Write("\nWould you like to convert a different value?\nType: 'yes' or 'no'\n\n");
            xDaBloodGlucoseConverter.YesOrNoOption = Console.ReadLine();

            if (xDaBloodGlucoseConverter.YesOrNoOption == "yes" || xDaBloodGlucoseConverter.YesOrNoOption == "Yes")
            {
                ClearAndDisplayMgToMmolConversion();

                MgToMmol();
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

        public static void ClearAndDisplayMgToMmolConversion()
        {
            Console.Clear();

            Console.Write("-- mg/dL to mmol/L Conversion Calculator -- \n\n");
        }
    }
}
