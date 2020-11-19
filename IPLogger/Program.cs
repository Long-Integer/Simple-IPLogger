using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IPLogger"; //Title of the Console

            Console.Write("Command: ");
            var command = Console.ReadLine(); //Sets the user imput to string "command"
            Checkcommand(command); //Check the command
            Console.ReadKey();
        }

        private static async void Checkcommand(string command)
        {
            if (command == "reload") // Checks if the command is reload
            {
                ReloadIPs(); // Reloads the ips if the command is correct
            }
            else // exits the console bc command is invailid
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invaild Command: " + command);
                Console.Write("Please wait Exiting Environment...");
                await Task.Delay(2500);
                Environment.Exit(0);
            }
        }

        private static void ReloadIPs()
        {
            Console.Clear();
            Console.WriteLine("Reloading...");
            Console.WriteLine("");
            System.Net.WebClient wc = new System.Net.WebClient(); // Creates a webclient to use
            byte[] raw = wc.DownloadData("https://serenityprotector.000webhostapp.com/data.txt"); // MAKE SURE TO CHANGE THE WEBSITE TO YOURS WITH THE RAW IP INFO
            string webData = System.Text.Encoding.UTF8.GetString(raw); // gets and puts all the raw ip info into a string
            Console.WriteLine(webData); // pring the ip info from the string above
            Console.WriteLine("");
            Console.WriteLine("Reload Complete!");
            Console.ReadKey();
        }

    }
}
