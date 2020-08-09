using System;

namespace MonteCarloMethod
{
    class Program
    {
        static (double, double) RandomPointGenerator(Random R)
        {
            double x = R.NextDouble();
            double y = R.NextDouble();

            //Console.WriteLine($"{x}      {y}");
            return (x, y);
        }

        static double hypotenesuse(double A, double B) => Math.Sqrt((A * A) + (B * B));


        static void Main(string[] args)
        {
            int iterations = 10;
            if (args.Length > 0) iterations = Int32.Parse(args[0]);
            Console.WriteLine($"try running {iterations} times:    ");

            int countInsideCircle = 0;
            Random R = new Random();
            double x, y, z;

            for (int i = 0; i < iterations; i++)
            {
                (x, y) = RandomPointGenerator(R);
                z = hypotenesuse(x, y);
                if (z <= 1.0) countInsideCircle++;
                //Console.WriteLine(".");
            }
            double result = (double)countInsideCircle / (double)iterations;
            Console.WriteLine($"{ result * 4.0}");
            Console.WriteLine(Math.PI);
        }
    }
}
//1. Why do we multiply the value from step 5 above by 4?
//We need to multiply the step 5 value by 4 to capture a full circle. Without, we are capturing one quadrant.

//2. What do you observe in the output when running your program with parameters of increasing size?
//With increased parameters, x and y provide more values and the value of result can carry a more extensive decimal place.

//3. If you run the program multiple times with the same parameter, does the output remain the same? Why or why not?
//The output changes due to the random values of x and y, therefore instances can vary.

//4. Find a parameter that requires multiple seconds of run time. What is that parameter?
//hypotenesuse(x, y) required a large portion of the run time.

//5. How accurate is the estimated value of pi?
//The largest available input of iterations results with 3.14152978, which is 99.99% accurate.

//6. Research one other use of Monte-Carlo methods.Record it in your exercise submission and be prepared to discuss it in class.
//Monte-Carlo methods are used to identify a probability of different outcomes through the use of random variables. 