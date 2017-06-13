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
    static void Main (string[] args)
    {
        var subject = new Subject<car>();

        subject
            .Where(myClassObject => myClassObject.Farbe.StartsWith("y"))
            .Subscribe(filteredMyClassObject =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{filteredMyClassObject.Farbe}");
            });

        subject.OnNext(new car("red", 2.2));
        subject.OnNext(new car("yellow", 9.9));
        subject.OnNext(new car("green", 7.1));
        subject.OnNext(new car("yellow-green", 1.9));
        subject.OnNext(new car("black", 5.2));
        subject.OnNext(new car("white", 4.2));

        subject.Dispose();

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

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
   
}