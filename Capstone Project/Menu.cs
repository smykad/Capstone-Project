using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone_Project
{
    class Menu
    {
        #region MAIN MENU
        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// *        A: Application Information                             *
        /// *        B: Home Data Menu                                      *
        /// *        C: Returning User Data                                 *
        /// *        D: Stored Users and Passwords                          *
        /// *                                                               *
        /// *****************************************************************
        /// </summary>
        public static void DisplayMenuScreen(string userName)
        {
            Console.CursorVisible = true;

            //
            // Initialize variables
            //
            bool quitMenu = false;
            string menuChoice;

            do
            {
                //
                // Display Header
                //
                Theme.DisplayScreenHeader("Main Menu");

                //
                // Get user menu choice
                //
                Theme.ColorMenu("A: ", "Application Information");
                Theme.ColorMenu("B: ", "Home Data Menu");
                Theme.ColorMenu("C: ", "Returning User Data");
                Theme.ColorMenu("D: ", "Stored Users and Passwords");
                Theme.ColorMenu("Q: ", "Quit");
                menuChoice = Theme.MenuChoice("\n\n\tEnter Choice: ").ToLower();
                

                //
                // Process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayApplicationInformation();
                        break;

                    case "b":
                        Home.DisplayRoomMenuScreen(userName);
                        break;

                    case "c":
                        DisplayReturningUserInformation(userName);
                        break;

                    case "d":
                        DisplayCredentials();
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Theme.ColorPrint("Please enter a letter for the menu choice.", ConsoleColor.Red);
                        Console.Beep(200, 500);
                        Theme.DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }
#endregion

        #region MENU OPTIONS
        /// <summary>
        /// *****************************************************************
        ///         A. Display Application Information
        /// *****************************************************************
        /// </summary>
        static void DisplayApplicationInformation()
        {
            Theme.DisplayScreenHeader("Capstone Project CIT 110");
            Theme.ColorPrint("*************************************************************************", ConsoleColor.DarkMagenta);
            Theme.ColorPrint("This application was developed using Visual Studio 2019 Community Edition", ConsoleColor.Cyan);
            Console.WriteLine();
            Theme.ColorTable("\tCreated: ", "11/19/2020\n");
            Console.WriteLine();
            Theme.ColorTable("\tRevised: ", "12/2/2020\n");
            Console.WriteLine();
            Theme.ColorTable("\tApplicationg written by: ", "Doug Smyka\n\n");
            Console.WriteLine();
            Theme.ColorPrint("With the assistance of", ConsoleColor.Yellow);
            Console.WriteLine();
            Theme.ColorPrint("Wyatt J. Miller", ConsoleColor.White);
            Theme.ColorPrint("Noah Osterhout", ConsoleColor.White);
            Theme.ColorPrint("Peter Steele", ConsoleColor.White);
            Console.WriteLine();
            Theme.ColorPrint("*************************************************************************", ConsoleColor.DarkMagenta);
            Theme.DisplayMenuPrompt("Main Menu");
        }
        /// <summary>
        /// *****************************************************************
        ///             C: Display Returning User Information
        /// *****************************************************************
        /// </summary>
        /// <param name="userName"></param>
        static void DisplayReturningUserInformation(string userName)
        {
            //
            // Initialize Variables
            //
            string dataPath = @"Data/UserHomes.txt";
            string[] loginInfoArray;

            //
            // Read Data from file
            //
            loginInfoArray = File.ReadAllLines(dataPath);

            //
            // Display Header
            //
            Theme.DisplayScreenHeader($"{userName}'s Home Data");

            foreach (string loginInfoText in loginInfoArray)
            {
                //
                // Added in the "'s" to catch similar names like Doug, Douglas
                //
                if (loginInfoText.Contains(userName + "'s"))
                {
                    Theme.Print($"{loginInfoText}");
                    Console.WriteLine();
                }
            }

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt("Main Menu");
        }
        /// <summary>
        /// ******************************************************
        ///             D. Display Credentials
        /// ******************************************************
        /// </summary>
        public static void DisplayCredentials()
        {
            Theme.DisplayScreenHeader("User Names and Passwords");
            TableofUserNames();
            Theme.DisplayMenuPrompt("Main Menu");
        }
#endregion

        #region DISPLAY INFO
        /// <summary>
        /// ******************************************************
        ///             DISPLAY USERNAMES AND ENCRYPTED PASSWORDS
        /// ******************************************************
        /// </summary>
        static void TableofUserNames()
        {
            //
            // Initialize variables
            //
            string dataPath = @"Data\Logins.txt";
            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            //
            // Read File
            //
            loginInfoArray = File.ReadAllLines(dataPath);

            //
            // Display Data in a Table
            //
            Console.WriteLine(string.Format($"\t{"User Name",10} \t {"Password",20}"));
            Console.WriteLine();
            foreach (string loginInfoText in loginInfoArray)
            {
                loginInfoArray = loginInfoText.Split(',');

                Console.WriteLine(string.Format($"\t{ loginInfoTuple.userName = loginInfoArray[0],10} \t {loginInfoTuple.password = loginInfoArray[1],20}"));
            }

        }
        #endregion
    }
}
