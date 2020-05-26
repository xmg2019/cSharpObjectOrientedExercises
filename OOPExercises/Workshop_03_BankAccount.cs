using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{
    // Workshop 03 - Enhanced Class
    // Implement a BankAccount class
    // Create following Attributes of a bank account;
    // acctNumber, acctHolderId & balance (private)
    // Create the following methods;
    // Withdraw(double amt)
    // Deposit(double amt)
    // TransferTo(double amt, BankAccount bankAccount)
    // Ensure appropriate accessibility specifiers for information hiding
    // and use properties to expose your class’s private attributes.
    // Create a new Test class and within its static void Main(string[]args), 
    // test that your BankAccount class functions correctly

        // My Attempt:
    class Workshop_03_BankAccount
    {
        public int acctNumber;
        public string acctHolderId;
        private double balance;

        public Workshop_03_BankAccount()
        {

        }

        public Workshop_03_BankAccount(string b, int a)
        {
            acctHolderId = b;
            acctNumber = a;
        }


        public void Withdraw(double amt)
        {
            balance -= amt;
        }

        public void Deposit(double amt)
        {
            balance += amt;
        }

        public void TransferTo(double amt, Workshop_03_BankAccount bankAccount)
        {
            this.balance -= amt;
            bankAccount.balance += amt;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setBalance(double amount)
        {
            balance = amount;
        }
    }

    class Workshop_03_BankAccount_Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NUSISS bank.");
            Console.WriteLine("Please enter your Bank Account Id (numerical & alphabets accepted): ");
            string bAcctId = Console.ReadLine();
            
            Console.WriteLine("Please enter your Bank Account number (only digits accepted): ");
            int aNumber = Convert.ToInt32(Console.ReadLine());

            Workshop_03_BankAccount bankAcct01 = new Workshop_03_BankAccount(bAcctId, aNumber);
            bankAcct01.setBalance(5000.00);

            Console.WriteLine("Your current bank account " + aNumber + " balance is $ " + bankAcct01.getBalance());

            Console.WriteLine("Please select an action to perform : \n 1. Withdraw \n 2. Deposit \n 3. Transfer To Another Bank Account ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());

            if( selectedOption == 1)
            {
                Console.WriteLine("Please enter withdrawal amount: ");
                double withdrawalAmt = Double.Parse(Console.ReadLine());

                if(withdrawalAmt <= bankAcct01.getBalance())
                {
                    bankAcct01.Withdraw(withdrawalAmt);
                    Console.WriteLine("Amount withdraw from account = $ " + withdrawalAmt);
                    Console.WriteLine("New balance after withdrawl = $ " + bankAcct01.getBalance());
                }else
                {
                    Console.WriteLine("There is insufficient fund to be withdrawn from the bank account.");
                }

            } else if (selectedOption == 2)
            
            {
                Console.WriteLine("Please enter a amount to deposit into bank : ");
                double depositAmt = Double.Parse(Console.ReadLine());
                bankAcct01.Deposit(depositAmt);

                Console.WriteLine("Amount deposited to account = $ " + depositAmt);
                Console.WriteLine("New balance after deposit = $ " + bankAcct01.getBalance());

            }
            else if (selectedOption == 3)
            {
                Console.WriteLine("Please enter the bank account number to be transfer to (only digits accepted): ");
                int transferBankAcct = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the bank account holder ID to be transfer to (numerical & alphabets accepted): ");
                string transferBankAcctID = Console.ReadLine();

                Workshop_03_BankAccount newBAcct = new Workshop_03_BankAccount(transferBankAcctID, transferBankAcct);
                newBAcct.setBalance(0.00);

                Console.WriteLine($"Please enter the amount to be transfer to the other bank account {transferBankAcct} : ");
                double transferAmount = double.Parse(Console.ReadLine());

     
                bankAcct01.TransferTo(transferAmount, newBAcct);

                Console.WriteLine($"New balance after fund transfer: $ {bankAcct01.getBalance()}.\n");

                // check
                Console.WriteLine($"Account number:{transferBankAcct}");
                Console.WriteLine($"Amount received from transfer: $ {transferAmount}, new balance = $ {newBAcct.getBalance()}");

            }


            
        }
    }
}
