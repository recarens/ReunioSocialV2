using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public class Dona : Convidat
    {
        Dictionary<Posicio, int> interessos;
      
        /// <summary>
        /// Crea una Dona
        /// </summary>
        /// <param name="nom"> String que identifica aquesta Dona</param>
        /// <param name="sexe">Plus de simpatia envers convidats del sexe contrari</param>
        public Dona(string nom, int sexe, string nomImg):base(nom,sexe,nomImg)
        {
            interessos = new Dictionary<Posicio, int>();
        }
        /// <summary>
        /// Interès d'aquesta dona per una posició
        /// </summary>
        /// <param name="pos">Posició per la qual s'interessa</param>
        /// <returns>Interès quantificat</returns>
        public override int Interes(Posicio pos)
        {
            int interes = 0;
            if(!pos.Buida)
            {
                if(pos is Convidat)
                { 
                     if (pos is Home)
                     {
                         interes = base[((Convidat)pos).Nom] + PlusSexe;
                     }
                     else if (pos is Dona)
                     {
                         interes = base[((Convidat)pos).Nom];
                     }
                }
            }
            return interes;
        }
    }
}
