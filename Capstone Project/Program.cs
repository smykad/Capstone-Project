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
    // Last Modified: 12/4/2020
    //
    // **************************************************
    class Program
    {
        static void Main(string[] args)
        {
            Theme.SetTheme();
            Theme.DisplayWelcomeScreen();
            Login.DisplayLoginMenuScreen();
            Theme.DisplayClosingScreen();
        }
    }
}
