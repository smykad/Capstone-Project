using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project
{
    public class Validate
    {
        /// <summary>
        /// *****************************************************************
        ///             VALIDATE INTEGER, INPUT WHITE
        /// *****************************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static int ReadInteger(string prompt)
        {
            int ret;
            Console.Write($"\t{prompt}");
            Theme.SetColor(ConsoleColor.White);
            ret = IsValidInt();
            Theme.SetForegroundColor();
            return ret;
        }
        /// <summary>
        /// *****************************************************************
        ///         VALIDATE INTEGER, INPUT WHITE,  WITH RANGE OVERLOAD
        /// *****************************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int ReadInteger(string prompt,
                                      int min,
                                      int max)
        {
            Console.Write($"\t{prompt}");
            Theme.SetColor(ConsoleColor.White);
            int thresholdValue = IsValidInt();
            Theme.SetForegroundColor();
            thresholdValue = IsValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        /// <summary>
        /// *****************************************************************
        ///             VALIDATE DOUBLE, INPUT WHITE
        /// *****************************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static double ReadDouble(string prompt)
        {
            double ret;
            Console.Write($"\t{prompt}");
            Theme.SetColor(ConsoleColor.White);
            ret = IsValidDouble();
            Theme.SetForegroundColor();
            return ret;
        }
        /// <summary>
        /// *****************************************************************
        ///             VALIDATE DOUBLE, INPUT WHITE, OVERLOAD WITH RANGE
        /// *****************************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double ReadDouble(string prompt,
                                        int min,
                                        int max)
        {

            Console.Write(prompt);
            Theme.SetColor(ConsoleColor.White);
            double thresholdValue = IsValidDouble();
            Theme.SetForegroundColor();
            Console.WriteLine();
            thresholdValue = IsValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        /// <summary>
        /// *****************************************************************
        ///             VALIDATE INTEGER
        /// *****************************************************************
        /// </summary>
        /// <returns></returns>
        static int IsValidInt()
        {
            bool IsValidInt = false;
            int validInt = 0;
            while (!IsValidInt)
            {
                IsValidInt = int.TryParse(Console.ReadLine(), out validInt);
                if (!IsValidInt)
                {
                    Console.WriteLine();
                    Theme.ValidateColorPrint("Please enter an integer value: ", ConsoleColor.Red);
                    IsValidInt = false;
                }
            }
            return validInt;
        }
        /// <summary>
        /// *****************************************************************
        ///             VALIDATE DOUBLE
        /// *****************************************************************
        /// </summary>
        /// <returns></returns>
        static double IsValidDouble()
        {
            bool IsValidDouble = false;
            double validDouble = 0;
            while (!IsValidDouble)
            {
                IsValidDouble = double.TryParse(Console.ReadLine(), out validDouble);
                if (!IsValidDouble)
                {
                    Console.WriteLine();
                    Theme.ValidateColorPrint("Please enter a numeric value: ", ConsoleColor.Red);
                    
                    IsValidDouble = false;
                }
            }
            return validDouble;
        }
        /// <summary>
        /// *****************************************************************
        ///         VALIDATE RANGE OF INTEGER, OVERLOAD
        /// *****************************************************************
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>

        static int IsValidThresholdAndRange(int thresholdValue,
                                            int min,
                                            int max)
        {
            bool isValidThreshold = false;
            while (!isValidThreshold)
            {
                if (thresholdValue > max || thresholdValue < min)
                {
                    Console.WriteLine();

                    Theme.RangeMessage("Please enter a threshold value between", $" {min} ", "and", $" {max}",": ");
                    Theme.SetColor(ConsoleColor.White);
                    thresholdValue = IsValidInt();
                    Theme.SetForegroundColor();
                }
                else
                {
                    isValidThreshold = true;
                }
            }
            return thresholdValue;
        }
        /// <summary>
        /// *****************************************************************
        ///             VALIDATE RANGE OF DOUBLE, OVERLOAD
        /// *****************************************************************
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>

        static double IsValidThresholdAndRange(double thresholdValue,
                                               int min,
                                               int max)
        {
            bool isValidThreshold = false;
            while (!isValidThreshold)
            {
                if (thresholdValue > max || thresholdValue < min)
                {
                    Console.WriteLine();
                    Theme.RangeMessage("Please enter a threshold value between", $"{min}", "and", $"{max}",": ");
                    Theme.SetColor(ConsoleColor.White);
                    thresholdValue = IsValidDouble();
                    Theme.SetForegroundColor();
                }
                else
                {
                    isValidThreshold = true;
                }
            }
            return thresholdValue;
        }
        /// <summary>
        /// *****************************************************************
        ///             VALIDATE STRING INPUT FOR ROOM CHOICE
        /// *****************************************************************
        /// </summary>
        /// <returns></returns>
        public static string ReadString()
        {
            bool validString = false;
            string roomName;
            do
            {
                Theme.SetColor(ConsoleColor.White);
                roomName = Console.ReadLine().ToLower();
                Theme.SetForegroundColor();
                switch (roomName)
                {
                    case "master bedroom":
                        roomName = "Master Bedroom";
                        validString = true;
                        break;
                    case "bedroom":
                        roomName = "Bedroom";
                        validString = true;
                        break;
                    case "living room":
                        roomName = "Living Room";
                        validString = true;
                        break;
                    case "kitchen":
                        roomName = "Kitchen";
                        validString = true;
                        break;
                    case "hallway":
                        roomName = "Hallway";
                        validString = true;
                        break;
                    case "bathroom":
                        roomName = "Bathroom";
                        validString = true;
                        break;
                    case "study":
                        roomName = "Study";
                        validString = true;
                        break;
                    case "office":
                        roomName = "Office";
                        validString = true;
                        break;
                    default:
                        Theme.SetForegroundColor();
                        Console.WriteLine();
                        Theme.ValidateColorPrint("Invalid input. Enter valid room name: ", ConsoleColor.Red);

                        break;
                }

            } while (!validString);
            return roomName;
        }
    }
}
