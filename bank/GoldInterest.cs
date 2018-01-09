using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class GoldInterest : IntresetRateMechanism
    {
        public override void Handle(Account acc)
        {
            acc.SetBalance(acc.GetBalance() + 10);
        }
    }
}
