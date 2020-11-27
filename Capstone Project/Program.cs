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
    // Last Modified: 11/27/2020
    //
    // **************************************************
    class Program
    {

        static void Main(string[] args)
        {
            string userName;

            Theme.SetTheme();

            Theme.DisplayWelcomeScreen();
            userName = Login.DisplayLoginMenuScreen();
            Menu.DisplayMenuScreen(userName);
            Theme.DisplayClosingScreen();
        }
 
    class Menu
        {
            /// <summary>
            /// *****************************************************************
            /// *                     Main Menu                                 *
            /// *****************************************************************
            /// </summary>
            public static void DisplayMenuScreen(string userName)
            {
                Console.CursorVisible = true;

                //
                // Initialize variables
                //
                bool quitMenu = false;
                string menuChoice;

                do
                {
                    //
                    // Display Header
                    //
                    Theme.DisplayScreenHeader("Main Menu");

                    //
                    // Get user menu choice
                    //
                    Console.WriteLine("\tA: Application Information");
                    Console.WriteLine("\tB: Home Data Menu");
                    Console.WriteLine("\tC: Returning User Data");
                    Console.WriteLine("\tD: Stored Users and Passwords");
                    Console.WriteLine("\tQ: Quit");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("\tEnter Choice: ");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // Process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            DisplayApplicationInformation();
                            break;

                        case "b":
                            Home.DisplayRoomMenuScreen(userName);
                            break;

                        case "c":
                            DisplayReturningUserInformation(userName);
                            break;

                        case "d":
                            Login.DisplayCredentials();
                            break;

                        case "q":

                            quitMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            Theme.DisplayContinuePrompt();
                            break;
                    }

                } while (!quitMenu);
            }
            /// <summary>
            /// *****************************************************************
            ///             Display Returning User Information
            /// *****************************************************************
            /// </summary>
            /// <param name="userName"></param>
            static void DisplayReturningUserInformation(string userName)
            {
                //
                // Initialize Variables
                //
                string dataPath = @"Data/UserHomes.txt";
                string[] loginInfoArray;

                //
                // Read Data from file
                //
                loginInfoArray = File.ReadAllLines(dataPath);

                //
                // Display Header
                //
                Theme.DisplayScreenHeader($"{userName}'s Home Data");

                foreach (string loginInfoText in loginInfoArray)
                {
                    if (loginInfoText.Contains(userName))
                    {
                        Console.WriteLine($"\t{loginInfoText}");
                    }
                }

                //
                // Menu Prompt
                //
                Theme.DisplayMenuPrompt("Main Menu");
            }

            /// <summary>
            /// *****************************************************************
            ///         Display Application Information
            /// *****************************************************************
            /// </summary>
            static void DisplayApplicationInformation()
            {
                Theme.DisplayScreenHeader("Application Information");
                Console.WriteLine("Module Under Construction");
                Theme.DisplayMenuPrompt("Main Menu");
            }

        }
    }
    class Home
    {
        #region ROOM DATA MENU
        /// <summary>
        /// *****************************************************************
        /// *                      HOME DATA MENU                           *
        /// *****************************************************************
        /// </summary>
        public static void DisplayRoomMenuScreen(string userName)
        {
            Console.CursorVisible = true;

            //
            // Initialize variables
            //
            int numberOfRooms = 0;
            int[] roomSizes = null;
            string[] roomNames = null;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                //
                // Display Header
                //
                Theme.DisplayScreenHeader($"{userName} Home Data Menu");

                //
                // Get user menu choice
                //
                Console.WriteLine("\tA: Instructions");
                Console.WriteLine("\tB: Number of Rooms");
                Console.WriteLine("\tC: Room Data");
                Console.WriteLine("\tD: Show Data");
                Console.WriteLine("\tQ: Quit\n\n");
                Console.Write("\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // Process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayInstructions();

                        break;
                    case "b":
                        numberOfRooms = DisplayGetNumberOfRoomsData();
                        break;

                    case "c":
                        DisplayGetRoomNameAndSizeData(numberOfRooms, out roomSizes, out roomNames, userName);
                        break;

                    case "d":
                        DisplayRoomSizeNameData(roomSizes, roomNames);
                        break;

                    case "q":

                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        Theme.DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }
        /// <summary>
        /// ******************************************************
        ///             DISPLAY INSTRUCTIONS
        /// ******************************************************
        /// </summary>
        static void DisplayInstructions()
        {
            //
            // Display Header
            //
            Theme.DisplayScreenHeader("Instructions");

            //
            // Display Instructions
            //
            Console.WriteLine("\tIn this application you will:\n" +
                "\n\t1. Enter number of rooms in your home" +
                "\n\t2. Enter room type from list below: " +
                "\n\t\tMaster Bedroom" +
                "\n\t\tBedroom" +
                "\n\t\tLiving Room" +
                "\n\t\tHallway" +
                "\n\t\tKitchen" +
                "\n\t\tBathroom" +
                "\n\t\tStudy" +
                "\n\t\tOffice" +
                "\n\t3. Enter room length" +
                "\n\t4. Enter room width" +
                "\n");

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt("User Data Menu");
        }

        /// <summary>
        /// ******************************************************
        ///             DISPLAY TOTAL SQ FT DATA 
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
        ///             DISPLAY ROOM NAMES AND SIZE
        /// ******************************************************
        /// </summary>
        /// <param name="roomSizes"></param>
        /// <param name="roomNames"></param>
        static void DisplayRoomSizeNameData(int[] roomSizes, string[] roomNames)
        {
            //
            // Display Header
            //
            Theme.DisplayScreenHeader("\t\tRoom Size Data");

            //
            // Display Info In Table
            //
            Console.WriteLine(string.Format($"{"Room Name",17}    {"Square Footage",17}\n"));

            for (int i = 0; i < roomSizes.Length; i++)
            {
                string room = roomSizes[i].ToString("n2");
                string roomName = roomNames[i];
                Console.WriteLine(string.Format($"{roomName,17}{room,17}"));
            }

            Console.WriteLine("\n");

            //
            // Display Total Square Footage
            //
            DisplayTotalSqFtData(roomSizes);

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt("User Data Menu");

        }
        /// <summary>
        /// ******************************************************
        ///             GET ROOM NAMES AND SIZE DATA
        /// ******************************************************
        /// </summary>
        /// <param name="numberOfRooms"></param>
        /// <param name="sizes"></param>
        /// <param name="names"></param>
        static void DisplayGetRoomNameAndSizeData(int numberOfRooms, out int[] sizes, out string[] names, string userName)
        {
            //
            // Initialize variables
            //
            int[] roomSizes = new int[numberOfRooms];
            string[] roomNames = new string[numberOfRooms];
            string roomAndSizes;
            string strRmSize;
            int length, width, roomSize, sum;
            string roomName;
            string dataPath = @"Data/UserHomes.txt";

            //
            // Start Entry in text file with userName
            //
            string userNameEntry = userName + ": ";
            File.AppendAllText(dataPath, userNameEntry);

            //
            // Display Header
            //
            Theme.DisplayScreenHeader("Get Room Size Data");

            //
            // Display Number of Rooms
            //
            Console.WriteLine($"\n\tNumber of Rooms: {numberOfRooms}\n");

            //
            // Display Room Types
            //
            Console.WriteLine("\tTypes of Rooms:\n");
            Console.WriteLine("\t****************************************************\n" +
                              "\t* Master Bedroom * Bedroom * Living Room * Hallway *\n" +
                              "\t*     * Kitchen * Bathroom * Study * Office *      *\n" +
                              "\t****************************************************\n");

            //
            // Get information from user
            //
            for (int i = 0; i < numberOfRooms; i++)
            {
                Console.Write("\tEnter Room Name: ");
                roomName = Validate.ReadString();

                length = Validate.ReadInteger($"Enter length of {roomName}: ");
                width = Validate.ReadInteger($"Enter width of {roomName}: ");

                roomSize = length * width;

                strRmSize = roomSize.ToString();

                //
                // Send information to arrays
                //
                roomSizes[i] = roomSize;
                roomNames[i] = roomName;

                // ***********************
                // Write user info to file
                // ***********************

                //
                // If not the last item
                //
                if (i < numberOfRooms - 1)
                {
                    roomAndSizes = roomName + ": " + strRmSize + ", ";
                    File.AppendAllText(dataPath, roomAndSizes);
                }

                //
                // If last room
                //
                if (i == numberOfRooms - 1)
                {
                    sum = roomSizes.Sum();
                    roomAndSizes = roomName + ": " + strRmSize + ", Total Square Footage: " + sum + "\n";
                    File.AppendAllText(dataPath, roomAndSizes);
                }
            }

            sizes = roomSizes;
            names = roomNames;

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt("User Data Menu");

        }
        /// <summary>
        /// ******************************************************
        ///             GET NUMBER OF ROOMS
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static int DisplayGetNumberOfRoomsData()
        {
            //
            // Initialize variables
            //
            int ret;

            //
            // Display Header
            //
            Theme.DisplayScreenHeader("Get Number of Rooms");

            //
            // Prompt user for number of Rooms
            //
            ret = Validate.ReadInteger("Enter number of Rooms: ");

            //
            // Echo input back to user
            //
            Console.WriteLine($"\n\tNumber of Rooms: {ret}");

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt("User Data Menu");

            //
            // Return number of rooms
            //
            return ret;
        }

        #endregion
    }
    class Login
    {
        
        /// <summary>
        /// *****************************************************************
        /// *                      LOGIN MENU                               *
        /// *****************************************************************
        /// </summary>
        /// <returns></returns>
        public static string DisplayLoginMenuScreen()
        {
            Console.CursorVisible = true;

            //
            // Initialize Variables
            //
            bool quitMenu = false;
            string menuChoice;
            string userName = "";

            do
            {
                Theme.DisplayScreenHeader("Login Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\tL: Log in");
                Console.WriteLine("\tA: Register");
                Console.WriteLine("\tB: Recover Password");
                Console.Write("\n\n\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "l":
                        userName = DisplayLogin();
                        quitMenu = true;
                        break;

                    case "a":
                        DisplayRegisterUser();
                        break;

                    case "b":
                        RecoverPassword();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        Theme.DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

            //
            // Return username for use in persistence
            //
            return userName;
        }
        /// <summary>
        /// ******************************************************
        ///             REGISTER USER            
        /// ******************************************************
        /// </summary>
        static void DisplayRegisterUser()
        {
            //
            // Initialize variables
            //
            string userName;
            string password;
            string encryptedPassword;
            int key;

            //
            // Display Header
            //
            Theme.DisplayScreenHeader("Register");

            //
            // Get username
            //
            userName = GetUserName();

            //
            // Get Password
            //
            Console.Write("\tEnter your password: ");
            password = Console.ReadLine();

            //
            // Get Cipher Key
            //
            key = Validate.ReadInteger("Enter a cipher value between 1 and 26: ", 1, 26);
            encryptedPassword = Cipher.Encrypt(password, key);

            //
            // Write login Data to file
            //
            WriteLoginInfoData(userName, encryptedPassword);

            //
            // Write User Name to file
            //
            WriteUserNameInfoData(userName);

            //
            // Echo back login credentials
            //
            Console.WriteLine();
            Console.WriteLine("\tYour login credentials are as followed: ");
            Console.WriteLine($"\tUser name: {userName}");
            Console.WriteLine($"\tPassword: {password}");
            Console.WriteLine($"\tYour key: {key}");
            Console.WriteLine($"\tEncrypted Password: {encryptedPassword}");
            Console.WriteLine("\tBe sure to remember your key, you won't be able to recover or reset it!");

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt("Login Menu");
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
        static string DisplayLogin()
        {
            //
            // Initialize Variables
            //
            string userName;
            string password;
            string encryptedPassword;
            int key;
            bool validLogin;


            do
            {
                //
                // Display Header
                //
                Theme.DisplayScreenHeader("Login");

                Console.WriteLine();

                //
                // Prompt for username
                //
                Console.Write("\tEnter your username: ");
                userName = Console.ReadLine();

                //
                // Prompt for password
                //
                Console.Write("\tEnter password: ");
                password = Console.ReadLine();

                //
                // Prompt for key
                //                
                key = Validate.ReadInteger("Enter Key: ");

                //
                // Encrypt Password
                //
                encryptedPassword = Cipher.Encrypt(password, key);

                //
                // Validate login info
                //
                validLogin = isValidLoginInfo(userName, encryptedPassword);


                Console.WriteLine();
                if (validLogin)
                {
                    Console.WriteLine($"\tYou are now logged in {userName}");
                    Theme.DisplayContinuePrompt();
                }
                else
                {
                    Theme.DisplayContinuePrompt();
                }

            } while (!validLogin);

            //
            // Return userName for later use
            //
            return userName;
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
            //
            // Initialize Variables
            //
            string dataPath = @"Data/Logins.txt";
            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;
            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string password)>();

            //
            // Read Text File
            //
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
            //
            // Initialize variables
            //
            string dataPath = @"Data\Logins.txt";
            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            //
            // Read File
            //
            loginInfoArray = File.ReadAllLines(dataPath);

            //
            // Display Data in a Table
            //
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
        ///             RECOVER PASSWORD
        /// ******************************************************
        /// </summary>
        static void RecoverPassword()
        {
            //
            // Initialize variables
            //
            int key;
            string userName;
            string encryptedPassword;
            string password;
            string dataPath = @"Data\Logins.txt";
            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            //
            // Display Header
            //
            Theme.DisplayScreenHeader("Password Recovery");

            //
            // Prompt user for username
            //
            Console.Write("\tEnter username: ");
            userName = Console.ReadLine();

            //
            // Prompt user for key
            //
            key = Validate.ReadInteger("Enter Key: ");

            //
            // Read File to retriave password
            //
            loginInfoArray = File.ReadAllLines(dataPath);
            foreach (string loginInfoText in loginInfoArray)
            {
                if (loginInfoText.Contains(userName))
                {
                    loginInfoArray = loginInfoText.Split(',');

                    loginInfoTuple.userName = loginInfoArray[0];
                    loginInfoTuple.password = loginInfoArray[1];
                    encryptedPassword = loginInfoArray[1];

                    //
                    // Echo back encrypted password
                    //
                    Console.WriteLine($"\tEncrypted Password: {encryptedPassword}");

                    //
                    // Echo back decrypted Password
                    //
                    password = Cipher.Decrypt(encryptedPassword, key);
                    Console.WriteLine($"\tPassword: {password}");
                }
            }

            //
            // Menu prompt
            //
            Theme.DisplayMenuPrompt("Login Menu");
        }
        /// <summary>
        /// ******************************************************
        ///             Display Credentials
        /// ******************************************************
        /// </summary>
        public static void DisplayCredentials()
        {
            Theme.DisplayScreenHeader("User Names and Passwords");
            TableofUserNames();
            Theme.DisplayMenuPrompt("Main Menu");
        }

    }
    class Validate
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
    class Theme
    {
        /// <summary>
        /// setup the console theme
        /// </summary>
        public static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        public static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\tThe Essential Home Application");
            Console.WriteLine();
            Console.WriteLine(@"
                                       /\
                                  /\  //\\
                           /\    //\\///\\\        /\
                          //\\  ///\////\\\\  /\  //\\
             /\          /  ^ \/^ ^/^  ^  ^ \/^ \/  ^ \
            / ^\    /\  / ^   /  ^/ ^ ^ ^   ^\ ^/  ^^  \
           /^   \  / ^\/ ^ ^   ^ / ^  ^    ^  \/ ^   ^  \       *
          /  ^ ^ \/^  ^\ ^ ^ ^   ^  ^   ^   ____  ^   ^  \     /|\
         / ^ ^  ^ \ ^  _\___________________|  |_____^ ^  \   /||o\
        / ^^  ^ ^ ^\  /______________________________\ ^ ^ \ /|o|||\
       /  ^  ^^ ^ ^  /________________________________\  ^  /|||||o|\
      /^ ^  ^ ^^  ^    ||___|___||||||||||||___|__|||      /||o||||||\
     / ^   ^   ^    ^  ||___|___||||||||||||___|__|||          | |
    / ^ ^ ^  ^  ^  ^   ||||||||||||||||||||||||||||||oooooooooo| |ooooooo
    ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");

            Console.WriteLine();
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        public static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tI hope you enjoyed using my application");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        public static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        public static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        public static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("\t" + headerText);
            Console.WriteLine();
        }



    }
    class Cipher
    {
        /// <summary>
        /// ******************************************************
        ///             CHIPHER METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static char CaesarCipher(char ch, int key)
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

    }
}
