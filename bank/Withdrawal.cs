using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class Withdrawal : Operation
    {
        public void execute(Account acc, int amount)
        {
            if (amount <= 0)
            {
                throw new System.ArgumentException("Invalid amount.");
            }
            acc.Withdraw(amount);   
        }
    }
}
