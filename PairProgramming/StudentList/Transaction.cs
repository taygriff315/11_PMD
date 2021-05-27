using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
   public class Transaction
    {
        public static void Trade(Crypto sent, Crypto recieved)
        {



            if (sent.Name == "BitCoin")
            {
                Console.WriteLine("1 BitCoin = 12.");
                Console.WriteLine("How many Shares would you like to trade?");
                int userTradeAmount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("And which Crypto will you be trading for?");
                Console.WriteLine("A) Etherium");
                Console.WriteLine("B) LiteCoin");
                string userTradeSelection = Console.ReadLine().ToLower();
                if (userTradeSelection == "a")
                {
                    //Trade bitcoin for etherium logic
                    


                }
                if (userTradeSelection == "b")
                {
                    //Trade bitcoin for LiteCoin logic
                }
            }
            if (sent.Name == "Etherium")
            {
                
                Console.WriteLine("How many Shares would you like to trade?");
                int userTradeAmount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("And which Crypto will you be trading for?");
                Console.WriteLine("A) BitCoin");
                Console.WriteLine("B) LiteCoin");
                string UserTradeSelection = Console.ReadLine().ToLower();
                if (UserTradeSelection == "a")
                {
                    //Trade Etherium for bitcoin logic
                }
                if (UserTradeSelection == "b")
                {
                    //Trade Etherium for LiteCoin logic
                }
            }
            if (sent.Name == "LiteCoin")
            {
                Console.WriteLine("How many Shares would you like to trade?");
                int userTradeAmount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("And which Crypto will you be trading for?");
                Console.WriteLine("A) BitCoin");
                Console.WriteLine("B) Etherium");
                string UserTradeSelection = Console.ReadLine().ToLower();
                if (UserTradeSelection == "a")
                {
                    //Trade LiteCoin for bitcoin logic
                }
                if (UserTradeSelection == "b")
                {
                    //Trade LiteCoin for Etherium logic
                }
            }


        }
    }
}
