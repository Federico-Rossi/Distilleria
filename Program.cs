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
        //menù per il riempimento delle botti
        static void MenùRiempimentoBotti()
        {
            {
                Console.WriteLine("\nMenùRiempimentoBotti");
                //selezione dei menù delle botti in base al distillato con controlli
                Console.WriteLine("\nScrivi quali botti vuoi riempire in base al distillato\nScrivi 1 per le botti di vino\nScrivi 2 per le botti di grappa" +
                "\nScrivi 3 per le botti di whisky\nScrivi 4 per le botti di gin\nScrivi 5 per le botti di brandy\nScrivi 6 per le botti di cognac" +
                "\nScrivi 7 per le botti di vodka\nScrivi 8 per le botti di rum\nScrivi * per tornare al menù principale");
                NumeroMenùBotti = Console.ReadLine(); //assunzione valore da tastiera
                while (NumeroMenùBotti != "1" && NumeroMenùBotti != "2" && NumeroMenùBotti != "3" && NumeroMenùBotti != "4" && NumeroMenùBotti != "5" && NumeroMenùBotti != "6" && NumeroMenùBotti != "7" && NumeroMenùBotti != "8" && NumeroMenùBotti != "*")
                {
                    Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                    NumeroMenùBotti = Console.ReadLine();
                }
                switch (NumeroMenùBotti)
                {
                    case "1": MenùBottiVino(); break;
                    case "2": MenùBottiGrappa(); break;
                    case "3": MenùBottiWhisky(); break;
                    case "4": MenùBottiGin(); break;
                    case "5": MenùBottiBrandy(); break;
                    case "6": MenùBottiCognac(); break;
                    case "7": MenùBottiVodka(); break;
                    case "8": MenùBottiRum(); break;
                    case "*": menù(); break;
                }
                salvataggio2();
            }
        }

        static void MenùBottiVino()
        {
            //selezione grandezza botti da riempire con controlli
            Console.WriteLine("\nQuali botti di vino vuoi riempire?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBotti");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": BottiVinoPiccole(); break;
                case "2": BottiVinoMedie(); break;
                case "3": BottiVinoGrandi(); break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
        static void BottiVinoPiccole()
        {
            //chiedo all'utente quanti botti vuole riempire e controllo il valore inserito
            Console.WriteLine("\nQuante botti piccole di vino vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[0][0])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            //rinnovo il valore dei dati
            bottiPiene[0][0] = bottiPiene[0][0] + RiempiBotti;
            botti[0][0] = botti[0][0] - RiempiBotti;
        }
        static void BottiVinoMedie()
        {
            //chiedo all'utente quanti botti vuole riempire e controllo il valore inserito
            Console.WriteLine("\nQuante botti medie di vino vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[0][1])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[0][1] = bottiPiene[0][1] + RiempiBotti;
            botti[0][1] = botti[0][1] - RiempiBotti;
        }
        static void BottiVinoGrandi()
        {
            //chiedo all'utente quanti botti vuole riempire e controllo il valore inserito
            Console.WriteLine("\nQuante botti grandi di vino vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[0][2])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[0][2] = bottiPiene[0][2] + RiempiBotti;
            botti[0][2] = botti[0][2] - RiempiBotti;
        }

        static void MenùBottiGrappa()
        {
            Console.WriteLine("\nQuali botti di grappa vuoi riempire?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBotti");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": BottiGrappaPiccole(); break;
                case "2": BottiGrappaMedie(); break;
                case "3": BottiGrappaGrandi(); break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
        //ripeto il procedimento per il riempimento delle botti di vino anche per gli altri distillati e per le rispettive grandezze delle botti 
        static void BottiGrappaPiccole()
        {
            Console.WriteLine("\nQuante botti piccole di grappa vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[1][0])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[1][0] = bottiPiene[1][0] + RiempiBotti;
            botti[1][0] = botti[1][0] - RiempiBotti;
        }
        static void BottiGrappaMedie()
        {
            Console.WriteLine("\nQuante botti medie di grappa vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[1][1])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[1][1] = bottiPiene[1][1] + RiempiBotti;
            botti[1][1] = botti[1][1] - RiempiBotti;
        }
        static void BottiGrappaGrandi()
        {
            Console.WriteLine("\nQuante botti grandi di grappa vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[1][2])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[1][2] = bottiPiene[1][2] + RiempiBotti;
            botti[1][2] = botti[1][2] - RiempiBotti;
        }

        static void MenùBottiWhisky()
        {
            Console.WriteLine("\nQuali botti di whisky vuoi riempire?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBotti");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": BottiWhiskyPiccole(); break;
                case "2": BottiWhiskyMedie(); break;
                case "3": BottiWhiskyGrandi(); break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
        static void BottiWhiskyPiccole()
        {
            Console.WriteLine("\nQuante botti piccole di whisky vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[2][0])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[2][0] = bottiPiene[2][0] + RiempiBotti;
            botti[2][0] = botti[2][0] - RiempiBotti;
        }
        static void BottiWhiskyMedie()
        {
            Console.WriteLine("\nQuante botti medie di whisky vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[2][1])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[2][1] = bottiPiene[2][1] + RiempiBotti;
            botti[2][1] = botti[2][1] - RiempiBotti;
        }
        static void BottiWhiskyGrandi()
        {
            Console.WriteLine("\nQuante botti grandi di whisky vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[2][2])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[2][2] = bottiPiene[2][2] + RiempiBotti;
            botti[2][2] = botti[2][2] - RiempiBotti;
        }

        static void MenùBottiGin()
        {
            Console.WriteLine("\nQuali botti di gin vuoi riempire?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBotti");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": BottiGinPiccole(); break;
                case "2": BottiGinMedie(); break;
                case "3": BottiGinGrandi(); break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
        static void BottiGinPiccole()
        {
            Console.WriteLine("\nQuante botti piccole di gin vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[3][0])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[3][0] = bottiPiene[3][0] + RiempiBotti;
            botti[3][0] = botti[3][0] - RiempiBotti;
        }
        static void BottiGinMedie()
        {
            Console.WriteLine("\nQuante botti medie di gin vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[3][1])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[3][1] = bottiPiene[3][1] + RiempiBotti;
            botti[3][1] = botti[3][1] - RiempiBotti;
        }
        static void BottiGinGrandi()
        {
            Console.WriteLine("\nQuante botti grandi di gin vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[3][2])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[3][2] = bottiPiene[3][2] + RiempiBotti;
            botti[3][2] = botti[3][2] - RiempiBotti;
        }

        static void MenùBottiBrandy()
        {
            Console.WriteLine("\nQuali botti di brandy vuoi riempire?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBotti");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": BottiBrandyPiccole(); break;
                case "2": BottiBrandyMedie(); break;
                case "3": BottiBrandyGrandi(); break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
        static void BottiBrandyPiccole()
        {
            Console.WriteLine("\nQuante botti piccole di brandy vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[4][0])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[4][0] = bottiPiene[4][0] + RiempiBotti;
            botti[4][0] = botti[4][0] - RiempiBotti;
        }
        static void BottiBrandyMedie()
        {
            Console.WriteLine("\nQuante botti medie di brandy vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[4][1])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[4][1] = bottiPiene[4][1] + RiempiBotti;
            botti[4][1] = botti[4][1] - RiempiBotti;
        }
        static void BottiBrandyGrandi()
        {
            Console.WriteLine("\nQuante botti grandi di brandy vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[4][2])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[4][2] = bottiPiene[4][2] + RiempiBotti;
            botti[4][2] = botti[4][2] - RiempiBotti;
        }

        static void MenùBottiCognac()
        {
            Console.WriteLine("\nQuali botti di cognac vuoi riempire?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBotti");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": BottiCognacPiccole(); break;
                case "2": BottiCognacMedie(); break;
                case "3": BottiCognacGrandi(); break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
        static void BottiCognacPiccole()
        {
            Console.WriteLine("\nQuante botti piccole di cognac vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[5][0])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[5][0] = bottiPiene[5][0] + RiempiBotti;
            botti[5][0] = botti[5][0] - RiempiBotti;
        }
        static void BottiCognacMedie()
        {
            Console.WriteLine("\nQuante botti medie di cognac vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[5][1])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[5][1] = bottiPiene[5][1] + RiempiBotti;
            botti[5][1] = botti[5][1] - RiempiBotti;
        }
        static void BottiCognacGrandi()
        {
            Console.WriteLine("\nQuante botti grandi di cognac vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[5][2])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[5][2] = bottiPiene[5][2] + RiempiBotti;
            botti[5][2] = botti[5][2] - RiempiBotti;
        }

        static void MenùBottiVodka()
        {
            Console.WriteLine("\nQuali botti di vodka vuoi riempire?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBotti");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": BottiVodkaPiccole(); break;
                case "2": BottiVodkaMedie(); break;
                case "3": BottiVodkaGrandi(); break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
        static void BottiVodkaPiccole()
        {
            Console.WriteLine("\nQuante botti piccole di vodka vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[6][0])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[6][0] = bottiPiene[6][0] + RiempiBotti;
            botti[6][0] = botti[6][0] - RiempiBotti;
        }
        static void BottiVodkaMedie()
        {
            Console.WriteLine("\nQuante botti medie di vodka vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[6][1])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[6][1] = bottiPiene[6][1] + RiempiBotti;
            botti[6][1] = botti[6][1] - RiempiBotti;
        }
        static void BottiVodkaGrandi()
        {
            Console.WriteLine("\nQuante botti grandi di vodka vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[6][2])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[6][2] = bottiPiene[6][2] + RiempiBotti;
            botti[6][2] = botti[6][2] - RiempiBotti;
        }

        static void MenùBottiRum()
        {
            Console.WriteLine("\nQuali botti di Rum vuoi riempire?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBotti");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": BottiRumPiccole(); break;
                case "2": BottiRumMedie(); break;
                case "3": BottiRumGrandi(); break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
        static void BottiRumPiccole()
        {
            Console.WriteLine("\nQuante botti piccole di rum vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[7][0])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[7][0] = bottiPiene[7][0] + RiempiBotti;
            botti[7][0] = botti[7][0] - RiempiBotti;
        }
        static void BottiRumMedie()
        {
            Console.WriteLine("\nQuante botti medie di rum vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[7][1])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[7][1] = bottiPiene[7][1] + RiempiBotti;
            botti[7][1] = botti[7][1] - RiempiBotti;
        }
        static void BottiRumGrandi()
        {
            Console.WriteLine("\nQuante botti grandi di rum vuoi riempire? Inserisci un numero intero\nRisposta: ");
            RiempiBotti = Convert.ToInt32(Console.ReadLine());
            while (RiempiBotti < 0 && RiempiBotti > botti[7][2])
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                RiempiBotti = Convert.ToInt32(Console.ReadLine());
            }
            bottiPiene[7][2] = bottiPiene[7][2] + RiempiBotti;
            botti[7][2] = botti[7][2] - RiempiBotti;
        }

        static void MenùBottiglie()
        {
            Console.WriteLine("MenùBottiglie");
            //ciclo per assegnare agli elementi dell'array le quantità di bottiglie vuote per ogni distillato
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"\nQuante {nomiBottiglie[i]} possiede la distilleria?\nRisposta: ");
                QuantitàBottiglie[i] = Convert.ToInt32(Console.ReadLine());
                //controllo i valori inseriti dall'utente, in caso di errore l'utente li inserisce nuovamente
                while (QuantitàBottiglie[i] < 0)
                {
                    Console.WriteLine($"\nReinsesci il numero di {nomiBottiglie[i]} in cantina\nRisposta: ");
                    QuantitàBottiglie[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            //selezione menù di riempimento delle bottiglie in base al distillato che devono contenere
            Console.WriteLine("\nDi quale distillato vuoi riempire le bottiglie?\nScrivi 1 per le bottiglie di vino\nScrivi 2 per le bottiglie di grappa" +
            "\nScrivi 3 per le bottiglie di whisky\n\nScrivi 4 per le bottiglie di gin\nScrivi 5 per le bottiglie di brandy" +
            "Scrivi 6 per le bottiglie di cognac\nScrivi 7 per le bottiglie di vodka\nScrivi 8 per le bottiglie di rum\nScrivi * per tornare al menù principale");
            Risposta = Console.ReadLine(); //assunzione valore da tastiera
            //controllo il valore inserito dall'utente
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "4" && Risposta != "5" && Risposta != "6" && Risposta != "7" && Risposta != "8" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": MenùBottiglieVino(); break;
                case "2": MenùBottiglieGrappa(); break;
                case "3": MenùBottiglieWhisky(); break;
                case "4": MenùBottiglieGin(); break;
                case "5": MenùBottiglieBrandy(); break;
                case "6": MenùBottiglieCognac(); break;
                case "7": MenùBottiglieVodka(); break;
                case "8": MenùBottiglieRum(); break;
                case "*": menù(); break;
            }
            salvataggio3();
            salvataggio4();
        }

        static void MenùBottiglieVino()
        {
            //chiedo all'utente quali botti, in base alla grandezza, vuole usare per riempire le bottiglie
            Console.WriteLine("\nQuali botti di vino vuoi utilizzare pr riempire le bottiglie?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBottiglie");
            Risposta = Console.ReadLine();
            //assunzione da tastiera e controllo
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1":
                    //botti piccole
                    Console.WriteLine("\nHai selezionato le botti piccole");
                    //chiedo all'utente quante botti vuole usare per riempire le bottiglie
                    Console.WriteLine("\nQuante botti piccole di vino vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine()); //assunzione da tastiera
                    BottiglieRiempite = (BottiUsate * 225000) / 750; //calcoli per la conversione dei dati
                    botti[0][0] = botti[0][0] - BottiUsate;
                    bottiPiene[0][0] = bottiPiene[0][0] + BottiUsate;
                    //controllo che le bottiglie vuote siano abbastanza
                    while (BottiglieRiempite > QuantitàBottiglie[0])
                    {
                        //chiedo all'utente di comprare nuove bottiglie vuote al menù per la compravvendita o di reinserire la quantità di botti da utilizzare
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        //controllo la risposta e reindirizzo l'utente al menù selezionato
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieVino();
                        }
                    }
                    //dichiaro all'utente quante bottiglie ha riempito
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[0]);
                    //modifico i dati
                    bottigliePiene[0] = bottigliePiene[0] + BottiglieRiempite;
                    QuantitàBottiglie[0] = QuantitàBottiglie[0] - BottiglieRiempite;
                    break;
                //ripeto il procedimento per tutti i distillati e per le rgrandezze delle botti usate cambiando i dati
                case "2":
                    Console.WriteLine("\nHai selezionato le botti medie");
                    Console.WriteLine("\nQuante botti medie di vino vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 1500000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[0])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieVino();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[0]);
                    botti[0][1] = botti[0][1] - BottiUsate;
                    bottiPiene[0][1] = bottiPiene[0][1] + BottiUsate;
                    bottigliePiene[0] = bottigliePiene[0] + BottiglieRiempite;
                    QuantitàBottiglie[0] = QuantitàBottiglie[0] - BottiglieRiempite;
                    break;
                case "3":
                    Console.WriteLine("\nHai selezionato le botti grandi");
                    Console.WriteLine("\nQuante botti grandi di vino vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 4000000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[0])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieVino();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[0]);
                    botti[0][2] = botti[0][2] - BottiUsate;
                    bottiPiene[0][2] = bottiPiene[0][2] + BottiUsate;
                    bottigliePiene[0] = bottigliePiene[0] + BottiglieRiempite;
                    QuantitàBottiglie[0] = QuantitàBottiglie[0] - BottiglieRiempite;
                    break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }

        static void MenùBottiglieGrappa()
        {
            Console.WriteLine("\nQuali botti di grappa vuoi utilizzare pr riempire le bottiglie?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBottiglie");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1":
                    Console.WriteLine("\nHai selezionato le botti piccole");
                    Console.WriteLine("\nQuante botti piccole di grappa vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 225000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[1])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieGrappa();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[1]);
                    botti[1][0] = botti[1][0] - BottiUsate;
                    bottiPiene[1][0] = bottiPiene[1][0] + BottiUsate;
                    bottigliePiene[1] = bottigliePiene[1] + BottiglieRiempite;
                    QuantitàBottiglie[1] = QuantitàBottiglie[1] - BottiglieRiempite;
                    break;
                case "2":
                    Console.WriteLine("\nHai selezionato le botti medie");
                    Console.WriteLine("\nQuante botti medie di grappa vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 1500000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[1])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieGrappa();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[1]);
                    botti[1][1] = botti[1][1] - BottiUsate;
                    bottiPiene[1][1] = bottiPiene[1][1] + BottiUsate;
                    bottigliePiene[1] = bottigliePiene[1] + BottiglieRiempite;
                    QuantitàBottiglie[1] = QuantitàBottiglie[1] - BottiglieRiempite;
                    break;
                case "3":
                    Console.WriteLine("\nHai selezionato le botti grandi");
                    Console.WriteLine("\nQuante botti grandi di grappa vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 4000000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[1])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieGrappa();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[1]);
                    botti[1][2] = botti[1][2] - BottiUsate;
                    bottiPiene[1][2] = bottiPiene[1][2] + BottiUsate;
                    bottigliePiene[1] = bottigliePiene[1] + BottiglieRiempite;
                    QuantitàBottiglie[1] = QuantitàBottiglie[1] - BottiglieRiempite;
                    break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }

        static void MenùBottiglieWhisky()
        {
            Console.WriteLine("\nQuali botti di vino vuoi utilizzare pr riempire le bottiglie?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBottiglie");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1":
                    Console.WriteLine("\nHai selezionato le botti piccole");
                    Console.WriteLine("\nQuante botti piccole di whisky vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 225000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[2])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieWhisky();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[2]);
                    botti[2][0] = botti[2][0] - BottiUsate;
                    bottiPiene[2][0] = bottiPiene[2][0] + BottiUsate;
                    bottigliePiene[2] = bottigliePiene[2] + BottiglieRiempite;
                    QuantitàBottiglie[2] = QuantitàBottiglie[2] - BottiglieRiempite;
                    break;
                case "2":
                    Console.WriteLine("\nHai selezionato le botti medie");
                    Console.WriteLine("\nQuante botti medie di whisky vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 1500000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[2])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieWhisky();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[2]);
                    botti[2][1] = botti[2][1] - BottiUsate;
                    bottiPiene[2][1] = bottiPiene[2][1] + BottiUsate;
                    bottigliePiene[2] = bottigliePiene[2] + BottiglieRiempite;
                    QuantitàBottiglie[2] = QuantitàBottiglie[2] - BottiglieRiempite;
                    break;
                case "3":
                    Console.WriteLine("\nHai selezionato le botti grandi");
                    Console.WriteLine("\nQuante botti grandi di whisky vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 4000000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[2])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieWhisky();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[2]);
                    botti[2][2] = botti[2][2] - BottiUsate;
                    bottiPiene[2][2] = bottiPiene[2][2] + BottiUsate;
                    bottigliePiene[2] = bottigliePiene[2] + BottiglieRiempite;
                    QuantitàBottiglie[2] = QuantitàBottiglie[2] - BottiglieRiempite;
                    break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }

        static void MenùBottiglieGin()
        {
            Console.WriteLine("\nQuali botti di gin vuoi utilizzare pr riempire le bottiglie?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBottiglie");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1":
                    Console.WriteLine("\nHai selezionato le botti piccole");
                    Console.WriteLine("\nQuante botti piccole di gin vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 225000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[3])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieGin();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[3]);
                    botti[3][0] = botti[3][0] - BottiUsate;
                    bottiPiene[3][0] = bottiPiene[3][0] + BottiUsate;
                    bottigliePiene[3] = bottigliePiene[3] + BottiglieRiempite;
                    QuantitàBottiglie[3] = QuantitàBottiglie[3] - BottiglieRiempite;
                    break;
                case "2":
                    Console.WriteLine("\nHai selezionato le botti medie");
                    Console.WriteLine("\nQuante botti medie di gin vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 1500000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[3])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieGin();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[3]);
                    botti[3][1] = botti[3][1] - BottiUsate;
                    bottiPiene[3][1] = bottiPiene[3][1] + BottiUsate;
                    bottigliePiene[3] = bottigliePiene[3] + BottiglieRiempite;
                    QuantitàBottiglie[3] = QuantitàBottiglie[3] - BottiglieRiempite;
                    break;
                case "3":
                    Console.WriteLine("\nHai selezionato le botti grandi");
                    Console.WriteLine("\nQuante botti grandi di gin vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 4000000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[3])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieGin();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[3]);
                    botti[3][2] = botti[3][2] - BottiUsate;
                    bottiPiene[3][2] = bottiPiene[3][2] + BottiUsate;
                    bottigliePiene[3] = bottigliePiene[3] + BottiglieRiempite;
                    QuantitàBottiglie[3] = QuantitàBottiglie[3] - BottiglieRiempite;
                    break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }

        static void MenùBottiglieBrandy()
        {
            Console.WriteLine("\nQuali botti di brandy vuoi utilizzare pr riempire le bottiglie?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBottiglie");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1":
                    Console.WriteLine("\nHai selezionato le botti piccole");
                    Console.WriteLine("\nQuante botti piccole di brandy vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 225000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[4])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieBrandy();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[4]);
                    botti[4][0] = botti[4][0] - BottiUsate;
                    bottiPiene[4][0] = bottiPiene[4][0] + BottiUsate;
                    bottigliePiene[4] = bottigliePiene[4] + BottiglieRiempite;
                    QuantitàBottiglie[4] = QuantitàBottiglie[4] - BottiglieRiempite;
                    break;
                case "2":
                    Console.WriteLine("\nHai selezionato le botti medie");
                    Console.WriteLine("\nQuante botti medie di brandy vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 1500000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[4])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieBrandy();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[4]);
                    botti[4][1] = botti[4][1] - BottiUsate;
                    bottiPiene[4][1] = bottiPiene[4][1] + BottiUsate;
                    bottigliePiene[4] = bottigliePiene[4] + BottiglieRiempite;
                    QuantitàBottiglie[4] = QuantitàBottiglie[4] - BottiglieRiempite;
                    break;
                case "3":
                    Console.WriteLine("\nHai selezionato le botti grandi");
                    Console.WriteLine("\nQuante botti grandi di brandy vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 4000000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[4])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieBrandy();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[4]);
                    botti[4][2] = botti[4][2] - BottiUsate;
                    bottiPiene[4][2] = bottiPiene[4][2] + BottiUsate;
                    bottigliePiene[4] = bottigliePiene[4] + BottiglieRiempite;
                    QuantitàBottiglie[4] = QuantitàBottiglie[4] - BottiglieRiempite;
                    break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }

        static void MenùBottiglieCognac()
        {
            Console.WriteLine("\nQuali botti di cognac vuoi utilizzare pr riempire le bottiglie?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBottiglie");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1":
                    Console.WriteLine("\nHai selezionato le botti piccole");
                    Console.WriteLine("\nQuante botti piccole di cognac vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 225000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[5])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieCognac();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[5]);
                    botti[5][0] = botti[5][0] - BottiUsate;
                    bottiPiene[5][0] = bottiPiene[5][0] + BottiUsate;
                    bottigliePiene[5] = bottigliePiene[5] + BottiglieRiempite;
                    QuantitàBottiglie[5] = QuantitàBottiglie[5] - BottiglieRiempite;
                    break;
                case "2":
                    Console.WriteLine("\nHai selezionato le botti medie");
                    Console.WriteLine("\nQuante botti medie di cognac vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 1500000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[5])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieCognac();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[5]);
                    botti[5][1] = botti[5][1] - BottiUsate;
                    bottiPiene[5][1] = bottiPiene[5][1] + BottiUsate;
                    bottigliePiene[5] = bottigliePiene[5] + BottiglieRiempite;
                    QuantitàBottiglie[5] = QuantitàBottiglie[5] - BottiglieRiempite;
                    break;
                case "3":
                    Console.WriteLine("\nHai selezionato le botti grandi");
                    Console.WriteLine("\nQuante botti grandi di cognac vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 4000000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[5])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieCognac();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[5]);
                    botti[5][2] = botti[5][2] - BottiUsate;
                    bottiPiene[5][2] = bottiPiene[5][2] + BottiUsate;
                    bottigliePiene[5] = bottigliePiene[5] + BottiglieRiempite;
                    QuantitàBottiglie[5] = QuantitàBottiglie[5] - BottiglieRiempite;
                    break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }

        static void MenùBottiglieVodka()
        {
            Console.WriteLine("\nQuali botti di vodka vuoi utilizzare pr riempire le bottiglie?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBottiglie");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1":
                    Console.WriteLine("\nHai selezionato le botti piccole");
                    Console.WriteLine("\nQuante botti piccole di vodka vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 225000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[6])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieVodka();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[6]);
                    botti[6][0] = botti[6][0] - BottiUsate;
                    bottiPiene[6][0] = bottiPiene[6][0] + BottiUsate;
                    bottigliePiene[6] = bottigliePiene[6] + BottiglieRiempite;
                    QuantitàBottiglie[6] = QuantitàBottiglie[6] - BottiglieRiempite;
                    break;
                case "2":
                    Console.WriteLine("\nHai selezionato le botti medie");
                    Console.WriteLine("\nQuante botti medie di vodka vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 1500000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[6])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieVodka();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[6]);
                    botti[6][1] = botti[6][1] - BottiUsate;
                    bottiPiene[6][1] = bottiPiene[6][1] + BottiUsate;
                    bottigliePiene[6] = bottigliePiene[6] + BottiglieRiempite;
                    QuantitàBottiglie[6] = QuantitàBottiglie[6] - BottiglieRiempite;
                    break;
                case "3":
                    Console.WriteLine("\nHai selezionato le botti grandi");
                    Console.WriteLine("\nQuante botti grandi di vodka vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 4000000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[6])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieVodka();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[6]);
                    botti[6][2] = botti[6][2] - BottiUsate;
                    bottiPiene[6][2] = bottiPiene[6][2] + BottiUsate;
                    bottigliePiene[6] = bottigliePiene[6] + BottiglieRiempite;
                    QuantitàBottiglie[6] = QuantitàBottiglie[6] - BottiglieRiempite;
                    break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }

        static void MenùBottiglieRum()
        {
            Console.WriteLine("\nQuali botti di rum vuoi utilizzare pr riempire le bottiglie?\nScrivi 1 per quelle piccole\nScrivi 2 per quelle medie\nScrivi 3 per quelle grandi\nScrivi * per tornare al MenùRiempimentoBottiglie");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1":
                    Console.WriteLine("\nHai selezionato le botti piccole");
                    Console.WriteLine("\nQuante botti piccole di rum vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 225000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[7])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieRum();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[7]);
                    botti[7][0] = botti[7][0] - BottiUsate;
                    bottiPiene[7][0] = bottiPiene[7][0] + BottiUsate;
                    bottigliePiene[7] = bottigliePiene[7] + BottiglieRiempite;
                    QuantitàBottiglie[7] = QuantitàBottiglie[7] - BottiglieRiempite;
                    break;
                case "2":
                    Console.WriteLine("\nHai selezionato le botti medie");
                    Console.WriteLine("\nQuante botti medie di rum vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 1500000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[7])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieRum();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[7]);
                    botti[7][1] = botti[7][1] - BottiUsate;
                    bottiPiene[7][1] = bottiPiene[7][1] + BottiUsate;
                    bottigliePiene[7] = bottigliePiene[7] + BottiglieRiempite;
                    QuantitàBottiglie[7] = QuantitàBottiglie[7] - BottiglieRiempite;
                    break;
                case "3":
                    Console.WriteLine("\nHai selezionato le botti grandi");
                    Console.WriteLine("\nQuante botti grandi di rum vuoi usare?\nRisposta: ");
                    BottiUsate = Convert.ToInt32(Console.ReadLine());
                    BottiglieRiempite = (BottiUsate * 4000000) / 750;
                    while (BottiglieRiempite > QuantitàBottiglie[7])
                    {
                        Console.WriteLine("\nLe bottiglie da riempire sono più di quelle possedute dalla distilleria");
                        Console.WriteLine("\nScrivi 1 per comprare altre bottiglie\nScrivi 2 per reinserire la quantità di botti da utilizzare");
                        Risposta2 = Console.ReadLine();
                        while (Risposta2 != "1" && Risposta2 != "2")
                        {
                            Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                            Risposta2 = Console.ReadLine();
                        }
                        if (Risposta2 == "1")
                        {
                            MenùCompravvendita();
                        }
                        if (Risposta2 == "2")
                        {
                            MenùBottiglieRum();
                        }
                    }
                    Console.WriteLine("\nHai riempito " + BottiglieRiempite + nomiBottiglie[7]);
                    botti[7][2] = botti[7][2] - BottiUsate;
                    bottiPiene[7][2] = bottiPiene[7][2] + BottiUsate;
                    bottigliePiene[7] = bottigliePiene[7] + BottiglieRiempite;
                    QuantitàBottiglie[7] = QuantitàBottiglie[7] - BottiglieRiempite;
                    break;
                case "*": MenùRiempimentoBotti(); break;
            }
        }
    }
    //menù della compravvendita
        static void MenùCompravvendita()
        {
            Console.WriteLine("\nMenùCompravvendità");
            //selezione dei menù con inserimento da tastiera e controllo del valore
            Console.WriteLine("\nScrivi 1 per comprare bottiglie\nScrivi 2 per vendere bottiglie\nScrivi * per tornare al menù principale");
            Risposta = Console.ReadLine();
            while (Risposta != "1" && Risposta != "2" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            switch (Risposta)
            {
                case "1": MenùCompraBottiglie(); break;
                case "2": MenùVendiBottiglie(); break;
                case "*": menù(); break;
            }
        }
        //menù per comprare bottiglie
        static void MenùCompraBottiglie()
        {
            //tramite assunzione da tastiera chiedo all'utente per quale distillato vuole comprare le bottiglie e controllo il valore inserito
            Console.WriteLine("\nDi quale distillato vuoi comprare le bottiglie?\nScrivi 1 per il vino\nScrivi 2 per la grappa\nScrivi 3 per il whisky" +
            "Scrivi 4 per il gin\nScrivi 5 per il brandy\nScrivi 6 per il cognac\nScrivi 7 per la vodka\nScrivi 8 per il rum\nScrivi * per tornare al MenùCompravvendita");
            Risposta = Console.ReadLine();
            while(Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "4" && Risposta != "5" && Risposta != "6" && Risposta != "7" && Risposta != "8" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            int NumeroBottiglie; //variabile per indicare la quuantità di bottiglie comprate
            double Spesa; //variabile che indica la spesa per l'acquisto di bottiglie
            switch (Risposta)
            {
                case "1":
                    //chiedo all'utente quante bottiglie vuole comprare
                    Console.WriteLine("\nQuante bottiglie per il vino vuoi comprare?\nUna bottiglia vuota da 750 ml standard costa circa 1,5 euro");
                    Console.WriteLine("\nIl tuo budget è di: " + Budget + "euro"); //ricordo all'utente quanti soldi possiede
                    NumeroBottiglie = Convert.ToInt32(Console.ReadLine()); //bottiglie comprate
                    Spesa = NumeroBottiglie * 1.5; //calcolo della spesa
                    Budget = Budget - Spesa; //sottrazione della spesa dal budget
                    QuantitàBottiglie[0] = QuantitàBottiglie[0] + NumeroBottiglie; //modifica ai dati sulle bottiglie
                    break;
                    //ripeto il procedimento per tutti i distillati
                case "2":
                    Console.WriteLine("\nQuante bottiglie per la grappa vuoi comprare?\nUna bottiglia vuota da 750 ml standard costa circa 1,5 euro");
                    Console.WriteLine("\nIl tuo budget è di: " + Budget + "euro");
                    NumeroBottiglie = Convert.ToInt32(Console.ReadLine());
                    Spesa = NumeroBottiglie * 1.5;
                    Budget = Budget - Spesa;
                    QuantitàBottiglie[1] = QuantitàBottiglie[1] + NumeroBottiglie;
                    break;
                case "3":
                    Console.WriteLine("\nQuante bottiglie per il whisky vuoi comprare?\nUna bottiglia vuota da 750 ml standard costa circa 1,5 euro");
                    Console.WriteLine("\nIl tuo budget è di: " + Budget + "euro");
                    NumeroBottiglie = Convert.ToInt32(Console.ReadLine());
                    Spesa = NumeroBottiglie * 1.5;
                    Budget = Budget - Spesa;
                    QuantitàBottiglie[2] = QuantitàBottiglie[2] + NumeroBottiglie;
                    break;
                case "4":
                    Console.WriteLine("\nQuante bottiglie per il gin vuoi comprare?\nUna bottiglia vuota da 750 ml standard costa circa 1,5 euro");
                    Console.WriteLine("\nIl tuo budget è di: " + Budget + "euro");
                    NumeroBottiglie = Convert.ToInt32(Console.ReadLine());
                    Spesa = NumeroBottiglie * 1.5;
                    Budget = Budget - Spesa;
                    QuantitàBottiglie[3] = QuantitàBottiglie[3] + NumeroBottiglie;
                    break;
                case "5":
                    Console.WriteLine("\nQuante bottiglie per il brandy vuoi comprare?\nUna bottiglia vuota da 750 ml standard costa circa 1,5 euro");
                    Console.WriteLine("\nIl tuo budget è di: " + Budget + "euro");
                    NumeroBottiglie = Convert.ToInt32(Console.ReadLine());
                    Spesa = NumeroBottiglie * 1.5;
                    Budget = Budget - Spesa;
                    QuantitàBottiglie[4] = QuantitàBottiglie[4] + NumeroBottiglie;
                    break;
                case "6":
                    Console.WriteLine("\nQuante bottiglie per il cognac vuoi comprare?\nUna bottiglia vuota da 750 ml standard costa circa 1,5 euro");
                    Console.WriteLine("\nIl tuo budget è di: " + Budget + "euro");
                    NumeroBottiglie = Convert.ToInt32(Console.ReadLine());
                    Spesa = NumeroBottiglie * 1.5;
                    Budget = Budget - Spesa;
                    QuantitàBottiglie[5] = QuantitàBottiglie[5] + NumeroBottiglie;
                    break;
                case "7":
                    Console.WriteLine("\nQuante bottiglie per la vodka vuoi comprare?\nUna bottiglia vuota da 750 ml standard costa circa 1,5 euro");
                    Console.WriteLine("\nIl tuo budget è di: " + Budget + "euro");
                    NumeroBottiglie = Convert.ToInt32(Console.ReadLine());
                    Spesa = NumeroBottiglie * 1.5;
                    Budget = Budget - Spesa;
                    QuantitàBottiglie[6] = QuantitàBottiglie[6] + NumeroBottiglie;
                    break;
                case "8":
                    Console.WriteLine("\nQuante bottiglie per il rum vuoi comprare?\nUna bottiglia vuota da 750 ml standard costa circa 1,5 euro");
                    Console.WriteLine("\nIl tuo budget è di: " + Budget + "euro");
                    NumeroBottiglie = Convert.ToInt32(Console.ReadLine());
                    Spesa = NumeroBottiglie * 1.5;
                    Budget = Budget - Spesa;
                    QuantitàBottiglie[7] = QuantitàBottiglie[7] + NumeroBottiglie;
                    break;
                case "*": menù(); break;
            }
        }
        //menù per la vendita delle bottiglie
        static void MenùVendiBottiglie()
        {
            //chiedo all'utente di quale distillato vuole vendere le bottiglie 
            Console.WriteLine("\nDi quale distillato vuoi vendere le bottiglie?\nScrivi 1 per il vino\nScrivi 2 per la grappa\nScrivi 3 per il whisky" +
            "Scrivi 4 per il gin\nScrivi 5 per il brandy\nScrivi 6 per il cognac\nScrivi 7 per la vodka\nScrivi 8 per il rum\nScrivi * per tornare al MenùCompravvendita");
            Risposta = Console.ReadLine(); //assunzione da tastiera e controllo del valore
            while (Risposta != "1" && Risposta != "2" && Risposta != "3" && Risposta != "4" && Risposta != "5" && Risposta != "6" && Risposta != "7" && Risposta != "8" && Risposta != "*")
            {
                Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                Risposta = Console.ReadLine();
            }
            int[] PrezzoBottiglie = new int[8]; //array con i prezzi delle bottiglie
            int VendiBottiglie; //variabile con quantità di bottiglie da vendere
            switch (Risposta) //selezione distillati
            {
                case "1":
                    //chiedo all'utente di inserire il prezzo della bottiglia singola
                    Console.WriteLine("\nInserisci il prezzo di una singola bottiglia di vino in euro");
                    PrezzoBottiglie[0] = Convert.ToInt32(Console.ReadLine()); //assunzione da tastiera
                    Console.WriteLine("\nQuante bottiglie di vino devi vendere?"); //chiedo all'utente la quantità di bottiglie da vendere
                    VendiBottiglie = Convert.ToInt32(Console.ReadLine()); //assunzione da tastiera
                    while (VendiBottiglie > QuantitàBottiglie[0]) //controllo che le bottiglie da vendere non superino quelle possedute 
                    {
                        Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                        VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    }
                    QuantitàBottiglie[0] = QuantitàBottiglie[0] - VendiBottiglie; //calcoli per modificare i dati
                    Guadagno = VendiBottiglie * PrezzoBottiglie[0];
                    Console.WriteLine("\nHai guadagnato: " + Guadagno + " euro"); //dichiaro all'utente il guadagno e il budget complessivo dopo la vendita
                    Budget = Budget + Guadagno;
                    Console.WriteLine("\nAttualmente possiedi: " + Budget + " euro");
                    break;
                    //ripeto il procedimento per tutti gli altri distillati
                case "2":
                    Console.WriteLine("\nInserisci il prezzo di una singola bottiglia di grappa in euro");
                    PrezzoBottiglie[1] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nQuante bottiglie di grappa devi vendere?");
                    VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    while (VendiBottiglie > QuantitàBottiglie[1])
                    {
                        Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                        VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    }
                    QuantitàBottiglie[1] = QuantitàBottiglie[1] - VendiBottiglie;
                    Guadagno = VendiBottiglie * PrezzoBottiglie[1];
                    Console.WriteLine("\nHai guadagnato: " + Guadagno + " euro");
                    Budget = Budget + Guadagno;
                    Console.WriteLine("\nAttualmente possiedi: " + Budget + " euro");
                    break;
                case "3":
                    Console.WriteLine("\nInserisci il prezzo di una singola bottiglia di whisky in euro");
                    PrezzoBottiglie[2] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nQuante bottiglie di whisky devi vendere?");
                    VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    while (VendiBottiglie > QuantitàBottiglie[2])
                    {
                        Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                        VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    }
                    QuantitàBottiglie[2] = QuantitàBottiglie[2] - VendiBottiglie;
                    Guadagno = VendiBottiglie * PrezzoBottiglie[2];
                    Console.WriteLine("\nHai guadagnato: " + Guadagno + " euro");
                    Budget = Budget + Guadagno;
                    Console.WriteLine("\nAttualmente possiedi: " + Budget + " euro");
                    break;
                case "4":
                    Console.WriteLine("\nInserisci il prezzo di una singola bottiglia di gin in euro");
                    PrezzoBottiglie[3] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nQuante bottiglie di gin devi vendere?");
                    VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    while (VendiBottiglie > QuantitàBottiglie[3])
                    {
                        Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                        VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    }
                    QuantitàBottiglie[3] = QuantitàBottiglie[3] - VendiBottiglie;
                    Guadagno = VendiBottiglie * PrezzoBottiglie[3];
                    Console.WriteLine("\nHai guadagnato: " + Guadagno + " euro");
                    Budget = Budget + Guadagno;
                    Console.WriteLine("\nAttualmente possiedi: " + Budget + " euro");
                    break;
                case "5":
                    Console.WriteLine("\nInserisci il prezzo di una singola bottiglia di brandy in euro");
                    PrezzoBottiglie[4] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nQuante bottiglie di brandy devi vendere?");
                    VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    while (VendiBottiglie > QuantitàBottiglie[4])
                    {
                        Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                        VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    }
                    QuantitàBottiglie[4] = QuantitàBottiglie[4] - VendiBottiglie;
                    Guadagno = VendiBottiglie * PrezzoBottiglie[4];
                    Console.WriteLine("\nHai guadagnato: " + Guadagno + " euro");
                    Budget = Budget + Guadagno;
                    Console.WriteLine("\nAttualmente possiedi: " + Budget + " euro");
                    break;
                case "6":
                    Console.WriteLine("\nInserisci il prezzo di una singola bottiglia di cognac in euro");
                    PrezzoBottiglie[5] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nQuante bottiglie di cognac devi vendere?");
                    VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    while (VendiBottiglie > QuantitàBottiglie[1])
                    {
                        Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                        VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    }
                    QuantitàBottiglie[5] = QuantitàBottiglie[5] - VendiBottiglie;
                    Guadagno = VendiBottiglie * PrezzoBottiglie[5];
                    Console.WriteLine("\nHai guadagnato: " + Guadagno + " euro");
                    Budget = Budget + Guadagno;
                    Console.WriteLine("\nAttualmente possiedi: " + Budget + " euro");
                    break;
                case "7":
                    Console.WriteLine("\nInserisci il prezzo di una singola bottiglia di vodka in euro");
                    PrezzoBottiglie[6] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nQuante bottiglie di vodka devi vendere?");
                    VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    while (VendiBottiglie > QuantitàBottiglie[6])
                    {
                        Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                        VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    }
                    QuantitàBottiglie[6] = QuantitàBottiglie[6] - VendiBottiglie;
                    Guadagno = VendiBottiglie * PrezzoBottiglie[6];
                    Console.WriteLine("\nHai guadagnato: " + Guadagno + " euro");
                    Budget = Budget + Guadagno;
                    Console.WriteLine("\nAttualmente possiedi: " + Budget + " euro");
                    break;
                case "8":
                    Console.WriteLine("\nInserisci il prezzo di una singola bottiglia di rum in euro");
                    PrezzoBottiglie[7] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nQuante bottiglie di rum devi vendere?");
                    VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    while (VendiBottiglie > QuantitàBottiglie[7])
                    {
                        Console.Write("\nIl valore inserito non è valido; reinserire il valore\nRisposta: ");
                        VendiBottiglie = Convert.ToInt32(Console.ReadLine());
                    }
                    QuantitàBottiglie[7] = QuantitàBottiglie[7] - VendiBottiglie;
                    Guadagno = VendiBottiglie * PrezzoBottiglie[7];
                    Console.WriteLine("\nHai guadagnato: " + Guadagno + " euro");
                    Budget = Budget + Guadagno;
                    Console.WriteLine("\nAttualmente possiedi: " + Budget + " euro");
                    break;
                case "*": menù(); break;
            }
        }
    }
}

    }
}
