﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account
    /// </summary>
    public class Account
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
        public double Balance { get; private set; }

        /// <summary>
        /// Adds a specfiied amount of money to the account
        /// </summary>
        /// <param name="amt"></param>
        /// <exception cref="NotImplementedException">The positive amount to deposit</exception>
        /// <returns>The new balance after the deposit</returns>
        public double Deposit(double amt)
        {
            
            if (amt <= 0)
            {                                               // gets the string representation of it so if we change it changes
                throw new ArgumentOutOfRangeException($"The {nameof(amt)} must be more than 0");
            }

            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Withdraws an amount of money from the balance and returns the updated balance
        /// </summary>
        /// <param name="amt"></param>
        /// <exception cref="NotImplementedException">The positive amount of money to be taken from the balance</exception>
        /// <returns>Returns the updated balance after withdrawal</returns>
        public double Withdraw(double amt) 
        { 
            Balance -= amt;
            return Balance;
        }
    }
}
