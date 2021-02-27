/*Alunni: Giovanni Marchetto, Alessio Modonesi, Andrea Marchetto e Marco Malanchin
 
 * Git master: Giovanni Marchetto
 * Project manager: Alessio Modonesi
 
 * Divisione del Codice:
 *                      -Menu principale: Giovanni Marchetto
 *                      -Menu 1: Alessio Modonesi
 *                      -Menu 2: Giovanni Marchetto
 *                      -Menu 3: Alessio Modonesi e Giovanni Marchetto
 *                      -Menu 4: Marco Malanchin e Andrea Marchetto
 *                      -Menu 5: Andrea Marchetto
 *                      -Menu 6: Marco Malanchin
 * 
 * Consegna: Un’azienda deve gestire gli ingressi, uscite, assunzioni, licenziamenti e presenze dei propri dipendenti, 
 *           presenze dei propri collaboratori e gestione dei giorni di ferie del personale dipendente.
 *           Si rende necessario un software gestionale che monitori l’anagrafica dei dipendenti attualmente presenti, 
 *           almeno i contatti telefonici dei licenziati e anche una gestione dei curriculum dei possibili candidati.
*/


using System;
using System.Linq;
using System.IO;

namespace Gestionale
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
           //dichiaro le variabili
           int k = 0; //variabile per il riavvio del programma
           string nome_dipendente = ""; //nome e cognome del dipendente
           string scelta = ""; //menù di scelta

           Console.WriteLine(DateTime.Now); //inserisco la data e l'ora

           while (k == 0)
           {
             //inserimento nome dipendente
             Console.WriteLine("Inserisci il nominativo del dipendente");
             nome_dipendente = Convert.ToString(Console.ReadLine()); //richiede il nominativo del dipendente

             //inserisco l'ora di ingresso nel file di salvataggio esterno        
             if (nome_dipendente != "") //se la stringa NON è vuota inserisco l'orario nel file "salvataggio_ingressi"
             {
                DateTime thisHour = DateTime.Now; //inserisco la funzione DateTime.Now

                Console.WriteLine("Inserisci l'orario di entrata");
                string orario = Console.ReadLine(); //inserisco l'orario di entrata
                                                            //NB: inserire il percorso del file di output del proprio computer

                string ingressi = AppDomain.CurrentDomain.BaseDirectory + filename_menu1;//percorso del file in cui verranno salvati i file                    
                StreamWriter Ingresso = new StreamWriter(ingressi, true); //false = sovrascrivi; true = non sovrascrivere

                //inserimento dati
                Ingresso.WriteLine(thisHour); //inserisco data e ora odierna
                Ingresso.Write(nome_dipendente); //inserisco il nome del dipendente
                Ingresso.Write(" "); //inserisco una ','
                Ingresso.WriteLine(orario); //inserisco l'orario di entrata
                Ingresso.WriteLine("_________________"); //questo serve per separare le varie righe e facilitare la lettura
                Ingresso.Close(); //esco
             }

             else
             Console.WriteLine("ERROR::inserisci un nome valido"); //se la stringa è vuota mostro ERROR e riavvia il programma

             //apro il menù di scelta per riavviare il programma o tornare al main
              Console.WriteLine("Digita: \n-'new' per inserire un altro orario; \n-'esc' per tornare al menù principale");
             
             //apro il menù di scelta
             scelta = Convert.ToString(Console.ReadLine()); //chiedo di inserire la scelta

             if (scelta == "new")
             {
               Console.WriteLine("Premi invio per confermare");
               Console.ReadKey();
               //riavvia il programma
             }

             else if (scelta == "esc")
             {
                Console.WriteLine("Premi invio per confermare");
                Console.ReadKey();
                k++; //break
                //torna al Main() 
             }

             else
             {
               Console.WriteLine("ERROR::tasto non valido");
               Console.WriteLine("Premi invio per riavviare il programma");
               Console.ReadKey();
               //se il tasto inserito non è 1 oppure 2, mostro un segnale ERROR e riavvia il programma
             }
           }
        }
    

        static void Menu2()
        {
            DateTime thisHour = DateTime.Now; //funzione datetime

            Uscita.WriteLine(thisHour); //scrivo nel file esterno il contenuto della variabile thisHuor
            Uscita.WriteLine(" "); 
            Console.WriteLine("Inserisci il nome e cognome del dipendente, ma separati da uno spazio e con le iniziali maiuscole"); //scrivo a schermo
            dipendente = Console.ReadLine();//var dico che vale ciò chge è stato indicato dall'utente

            do
            {
                int contatore = 0; //inizialiazzo la variabile contatore e le do valore 0
                int pos = Array.IndexOf(Nome_Dipendenti, dipendente); 
                string[] results; //creo un array per i risultati
                if (pos > -1) /*inizializzo la variabile "pos" e le viene dato un valore che può essere -1 (se ciò che è contenuto nell'array Nome_Dipendenti[] 
                                ha lo stesso valore delle stringa dipendente), oppure 0 se non ha lo stesso contenuto*/
                {
                    for (int i = 0; i < Nome_Dipendenti.Length; i++) // l'indice 'i' sia minore della lunghezza di Nome_Dipendenti[]
                    {
                        if (!Nome_Dipendenti[i].Equals(dipendente)) //Nome_Dipendenti[i] è uguale alla variabile dipendente?
                        {
                            contatore++; //incremento in contatore
                        }
                    }
                    results = elenco_dipendenti[contatore].Split(",", StringSplitOptions.None); //pongo "results" uguale allo Split della riga dell'array elenco_dipendenti[]
                    Console.WriteLine("Il dipendente è {0}", results[2]); //mostro a video lo stato del dipendente

                    if (results[2] == "presente")
                    {
                        string Risposta; //inizializzo la stringa Risposta
                        int k = 0; //inizialiazzo la variabile k e le do valore 0
                        while (k == 0)
                        {
                            k = 1;

                            Console.WriteLine("Il dipendente deve uscire? si o no");  //scrivo a schermo
                            Risposta = Console.ReadLine(); //inserisco ciò che l'utente ha scritto a schermo nella stinga risposta
                            if (Risposta == "si")
                            {
                                Console.WriteLine("A che ora deve uscire il dipendente?");  //scrivo a schermo
                                string Orario = Console.ReadLine(); //inizializzo la stringa Orario e vi inserisco ciò che l'utente ha scritto a schermo
                                Uscita.Write(dipendente); //scrivo nel file il valore della stringa dipendente
                                Uscita.Write(" ");
                                Uscita.WriteLine(Orario); //scrivo nel file il valore della stringa Orario
                            }
                            else
                            {
                                if (Risposta == "no")
                                {
                                    string risposta1; //inizializzo la stringa risposta1
                                    int g = 0; //inizializzo la variabile g e le do valore 0
                                    while (g == 0)
                                    {
                                        g = 1;
                                        Console.WriteLine("Vuoi essere riportato al menu principale? si o no");  //scrivo a schermo
                                        risposta1 = Console.ReadLine(); //inserisco ciò che l'utente ha scritto a schermo nella stinga risposta1
                                        if (risposta1 == "si")
                                        {
                                            do
                                            {
                                                Console.Clear(); //pulisco la console

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

                                                Uscita.Close(); //chiusura del file
                                            } while (menu != "1" || menu != "2" || menu != "3" || menu != "4" || menu != "5" || menu != "6"); //controllo del contenuto menu
                                        }
                                        if (risposta1 == "no")
                                        {

                                        }
                                        else
                                        {
                                            Console.WriteLine("La scelta non e' valida");  //scrivo a schermo
                                            g = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("La scelta non e' valida");  //scrivo a schermo
                                    k = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        string risposta2; //inizializzo la stringa risposta2
                        int g = 0; //inizializzo la variabile g e le do valore 0
                        while (g == 0)
                        {
                            g = 1;
                            Console.WriteLine("Vuoi essere portato al menu 3? si o no");  //scrivo a schermo
                            risposta2 = Console.ReadLine(); //inserisco ciò che l'utente ha scritto a schermo nella stinga risposta2
                            if (risposta2 == "si")
                            {
                                Menu3(); //funzione Menu3
                            }
                            if (risposta2 == "no")
                            {

                            }
                            else
                            {
                                Console.WriteLine("La scelta non e' valida");  //scrivo a schermo
                                g = 0;
                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Il dipendente non è registrato"); //scrivo a schermo
                }
                Console.Write("Se vuoi terminare l'inserimento dei dati scrivi '*', oppure se vuoi continuare inserisci un'altro dipendente: "); /*chiedo all'utente la frase "Se vuoi terminare l'inserimento dei dati scrivi '*',
                                                                                                                                                 oppure se vuoi continuare inserisci il numero successivo: "*/
                dipendente = Console.ReadLine(); //inserisco ciò che l'utente ha scritto a schermo nella stinga dipendente
            } while (dipendente != "*"); //controllo del contenuto della stringa dipendente attraverso un ciclo while
            Uscita.WriteLine("_______________________________________________"); //scrivo nel file
            Uscita.Close(); //chiudo il file
            Console.WriteLine("Premi un tasto per uscire...");  //scrivo a schermo
        }
        static void Menu3()
        {
            string assenze = AppDomain.CurrentDomain.BaseDirectory + filename_menu3; //apro il file esterno "salvataggio_stati"
            StreamWriter Stato = new StreamWriter(assenze, true); //false = sovrascrivi; true = non sovrascrivere

            //dichiaro le variabili
            int k = 0; //variabile per riavviare il programma
            string scelta = ""; //menù di scelta 

            Console.WriteLine(DateTime.Now); //inserisco la data e l'ora

            while (k == 0)//while di "riavvio" del programma
            {
               Console.WriteLine("Inserisci il nome e cognome del dipendente, ma separati da uno spazio e con le iniziali maiuscole");
               dipendente = Console.ReadLine();//var dico che vale ciò che è stato indicato dall'utente

               int contatore = 0;//inizializzo il contatore a 0
               string[] results;//creo un array per i risultati
               int pos = Array.IndexOf(Nome_Dipendenti, dipendente);
               /*inizializzo la variabile "pos" e le viene dato un valore che può essere -1 (se ciò che è contenuto nell'array Nome_Dipendenti[] ha lo stesso valore delle stringa dipendente), oppure 0 se non ha lo stesso contenuto*/

               if (pos > -1)
               {
                  for (int i = 0; i < Nome_Dipendenti.Length; i++)// l'indice 'i' sia minore della lunghezza di Nome_Dipendenti[]
                  {
                      if (!Nome_Dipendenti[i].Equals(dipendente))
                      {
                        contatore++;//incremento in contatore
                      }
                  }

                  results = elenco_dipendenti[contatore].Split(",", StringSplitOptions.None);
                  /*pongo "results" uguale allo Split della riga dell'array elenco_dipendenti[]*/
                  Console.WriteLine("Il dipendente è {0}", results[2]);//mostro a video lo stato del dipendente


                  //inserisco lo stato nel file di salvataggio esterno        
                  if (dipendente != "") //se la stringa NON è vuota inserisco l'orario nel file "salvataggio_stato"
                  {
                      DateTime thisHour = DateTime.Now; //inserisco la funzione DateTime.Now

                      Console.WriteLine("Inserisci lo stato del dipendente");
                      string stato = Console.ReadLine(); //inserisco lo stato

                      //inserimento dati
                      Stato.WriteLine(thisHour); //inserisco data e ora odierna
                      Stato.Write(dipendente); //inserisco il nome del dipendente
                      Stato.Write(" "); //inserisco uno spazio
                      Stato.WriteLine(stato); //inserisco lo stato
                      Stato.WriteLine("_________________"); //questo serve per separare le varie righe e facilitare la lettura
                      Stato.Close(); //esco
                  }

                  else
                  Console.WriteLine("ERROR::inserisci un nome valido"); //se la stringa è vuota mostro ERROR e riavvia il programma

                  //apro il menù di scelta per riavviare il programma o tornare al main
                  Console.WriteLine("Digita: \n-'new' per inserire un altro orario; \n-'esc' per tornare al menù principale"); //apro il menù di scelta
                  scelta = Convert.ToString(Console.ReadLine()); //chiedo di inserire la scelta
                  if (scelta == "new")
                  {
                     Console.WriteLine("Premi invio per confermare");
                     Console.ReadKey();
                     //riavvia il programma
                  }

                  else if (scelta == "esc")
                  {
                     Console.WriteLine("Premi invio per confermare");
                     Console.ReadKey();
                     k++; //break
                     //torna al Main() 
                  }

                  else
                  {
                     Console.WriteLine("ERROR::tasto non valido");
                     Console.WriteLine("Premi invio per riavviare il programma");
                     Console.ReadKey();
                     //se il tasto inserito non è 1 oppure 2, mostro un segnale ERROR e riavvia il programma
                  }
               }
            }
        }

        static void Menu4()
        {
            string[,] dati;
            StreamReader file;
            string[] tmp;                                                   //array temporaneo con cui suddivido i dati del file nelle varie colonne
            int righe;                                                      //conta quante righe ci sono nel file
            void Lettura()
            {
                righe = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + filename_menu4).Count();    //Conta quante righe ci sono nel file esterno
                dati = new string[righe, 3];                                                                //Crea una matrice in base a quante righe ci sono
                using (file = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + filename_menu4))    //apre il file esterno
                {
                    for (int i = 0; i < righe; i++)                                                         //Questo ciclo for inserisci i dati del file separati dalla virgola                                                                             // carattere ',' in una matricie
                    {
                        tmp = file.ReadLine().Split(',');
                        dati[i, 0] = tmp[0];
                        dati[i, 1] = tmp[1];
                        dati[i, 2] = tmp[2];
                    }
                }
            }

            bool Ricerca(string dipendente)
            {
                for (int i = 0; i < righe; i++)                                                 //Ricerca il Nome dell dipendente inserito
                {
                    if (dati[i, 0] == dipendente)
                    {
                        stato = dati[i, 1];
                        k = i;                                                                  //segna in quele riga della matrice è situato il dipendente
                        return true;
                    }
                }
                for (int i = 0; i < righe; i++)
                {
                    if (dati[i, 0] == dipendente)
                    {
                        curriculum = dati[i, 2];
                        k = i;
                        return true;
                    }
                }
                Console.WriteLine("Errore, nome non trovato, reinseriscilo correttamente.");
                return false;
            }

            void Scrittura()
            {
                string testo = "";
                for (int i = 0; i < righe; i++)
                {
                    testo = testo + dati[i, 0] + "," + dati[i, 1] + "," + dati[i, 2] + "\n";                   //sovrascrive il file esterno utilizzando la matrice modificata
                }

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + filename_menu4, testo);
            }

            int z = 0;
            while (z == 0)
            {
                Lettura();
                do
                {
                    Console.WriteLine("Inserisci nome e cognome del candidato.");
                    string nome = Console.ReadLine();
                    Console.Clear();
                    if (Ricerca(nome) == true)
                    {
                        break;

                    }
                } while (true);


                z = 1;
                int x = 0;
                while (x == 0)
                {
                    x = 1;
                    Console.WriteLine("Digita 'assumere' se vuoi assumere il candidato, digita 'rifiutare' se vuoi rifiutarlo.");
                    string decisione;
                    decisione = Convert.ToString(Console.ReadLine());
                    if (decisione == "assumere")                                                                                                  //l'utente decide di assumere il candidato
                    {
                        Console.WriteLine("Il candidato verrà assunto nell'azienda.");
                        dati[k, 1] = "Assunto";										//viene scritto nel file esterno
                        Scrittura();
                        int g = 0;
                        while (g == 0)											//ciclo per controllare altri candidati
                        {
                            g = 1;
                            Console.WriteLine("Vuoi controllare un altro candidato? \nDigita 'si' o 'no'.");
                            conferma = Console.ReadLine();
                            if (conferma == "si")
                            {
                                z = 0;

                            }
                            else if (conferma == "no")
                            {
                                Console.WriteLine("Il programma è terminato.");
                                z = 1;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Riscrivi la tua risposta.");
                                z = 0;
                                g = 0;
                            }
                        }

                    }
                    else if (decisione == "rifiutare")                                                                                          //l'utente decide di rifiutare il candidato
                    {
                        int y = 0;
                        while (y == 0)                                                                            //secondo while che ripete la procedura se l'utente sbaglia a scrivere
                        {
                            y = 1;
                            Console.WriteLine("Il candidato verrà rifiutato.");					//decido di rifiutare il candidato
                            dati[k, 1] = "Rifiutato";
                            Console.WriteLine("Digita 'conservare' se vuoi conservare il curriculum del candidato, digita 'eliminare' se lo vuoi eliminare.");
                            string decisione2;
                            decisione2 = Convert.ToString(Console.ReadLine());
                            if (decisione2 == "conservare")
                            {
                                Console.WriteLine("Il curriculum del candidato verrà conservato. Verrà salvato nella prossima versione.");       //decido di conservare il curriculum
                                dati[k, 2] = "Curriculum conservato";
                                Scrittura();
                                int g = 0;
                                while (g == 0)											//ciclo per controllare altri candidati
                                {
                                    g = 1;
                                    Console.WriteLine("Vuoi controllare un altro candidato? \nDigita 'si' o 'no'.");
                                    conferma = Console.ReadLine();
                                    if (conferma == "si")
                                    {
                                        z = 0;

                                    }
                                    else if (conferma == "no")
                                    {
                                        Console.WriteLine("Il programma è terminato.");
                                        z = 1;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Riscrivi la tua risposta.");
                                        z = 0;
                                        g = 0;
                                    }
                                }

                            }
                            else if (decisione2 == "eliminare")
                            {
                                Console.WriteLine("Il curriculum del candidato verrà eliminato. Verrà salvato nella prossima versione.");        //decido di conservare il curriculum
                                dati[k, 2] = "Curriculum eliminato";
                                Scrittura();

                                int g = 0;
                                while (g == 0)											//ciclo per controllare altri candidati
                                {
                                    g = 1;
                                    Console.WriteLine("Vuoi controllare un altro candidato? \nDigita 'si' o 'no'.");
                                    conferma = Console.ReadLine();
                                    if (conferma == "si")
                                    {
                                        z = 0;

                                    }
                                    else if (conferma == "no")
                                    {
                                        Console.WriteLine("Il programma è terminato.");
                                        z = 1;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Riscrivi la tua risposta.");
                                        z = 0;
                                        g = 0;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Riscrivi la tua decisione.");
                                y = 0;                                                   //mi fa ripetere il ciclo
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Riscrivi la tua decisione.");
                        x = 0;                                                   //mi fa ripetere il ciclo
                    }
                }
            }
        }
    

        static void Menu5()
        {
            string[,] dati;
            StreamReader file;
            string[] tmp;                                                   //array temporaneo con cui suddivido i dati del file nelle varie colonne
            int righe;                                                      //conta quante righe ci sono nel file
            void Lettura()
            {
                righe = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + filename_menu5).Count();    //Conta quante righe ci sono nel file esterno
                dati = new string[righe, 3];                                                                //Crea una matrice in base a quante righe ci sono
                using (file = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + filename_menu5))    //apre il file esterno
                {
                    for (int i = 0; i < righe; i++)                                                         //Questo ciclo for inserisci i dati del file separati dalla virgola                                                                             // carattere ',' in una matricie
                    {
                        tmp = file.ReadLine().Split(',');
                        dati[i, 0] = tmp[0];
                        dati[i, 1] = tmp[1];
                        dati[i, 2] = tmp[2];
                    }
                }
            }

            bool Ricerca(string dipendente)
            {
                for (int i = 0; i < righe; i++)                                                 //Ricerca il Nome dell dipendente inserito
                {
                    if (dati[i, 0] == dipendente)
                    {
                        stato = dati[i, 1];
                        k = i;                                                                  //segna in quele riga della matrice è situato il dipendente
                        return true;
                    }
                }
                for (int i = 0; i < righe; i++)
                {
                    if (dati[i, 0] == dipendente)
                    {
                        contatto = dati[i, 2];
                        k = i;
                        return true;
                    }
                }
                Console.WriteLine("Errore, nome non trovato, reinseriscilo correttamente.");
                return false;
            }

            void Scrittura()
            {
                string testo = "";
                for (int i = 0; i < righe; i++)
                {
                    testo = testo + dati[i, 0] + "," + dati[i, 1] + "," + dati[i, 2] + "\n";                   //sovrascrive il file esterno utilizzando la matrice modificata
                }
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + filename_menu5, testo);
            }



            int z = 0;
            while (z == 0)
            {

                Lettura();
                do
                {
                    Console.WriteLine("Inserisci nome e cognome del dipendente per decidere il suo futuro nell'azienda.");
                    string nome = Console.ReadLine();
                    Console.Clear();
                    if (Ricerca(nome) == true)
                    {
                        break;

                    }
                } while (true);

                z = 1;
                Console.WriteLine("Il dipendente in questione si trova in questo stato:");
                Console.WriteLine(dati[k, 1]);
                string stringa = dati[k, 1];
                if (stringa == "Dipendente")                                                 //il dipendente lavora ancora nell'azienda
                {
                    int y = 0;
                    while (y == 0)                                                           //while che mi fa ripetere se l'utente sbaglia a scrivere
                    {
                        y = 1;
                        Console.WriteLine("Digita 'conservare' se vuoi conservare il dipendente, digita 'licenziare' se lo vuoi licenziare.");
                        string dec;
                        dec = Convert.ToString(Console.ReadLine());
                        if (dec == "conservare")						//decido di conservare il dipendente
                        {
                            Console.WriteLine("Il dipendente verrà conservato nell'azienda.");
                            int g = 0;
                            while (g == 0)									//ciclo per controllare altri candidati
                            {
                                g = 1;
                                Console.WriteLine("Vuoi controllare un altro candidato? \nDigita 'si' o 'no'.");
                                conferma = Console.ReadLine();
                                if (conferma == "si")
                                {
                                    z = 0;

                                }
                                else if (conferma == "no")
                                {
                                    Console.WriteLine("Il programma è terminato.");
                                    z = 1;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Riscrivi la tua risposta.");
                                    z = 0;
                                    g = 0;
                                }
                            }
                        }
                        else if (dec == "licenziare")							//decido di licenziare il dipendente
                        {
                            Console.WriteLine("Il dipendente verrà licenziato dall'azienda.");
                            dati[k, 1] = "Licenziato";							//verrà scritto nel file esterno
                            Console.WriteLine("Inserisci il suo numero telefonico.");
                            string numeroTelefonico = Console.ReadLine();
                            dati[k, 2] = numeroTelefonico;
                            Scrittura();
                            int g = 0;
                            while (g == 0)									//ciclo per controllare altri candidati
                            {
                                g = 1;
                                Console.WriteLine("Vuoi controllare un altro candidato? \nDigita 'si' o 'no'.");
                                conferma = Console.ReadLine();
                                if (conferma == "si")
                                {
                                    z = 0;

                                }
                                else if (conferma == "no")
                                {
                                    Console.WriteLine("Il programma è terminato.");
                                    z = 1;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Riscrivi la tua risposta.");
                                    z = 0;
                                    g = 0;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Riscrivi la tua decisione.");
                            y = 0;                                                               //contatore che mi fa ripetere la decisione
                        }
                    }
                }
                else if (stringa == "Licenziato")
                {
                    Console.WriteLine("Questo è il suo contatto telefonico:");
                    Console.WriteLine(dati[k, 2]);							//stampa il contatto telefonico dal file esterno
                    int g = 0;
                    while (g == 0)									//ciclo per con trollare altri candidati
                    {
                        g = 1;
                        Console.WriteLine("Vuoi controllare un altro candidato? \nDigita 'si' o 'no'.");
                        conferma = Console.ReadLine();
                        if (conferma == "si")
                        {
                            z = 0;

                        }
                        else if (conferma == "no")
                        {
                            Console.WriteLine("Il programma è terminato.");
                            z = 1;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Riscrivi la tua risposta.");
                            z = 0;
                            g = 0;
                        }
                    }
                }
            }
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
            while (y == 0)                                                                                              //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
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
                    while (l == 0)
                    {
                        Console.WriteLine("digitare 'si' se si vuole inserire altre ore di ferie, premere 'no' se non si vuole.");     // se il dipendente vuole altre ferie
                        l = 1;
                        risposta = Convert.ToString(Console.ReadLine());                                                        // si digita si
                        if (risposta == "si")
                        {
                            Console.Clear();
                            x = 0;
                            while (x == 0)
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
                                    while (z == 0)                      //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                                    {
                                        z = 1;
                                        Console.WriteLine("Vuoi passare ad un altro Dipendente? \nDigitare 'si' se si vuole passare ad un altro dipendente, premere 'no' se non si vuole.");
                                        decisione = Convert.ToString(Console.ReadLine());
                                        if (decisione == "si")
                                        {                                                                                                              //funzione che mi consente l'nserimento di altri dipendenti
                                            y = 0;                                                                                                    // Grazie alla variabile decisione.                              
                                        }
                                        else if (decisione == "no")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Il programma si terminerà");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Risposta inserita non accettata \nRiscrivila correttamente");
                                            z = 0;
                                        }
                                    }
                                }
                            }
                        }
                        else if (risposta == "no")
                        {
                            Console.Clear();                                                                        // Se non si vuole aggiungere ore di ferie al dipendente il programma chiede il nome di un'altro dipendente
                            Console.WriteLine("Le ore di ferie non verranno aggiornate");
                            z = 0;
                            while (z == 0)                                                               //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                            {
                                z = 1;
                                Console.WriteLine("Vuoi passare ad un altro Dipendente? \nDigitare 'si' se si vuole passare ad un altro dipendente, premere 'no' se non si vuole.");
                                decisione = Convert.ToString(Console.ReadLine());
                                if (decisione == "si")                                                                                   //funzione che mi consente l'nserimento di altri dipendenti
                                {                                                                                                        // Grazie alla variabile decisione.     
                                    y = 0;
                                }
                                else if (decisione == "no")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Il programma si terminerà");                     //Funzione che fa terminare il programma
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
                            Console.WriteLine("Risposta inserita non accettata \nRiscrivila correttamente");
                            l = 0;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("il dipendente ha esaurito le ore di ferie");
                    z = 0;
                    while (z == 0)                                           //Ciclo che mi permette di reinserire la risposta se inserita sbagliata
                    {
                        z = 1;
                        Console.WriteLine("Vuoi passare ad un altro Dipendente? \nDigitare 'si' se si vuole passare ad un altro dipendente, premere 'no' se non si vuole.");
                        decisione = Convert.ToString(Console.ReadLine());
                        if (decisione == "si")
                        {
                            y = 0;                                                                           //funzione che mi consente l'nserimento di altri dipendenti
                        }                                                                                     // Grazie alla variabile decisione.      
                        else if (decisione == "no")
                        {
                            Console.Clear();
                            Console.WriteLine("Il programma si terminerà");                                             //Funzione che fa terminare il programma
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Risposta inserita non accettata \nRiscrivila correttamente");
                            z = 0;
                        }
                    }
                }
                Console.ReadKey();
            }
          
        }
    }
}









