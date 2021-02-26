/*Alunni: Giovanni Marchetto, Alessio Modonesi, Andrea Marchetto e Marco Malanchin
 
 * Git master: Giovanni Marchetto
 * Project manager: Giovanni Marchetto
 
 * Divisione del Codice:
 *                      -Menu principale: Giovanni Marchetto
 *                      -Menu 1:Alessio Modonesi
 *                      -Menu 2:Giovanni Marchetto
 *                      -Menu 3:Alessio Modonesi e Giovanni Marchetto
 *                      -Menu 4:Marco Malanchin e Andrea Marchetto
 *                      -Menu 5:Andrea Marchetto
 *                      -Menu 6:Marco Malanchin
 * 
 * Consegna: Un’azienda deve gestire gli ingressi, uscite, assunzioni, licenziamenti e presenze dei propri dipendenti, 
 *           presenze dei propri collaboratori e gestione dei giorni di ferie del personale dipendente.
 *           Si rende necessario un software gestionale che monitori l’anagrafica dei dipendenti attualmente presenti, 
 *           almeno i contatti telefonici dei licenziati e anche una gestione dei curriculum dei possibili candidati.
*/


using System;
using System.Linq;
using System.IO;

namespace Gestionele
{
    class Program
    {
        public static string[] Nome_Dipendenti = new string[0]; //array Nome_Dipendenti
        public static string[] elenco_dipendenti = new string[0]; //array elenco_dipendenti
        public static string Elenco = @"Elenco.txt"; //inizializzo la stringa elenco e le do valore del percorso al file elenco.txt         
        public static string dipendente; //inizializzo la stringa dipendente
        public static string menu = "1"; //inizializzo la stringa menu e le do valore 1
        public static DateTime thisHour = DateTime.Now; //funzione DateTime
        public static string stato = ""; //stringa con cui stabilisco lo stato del dipendente
        public static string curriculum = ""; //stringa con cui stabilisco il contatto telefonico del dipendente
        public static int k = 0;  //variabile con cui mi segno la posizione del dipendente nella matrice
        public static string conferma; //inizializzo la stringa conferma
        public static string contatto = ""; //inizializzo la stringa contatto
        public static string decisione; //inizializzo la stringa decisione
        public static string risposta; //inizializzo la stringa risposta
        public static int tempo = 0; // Variabile con cui mi segno le ore di ferie del dipendente
        public static int l = 0; //inizializzo la variabile l e lo do valore 0
        public static int x = 0; //inizializzo la variabile x e lo do valore 0
        public static int y = 0; //inizializzo la variabile y e lo do valore 0
        public static int z = 0; //inizializzo la variabile z e lo do valore 0
        public static string filename_menu1 = @"salvataggio_ingressi.txt"; //inizializzo la variabile filename_menu1 e le do valore del percorso al file salvataggio_ingressi.txt
        public static string filename_menu2 = @"Uscita.txt"; //inizializzo la variabile filename_menu1 e le do valore del percorso al file Uscita.txt
        public static string filename_menu3 = @"Salvataggio_stati.txt"; //inizializzo la variabile filename_menu1 e le do valore del percorso al file Salvataggio_stati.txt
        public static string filename_menu4 = @"File_Candidati.txt"; //inizializzo la variabile filename_menu1 e le do valore del percorso al file File_Candidati.txt
        public static string filename_menu5 = @"File_dipendenti.txt"; //inizializzo la variabile filename_menu1 e le do valore del percorso al file File_dipendenti.txt
        public static string filename_menu6 = @"File_dipendenti_menu6.txt"; //inizializzo la variabile filename_menu1 e le do valore del percorso al file File_dipendenti_menu6.txt
        public static StreamWriter Uscita = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + filename_menu2, true); ////apertura del file situato nella variabile fileneme_menù2 e le do il nome Uscita

        static void Dipendenti()
        {
            StreamReader sw = new StreamReader(Elenco); //apertura del file situato nella elenco e do il nome sw

            var data = File.ReadLines(Elenco); //memorizzo in data tutti le righe

            Array.Resize(ref elenco_dipendenti, elenco_dipendenti.Length + data.ToArray().Length); //eseguo un resize dell'array elenco_dipendenti
            Array.Resize(ref Nome_Dipendenti, Nome_Dipendenti.Length + data.ToArray().Length); //eseguo un resize dell'array Nome_Dipendenti


            for (int i = 0; i < data.ToArray().Length; i++) //ciclo che divide e inserisce il nome e cognome dei dipendenti dal file esterno all'array Nome_Dipendente
            {
                elenco_dipendenti[i] = data.ToArray()[i]; //elenco_dipendenti è uguale alla righa di data
                string[] subs = elenco_dipendenti[i].Split(','); //utilizzo del comando line.split
                Nome_Dipendenti[i] = $"{subs[0]} {subs[1]}"; //nome_dipendenti è uguale alle posizione 0 e 1 di elenco_dipendenti
            }
        }
        static void Benvenuto()
        {
            DateTime thisHour = DateTime.Now; //funzione datetime
            Console.WriteLine("Buon giorno, oggi è il giorno {0}", thisHour.ToString()); //Digita a schermo la frase Buon giorno, oggi è il giorno e poi digita l'orario e la data
        }

