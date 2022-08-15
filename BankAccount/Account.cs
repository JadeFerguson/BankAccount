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
    public class Account
    {
        private string owner;

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
        /// can convert to full property by going to toll and Convert to full property
        public string Owner 
        {
            get { return owner; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{Owner} cannot be null");
                }

                if (value.Trim() == string.Empty)
                {
                    throw new ArgumentException($"{nameof(Owner)} must have some text");
                }

                if (IsOwnerNameValid(value))
                {
                    owner = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(owner)} can be up to 20 characters, A-Z/spaces only");
                }
            }           
        }

        /// <summary>
        /// Checks if Owner name is less than or equal to 20 characters, A-Z 
        /// and whitespace characters are allowed
        /// </summary>
        /// <returns></returns>
        private bool IsOwnerNameValid(string ownerName)
        {
            char[] validCharacters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'
                , 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x'
                , 'y', 'z'};

            ownerName = ownerName.ToLower(); // Only need to compare one casing

            const int MaxNameValue = 20;

            if (ownerName.Length > MaxNameValue)
            {
                return false;
            }

            foreach(char letter in ownerName)
            {
                if (letter != ' ' && !validCharacters.Contains(letter))
                {
                    return false;
                }
            }
            return true;

        }

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
            if (amt > Balance)
            {
                throw new ArgumentException($"{nameof(amt)} cannot be greater than {nameof(Balance)}");
            }

            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amt)} must be greater than 0");
            }

            Balance -= amt;
            return Balance;
        }
    }
}
