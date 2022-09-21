using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace task_at_lesson_18._09
{
    class Program
    {
        private static string Path = @"C:\Users\HP\source\repos\task at lesson 18.09\task at lesson 18.09\ToDoOutputs.txt";

        static async Task Main(string[] args)
        {
            //                                             JSON, ASYNC

            Console.WriteLine("Please enter the Url that you want");
            string url = Console.ReadLine();
            var awaiter = await GetToDo(url);


            if (awaiter != null)
            {
                 File.WriteAllTextAsync(Path, awaiter.ToString());
            }

            Console.WriteLine("Press X to Exit");
            Console.ReadKey();
        }


        public static async Task<string> GetToDo(string url)
        {
            Console.WriteLine("Show me Daily Activies");
            //string url = "https://jsonplaceholder.typicode.com/todos";
            using var client = new HttpClient();
            //HttpClient client = new HttpClient();

            var activities = await client.GetStringAsync(url);
            return activities;

           
        }
        //FINALIZE metodu avtomatik cagirilir G.C vasitesile her hansi connection varsa, just before object is destroyed...

        //DISPOSE metodunu ozumuz cagiririq...

    }

}
