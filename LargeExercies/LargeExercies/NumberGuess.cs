using System;

namespace LargeExercies
{
    internal static class NumberGuess
    {
        public static void RunGame()
        {
            Console.Clear();
            Random rand = new Random();
            int guess = 0;
            const string welcome = "Guess a number between 1 and 10";
            int num = rand.Next(1, 10);
            Console.WriteLine(welcome);

            int i = 0;

            while (guess != num)
            {
                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());

                    if (guess > num)
                    {
                        Console.WriteLine("Too High");
                    }
                    else
                    {
                        Console.WriteLine("Too Low");
                    }
                }
                catch
                {
                    Console.WriteLine("Guess must be a number");
                    i--;
                }

                i++;
            }
            Console.WriteLine("Congrats, it took you " + i + " tries. Press any key to exit.");
            Console.ReadLine();
        }
    }
}