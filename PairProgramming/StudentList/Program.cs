using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<string> studentNames = new List<string>();

            // Console.WriteLine("Please enter student name");
            // string userInput = Console.ReadLine();

            // do
            // {
            //     studentNames.Add(userInput);
            //     Console.WriteLine("Please enter student name");
            //     userInput = Console.ReadLine();

            // } while (!string.IsNullOrEmpty(userInput));

            // string[] studentPair = new string[2];
            //Dictionary<string, string> studentPairs = new Dictionary<string, string>();

            // if (studentNames.Count % 2 == 1)
            // {

            //     studentPairs.Add(string.Empty, studentNames[0]);
            //     studentNames.Remove(studentNames[0]);
            // }

            // int count = studentNames.Count / 2;

            // for (int i = 0; i < count; i++)
            // {
            //     Random rand = new Random();

            //     studentPair[0] = studentNames[rand.Next(studentNames.Count)];
            //     studentNames.Remove(studentPair[0]);
            //     studentPair[1] = studentNames[rand.Next(studentNames.Count)];
            //     studentNames.Remove(studentPair[1]);
            //     studentPairs.Add(studentPair[0], studentPair[1]);
            // }

            // foreach (var pair in studentPairs)
            // {
            //     Console.WriteLine(pair);
            // }

            bool end = false;
            double cashBalance = 5000;

            double bitCoinBalance =0;
            double etheriumBalance = 0;
            double litecoinBalance = 0;
           
            double bitcoin = 7480;
            double etherium = 586.15;
            double litecoin = 119.04;

            do
            {
                Console.WriteLine("Choose an action");
                Console.WriteLine("\n-[1] Buy Crypto" +
                    "\n-[2] Sell Crypto for Cash" +
                    "\n-[3] View Account Balance" +
                    "\n-[4] Trade Crypto");

                ConsoleKey userChoice = Console.ReadKey(true).Key;
               

                switch (userChoice)
                {

                   

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("\n-[B] Bitcoin" +
                            "\n-[E] Etherium" +
                            "\n-[L] Litecoin");
                        string cryptoChoice = Console.ReadLine().ToLower();
                        if (cryptoChoice == "b"  )
                        {
                           

                            Console.Write("How much bitcoin would you like to purchase? ");
                            int bitChoice = Convert.ToInt32(Console.ReadLine());
                            cashBalance -= bitChoice * bitcoin;
                            bitCoinBalance = bitChoice * bitcoin;
               
                        }
                        if (cryptoChoice == "e")
                        {
                            Console.Write("How much Etherium would you like to purchase? ");
                            int ethChoice = Convert.ToInt32(Console.ReadLine());
                            cashBalance -= ethChoice * etherium;
                            etheriumBalance = ethChoice * etherium;


                        }

                        if (cryptoChoice == "l")
                        {
                            Console.Write("How much Litecoin would you like to purchase? ");
                            int liteChoice = Convert.ToInt32(Console.ReadLine());
                            cashBalance -= liteChoice * litecoin;
                            litecoinBalance = liteChoice * litecoin;

                        }
                        else
                        {
                            Console.WriteLine("Enter a valid decision");
                        }

                        break;

                    //case ConsoleKey.D2:
                    //case ConsoleKey.NumPad2:
                    //    string cryptoSell = Console.ReadLine().ToLower();
                    //    if (cryptoSell == "b")
                    //    {
                    //        int sellChoice = Convert.ToInt32(Console.ReadLine());

                    //        cashBalance += sellChoice * bitcoin;
                    //        bitCoinBalance = sellChoice - bitCoinBalance;
                    //        Console.WriteLine(bitCoinBalance);
                    //        Console.WriteLine(cashBalance);
                        

                    //    }
                    //    if (cryptoSell == "e")
                    //    {
                          


                    //    }

                    //    if (cryptoSell == "l")
                    //    {
                         

                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("Enter a valid decision");
                    //    }

                    //    break;

                    
                  
                }


            } while (!end);

           
        }
    }
}
