using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class Account : AbstractAccount
    {
        public int ID { get; set; }
        public string owner { get; set; }
        public DateTime openingDate { get; set; }

        public List<Operation> operations { get; set; }

       private IntresetRateMechanism InterestRate;

       private int balance;

        public Account(int id, string Owner, int bal)
        {
            this.ID = id;
            this.owner = owner;
            this.openingDate = DateTime.Now;
            this.operations = new List<Operation>();
            this.balance =bal;
            this.InterestRate = new GoldInterest();
        }

        public Account(IntresetRateMechanism itr)
        {
            this.InterestRateMechanism = itr;
        }
        public IntresetRateMechanism InterestRateMechanism
        {
            get { return InterestRate; }
            set { this.InterestRate = value; }
        }

       public void Withdraw(int amount)
       {
           this.balance = this.balance - amount;
           
       }
       public void Deposit(int amount)
       {
           this.balance = this.balance + amount;
       }
       public void SetBalance(int balance)
       {
           this.balance = balance;
       }

       public int GetBalance()
       {
           return this.balance;
       }
    }

}
