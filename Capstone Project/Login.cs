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
}
