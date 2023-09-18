using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using System.Collections;

namespace Car_Park_App
{
    internal class Program
    {
        static void Reset() //This is just a class to make the rest of the code a little more clear
        {
            Console.Clear();
            Console.WriteLine("####################################################\n\n  W E L C O M E   T O   B O B ' S   C A R   P A R K\n\n####################################################");
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black; // It is inefficient to add this to Reset
            Reset();

            Thread.Sleep(1000); //Pausescode execution for 1000 milliseconds
            while (true) // Simple Validation
            {
                Console.WriteLine("\nPlease enter the car registration: ");
                string reg_plate = Console.ReadLine().ToUpper();
                Console.WriteLine("Registration entered: " +reg_plate+" \n\nIs this correct? (y/n)");
                try
                {
                    char reg_plate_confimation = char.Parse(Console.ReadLine());
                    if (reg_plate_confimation == 'y')
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
                catch
                {
                    Console.WriteLine("\nInvalid data entered.");
                    Thread.Sleep(1000);
                }
            }
            Reset(); //Clears screen ready for the parking options

            Dictionary<int, int> dictionary = new Dictionary<int, int>(); //This upcoming section is making the dictionary from the menu.txt, so that any modifications made in the "management mode" will be saved for when the program loads up again.

            string[] lines = File.ReadAllLines(@"C:\Users\College\Documents\LSComputing\Car Park\Car Park App\Car Park App\Car Park App\menu.txt");
            List<string> timing = new List<string>();
            int count1 = 0;

            foreach (string line in lines) 
            {
                count1++;
                string[] parts = line.Split('=');
                timing.Add(parts[0]);
                dictionary.Add(count1, int.Parse(parts[1]));
                Console.WriteLine("{0}      {1}       £{2}", count1, parts[0], parts[1]);
            }

            Console.WriteLine("\nPlease select duration:       (Press number 1-" + dictionary.Count + ")\n");

            while (true)
            {
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice < 1 || choice > dictionary.Count)
                    {
                        Console.WriteLine("Invalid entry, please enter a valid option (1-" + dictionary.Count + ")");
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid entry, please enter a valid option (1-" + dictionary.Count + ")");
                }
            }

            
        }
    }
}
