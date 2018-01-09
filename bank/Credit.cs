using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
   public class Credit : Operation
    {
       public Boolean execute(Account acc, Bank bank, int amount)
       {
           if (amount > (acc.GetBalance() * 0.3))
           {
               return false;
           }
           else if (amount <= 0)
           {
               throw new System.ArgumentException("Invalid requested amount.");
           }
           else
           {
               acc.SetBalance(acc.GetBalance() + amount);
               bank.AvailableLoan = bank.AvailableLoan - amount;
               return true;
           }
       }
    }
}