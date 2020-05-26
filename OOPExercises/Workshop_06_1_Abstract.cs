using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{
    // Workshop 6.1 - Abstract Classes and Interfaces
    // 6.1 Abstract Shape class
    // Returning to Workshop 1 where you worked on various geometric shapes such as Triangle and Rectangle.
    // a. What common attributes or methods might be more appropriately refactored into a base class?
    // b. What methods in the base class might be more appropriately annotated as abstract?
    // c. Enhance your geometric shape classes Triangle and Rectangle using an abstract base class.

    // My Attempt:

    public abstract class Workshop_06_1_Abstract
    {

        // abstract method for Area & Perimeter
        public abstract double Area();
        public abstract double Perimeter();

        // an abstract property 
        public abstract double shapeBase
        {
            get;
            set;
        }

        //public double shapeBase;
        public abstract double Height
        {
            get;
            set;
        }

    }

    public class Triangle : Workshop_06_1_Abstract
    {
        private double triangleBase;
        private double triangleHeight;
        public double area;
        public double perimeter;
        private double side01;
        private double side02;

        public Triangle()
        {

        }

        public override double shapeBase
        {
            get { return triangleBase; }

            // value is reserved word
            set { triangleBase = value; }
        }

        public override double Height
        {
            get { return triangleHeight; }

            // value is reserved word
            set { triangleHeight = value; }
        }

        public override double Area()
        {
            area = triangleBase * triangleHeight * 0.5;
            return area;
        }

        public double Side01
        {
            get { return side01; }
            set { side01 = value; }
        }

        public double Side02
        {
            get { return side02; }
            set { side02 = value; }
        }

        public override double Perimeter()
        {
            perimeter = side01 + side02 + triangleBase;

            return perimeter;
        }

    }

    public class Rectangle : Workshop_06_1_Abstract
    {
        private double rectangleBase;
        private double rectangleLength;
        public double area;
        public double perimeter;

        public Rectangle()
        {

        }

        public override double shapeBase
        {
            get { return rectangleBase; }
            set { rectangleBase = value; }
        }

        public override double Height
        {
            get { return rectangleLength; }
            set { rectangleLength = value; }
        }

        public override double Area()
        {
            area = rectangleBase * rectangleLength;
            return area;
        }

        public override double Perimeter()
        {
            perimeter = 2 * rectangleBase + 2 * rectangleLength;
            return perimeter;
        }

    }

    public class Workshop_06_1_Abstract_test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Math Magic Box.");
            Console.WriteLine("Please put your right hand into the box to pick a shape.\n");
            Console.WriteLine("Picking ... ...\n");
            Console.WriteLine("Congratulations, you have picked a triangle! \n");

            Console.WriteLine("Please enter the measurement of the triangle base: ");
            double triangleBase01 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the measurement of the triangle height: \n");
            double triangleHeight01 = Convert.ToDouble(Console.ReadLine());

            Triangle triangle01 = new Triangle();
            triangle01.shapeBase = triangleBase01;
            triangle01.Height = triangleHeight01;
            triangle01.Area();
            
            Console.WriteLine($"Area of triangle = {triangle01.area} units sq. \n");

            Console.WriteLine("Now, lets continue to explore the perimeter of the triangle... ...");
            Console.WriteLine("Please enter the measurement of one side of the triangle (aside from the base and assuming that base is the longest side of the triangle) : ");
            double triangleSide01 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the measurement of the other side of the triangle (aside from the base and assuming that base is the longest side of the triangle): ");
            double triangleSide02 = Convert.ToDouble(Console.ReadLine());

            // logic rule for triangles 
            if (triangleSide01 + triangleSide02 > triangleBase01)
            {
                triangle01.Side01 = triangleSide01;
                triangle01.Side02 = triangleSide02;
                triangle01.Perimeter();

                Console.WriteLine($"Perimeter of triangle = {triangle01.perimeter} units \n");
                Console.WriteLine("Great Job, you have finished the triangle round.\n");

            }
            else
            {
                
                while(triangleSide01 + triangleSide02 < triangleBase01 || triangleSide01 + triangleSide02 == triangleBase01)
                {
                    Console.WriteLine("Both sides add together must be more than the triangle base.");
                    Console.WriteLine("Please enter the measurement of one side of the triangle (aside from the base and assuming that base is the longest side of the triangle) : ");
                    triangleSide01 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter the measurement of the other side of the triangle (aside from the base and assuming that base is the longest side of the triangle): ");
                    triangleSide02 = Convert.ToDouble(Console.ReadLine());
                }

                triangle01.Side01 = triangleSide01;
                triangle01.Side02 = triangleSide02;
                triangle01.Perimeter();

                Console.WriteLine($"Perimeter of triangle = {triangle01.perimeter} units \n");
                Console.WriteLine("Great Job, you have finished the triangle round.\n");

            }

            
            Console.WriteLine("Now, lets go back to the Math Magic Box to pick out another shape.");
            Console.WriteLine("Picking ... ...\n");
            Console.WriteLine("Congratulations, you have picked a rectangle! \n");

            Console.WriteLine("Please enter the measurement of the rectangle base: ");
            double rectangleBase01 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the measurement of the rectangle height: \n");
            double rectangleHeight01 = Convert.ToDouble(Console.ReadLine());

            Rectangle rectangle01 = new Rectangle();
            rectangle01.shapeBase = rectangleBase01;
            rectangle01.Height = rectangleHeight01;
          
            rectangle01.Area();
            rectangle01.Perimeter();

            Console.WriteLine($"Area of rectangle = {rectangle01.area} units sq. \n");        
            Console.WriteLine($"Perimeted of triangle = {rectangle01.perimeter} units sq. \n");

            Console.WriteLine($"Thank you for coming to play the the Math Magic Box. Hope u have enjoy the session!");

        }
    }

}
