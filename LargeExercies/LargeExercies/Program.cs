using System;

namespace LargeExercies
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Clear();
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("");
                int selectedOption = Menu.ShowMenu("Menu", new[]
                {
                "Play number guess",
                "Todo list",
                "blue",
                "Exit"
            });

                if (selectedOption == 0)
                {
                    NumberGuess.RunGame();
                }
                if (selectedOption == 1)
                {
                    Todo.ListMenu();
                }
                if (selectedOption == 3)
                {
                    running = false;
                }
            }
        }
    }
}