        static void Gestione()
        {
            Console.WriteLine("Premere 1 per la gestione degli ingressi"); //Digita a schermo la frase Premere 1 per la gestione degli ingressi
            Console.WriteLine("Premere 2 per la gestione delle uscite"); //Digita a schermo la frase Premere 2 per la gestione delle uscite
            Console.WriteLine("Premere 3 per la gestione delle presenze dei dipendenti e dei collaboratori"); //Digita a schermo la frase Premere 3 per la gestione delle presenze dei dipendenti e dei collaboratori
            Console.WriteLine("Premere 4 per la gestione delle assunzioni"); //Digita a schermo la frase Premere 4 per la gestione delle assunzioni
            Console.WriteLine("Premere 5 per la gestione dei licenziamenti"); //Digita a schermo la frase Premere 5 per la gestione dei licenziamenti
            Console.WriteLine("Premere 6 per la gestione delle ferie dei dipendenti"); //Digita a schermo la frase Premere 6 per la gestione delle ferie dei dipendenti
        }


        static void Main(string[] args)
        {
            Dipendenti(); //richiamo la funzione dipendenti


            while (menu != "1" || menu != "2" || menu != "3" || menu != "4" || menu != "5" || menu != "6") //controllo del contenuto menu 
            {                
                Benvenuto(); //richiamo la funzione Benvenuto
                Console.WriteLine();
                Gestione(); //richiamo la funzione Gestione
                menu = Console.ReadLine(); //inserisco ciò che è stato digitato dall'utente in menu

                if (menu == "1") //se il valore di menu è uguale a 1 allora fai questo
                    Menu1(); //richiamo la funzione Menu1
                else if (menu == "2") //se il valore di menu è uguale a 2 allora fai questo
                    Menu2(); //richiamo la funzione Menu2
                else if (menu == "3") //se il valore di menu è uguale a 3 allora fai questo
                    Menu3(); //richiamo la funzione Menu3
                else if (menu == "4") //se il valore di menu è uguale a 4 allora fai questo
                    Menu4(); //richiamo la funzione Menu4
                else if (menu == "5") //se il valore di menu è uguale a 5 allora fai questo
                    Menu5(); //richiamo la funzione Menu5
                else if (menu == "6") //se il valore di menu è uguale a 6 allora fai questo
                    Menu6(); //richiamo la funzione Menu6
                else
                    Console.WriteLine("Menù non trovato"); //scrivo a schermo la frase Menù non trovato
            }

            Console.ReadKey(); //blocco del programma
        }

        static void Menu1()
        {
            Console.WriteLine("1");
        }

        static void Menu2()
        {
            Console.WriteLine("2");
        }
        static void Menu3()
        {
            Console.WriteLine("3");
        }

        static void Menu4()
        {
            Console.WriteLine("4");
        }

        static void Menu5()
        {
            Console.WriteLine("5");
        }

