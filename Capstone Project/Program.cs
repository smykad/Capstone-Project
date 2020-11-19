using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project
{
    // **************************************************
    //
    // Title: Capstone Project
    // Application Type: Console
    // Description: Calculate square footage of a house
    // Author: Smyka, Doug
    // Dated Created: 11/19/2020
    // Last Modified: 11/19/2020
    //
    // **************************************************
    class Program
    {
        static void Main(string[] args)
        {
            SetTheme();

           // DisplayLoginRegister();
            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        #region MAIN MENU
        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\tA: Room Size Evaluator");
                Console.WriteLine("\tB: ");
                Console.WriteLine("\tC: ");
                Console.WriteLine("\tD: ");
                Console.WriteLine("\tE: ");
                Console.WriteLine("\tF: Stored Users and Passwords");
                Console.WriteLine("\tG: ");
                Console.WriteLine("\tQ: Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayRoomMenuScreen();
                        break;

                    case "b":
                        
                        break;

                    case "c":
                        
                        break;

                    case "d":
                        
                        break;

                    case "e":
                        
                        break;
                    case "f":
                        DisplayCredentials();
                        break;

                    case "g":
                        
                        break;

                    case "q":
                        
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }
        /// <summary>
        /// *****************************************************************
        /// *                      ROOM DATA MENU                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayRoomMenuScreen()
        {
            Console.CursorVisible = true;

            int numberOfRooms = 0;
            int[] roomSizes = null;
            string[] roomNames = null;

            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("User Data Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\tA: Number of Rooms");
                Console.WriteLine("\tB: Room Data");
                Console.WriteLine("\tC: Show Data");
                Console.WriteLine("\tD: ");
                Console.WriteLine("\tE: ");
                Console.WriteLine("\tF: ");
                Console.WriteLine("\tG: ");
                Console.WriteLine("\tQ: Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfRooms = DisplayGetNumberOfRoomsData();
                        break;

                    case "b":
                        DisplayGetRoomNameAndSizeData(numberOfRooms, out roomSizes, out roomNames);
                        break;

                    case "c":
                        DisplayRoomSizeNameData(roomSizes, roomNames);
                        break;

                    case "d":

                        break;

                    case "e":
                        
                        break;
                    case "f":
                        
                        break;

                    case "g":

                        break;

                    case "q":

                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }
        /// <summary>
        /// ******************************************************
        /// 
        /// ******************************************************
        /// </summary>
        /// <param name="roomsizes"></param>
        static void DisplayTotalSqFtData(int[] roomSizes)
        {
            int sum = roomSizes.Sum();

            Console.WriteLine($"\tThe total square footage is {sum}");
        }
        /// <summary>
        /// ******************************************************
        /// 
        /// ******************************************************
        /// </summary>
        /// <param name="roomSizes"></param>
        /// <param name="roomNames"></param>
        static void DisplayRoomSizeNameData(int[] roomSizes, string[] roomNames)
        {

            DisplayScreenHeader("\t\tRoom Size Data");

            Console.WriteLine(string.Format($"{"Room",17}    {"Square Footage",17}"));
            Console.WriteLine();

            for (int i = 0; i < roomSizes.Length; i++)
            {
                string room = roomSizes[i].ToString("n2");
                string roomName = roomNames[i];
                Console.WriteLine(string.Format($"\t{roomName}{room,15}"));
            }

            Console.WriteLine();
            Console.WriteLine();
            DisplayTotalSqFtData(roomSizes);
            DisplayMenuPrompt("User Data Menu");

        }
        /// <summary>
        /// ******************************************************
        /// 
        /// ******************************************************
        /// </summary>
        /// <param name="numberOfRooms"></param>
        /// <param name="sizes"></param>
        /// <param name="names"></param>
        static void DisplayGetRoomNameAndSizeData(int numberOfRooms, out int[] sizes, out string[] names)
        {
            int[] roomSizes = new int[numberOfRooms];
            string[] roomNames = new string[numberOfRooms];
            int length;
            int width;
            string roomName;
            DisplayScreenHeader("Get Room Size Data");

            for (int i = 0; i < numberOfRooms; i++)
            {
                Console.Write("\tEnter Room Name: ");
                roomName = Console.ReadLine();
                length = PromptUserForInt($"Enter length of {roomName}: ");
                width = PromptUserForInt($"Enter width of {roomName}: ");
                roomSizes[i] = (length * width);
                roomNames[i] = roomName;
            }
            DisplayMenuPrompt("User Data Menu");
            sizes = roomSizes;
            names = roomNames;
        }

        /// <summary>
        /// ******************************************************
        /// 
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static int DisplayGetNumberOfRoomsData()
        {
            DisplayScreenHeader("Get Number of Rooms");
            int ret;
            ret = PromptUserForInt("Enter number of Rooms: ");

            DisplayMenuPrompt("User Data Menu");
            return ret;            
        }

        #endregion

        #region Theme
        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;
            string welcome = "Square Footage Evaluator";
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,28}", welcome));
            Console.WriteLine();
            Console.WriteLine(@"
                        | 
    ____________    __ -+-  ____________ 
    \_____     /   /_ \ |   \     _____/
     \_____    \____/  \____/    _____/
      \_____   FINCH CONTROL    _____/
         \___________  ___________/
                   /____\");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tThank you for using square footage evaluator");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("\t" + headerText);
            Console.WriteLine();
        }

        #endregion

        #region VALIDATION METHODS
        static int PromptUserForInt(string prompt)
        {
            int ret;
            Console.Write($"\t{prompt}");
            ret = IsValidInt();
            return ret;
        }

        /// <summary>
        /// ******************************************************
        ///         VALIDATES USER INPUT IS AN INTEGER
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
        ///         VALIDATES USER INPUT IS A DOUBLE
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
        ///         PROMPTS FOR INTEGER WITHIN A RANGE
        ///         VALIDATES USER INPUT
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static int ValidIntegerAndRange(string prompt, int min, int max)
        {
            Console.Write(prompt);
            int thresholdValue = IsValidInt();
            thresholdValue = isValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        /// <summary>
        /// ******************************************************
        ///         VALIDATES DOUBLE FALLS WITHIN A RANGE     
        /// ******************************************************
        /// 
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static double isValidThresholdAndRange(double thresholdValue, int min, int max)
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
        ///         VALIDATES INTEGER FALLS WITHIN A RANGE     
        /// ******************************************************
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>

        static int isValidThresholdAndRange(int thresholdValue, int min, int max)
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
        #endregion

        #region System I/0


        /// <summary>
        /// ******************************************************
        ///             LOGIN OR REGISTER MENU
        /// ******************************************************
        /// </summary>
        static void DisplayLoginRegister()
        {
            DisplayScreenHeader("Login/Register");

            Console.Write("\tAre you a registered user?  [Yes/No] ");
            string userResponse = Console.ReadLine().ToLower();
            if (userResponse == "yes" || userResponse == "y")
            {
                DisplayLogin();
            }
            else
            {
                DisplayRegisterUser();
                DisplayLogin();
            }
        }
        /// <summary>
        /// ******************************************************
        ///             REGISTER USER            
        /// ******************************************************
        /// </summary>
        static void DisplayRegisterUser()
        {
            string userName;
            string password;
            string encryptedPassword;
            int key;

            DisplayScreenHeader("Register");

            userName = GetUserName();
            Console.Write("\tEnter your password: ");
            password = Console.ReadLine();
            key = ValidIntegerAndRange("\tEnter a cipher value between 1 and 26: ", 1, 26);
            encryptedPassword = Encrypt(password, key);


            WriteLoginInfoData(userName, encryptedPassword);
            WriteUserNameInfoData(userName);

            Console.WriteLine();
            Console.WriteLine("\tYour login credentials are as followed: ");
            Console.WriteLine($"\tUser name: {userName}");
            Console.WriteLine($"\tPassword: {password}");
            Console.WriteLine($"\tYour key: {key}");
            Console.WriteLine($"\tEncrypted Password: {encryptedPassword}");

            DisplayContinuePrompt();
        }
        /// <summary>
        /// ******************************************************
        ///             WRITE LOGIN INFO DATA
        /// ******************************************************
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        static void WriteLoginInfoData(string userName, string password)
        {
            string dataPath = @"Data/Logins.txt";
            string loginInfoText = userName + "," + password + "\n";

            File.AppendAllText(dataPath, loginInfoText);
        }
        /// <summary>
        /// ******************************************************
        ///             DISPLAY LOGIN
        /// ******************************************************
        /// </summary>
        static void DisplayLogin()
        {
            string userName;
            string password;
            string encryptedPassword;
            int key;
            bool validLogin;


            do
            {
                DisplayScreenHeader("Login");

                Console.WriteLine();
                Console.Write("\tEnter your user name: ");
                userName = Console.ReadLine();
                Console.Write("\tEnter password: ");
                password = Console.ReadLine();
                Console.Write("\tEnter Key: ");
                key = IsValidInt();
                encryptedPassword = Encrypt(password, key);

                validLogin = isValidLoginInfo(userName, encryptedPassword);

                Console.WriteLine();
                if (validLogin)
                {
                    Console.WriteLine($"\tYou are now logged in {userName}");
                    DisplayContinuePrompt();
                }
                else
                {
                    DisplayContinuePrompt();
                }

            } while (!validLogin);
        }
        /// <summary>
        /// ******************************************************
        ///             VALIDATE LOGIN CREDENTIALS
        /// ******************************************************
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static bool isValidLoginInfo(string userName, string password)
        {
            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string password)>();
            bool validUser = false;

            registeredUserLoginInfo = ReadLoginInfoData();

            foreach ((string userName, string password) userLoginInfo in registeredUserLoginInfo)
            {
                if ((userLoginInfo.userName == userName) && (userLoginInfo.password == password))
                {
                    validUser = true;
                    break;
                }
            }
            if (!validUser)
            {
                Console.WriteLine("\tWrong login credentials");
            }
            return validUser;
        }

        /// <summary>
        /// ******************************************************
        ///             READ LOGIN INFO DATA
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static List<(string userName, string password)> ReadLoginInfoData()
        {
            string dataPath = @"Data/Logins.txt";


            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string password)>();

            loginInfoArray = File.ReadAllLines(dataPath);

            foreach (string loginInfoText in loginInfoArray)
            {
                loginInfoArray = loginInfoText.Split(',');

                loginInfoTuple.userName = loginInfoArray[0];
                loginInfoTuple.password = loginInfoArray[1];

                registeredUserLoginInfo.Add(loginInfoTuple);
            }

            return registeredUserLoginInfo;

        }
        /// <summary>
        /// ******************************************************
        ///             WRITE USER NAMES TO FILE
        /// ******************************************************
        /// </summary>
        /// <param name="userName"></param>
        static void WriteUserNameInfoData(string userName)
        {
            string dataPath = @"Data/UserNames.txt";
            string userNames = userName + "\n";

            File.AppendAllText(dataPath, userNames);
        }
        /// <summary>
        /// ******************************************************
        ///             GET USER NAME AND SEE IF IT'S TAKEN
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static string GetUserName()
        {
            bool validUserName;
            string userName;
            do
            {
                Console.Write("\tEnter user name: ");
                userName = Console.ReadLine();
                validUserName = isValidUserName(userName);

            } while (validUserName);

            return userName;
        }
        /// <summary>
        /// ******************************************************
        ///             CHECK IF USERNAME EXISTS ALREADY
        /// ******************************************************
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        static bool isValidUserName(string userName)
        {
            string dataPath = @"Data/UserNames.txt";
            bool validUserName = File.ReadLines(dataPath).Contains(userName);
            if (validUserName)
            {
                Console.WriteLine($"\tUser name already taken.");
            }
            return validUserName;
        }
        /// <summary>
        /// ******************************************************
        ///             DISPLAY USERNAMES AND ENCRYPTED PASSWORDS
        /// ******************************************************
        /// </summary>
        static void TableofUserNames()
        {
            string dataPath = @"Data\Logins.txt";

            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            loginInfoArray = File.ReadAllLines(dataPath);

            Console.WriteLine(string.Format($"\t{"User Name",10} \t {"Password",20}"));
            Console.WriteLine();
            foreach (string loginInfoText in loginInfoArray)
            {
                loginInfoArray = loginInfoText.Split(',');

                Console.WriteLine(string.Format($"\t{ loginInfoTuple.userName = loginInfoArray[0],10} \t {loginInfoTuple.password = loginInfoArray[1],20}"));

            }

        }
        /// <summary>
        /// ******************************************************
        ///             Display Credentials
        /// ******************************************************
        /// </summary>
        static void DisplayCredentials()
        {
            DisplayScreenHeader("User Names and Passwords");
            TableofUserNames();
            DisplayMenuPrompt("Main Menu");
        }
        #endregion

        #region Cipher
        /// <summary>
        /// ******************************************************
        ///             CHIPHER METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static char CaesarCipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
        /// <summary>
        /// ******************************************************
        ///             ENCRYPTION
        /// ******************************************************
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>

        public static string Encrypt(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += CaesarCipher(ch, key);

            return output;
        }
        /// <summary>
        /// ******************************************************
        ///             DECRYPTION
        /// ******************************************************
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string input, int key)
        {
            return Encrypt(input, 26 - key);
        }

        #endregion
    }
}
