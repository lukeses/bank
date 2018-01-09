using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class OperationType
    {
       public enum Type
        {
            Withdrawal, Payment, InterestCalculation, ChangeOfInterestRate, Deposit, DepositClose, Credit, CreditPayment, Debit, Reporting
        }
        
    }
}
