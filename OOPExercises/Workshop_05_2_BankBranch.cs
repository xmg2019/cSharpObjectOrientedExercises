using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{
    // Workshop 5 - Polymorphism
    // 5.2 BankBranch
    // Create a BankBranch class as in the class diagram below so that an instance of the class 
    // may contain all the BankAccount objects that have been created, along with the following attributes & methods
    // Attributes: BranchName (string), BranchManager(string), BankAccounts (list of BankAccount)
    // Methods: AddAccount(BankAccount), PrintCustomers() - print out all the account holders' ID
    // Methods: TotalDeposits() - print out all the deposits of the account, 
    // Methods: TotalInterestPaid() - sum of interests paid out to all accounts, TotalInterestEarned() - sum of interests earned from all accounts ( overdraft accounts with negative interests)

        // My Attempt:

    class Workshop_05_2_BankBranch
    {
        public string BranchName;
        public string BranchManager;

        // making a list of bank account objects
        public List<Workshop_05_1_BankAccount_Polymorphism> BankAccounts = new List<Workshop_05_1_BankAccount_Polymorphism>();

        public Workshop_05_2_BankBranch()
        {

        }

        public Workshop_05_2_BankBranch(string branchN, string branchM)
        {
            BranchName = branchN;
            BranchManager = branchM;
        }

        public void AddAccount(Workshop_05_1_BankAccount_Polymorphism bankAcct)
        {
            BankAccounts.Add(bankAcct);
        }

        public void PrintCustomers()
        {
            Console.WriteLine($" List of account holders' IDs: ");

            for (int i=0; i<BankAccounts.Count; i++)
            {
                Workshop_05_1_BankAccount_Polymorphism bankAcct01 = BankAccounts[i];
                Console.WriteLine($" {bankAcct01.acctHolderId}");
            }
        }

        public void TotalDeposits()
        {
            double sum0 = 0;

            for (int j = 0; j < BankAccounts.Count; j++)
            {
                Workshop_05_1_BankAccount_Polymorphism bA = BankAccounts[j];
                sum0 += bA.depositAmt;           
            }
            Console.WriteLine($"\n Sum of Deposits of all bank account: $ {sum0:0.00}");
        }

        public void TotalInterestPaid()
        {
            double sum = 0;

            for (int k = 0; k < BankAccounts.Count; k++)
            {
                 Workshop_05_1_BankAccount_Polymorphism bA01 = BankAccounts[k];
                 sum += bA01.interestEarned;
                // sum += BankAccounts[k].interestPaid;
                // interest paid by the bank to customers

            }
            Console.WriteLine($" Sum of interests paid out to all accounts: $ {sum:0.00}");
        }

        public void TotalInterestEarned()
        {
            double sum01 = 0;

            for (int t = 0; t < BankAccounts.Count; t++)
            {
                 Workshop_05_1_BankAccount_Polymorphism bA02 = BankAccounts[t];
                 sum01 += bA02.interestPaid;
                // sum01 += BankAccounts[t].interestEarned;
                // interested earned from customers in the form of admin fee due to negative fund
            }
            Console.WriteLine($" Sum of interests earned from across all accounts : $ {-sum01:0.00} ");
        }

    }

    class Workshop_05_2_BankBranch_test
    {
        static void Main(string[]args)
        {

            Console.WriteLine(" Welcome to NUSISS Bank Staff Intranet.");
            Console.WriteLine(" Please key in a bank branch name: ");
            string bName = Console.ReadLine();

            Console.WriteLine(" Please key your username: ");
            string mName = Console.ReadLine();      

            // create a saving account
            Workshop_05_1_BankAccount_Polymorphism_SavingAccount savingAcct01 = new Workshop_05_1_BankAccount_Polymorphism_SavingAccount("Tom001", 1001);
            savingAcct01.SetBalance(4000.00);
            savingAcct01.Deposit(800.00);
            savingAcct01.TestBalance();
            savingAcct01.CalculateInterest(1.00);
            savingAcct01.CreditInterest();

            // create a current account
            Workshop_05_1_BankAccount_Polymorphism_CurrentAccount currentAcct01 = new Workshop_05_1_BankAccount_Polymorphism_CurrentAccount("Karen002", 2001);
            currentAcct01.SetBalance(6000.00);
            currentAcct01.Deposit(5000.00);
            currentAcct01.TestBalance();
            currentAcct01.CalculateInterest(0.25);
            currentAcct01.CreditInterest();

            // create an over-draft account
            Workshop_05_1_BankAccount_Polymorphism_OverDraftAccount oDAcct01 = new Workshop_05_1_BankAccount_Polymorphism_OverDraftAccount("Ken003", 3001);
            oDAcct01.SetBalance(-100.00);
            oDAcct01.TestBalance();
            oDAcct01.CalculateInterest(0.25);
            oDAcct01.CreditInterest();

            // create a bank branch
            // then, add all the accounts created above into the list of bank accounts belonging to the bank branch
            Workshop_05_2_BankBranch branch01 = new Workshop_05_2_BankBranch(bName, mName);
            branch01.AddAccount(savingAcct01);
            branch01.AddAccount(currentAcct01);
            branch01.AddAccount(oDAcct01);

            // actions of the bank branch
            branch01.PrintCustomers();
            branch01.TotalDeposits();       
            branch01.TotalInterestPaid();
            branch01.TotalInterestEarned();
        }

    }
}
