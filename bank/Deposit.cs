using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class Deposit : Operation
    {
        public void execute(AbstractAccount acc, int amount)
        {
            if (amount <= 0)
            {
                throw new System.ArgumentException("Invalid amount.");
            }
            acc.Deposit(amount);
        }
    }
}
