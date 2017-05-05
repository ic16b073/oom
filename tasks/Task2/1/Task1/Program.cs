using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Namen des 1. Fahrrades eingeben");
            string typ = Console.ReadLine();

            Console.WriteLine("Namen des 2. Fahrrades eingeben");
            string typ2 = Console.ReadLine();
                                   

            bike a = new bike(typ, 111, 11);
            bike b = new bike(typ2, 110, 10);      

            Console.WriteLine("Der Name A ist " + a.Name + " und die Rahmennummer ist " + a.Framenumber + " Derzeitiges Gewicht: " + a.GetWeight() + "kg");
            Console.WriteLine("Der Name B ist " + b.Name + " und die Rahmennummer ist " + b.Framenumber + " Derzeitiges Gewicht: " + b.GetWeight() + "kg");
            

            Console.WriteLine("Neues Gewicht des Fahrrades <A> eingeben");
            double newgewicht = Convert.ToInt32(Console.ReadLine());
            a.UpdateWeight(newgewicht);

            Console.WriteLine("Neues Gewicht des Fahrrades <B> eingeben");
            double newgewicht2 = Convert.ToInt32(Console.ReadLine());
            a.UpdateWeight(newgewicht2);

            Console.WriteLine("Das neue Gewicht von " + a.Name + " ist: " + a.GetWeight() + "kg");
            Console.WriteLine("Das neue Gewicht von " + b.Name + " ist: " + b.GetWeight() + "kg");

        } 
        }
    }

    public class bike
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


        public double GetWeight() => weight;        //abgekürzte schreibweise für return;
    

        //Public Property
        public string Name { get; }
        //Public Property
        public int Framenumber { get; }


        //public method
        public void UpdateWeight(double partweight)
        {
            if (partweight < 0) throw new ArgumentException("partweight must be higher than zero", nameof(partweight));
            weight = partweight;
        }
}

