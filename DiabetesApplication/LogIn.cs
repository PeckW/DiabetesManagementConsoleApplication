using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesApplication
{
    public class LogIn
    {
        public static string       UserName;
        public static string       CreatedPassword;
        public static string       attemptedPassword;
        public static string       EnteredPassword;
        public static int          maximumPasswordAttempts = 4;
        public static bool         IsUserLoggedIn;
        public static string       AccountFileName = string.Empty;
        public static List<string> AccountDataList = new List<string>();
        public static string       FilePassword = string.Empty;

        public static void ExistingAccountUserLogIn()
        {
            Program.ClearAndDisplayTitleOfApplication();

            Console.Write("--Log-In--\n\n");

            Console.Write("Enter user name: ");
            UserName = Console.ReadLine();

            LogIn.AccountFileName = UserName + ".txt";

            if (File.Exists(AccountFileName))
            {
                if (StreamReaderOpenAndCloseAccountDataFile())
                {
                    string PasswordRead = LogIn.FilePassword;

                    bool IsPasswordCorrect = false;

                    for (int passwordAttempts = 0; passwordAttempts < maximumPasswordAttempts; passwordAttempts++)
                    {
                        Console.Write("Enter your password: ");
                        attemptedPassword = Console.ReadLine();

                        if (PasswordRead == attemptedPassword)
                        {
                            IsPasswordCorrect = true;
                            break;
                        }
                        else
                        {
                            Console.Write("Incorrect password, try again.\n ");
                        }
                    }

                    if (IsPasswordCorrect)
                    {
                        Console.Clear();
                        DiabetesManagementMenu.DiabetesManagementMenuItems();
                    }
                    else
                    {
                        Console.Write("Too many password attempts. Log-in failed. Press any key to continue.");
                        Console.WriteLine();

                        Console.Clear();
                    }
                }
                else
                {
                    //hitting this because it is passing the 'if' statement.
                    // tried stepping through the if statement on NewAccountUserLogIn with no problems in the if statement.
                    // it doesnt work when logging in from a new program run. So is streamreader closed?
                    // it does work when creating an account, then logging out, then logging in within the same session of program.
                    Console.Write("Exception hit within: if (File.Exists(AccountFileName)){if } statement.\nDid not step into StreamReaderOpenAndCloseAccountDataFile() method.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("This account does not exist");
                Console.ReadLine();
            }
        }

        public static void NewAccountUserLogIn()
        {
            Program.ClearAndDisplayTitleOfApplication();

            Console.Write("--Log-In--\n\n");

            if (StreamReaderOpenAndCloseAccountDataFile())
            {
                     Console.Clear();
                     DiabetesManagementMenu.DiabetesManagementMenuItems();
            }
            else
            {
                //EXECEPTION HANDLER GOES HERE
            }
        }

        public static void UserCreateAccount()
        {
            Program.ClearAndDisplayTitleOfApplication();

            Console.Write("--Create Account--\n\n");

            Console.Write("Enter a user name: ");
            UserName = Console.ReadLine();

            if(UserName == "")
            {
                Console.Write("User name is empty, press 'Enter' to return.");
                Console.ReadLine();
                return;
            }
            else
            {

            }

            Console.Write("Create a password: ");
            CreatedPassword = Console.ReadLine();

            if (CreatedPassword == "")
            {
                Console.Write("Password cannot be empty, press 'Enter' to return.");
                Console.ReadLine();
                return;
            }
            else
            {

            }

            Console.Write("Repeat your entered password: ");
            EnteredPassword = Console.ReadLine();

            bool IsSuccessfulLogIn = CreatedPassword == EnteredPassword;

            if (!IsSuccessfulLogIn)
            {
                Console.Write("Incorrect password, try again: ");
                CreatedPassword = Console.ReadLine();

                Console.Write("Repeat your entered password: ");
                EnteredPassword = Console.ReadLine();
            }
            else
            {
                AccountFileName = UserName + ".txt";

                AccountDataList.Clear();

                OpenOrCreateAndWriteToAccountDataFile();

                NewAccountUserLogIn();
            }
        }

        public static void OpenOrCreateAndWriteToAccountDataFile()
        {
            File.Delete(AccountFileName);

            StreamWriter AccountDataFileStreamWriter = new StreamWriter(File.Open(LogIn.AccountFileName, FileMode.Create));

            AccountDataFileStreamWriter.WriteLine(LogIn.UserName);
            AccountDataFileStreamWriter.WriteLine(LogIn.CreatedPassword);
            AccountDataFileStreamWriter.Write("\n");

            foreach (string Record in LogIn.AccountDataList)
            {
                AccountDataFileStreamWriter.WriteLine(Record);
            }

            AccountDataFileStreamWriter.Close();
        }

        public static bool StreamReaderOpenAndCloseAccountDataFile()
        {
            bool IsReadOk = false;

            StreamReader AccountDataFileStreamReader = new StreamReader(File.Open(LogIn.AccountFileName, FileMode.Open));

            string FileUserName = AccountDataFileStreamReader.ReadLine();
                   FilePassword = AccountDataFileStreamReader.ReadLine();

            if (LogIn.UserName == FileUserName) //&& LogIn.CreatedPassword == FilePassword
            //LogIn.UserName + LogIn.CreatedPassword are null. Due to not being created during this instance of the program
            {
                while (!AccountDataFileStreamReader.EndOfStream)
                {
                    string Record = AccountDataFileStreamReader.ReadLine();

                    LogIn.AccountDataList.Add(Record);
                }
                //has the LogIn. due to having this method being used in other classes.
                AccountDataFileStreamReader.Close();

                IsReadOk = true;
            }
            else
            {
                Console.WriteLine("Exeception Hit within: StreamReaderOpenAndCloseAccountDataFile ");
                Console.ReadLine();
                //In practise: take dump of variables and inform user of error.
            }
            return IsReadOk;
        }

        public static void LogOut()
        {
            Console.Write("Press Any Key To Log Out");
            Console.ReadLine();

            Console.Clear();

            Program.Main(null);
        }

     
        private static void LogInMenuGraphics()
        {

        }

    }
}
