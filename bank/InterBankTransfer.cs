using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class InterBankTransfer
    {
        private Bank SenderBank{ get; set; }
        private Bank ReceiverBank { get; set; }
        private int SenderID { get; set; }

        private int ReceiverID { get; set; }
        private int Amount { get; set; }


        public InterBankTransfer(Bank senderBank, int senderID, Bank receiverBank, int receiverID, int amount)
        {
            this.SenderBank = senderBank;
            this.ReceiverBank = receiverBank;
            this.SenderID = senderID;
            this.ReceiverID = receiverID;
            this.Amount = amount;
        }

        public Bank getReceiverBank()
        {
            return this.ReceiverBank;
        }

        public int getReceiverID()
        {
            return this.ReceiverID;
        }

        public int getSenderID()
        {
            return this.SenderID;
        }

        public int getAmount()
        {
            return this.Amount;
        }

        public Bank getSenderBank()
        {
            return this.SenderBank;
        }
    }
}