        static void Menu6()
        {
            
            
                string[,] dati;

                StreamReader file;

                string[] tmp;                                                   //array temporaneo con cui suddivido i dati del file nelle varie colonne
                int righe;                                                      // conta quante righe ci sono nel file
                void Lettura()
                {
                    righe = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + filename_menu6).Count();    //Conta quante righe ci sono nel file esterno
                    dati = new string[righe, 2];                                                        // Crea una matrice in base a quante righe ci sono
                    using (file = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + filename_menu6))    //apre il file esterno
                    {
                        for (int i = 0; i < righe; i++)                                                 //Questo ciclo for inserisci i dati del file separati dal
                                                                                                        // carattere ',' in una matricie
                        {
                            tmp = file.ReadLine().Split(',');
                            dati[i, 0] = tmp[0];
                            dati[i, 1] = tmp[1];
                        }

                    }
                }
                bool Ricerca(string dipendente)
                {
                    for (int i = 0; i < righe; i++)                                                 //Ricerca il Nome dell dipendente inserito
                    {
                        if (dati[i, 0] == dipendente)
                        {
                            tempo = Convert.ToInt32(dati[i, 1]);
                            k = i;                                                                  // segna in quele riga della matrice è situato il dipendente
                            return true;
                        }
                    }
                    Console.WriteLine("errore nome non trovato reinserirlo correttamente");
                    return false;
                }

                void Scrittura()
                {
                    string testo = "";
                    for (int i = 0; i < righe; i++)
                    {
                        testo = testo + dati[i, 0] + "," + dati[i, 1] + "\n";                                        //sovrascrive il file esterno utilizzando la matrice
                    }                                                                                                  // modificata
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + filename_menu6, testo);
                }

                y = 0;
                while (y == 0)                                           //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                {
                    y = 1;
                    Lettura();
                    do
                    {
                        Console.WriteLine("Metti nome e cognome del dipendente al quale attribuire le ferie");
                        string nome = Console.ReadLine();
                        Console.Clear();
                        if (Ricerca(nome) == true)
                        {
                            break;

                        }
                    } while (true);

                    if (tempo < 400)                                                // se le ore riportate sono inferiori al massimo consentito in azienda
                    {                                                                  // allora si possono aggiungere altre ore      
                        Console.Clear();
                        Console.WriteLine("il dipendente vuole avere altre ore di ferie?");
                        l = 0;
                        while (l == 0)                                                           //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                        {
                            Console.WriteLine("digitare 'si' se si vuole inserire altre ore di ferie, premere 'no' se non si vuole.");     // se il dipendente vuole altre ferie
                            l = 1;
                            risposta = Convert.ToString(Console.ReadLine());                                                        // si digita si
                            if (risposta == "si")
                            {
                                Console.Clear();
                                x = 0;
                                while (x == 0)                                               //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                                {
                                    x = 1;                                              //Questo ciclo while servirà per rimettere le ore in caso di errore
                                    Console.WriteLine("Inserisci le ore che il dipendente vuole avere");
                                    int ore = Convert.ToInt32(Console.ReadLine());
                                    tempo = tempo + ore;
                                    if (tempo > 400)              // se le ore nuove, sommate alle ore precedenti, superano le ore totali si mostrerà un messaggio di errore
                                    {
                                        Console.Clear();
                                        Console.WriteLine("le ore inserite superano le ore totali stabilite. Prendere un numero di ore minori");
                                        tempo = tempo - ore;
                                        x = 0;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Le ore di ferie sono state aggiornate");
                                        dati[k, 1] = Convert.ToString(tempo);           // sovrascrive file esterno
                                        Scrittura();
                                        z = 0;
                                        while (z == 0)                                                          //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                                        {
                                            z = 1;
                                            Console.WriteLine("Vuoi passare ad un altro Dipendente? \nDigitare 'si' se si vuole passare ad un altro dipendente, premere 'no' se non si vuole.");
                                            decisione = Convert.ToString(Console.ReadLine());
                                            if (decisione == "si")
                                            {
                                                y = 0;                                                            //funzione che mi consente l'inserimento di altri dipendenti           
                                            }                                                                   // Grazie alla variabile decisione. 
                                            else if (decisione == "no")
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Il programma si terminerà");
                                            }                                                                                        //Funzione che fa terminare il programma
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Risposta inserita non accettata \nRiscrivila correttamente");         //se la risposta inserita è sbagliata fa ricominciare il ciclo  
                                                z = 0;                                                                                  //richiedendo la domanda
                                            }
                                        }
                                    }
                                }
                            }
                            else if (risposta == "no")
                            {
                                Console.Clear();
                                Console.WriteLine("Le ore di ferie non verranno aggiornate");
                                z = 0;
                                while (z == 0)                                                   //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                                {
                                    z = 1;
                                    Console.WriteLine("Vuoi passare ad un altro Dipendente? \nDigitare 'si' se si vuole passare ad un altro dipendente, premere 'no' se non si vuole.");
                                    decisione = Convert.ToString(Console.ReadLine());
                                    if (decisione == "si")
                                    {
                                        y = 0;                                                                       //funzione che mi consente l'inserimento di altri dipendenti
                                    }                                                                                 // Grazie alla variabile decisione.               
                                    else if (decisione == "no")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Il programma si terminerà");                             //Funzione che fa terminare il programma
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Risposta inserita non accettata \nRiscrivila correttamente");
                                        z = 0;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Risposta inserita non accettata \nRiscrivila correttamente");        //se la risposta inserita è sbagliata fa ricominciare il ciclo
                                l = 0;                                                                                 //richiedendo la domanda
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("il dipendente ha esaurito le ore di ferie");
                        z = 0;
                        while (z == 0)                                                           //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                        {
                            z = 1;
                            Console.WriteLine("Vuoi passare ad un altro Dipendente? \nDigitare 'si' se si vuole passare ad un altro dipendente, premere 'no' se non si vuole.");
                            decisione = Convert.ToString(Console.ReadLine());
                            if (decisione == "si")
                            {                                                                                   //funzione che mi consente l'inserimento di altri dipendenti 
                                y = 0;                                                                       // Grazie alla variabile decisione.
                            }
                            else if (decisione == "no")
                            {
                                Console.Clear();
                                Console.WriteLine("Il programma si terminerà");                                 //Funzione che fa terminare il programma
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Risposta inserita non accettata \nRiscrivila correttamente");        //se la risposta inserita è sbagliata fa ricominciare il ciclo
                                z = 0;                                                                                    //richiedendo la domanda  
                            }
                        }
                    }
                }
            
        }
    }
}

