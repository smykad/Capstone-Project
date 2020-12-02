﻿using System;
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
                        Login.DisplayCredentials();
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
                //
                // Added in the "'s" to catch similar names like Doug, Douglas
                //
                if (loginInfoText.Contains(userName + "'s"))
                {
                    Theme.Print($"{loginInfoText}");
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
            Theme.Print("Module Under Construction");
            Theme.DisplayMenuPrompt("Main Menu");
        }
    }
}
