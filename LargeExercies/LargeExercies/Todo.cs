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
                "Search tasks",
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
                        Search();
                        break;

                    case 3:
                        FinishTask();
                        break;

                    case 4:
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
            var todo = new List<string>();
            Console.WriteLine("Enter todo: ");
            var input = Console.ReadLine();
            todo.Add(input);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\liamb\Documents\List.txt", true))
            {
                file.WriteLine(input);
            }

            Console.WriteLine($"{input} added.");
        }

        public static void ViewList()
        {
            Console.Clear();
            try
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\liamb\Documents\List.txt");
                Console.WriteLine("--------TODO LIST--------");
                Console.WriteLine(text);
                Console.WriteLine("-------END OF LIST-------");
            }
            catch (Exception)
            {
                Console.WriteLine("Path not found");
            }
        }

        public static void FinishTask()
        {
            Console.Clear();
            var text = File.ReadAllText(@"C:\Users\liamb\Documents\List.txt");
            var result = Regex.Split(text, "\r\n|\r|\n");

            var todos = result.ToList();
            Console.WriteLine("Which task is completed?");
            Console.WriteLine("-----------------------");
            foreach (var a in todos)
            {
                Console.WriteLine(a);
            }
            var input = Console.ReadLine();
            foreach (var b in todos)
            {
                if (input == b)
                {
                    string item = input;
                    var lines = File.ReadAllLines(@"C:\Users\liamb\Documents\List.txt").Where(line => line.Trim() != item).ToArray();
                    Console.WriteLine($"{item} removed from list.");
                    File.WriteAllLines(@"C:\Users\liamb\Documents\List.txt", lines);
                }
            }
        }

        public static void Search()
        {
            Console.Clear();
            string text = File.ReadAllText(@"C:\Users\liamb\Documents\List.txt");
            var todos = new List<string>();
            var result = Regex.Split(text, "\r\n|\r|\n");

            foreach (string s in result)
            {
                todos.Add(s);
            }
            Console.WriteLine("Enter task name: ");
            var input = Console.ReadLine();

            foreach (var s in result)
            {
                if (s.Contains(input!))
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}