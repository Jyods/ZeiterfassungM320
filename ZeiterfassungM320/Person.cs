using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public abstract class Person : IAnzeige
    {
        public string Name { get; set; }
        public int Alter { get; set; }
        public string Arbeit { get; set; }
        public int Urlaub { get; set; }
        public int Arbeitsstunden { get; set; }

        public Person(string name, int alter)
        {
            this.Name = name;
            this.Alter = alter;
        }
        public virtual void Anzeige()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Alter: {Alter}");
            Console.WriteLine($"Arbeit: {Arbeit}");
            Console.WriteLine($"Resturlaub: {Urlaub}");
            Console.WriteLine($"Überzeit: {Arbeitsstunden}");
        }
    }
}