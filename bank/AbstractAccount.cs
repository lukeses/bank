using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public interface AbstractAccount
    {
        void Withdraw(int amount);

        void Deposit(int amount);

    }
}
