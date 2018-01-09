using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Program
    {

        private static Bank MBank;
        private static Bank WBK;
        private static InterBank ElixirSessionInterBank;

        static void Main(string[] args)
        {
            //            Account acc1 = new Account(65,"b", 500);
            //            Account acc2 = new Account(66, "C", 800);

            //            DebtAccount debtAccount = new DebtAccount(acc1);

            //            acc1.InterestRateMechanism.Handle(acc1);
            ////            var mechanism = acc1.InterestRate;

            //            Deposit dep = new Deposit();
            //            Withdrawal with = new Withdrawal();
            //            Transaction tran = new Transaction();
            //            Credit credit = new Credit();
            //            Bank bank = new Bank (90000);
            //            Bank bank_2 = new Bank(1200);

            //            Console.WriteLine("Account 1: {0} ", acc1.GetBalance());
            //            Console.WriteLine("Account 2: {0} ", acc2.GetBalance());
            //            credit.execute(acc1, bank, 140);
            //            dep.execute(acc1, 80);
            //            tran.execute(acc1, acc2, 60);
            //            with.execute(acc1, 50);
            //            Console.WriteLine("Credit request accepted. (T/F) \n {0}", credit.execute(acc1, bank, 140));

            //            //Console.WriteLine("Account 1: {0} ", acc1.balance);
            //            //Console.WriteLine("Account 2: {0} ", acc2.balance);
            //            //Console.WriteLine("Account 1: {0} ", acc1.balance);
            //            //Console.WriteLine("Account 1: {0} ", acc1.balance);
            //            Console.ReadLine();

            createInterBank();

            createAccount(MBank, 1, "Lukasz");
            createAccount(WBK, 2, "Tomasz");

            getAccount(MBank, 1).Deposit(100);
            getAccount(WBK, 2).Deposit(100);


            InterBankTransfer interBankTransfer = new InterBankTransfer(MBank, 1, WBK, 2, 100);
            MBank.sendInterBankTransfer(interBankTransfer);

            printBalance(getAccount(MBank, 1));
            printBalance(getAccount(WBK, 2));

        }

        public static void createInterBank()
        {
            ElixirSessionInterBank = new InterBank();
            MBank = new Bank(1000, ElixirSessionInterBank);
            WBK = new Bank(1000, ElixirSessionInterBank);
            ElixirSessionInterBank.AddToInterBank(MBank);
            ElixirSessionInterBank.AddToInterBank(WBK);

            List<Bank> listOfBanks = new List<Bank>();
            listOfBanks.Add(MBank);
            listOfBanks.Add(WBK);
        }
        

        public static void createAccount(Bank bank, int id, string owner)
        {
            var account = new Account(id, owner, 0);
            bank.AddAccount(account);
        }

        public static Account getAccount(Bank bank, int id)
        {
            return bank.FindAccount(id);
        }

        public static void deposit(Account account, int amount)
        {
            account.Deposit(amount);
        }

        public static void printBalance(Account account)
        {
            Console.WriteLine("Account ID: {0} Account balance: {1}", account.ID, account.GetBalance());
        }


    }
}
