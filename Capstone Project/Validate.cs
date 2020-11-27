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
        /// ******************************************************
        ///             Read Integer Overload
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static int ReadInteger(string prompt)
        {
            int ret;
            Console.Write($"\t{prompt}");
            ret = IsValidInt();
            return ret;
        }
        /// <summary>
        /// ******************************************************
        ///             Read Integer Overload that takes
        ///             threshold
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int ReadInteger(string prompt, int min, int max)
        {
            Console.Write(prompt);
            int thresholdValue = IsValidInt();
            thresholdValue = IsValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        /// <summary>
        /// ******************************************************
        ///             Read Double Overload
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static double ReadDouble(string prompt)
        {
            double ret;
            Console.Write($"\t{prompt}");
            ret = IsValidDouble();
            return ret;
        }
        /// <summary>
        /// ******************************************************
        ///             Read Double Overload that takes
        ///             threshold
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double ReadDouble(string prompt, int min, int max)
        {

            Console.Write(prompt);
            double thresholdValue = IsValidDouble();
            thresholdValue = IsValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        /// <summary>
        /// ******************************************************
        ///         Validate Integer
        /// ******************************************************
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
                    Console.Write("\tPlease enter an integer value: ");
                    IsValidInt = false;
                }
            }
            return validInt;
        }
        /// <summary>
        /// ******************************************************
        ///             Validate Double
        /// ******************************************************
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
                    Console.Write("\tPlease enter a numeric value: ");
                    IsValidDouble = false;
                }
            }
            return validDouble;
        }
        /// <summary>
        /// ******************************************************
        ///             Overload for validating int threshold
        /// ******************************************************
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static int IsValidThresholdAndRange(int thresholdValue, int min, int max)
        {
            bool isValidThreshold = false;
            while (!isValidThreshold)
            {
                if (thresholdValue > max || thresholdValue < min)
                {
                    Console.WriteLine();
                    Console.Write($"\tPlease enter a threshold value between {min} and {max}: ");
                    thresholdValue = IsValidInt();
                }
                else
                {
                    isValidThreshold = true;
                }
            }
            return thresholdValue;
        }
        /// <summary>
        /// ******************************************************
        ///             Overload for validating double threshold
        /// ******************************************************
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static double IsValidThresholdAndRange(double thresholdValue, int min, int max)
        {
            bool isValidThreshold = false;
            while (!isValidThreshold)
            {
                if (thresholdValue > max || thresholdValue < min)
                {
                    Console.WriteLine();
                    Console.Write($"\tPlease enter a threshold value between {min} and {max}: ");
                    thresholdValue = IsValidDouble();
                }
                else
                {
                    isValidThreshold = true;
                }
            }
            return thresholdValue;
        }

        /// <summary>
        /// ******************************************************
        ///         VALIDATES USER STRING INPUT    
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        public static string ReadString()
        {
            bool validString = false;
            string roomName;
            do
            {
                roomName = Console.ReadLine().ToLower();
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
                        Console.Write("\tInvalid input. Enter valid room name: ");
                        break;
                }

            } while (!validString);
            return roomName;
        }
    }
}
