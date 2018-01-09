using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bank;
using System.Collections.Generic;

namespace BankTest
{
    [TestClass]
    public class InterBankTransferTest
    {
        InterBank ElixirSessionInterBank;
        Bank MBank;
        Bank WBK;

        [TestInitialize]
        public void TestInitialize()
        {
            ElixirSessionInterBank = new InterBank();
            MBank = new Bank(1000, ElixirSessionInterBank);
            WBK = new Bank(1000, ElixirSessionInterBank);
        }

        [TestMethod]
        public void CreateInterTransfer()
        {
            ElixirSessionInterBank.AddToInterBank(MBank);
            ElixirSessionInterBank.AddToInterBank(WBK);

            List<Bank> listOfBanks = new List<Bank>();
            listOfBanks.Add(MBank);
            listOfBanks.Add(WBK);

            createAccount(MBank, 1, "Lukasz");
            createAccount(WBK, 2, "Tomasz");

            getAccount(MBank, 1).Deposit(100);
            getAccount(WBK, 2).Deposit(100);


            InterBankTransfer interBankTransfer = new InterBankTransfer(MBank, 1, WBK, 2, 100);
            MBank.sendInterBankTransfer(interBankTransfer);

            Assert.AreEqual(getAccount(MBank, 1).GetBalance(), 0);
            Assert.AreEqual(getAccount(WBK, 2).GetBalance(), 200);
        }

        [TestMethod]
        public void Negative_CreateInterTransfer()
        {
            ElixirSessionInterBank.AddToInterBank(MBank);
            ElixirSessionInterBank.AddToInterBank(WBK);

            List<Bank> listOfBanks = new List<Bank>();
            listOfBanks.Add(MBank);
            listOfBanks.Add(WBK);

            createAccount(MBank, 1, "Lukasz");
            createAccount(WBK, 2, "Tomasz");

            getAccount(MBank, 1).Deposit(100);
            getAccount(WBK, 2).Deposit(100);


            InterBankTransfer interBankTransfer = new InterBankTransfer(MBank, 1, WBK, 3, 100);
            MBank.sendInterBankTransfer(interBankTransfer);

            Assert.AreEqual(getAccount(MBank, 1).GetBalance(), 100);
            Assert.AreEqual(getAccount(WBK, 2).GetBalance(), 100);
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
    }
}
