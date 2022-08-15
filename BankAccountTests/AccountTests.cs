using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize] // run before tests so we have a fresh accoutn before each test
        public void CreateDefaultAccount()
        {
            acc = new Account("J. Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9_999.99)]
        public void DepositAPositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]

        public void Deposit_APositiveAmount_ReturnUpdatedBalance()
        {
            // AAA - Arrange Act Assert
            // Arrange is getting all varibles together
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)] // calls test with a piece of informations
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowArgumentException(double invalidDepositAmount)
        {

            //Assert => Act - calling the method
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));

            //Assert
        }

        // Withdrawing a positive amount - decrease balance
        // Withdrawing 0 - Throws ArgumentOutRange exception
        // Withdrawing negative amount - Throws ArgumentOutOfRange exception
        // Withdrawing more than balance - ArgumentEXception
        [TestMethod]
        public void Withdraw_PostitiveAmount_DecreaseBalance()
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawlAmount = 50;
            double expectedBalance = initialDeposit - withdrawlAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawlAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance); ;
        }

        [TestMethod]
        [DataRow(100, 50)]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double initialDeposit, double withdrawlAmount)
        {
            // deposit some money so i can withdraw
            //Arrange
            double expectedBalance = initialDeposit - withdrawlAmount;
            acc.Deposit(initialDeposit);

            //Act
            double returnedBalance = acc.Withdraw(withdrawlAmount);

            //Assert
            Assert.AreEqual(expectedBalance, returnedBalance);

        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withDrawlAmount)
        {
            // if thorws any of these amounts will throw exception
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withDrawlAmount));
        }

        [TestMethod]
        public void Withdrawl_MoreThanAvaliableBalance_ThrowsArgumentException()
        {
            double withdrawlAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawlAmount));
        }
    }
}