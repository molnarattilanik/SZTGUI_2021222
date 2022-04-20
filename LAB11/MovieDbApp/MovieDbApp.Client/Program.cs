using ConsoleTools;
using MovieDbApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDbApp.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor Name: ");
                string name = Console.ReadLine();
                rest.Post(new Actor() { ActorName = name }, "actor");
            }
        }
        static void List(string entity)
        {
            if (entity == "Actor")
            {
                List<Actor> actors = rest.Get<Actor>("actor");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.ActorId + ": " + item.ActorName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Actor one = rest.Get<Actor>(id, "actor");
                Console.Write($"New name [old: {one.ActorName}]: ");
                string name = Console.ReadLine();
                one.ActorName = name;
                rest.Put(one, "actor");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "actor");
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:53910/","movie");

            var actorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Actor"))
                .Add("Create", () => Create("Actor"))
                .Add("Delete", () => Delete("Actor"))
                .Add("Update", () => Update("Actor"))
                .Add("Exit", ConsoleMenu.Close);

            var roleSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Role"))
                .Add("Create", () => Create("Role"))
                .Add("Delete", () => Delete("Role"))
                .Add("Update", () => Update("Role"))
                .Add("Exit", ConsoleMenu.Close);

            var directorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Director"))
                .Add("Create", () => Create("Director"))
                .Add("Delete", () => Delete("Director"))
                .Add("Update", () => Update("Director"))
                .Add("Exit", ConsoleMenu.Close);

            var movieSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Movie"))
                .Add("Create", () => Create("Movie"))
                .Add("Delete", () => Delete("Movie"))
                .Add("Update", () => Update("Movie"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Movies", () => movieSubMenu.Show())
                .Add("Actors", () => actorSubMenu.Show())
                .Add("Roles", () => roleSubMenu.Show())
                .Add("Directors", () => directorSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
