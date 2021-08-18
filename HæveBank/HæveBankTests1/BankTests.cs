using Microsoft.VisualStudio.TestTools.UnitTesting;
using HæveBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace HæveBank.Tests
{
    [TestClass()]
    public class BankTests
    {
        [TestMethod()]
        public void CreateNewAccount_CreateNewAccountTest()
        {
            Bank bank = new Bank();
            // Arrange
            string expected = "New user created";
            // Act
            string actual = bank.CreateNewAccount("tester", 123); //input string username,int pin
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LoginTest()
        {
            Bank bank = new Bank();
            // Acts
            User actual = bank.Login("tester", 123);
            // Assert
            Assert.AreEqual(actual, null);
        }

        [TestMethod()]
        public void WithdrawTest()//Example on a failure
        {
            Bank bank = new Bank();
            Account acc = new Account() { balance = 11,pin = 123};
            User user = new User() { account = acc,name = "tester"};
            bool result = bank.Withdraw(5, user);

            Assert.AreEqual(result,false);
        }
    }
}