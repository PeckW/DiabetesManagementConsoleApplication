using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesApplication
{
    class xDaBloodGlucoseEntry
    {
        public static string userEnteredBloodGlucoseAsString;
        public static double userEnteredBloodGlucoseAsDouble;
        public static string YesOrNo;
        public static string EnterAnotherValueQuestion = "\nDo you want to input a value? type yes or no\n";
        public static string FilePathForStreamWriter = AppDomain.CurrentDomain.BaseDirectory + LogIn.UserName + ".txt";


        public static string UserInputValue0 = "N/A ";
        public static DateTime DateTime0;
        public static string UserInputValue1 = "N/A ";
        public static DateTime DateTime1;
        public static string UserInputValue2 = "N/A ";
        public static DateTime DateTime2;
        public static string UserInputValue3 = "N/A ";
        public static DateTime DateTime3;
        public static string UserInputValue4 = "N/A ";
        public static DateTime DateTime4;
        public static string UserInputValue5 = "N/A ";
        public static DateTime DateTime5;
        public static string UserInputValue6 = "N/A ";
        public static DateTime DateTime6;
        public static string UserInputValue7 = "N/A ";
        public static DateTime DateTime7;
        public static string UserInputValue8 = "N/A ";
        public static DateTime DateTime8;
        public static string UserInputValue9 = "N/A ";
        public static DateTime DateTime9;

        public static void BloodGlucoseEntry()
        {
            Program.ClearAndDisplayTitleOfApplication();

            ClearAndDisplayBloodGlucoseEntry();

            UserInput();

            //HERE DISPLAY THE USER INPUT
            CreationAndDisplayOfListAndArrays();

            Console.Write("\n\nPress a key to return to menu.");
            Console.ReadLine();

            Console.Clear();

            //save value
            //delete value
        }

        public static void CheckForValidUserInput()
        {
            Console.Write("Enter your blood glucose level in mmol/L: ");

            userEnteredBloodGlucoseAsString = string.Empty;
            userEnteredBloodGlucoseAsString = Console.ReadLine();

            while (true)
            {
                if (!double.TryParse(userEnteredBloodGlucoseAsString, out userEnteredBloodGlucoseAsDouble))
                {
                    Console.Write("This is an invalid value. Please press enter to try again: ");
                    Console.ReadLine();

                    CheckForValidUserInput();
                 }
                else
                {
                    break;
                }
            }

            if (userEnteredBloodGlucoseAsDouble < 1 || userEnteredBloodGlucoseAsDouble > 30)
            {
                Console.WriteLine("Inputted value for 'Blood Glucose Level' is invalid.\nPlease press enter to try again.");
                Console.ReadLine();

                ClearAndDisplayBloodGlucoseEntry();

                BloodGlucoseEntry();
            }
            else 
            {
                
            }
        }

        public static void CreationAndDisplayOfListAndArrays()
        {
            string[] ArrayZero, ArrayOne, ArrayTwo, ArrayThree, ArrayFour, ArrayFive, ArraySix, ArraySeven, ArrayEight, ArrayNine;

            CreationOfArraysInList(out ArrayZero, out ArrayOne, out ArrayTwo, out ArrayThree, out ArrayFour, out ArrayFive, out ArraySix, out ArraySeven, out ArrayEight, out ArrayNine);

            CreationOfListOfArrays(ArrayZero, ArrayOne, ArrayTwo, ArrayThree, ArrayFour, ArrayFive, ArraySix, ArraySeven, ArrayEight, ArrayNine);
        }

        public static void CreationOfListOfArrays(string[] ArrayZero, string[] ArrayOne, string[] ArrayTwo, string[] ArrayThree, string[] ArrayFour, string[] ArrayFive, string[] ArraySix, string[] ArraySeven, string[] ArrayEight, string[] ArrayNine)
        {
            List<Array> ListOfArray = new List<Array>();
            ListOfArray.Add(ArrayZero );
            ListOfArray.Add(ArrayOne  );
            ListOfArray.Add(ArrayTwo  );
            ListOfArray.Add(ArrayThree);
            ListOfArray.Add(ArrayFour );
            ListOfArray.Add(ArrayFive );
            ListOfArray.Add(ArraySix  );
            ListOfArray.Add(ArraySeven);
            ListOfArray.Add(ArrayEight);
            ListOfArray.Add(ArrayNine );

            DisplayListOfArray(ArrayZero, ArrayOne, ArrayTwo, ArrayThree, ArrayFour, ArrayFive, ArraySix, ArraySeven, ArrayEight, ArrayNine, ListOfArray);
        }

        public static void DisplayListOfArray(string[] ArrayZero, string[] ArrayOne, string[] ArrayTwo, string[] ArrayThree, string[] ArrayFour, string[] ArrayFive, string[] ArraySix, string[] ArraySeven, string[] ArrayEight, string[] ArrayNine, List<Array> ListOfArray)
        {
            foreach (Array ArrayOfString in ListOfArray)
            {
                for (int x = 0; x < ListOfArray.Count; x++)
                {
                    if (UserInputValue0 != "N/A ")
                    {
                        Console.Write                              ($"\nEntered BG level: { ArrayZero[0]} mmol/L" + $" Date/Time: {ArrayZero[1]}   \n");
                        File.AppendAllText(FilePathForStreamWriter, $"\nEntered BG level: { ArrayZero[0]} mmol/L" + $" Date / Time: { ArrayZero[1]}\n");
                    }
                    if (UserInputValue1 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArrayOne[0]} mmol/L" + $" Date/Time: {ArrayOne[1]}   \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArrayOne[0]} mmol/L" + $" Date / Time: { ArrayOne[1]}\n");
                    }
                    if (UserInputValue2 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArrayTwo[0]} mmol/L" + $" Date/Time: {ArrayTwo[1]}   \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArrayTwo[0]} mmol/L" + $" Date / Time: { ArrayTwo[1]}\n");
                    }
                    if (UserInputValue3 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArrayThree[0]} mmol/L"  + $" Date/Time: {ArrayThree[1]}  \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArrayThree[0]} mmol/L" + $" Date / Time: { ArrayThree[1]}\n");
                    }
                    if (UserInputValue4 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArrayFour[0]} mmol/L"  + $" Date/Time: {ArrayFour[1]}  \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArrayFour[0]} mmol/L" + $" Date / Time: { ArrayFour[1]}\n");
                    }
                    if (UserInputValue5 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArrayFive[0]} mmol/L"  + $" Date/Time: {ArrayFive[1]}  \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArrayFive[0]} mmol/L" + $" Date / Time: { ArrayFive[1]}\n");
                    }
                    if (UserInputValue6 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArraySix[0]} mmol/L"  + $" Date/Time: {ArraySix[1]}  \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArraySix[0]} mmol/L" + $" Date / Time: { ArraySix[1]}\n");
                    }
                    if (UserInputValue7 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArraySeven[0]} mmol/L"  + $" Date/Time: {ArraySeven[1]}  \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArraySeven[0]} mmol/L" + $" Date / Time: { ArraySeven[1]}\n");
                    }
                    if (UserInputValue8 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArrayEight[0]} mmol/L"  + $" Date/Time: {ArrayEight[1]}  \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArrayEight[0]} mmol/L" + $" Date / Time: { ArrayEight[1]}\n");
                    }
                    if (UserInputValue9 != "N/A ")
                    {
                        Console.Write                              ($"Entered BG level: { ArrayNine[0]} mmol/L"  + $" Date/Time: {ArrayNine[1]}  \n");
                        File.AppendAllText(FilePathForStreamWriter, $"Entered BG level: { ArrayNine[0]} mmol/L" + $" Date / Time: { ArrayNine[1]}\n");
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            }
        }

        public static void CreationOfArraysInList(out string[] ArrayZero, out string[] ArrayOne, out string[] ArrayTwo, out string[] ArrayThree, out string[] ArrayFour, out string[] ArrayFive, out string[] ArraySix, out string[] ArraySeven, out string[] ArrayEight, out string[] ArrayNine)
        {
            ArrayZero  = new string[] { UserInputValue0, DateTime0.ToString() };
            ArrayOne   = new string[] { UserInputValue1, DateTime1.ToString() };
            ArrayTwo   = new string[] { UserInputValue2, DateTime2.ToString() };
            ArrayThree = new string[] { UserInputValue3, DateTime3.ToString() };
            ArrayFour  = new string[] { UserInputValue4, DateTime4.ToString() };
            ArrayFive  = new string[] { UserInputValue5, DateTime5.ToString() };
            ArraySix   = new string[] { UserInputValue6, DateTime6.ToString() };
            ArraySeven = new string[] { UserInputValue7, DateTime7.ToString() };
            ArrayEight = new string[] { UserInputValue8, DateTime8.ToString() };
            ArrayNine  = new string[] { UserInputValue9, DateTime9.ToString() };
        }

        public static void UserInput()
        {
            bool InputAnotherValue = false;

            while (!InputAnotherValue)
            {
                Console.Write("Do you want to input a value? type yes or no\n");
                YesOrNo = Console.ReadLine();

                if (YesOrNo == "yes")
                {
                    InputAnotherValue = true;

                    AddToListArrayZero();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArrayOne();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArrayTwo();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArrayThree();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArrayFour();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArrayFive();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArraySix();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArraySeven();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArrayEight();

                    Console.Write(EnterAnotherValueQuestion);
                    YesOrNo = Console.ReadLine(); if (YesOrNo == "no") { break; } else { }

                    AddToListArrayNine();

                    break;
                }
                else if (YesOrNo == "no")
                {
                    break;
                }
            }
        }

        public static void AddToListArrayZero()
        {
            CheckForValidUserInput();

            UserInputValue0 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime0 = DateTime.Now;
        }

        public static void AddToListArrayOne()
        {
            CheckForValidUserInput();

            UserInputValue1 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime1 = DateTime.Now;
        }

        public static void AddToListArrayTwo()
        {
            CheckForValidUserInput();

            UserInputValue2 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime2 = DateTime.Now;
        }

        public static void AddToListArrayThree()
        {
            CheckForValidUserInput();

            UserInputValue3 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime3 = DateTime.Now;
        }

        public static void AddToListArrayFour()
        {
            CheckForValidUserInput();

            UserInputValue4 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime4 = DateTime.Now;
        }

        public static void AddToListArrayFive()
        {
            CheckForValidUserInput();

            UserInputValue5 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime5 = DateTime.Now;
        }

        public static void AddToListArraySix()
        {
            CheckForValidUserInput();

            UserInputValue6 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime6 = DateTime.Now;
        }

        public static void AddToListArraySeven()
        {
            CheckForValidUserInput();

            UserInputValue7 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime7 = DateTime.Now;
        }

        public static void AddToListArrayEight()
        {
            CheckForValidUserInput();

            UserInputValue8 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime8 = DateTime.Now;
        }

        public static void AddToListArrayNine()
        {
            CheckForValidUserInput();

            UserInputValue9 = userEnteredBloodGlucoseAsDouble.ToString();

            DateTime9 = DateTime.Now;
        }

        public static void ClearAndDisplayBloodGlucoseEntry()
        {
            Console.Clear();

            Console.Write("-- Blood Glucose Entry -- \n\n");

            Console.WriteLine("-- Valid values range from 1 to 30 -- \n\n");
        }
    }
}
