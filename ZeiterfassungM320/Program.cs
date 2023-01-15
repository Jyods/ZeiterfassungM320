using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using ZeiterfassungM320;
using Zeiterfassungsprogramm;

namespace Zeiterfassung
{
    class Program
    {
        static void Main(string[] args)
        {
            // Andere Listen erstellen
            List<Ausbilder> ausbilderListe = new List<Ausbilder>();
            List<Lernender> lernenderListe = new List<Lernender>();

            Ausbilder ausbilder1 = new Ausbilder("Anna Müller", 35, "Softwareentwicklung", 20, 160);
            Ausbilder ausbilder2 = new Ausbilder("Hans Meier", 41, "Projektmanagement", 25, 170);
            Lernender lernender1 = new Lernender("Laura Schulz", 21, "Softwareentwicklung", 10, 10, ausbilder1);
            Lernender lernender2 = new Lernender("Thomas Schmidt", 23, "KV", 10, 10, ausbilder2);

            ausbilderListe.Add(ausbilder1);
            ausbilderListe.Add(ausbilder2);
            lernenderListe.Add(lernender1);
            lernenderListe.Add(lernender2);

            // Mitarbeiter erstellen
            List<Mitarbeiter> mitarbeiterListe = new List<Mitarbeiter>();
            mitarbeiterListe.Add(new Mitarbeiter("Max Mustermann", 30, "Entwickler", 20, 160));
            mitarbeiterListe.Add(new Mitarbeiter("Erika Mustermann", 25, "Projektmanager", 25, 175));
            mitarbeiterListe.Add(new Mitarbeiter("Jon Doe", 35, "CEO", 30, 200));

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
                switch (auswahl)
                {
                    case 1:
                        Console.Clear();
                        // Urlaub verwalten
                        Console.WriteLine("1. Urlaub abziehen");
                        Console.WriteLine("2. Urlaub hinzufügen");
                        Console.Write("Auswahl: ");
                        int urlaubAuswahl = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (urlaubAuswahl == 1)
                        {
                            // Mitarbeiter auswählen
                            Console.WriteLine("Mitarbeiter auswählen:");
                            for (int i = 0; i < mitarbeiterListe.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {mitarbeiterListe[i].Name} ({mitarbeiterListe[i].Urlaub} Urlaubstage verfügbar)");
                            }
                            Console.Write("Auswahl: ");
                            int mitarbeiterAuswahl = int.Parse(Console.ReadLine()) - 1;

                            if (mitarbeiterAuswahl > 0 && mitarbeiterAuswahl < mitarbeiterListe.Count)
                            {
                                // Anzahl der Urlaubstage abziehen
                                Console.Write("Anzahl der Urlaubstage: ");
                                int urlaubstage = int.Parse(Console.ReadLine());
                                mitarbeiterListe[mitarbeiterAuswahl].UrlaubAbziehen(urlaubstage);
                            }
                            else
                                Console.WriteLine("Ungültige Eingabe: Abgebrochen");
                        }
                        else if (urlaubAuswahl == 2)
                        {
                            // Mitarbeiter auswählen
                            Console.WriteLine("Mitarbeiter auswählen:");
                            for (int i = 0; i < mitarbeiterListe.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {mitarbeiterListe[i].Name} ({mitarbeiterListe[i].Urlaub} Urlaubstage verfügbar)");
                            }
                            Console.Write("Auswahl: ");
                            int mitarbeiterAuswahl = int.Parse(Console.ReadLine()) - 1;

                            if (mitarbeiterAuswahl > 0 && mitarbeiterAuswahl < mitarbeiterListe.Count)
                            {
                                // Anzahl der Urlaubstage hinzufügen
                                Console.Write("Anzahl der Urlaubstage: ");
                                int urlaubstage = int.Parse(Console.ReadLine());
                                mitarbeiterListe[mitarbeiterAuswahl].UrlaubHinzufügen(urlaubstage);
                                //Console.WriteLine($"{ur mitarbeiterListe[mitarbeiterAuswahl].UrlaubAbziehen(urlaubstage);
                                Console.WriteLine($"{urlaubstage} Urlaubstage wurden von {mitarbeiterListe[mitarbeiterAuswahl].Name} abgezogen.");
                            }
                            else
                                Console.WriteLine("Ungültige Eingabe: Abgebrochen");
                        }
                        else
                        {
                            Console.WriteLine("Ungültige Eingabe: " + urlaubAuswahl);
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
                        foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                        {
                            Console.WriteLine($"{mitarbeiter.Name}: {mitarbeiter.Urlaub} Tage Resturlaub ({mitarbeiter.GetType().Name})");
                        }
                        foreach (Ausbilder ausbilder in ausbilderListe)
                        {
                            Console.WriteLine($"{ausbilder.Name}: {ausbilder.Urlaub} Tage Resturlaub ({ausbilder.GetType().Name})");
                        }
                        foreach (Lernender lernender in lernenderListe)
                        {
                            Console.WriteLine($"{lernender.Name}: {lernender.Urlaub} Tage Resturlaub ({lernender.GetType().Name})");
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
                        Console.WriteLine("1. Mitarbeiter");
                        Console.WriteLine("2. Lernender");
                        Console.WriteLine("3. Ausbilder");
                        Console.WriteLine("9. Zurück");
                        int mitarbeiterTyp = int.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (mitarbeiterTyp)
                        {
                            case 1:
                                // Mitarbeiter hinzufügen
                                Console.WriteLine("Mitarbeiter Hinzufügen");
                                Console.WriteLine("");
                                Console.Write("Name: ");
                                string name = Console.ReadLine();
                                Console.Write("Alter: ");
                                int alter = int.Parse(Console.ReadLine());
                                Console.Write("Arbeit: ");
                                string arbeit = Console.ReadLine();
                                Console.Write("Urlaub: ");
                                int urlaub = int.Parse(Console.ReadLine());
                                Console.Write("Arbeitsstunden: ");
                                int arbeitsstunden = int.Parse(Console.ReadLine());
                                Mitarbeiter mitarbeiter = new Mitarbeiter(name, alter, arbeit, urlaub, arbeitsstunden);
                                mitarbeiter.Anzeige(); // Anwendung der Methode "Anzeige()" des Interfaces "IAnzeige" auf das Mitarbeiter-Objekt
                                mitarbeiterListe.Add(mitarbeiter);
                                Console.WriteLine("Mitarbeiter hinzugefügt.");
                                break;
                            case 2:
                                Console.WriteLine("Lernender Hinzufügen");
                                Console.WriteLine("");
                                Console.Write("Name des Lernenden: ");
                                string lernenderName = Console.ReadLine();
                                Console.Write("Alter des Lernenden: ");
                                int lernenderAlter = int.Parse(Console.ReadLine());
                                Console.Write("Arbeit des Lernenden: ");
                                string lernenderArbeit = Console.ReadLine();
                                Console.Write("Urlaub des Lernenden: ");
                                int lernenderUrlaub = int.Parse(Console.ReadLine());
                                Console.Write("Arbeitsstunden des Lernenden: ");
                                int lernenderArbeitsstunden = int.Parse(Console.ReadLine());

                                Console.WriteLine("Ausbilder auswählen:");
                                for (int i = 0; i < ausbilderListe.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {ausbilderListe[i].Name}");
                                }
                                Console.Write("Ausbilder-Auswahl: ");
                                int ausbilderAuswahl = int.Parse(Console.ReadLine()) - 1;
                                Ausbilder ausbilder = ausbilderListe[ausbilderAuswahl];

                                Lernender lernender = new Lernender(lernenderName, lernenderAlter, lernenderArbeit, lernenderUrlaub, lernenderArbeitsstunden, ausbilder);
                                lernender.Anzeige(); // Anwendung der Methode "Anzeige()" des Interfaces "IAnzeige" auf das Lernender-Objekt
                                lernenderListe.Add(lernender);
                                ausbilder.LernenderListe.Add(lernender);
                                break;
                            case 3:
                                Console.WriteLine("Ausbilder Hinzufügen");
                                Console.WriteLine("");
                                // Ausbilder hinzufügen
                                Console.Write("Name: ");
                                string Ausbildername = Console.ReadLine();
                                Console.Write("Alter: ");
                                int Ausbilderalter = int.Parse(Console.ReadLine());
                                Console.Write("Arbeit: ");
                                string Ausbilderarbeit = Console.ReadLine();
                                Console.Write("Urlaub: ");
                                int Ausbilderurlaub = int.Parse(Console.ReadLine());
                                Console.Write("Arbeitsstunden: ");
                                int Ausbilderarbeitsstunden = int.Parse(Console.ReadLine());
                                Ausbilder newausbilder = new Ausbilder(Ausbildername, Ausbilderalter, Ausbilderarbeit, Ausbilderurlaub, Ausbilderarbeitsstunden);
                                ausbilderListe.Add(newausbilder);
                                break;
                            default:
                                Console.WriteLine("Ungültige Auswahl. Drücke Enter um zu verlassen.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 9:
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
                            foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                            {
                                summeAlter += mitarbeiter.Alter;
                            }
                            double durchschnittsalter = (double)summeAlter / mitarbeiterListe.Count;
                            Console.WriteLine($"Durchschnittsalter: {durchschnittsalter:F2}");
                        }
                        else if (statistikAuswahl == 2)
                        {
                            Console.WriteLine("Anzahl der Mitarbeiter pro Beruf");
                            Console.WriteLine("");
                            // Anzahl der Mitarbeiter pro Beruf
                            var gruppierung = from mitarbeiter in mitarbeiterListe
                                              group mitarbeiter by mitarbeiter.Arbeit into gruppe
                                              select new { Arbeit = gruppe.Key, Anzahl = gruppe.Count() };
                            foreach (var g in gruppierung)
                            {
                                Console.WriteLine($"{g.Arbeit}: {g.Anzahl}");
                            }
                        }
                        else if (statistikAuswahl == 3)
                        {
                            Console.WriteLine("Durchschnittliche Arbeitszeit aller Mitarbeiter");
                            Console.WriteLine("");
                            // Durchschnittliche Arbeitszeit aller Mitarbeiter
                            int summeArbeitsstunden = 0;
                            foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                            {
                                summeArbeitsstunden += mitarbeiter.Arbeitsstunden;
                            }
                            double durchschnittsarbeitszeit = (double)summeArbeitsstunden / mitarbeiterListe.Count;
                            Console.WriteLine($"Durchschnittliche Arbeitszeit: {durchschnittsarbeitszeit:F2} Stunden");
                        }
                        else if (statistikAuswahl == 4)
                        {
                            Console.WriteLine("Durchschnittliche Arbeitszeit pro Beruf");
                            Console.WriteLine("");
                            // Durchschnittliche Arbeitszeit pro Beruf
                            var gruppierung = from mitarbeiter in mitarbeiterListe
                                              group mitarbeiter by mitarbeiter.Arbeit into gruppe
                                              select new { Arbeit = gruppe.Key, Arbeitsstunden = gruppe.Average(m => m.Arbeitsstunden) };
                            foreach (var g in gruppierung)
                            {
                                Console.WriteLine($"{g.Arbeit}: {g.Arbeitsstunden:F2} Stunden");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ungültige Auswahl. Drücke Enter um zu verlassen.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 5:
                        Console.Clear();
                        // Mitarbeiter löschen
                        Console.WriteLine("Mitarbeiter auswählen:");
                        for (int i = 0; i < mitarbeiterListe.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {mitarbeiterListe[i].Name}");
                        }
                        Console.Write("Auswahl: ");
                        int mitarbeiterLoeschenAuswahl = int.Parse(Console.ReadLine()) - 1;
                        mitarbeiterListe.RemoveAt(mitarbeiterLoeschenAuswahl);
                        Console.WriteLine("Mitarbeiter gelöscht.");
                        break;
                    case 6:
                        Console.Clear();
                        // Lernende Anzeigen
                        Console.WriteLine("Lernende:");
                        int t = 1;
                        foreach (Lernender lernender in lernenderListe)
                        {
                            Console.WriteLine($"{t}. {lernender.Name} (Ausbilder: {lernender.Ausbilder.Name})");
                            t++;
                        }
                        Console.Write("Auswahl: ");
                        int lernenderAuswahl = int.Parse(Console.ReadLine());
                        if (lernenderAuswahl >= 1 && lernenderAuswahl <= lernenderListe.Count)
                        {
                            Lernender ausgewählterLernender = lernenderListe[lernenderAuswahl - 1];
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
                                mitarbeiterListe = JSONHandling.MitarbeiterList;
                                ausbilderListe = JSONHandling.AusbilderList;
                                lernenderListe = JSONHandling.LernenderList;
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
                            JSONHandling.MitarbeiterList = mitarbeiterListe;
                            JSONHandling.AusbilderList = ausbilderListe;
                            JSONHandling.LernenderList = lernenderListe;

                            string json = JsonConvert.SerializeObject(JSONHandling);
                            File.WriteAllText(dateiname, json);
                            Console.WriteLine($"Mitarbeiter-Daten in JSON-Datei \"{dateiname}\" gespeichert.");

                            Console.ReadKey();
                        }
                        break;
                    case 0:
                        beenden = true;
                        break;
                }
            }
        }
    }
}

