using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                Console.WriteLine("9. Mitarbeiter-Daten aus JSON-Datei einlesen oder speichern");
                Console.WriteLine("0. Beenden");
                Console.Write("Auswahl: ");

                // Eingabe auswerten
                int auswahl = int.Parse(Console.ReadLine());
                switch (auswahl)
                {
                    case 1:
                        // Urlaub verwalten
                        Console.WriteLine("1. Urlaub abziehen");
                        Console.WriteLine("2. Urlaub hinzufügen");
                        Console.Write("Auswahl: ");
                        int urlaubAuswahl = int.Parse(Console.ReadLine());
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

                            // Anzahl der Urlaubstage abziehen
                            Console.Write("Anzahl der Urlaubstage: ");
                            int urlaubstage = int.Parse(Console.ReadLine());
                            mitarbeiterListe[mitarbeiterAuswahl].UrlaubAbziehen(urlaubstage);
                            Console.WriteLine($"{urlaubstage} Urlaubstage wurden von {mitarbeiterListe[mitarbeiterAuswahl].Name} abgezogen.");
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

                            // Anzahl der Urlaubstage hinzufügen
                            Console.Write("Anzahl der Urlaubstage: ");
                            int urlaubstage = int.Parse(Console.ReadLine());
                            mitarbeiterListe[mitarbeiterAuswahl].UrlaubHinzufügen(urlaubstage);
                            //Console.WriteLine($"{ur mitarbeiterListe[mitarbeiterAuswahl].UrlaubAbziehen(urlaubstage);
                            Console.WriteLine($"{urlaubstage} Urlaubstage wurden von {mitarbeiterListe[mitarbeiterAuswahl].Name} abgezogen.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Verfügbarer Resturlaub:");
                        Console.WriteLine("------------------------");

                        // Mitarbeiter anzeigen
                        foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                        {
                            Console.WriteLine($"{mitarbeiter.Name}: {mitarbeiter.Resturlaub} Tage Resturlaub ({mitarbeiter.GetType().Name})");
                        }
                        foreach (Ausbilder ausbilder in ausbilderListe)
                        {
                            Console.WriteLine($"{ausbilder.Name}: {ausbilder.Resturlaub} Tage Resturlaub ({ausbilder.GetType().Name})");
                        }
                        foreach (Lernender lernender in lernenderListe)
                        {
                            Console.WriteLine($"{lernender.Name}: {lernender.Resturlaub} Tage Resturlaub ({lernender.GetType().Name})");
                        }


                        break;

                    // Mitarbeiter Hinzufügen
                    case 3:
                        Console.WriteLine("Bitte wählen Sie den Typ des Mitarbeiters aus:");
                        Console.WriteLine("1. Mitarbeiter");
                        Console.WriteLine("2. Lernender");
                        Console.WriteLine("3. Vorgesetzer");
                        int mitarbeiterTyp = int.Parse(Console.ReadLine());

                        switch (mitarbeiterTyp)
                        {
                            case 1:
                                // Mitarbeiter hinzufügen
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
                                mitarbeiterListe.Add(mitarbeiter);
                                Console.WriteLine("Mitarbeiter hinzugefügt.");
                                break;
                            case 2:
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
                                lernenderListe.Add(lernender);
                                ausbilder.LernenderListe.Add(lernender);
                                break;

                            case 3:
                                // Code zum Hinzufügen eines Vorgesetzten
                                break;
                            case 4:
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
                                Console.WriteLine("Ungültige Auswahl.");
                                break;
                        }
                        break;

                        
                    case 4:
                        // Statistik anzeigen
                        Console.WriteLine("1. Durchschnittsalter aller Mitarbeiter");
                        Console.WriteLine("2. Anzahl der Mitarbeiter pro Beruf");
                        Console.WriteLine("3. Durchschnittliche Arbeitszeit aller Mitarbeiter");
                        Console.WriteLine("4. Durchschnittliche Arbeitszeit pro Beruf");
                        Console.Write("Auswahl: ");
                        int statistikAuswahl = int.Parse(Console.ReadLine());
                        if (statistikAuswahl == 1)
                        {
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
                            // Durchschnittliche Arbeitszeit pro Beruf
                            var gruppierung = from mitarbeiter in mitarbeiterListe
                                              group mitarbeiter by mitarbeiter.Arbeit into gruppe
                                              select new { Arbeit = gruppe.Key, Arbeitsstunden = gruppe.Average(m => m.Arbeitsstunden) };
                            foreach (var g in gruppierung)
                            {
                                Console.WriteLine($"{g.Arbeit}: {g.Arbeitsstunden:F2} Stunden");
                            }
                        }
                        break;
                    case 5:
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
                    case 9:
                        // Mitarbeiter-Daten aus JSON-Datei einlesen oder speichern
                        Console.WriteLine("1. Aus JSON-Datei einlesen");
                        Console.WriteLine("2. In JSON-Datei speichern");
                        Console.Write("Auswahl: ");
                        int jsonAuswahl = int.Parse(Console.ReadLine());
                        if (jsonAuswahl == 1)
                        {
                            // Aus JSON-Datei einlesen
                            Console.Write("Dateipfad: ");
                            string dateipfad = Console.ReadLine();
                            mitarbeiterListe = JsonConvert.DeserializeObject<List<Mitarbeiter>>(File.ReadAllText(dateipfad));
                            Console.WriteLine("Mitarbeiter-Daten aus JSON-Datei eingelesen.");
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
                            File.WriteAllText(dateiname, JsonConvert.SerializeObject(mitarbeiterListe));
                            Console.WriteLine($"Mitarbeiter-Daten in JSON-Datei \"{dateiname}\" gespeichert.");
                        }
                        break;
                }
            }
        }
    }
}

