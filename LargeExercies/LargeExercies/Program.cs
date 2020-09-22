using System;

namespace LargeExercies
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Clear();
            var running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("");
                var selectedOption = Menu.ShowMenu("Menu", new[]
                {
                "Play number guess",
                "Todo list",
                "blue",
                "Exit"
            });

                switch (selectedOption)
                {
                    case 0:
                        NumberGuess.RunGame();
                        break;
                    case 1:
                        Todo.ListMenu();
                        break;
                    case 3:
                        running = false;
                        break;
                }
            }
        }
    }
}