using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassungsprogramm;

namespace ZeiterfassungM320
{
    public class JSONHandling
    {
        public List<Mitarbeiter> MitarbeiterList { get; set; }
        public List<Ausbilder> AusbilderList { get; set; }
        public List<Lernender> LernenderList { get; set; }

        public JSONHandling()
        {
            MitarbeiterList = new List<Mitarbeiter>();
            AusbilderList = new List<Ausbilder>();
            LernenderList = new List<Lernender>();
        }
    }

}
