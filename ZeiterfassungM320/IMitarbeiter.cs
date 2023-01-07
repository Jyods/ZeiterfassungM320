﻿using System;
using Zeiterfassungsprogramm;

namespace Zeiterfassungsprogramm
{
    public interface IMitarbeiter
    {
        string Name { get; set; }
        int Alter { get; set; }
        string Arbeit { get; set; }
        int Urlaub { get; set; }
        int Arbeitsstunden { get; set; }

        int ArbeitsstundenBerechnen();
        void UrlaubAbziehen(int stunden);
        void UrlaubHinzufuegen(int stunden);
    }
}
