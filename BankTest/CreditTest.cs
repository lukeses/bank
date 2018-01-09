using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bank;

namespace BankTest
{
    [TestClass]

    public class CreditTest
    {
         Account acc;
         Bank bank;
         Credit credit;
         InterBank interBank;

        [TestInitialize]
        public void TestInitialize()
        {
            interBank = new InterBank();
            acc = new Account(2, "", 300);
            bank = new Bank(1500, interBank);
            credit = new Credit();
        }

        [TestMethod]
        public void Possible_Request()
        {
            int amount = 80;
           Boolean result = credit.execute(acc, bank, amount);
           // Assert.AreEqual(result,true);
            Assert.AreEqual(bank.AvailableLoan,1420);
            Assert.AreEqual(acc.GetBalance(),380);
        }

        [TestMethod]
        public void Not_Possible()
        {
            int amount = (int)(acc.GetBalance()*0.3+1);
            Boolean result = credit.execute(acc, bank, amount);   
            Assert.AreEqual(result,false);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException),"")]
        public void Negative_Request()
        {
            int amount = -80;
            credit.execute(acc, bank, amount);
        }

        [TestMethod]
        public void Possibility_Loan()
        {
            int amount = 1000;
            Boolean bigger = bank.AvailableLoan > amount;
            Assert.AreEqual(bigger,true);
        }

        [TestMethod]
        public void Bankrupt()
        {
            int amount = 2000;
            Boolean bigger = bank.AvailableLoan > amount;
            Assert.AreEqual(bigger, false);
        }
    }
}
