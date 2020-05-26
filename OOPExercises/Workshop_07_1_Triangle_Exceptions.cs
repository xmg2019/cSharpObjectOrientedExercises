using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{

    // Workshop 7 - Using Exceptions
    // 7.1 Triangle Exception
    // a. Consider the earlier Workshop on the Triangle class and identify possible error scenarios -- for example, the sides might not represent a valid triangle.
    // b.Define suitable Exception class(es) to represent the appropriate erroneous situation(s).
    // c.Identify this situation in your code and throw the Exception object to highlight this situation to developers who are reusing the Triangle class.
    // d.Modify the test harness code which uses the Triangle class to handle the newly thrown Exception object.

        // My Attempt

    class Workshop_07_1_Triangle_Exceptions
    {
        public static void TriangelDimensions()
        {
            
            Console.WriteLine(" Qn 1: Please enter the measurement of the triangle base: ");
            double triB01 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(" Qn 2: Please enter the measurement of one side of the triangle (aside from the base and assuming that base is the longest side of the triangle) : ");
            double triS01 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(" Qn 3: Please enter the measurement of the other side of the triangle (aside from the base and assuming that base is the longest side of the triangle): ");
            double triS02 = Convert.ToDouble(Console.ReadLine());

            // Console.WriteLine("Congratulations, you have picked a triangle! \n");

            if(triS01 + triS02 <= triB01)
            {
                throw new Exception(" Error!!! Both sides of triangle added together should exceed base measurement!");
            }
            else
            {
                TriangleTest triTest01 = new TriangleTest();
                triTest01.TriBase = triB01;
                triTest01.TriSide01 = triS01;
                triTest01.TriSide02 = triS02;
                triTest01.TriArea();
                triTest01.TriPerimeter();

                Console.WriteLine($"Perimeter of triangle = {triTest01.Perimeter} units \n");
                Console.WriteLine("Great Job, you have finished the triangle round.\n");
            }


            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Exception Testing session.");
            Console.WriteLine("Today, we are going to test on your concept of what makes a triangle.");
            Console.WriteLine("\nFirst, you got to answer the following questions: ");

            try
            {
                TriangelDimensions();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: ");
                Console.WriteLine(e.Message);
            }
        }
    }

    public class TriangleTest
    {
        private double triBase;
        private double triHeight;
        public double Area;
        public double Perimeter;
        private double Side01;
        private double Side02;

        public TriangleTest()
        {

        }

        public double TriBase
        {
            get { return triBase; }
            set { triBase = value; }
        }

        public double TriHeight
        {
            get { return triHeight; }

            // value is reserved word
            set { triHeight = value; }
        }

        public double TriArea()
        {
            Area = triBase * triHeight * 0.5;
            return Area;
        }

        public double TriSide01
        {
            get { return Side01; }
            set { Side01 = value; }
        }

        public double TriSide02
        {
            get { return Side02; }
            set { Side02 = value; }
        }

        public double TriPerimeter()
        {
            Perimeter = Side01 + Side02 + triBase;

            return Perimeter;
        }

    }

  
}
