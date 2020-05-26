using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{
    // Workshop 02 - Implementing & Using Objects
    // 1. Implement Shape Classes
    // b. Create the Rectangle class & implement methods - Area() & Perimeter()
    // Write a driver program (i.e. a suitable static void Main() method) to test your classes 
    // by instantiating appropriate objects and sending them corresponding messages to execute methods.

    // My Attempt:

    class Workshop_02_1b_Shape_Rectangle
    {
        private double length;
        private double breath;
        public double area;
        public double perimeter;

       public Workshop_02_1b_Shape_Rectangle()
       {

       }

        public double Area ()
        {
            area = length * breath;

            return area;
        }

        public double Perimeter()
        {
            perimeter = 2 * length + 2 * breath;

            return perimeter;
        }

        public double getLength()
        {
            return length;
        }

        public void setLength(double inputLength)
        {
            length = inputLength;          
        }

        public double getBreath()
        {
            return breath;
        }

        public void setBreath(double inputBreath)
        {
            breath = inputBreath;
        }

        static void Main (string[] args)
        {
            Console.WriteLine("Please enter a value as breath of a rectangle: ");
            double breath01 = double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a value as length of a rectangle: ");
            double length01 = double.Parse(Console.ReadLine());

            Workshop_02_1b_Shape_Rectangle rectangle01 = new Workshop_02_1b_Shape_Rectangle();
            rectangle01.setBreath(breath01);
            rectangle01.setLength(length01);

            Console.WriteLine($"Area of rectangle : {rectangle01.Area()}");
            Console.WriteLine($"Perimeter of rectangle : {rectangle01.Perimeter()}");
        }


    }
}
