using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project
{
    public class Validate
    {
        private string _prompt;
        private int _integer;
        private double _double;

        public double Double
        {
            get { return _double; }
            set { _double = value; }
        }
        public string Prompt
        {
            get { return _prompt; }
            set { _prompt = value; }
        }
        public int Integer
        {
            get { return _integer; }
            set { _integer = value; }
        }
        public Validate(string prompt, string type)
        {
            _prompt = prompt;
            Console.Write($"\t{prompt}");
            if (type == "integer")
            {
                _integer = IsValidInt();
            }
            if (type == "double")
            {
                _double = IsValidDouble();
            }
        }
        public Validate(string prompt, string type, int min, int max)
        {
            _prompt = prompt;
            Console.Write($"\t{prompt}");
            if (type == "integer")
            {
                _integer = IsValidInt();
                _integer = IsValidThresholdAndRange(_integer, min, max);
            }
            if (type == "double")
            {
                _double = IsValidDouble();
                _double = IsValidThresholdAndRange(_double, min, max);
            }
        }

        int IsValidInt()
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
        double IsValidDouble()
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

        int IsValidThresholdAndRange(int thresholdValue, int min, int max)
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

        double IsValidThresholdAndRange(double thresholdValue, int min, int max)
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
