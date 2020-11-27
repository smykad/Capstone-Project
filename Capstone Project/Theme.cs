using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project
{
    class Theme
    {
        /// <summary>
        /// setup the console theme
        /// </summary>
        public static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        public static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\tThe Essential Home Application");
            Console.WriteLine();
            Console.WriteLine(@"
                                       /\
                                  /\  //\\
                           /\    //\\///\\\        /\
                          //\\  ///\////\\\\  /\  //\\
             /\          /  ^ \/^ ^/^  ^  ^ \/^ \/  ^ \
            / ^\    /\  / ^   /  ^/ ^ ^ ^   ^\ ^/  ^^  \
           /^   \  / ^\/ ^ ^   ^ / ^  ^    ^  \/ ^   ^  \       *
          /  ^ ^ \/^  ^\ ^ ^ ^   ^  ^   ^   ____  ^   ^  \     /|\
         / ^ ^  ^ \ ^  _\___________________|  |_____^ ^  \   /||o\
        / ^^  ^ ^ ^\  /______________________________\ ^ ^ \ /|o|||\
       /  ^  ^^ ^ ^  /________________________________\  ^  /|||||o|\
      /^ ^  ^ ^^  ^    ||___|___||||||||||||___|__|||      /||o||||||\
     / ^   ^   ^    ^  ||___|___||||||||||||___|__|||          | |
    / ^ ^ ^  ^  ^  ^   ||||||||||||||||||||||||||||||oooooooooo| |ooooooo
    ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");

            Console.WriteLine();
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        public static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tI hope you enjoyed using my application");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        public static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        public static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        public static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("\t" + headerText);
            Console.WriteLine();
        }
    }
}
