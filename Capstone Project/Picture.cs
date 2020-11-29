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
        /// *****************************************************************
        /// *           CLASS FOR PRINTING AN IMAGE IN COLOR                *
        /// *****************************************************************
        /// </summary>
        public static void PrintImage()
        {
            PrintPictureTwo(
                @"
                                       /\
                                  /\  //\\
                           /\    //\\///\\\        /\
                          //\\  ///\////\\\\  /\  //\\");

            PrintPicture(
                @"
             /\          /  ^ \/^ ^/^  ^  ^ \/^ \/  ^ \
            / ^\    /\  / ^   /  ^/ ^ ^ ^   ^\ ^/  ^^  \");

            PrintPicture(
                @"
           /^   \  / ^\/ ^ ^   ^ / ^  ^    ^  \/ ^   ^  \       ", "*");

            PrintPicture(
                @"          /  ^ ^ \/^  ^\ ^ ^ ^   ^  ^   ^   ",
                @"____",
                @"  ^   ^  \     /|\");

            PrintPictureTwo(
                @"         / ^ ^  ^ \ ^  ",
                @"_",
                @"\",
                @"___________________|  |_____",
                @"^ ^  \   /||",
                @"o",
                @"\");

            PrintPictureTwo(
                @"        / ^^  ^ ^ ^\  ", 
                @"/______________________________\", 
                @" ^ ^ \ /|", 
                @"o", 
                @"|||\");

            PrintPictureTwo(
                @"       /  ^  ^^ ^ ^  ",
                @"/________________________________\",
                @"  ^  /|||||",
                @"o",
                @"|\");

            PrintPicture(
                @"      /^ ^  ^ ^^  ^    ",
                @"|", @"|___|___|",
                @"||||||||||",
                @"|___|__|",
                @"||      ",
                @"/||", @"o",
                @"||||||\");

            PrintPicture(
                @"     / ^   ^   ^    ^  ",
                @"|",
                @"|___|___|",
                @"||||||||||",
                @"|___|__|",
                @"||          ",
                @"| |");


            PrintPicture(
                @"    / ^ ^ ^  ^  ^  ^   ",
                @"||||||||||||||||||||||||||||||",
                @"oooooooooo",
                @"| |",
                @"ooooooo");

            PrintPictureTwo(
                @"    ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
        }
        static void PrintPicture(string image)
        {
            DGreen();
            Console.Write(image);
        }
        static void PrintPicture(string imageOne, string imageTwo)
        {
            DGreen();
            Console.Write(imageOne);
            Yellow();
            Console.WriteLine(imageTwo);
        }
        static void PrintPicture(string imageOne, string imageTwo, string imageThree)
        {
            DGreen();
            Console.Write(imageOne);
            DRed();
            Console.Write(imageTwo);
            DGreen();
            Console.WriteLine(imageThree);
        }
        static void PrintPicture(string imageOne, string imageTwo, string imageThree, string imageFour, string imageFive)
        {
            DGreen();
            Console.Write(imageOne);
            Magenta();
            Console.Write(imageTwo);
            White();
            Console.Write(imageThree);
            DYellow();
            Console.Write(imageFour);
            White();
            Console.WriteLine(imageFive);
        }
        static void PrintPicture(string imageOne, string imageTwo, string imageThree, 
                                string imageFour, string imageFive, string imageSix, 
                                string imageSeven)
        {
            DGreen();
            Console.Write(imageOne);
            Magenta();
            Console.Write(imageTwo);
            Blue();
            Console.Write(imageThree);
            Magenta();
            Console.Write(imageFour);
            Blue();
            Console.Write(imageFive);
            Magenta();
            Console.Write(imageSix);
            DYellow();
            Console.WriteLine(imageSeven);
        }
        static void PrintPicture(string imageOne, string imageTwo, string imageThree, 
                                string imageFour, string imageFive, string imageSix, 
                                string imageSeven, string imageEight, string imageNine)
        {
            DGreen();
            Console.Write(imageOne);
            Magenta();
            Console.Write(imageTwo);
            Blue();
            Console.Write(imageThree);
            Magenta();
            Console.Write(imageFour);
            Blue();
            Console.Write(imageFive);
            Magenta();
            Console.Write(imageSix);
            DGreen();
            Console.Write(imageSeven);
            Yellow();
            Console.Write(imageEight);
            DGreen();
            Console.WriteLine(imageNine);
        }
        static void PrintPictureTwo(string imageOne, string imageTwo, string imageThree, 
                                    string imageFour, string imageFive)
        {
            DGreen();
            Console.Write(imageOne);
            DRed();
            Console.Write(imageTwo);
            DGreen();
            Console.Write(imageThree);
            Yellow();
            Console.Write(imageFour);
            DGreen();
            Console.WriteLine(imageFive);
        }
        static void PrintPictureTwo(string imageOne, string imageTwo, string imageThree, 
                                    string imageFour, string imageFive, string imageSix, 
                                    string imageSeven)
        {
            DGreen();
            Console.Write(imageOne);
            DRed();
            Console.Write(imageTwo);
            DGreen();
            Console.Write(imageThree);
            DRed();
            Console.Write(imageFour);
            DGreen();
            Console.Write(imageFive);
            Yellow();
            Console.Write(imageSix);
            DGreen();
            Console.WriteLine(imageSeven);
        }

        static void PrintPictureTwo(string image)
        {
            White();
            Console.Write(image);
        }
        static void DGreen()
        {
            Theme.SetColor(ConsoleColor.DarkGreen);
        }
        static void DRed()
        {
            Theme.SetColor(ConsoleColor.DarkRed);
        }
        static void Blue()
        {
            Theme.SetColor(ConsoleColor.Blue);
        }
        static void Yellow()
        {
            Theme.SetColor(ConsoleColor.Yellow);
        }
        static void DYellow()
        {
            Theme.SetColor(ConsoleColor.DarkYellow);
        }
        static void White()
        {
            Theme.SetColor(ConsoleColor.White);
        }
        static void Magenta()
        {
            Theme.SetColor(ConsoleColor.Magenta);
        }
    }
}
