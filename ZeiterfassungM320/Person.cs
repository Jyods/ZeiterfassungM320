using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassungsprogramm_old;
using Zeiterfassung;

namespace Zeiterfassung
{
    public abstract class Person
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
    }
}