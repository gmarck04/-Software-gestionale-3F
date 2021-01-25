using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace Main
{
    class Program
    {
        public static string[] Nome_Dipendenti = new string[0];
        public static string[] elenco_dipendenti = new string[0];
        public static string Elenco = @"C:\Users\gmarc\Desktop\Main\Elenco.txt";
        
        static void Dipendenti()
        {                   
            StreamReader sw = new StreamReader(Elenco);            

            var data = File.ReadLines(Elenco); //memorizzo in data tutti le righe

            Array.Resize(ref elenco_dipendenti, elenco_dipendenti.Length + data.ToArray().Length);
            Array.Resize(ref Nome_Dipendenti, Nome_Dipendenti.Length + data.ToArray().Length);
            
            

            for (int i = 0; i < data.ToArray().Length; i++)
            {
                elenco_dipendenti[i] = data.ToArray()[i];
                string[] subs = elenco_dipendenti[i].Split(',');
                Nome_Dipendenti[i] = $"{subs[0]} {subs[1]}";
            }                     
        }
        static void Benvenuto()
        {
            DateTime thisHour = DateTime.Now;            
            Console.WriteLine("Buon giorno, oggi è il giorno {0}", thisHour.ToString());            
        }

        static void Gestione()
        {
            Console.WriteLine("Premere 1 per la gestione degli ingressi");
            Console.WriteLine("Premere 2 per la gestione delle uscite");
            Console.WriteLine("Premere 3 per la gestione delle presenze dei dipendenti e dei collaboratori");
            Console.WriteLine("Premere 4 per la gestione delle assunzioni");
            Console.WriteLine("Premere 5 per la gestione dei licenziamenti");
            Console.WriteLine("Premere 6 per la gestione delle ferie dei dipendenti");
        }


        static void Main(string[] args)
        {
            Dipendenti();
            Benvenuto();
            Console.WriteLine();
            Gestione();

            int menu = Convert.ToInt32(Console.ReadLine());


            if (menu == 1)
                Menu1();
            else if (menu == 2)
                Menu2();
            else if (menu == 3)
                Menu3();
            else if (menu == 4)
                Menu4();
            else if (menu == 5)
                Menu5();
            else if (menu == 6)
                Menu6();
            else
                Console.WriteLine("Menù non trovato");

            Console.ReadKey();
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
            Console.WriteLine("6");
        }
    }
}
