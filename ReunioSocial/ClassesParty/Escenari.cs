using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesParty
{
    public class Escenari
    {
        Posicio[,] esc;
        int nHomes;
        int nDones;
        int nCambrers;
        TaulaPersones tp;

        
        /// <summary>
        /// Crea un escenari donades unes mides
        /// </summary>
        /// <param name="files">Número de files de l'escenari</param>
        /// <param name="columnes">Número de columnes de l'escenari</param>
        public Escenari(int files, int columnes)
        {
            esc = new Posicio[files,columnes];
            for(int fila = 0; fila < files; fila++)
            {
                for(int columna = 0; columna < columnes; columna++)
                {
                    esc[fila, columna] = new Posicio(fila, columna);    
                }
            }
            nHomes = 0;
            nDones = 0;
            nCambrers = 0;
            tp = new TaulaPersones();
        }
        /// <summary>
        /// Retorna el número de files de l'escenari
        /// </summary>
        public int Files
        {
            get { return esc.GetLength(0); }
        }
        /// <summary>
        /// Retorna el número de columnes de l'escenari
        /// </summary>
        public int Columnes
        {
            get { return esc.GetLength(1); }
        }
        /// <summary>
        /// Retorna el número de homes que hi ha dins de l'escenari
        /// </summary>
        public int Homes
        { 
            get { return nHomes;} 
        }
        /// <summary>
        /// Retorna el número de dones que hi ha dins de l'escenari
        /// </summary>
        public int Dones
        {
            get { return nDones; }
        }
        /// <summary>
        /// Retorna el número de Cambrers que hi ha dins de l'escenari
        /// </summary>
        public int Cambrers
        { 
            get { return nCambrers;} 
        }

        /// <summary>
        /// retorna taula persones
        /// </summary>
        public TaulaPersones Tp
        {
            get { return tp; }
        }
        /// <summary>
        /// Mou una persona de (filOrig, colOrig) fins a la posicio adjacent(filDesti,colDesti)
        /// Es suposa que les coordenades són vàlides, que hi ha una persona a l'origen i que el destí està buit.
        /// </summary>
        /// <param name="filOrig">Fila de la coordenada d'origen</param>
        /// <param name="colOrig">Columna de la coordenada d'origen</param>
        /// <param name="filDesti">Fila de la coordenada de destí</param>
        /// <param name="colDesti">Columna de la coordenada de destí</param>
        private void Moure(int filOrig, int colOrig, int filDesti, int colDesti)
        {
            if (DestiValid(filDesti, colDesti) && esc[filDesti, colDesti].Buida)
            {
                esc[filDesti, colDesti] = esc[filOrig, colOrig];
                esc[filDesti, colDesti].Fila = filDesti;
                esc[filDesti, colDesti].Columna = colDesti;
                esc[filOrig, colOrig] = new Posicio(filOrig,colOrig);
            }

        }

        /// <summary>
        /// Retorna la Posició que hi ha en una coordenada donada
        /// </summary>
        public Posicio this[int fila, int col]
        {
            get { return (Posicio)esc[fila,col];}
        }
        /// <summary>
        /// Mira si una coordenada es correcte per ser destí d'una persona
        /// </summary>
        /// <param name="fil">fila de la coordenada</param>
        /// <param name="col">columna de la coordenada</param>
        /// <returns>retorna si la coordenada és vàlida i està buida</returns>
        public bool DestiValid(int fil, int col)
        {
            bool destiValid = false;
            if (fil < esc.GetLength(0) && fil >= 0 && col >= 0 && col < esc.GetLength(1) && esc[fil,col].Buida)
                destiValid = true;
            return destiValid;

        }
        /// <summary>
        /// Retorna el contingut del escenari en forma de matriu d'strings,
        /// representant cada persona amb el seu nom
        /// </summary>
        /// <returns>Matriu de caràcters</returns>
        public String[,] ContingutNoms() //!
        {
            string[,] contingut = new string[esc.GetLength(0), esc.GetLength(1)];
            for(int i = 0; i < contingut.GetLength(0);i++)
            {
                for (int j = 0; j < contingut.GetLength(1); j++)
                {
                    if (!esc[i, j].Buida)
                    {
                        if (((Persona)esc[i, j]).EsConvidat())
                            contingut[i, j] = ((Convidat)esc[i, j]).Nom.ToString().Trim();
                        else
                            contingut[i, j] = ((Cambrer)esc[i, j]).Nom.ToString().Trim();
                    }
                }
            }
            return contingut;
        }
        /// <summary>
        /// Elimina una persona de l'escenari i de la taula de persones
        /// </summary>
        /// <param name="fil">Fila on està la persona</param>
        /// <param name="col">Columna on està la persona</param>
        public void buidar(int fil, int col)
        {
            if (esc[fil, col] is Cambrer)
            {
                nCambrers--;
            }
            else
            {
                if (esc[fil, col] is Home)
                    nHomes--;
                else
                    nDones--;
            }
            tp.Eliminar((Persona)esc[fil, col]);
            esc[fil, col] = new Posicio(fil,col);
            
        }
        /// <summary>
        /// Posa una Persona dins de l'escenari i a la taula de persones
        /// Si la posició de la persona ja està ocupada, genera una excepció
        /// </summary>
        /// <param name="pers">Persona a afegir</param>
        public void posar(Persona pers)
        {
            if (esc[pers.Fila, pers.Columna].Buida)
            {
                tp.Afegir(pers);
                esc[pers.Fila, pers.Columna] = pers;
                if (pers is Home)
                {
                    nHomes++;
                }
                else if (pers is Dona)
                    nDones++;
                else
                    nCambrers++;
            }
            else
                throw new Exception("Ja hi ha una persona en aquesta posicio");
        }
        /// <summary>
        /// Mira si en el tauler hi ha alguna persona amb aquest nom
        /// </summary>
        /// <param name="nom">Nom a cercar</param>
        /// <returns>Si hi ha coincidència</returns>
        public bool NomRepetit(string nom)
        {
            bool trobat = false;
            int i = 0;
            while(i < tp.NumPersones && !trobat)
            {
                if(tp.ElementAt(i).Nom == nom)
                {
                    trobat = true;
                }
                i++;
            }

            return trobat;
        }
        /// <summary>
        /// Fa que totes les persones facin un moviment
        /// </summary>
        public void Cicle()
        {
            
            foreach (Persona p in tp)
            {
                Direccio d = p.OnVaig(this);
                if (d == Direccio.Amunt)
                {
                    this.Moure(p.Fila, p.Columna, p.Fila - 1, p.Columna);
                }
                else if (d == Direccio.Avall)
                {
                    this.Moure(p.Fila, p.Columna, p.Fila + 1, p.Columna);
                }
                else if (d == Direccio.Dreta)
                {
                    this.Moure(p.Fila, p.Columna, p.Fila, p.Columna + 1);
                }
                else if (d == Direccio.Esquerra)
                {
                    this.Moure(p.Fila, p.Columna, p.Fila, p.Columna - 1);
                }
                else if (d == Direccio.Quiet)
                {
                    this.Moure(p.Fila, p.Columna, p.Fila, p.Columna);
                }
            }
        }
    }
}
