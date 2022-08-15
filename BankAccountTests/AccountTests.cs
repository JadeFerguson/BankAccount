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
            acc = new Account("Jade Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9_999.99)]
        [TestCategory("Deposit")]
        public void DepositAPositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
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
        [TestCategory("Deposit")]
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
        [TestCategory("Withdrawl")]
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
        [TestCategory("Withdrawl")]
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
        [TestCategory("Withdrawl")]
        //[Priority()] // can test tests by priority so can make 
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withDrawlAmount)
        {
            // if thorws any of these amounts will throw exception
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withDrawlAmount));
        }

        [TestMethod]
        [TestCategory("Withdrawl")]
        public void Withdrawl_MoreThanAvaliableBalance_ThrowsArgumentException()
        {
            double withdrawlAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawlAmount));
        }

        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = "   ");
            
        }

        [TestMethod]
        [DataRow("Jade")]
        [DataRow("Jade Ferguson")]
        [DataRow("Jade Ferguson Strife")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName)
        {
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }

        [TestMethod]
        [DataRow("Joe 3rd")]
        [DataRow("Jade Ferguson Strifes")]
        [DataRow("#$%&")]
        public void Owner_IvalidOwnerName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
    }
}

// [TestCategory("Withdrawl")] is a category
// Can sort tests and see them in the test expolorer
// so do group by, traits