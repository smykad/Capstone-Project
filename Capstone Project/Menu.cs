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
        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
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
                Console.WriteLine("\tA: Application Information");
                Console.WriteLine("\tB: Home Data Menu");
                Console.WriteLine("\tC: Returning User Data");
                Console.WriteLine("\tD: Stored Users and Passwords");
                Console.WriteLine("\tQ: Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

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
                        Login.DisplayCredentials();
                        break;

                    case "q":

                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        Theme.DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }
        /// <summary>
        /// *****************************************************************
        ///             Display Returning User Information
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
                if (loginInfoText.Contains(userName))
                {
                    Console.WriteLine($"\t{loginInfoText}");
                }
            }

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        ///         Display Application Information
        /// *****************************************************************
        /// </summary>
        static void DisplayApplicationInformation()
        {
            Theme.DisplayScreenHeader("Application Information");
            Console.WriteLine("Module Under Construction");
            Theme.DisplayMenuPrompt("Main Menu");
        }
    }
}
