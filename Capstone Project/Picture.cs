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
                @"
             /\          /  ^ \/^ ^/^  ^  ^ \/^ \/  ^ \
            / ^\    /\  / ^   /  ^/ ^ ^ ^   ^\ ^/  ^^  \",
                ConsoleColor.DarkGreen);

            PrintPicture(
                @"
           /^   \  / ^\/ ^ ^   ^ / ^  ^    ^  \/ ^   ^  \       ", "*",
               ConsoleColor.DarkGreen,
               ConsoleColor.Yellow);

            PrintPicture(
                @"
          /  ^ ^ \/^  ^\ ^ ^ ^   ^  ^   ^   ",
                @"____",
                @"  ^   ^  \     /|\
",
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
                @"\
",
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
                @"|||\
",
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
                @"|\
",
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
                @"||||||\
",
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
                @"| |
",
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
                @"ooooooo
",
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

        public static void getImages(ConsoleColor[] colors, string[] images)
        {
            int i = 0;
            foreach (string image in images)
            {

                SetColor(colors[i]);
                Console.Write(image);
                i++;
            }
        }

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

        static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
