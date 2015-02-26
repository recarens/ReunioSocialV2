﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public class Cambrer : Persona
    {

        static int numCambrers = 0;
        /// <summary>
        /// Crea un cambrer (Persona de la que no importa el nom, i es dirà "Cambrer 1",
        /// "Cambrer 2", "Cambrer 3", "Cambrer 4" ... "CambrerN"/// </summary>
        public Cambrer(string nomImg):base("Cambrer "+ numCambrers++,nomImg){}//el cambrer falta la herencia  apersona sino no es pot afegir a la taulaPersones
        public string Nom
        {
            get { return base.Nom; }
        }
        /// <summary>
        /// Interès del cambrer per una posició
        /// </summary>
        /// <param name="pos">posició per la que s'interessa</param>/// <returns>Retorna 0 si no hi ha ningú, 1 si hi ha un convidat i -1 si un cambrer</returns>
        public override int Interes(Posicio pos)
        {
            int interes = 0;

            if (pos is Cambrer)
            {
                interes= -1;
            }
            else if (pos is Convidat)
            {
               interes =  1;
            }

            return interes;
        }
        /// <summary>
        /// Retorna que el Cambrer no és un convidat
        /// </summary>
        /// <returns>false</returns>
        public override bool EsConvidat()
        {
            return false;
        }
    }
}
