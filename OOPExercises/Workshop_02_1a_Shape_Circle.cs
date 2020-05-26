using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{

    // Workshop 02 - Implementing & Using Objects
    // 1. Implement Shape Classes
    // a. Create the Circle class & implement methods - Area() & Perimeter()
    // Write a driver program (i.e. a suitable static void Main() method) to test your classes 
    // by instantiating appropriate objects and sending them corresponding messages to execute methods.

    // My Attempt:

    class Workshop_02_1a_Shape_Circle
    {

        private double radius;
        public double area;
        public double perimeter;

        public Workshop_02_1a_Shape_Circle()
        {

        }

        public double Area()
        {
            area = Math.PI*radius*radius;
            return area;
        }

        public double Perimeter()
        {
            perimeter = Math.PI * radius * 2;
            return perimeter;
        }

        public double getRadius()
        {
            return radius;
        }

        public void setRadius (double input)
        {
            radius = input;

        }

        static void Main (string[] args)
        {
            Console.WriteLine("Please enter a value for radius of a circle: ");
            double radiusValue = double.Parse(Console.ReadLine());

            Workshop_02_1a_Shape_Circle c01 = new Workshop_02_1a_Shape_Circle();
            c01.setRadius(radiusValue);

            Console.WriteLine($"Area of Circle : {c01.Area():0.00}");
            Console.WriteLine($"Perimeter of Circle : {c01.Perimeter():0.00}");
        }

    }
}
