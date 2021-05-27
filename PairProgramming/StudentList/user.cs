using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
   public class User
    {
        public decimal CashBalance { get; set; }
        public int BitTotal { get; set; }
        public int EthTotal { get; set; }
        public int LiteTotal { get; set; }

    public User(decimal cashBalance, int bitTotal, int ethTotal, int liteTotal)
    {
            CashBalance = cashBalance;
            BitTotal = bitTotal;
            EthTotal = ethTotal;
            LiteTotal = liteTotal;
    }

        public User()
        {

        }



    }
}


//double bitcoin = 7480;
//double etherium = 586.15;
//double litecoin = 119.04;