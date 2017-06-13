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




class Program
{
    static void Main(string[] args)
    {
        //PullExample.Run(); 

        //PushExample.Run(); 
        PushExampleWithSubject.Run();


        //TasksExample.Run();
    }



    public static class PushExampleWithSubject
    {
        public static void Run()
        {
            var source = new Subject<int>();

            source
                .Sample(TimeSpan.FromSeconds(2.0))
                .Subscribe(x => Console.WriteLine($"received {x}"))
                ;

            var t = new Thread(() =>
            {
                var i = 0;
                while (true)
                {
                    Thread.Sleep(2500);
                    source.OnNext(i);
                    Console.WriteLine($"sent {i}");
                    i++;
                }
            });


            t.Start();
        }

    }


    public static class TasksExample
    {

        public static void Run()

        {

            var random = new Random();
            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var tasks = new List<Task<int>>();

            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {

                    WriteLine($"computing result for {x}");
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait();
                    WriteLine($"done computing result for {x}");
                    return x * x;
                });
                tasks.Add(task);
            }

            WriteLine("doing something else ...");
            var tasks2 = new List<Task<int>>();
            foreach (var task in tasks.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(t => { WriteLine($"result is {t.Result}"); return t.Result; })
                    );
            }

            var cts = new CancellationTokenSource();
            var primeTask = ComputePrimes(cts.Token);


            ReadLine();
            cts.Cancel();
            WriteLine("canceled ComputePrimes");


            ReadLine();
        }



        public static Task<bool> IsPrime(int x, CancellationToken ct)
        {
            return Task.Run(() =>
            {
                for (var i = 2; i < x - 1; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    if (x % i == 0) return false;
                }
                return true;
            }, ct);
        }


        public static async Task ComputePrimes(CancellationToken ct)
        {
            for (var i = 100000000; i < int.MaxValue; i++)
            {
                ct.ThrowIfCancellationRequested();
                if (await IsPrime(i, ct)) WriteLine($"prime number: {i}");
            }
        }
    }
}


public class car
{
    private double carweight;

  
    public car(string farbe, double weight)
    {
        Farbe = farbe;
        carweight = weight;
    }



    public car(string colour, double weight, string currency)
    {
        if (string.IsNullOrWhiteSpace(colour)) throw new ArgumentException("colour must not be empty.", nameof(colour));

        Farbe = colour;
        carweight = weight;
    }


    public string Farbe { get; }


    public double Weight => carweight;


    #region ItemA Implementation

    public double newWeight(double kg, string Einheit)
    {
        if (kg <= 0) return kg;

        if (Einheit == "pfund")
        {
            return kg * 0.453; //konvert kg to pound
        }

        return kg;

    }

    public void printall()
    {
        Console.WriteLine($"CAR: {Farbe} , {carweight} ");
    }
    #endregion 
}