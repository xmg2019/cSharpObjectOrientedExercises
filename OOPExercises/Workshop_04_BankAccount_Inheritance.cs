using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{
    // Workshop 4 - Using Inheritance
    // Enhance the BankAccount class created in Workshop 3.
    // Add its derived classes to cater to the following types of accounts:
    // SavingsAccount: Savings Account earns 1% interest; but balance may not be negative.
    // CurrentAccount: Current Account earns 0.25% interest; but balance may not be negative.
    // OverDraftAccout: Overdraft Account earns 0.25% interest for positive balance; but is required to pay 6% interest for negative balance; 
    // balance may be negative.
    // Create a new Test class and within its static void Main(string[] args), test that your classes function correctly.

        // My Attempt:

    class Workshop_04_BankAccount_Inheritance
    {
        public int acctNumber;
        public string acctHolderId;
        private double balance;
        public double interestEarned;
        public bool balanceIsNeg;

        public Workshop_04_BankAccount_Inheritance()
        {

        }

        public Workshop_04_BankAccount_Inheritance(string b, int a)
        {
            acctHolderId = b;
            acctNumber = a;
        }


        public void Withdraw(double amt)
        {
            if (balanceIsNeg == true)
            {
                Console.WriteLine("There is insufficent fund for withdrawal");
            }
            else
            {
                balance -= amt;
            }
        }

        public void Deposit(double amt)
        {
            balance += amt;
        }

        public void TransferTo(double amt, Workshop_04_BankAccount_Inheritance bankAccount)
        {
            this.balance -= amt;
            bankAccount.balance += amt;
        }

        public void CalculateInterest(double interest)
        {
            interestEarned = balance * (interest / 100);
        }

        public void CreditInterest()
        {
            balance += interestEarned;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void SetBalance(double amount)
        {
            balance = amount;
        }

        public bool TestBalance()
        {
            if (GetBalance() < 0)
            {
                return balanceIsNeg = true;
            }
            else
            {
                return balanceIsNeg = false;
            }
        }
    }


    class Workshop_04_BankAccount_SavingAccount : Workshop_04_BankAccount_Inheritance
    {
        
        public Workshop_04_BankAccount_SavingAccount(string b, int a) : base(b, a)
        {

        }

        public new bool TestBalance()
        {
            if (GetBalance() < 0)
            {
                return balanceIsNeg = true;
            }
            else
            {
                return balanceIsNeg = false;
            }
        }


        public void CalculateInterest()
        {
            if (balanceIsNeg == true)
            {
                interestEarned = 0;
                
            }
            else
            {
                interestEarned = GetBalance() * (0.01);
                // 1% interest = 1/100 = 0.01
                
            }
        }

    }


    class Workshop_04_BankAccount_CurrentAccount : Workshop_04_BankAccount_Inheritance
    {

        public Workshop_04_BankAccount_CurrentAccount(string b1, int a1) : base(b1, a1)
        {


        }

        public new bool TestBalance()
        {
            if (GetBalance() < 0)
            {
                return balanceIsNeg = true;
            }
            else
            {
                return balanceIsNeg = false;
            }
        }

        public void CalculateInterest()
        {
            if (balanceIsNeg == true)
            {
                interestEarned = 0;
          
            }
            else
            {
                interestEarned = GetBalance() * (0.25 / 100);
                
            }
        }


    }

    class Workshop_04_BankAccount_OverDraftAccount : Workshop_04_BankAccount_Inheritance
    {
        

        public Workshop_04_BankAccount_OverDraftAccount(string b2, int a2) : base(b2, a2)
        {


        }

        public new bool TestBalance()
        {
            if (GetBalance() < 0)
            {      
                return balanceIsNeg = true;
            }
            else
            {
                return balanceIsNeg = false;
            }
        }

        public void CalculateInterest()
        {
            if (balanceIsNeg == true)
            {
                interestEarned = GetBalance() * (0.06);          
                // admin fee of 6% = 6/100 = 0.06
            }
            else
            {
                interestEarned = GetBalance() * (0.25 / 100);             
            }
        }

    }

    class Workshop_04_BankAccount_Inheritance_test
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NUSISS bank.");
            Console.WriteLine("Please select your account type : \n 1. Savings Account \n 2. Current Account \n 3. OverDraft Account ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Please enter your Bank Account Id: ");
            string bAcctId = Console.ReadLine();

            Console.WriteLine("Please enter your Bank Account number: ");
            int aNumber = Convert.ToInt32(Console.ReadLine());

                      
            if (selectedOption == 1)
            {
                Workshop_04_BankAccount_SavingAccount savingAcct = new Workshop_04_BankAccount_SavingAccount(bAcctId, aNumber);
                savingAcct.SetBalance(5000.00);

                Console.WriteLine($"Your saving account {aNumber} current balance is $ {savingAcct.GetBalance():0.00}. \n");

                savingAcct.TestBalance();
                savingAcct.CalculateInterest();
                savingAcct.CreditInterest();

                Console.WriteLine($"Interest earned = ${savingAcct.interestEarned:0.00}");
                Console.WriteLine($"Total amount in saving account with interest = ${savingAcct.GetBalance():0.00}");

                

            }
            else if (selectedOption == 2)

            {
                Workshop_04_BankAccount_CurrentAccount currentAcct = new Workshop_04_BankAccount_CurrentAccount(bAcctId, aNumber);
                currentAcct.SetBalance(2000.00);

                Console.WriteLine($"Your current account {aNumber} current balance is $ {currentAcct.GetBalance():0.00}. \n");

                currentAcct.TestBalance();
                currentAcct.CalculateInterest();
                currentAcct.CreditInterest();

                Console.WriteLine($"Interest earned = ${currentAcct.interestEarned:0.00}");
                Console.WriteLine($"Total Amount in current account with interest = ${currentAcct.GetBalance():0.00}");

            }
            else if (selectedOption == 3)
            {
                Workshop_04_BankAccount_OverDraftAccount oDAcct = new Workshop_04_BankAccount_OverDraftAccount(bAcctId, aNumber);
                oDAcct.SetBalance(-90);

                Console.WriteLine($"Your saving account {aNumber} current balance is $ {oDAcct.GetBalance():0.00}. \n");

                oDAcct.TestBalance();
                oDAcct.CalculateInterest();
                oDAcct.CreditInterest();

                Console.WriteLine("Your account is negative, no interest is earned. ");
                Console.WriteLine($"Please pay $ {-oDAcct.interestEarned: 0.00} as administrative fees for negative balance.");
                Console.WriteLine($"Total amount owe to over-draft account (with interest) = $ {oDAcct.GetBalance(): 0.00}");


            }
        }
    }

}



