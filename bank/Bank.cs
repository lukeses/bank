using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class Bank
    {
        public int AvailableLoan { get; set; }
        private List<Account> AccountList { get; set; }
        private InterBank InterBankOfBank { get; set; }

        public Bank(int amount, InterBank interBank)
        {
            this.AvailableLoan = amount;
            this.AccountList = new List<Account>();
            this.InterBankOfBank = interBank;
        }

        public void AddAccount(Account account){
            AccountList.Add(account);
        }

        public void sendInterBankTransfer(InterBankTransfer interBankTransfer)
        {
            var senderAccount = this.AccountList.Find(b => b.ID == interBankTransfer.getSenderID());
            senderAccount.Withdraw(interBankTransfer.getAmount());
            InterBankOfBank.SendInterBankTransfer(interBankTransfer);
        }

        public void receiveInterBankTransfer(InterBankTransfer interBankTransfer)
        {
            var receiverAccount = this.AccountList.Find(b => b.ID == interBankTransfer.getReceiverID());
            if(receiverAccount != null)
            {
                receiverAccount.Deposit(interBankTransfer.getAmount());
            }
            else
            {
                InterBankOfBank.SendBackInterBankTransfer(interBankTransfer);
            }
        }

        public Account FindAccount(int ID)
        {
            return AccountList.Find(x => x.ID == ID);
        }
    }
}
