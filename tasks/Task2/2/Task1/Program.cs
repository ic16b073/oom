using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



internal class Program
    {
        static void Main(string[] args)
        {

        var bike = new List<bike>
           {
               new bike("Crazy Red Star", 101, 10),
               new bike("Blue Speedster", 102, 9),
               new bike("black jumper", 103, 13),
               new bike("pink beauty", 104, 11)
           };

        foreach (var c in bike)
        {
            Console.WriteLine($"Fahrrad: {c.Name}\nNummer: {c.Framenumber}\nGewicht: {c.GetWeight()}\n-----------------------------------------");
        }

        Console.WriteLine("||||||||||||||||||||||||||||||");

        foreach (var b in bike)
        {
            b.UpdateWeight(10);
        }

        foreach(var c in bike)
        {
            Console.WriteLine($"Fahrrad: {c.Name}\nNummer: {c.Framenumber}\nGewicht: {c.GetWeight()}\n-----------------------------------------");
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

