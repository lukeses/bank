using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
      public class Transaction : Operation

    {
         public int TransferAmount { get; set; }

         //public Transaction() : base (OperationType.Type type , string desc)
         //{
         //    super(type, desc);
         //    this.transferAmount = amount;
         //}

         public void execute(Account sender, Account receiver,  int amount)
         {
             if (amount > sender.GetBalance())
             { 
                 throw new System.ArgumentException("Not enough balance.");
             }
             else if (amount <= 0)
             {
                 throw new System.ArgumentException("Negative amount to transfer.");
             }
             sender.SetBalance(sender.GetBalance() - amount);
             receiver.SetBalance(receiver.GetBalance() + amount);


             //sender.balance = sender.balance - amount;
             //receiver.balance = receiver.balance + amount;
             Console.WriteLine("Amount transferred.");
         }


    }
}
