using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
   public class Crypto
    {

        public decimal CashValue { get; set; }
        
        public string Name { get; set; }

        public Crypto( decimal cashValue, string name)
        {
            CashValue = cashValue;
            Name = name;
            
        }

        public Crypto()
        {

        }

        public override string ToString() => $"{CashValue}";
      
    }
}
