using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project
{
    class Picture
    {
        #region ART
        /// <summary>
        /// *****************************************************************************
        /// *                           CLOSING IN ASCII ART                            *
        /// *****************************************************************************
        /// *                             ''~``                                         * 
        /// *                            ( o o )                                        *
        /// *    +------------------.oooO--(_)--Oooo.------------------+                *
        /// *    |      Thanks for using my application                |                *
        /// *    |                    .oooO                            |                *
        /// *    |                    (   )   Oooo.    -Doug Smyka     |                *
        /// *    +---------------------\ (----(   )--------------------+                *
        /// *                           \_)    ) /                                      *
        /// *                                 (_/                                       *
        /// *****************************************************************************
        ///</summary>
        public static void PrintClosing()
        {
            PrintPicture(
                @"                                   ''~``",
                ConsoleColor.Yellow);
            PrintPicture(
                @"                                  (",
                @" o o ",
                @") ",


                ConsoleColor.DarkYellow, 
                ConsoleColor.Blue, 
                ConsoleColor.DarkYellow);
            PrintPicture(
                @"          +",
                @"------------------",
                @".oooO",
                @"--",
                @"(_)",
                @"--",
                @"Oooo.",
                @"------------------",
                @"+",
                ConsoleColor.Cyan,
                ConsoleColor.Green,
                ConsoleColor.DarkYellow,
                ConsoleColor.Green,
                ConsoleColor.DarkYellow, 
                ConsoleColor.Green,
                ConsoleColor.DarkYellow,
                ConsoleColor.Green,
                ConsoleColor.Cyan);
            PrintPicture(
                @"          |      ",
                @"Thanks for using my application",
                @"                |",
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Green);
            PrintPicture(
                @"          |                    ",
                @".oooO                            ",
                @"|",
                ConsoleColor.Green,
                ConsoleColor.DarkYellow,
                ConsoleColor.Green);
            PrintPicture(
                @"          |                    ",
                @"(   )   Oooo.    ",
                @"-Doug Smyka     ",
                @"|",
                ConsoleColor.Green,
                ConsoleColor.DarkYellow,
                ConsoleColor.White,
                ConsoleColor.Green);
            PrintPicture(
                @"          +",
                @"---------------------",
                @"\ (",
                @"----",
                @"(   )",
                @"--------------------",
                @"+",
                ConsoleColor.Cyan,
                ConsoleColor.Green,
                ConsoleColor.DarkYellow,
                ConsoleColor.Green,
                ConsoleColor.DarkYellow,
                ConsoleColor.Green,
                ConsoleColor.Cyan);
            PrintPicture(
                @"                                 \_)    ) /",
                ConsoleColor.DarkYellow);
            PrintPicture(
                @"                                       (_/",
                ConsoleColor.DarkYellow);


        }
        /// <summary>
        /// *****************************************************************************
        /// *                  DISPLAY HOUSE ASCII ART  IN COLOR                        *
        /// *****************************************************************************
        /// *                                       /\                                  *
        /// *                                  /\  //\\                                 *
        /// *                           /\    //\\///\\\        /\                      *
        /// *                          //\\  ///\////\\\\  /\  //\\                     *
        /// *             /\          /  ^ \/^ ^/^  ^  ^ \/^ \/  ^ \                    *
        /// *            / ^\    /\  / ^   /  ^/ ^ ^ ^   ^\ ^/  ^^  \                   *
        /// *           /^   \  / ^\/ ^ ^   ^ / ^  ^    ^  \/ ^   ^  \       *          *
        /// *          /  ^ ^ \/^  ^\ ^ ^ ^   ^  ^   ^   ____  ^   ^  \     /|\         *
        /// *         / ^ ^  ^ \ ^  _\___________________|  |_____^ ^  \   /||o\        *
        /// *        / ^^  ^ ^ ^\  /______________________________\ ^ ^ \ /|o|||\       *
        /// *       /  ^  ^^ ^ ^  /________________________________\  ^  /|||||o|\      *
        /// *      /^ ^  ^ ^^  ^    ||___|___||||||||||||___|__|||      /||o||||||\     *
        /// *     / ^   ^   ^    ^  ||___|___||||||||||||___|__|||          | |         *
        /// *    / ^ ^ ^  ^  ^  ^   ||||||||||||||||||||||||||||||oooooooooo| |ooooooo  *
        /// *    ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo  *
        /// *                                                                           *
        /// *****************************************************************************
        /// </summary>
        public static void PrintImage()
        {
            PrintPicture(
                @"
                                       /\
                                  /\  //\\
                           /\    //\\///\\\        /\
                          //\\  ///\////\\\\  /\  //\\",
                ConsoleColor.White);

            PrintPicture(
                @"             /\          /  ^ \/^ ^/^  ^  ^ \/^ \/  ^ \
            / ^\    /\  / ^   /  ^/ ^ ^ ^   ^\ ^/  ^^  \",
                ConsoleColor.DarkGreen);

            PrintPicture(
                @"           /^   \  / ^\/ ^ ^   ^ / ^  ^    ^  \/ ^   ^  \       ", "*",
               ConsoleColor.DarkGreen,
               ConsoleColor.Yellow);

            PrintPicture(
                @"          /  ^ ^ \/^  ^\ ^ ^ ^   ^  ^   ^   ",
                @"____",
                @"  ^   ^  \     /|\",
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkGreen);

            PrintPicture(
                @"         / ^ ^  ^ \ ^  ",
                @"_",
                @"\",
                @"___________________|  |_____",
                @"^ ^  \   /||",
                @"o",
                @"\",
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkGreen,
                ConsoleColor.Yellow,
                ConsoleColor.DarkGreen);

            PrintPicture(
                @"        / ^^  ^ ^ ^\  ",
                @"/______________________________\",
                @" ^ ^ \ /|",
                @"o",
                @"|||\",
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkGreen,
                ConsoleColor.Yellow,
                ConsoleColor.DarkGreen);

            PrintPicture(
                @"       /  ^  ^^ ^ ^  ",
                @"/________________________________\",
                @"  ^  /|||||",
                @"o",
                @"|\",
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkGreen,
                ConsoleColor.Yellow,
                ConsoleColor.DarkGreen);

            PrintPicture(
                @"      /^ ^  ^ ^^  ^    ",
                @"|",
                @"|___|___|",
                @"||||||||||",
                @"|___|__|",
                @"||      ",
                @"/||",
                @"o",
                @"||||||\",
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkGray,
                ConsoleColor.Blue,
                ConsoleColor.DarkGray,
                ConsoleColor.Blue,
                ConsoleColor.DarkGray,
                ConsoleColor.DarkGreen,
                ConsoleColor.Yellow,
                ConsoleColor.DarkGreen);

            PrintPicture(
                @"     / ^   ^   ^    ^  ",
                @"|",
                @"|___|___|",
                @"||||||||||",
                @"|___|__|",
                @"||          ",
                @"| |",
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkGray,
                ConsoleColor.Blue,
                ConsoleColor.DarkGray,
                ConsoleColor.Blue,
                ConsoleColor.DarkGray,
                ConsoleColor.DarkYellow);


            PrintPicture(
                @"    / ^ ^ ^  ^  ^  ^   ",
                @"||||||||||||||||||||||||||||||",
                @"oooooooooo",
                @"| |",
                @"ooooooo",
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkGray,
                ConsoleColor.White,
                ConsoleColor.DarkYellow,
                ConsoleColor.White);

            PrintPicture(
                @"    ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo",
                ConsoleColor.White);
        }
        #endregion

        #region IMAGE COLORING
        /// *****************************************************************************
        /// *                  METHODS FOR COLORING THE IMAGE                           *
        /// *****************************************************************************

        /// <summary>
        /// *****************************************************************************
        ///             PRINT PICTURE
        /// *****************************************************************************
        /// </summary>
        /// <param name="arguments"></param>
        static void PrintPicture(params object[] arguments)
        {
            //
            // Initialize lists for input
            //
            List<ConsoleColor> colors = new List<ConsoleColor>();
            List<string> images = new List<string>();


            // 
            // Iterate through the arguments entered
            //
            foreach (object argument in arguments)
            {

                //
                // Filter through the arguments
                //
                if (argument.GetType() == typeof(string))
                {
                    images.Add(argument.ToString());
                }
                else if (argument.GetType() == typeof(ConsoleColor))
                {
                    colors.Add((ConsoleColor)Enum.Parse(typeof(ConsoleColor), argument.ToString()));
                }
            }

            //
            // Pass the lists as arrays to the "getImages" method
            //
            getImages(colors.ToArray(), images.ToArray());
        }
        /// <summary>
        /// *****************************************************************************
        ///         Get Images
        /// ***************************************************************************** 
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="images"></param>
        static void getImages(ConsoleColor[] colors,
                                     string[] images)
        {
            //
            // Initialize variable i for iterations
            //
            int i = 0;
            foreach (string image in images)
            {
                //
                // Use the method "SetColor" to set the color 
                // based on the index of the array
                //
                SetColor(colors[i]);
                //
                // Write the first image
                //
                Console.Write(image);
                //
                // Increment iteration
                //
                i++;

                //
                // When you reach the last string to write it goes to a new line
                //
                if (i == images.Length)
                {
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// *****************************************************************************
        ///         SET COLOR
        /// *****************************************************************************                         
        /// </summary>
        /// <param name="color"></param>
        static void SetColor(ConsoleColor color)
        {
            //
            // Set the foreground color
            //
            Console.ForegroundColor = color;
        }
        #endregion
    }
}
