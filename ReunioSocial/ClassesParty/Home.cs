using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public class Home : Convidat
    {
       
        /// <summary>
        /// Crea un Home
        /// </summary>
        /// <param name="nom">String que l'identificarà</param>
        /// <param name="sexe">Plus de simpatia envers del sexe contrari</param>
        /// 
        public Home(string nom, int sexe, string nomImg) : base(nom, sexe, nomImg){}
        /// <summary>
        /// Interès d'aquest home per una posició
        /// </summary>
        /// <param name="pos">Posició per la qual s'interessa</param>
        /// <returns>Interès quantificat</returns>
        /// 
        public override int Interes(Posicio pos)
        {
            int interes = 0;
            if (!pos.Buida)
            {
                if (pos is Convidat)
                {
                    if (pos is Dona)
                    {
                        interes = base[((Convidat)pos).Nom] + PlusSexe;
                    }
                    else
                    {
                        interes = base[((Convidat)pos).Nom];
                    }
                }
                else
                {
                    interes = 1;
                }
            }
            return interes;
        }
    }
}
