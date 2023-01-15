using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public class JSONHandling
    {
        public List<Arbeiter> MitarbeiterList { get; set; }
        public List<Ausbilder> AusbilderList { get; set; }
        public List<Lernender> LernenderList { get; set; }
        public List<Funktion> FunktionsListe { get; set; }

        public JSONHandling()
        {
            MitarbeiterList = new List<Arbeiter>();
            AusbilderList = new List<Ausbilder>();
            LernenderList = new List<Lernender>();
            FunktionsListe = new List<Funktion>();
        }
    }

}
