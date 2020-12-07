using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone_Project
{
    class Home
    {
        #region HOME MENU
        /// <summary>
        /// *****************************************************************
        /// *                      HOME DATA MENU                           *
        /// *****************************************************************
        /// *        A: Instructions                                        *
        /// *        B: Number of Rooms                                     *
        /// *        C: Home Name and Room Data                             *
        /// *        D: Show Data                                           *
        /// *                                                               *
        /// *****************************************************************
        /// </summary>
        public static void DisplayRoomMenuScreen(string userName)
        {
            Console.CursorVisible = true;

            //
            // Initialize variables
            //
            int numberOfRooms = 0;
            double[] roomSizes = null;
            string[] roomNames = null;

            bool quitMenu = false;
            string menuChoice;
            string homeName = "Home";

            do
            {
                //
                // Display Header
                //
                Theme.DisplayScreenHeader($"{userName}'s {homeName} Data Menu");

                //
                // Get user menu choice
                //
                Theme.ColorMenu("A: ", "Instructions");
                Theme.ColorMenu("B: ", "Number of Rooms");
                Theme.ColorMenu("C: ", "Home Name and Room Data");
                Theme.ColorMenu("D: ", $"Show {userName}'s Data");
                Theme.ColorMenu("Q: ", "Quit\n\n");
                menuChoice = Theme.MenuChoice("Enter Choice: ").ToLower();

                //
                // Process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayInstructions(userName, homeName);

                        break;
                    case "b":
                        numberOfRooms = DisplayGetNumberOfRoomsData(userName, homeName);
                        break;

                    case "c":
                        DisplayGetRoomNameAndSizeData(numberOfRooms, out roomSizes, 
                                                      out roomNames, userName, out homeName);
                        break;

                    case "d":
                        DisplayRoomSizeNameData(roomSizes, roomNames, homeName, userName);
                        break;

                    case "q":

                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Theme.ColorPrint("Please enter a letter for the menu choice.", ConsoleColor.Red);
                        Console.Beep(200, 500);
                        Theme.DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }
        #endregion

        #region MENU OPTIONS
        /// <summary>
        /// ******************************************************
        ///             A. DISPLAY INSTRUCTIONS
        /// ******************************************************
        /// </summary>
        static void DisplayInstructions(string userName, string homeName)
        {
            //
            // Display Header
            //
            Theme.DisplayScreenHeader("Instructions");

            //
            // Display Instructions
            //
            Theme.Print("In this application you will:");
            Console.WriteLine();
            Theme.ColorMenu("1. ", "Enter number of rooms in your home");
            Theme.ColorMenu("2. ", "Enter the name of your home");
            Theme.ColorMenu("3. ", "Enter room type from list below: ");
            Theme.ColorPrint("\n\t\tMaster Bedroom" +
                            "\n\t\tBedroom" +
                            "\n\t\tLiving Room" +
                            "\n\t\tHallway" +
                            "\n\t\tKitchen" +
                            "\n\t\tBathroom" +
                            "\n\t\tStudy" +
                            "\n\t\tOffice\n", 
                            ConsoleColor.White);
            Theme.ColorMenu("4. ", "Enter room length");
            Theme.ColorMenu("5. ", "Enter room width");

            Console.WriteLine(
);

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt($"{userName}'s {homeName} Data Menu");
        }
        /// <summary>
        /// ******************************************************
        ///             B: GET NUMBER OF ROOMS
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static int DisplayGetNumberOfRoomsData(string userName,
                                               string homeName)
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
            Theme.PrintColorData($"\n\tNumber of Rooms: ", $"{ret}");

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt($"{userName}'s {homeName} Data Menu");

            //
            // Return number of rooms
            //
            return ret;
        }

        /// <summary>
        /// ******************************************************
        ///             C: GET ROOM NAMES AND SIZE DATA
        /// ******************************************************
        /// </summary>
        /// <param name="numberOfRooms"></param>
        /// <param name="sizes"></param>
        /// <param name="names"></param>
        static void DisplayGetRoomNameAndSizeData(int numberOfRooms,
                                                  out double[] sizes,
                                                  out string[] names,
                                                  string userName,
                                                  out string homeName)
        {
            //
            // Initialize variables
            //

            double[] roomSizes = new double[numberOfRooms];
            string[] roomNames = new string[numberOfRooms];
            string roomAndSizes;
            string strRmSize;
            string userNameAndHomeEntry;
            double length, width, roomSize, sum;
            string roomName;
            string dataPath = @"Data/UserHomes.txt";



            //
            // Display Header
            //
            Theme.DisplayScreenHeader($"Get {userName}'s Home Name and Data");

            Console.WriteLine();

            if (numberOfRooms == 0)
            {
                Theme.ColorPrint("Please enter number of rooms first", ConsoleColor.Red);
                Console.Beep(200, 500);
                sizes = null;
                names = null;
                homeName = "Home";
            }
            else
            {

                //
                // Get home name from user
                //
                homeName = Theme.ReadWrite("Enter home name: ");
                userNameAndHomeEntry = userName + "'s " + homeName + ": ";

                //
                // Save users name and home name to file
                //
                File.AppendAllText(dataPath, userNameAndHomeEntry);


                //
                // Display Number of Rooms
                //
                Console.WriteLine();
                Console.WriteLine();
                Theme.PrintColorData($"Number of Rooms: ", $"{numberOfRooms}");
                Console.WriteLine();


                //
                // Display Room Types
                //
                Theme.Print("Types of Rooms:\n");
                Theme.ColorPrint("****************************************************\n" +
                                 "\t* Master Bedroom * Bedroom * Living Room * Hallway *\n" +
                                 "\t*     * Kitchen * Bathroom * Study * Office *      *\n" +
                                 "\t****************************************************\n",
                                 ConsoleColor.Cyan);

                //
                // Get information from user
                //

                for (int i = 0; i < numberOfRooms; i++)
                {
                    Console.Write("\tEnter Room Name: ");
                    roomName = Validate.ReadString();

                    Console.WriteLine();
                    length = Validate.ReadDouble($"Enter length of {roomName}: ");
                    width = Validate.ReadDouble($"Enter width of {roomName}: ");
                    Console.WriteLine();
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
                        roomAndSizes = roomName + ": " + strRmSize + "sq ft, ";
                        File.AppendAllText(dataPath, roomAndSizes);
                    }

                    //
                    // If last room
                    //
                    if (i == numberOfRooms - 1)
                    {
                        sum = roomSizes.Sum();
                        roomAndSizes = roomName + ": " + strRmSize + "sq ft, Total Square Footage: " + sum + "\n";
                        File.AppendAllText(dataPath, roomAndSizes);
                    }
                }

                sizes = roomSizes;
                names = roomNames;
            }
                //
                // Menu Prompt
                //
                Theme.DisplayMenuPrompt($"{userName}'s {homeName} Data Menu");
            
        }


        /// <summary>
        /// ******************************************************
        ///             D: DISPLAY ROOM NAMES AND SIZE
        /// ******************************************************
        /// </summary>
        /// <param name="roomSizes"></param>
        /// <param name="roomNames"></param>
        static void DisplayRoomSizeNameData(double[] roomSizes,
                                            string[] roomNames,
                                            string homeName,
                                            string userName)
        {
            //
            // Display Header
            //
            Theme.DisplayScreenHeader($"\t{userName}'s {homeName} Data");

            //
            // Display Info In Table
            //
            
            Theme.ColorPrint(string.Format($"{"Room Name",12}    {"Square Footage",12}\n"), ConsoleColor.Yellow);

            if (roomSizes != null)
            {
                for (int i = 0; i < roomSizes.Length; i++)
                {
                    string room = roomSizes[i].ToString("n2");
                    string roomName = roomNames[i];

                    Theme.ColorTable(string.Format($"{roomName,17}"), string.Format($"{room,17}\n"));
                }
            }
            else
            {
                Theme.ColorPrint("No data has been entered.", ConsoleColor.Red);
                Console.Beep(200, 500);
            }
            Console.WriteLine("\n");

            //
            // Display Total Square Footage
            //
            DisplayTotalSqFtData(roomSizes);

            //
            // Menu Prompt
            //
            Theme.DisplayMenuPrompt($"{userName}'s Data Menu");
        }       
        #endregion

        #region PRINTING METHODS

        /// <summary>
        /// ******************************************************
        ///             DISPLAY TOTAL SQ FT DATA 
        /// ******************************************************
        /// </summary>
        /// <param name="roomsizes"></param>
        static void DisplayTotalSqFtData(double[] roomSizes)
        {
            if (roomSizes != null)
            {
                double sum = roomSizes.Sum();
                string stringSum = sum.ToString("n2");

                Theme.ColorTable(string.Format($"{"Total Sq Ft:",17}"), string.Format($"{stringSum,17}\n"));
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        #endregion
    }
}
