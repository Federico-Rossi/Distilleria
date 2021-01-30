using System;
using System.IO;

namespace Programma_distilleria_distillati
{
    class Program
    {
        /*Inizializzo l'array bidimensionale dove la prima dimensione contiene i nomi dei distillati
         e la seconda contiene, per ogni distillato la quantità di botti piccole, medie e grandi che lo conterranno*/
        public static int[][] botti = new int[8][]{
                        new int[3]{ 0, 0, 0 },     //botti di vino 
                        new int[3]{ 0, 0, 0 },     //botti di grappa 
                        new int[3]{ 0, 0, 0 },     //botti di whisky 
                        new int[3]{ 0, 0, 0 },     //botti di gin 
                        new int[3]{ 0, 0, 0 },     //botti di brandy 
                        new int[3]{ 0, 0, 0 },     //botti di cognac
                        new int[3]{ 0, 0, 0 },     //botti di vodka 
                        new int[3]{ 0, 0, 0 }      //botti di rum 
                      };
        //Inizializzo l'array che contiene i nomi delle botti per chiamarle nel ciclo for 
        public static string[] nomeBotti = new string[8] { "botti di vino", "botti di grappa", "botti di whisky", "botti di gin", "botti di brandy", "botti di cognac", "botti di vodka", "botti di rum" };
        //Valori massimi di botti che può contenere la distilleria per evitare che l'utente inserisca valori eccessivi
        public static int bottiMinMaxCantina = 40, bottiMedMaxCantina = 20, bottiBigMaxCantina = 10;
        public static string NumeroMenù; //chiamo la variabile alla quale sarà assegnato il valore corrispondente al punto del menù che l'utente vuole mandare in esecuzione
        public static string NumeroMenùBotti; //variablie per lo spostamento fra i menù
        public static string Risposta; //variablie per lo spostamento fra i menù
        public static string Risposta2; //variablie per lo spostamento fra i menù
        public static int RiempiBotti; //Variabile che indica quante botti l'utente vuole riempire
        public static double Budget; //variablie che indica il denaro posseduto dalla distilleria
        public static double Guadagno; //variabile che indica il guadagno di ogni singola vendita di bottiglie
        public static int[] BottiglieComprate = new int[8]; //array che indica quante bottiglie vuote l'utente ha comprato per la distilleria
        //array che indica quante botti di ciascun distillato e di ciascuna grandezza sono piene
        public static int[][] bottiPiene = new int[8][]{
                        new int[3]{ 0, 0, 0 },     //botti di vino piene
                        new int[3]{ 0, 0, 0 },     //botti di grappa piene
                        new int[3]{ 0, 0, 0 },     //botti di whisky piene
                        new int[3]{ 0, 0, 0 },     //botti di gin piene
                        new int[3]{ 0, 0, 0 },     //botti di brandy piene
                        new int[3]{ 0, 0, 0 },     //botti di cognac piene
                        new int[3]{ 0, 0, 0 },     //botti di vodka piene
                        new int[3]{ 0, 0, 0 }     //botti di rum piene
                      };
        public static string[] contenutoFile = new string[8]; //array per il salvataggio su file
        //array con i nomi delle bottiglie
        public static string[] nomiBottiglie = new string[8] { "bottiglie di vino", "bottiglie di grappa", "bottiglie di whisky", "bottiglie di gin", "bottiglie di brandy", "bottiglie di cognac", "bottiglie di vodka", "bottiglie di rum" };
        public static int[] QuantitàBottiglie = new int[8]; //array che indica la quantità di bottiglie vuote possedute per ogni distillato
        public static int[] bottigliePiene = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 }; //array che indica le bottiglie piene per ogni distillato
        public static int BottiglieRiempite; //variablie che indica la quantità di bottiglie riempite
        public static int BottiUsate; //variabile che indica la quantità di botti usate per riempire le bottiglie
        //ulteriori stringhe per il salvataggio su file
        public static string nomeDelFile = "Botti.txt";
        public static string nomeFile = "Botti.txt";
        public static string percorsoFile = AppDomain.CurrentDomain.BaseDirectory + nomeDelFile;
        public static string nomeDelFile2 = "BottiPiene.txt";
        public static string nomeFile2 = "BottiPiene.txt";
        public static string percorsoFile2 = AppDomain.CurrentDomain.BaseDirectory + nomeDelFile2;
        public static string nomeDelFile3 = "BottiglieVuote.txt";
        public static string nomeFile3 = "BottiglieVuote.txt";
        public static string percorsoFile3 = AppDomain.CurrentDomain.BaseDirectory + nomeDelFile3;
        public static string nomeDelFile4 = "BottigliePiene.txt";
        public static string nomeFile4 = "BottigliePiene.txt";
        public static string percorsoFile4 = AppDomain.CurrentDomain.BaseDirectory + nomeDelFile4;

