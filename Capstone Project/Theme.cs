using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project
{
    class Theme
    {
        #region SET COLORS

        
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
        /// <summary>
        /// *****************************************************************
        ///             SET THEME COLOR
        /// *****************************************************************
        /// </summary>
        public static void SetForegroundColor()
        {
            SetColor(ConsoleColor.DarkCyan);
        }
        /// <summary>
        /// *****************************************************************
        ///             SET CONSOLE COLOR
        /// *****************************************************************
        /// </summary>
        /// <param name="color"></param>
        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        #endregion

        #region COLOR MESSAGE


        /// <summary>
        /// *****************************************************************
        ///             MENU IN COLORS
        /// *****************************************************************
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void ColorMenu(string menuLetter,
                                     string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"\t{menuLetter}");
            SetForegroundColor();
            Console.Write($"{message}\n");
        }
        /// <summary>
        /// *****************************************************************
        ///             PRINT MESSAGE IN COLOR
        /// *****************************************************************
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void ColorPrint(string message,
                                      ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\t{message}");
            SetForegroundColor();
        }
        
        /// <summary>
        /// *****************************************************************
        ///             VALIDATION MESSAGE IN RED, INPUT IN WHITE
        /// *****************************************************************
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void ValidateColorPrint(string message,
                                              ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"\t{message}");
            SetColor(ConsoleColor.White);
        }

        /// <summary>
        /// *****************************************************************
        ///             PRINT WITH TAB
        /// *****************************************************************
        /// </summary>
        /// <param name="prompt"></param>
        public static void Print(string prompt)
        {
            Console.WriteLine($"\t{prompt}");
        }
        /// <summary>
        /// *****************************************************************
        ///             MENU CHOICE THEME
        /// *****************************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
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
        /// <summary>
        /// *****************************************************************
        ///             PRINT MESSAGE IN THEME COLOR, INPUT IN WHITE
        /// *****************************************************************
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public static void PrintColorData(string message,
                                          string data)
        {
            Console.Write($"\t{message}");
            SetColor(ConsoleColor.White);
            Console.Write($"{data}\n");
            SetForegroundColor();
        }
        /// <summary>
        /// *****************************************************************
        ///             READ IN THEME COLOR, INPUT IN WHITE
        /// *****************************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string ReadWrite(string prompt)
        {
            string ret;
            Console.Write($"\t{prompt}");
            SetColor(ConsoleColor.White);
            ret = Console.ReadLine();
            SetForegroundColor();
            return ret;
        }
        /// <summary>
        /// *****************************************************************
        ///             PRINT RANGE MESSAGE WITH RED AND WHITE
        /// *****************************************************************
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dataOne"></param>
        /// <param name="messageTwo"></param>
        /// <param name="dataTwo"></param>
        /// <param name="messageThree"></param>
        public static void RangeMessage(string message,
                                        string dataOne,
                                        string messageTwo,
                                        string dataTwo,
                                        string messageThree)
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
        /// <summary>
        /// *****************************************************************
        ///             PRINT TABLE IN CYAN AND WHITE
        /// *****************************************************************
        /// </summary>
        /// <param name="dataOne"></param>
        /// <param name="dataTwo"></param>
        public static void ColorTable(string dataOne,
                                      string dataTwo)
        {
            SetColor(ConsoleColor.Cyan);
            Console.Write(dataOne);
            SetColor(ConsoleColor.White);
            Console.Write(dataTwo);
            SetForegroundColor();
        }
        #endregion

        #region THEME


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

            //
            // Print Welcome Header
            //
            ColorPrint("\t\tThe Essential Home Application", ConsoleColor.DarkMagenta);
            Console.WriteLine();

            //
            // Print welcome Image
            //
            Picture.PrintImage();


            Console.WriteLine();
            Console.WriteLine();
            
            //
            // Prompt user to continue
            //
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
            Picture.PrintClosing();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ColorPrint("And a special thanks goes to", ConsoleColor.Cyan);
            Console.WriteLine();
            ColorPrint("Wyatt J. Miller", ConsoleColor.White);
            ColorPrint("Noah Osterhout", ConsoleColor.White);
            ColorPrint("Peter Steele", ConsoleColor.White);

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
            //
            // Continue prompt in Dark Yellow
            //
            ColorPrint("Press any key to continue.", ConsoleColor.DarkYellow);
            Console.ReadKey();
        }

        /// <summary>
        /// *****************************************************************
        ///             DISPLAY MENU PROMPT
        /// *****************************************************************
        /// </summary>
        public static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            
            // 
            // Menu Prompt in Dark Yellow
            //
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
            
            //
            // Set Cursor invisible
            //
            Console.CursorVisible = false;

            //
            // Set color for Header text in Dark Magenta
            //
            SetColor(ConsoleColor.DarkMagenta);

            Console.WriteLine();

            //
            // Display Header
            //
            Print($"{headerText}");
            Console.WriteLine();
            SetForegroundColor();
        }
        #endregion
    }
}
