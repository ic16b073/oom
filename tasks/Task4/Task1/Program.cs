using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO; //for File.

internal class Program
    {

    static void printbike(bike x)
    {
        Console.WriteLine($"{x.Name}: Nummer: {x.Framenumber}, Gewitcht: {x.GetWeight()}");
    }

    static void convertweight()
    {

    }


    static void Main(string[] args)
    {
        //task2
        Console.WriteLine("Namen des 1. Fahrrades eingeben");
        string typ = Console.ReadLine();

        Console.WriteLine("Namen des 2. Fahrrades eingeben");
        string typ2 = Console.ReadLine();


        bike a = new bike(typ, 111, 11);
        bike b = new bike(typ2, 110, 10);

        printbike(a);
        printbike(b);

        Console.WriteLine("Neues Gewicht des Fahrrades <A> eingeben");
        double newgewicht = Convert.ToInt32(Console.ReadLine());
        a.UpdateWeight(newgewicht);
        printbike(a);

        Console.WriteLine("Neues Gewicht des Fahrrades <B> eingeben");
        double newgewicht2 = Convert.ToInt32(Console.ReadLine());
        b.UpdateWeight(newgewicht2);
        printbike(b);

        Console.WriteLine("\nxXxXxXxX-TASK3-XxXxXxXx");
        //Task3

        car x = new car("red", 1000, "kg");

        Console.WriteLine("\nCalculating Weights with new Array 200.2, 250.9, 920.2, 400.1, 601.5");

        var doublearray = new[] { 200.2, 250.9, 920.2, 400.1, 601.5 };
        var result = new double[doublearray.Length];
        for (var i = 0; i < doublearray.Length; i++)
        {
            result[i] = a.newWeight(doublearray[i], "pound");
        }
        for(var i = 0; i< result.Length; i++)
        {
            Console.WriteLine($"Wert {i}: {result[i]}");
        }

        Console.WriteLine("\n_______Weights in Pounds_____________");
        for (var i = 0; i < doublearray.Length; i++)
        {
            result[i] = x.newWeight(doublearray[i], "pfund");
        }
        for (var i = 0; i < result.Length; i++)
        {
            Console.WriteLine($"Wert {i}: {result[i]}");
        }


        //task4
        Console.WriteLine("\nxXxXxXxX-Task4-XxXxXxXx\n");

        bike[] array = new bike[3];
        for(var i= 0; i<3; i++)
        {
            array[i] = new bike($"arraybike {i}", i + 1000, i + 50);
            
        }
        File.WriteAllText(@"c:\Users\scheidl\oom\tasks\Task4\bikes.json", JsonConvert.SerializeObject(array));

        //array = null;
        bike[] array2 = JsonConvert.DeserializeObject<bike[]>(File.ReadAllText(@"c:\Users\scheidl\oom\tasks\Task4\bikes.json"));

        for (var i = 0; i < 3; i++)
        {
            Console.WriteLine($"{array2[i].Name} : {array2[i].Framenumber}");
        }


    }
}



    
interface ItemA
{
    double newWeight(double value, string cur);
}




[TestFixture]
public class car : ItemA
{       
    private double carweight;

    
    public car (string colour, double kg, string currency )
    { 
        if (string.IsNullOrWhiteSpace(colour)) throw new ArgumentException("colour must not be empthy.", nameof(colour));
              
        Farbe = colour;
        carweight = kg;
        
    }

    
    public string Farbe { get; }

    [Test]
    public double GetWeight() => carweight;


    #region ItemA Implementation
    [Test]
    public double newWeight(double kg, string Einheit)
    {
        if (kg <= 0) return kg;

        if (Einheit == "pfund")
        {
            return kg * 0.453; //konvert kg to pound
        }

        return kg;
        
    }
    #endregion 
}





[TestFixture]
public class bike : ItemA
{
    //private field
    private double weight;

       
    //Constructor
    public bike(string name, int framenumber, double partweight)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name must not be empty.", nameof(name));

        Framenumber = framenumber;
        Name = name;

        UpdateWeight(partweight);
    }

    [Test]
    public double GetWeight() => weight;        //abgekürzte schreibweise für return;


    //from ItemA
    public string Name { get; }
    //Public Property
    public int Framenumber { get; }


    //public method from ItemA
    [Test]
    public void UpdateWeight(double partweight)
    {
    if (partweight < 0) throw new ArgumentException("partweight must be higher than zero", nameof(partweight));
            weight = partweight;
    }

    #region ItemA Implementation
    [Test]
    public double newWeight(double partweight, string Name) => partweight;

    #endregion 
}

