using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{
    // Workshop 5 - Polymorphism
    // 5.1 Polymorphic methods
    // Modify the classes in your solution for workshop 4 by making the necessary methods to be virtual 
    // so that the correct methods of derived classes are invoked.

    // Create a BankBranch class as in the class diagram below so that an instance of the class 
    // may contain all the BankAccount objects that have been created.

        // My Attempt:

    class Workshop_05_1_BankAccount_Polymorphism
    {
        public int acctNumber;
        public string acctHolderId;
        private double balance;
        public double interestEarned;
        public double interestPaid;
        public bool balanceIsNeg;
        public double depositAmt;

        public Workshop_05_1_BankAccount_Polymorphism()
        {

        }

        public Workshop_05_1_BankAccount_Polymorphism(string b, int a)
        {
            acctHolderId = b;
            acctNumber = a;
        }


        public void Withdraw(double amt)
        {
            if (balanceIsNeg == true)
            {
                Console.WriteLine("There is insufficent amount to withdraw");
            }
            else
            {
                balance -= amt;
            }
            
        }

        public void Deposit(double amt)
        {
            this.depositAmt = amt;
            balance += depositAmt;
        }

        public void TransferTo(double amt, Workshop_05_1_BankAccount_Polymorphism bankAccount)
        {
            this.balance -= amt;
            bankAccount.balance += amt;
        }

        public virtual void CalculateInterest(double interest)
        {
            interestEarned = balance * (interest / 100);
        }

        public virtual void CreditInterest()
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


        public virtual bool TestBalance()
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


    class Workshop_05_1_BankAccount_Polymorphism_SavingAccount : Workshop_05_1_BankAccount_Polymorphism
    {
        
        public Workshop_05_1_BankAccount_Polymorphism_SavingAccount(string b, int a) : base(b, a)
        {

        }

        public override bool TestBalance()
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


        public override void CalculateInterest(double interest)
        {
            if (balanceIsNeg == true)
            {
                interestEarned = 0;

            }
            else
            {
                interestEarned = GetBalance() * (interest/100);
                // 1% interest = 1/100 = 0.01

            }
        }

    }


    class Workshop_05_1_BankAccount_Polymorphism_CurrentAccount : Workshop_05_1_BankAccount_Polymorphism
    {
        

        public Workshop_05_1_BankAccount_Polymorphism_CurrentAccount(string b1, int a1) : base(b1, a1)
        {


        }

        public override bool TestBalance()
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

        public override void CalculateInterest(double interest)
        {
            if (balanceIsNeg == true)
            {
                interestEarned = 0;

            }
            else
            {
                interestEarned = GetBalance() * (interest / 100);

            }
        }


    }

    class Workshop_05_1_BankAccount_Polymorphism_OverDraftAccount : Workshop_05_1_BankAccount_Polymorphism
    {
        

        public Workshop_05_1_BankAccount_Polymorphism_OverDraftAccount(string b2, int a2) : base(b2, a2)
        {


        }

        public override bool TestBalance()
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

        public override void CalculateInterest(double interest)
        {
            if (balanceIsNeg == true)
            {
                interestPaid = GetBalance() * (0.06);
                // admin fee of 6% = 6/100 = 0.06
            }
            else
            {
                interestEarned = GetBalance() * (interest / 100);
            }
        }

        public override void CreditInterest()
        {
          
            if (balanceIsNeg == true)
            {
                double balance01 = GetBalance();
                balance01 += interestPaid;
                SetBalance(balance01);  
            }
            else
            {
                double balance02 = GetBalance();
                balance02 += interestEarned;
                SetBalance(balance02);
            }
        }

    }

    class Workshop_05_1_BankAccount_Polymorphism_test
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
                Workshop_05_1_BankAccount_Polymorphism_SavingAccount savingAcct = new Workshop_05_1_BankAccount_Polymorphism_SavingAccount(bAcctId, aNumber);
                savingAcct.SetBalance(5000.00);

                Console.WriteLine($"Your saving account {aNumber} current balance is $ {savingAcct.GetBalance():0.00}. \n");

                savingAcct.TestBalance();
                savingAcct.CalculateInterest(1.00);
                savingAcct.CreditInterest();

                Console.WriteLine($"Interest earned = ${savingAcct.interestEarned:0.00}");
                Console.WriteLine($"Total Amount in saving account with interest = ${savingAcct.GetBalance():0.00}");

            }
            else if (selectedOption == 2)

            {
                Workshop_05_1_BankAccount_Polymorphism_CurrentAccount currentAcct = new Workshop_05_1_BankAccount_Polymorphism_CurrentAccount(bAcctId, aNumber);
                currentAcct.SetBalance(2000.00);

                Console.WriteLine($"Your current account {aNumber} current balance is $ {currentAcct.GetBalance():0.00}. \n");

                currentAcct.TestBalance();
                currentAcct.CalculateInterest(0.25);
                currentAcct.CreditInterest();

                Console.WriteLine($"Interest earned = ${currentAcct.interestEarned:0.00}");
                Console.WriteLine($"Total amount in current account with interest = ${currentAcct.GetBalance():0.00}");

            }
            else if (selectedOption == 3)
            {
                Workshop_05_1_BankAccount_Polymorphism_OverDraftAccount oDAcct = new Workshop_05_1_BankAccount_Polymorphism_OverDraftAccount(bAcctId, aNumber);
                oDAcct.SetBalance(-90);

                Console.WriteLine($"Your over-draft account {aNumber} current balance is $ {oDAcct.GetBalance():0.00}. \n");

                oDAcct.TestBalance();
                oDAcct.CalculateInterest(0.25);
                oDAcct.CreditInterest();

                Console.WriteLine("Your account is negative, no interest is earned. ");
                Console.WriteLine($"Please pay $ {-oDAcct.interestPaid: 0.00} as administrative fees for negative balance.");
                Console.WriteLine($"Total amount owe to over-draft account (with interest) = $ {- oDAcct.GetBalance(): 0.00}");


            }
        }
    }

}

