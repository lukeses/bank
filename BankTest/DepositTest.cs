using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bank;

namespace BankTest
{
    [TestClass]
    public class DepositTest
    {
        Account account;
        private Deposit dep;

        [TestInitialize]
        public void TestInitialize()
        {

            account = new Account(12, "",  500);
            dep = new Deposit();
        }

        [TestMethod]
        public void PositiveAmount()
        {
            int amount = 50;
            dep.execute(account, amount);
            Assert.AreEqual(account.GetBalance(), 550);
            
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid amount.")]
        public void NegativeAmount()
        {
           int amount = -50;
           dep.execute(account, amount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid amount.")]
        public void ZeroAmount()
        {
            int amount = 0;
            dep.execute(account, amount);
        }
    }
}
