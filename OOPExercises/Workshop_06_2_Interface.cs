using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{
    // Workshop 6.2 - Sorting and ordering via IComparable interface
    // implementation of int CompareTo() method to compare Customer Balance 
    // implementation of int CompareTo() method to compare Customer Name

        // My Attempt:

    class Workshop_06_2_Interface
    {

        public static void printNumbers(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number);
                Console.Write(" ");
            }

            Console.WriteLine("\n");
        }

        public static void printCustomers(Customer[] customers)
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        public static void Main(string[] args)
        {
            int[] numbers = { 0, 6, 4, 8, 10 };

            Console.WriteLine("Numbers before sorting");
            printNumbers(numbers);

            Array.Sort(numbers);

            Console.WriteLine("Numbers after sorting");
            printNumbers(numbers);

            Customer c1 = new Customer("Tan Ah Kow", "4 Short Street", 2000);
            Customer c2 = new Customer("Tan Ah Lian", "81 Berry Road", 1500);
            Customer c3 = new Customer("Tan Aaron", "81 Berry Road", 1700);
            Customer c4 = new Customer("Ben Lim", "67 Lorry Road", 1900);

            Customer[] customers = { c1, c2, c3, c4 };

            Console.WriteLine("Customers before sorting");
            printCustomers(customers);

            // automatically calls out to iComparable
            Array.Sort(customers);

            Console.WriteLine("\nCustomers after sorting");
            printCustomers(customers);

            Console.ReadKey();
        }
    }

    public class Customer : IComparable<Customer>
    {
        private string name;
        private string address;
        private double balance;

        public string Name
        {
            get { return name; }
        }
        
        public string Address
        {
            get { return address; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public Customer (string n, string a, double b)
        {
            name = n;
            address = a;
            balance = b;
        }

        // must implement for IComparable of objects
        // comparision of balance
        /*
        public int CompareTo(Customer anotherCustomer)
        {
            if(this.balance < anotherCustomer.balance)
            {
                return -1;
            }
            else if (this.balance > anotherCustomer.balance)
            {
                return 1;
            }else  
            {
                return 0;
            }
        }
        */

        // comparision of name    
        public int CompareTo(Customer otherCustomer)
        {
            int outcome = String.Compare(this.name, otherCustomer.name);
            // String.Compare will return an integer
            
            if (outcome == 1)
            {
                return 1;
            }
            else if (outcome == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        

        public override string ToString()
        {
            return String.Format("[Name= {0}, Address= {1}, Balance= {2}]", this.Name, this.Address, this.Balance);
        }

    
    }

  
}
