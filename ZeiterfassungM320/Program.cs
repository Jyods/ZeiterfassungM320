using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ZeiterfassungM320
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Mitarbeiter> mitarbeiterListe = new List<Mitarbeiter>();
            // Mitarbeiter-Objekte zur Liste hinzufügen
            mitarbeiterListe.Add(new Mitarbeiter("Max Mustermann", 30, "Programmierer", 20, 160));
            mitarbeiterListe.Add(new Mitarbeiter("Anna Mustermann", 28, "Designer", 10, 120));

            while (true)
            {
                Console.WriteLine("Bitte wählen Sie eine Option aus:");
                Console.WriteLine("1. Urlaub modifizieren");
                Console.WriteLine("2. Mitarbeiter mit verfügbarem Urlaub auflisten");
                Console.WriteLine("3. Neuen Mitarbeiter hinzufügen");
                Console.WriteLine("4. Statistik anzeigen");
                Console.WriteLine("9. Mitarbeiterdaten importieren/exportieren");

                // Eingabe des Benutzers einlesen
                string input = Console.ReadLine();

                // Überprüfen, ob die Eingabe gültig ist
                if (input == "1")
                {
                    Console.Clear();
                    // Code für die Option "Urlaub modifizieren"
                    Console.WriteLine("Wählen Sie den Mitarbeiter aus, dessen Urlaub modifiziert werden soll:");
                    int index = 1;
                    foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                    {
                        Console.WriteLine($"{index}. {mitarbeiter.Name}");
                        index++;
                    }

                    int auswahl = Convert.ToInt32(Console.ReadLine());
                    if (auswahl > 0 && auswahl <= mitarbeiterListe.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("Möchten Sie dem Mitarbeiter Urlaub abziehen oder hinzufügen? (a/h)");
                        string eingabe = Console.ReadLine();
                        if (eingabe == "a")
                        {
                            Console.Clear();
                            Console.WriteLine("Wie viele Urlaubstage sollen abgezogen werden?");
                            int urlaub = Convert.ToInt32(Console.ReadLine());
                            mitarbeiterListe[auswahl - 1].SubtractUrlaub(urlaub);
                            Console.Clear();
                        }
                        else if (eingabe == "h")
                        {
                            Console.Clear();
                            Console.WriteLine("Wie viele Urlaubstage sollen hinzugefügt werden?");
                            int urlaub = Convert.ToInt32(Console.ReadLine());
                            mitarbeiterListe[auswahl - 1].AddUrlaub(urlaub);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                    }
                }

                else if (input == "2")
                {
                    Console.Clear();
                    UrlaubAnzeigen(mitarbeiterListe);
                }
                else if (input == "3")
                {
                    Console.Clear();
                    // Code für die Option "Neuen Mitarbeiter hinzufügen"
                    Console.WriteLine("Geben Sie den Namen des Mitarbeiters ein:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Geben Sie das Alter des Mitarbeiters ein:");
                    int alter = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Geben Sie den Beruf des Mitarbeiters ein:");
                    string arbeit = Console.ReadLine();
                    Console.WriteLine("Geben Sie die Anzahl an verfügbarem Urlaub ein:");
                    int urlaub = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Geben Sie die Arbeitszeit des Mitarbeiters ein:");
                    int arbeitszeit = Convert.ToInt32(Console.ReadLine());
                    // Neues Mitarbeiter-Objekt erstellen und zur Liste hinzufügen
                    mitarbeiterListe.Add(new Mitarbeiter(name, alter, arbeit, urlaub, arbeitszeit));
                    Console.Clear();
                }
                else if (input == "4")
                {
                    Console.Clear();
                    // Code für die Option "Statistik anzeigen"
                    Console.WriteLine("Welche Statistik möchten Sie anzeigen?");
                    Console.WriteLine("1. Durchschnittsalter");
                    Console.WriteLine("2. Berufe");
                    Console.WriteLine("3. Durchschnittliche Arbeitszeit");

                    // Eingabe des Benutzers einlesen
                    string statistik = Console.ReadLine();

                    if (statistik == "1")
                    {
                        int summe = 0;
                        foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                        {
                            summe += mitarbeiter.Alter;
                        }

                        double durchschnitt = (double)summe / mitarbeiterListe.Count;

                        Console.Clear();
                        Console.WriteLine($"Das Durchschnittsalter aller Mitarbeiter beträgt {durchschnitt:F2} Jahre.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (statistik == "2")
                    {
                        // Dictionary, das die Arten von Arbeit mit der Anzahl der Mitarbeiter, die die gleiche Art von Arbeit haben, verknüpft
                        Dictionary<string, int> arbeit = new Dictionary<string, int>();

                        foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                        {
                            if (arbeit.ContainsKey(mitarbeiter.Arbeit))
                            {
                                arbeit[mitarbeiter.Arbeit]++;
                            }
                            else
                            {
                                arbeit[mitarbeiter.Arbeit] = 1;
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("Arten von Arbeit:");
                        foreach (KeyValuePair<string, int> entry in arbeit)
                        {
                            Console.WriteLine($"{entry.Key}: {entry.Value}");
                        }
                    }

                    else if (statistik == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("Wollen Sie die durchschnittliche Arbeitszeit von allen Mitarbeitern oder nur von Mitarbeitern eines bestimmten Berufs anzeigen?");
                        Console.WriteLine("1. Aller Mitarbeiter");
                        Console.WriteLine("2. Mitarbeiter eines bestimmten Berufs");

                        // Eingabe des Benutzers einlesen
                        string auswahl = Console.ReadLine();

                        if (auswahl == "1")
                        {
                            // Durchschnittliche Arbeitszeit von allen Mitarbeitern berechnen
                            int summe = 0;
                            foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                            {
                                summe += mitarbeiter.Arbeitszeit;
                            }

                            double durchschnitt = (double)summe / mitarbeiterListe.Count;
                            Console.Clear();
                            Console.WriteLine($"Die durchschnittliche Arbeitszeit aller Mitarbeiter beträgt {durchschnitt:F2} Stunden.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (auswahl == "2")
                        {
                            // Dictionary, das die Berufe mit der Gesamtarbeitszeit der Mitarbeiter, die den gleichen Beruf haben, verknüpft
                            Dictionary<string, int> arbeitszeit = new Dictionary<string, int>();

                            foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
                            {
                                if (arbeitszeit.ContainsKey(mitarbeiter.Arbeit))
                                {
                                    arbeitszeit[mitarbeiter.Arbeit] += mitarbeiter.Arbeitszeit;
                                }
                                else
                                {
                                    arbeitszeit[mitarbeiter.Arbeit] = mitarbeiter.Arbeitszeit;
                                }
                            }

                            Console.Clear();
                            Console.WriteLine("Durchschnittliche Arbeitszeit pro Beruf:");
                            foreach (KeyValuePair<string, int> entry in arbeitszeit)
                            {
                                int anzahl = arbeitszeit[entry.Key];
                                double durchschnitt = (double)entry.Value / anzahl;
                                Console.WriteLine($"{entry.Key}: {durchschnitt:F2} Stunden");
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ungültige Eingabe Bitte versuchen Sie es erneut.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");

                    }
                }
                else if (input == "9")
                {
                    Console.Clear();
                    Console.WriteLine("Wollen Sie die Mitarbeiterdaten importieren oder exportieren?");
                    Console.WriteLine("1. Importieren");
                    Console.WriteLine("2. Exportieren");

                    // Eingabe des Benutzers einlesen
                    string auswahl = Console.ReadLine();

                    if (auswahl == "1")
                    {
                        Console.WriteLine("Bitte geben Sie den Pfad zur JSON-Datei an:");

                        // Pfad zur JSON-Datei einlesen
                        string pfad = Console.ReadLine();

                        // JSON-Datei einlesen
                        string json = File.ReadAllText(pfad);

                        // Deserialisieren der JSON-Datei in Mitarbeiter-Objekte
                        mitarbeiterListe = JsonConvert.DeserializeObject<List<Mitarbeiter>>(json);

                        Console.WriteLine($"JSON Erfolgreich eingelesen!");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else if (auswahl == "2")
                    {
                        Console.Clear();
                        // Serialisieren der Mitarbeiter-Objekte in JSON-Format
                        string json = JsonConvert.SerializeObject(mitarbeiterListe);

                        // Benutzer auffordern, einen Namen für die JSON-Datei anzugeben
                        string dateiname = "";
                        int zaehler = 1;
                        while (true)
                        {
                            Console.WriteLine("Bitte geben Sie einen Namen für die JSON-Datei an:");
                            dateiname = Console.ReadLine();

                            // .json an den Dateinamen anhängen, falls nicht bereits vorhanden
                            if (!dateiname.EndsWith(".json"))
                            {
                                dateiname += ".json";
                            }

                            // Pfad für die JSON-Datei erstellen
                            string pfad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), dateiname);

                            // Überprüfen, ob die Datei bereits existiert
                            if (!File.Exists(pfad))
                            {
                                // Datei speichern
                                File.WriteAllText(pfad, json);
                                Console.WriteLine($"JSON wurde unter {pfad} erstellt.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Eine Datei mit dem Namen '{0}' existiert bereits auf dem Desktop.", dateiname);
                                Console.WriteLine("Bitte wählen Sie einen anderen Namen oder löschen Sie die existierende Datei.");

                                // Zähler erhöhen, um an den Dateinamen anhängen zu können, falls erneut eine Datei mit demselben Namen existiert
                                zaehler++;
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                        Console.Clear();
                    }
                }
            }
        }

        static void UrlaubAnzeigen(List<Mitarbeiter> mitarbeiterListe)
        {
            Console.Clear();

            foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
            {
                if (mitarbeiter.Urlaub > -50 || mitarbeiter.Urlaub < 50)
                {
                    Console.WriteLine($"{mitarbeiter.Name} hat noch {mitarbeiter.Urlaub} Tage Urlaub übrig.");
                }
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
