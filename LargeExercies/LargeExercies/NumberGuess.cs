using System;

namespace LargeExercies
{
    internal static class NumberGuess
    {
        public static void RunGame()
        {
            Console.Clear();
            var rand = new Random();
            var guess = 0;
            const string welcome = "Guess a number between 1 and 10";
            var num = rand.Next(1, 10);
            Console.WriteLine(welcome);

            int i = 0;

            while (guess != num)
            {
                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(guess > num ? "Too High" : "Too Low");
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