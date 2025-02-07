using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class BankAccount
    {
        int accountNumber;
        string holderName;
        string currency;
        float balance;

        public BankAccount (int accountNumber, string holderName, string currency, float balance)
        {
            this.accountNumber = accountNumber;
            this.holderName = holderName;
            this.currency = currency;
            this.balance = balance;
        }

        public float Deposit (float amount)
        {
            balance = balance + amount;
            return balance;
        }

        public float Withdraw (float amount)
        {
            if (balance - amount > 0)
            {
                balance = balance - amount;
                return amount;
            }
            else 
            {
                Console.WriteLine("Not enough balance");
                return 0;
            }
            
        }

        public float TransferFrom (float amount)
        {
            balance -= amount;
            return amount;
        }

        public float TransferTo (float amount)
        {
            balance += amount;
            return 0;
        }
    }
}
