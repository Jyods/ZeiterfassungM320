using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Zeiterfassungsprogramm {
    class Program
    {
        //Listen erstellen
        static CEO ceo;
        static List<Funktion> funktionsListe = new List<Funktion>();
        static List<Arbeiter> arbeiterListe = new List<Arbeiter>();
        static List<Ausbilder> ausbilderListe = new List<Ausbilder>();
        static List<Lernender> lernendeListe = new List<Lernender>();

        static void Main(string[] args)
        {

            Voreinstellung();

            bool beenden = false;
            while (!beenden)
            {
                // Menü anzeigen
                Console.WriteLine("Zeiterfassungsprogramm");
                Console.WriteLine("1. Urlaub verwalten");
                Console.WriteLine("2. Mitarbeiter mit verfügbarem Resturlaub anzeigen");
                Console.WriteLine("3. Mitarbeiter hinzufügen");
                Console.WriteLine("4. Statistik anzeigen");
                Console.WriteLine("5. Mitarbeiter löschen");
                Console.WriteLine("6. Lernende Anzeigen");
                Console.WriteLine("9. Mitarbeiter-Daten aus JSON-Datei einlesen oder speichern");
                Console.WriteLine("0. Beenden");
                Console.Write("Auswahl: ");

                // Eingabe auswerten
                int auswahl = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (auswahl) {
                    // Urlaub verwalten
                case 1:
                    Console.Clear();
                    Console.WriteLine("1. Urlaub abziehen");
                    Console.WriteLine("2. Urlaub hinzufügen");
                    Console.Write("Auswahl: ");

                    int subAuswahl = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (subAuswahl == 1)
                    {
                        Arbeiter arbeiter = AuswahlArbeiter(arbeiterListe);
                        if (arbeiter != null)
                        {
                            Console.Clear();
                            // Anzahl der Urlaubstage abziehen
                            Console.Write("Anzahl der abzuziehenden Urlaubstage: ");
                            int urlaubstage = int.Parse(Console.ReadLine());
                            arbeiter.SetFerienguthaben(arbeiter.GetFerienguthaben()-urlaubstage);
                        }
                        else
                            Console.WriteLine("Ungültige Eingabe: Abgebrochen");
                    }
                    else if (subAuswahl == 2)
                    {
                        Arbeiter arbeiter = AuswahlArbeiter(arbeiterListe);
                        if(arbeiter != null) {
                            Console.Clear();
                            // Anzahl der Urlaubstage hinzufügen
                            Console.Write("Anzahl der Urlaubstage: ");
                            int urlaubstage = int.Parse(Console.ReadLine());
                            arbeiter.SetFerienguthaben(arbeiter.GetFerienguthaben()+urlaubstage);
                            //Console.WriteLine($"{ur mitarbeiterListe[mitarbeiterAuswahl].UrlaubAbziehen(urlaubstage);
                        }
                        else
                            Console.WriteLine("Ungültige Eingabe: Abgebrochen");
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe: " + subAuswahl);
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Drücke Enter um zu verlassen.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Verfügbarer Resturlaub:");
                    Console.WriteLine("------------------------");

                    // Mitarbeiter anzeigen
                    foreach (Arbeiter mitarbeiter in arbeiterListe)
                    {
                        Console.WriteLine($"{mitarbeiter.GetGanzerName()}: {mitarbeiter.GetFerienguthaben()} Tage Resturlaub ({mitarbeiter.GetType().Name})");
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Drücke Enter um zu verlassen.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                // Mitarbeiter Hinzufügen
                case 3:
                    Console.Clear();
                    Console.WriteLine("Bitte wählen Sie den Typ des Mitarbeiters aus:");
                    Console.WriteLine("1. Arbeiter");
                    Console.WriteLine("2. Lernender");
                    Console.WriteLine("3. Ausbilder");
                    Console.WriteLine("9. Zurück");
                    int mitarbeiterTyp = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (mitarbeiterTyp)
                    {
                        case 1:
                            // Arbeiter hinzufügen
                            Console.WriteLine("Arbeiter Hinzufügen");
                            Console.WriteLine("");
                            Console.Write("Vorname: ");
                            string vorname = Console.ReadLine();
                            Console.Write("Nachname: ");
                            string nachname = Console.ReadLine();
                            Console.Write("Alter: ");
                            int alter = int.Parse(Console.ReadLine());
                            Console.WriteLine("Funktion auswählen:");
                            for (int i = 0; i < funktionsListe.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {funktionsListe[i].Bezeichnung}");
                            }
                            Console.Write("Funktions-Auswahl: ");
                            int funktionAuswahl = int.Parse(Console.ReadLine()) - 1;
                            Funktion funktion = funktionsListe[funktionAuswahl];
                            Console.Write("Urlaub: ");
                            int urlaub = int.Parse(Console.ReadLine());
                            Console.Write("Arbeitsstunden: ");
                            int arbeitsstunden = int.Parse(Console.ReadLine());
                            Arbeiter mitarbeiter = new Arbeiter(vorname, nachname, alter, ceo, funktion);
                            mitarbeiter.Anzeige(); // Anwendung der Methode "Anzeige()" des Interfaces "IAnzeige" auf das Mitarbeiter-Objekt
                            arbeiterListe.Add(mitarbeiter);
                            Console.WriteLine("Mitarbeiter hinzugefügt.");
                            Console.Clear();
                            break;
                        case 2:
                            Console.Write("Vorname des Lernenden: ");
                            string lernenderVorName = Console.ReadLine();
                            Console.Write("Nachname des Lernenden: ");
                            string lernenderNachName = Console.ReadLine();
                            Console.Write("Alter des Lernenden: ");
                            int lernenderAlter = int.Parse(Console.ReadLine());
                            Console.WriteLine("Arbeit auswählen:");
                            for (int i = 0; i < funktionsListe.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {funktionsListe[i].Bezeichnung}");
                            }
                            Console.Write("Funktions-Auswahl: ");
                            int lernenderArbeitAuswahl = int.Parse(Console.ReadLine()) - 1;
                            Funktion lernenderArbeit = funktionsListe[lernenderArbeitAuswahl];
                            Console.Write("Urlaub des Lernenden: ");
                            int lernenderUrlaub = int.Parse(Console.ReadLine());
                            Console.Write("Arbeitsstunden des Lernenden: ");
                            int lernenderArbeitsstunden = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ausbilder auswählen:");
                            for (int i = 0; i < ausbilderListe.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {ausbilderListe[i].GetGanzerName()}");
                            }
                            Console.Write("Ausbilder-Auswahl: ");
                            int ausbilderAuswahl = int.Parse(Console.ReadLine()) - 1;
                            Ausbilder ausbilder = ausbilderListe[ausbilderAuswahl];

                            Lernender lernender = new Lernender(lernenderVorName, lernenderNachName, lernenderAlter, ausbilder, lernenderArbeit);
                            lernender.Anzeige(); // Anwendung der Methode "Anzeige()" des Interfaces "IAnzeige" auf das Lernender-Objekt
                            lernendeListe.Add(lernender);
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("Ausbilder Hinzufügen");
                            Console.WriteLine("");
                            // Ausbilder hinzufügen
                            Console.Write("Vorname: ");
                            string Ausbildervorname = Console.ReadLine();
                            Console.Write("Nachname: ");
                            string Ausbildernachname = Console.ReadLine();
                            Console.Write("Alter: ");
                            int Ausbilderalter = int.Parse(Console.ReadLine());
                            Console.WriteLine("Arbeit auswählen:");
                            for (int i = 0; i < funktionsListe.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {funktionsListe[i].Bezeichnung}");
                            }
                            Console.Write("Funktions-Auswahl: ");
                            int ausbilderArbeitAuswahl = int.Parse(Console.ReadLine()) - 1;
                            Funktion Ausbilderarbeit = funktionsListe[ausbilderArbeitAuswahl];
                            Console.Write("Urlaub: ");
                            int Ausbilderurlaub = int.Parse(Console.ReadLine());
                            Console.Write("Arbeitsstunden: ");
                            int Ausbilderarbeitsstunden = int.Parse(Console.ReadLine());
                            Ausbilder newausbilder = new Ausbilder(Ausbildervorname,Ausbildernachname,Ausbilderalter,ceo,Ausbilderarbeit);
                            ausbilderListe.Add(newausbilder);
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Ungültige Auswahl. Drücke Enter um zu verlassen.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 9:
                            Console.Clear();
                            break;
                    }
                    break;

                        
                case 4:
                    Console.Clear();
                    // Statistik anzeigen
                    Console.WriteLine("1. Durchschnittsalter aller Mitarbeiter");
                    Console.WriteLine("2. Anzahl der Mitarbeiter pro Beruf");
                    Console.WriteLine("3. Durchschnittliche Arbeitszeit aller Mitarbeiter");
                    Console.WriteLine("4. Durchschnittliche Arbeitszeit pro Beruf");
                    Console.Write("Auswahl: ");
                    int statistikAuswahl = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (statistikAuswahl == 1)
                    {
                        Console.WriteLine("Durchschnittsalter aller Mitarbeiter");
                        Console.WriteLine("");
                        // Durchschnittsalter aller Mitarbeiter
                        int summeAlter = 0;
                        foreach (Arbeiter mitarbeiter in arbeiterListe)
                        {
                            summeAlter += mitarbeiter.GetAlter();
                        }
                        double durchschnittsalter = (double)summeAlter / arbeiterListe.Count;
                        Console.WriteLine($"Durchschnittsalter: {durchschnittsalter:F2}");
                        Console.WriteLine("Drücke Enter um zu verlassen");
                        Console.ReadLine();
                    }
                    else if (statistikAuswahl == 2)
                    {
                        Console.WriteLine("Anzahl der Mitarbeiter pro Beruf");
                        Console.WriteLine("");
                        // Anzahl der Mitarbeiter pro Beruf
                        var gruppierung = from mitarbeiter in arbeiterListe
                                            group mitarbeiter by mitarbeiter.GetFunktion().Bezeichnung into gruppe
                                            select new { Arbeit = gruppe.Key, Anzahl = gruppe.Count() };
                        foreach (var g in gruppierung)
                        {
                            Console.WriteLine($"{g.Arbeit}: {g.Anzahl}");
                        }
                        Console.WriteLine("Drücke Enter um zu verlassen");
                        Console.ReadLine();
                    }
                    else if (statistikAuswahl == 3)
                    {
                        Console.WriteLine("Durchschnittliche Arbeitszeit aller Mitarbeiter");
                        Console.WriteLine("");
                        // Durchschnittliche Arbeitszeit aller Mitarbeiter
                        int summeArbeitsstunden = 0;
                        foreach (Arbeiter mitarbeiter in arbeiterListe)
                        {
                            summeArbeitsstunden += mitarbeiter.GetArbeitsstunden();
                        }
                        double durchschnittsarbeitszeit = (double)summeArbeitsstunden / arbeiterListe.Count;
                        Console.WriteLine($"Durchschnittliche Arbeitszeit: {durchschnittsarbeitszeit:F2} Stunden");
                        Console.WriteLine("Drücke Enter um zu verlassen");
                        Console.ReadLine();
                    }
                    else if (statistikAuswahl == 4)
                    {
                        Console.WriteLine("Durchschnittliche Arbeitszeit pro Beruf");
                        Console.WriteLine("");
                        // Durchschnittliche Arbeitszeit pro Beruf
                        var gruppierung = from mitarbeiter in arbeiterListe
                                            group mitarbeiter by mitarbeiter.GetFunktion().Bezeichnung into gruppe
                                            select new { Arbeit = gruppe.Key, Arbeitsstunden = gruppe.Average(m => m.GetArbeitsstunden()) };
                        foreach (var g in gruppierung)
                        {
                            Console.WriteLine($"{g.Arbeit}: {g.Arbeitsstunden:F2} Stunden");
                        }
                        Console.WriteLine("Drücke Enter um zu verlassen");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Auswahl. Drücke Enter um zu verlassen.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    // Mitarbeiter löschen
                    Console.WriteLine("Mitarbeiter auswählen:");
                    for (int i = 0; i < arbeiterListe.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {arbeiterListe[i].GetGanzerName()}");
                    }
                    Console.Write("Auswahl: ");
                    int mitarbeiterLoeschenAuswahl = int.Parse(Console.ReadLine()) - 1;
                    arbeiterListe.RemoveAt(mitarbeiterLoeschenAuswahl);
                    Console.WriteLine("Mitarbeiter gelöscht.");
                    Console.Clear();
                    break;
                case 6:
                    Console.Clear();
                    // Lernende Anzeigen
                    Console.WriteLine("Lernende:");
                    int t = 1;
                    foreach (Lernender lernender in lernendeListe)
                    {
                        Console.WriteLine($"{t}. {lernender.GetGanzerName()} (Ausbilder: {lernender.GetAusbilder().GetGanzerName()})");
                        t++;
                    }
                    Console.Write("Auswahl: ");
                    int lernenderAuswahl = int.Parse(Console.ReadLine());
                    if (lernenderAuswahl >= 1 && lernenderAuswahl <= lernendeListe.Count)
                    {
                        Lernender ausgewählterLernender = lernendeListe[lernenderAuswahl - 1];
                        ausgewählterLernender.Anzeige();
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Auswahl.");
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Drücke Enter um zu verlassen.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 9:
                    Console.Clear();
                    // Mitarbeiter-Daten aus JSON-Datei einlesen oder speichern
                    Console.WriteLine("1. Aus JSON-Datei einlesen");
                    Console.WriteLine("2. In JSON-Datei speichern");
                    Console.Write("Auswahl: ");
                    int jsonAuswahl = int.Parse(Console.ReadLine());
                    if (jsonAuswahl == 1)
                    {
                        Console.Clear();
                        // Aus JSON-Datei einlesen
                        Console.WriteLine("JSON Datei einlesen");
                        Console.WriteLine();
                        Console.WriteLine("Leer lassen wenn diese Datei nicht eingelesen werden soll.");
                        Console.WriteLine();
                        Console.Write("Dateipfad: ");
                        string dateipfad = Console.ReadLine();
                        if (dateipfad != "")
                        {
                            if (!dateipfad.EndsWith(".json"))
                            {
                                dateipfad += ".json";
                            }
                            dateipfad = File.ReadAllText(dateipfad);
                            JSONHandling JSONHandling = JsonConvert.DeserializeObject<JSONHandling>(dateipfad);
                            arbeiterListe = JSONHandling.MitarbeiterList;
                            ausbilderListe = JSONHandling.AusbilderList;
                            lernendeListe = JSONHandling.LernenderList;
                            Console.WriteLine("Import Abgeschlossen. Drücke Enter um fortzufahren.");
                        }
                        else
                            Console.WriteLine("Import übersprungen.");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else if (jsonAuswahl == 2)
                    {

                        // In JSON-Datei speichern
                        Console.Write("Dateiname: ");
                        string dateiname = Console.ReadLine();
                        if (!dateiname.EndsWith(".json"))
                        {
                            dateiname += ".json";
                        }

                        if (File.Exists(dateiname))
                        {
                            // Wenn Datei bereits vorhanden ist, fortlaufende Nummer anhängen
                            int nummer = 1;
                            while (File.Exists($"{dateiname.Replace(".json", "")} ({nummer}).json"))
                            {
                                nummer++;
                            }
                            dateiname = $"{dateiname.Replace(".json", "")} ({nummer}).json";
                        }

                        JSONHandling JSONHandling = new JSONHandling();
                        JSONHandling.MitarbeiterList = arbeiterListe;
                        JSONHandling.AusbilderList = ausbilderListe;
                        JSONHandling.LernenderList = lernendeListe;
                        JSONHandling.FunktionsListe = funktionsListe;

                        string json = JsonConvert.SerializeObject(JSONHandling);
                        File.WriteAllText(dateiname, json);
                        Console.WriteLine($"Mitarbeiter-Daten in JSON-Datei \"{dateiname}\" gespeichert.");

                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                case 0:
                    beenden = true;
                    break;
                }
            }


        }

        static void Voreinstellung() {
            // Funktionen erstellen
            Funktion funktion_ar_1 = new Funktion("Entwickler/in",170);
            Funktion funktion_ar_2 = new Funktion("Projektmanager/in",170);
            Funktion funktion_au_1 = new Funktion("Ausbilder Softwareentwicklung",160);
            Funktion funktion_au_2 = new Funktion("Ausbilder Projektmanagement",170);
            Funktion funktion_le_1 = new Funktion("Lernende/r Softwareentwicklung",170);
            Funktion funktion_le_2 = new Funktion("Lernende/r Projektmanagement",170);

            // Mitarbeiter erstellen
            ceo = new CEO("Samantha","Rasper",54);
            Ausbilder ausbilder1 = new Ausbilder("Anna","Müller",34,ceo,funktion_au_1);
            Ausbilder ausbilder2 = new Ausbilder("Hans","Meier",69,ceo,funktion_au_2);
            Lernender lernender1 = new Lernender("Laura","Schulz",16,ausbilder1,funktion_le_1);
            Lernender lernender2 = new Lernender("Thomas","Schmidt",17,ausbilder2,funktion_le_2);
            Arbeiter arbeiter1 = new Arbeiter("Max","Mustermann",50,ceo,funktion_ar_1);
            Arbeiter arbeiter2 = new Arbeiter("Erika","Mustermann",20,ceo,funktion_ar_2);


            // Listen füllen
            funktionsListe.Add(funktion_ar_1);
            funktionsListe.Add(funktion_ar_2);
            funktionsListe.Add(funktion_au_1);
            funktionsListe.Add(funktion_au_2);
            funktionsListe.Add(funktion_le_1);
            funktionsListe.Add(funktion_le_2);

            ausbilderListe.Add(ausbilder1);
            ausbilderListe.Add(ausbilder2);

            lernendeListe.Add(lernender1);
            lernendeListe.Add(lernender2);

            arbeiterListe.Add(arbeiter1);
            arbeiterListe.Add(arbeiter2);
        }

        static Arbeiter AuswahlArbeiter(List<Arbeiter> list, bool ferienAnzeige = true) {
            Console.Clear();
            Console.WriteLine("Mitarbeiter auswählen:");

            //Liste anzeigen
            for(int i=0; i < list.Count; i++) {
                Arbeiter a = list[i];
                if(ferienAnzeige) {
                    Console.WriteLine($"{i + 1}. {a.GetGanzerName()} ({a.GetFerienguthaben()} Urlaubstage verfügbar)");
                } else {
                    Console.WriteLine($"{i + 1}. {a.GetGanzerName()}");
                }
            }
            Console.Write("Auswahl: ");
            int mitarbeiterAuswahl = int.Parse(Console.ReadLine()) - 1;

            //Arbeiter zurückgeben
            if(mitarbeiterAuswahl >= 0 && mitarbeiterAuswahl < list.Count) {
                return list[mitarbeiterAuswahl];
            } else {
                return null;
            }
        }
    }
}

