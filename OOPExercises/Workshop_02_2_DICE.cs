using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercises
{

    // Workshop 02 - Implementing & Using Objects
    // 2. Implement DICE class
    // Create a DICE Class, define an instance variable faceUp that accepts values from 1 to 6.
    // Define a method Throw(), similar to Flip() in Coin example, but makes use of the Random’s Next(min, max) library method.
    // Define the property StrFaceUp that returns the textual value of faceUp. For example, if faceUp is 1, it returns “one”. If faceUp is 2, it returns “two” and so on.
    // Create 2 static methods TestDice() and TestProbability().
    // Implement TestDice() to test that your Dice class works.
    // Implement TestProbability() Compute and display the probability of obtaining the value 8 from throwing 2 dice (together) a thousand times.
    // Modify TestProbability() such that it takes in a parameter value, from 1 to 12, such that all probabilities from that range can be computed and displayed.


    // My Attempt:

    class Workshop_02_2_DICE
    {
        public int faceUp;   

        public Workshop_02_2_DICE()
        {
            
        }

        public void Throw()
        {
            Random randomNumber = new Random();
            faceUp = randomNumber.Next(1, 6);
        }

        public int getStrFaceUp()
        {
            return faceUp;
        }

        public static void TestDice()
        {
            Workshop_02_2_DICE dice01 = new Workshop_02_2_DICE();
            dice01.Throw();

            Console.WriteLine(" TestDice() ");
            Console.WriteLine(" Throwing the dice... ");
            Console.WriteLine(" Dice's face value: " + dice01.getStrFaceUp());
        }

       public static void TestProbability()
        {
            Workshop_02_2_DICE dice02 = new Workshop_02_2_DICE();
            Workshop_02_2_DICE dice03 = new Workshop_02_2_DICE();

            int d02;  
            int d03; 
            int count=0;


            for(int j = 1; j <=1000; j++)
            {
                dice02.Throw();
                dice03.Throw();

                d02 = dice02.getStrFaceUp();
                d03 = dice03.getStrFaceUp();


                if (d02 + d03 == 8)
                {
                    count++;
                }
                
            }

            Console.WriteLine("\n TestProability() ");
            Console.WriteLine(" After throwing the dices a thousand times ... ... ");
            Console.WriteLine(" No. of count for getting 8 from throwing both dices a thousand times =  " + count++);
            Console.WriteLine($" Proability of getting 8 from throwing both dices a thousand times(approx.) = {(count++ *100/1000)} % ");

        }

        public static void ModifiedTestProbability(int valueOfThrows)
        {
            Workshop_02_2_DICE dice04 = new Workshop_02_2_DICE();
            Workshop_02_2_DICE dice05 = new Workshop_02_2_DICE();

            int d04;
            int d05;
            int count01 = 0;


            for (int j = 1; j <= 1000; j++)
            {
                dice04.Throw();
                dice05.Throw();

                d04 = dice04.getStrFaceUp();
                d05 = dice05.getStrFaceUp();


                if (d04 + d05 == valueOfThrows)
                {
                    count01++;
                }

            }

            Console.WriteLine("\n ModifiedTestProability() ");
            Console.WriteLine(" After throwing the dices a thousand times ... ... ");
            Console.WriteLine(" No. of count for getting " + valueOfThrows + " from throwing both dices a thousand times =  " + count01++);

            Console.WriteLine($" Proability of getting {valueOfThrows} from throwing both dices a thousand times(approx.) = {(count01++ * 100 / 1000)} % ");

        }




        static void Main(string[] args)
        {
            TestDice();

            TestProbability();

            Console.WriteLine("\n Throwing 2 dices once again ... ...  ");
            Console.WriteLine(" Please key a desired total value for the throw (betw 1 to 12)");
            int input = Convert.ToInt32(Console.ReadLine());

            ModifiedTestProbability(input);


        }
    }
}
