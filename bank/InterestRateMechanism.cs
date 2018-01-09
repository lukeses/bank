using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public abstract class IntresetRateMechanism
    {
        public abstract void Handle(Account acc);
    }
}
