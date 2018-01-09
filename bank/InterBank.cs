using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class InterBank
    {

       public List<Bank> BankList {get; set;}

        public void AddToInterBank(Bank bank)
        {
            BankList.Add(bank);
        }

        public void SendBackInterBankTransfer(InterBankTransfer interBankTransfer)
        {
            var returnTransfer = new InterBankTransfer(interBankTransfer.getReceiverBank(), interBankTransfer.getReceiverID(),
                interBankTransfer.getSenderBank(), interBankTransfer.getSenderID(), interBankTransfer.getAmount());
            SendInterBankTransfer(returnTransfer);
        }

        public InterBank()
        {
            this.BankList = new List<Bank>();
        }

        public void SendInterBankTransfer(InterBankTransfer interBankTransfer)
        {
            var receiverBank = interBankTransfer.getReceiverBank();
            if (BankList.Contains(receiverBank))
            {
                receiverBank.receiveInterBankTransfer(interBankTransfer);
            }
        }

    }
}
