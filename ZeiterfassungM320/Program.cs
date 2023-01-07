using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Zeiterfassungsprogramm;

namespace Zeiterfassung
{
    class Program
    {
        static void Main(string[] args)
        {
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
                            mitarbeiterListe[mitarbeiterAuswahl].UrlaubHinzufuegen(urlaubstage);
                            //Console.WriteLine($"{ur mitarbeiterListe[mitarbeiterAuswahl].UrlaubAbziehen(urlaubstage);
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
                            mitarbeiterListe[mitarbeiterAuswahl].UrlaubHinzufuegen(urlaubstage);
                            Console.WriteLine($"{urlaubstage} Urlaubstage wurden zu {mitarbeiterListe[mitarbeiterAuswahl].Name} hinzugefügt.");
                        }
                        break;
                    case 2:
                        // Mitarbeiter mit verfügbarem Resturlaub anzeigen
                        foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                        {
                            if (mitarbeiter.Urlaub > 0)
                            {
                                Console.WriteLine($"{mitarbeiter.Name} ({mitarbeiter.Urlaub} Urlaubstage verfügbar)");
                            }
                        }
                        break;
                    case 3:
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
                        mitarbeiterListe.Add(new Mitarbeiter(name, alter, arbeit, urlaub, arbeitsstunden));
                        Console.WriteLine("Mitarbeiter hinzugefügt.");
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