        static void Main(string[] args)
        {
            //il main serve solo per chiedere all'utente di inserire il budget iniziale della distilleria e per richiamare alcune funzioni necessarie al funzionamento del programma
            Console.WriteLine("Inserisci il budget in euro della distilleria");
            Budget = Convert.ToInt32(Console.ReadLine());
            salvataggio();
            salvataggio2();
            salvataggio3();
            salvataggio4();
            menù();
            Console.ReadKey();
        }
        //funzione per il salvataggio
        static void salvataggio()
        {
            {
                if (!File.Exists(percorsoFile))
                {
                    using (StreamWriter sw = File.CreateText(percorsoFile))
                    {

                    }

                }
                //cicli per salvare tutti i dati dell'array con botti vuote sul file
                for (int a = 0; a < 8; a++)
                {
                    string contenutoArray = $"{botti[a][0]};{botti[a][1]};{botti[a][2]}";
                    contenutoFile[a] = contenutoArray;
                }
                StreamWriter fileBottiVuote = new StreamWriter(percorsoFile, false);
                for (int i = 0; i < contenutoFile.Length; i++)
                {
                    fileBottiVuote.WriteLine(contenutoFile[i]);
                }
                fileBottiVuote.Close();
            }
        }
        static void salvataggio2()
        {
            {
                if (!File.Exists(percorsoFile2))
                {
                    using (StreamWriter sw = File.CreateText(percorsoFile2))
                    {

                    }

                }
                //cicli per salvare tutti i dati dell'array con botti vuote sul file
                for (int a = 0; a < 8; a++)
                {
                    string contenutoArray = $"{bottiPiene[a][0]};{bottiPiene[a][1]};{bottiPiene[a][2]}";
                    contenutoFile[a] = contenutoArray;
                }
                StreamWriter fileBottiPiene = new StreamWriter(percorsoFile2, false);
                for (int i = 0; i < contenutoFile.Length; i++)
                {
                    fileBottiPiene.WriteLine(contenutoFile[i]);
                }
                fileBottiPiene.Close();
            }
        }
        static void salvataggio3()
        {
            {
                if (!File.Exists(percorsoFile3))
                {
                    using (StreamWriter sw = File.CreateText(percorsoFile3))
                    {

                    }

                }
                //cicli per salvare tutti i dati dell'array con bottiglie vuote sul file
                for (int a = 0; a < 8; a++)
                {
                    string contenutoArray = $"{QuantitàBottiglie[a]}";
                    contenutoFile[a] = contenutoArray;
                }
                StreamWriter fileBottiglieVuote = new StreamWriter(percorsoFile3, false);
                for (int i = 0; i < contenutoFile.Length; i++)
                {
                    fileBottiglieVuote.WriteLine(contenutoFile[i]);
                }
                fileBottiglieVuote.Close();
            }
        }
        static void salvataggio4()
        {
            {
                if (!File.Exists(percorsoFile4))
                {
                    using (StreamWriter sw = File.CreateText(percorsoFile4))
                    {

                    }

                }
                //cicli per salvare tutti i dati dell'array con bottiglie piene sul file
                for (int a = 0; a < 8; a++)
                {
                    string contenutoArray = $"{bottigliePiene[a]}";
                    contenutoFile[a] = contenutoArray;
                }
                StreamWriter fileBottigliePiene = new StreamWriter(percorsoFile4, false);
                for (int i = 0; i < contenutoFile.Length; i++)
                {
                    fileBottigliePiene.WriteLine(contenutoFile[i]);
                }
                fileBottigliePiene.Close();
            }
        }
        //funzione per la selezione dei menù
        static void menù()
        {
            //controlli sui valori inseriti dall'utente, in caso di errore si ripete l'inserimento
            while (NumeroMenù != "*")
            {
                Console.WriteLine("\nMenù principale");
                Console.WriteLine("\nScrivi quale menù in cui devi andare\nScrivi 1 per andare nel menù delle botti\nScrivi 2 per andare nel menù di riempimento di botti" +
                    "\nScrivi 3 per andare nel menù delle bottiglie\nScrivi 4 per andare nel menù della vendita\nScrivi * per terminare il programma");
                NumeroMenù = Console.ReadLine(); //assunzione valore da tastiera
                while (NumeroMenù != "1" && NumeroMenù != "2" && NumeroMenù != "3" && NumeroMenù != "4" && NumeroMenù != "*")
                {
                    Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                    NumeroMenù = Console.ReadLine();
                }
                //selezione menù
                switch (NumeroMenù)
                {
                    case "1": MenùBotti(); break;
                    case "2": MenùRiempimentoBotti(); break;
                    case "3": MenùBottiglie(); break;
                    case "4": MenùCompravvendita(); break;
                    case "*": System.Environment.Exit(1); break;
                }
            }
        }
        //menù delle botti
        static void MenùBotti()
        {
            Console.WriteLine("\nMenùBotti");
            //cicli assegnare agli elementi dell'array le quantità di botti vuote per distillato e per grandezza
            for (int i = 0; i < 8; i++)
            {
                //botti piccole
                Console.WriteLine($"\nQuante {nomeBotti[i]} piccole hai in cantina?\nRisposta: ");
                botti[i][0] = Convert.ToInt32(Console.ReadLine());
                while (botti[i][0] < 0 || botti[i][0] > bottiMinMaxCantina)
                {
                    Console.WriteLine("\nReinsesci il numero di botti minime in cantina\nRisposta: ");
                    botti[i][0] = Convert.ToInt32(Console.ReadLine());
                }

                //botti medie
                Console.WriteLine($"\nQuante {nomeBotti[i]} medie hai in cantina?\nRisposta: ");
                botti[i][1] = Convert.ToInt32(Console.ReadLine());
                while (botti[i][1] < 0 || botti[i][1] > bottiMedMaxCantina)
                {
                    Console.WriteLine("\nReinsesci il numero di botti minime in cantina\nRisposta: ");
                    botti[i][1] = Convert.ToInt32(Console.ReadLine());
                }

                //botti grandi
                Console.WriteLine($"\nQuante {nomeBotti[i]} grandi hai in cantina?\nRisposta: ");
                botti[i][2] = Convert.ToInt32(Console.ReadLine());
                while (botti[i][2] < 0 || botti[i][2] > bottiBigMaxCantina)
                {
                    Console.WriteLine("\nReinsesci il numero di botti grandi in cantina\nRisposta: ");
                    botti[i][2] = Convert.ToInt32(Console.ReadLine());
                }
            }
            salvataggio();
        }
    }
}
