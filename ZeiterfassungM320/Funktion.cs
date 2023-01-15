using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungsprogramm
{
    public class Funktion {

        public string Bezeichnung { get; set; }
        public int Lohn { get; set; }

        // Konstruktor
        public Funktion(string bezeichnung, int lohn) {
            Bezeichnung = bezeichnung;
            Lohn = lohn;
        }

    }
}
