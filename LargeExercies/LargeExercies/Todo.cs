using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LargeExercies
{
    internal static class Todo
    {
        public static void ListMenu()
        {
            Console.Clear();
            bool running = true;
            while (running)
            {
                Console.WriteLine("");
                int selectedOption = Menu.ShowMenu("TODO Menu", new[]
                {
                "Add task",
                "View tasks",
                "Finish task",
                "Exit"
            });
                switch (selectedOption)
                {
                    case 0:
                        List();
                        break;

                    case 1:
                        ViewList();
                        break;

                    case 2:
                        FinishTask();
                        break;

                    case 3:
                        running = false;
                        break;

                    default:
                        break;
                }
            }
        }

        public static void List()
        {
            Console.Clear();
            List<string> todo = new List<string>();
            Console.WriteLine("Enter todo: ");
            string input = Console.ReadLine();
            todo.Add(input);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\empir\Documents\List.txt", true))
            {
                file.WriteLine(input);
            }

            Console.WriteLine($"{input} added.");
        }

        public static void ViewList()
        {
            Console.Clear();
            string text = System.IO.File.ReadAllText(@"C:\Users\empir\Documents\List.txt");
            Console.WriteLine("--------TODO LIST--------");
            Console.WriteLine(text);
            Console.WriteLine("-------END OF LIST-------");
        }

        public static void FinishTask()
        {
            Console.Clear();
            string text = File.ReadAllText(@"C:\Users\empir\Documents\List.txt");
            List<string> todos = new List<string>();
            var result = Regex.Split(text, "\r\n|\r|\n");

            foreach (string s in result)
            {
                todos.Add(s);
            }
            Console.WriteLine("Which task is completed?");
            Console.WriteLine("-----------------------");
            foreach (string a in todos)
            {
                Console.WriteLine(a);
            }
            string input = Console.ReadLine();
            foreach (string b in todos)
            {
                if (input == b)
                {
                    string item = input;
                    var lines = File.ReadAllLines(@"C:\Users\empir\Documents\List.txt").Where(line => line.Trim() != item).ToArray();
                    Console.WriteLine($"{item} removed from list.");
                    File.WriteAllLines(@"C:\Users\empir\Documents\List.txt", lines);
                }
            }
        }
    }
}