using System; 
using System.Collections.Generic; 
using System.Drawing; 
using System.Linq; 
using System.Reactive.Linq; 
using System.Text; 
using System.Threading; 
using System.Threading.Tasks; 
//using System.Windows.Forms; 
using static System.Console;
using System.Reactive.Subjects;


namespace Task5_Task6
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var car = new[]
            {
            new car("red", 2.2),
            new car("yellow", 9.9),
            new car("green", 7.1),
            new car("yellow-green", 1.9),
            new car("black", 5.2),
            new car("white", 4.2)
            };

           // car_pullExample.Run(car);
           // car_pushExample.Run(car);
            car_runExpample.Run(car);
        }
    }


    public static class car_pullExample
    {
        public static void Run(car[] items)
        {
            var car = items[0];
            var all_weights = items.Select(x => x.carweight).OrderBy(x => x);

            Console.WriteLine("\n ----PULL Expample\n");
            var e = all_weights.GetEnumerator();

            while (e.MoveNext()) Console.WriteLine(">{0}<", e.Current);
            Console.WriteLine("\n ----PULL Expample END\n");
        }
    }


    public static class car_pushExample
    {
        public static void Run(car[] items)
        {
            var car = items[0];
            var source = new Subject<int>();

            source
                .Sample(TimeSpan.FromSeconds(1.0))
                .Subscribe(x => Console.WriteLine($"received {x}"))
                ;

            var t = new Thread(() =>
            {
                var i = 0;
                while (true)
                {
                    Thread.Sleep(100);
                    source.OnNext(i);
                    Console.WriteLine($"sent {i++}");
                }
            });
            t.Start();
        }
    }



    public static class car_runExpample
    {
        public static void Run(car[]items)
        {
            var car = items[0];

            Console.WriteLine("\n RUN EXAMPLE Part1\n");
            var tasks = new List<Task<car>>();
            var all_weights = items.Select(x => x.carweight).OrderBy(x => x);

            foreach (var x in all_weights)
            {
                var task = Task.Run(() =>
                    {
                        Console.WriteLine("fetched: {0}", x);
                    }
                );
            }
            Console.WriteLine("executing something else...");
            Console.WriteLine("\n Part1 END\n");

            Console.WriteLine("\n RUN EXAMPLE Part 2\n");
            var tasks2 = new List<Task<car>>();
            foreach (var task in tasks2.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(t => {Console.WriteLine($"result is {t.Result}"); return t.Result; })
                    );

            }
            Console.WriteLine("\n Part2 END \n");

        }
    }




    public class car
    {


        public car(string farbe, double weight)
        {
            Farbe = farbe;
            carweight = weight;
        }

        public double carweight { get; }
        public string Farbe { get; }

    }
}