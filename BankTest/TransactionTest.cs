using System;
using System.Net.Mime;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bank;

namespace BankTest
{
    [TestClass]
    public class TransactionTest
    {

        Account sender;
        Account receiver;

        [TestInitialize]
        public void TestInitialize()
        {
          
            sender = new Account(5, "", 600);
            receiver = new Account(6, "", 800);
        }

        [TestMethod]
        public void Succesful_Transaction()
        {
            int amount = 150;
            Transaction tran = new Transaction();
            tran.execute(sender, receiver, amount);
            Assert.AreEqual(sender.GetBalance(),450);
            Assert.AreEqual(receiver.GetBalance(),950);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException),"Not enough balance.")]
        public void Sufficient_Amount_Transfer()
        {
           int amount = 650;
            Transaction tran = new Transaction();
            tran.execute(sender, receiver, amount);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "")]
        public void Zero_Transfer()
        {
            int amount = 0;
            Transaction tran = new Transaction();
            tran.execute(sender, receiver, amount);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException),"")]
        public void Negative_Transfer()
        {
           int amount = -150;
            Transaction tran = new Transaction();
            tran.execute(sender, receiver, amount);
        }
    }
}
