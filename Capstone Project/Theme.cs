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
        /// *****************************************************************
        ///             SET UP CONSOLE THEME
        /// *****************************************************************
        /// </summary>
        public static void SetTheme()
        {
            SetForegroundColor();
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void SetForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// *****************************************************************
        ///             SET A STRING A SPECIFIC COLOR
        /// *****************************************************************
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void ColorMenu(string menuLetter, string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"\t{menuLetter}");
            SetForegroundColor();
            Console.Write($"{message}\n");
        }
        public static void ColorPrint(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\t{message}");
            SetForegroundColor();
        }

        public static void ValidateColorPrint(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"\t{message}");
            SetColor(ConsoleColor.White);
        }

        /// <summary>
        /// *****************************************************************
        ///             WELCOME SCREEN
        /// *****************************************************************
        /// </summary>
        public static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            ColorPrint("\t\tThe Essential Home Application", ConsoleColor.DarkMagenta);
            Console.WriteLine();
            Picture.PrintImage();
            Console.WriteLine();
            Console.WriteLine();
            DisplayContinuePrompt();
        }


        /// <summary>
        /// *****************************************************************
        ///             CLOSING SCREEN
        /// *****************************************************************
        /// </summary>
        public static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Print("I hope you enjoyed using my application");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        ///             DISPLAY CONTINUE PROMPT
        /// *****************************************************************
        /// 
        /// </summary>
        public static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            ColorPrint("Press any key to continue.", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        public static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            SetColor(ConsoleColor.DarkYellow);
            Print($"Press any key to return to the {menuName} Menu.");
            SetForegroundColor();
            Console.ReadKey();
        }

        /// <summary>
        /// *****************************************************************
        ///             DISPLAY SCREEN HEADER
        /// *****************************************************************
        /// </summary>
        public static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.CursorVisible = false;
            SetColor(ConsoleColor.DarkMagenta);
            Console.WriteLine();
            Console.WriteLine($"\t{headerText}");
            Console.WriteLine();
            SetForegroundColor();
        }
        /// <summary>
        /// *****************************************************************
        ///             PRINT
        /// *****************************************************************
        /// </summary>
        /// <param name="prompt"></param>
        public static void Print(string prompt)
        {
            Console.WriteLine($"\t{prompt}");
        }
        public static string MenuChoice(string prompt)
        {
            string ret;
            SetColor(ConsoleColor.DarkYellow);
            Console.Write($"\t{prompt}");
            SetColor(ConsoleColor.White);
            ret = Console.ReadLine();
            SetForegroundColor();
            return ret;
        }
        public static void PrintColorData(string message, string data)
        {
            Console.Write($"\t{message}");
            SetColor(ConsoleColor.White);
            Console.Write($"{data}\n");
            SetForegroundColor();
        }
        public static string ReadWrite(string prompt)
        {
            string ret;
            Console.Write($"\t{prompt}");
            SetColor(ConsoleColor.White);
            ret = Console.ReadLine();
            SetForegroundColor();
            return ret;
        }
        public static void RangeMessage(string message, string dataOne, string messageTwo, string dataTwo, string messageThree)
        {
            SetColor(ConsoleColor.Red);
            Console.Write($"\t{message}");
            SetColor(ConsoleColor.White);
            Console.Write(dataOne);
            SetColor(ConsoleColor.Red);
            Console.Write(messageTwo);
            SetColor(ConsoleColor.White);
            Console.Write(dataTwo);
            SetColor(ConsoleColor.Red);
            Console.Write(messageThree);
        }
        public static void ColorTable(string dataOne, string dataTwo)
        {
            SetColor(ConsoleColor.Cyan);
            Console.Write(dataOne);
            SetColor(ConsoleColor.White);
            Console.Write(dataTwo);
            SetForegroundColor();
        }
    }
}
