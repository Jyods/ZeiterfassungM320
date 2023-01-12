using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public class Arbeiter : User {

        private User vorgesetzter; //potentially use interface for this ("verantwortlich"?)
        private Funktion funktion;
        private int lohnZuschlag;

        private int sollZeit;
        private int istZeit;

        private int ferienguthaben;
        private int ferienbezug;

        //TODO: add functions (request, ..whatever)🤖🤖🤖

    }
}
