using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bank;


namespace BankTest
{
    [TestClass]
    public class DebtAccountTest
    {
        Account acc;
        Account accWithDebt;
        Bank bank;
        DebtAccount debtacc;
        DebtAccount withDebt;
        InterBank interBank;

        [TestInitialize]
        public void TestInitialize()
        {
            interBank = new InterBank();
            acc = new Account(2, "", 300);
            bank = new Bank(1500, interBank);
            debtacc = new DebtAccount(acc);
            accWithDebt = new Account(2, "", 0);
            withDebt = new DebtAccount(accWithDebt);
            withDebt.SetDebtBalance(50);
        }

        [TestMethod]
        public void Possible_Withdrawal()
        {
            debtacc.Withdraw(300);
            Assert.AreEqual(debtacc.GetDebtBalance(), 0);
            Assert.AreEqual(acc.GetBalance(), 0);

        }

        [TestMethod]
        public void Beyong_Withdraw()
        {
            debtacc.Withdraw(350);
            Assert.AreEqual(debtacc.GetDebtBalance(), 50);
            Assert.AreEqual(acc.GetBalance(), 0);

        }

        [TestMethod]
        public void Above_Withdraw()
        {
            debtacc.Withdraw(250);
            Assert.AreEqual(debtacc.GetDebtBalance(), 0);
            Assert.AreEqual(acc.GetBalance(), 50);

        }

        [TestMethod]
        public void Possible_Deposit()
        {
            debtacc.Deposit(100);
            Assert.AreEqual(debtacc.GetDebtBalance(), 0);
            Assert.AreEqual(acc.GetBalance(), 400);
        }

        [TestMethod]
        public void Possible_Deposit_With_Debt()
        {
            withDebt.Deposit(50);

            Assert.AreEqual(withDebt.GetDebtBalance(), 0);
            Assert.AreEqual(accWithDebt.GetBalance(), 0);
        }

        [TestMethod]
        public void Possible_Deposit_With_Debt_And_Incoming_Balance()
        {
            withDebt.Deposit(100);

            Assert.AreEqual(withDebt.GetDebtBalance(), 0);
            Assert.AreEqual(accWithDebt.GetBalance(), 50);
        }

    }
}
