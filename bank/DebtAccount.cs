using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class DebtAccount : AbstractAccount
    {
        private Account account;
        private int debtBalance;

        public DebtAccount(Account account)
        {
            this.account = account;
        }

        public void Withdraw(int amount) {
            if (account.GetBalance() >= amount)
            {
                account.Withdraw(amount);
            }
            else
            {
                int difference = amount - account.GetBalance();
                account.Withdraw(account.GetBalance());
                this.SetDebtBalance(this.GetDebtBalance() + difference);
            }
        }

        public void SetDebtBalance(int debtBalance)
        {
            this.debtBalance = debtBalance;
        }

        public int GetDebtBalance()
        {
            return this.debtBalance;
        }

        public void Deposit(int amount)
        {
            if (this.GetDebtBalance()>0)
            {
                if (amount >= this.GetDebtBalance())
                {
                    
                    int difference = amount - this.GetDebtBalance();
                    this.SetDebtBalance(0);
                    account.SetBalance(difference);
                }
                else
                {
                    this.SetDebtBalance( this.GetDebtBalance()-amount);
                }
                
            }
            else
            {
                account.Deposit(amount);
            }
        }
    }
}
