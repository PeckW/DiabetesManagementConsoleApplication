using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//VALUES FOR INSULIN CONVERSION ARE INTS NOT DOUBLES BECAUSE THE ISULIN INJECTION PEN WHICH ARE USED TO INJECT ONLY USE WHOLE NUMBERS.

namespace DiabetesApplication
{
    [Serializable]
    public struct CalculationRequirements
    {
        public int InsulinQuantityValue;
        public int CarbohydrateQuantityValue;

        public CalculationRequirements(int insulinQuantityValue, int carbohydrateQuantityValue)
        {
            this.InsulinQuantityValue      = insulinQuantityValue;
            this.CarbohydrateQuantityValue = carbohydrateQuantityValue;
        }
    }

    class xDaInsulinRequirementCalculator 
    {
        public static string TotalCarbohydrateValueForConversion;
        public static int InsulinValueForCalculation;
        public static int CarbValueForCalculation;
        public static int DefaultInsulinRatioValue = 1;
        public static int DefaultCarbRatioValue = 10;

        public static void InsulinRequirementsCalculator()
        {
            int StorageForInsulinInt;
            int StorageForCarbInt;
            int FinalInsulinRequirementValue;

            Program.ClearAndDisplayTitleOfApplication();

            ClearAndDisplayInsulinRequirementCalculator();

            Console.Write("Type 'New' for a new entry value. Type 'Load' to use exisiting values. ");
            string choice = Console.ReadLine();

            Console.Write("\n");

            if (choice == "New" || choice == "new")
            {
                Console.Write("\nThis ratio calculation works off two values:\n1. Insulin quantity(Units)\n2. Carbohydrate quantity(grams of carbohydrate).\nAn example would be --> 1:10\n" +
                              "Meaning you take 1 unit of insulin per 10grams of carbohydrate.\n\n");

                StorageForInsulinInt = InputOfInsulinRatioValue();

                StorageForCarbInt = InputOfCarbohydrateRatioValue();

                CalculationRequirements[] CalculationVariables =
                {
                    new CalculationRequirements(StorageForInsulinInt, StorageForCarbInt)
                };

                SaveToFile(CalculationVariables);

                Console.WriteLine(StorageForInsulinInt + "units per " + StorageForCarbInt + "grams.");

                InsulinValueForCalculation = StorageForInsulinInt;
                CarbValueForCalculation    = StorageForCarbInt;
            }
            else if (choice == "Load" || choice == "load")
            {
                CalculationRequirements[] CalculationVariables = LoadFromFile();

                if (InsulinValueForCalculation == 0)
                {
                    Console.Write("\nInsulin ratio value cannot be 0. 1 Unit has been set by default.\n");
                    InsulinValueForCalculation = DefaultInsulinRatioValue;
                }
                else
                {
                   
                }
                if (CarbValueForCalculation == 0)
                {
                    Console.Write("Carbohydrate ratio value cannot be 0. 10 grams has been set by default.\n\n");
                    CarbValueForCalculation = DefaultCarbRatioValue;
                }
                else
                {
                    
                }
                for(int i = 0; i < CalculationVariables.Length; ++i)
                {
                    Console.Write(CalculationVariables[i].InsulinQuantityValue + "unit/s per ");
                    Console.Write(CalculationVariables[i].CarbohydrateQuantityValue + "grams\n");
                }
            }
            else
            {
                Console.Write("Invalid Option, press 'Enter' to return.");
                Console.ReadLine();

                Console.Clear();

                return;
            }

            FinalInsulinRequirementValue = (InputOfTotalCarb() / CarbValueForCalculation) * InsulinValueForCalculation;

            Console.Write(FinalInsulinRequirementValue + " units of Insulin required.");
            Console.Write("\nPress 'Enter' key to return to menu.");
            Console.ReadLine();

            Console.Clear();
        }

        public static int InputOfInsulinRatioValue()
        {
            string InsulinQuantityValueAsString;

            Console.Write("Input an insluin ratio value (units): ");
            InsulinQuantityValueAsString = Console.ReadLine();
 
            if (Int32.TryParse(InsulinQuantityValueAsString, out int InsulinQuantityValueAsInt))
            {
                if(InsulinQuantityValueAsInt == 0)
                {
                    Console.WriteLine("\n0 is an invalid input. 1 unit has been set by default untill changed.\n");
                    return InsulinQuantityValueAsInt = 1;
                }
            }
            else
            {
                Console.Write("\nException: Could not parse InsulinQuantityValue\n");
            }
            return InsulinQuantityValueAsInt;
        }

        public static int InputOfCarbohydrateRatioValue()
        {
            string CarbohydrateQuantityValueAsString;

            Console.Write("Input an carbohydrate ratio value (grams): ");
            CarbohydrateQuantityValueAsString = Console.ReadLine();

            if (Int32.TryParse(CarbohydrateQuantityValueAsString, out int CarbohydrateQuantityValueAsInt))
            {
                if (CarbohydrateQuantityValueAsInt == 0)
                {
                    Console.WriteLine("\n0 is an invalid input. 10grams has been set by default untill changed.\n");
                    return CarbohydrateQuantityValueAsInt = 10;
                }
            }
            else
            {
                Console.Write("\nException: Could not parse CarbohydrateQuantityValue\n");
            }
            return CarbohydrateQuantityValueAsInt;
        }

        public static void SaveToFile(CalculationRequirements[] StoreVariables)
        {
            BinaryFormatter InsulinRequirementBinaryFormatter = new BinaryFormatter(); //to convert data to binary

            FileStream UserDataFileStream = File.Create(LogIn.UserName + ".bin"); //create and open binary file 

            InsulinRequirementBinaryFormatter.Serialize(UserDataFileStream, StoreVariables); // write data to file

            UserDataFileStream.Close(); //close file
        }

        public static CalculationRequirements[] LoadFromFile()
        {
            BinaryFormatter InsulinRequirementBinaryFormatter = new BinaryFormatter(); // create to convert from binary

            FileStream UserDataFileStream = File.OpenRead(LogIn.UserName + ".bin"); //open file containing data

            CalculationRequirements[] StoreVariables = (CalculationRequirements[])InsulinRequirementBinaryFormatter.Deserialize(UserDataFileStream); //read and convert data

            UserDataFileStream.Close(); // close file

            return StoreVariables;
        }

        public static int InputOfTotalCarb()
        {
            Console.Write("\nInput total carbohydrate value for conversion (grams): ");
            TotalCarbohydrateValueForConversion = Console.ReadLine();

            if (Int32.TryParse(TotalCarbohydrateValueForConversion, out int TotalCarbohydrateValueForConversionAsInt))
            {
                if (TotalCarbohydrateValueForConversionAsInt == 0)
                {
                    Console.WriteLine("\n0 is an invalid input. 50grams has been set by default untill changed.\n");
                    return TotalCarbohydrateValueForConversionAsInt = 50;
                }
            }
            else
            {
                Console.Write("\nException: Could not parse TotalCarbohydrateValueForConversion\n");
            }
            return TotalCarbohydrateValueForConversionAsInt;
        }

        public static void ClearAndDisplayInsulinRequirementCalculator()
        {
            Console.Clear();

            Console.Write("-- Insulin Requirement Calculator -- \n\n");
        }

    }
}

