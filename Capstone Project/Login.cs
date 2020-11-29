using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone_Project
{
    class Login
    {
        /// <summary>
        /// *****************************************************************
        /// *                      LOGIN MENU                               *
        /// *****************************************************************
        /// </summary>
        /// <returns></returns>
        public static void DisplayLoginMenuScreen()
        {
            Console.CursorVisible = true;

            //
            // Initialize Variables
            //
            bool quitMenu = false;
            string menuChoice;

            do
            {
                Theme.DisplayScreenHeader("Login Menu");

                //
                // get user menu choice
                //
                Theme.ColorMenu("L: ", "Log in");
                Theme.ColorMenu("A: ", "Register");
                Theme.ColorMenu("B: ", "Recover Password");
                
                menuChoice = Theme.MenuChoice("\n\n\tEnter Choice: ").ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "l":
                        DisplayLogin();
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
                        Theme.ColorPrint("Please enter a letter for the menu choice.", ConsoleColor.Red);
                        Theme.DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

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
            password = Theme.ReadWrite("Enter your password: ");
            
            //
            // Get Cipher Key
            //
            key = Validate.ReadInteger("Enter a cipher value between 1 and 26: ",  1, 26);
            
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
            Theme.Print("Your login credentials are as followed: ");
            Theme.PrintColorData("Username: ", userName);
            Theme.PrintColorData("User name: ", userName);
            Theme.PrintColorData("Password: ", password);
            Theme.PrintColorData("Your key: ", $"{key}");
            Theme.PrintColorData("Encrypted Password:", encryptedPassword);
            Console.WriteLine();
            Theme.ColorPrint("Be sure to remember your key, you won't be able to recover or reset it!", ConsoleColor.Red);

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
        static void DisplayLogin()
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
                userName = Theme.ReadWrite("Enter your username: ");

                //
                // Prompt for password
                //
                password = Theme.ReadWrite("Enter password: ");
                
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
                    Theme.Print($"You are now logged in {userName}");
                    
                    Theme.DisplayContinuePrompt();
                    Menu.DisplayMenuScreen(userName);
                }
                else
                {
                    Theme.DisplayMenuPrompt("Login Menu");
                    DisplayLoginMenuScreen();
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
                Console.WriteLine();
                Theme.ColorPrint("Wrong login credentials", ConsoleColor.Red);
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
                userName = Theme.ReadWrite("Enter user name: ");
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
                Theme.ColorPrint($"User name already taken.", ConsoleColor.Red);
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
            userName = Theme.ReadWrite("Enter username: ");
            
            //
            // Prompt user for key
            //
            key = Validate.ReadInteger("Enter Key: ", 1, 26);

            //
            // Read File to retriave password
            //
            loginInfoArray = File.ReadAllLines(dataPath);
            foreach (string loginInfoText in loginInfoArray)
            {
                if (loginInfoText.Contains(userName + ","))
                {
                    loginInfoArray = loginInfoText.Split(',');

                    loginInfoTuple.userName = loginInfoArray[0];
                    loginInfoTuple.password = loginInfoArray[1];
                    encryptedPassword = loginInfoArray[1];

                    //
                    // Echo back encrypted password
                    //
                    Theme.Print($"Encrypted Password: {encryptedPassword}");

                    //
                    // Echo back decrypted Password
                    //
                    password = Cipher.Decrypt(encryptedPassword, key);
                    Theme.Print($"Password: {password}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Theme.ColorPrint("If your password looks incorrect you provided the " +
                        "wrong key, come back and try again!", ConsoleColor.Red);
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
}
