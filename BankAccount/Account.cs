using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account
    /// </summary>
    internal class Account
    {
        /// <summary>
        /// Construsctor for creating an account with a specific owner and a balance of 0
        /// </summary>
        /// <param name="accOwner">The customer full name that owns the account</param>
        public Account(string accOwner)
        {
            Owner = accOwner;
        }

        /// <summary>
        /// Accounts holders full name (first and last)
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Current amount of money in the account
        /// </summary>
        public string Balance { get; set; }

        /// <summary>
        /// Adds a specfiied amount of money to the account
        /// </summary>
        /// <param name="amt"></param>
        /// <exception cref="NotImplementedException">The positive amount to deposit</exception>
        public void Deposit(double amt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Withdraws an amount of money from the balance
        /// </summary>
        /// <param name="amt"></param>
        /// <exception cref="NotImplementedException">The positive amount of money to be taken from the balance</exception>
        public void Withdraw(double amt) 
        { 
            throw new NotImplementedException(); 
        }
    }
}
