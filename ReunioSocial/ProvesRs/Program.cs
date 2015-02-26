using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesParty;
namespace ProvesRs
{
    class Program
    {
        private const int NUM_FILES_ESCENARI = 20;
        private const int NUM_COLUMNES_ESCENARI = 20;
        
        static void Main(string[] args)
        {
            Escenari esc1 = new Escenari(NUM_FILES_ESCENARI, NUM_COLUMNES_ESCENARI);

            //Home antonio = new Home("antonio", 1);
            //Convidat maria = new Dona("maria", 2);
            //Home josep = new Home("josep", 2);
            ////Cambrer c1 = new Cambrer();
            //Random rF;
            //Random rC;
            ////random de files i columnes
            //// Mostrem la posicio d'una persona de la taula
            ////tp1["antonio"].Fila = 2;
            ////tp1["antonio"].Columna = 12;
            ////Console.WriteLine("Files: " + esc1.Files + ", Columnes: " + esc1.Columnes);
            ////Console.WriteLine(tp1["antonio"].Nom + ": Columna -> "+ tp1["antonio"].Columna + ", Fila -> "+ tp1["antonio"].Fila);
            //// Col·loquem un cambrer
            ////c1.Fila = 4; c1.Columna = 5;
            ////esc1.posar(c1);
            //maria.Fila = 3; maria.Columna = 2;
            //esc1.posar(maria);
            //antonio.Fila = 1; antonio.Columna = 6;
            //esc1.posar(antonio);
            ////Console.WriteLine(c1.Nom);

            ////Direccio direccio = c1.OnVaig(esc1);

            //string[,] escStrings = esc1.ContingutNoms();
            
            //antonio["maria"] = 5;
            //antonio["josep"] = 1;

            //maria["antonio"] = 5;
            //maria["josep"] = 1;


            //Direccio d = antonio.OnVaig(esc1);
            //Direccio d1 = maria.OnVaig(esc1);

            //int i = antonio["maria"];
            //Console.WriteLine(maria.Fila + " " + maria.Columna + "        " + antonio.Fila + " " + antonio.Columna);
            //for (int a = 0; a < 10; a++)
            //{
            //    esc1.Cicle();
            //    Console.WriteLine(maria.Fila + " " + maria.Columna+"        "+antonio.Fila + " " + antonio.Columna);
            //}
        }
    }
}
