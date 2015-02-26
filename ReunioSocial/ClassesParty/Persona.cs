using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ClassesParty
{
    public abstract class Persona : Posicio
    {
        string nom;
        string nomImg;
        static Random r = new Random();

        /// <summary>
        /// Crea una persona
        /// </summary>
        /// <param name="nom">Strng que identifica la persona</param>
        /// <param name="fil">Fila on està localitzada</param>
        /// <param name="col">Columna on està localitzada</param>
        public Persona(string nom, int fil, int col, string nomImg) : base(fil, col)
        {
            this.nom = nom;
            this.nomImg = nomImg;
        }
        /// <summary>
        /// Crea una persona
        /// </summary>
        /// <param name="nom">nom de la persona</param>
        public Persona(string nom, string nomImg)
        {
            this.nom = nom;
            this.nomImg = nomImg;
        }
        /// <summary>
        /// Crea una persona
        /// </summary>
        public Persona() : base(){}
        /// <summary>
        /// Obté el nom de la persona
        /// </summary>
        public string Nom
        {
            get { return nom;}
            set { this.nom = value; }
        }
        /// <summary>
        /// Retorna que la posició ocupada per aquesta persona no està buida
        /// </summary>
        public override bool Buida
        {
            get { return false;}
        }

        //Retorna o asigna un bitmat "imatge" a la persona;
        public string NomImg
        {
            get { return nomImg; }
            set { nomImg = value; }
        }
        /// <summary>
        /// Atraccio de persona sobre una determinada posicio
        /// </summary>
        /// <param name="fil">Fila de la posició</param>
        /// <param name="col">Columan de la posició</param>
        /// <param name="esc">Escenari on estan situats</param>
        /// <returns>Atracció quantificada</returns>
        private double Atraccio(int fil, int col, Escenari esc)
        {
            double atraccio = 0;

            Posicio posicio = new Posicio(fil,col); // Creem la posició a on és possible que vagi la persona

            foreach(Persona p in esc.Tp)
            {
                if(p.Nom != this.Nom) // Controlem que no calculi a la persona que estem tractant
                {
                     atraccio += Interes(p) / Posicio.Distancia(posicio,p);
                }
            }

            return atraccio;
        }
        /// <summary>
        /// Decideix quin serà el següent moviment que farà la persona
        /// </summary>
        /// <param name="esc">Escenari on esta situada la persona</param>
        /// <returns>Una de les 5 possibles direccions (Quiet, Amunt, Avall, Dreta, Esquerra</returns>
        public Direccio OnVaig(Escenari esc)
        {
            
            List<double> atraccions = new List<double>();
            List<Direccio> d = new List<Direccio>();

            // inicialitzar direcció = quiet
            //Direccio direccio = Direccio.Quiet;

            double amunt = 0;
            double dreta = 0;
            double esquerra = 0;
            double avall = 0;
            double quiet = 0;
            double resultat;
            
            // Calculem totes les atraccions
            if (esc.DestiValid(this.Fila - 1, this.Columna))
            {
                amunt = Atraccio(this.Fila - 1, this.Columna, esc);
                atraccions.Add(amunt);
            }
            if (esc.DestiValid(this.Fila, this.Columna + 1))
            {
                dreta = Atraccio(this.Fila, this.Columna + 1, esc);
                atraccions.Add(dreta);
            }
            if (esc.DestiValid(this.Fila + 1, this.Columna))
            {
                avall = Atraccio(this.Fila + 1, this.Columna, esc);
                atraccions.Add(avall);
            }
            if (esc.DestiValid(this.Fila, this.Columna - 1))
            {
                esquerra = Atraccio(this.Fila, this.Columna - 1, esc);
                atraccions.Add(esquerra);
            }

            quiet = Atraccio(this.Fila, this.Columna, esc);
            atraccions.Add(quiet);
            
            resultat = atraccions.Max();

            if (resultat == amunt)
            {
                d.Add(Direccio.Amunt);
            }
            if (resultat == avall)
            {
                d.Add(Direccio.Avall);
            }
            if (resultat == dreta)
            {
                d.Add(Direccio.Dreta);
            }
            if (resultat == esquerra)
            {
                d.Add(Direccio.Esquerra);
            }
            if (resultat == quiet)
            {
                d.Add(Direccio.Quiet);
            }

            int direccio = r.Next(0, d.Count);
            return d[direccio];

        }
        /// <summary>
        /// Interès de la persona sobre una determinada posició
        /// </summary>
        /// <param name="pos">Posició</param>
        /// <returns>Interès quantificat</returns>
        public abstract int Interes(Posicio pos);
        /// <summary>
        /// Determina si la persona es un convidat (home o dona) o un cambrer
        /// </summary>
        /// <returns>Retorna si és convidat</returns>
        public abstract bool EsConvidat();

    }
}
