using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{
    // Workshop 7 - Using Exceptions
    // 7.2 BankAccount Exception
    // Replace the boolean result in the Withdraw() method in the Workshop 3 with C# Exception handling method

        // Mt Attempt: 

    class Workshop_07_2_BankAccount_Exceptions
    {
         static void Main (string[] args)
        {
            Console.WriteLine("Welcome to NUSISS bank.");
            Console.WriteLine("Please enter your Bank Account Id (numerical & alphabets accepted): ");
            string baId = Console.ReadLine();

            Console.WriteLine("Please enter your Bank Account number (only digits accepted): ");
            int aNum = Convert.ToInt32(Console.ReadLine());

            BankAccount bankAcct001 = new BankAccount(baId, aNum);
            bankAcct001.SetBalance(8000.00);

            Console.WriteLine("Your current bank account " + aNum + " balance is $ " + bankAcct001.GetBalance());

            Console.WriteLine("Please select an action to perform : \n 1. Withdraw \n 2. Deposit \n 3. Transfer To Another Bank Account ");
            int chosenOption = Convert.ToInt32(Console.ReadLine());


            if (chosenOption == 1)
            {
                Console.WriteLine("Please enter withdrawal amount: ");
                double withdrawalAmt01 = Double.Parse(Console.ReadLine());

                bankAcct001.WithdrawalAmount = withdrawalAmt01;
         
                // test balance, try-catch block

                try
                {
                    bankAcct001.Withdraw();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    return;
                }
    
                Console.WriteLine("Amount withdraw from account = $ " + withdrawalAmt01);
                Console.WriteLine("New balance after withdrawl = $ " + bankAcct001.GetBalance()); 

            }
            else if (chosenOption == 2)
            {
                Console.WriteLine("Please enter a amount to deposit into bank : ");
                double depositAmt = Double.Parse(Console.ReadLine());
                bankAcct001.Deposit(depositAmt);

                Console.WriteLine("Amount deposited to account = $ " + depositAmt);
                Console.WriteLine("New balance after deposit = $ " + bankAcct001.GetBalance());

            }
            else if (chosenOption == 3)
            {
                Console.WriteLine("Please enter the bank account number to be transfer to (only digits accepted): ");
                int transferBankAcct = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the bank account holder ID to be transfer to (numerical & alphabets accepted): ");
                string transferBankAcctID = Console.ReadLine();

                BankAccount newBAcct = new BankAccount(transferBankAcctID, transferBankAcct);
                newBAcct.SetBalance(0.00);

                Console.WriteLine($"Please enter the amount to be transfer to the other bank account {transferBankAcct} : ");
                double transferAmount = double.Parse(Console.ReadLine());


                bankAcct001.TransferTo(transferAmount, newBAcct);

                Console.WriteLine($"New balance after fund transfer: $ {bankAcct001.GetBalance()}.\n");

                // check
                Console.WriteLine($"Account number:{transferBankAcct}");
                Console.WriteLine($"Amount received from transfer: $ {transferAmount}, new balance = $ {newBAcct.GetBalance()}");
            }

        }
    }

    public class BankAccount
    {
        public int acctNumber;
        public string acctHolderId;
        private double balance;
        public double interestEarned;
        public double withdrawalAmt;

        // public bool balanceIsNeg; (not required)

        public BankAccount()
        {

        }

        public BankAccount(string b, int a)
        {
            acctHolderId = b;
            acctNumber = a;
        }

        public void Withdraw()
        {
          
            // modified for try-catch loop

            if (GetBalance() < 0)
            {
                throw new Exception("Error: Insufficient fund in account to perform transaction ");
            }
            else if (withdrawalAmt > GetBalance())
            {
                throw new Exception("Error: Requested withdrawal exceeds available fund. Transaction cancelled. ");
            }
            else
            {
                balance -= withdrawalAmt;
            }

        }

        public void Deposit(double amt)
        {
            balance += amt;
        }

        public void TransferTo(double amt, BankAccount bankAccount)
        {
            this.balance -= amt;
            bankAccount.balance += amt;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void SetBalance(double amount)
        {
            balance = amount;
        }

        public double WithdrawalAmount
        {
            get { return withdrawalAmt; }
            set { withdrawalAmt = value; }
        }
     
    }

}
