using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project
{
    class Picture
    {
        /// <summary>
        /// *****************************************************************************
        /// *                             HOUSE IN ASCII ART                            *
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


        /// <summary>
        /// *****************************************************************************
        /// *                  METHODS FOR COLORING THE IMAGE                           *
        /// *****************************************************************************
        /// </summary>

        public static void PrintPicture(params object[] arguments)
        {
            List<ConsoleColor> colors = new List<ConsoleColor>();
            List<string> images = new List<string>();
            foreach (object argument in arguments)
            {
                if (argument.GetType() == typeof(string))
                {
                    images.Add(argument.ToString());
                }
                else if (argument.GetType() == typeof(ConsoleColor))
                {
                    colors.Add((ConsoleColor)Enum.Parse(typeof(ConsoleColor), argument.ToString()));
                }
            }

            getImages(colors.ToArray(), images.ToArray());
        }

        static void getImages(ConsoleColor[] colors,
                                     string[] images)
        {
            int i = 0;
            foreach (string image in images)
            {
                SetColor(colors[i]);
                Console.Write(image);
                i++;
                if (i == images.Length)
                {
                    Console.WriteLine();
                }
            }
        }
        static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
