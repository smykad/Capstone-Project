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
            int roomSize, sum;
            string roomName = "";
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

                Validate length = new Validate($"Enter length of {roomName}: ", "integer");
                Validate width = new Validate($"Enter width of {roomName}: ", "integer");
;
                roomSize = length.Integer * width.Integer;

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
            Validate rooms = new Validate("Enter number of Rooms: ", "integer");
            ret = rooms.Integer;

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
    }
}
