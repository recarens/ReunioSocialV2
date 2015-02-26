using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesParty
{
    public abstract class Convidat : Persona
    {
        Dictionary<string,int> simpaties;
        int sexe;
        static int i = 0;

        /// <summary>
        /// Crea un convidat
        /// </summary>
        /// <param name="nom">Caràcter que l'identificarà</param>
        /// <param name="sex">Plus de simpatia sobre el sexe contrari</param>
        public Convidat(string nom, int sexe, string nomImg):base(nom,nomImg)
        {
            this.sexe = sexe;
            simpaties = new Dictionary<string, int>();
        }
        /// <summary>
        /// Retorna o estableix la simpaties envers a algú
        /// </summary>
        public int this[string nom]
        {
            get 
            {
                nom = nom.ToLower();
                return simpaties[nom];
            }
            set 
            {
                if(simpaties.ContainsKey(nom))
                {
                    simpaties[nom] = value;
                }
                else
                {
                    nom = nom.ToLower();
                    simpaties.Add(nom, value);
                    i++;
                }
                
            }
        }
        /// <summary>
        /// Retorna o estableix el plus de simpatia envers del sexe contrari
        /// </summary>
        public int PlusSexe
        {
            get
            {
                return sexe;
            }
            set
            {
                this.sexe = value;
            }
        }
        /// <summary>
        /// Retorna que si és un convidat
        /// </summary>
        /// <returns>Cert</returns>
        public override bool EsConvidat()
        {
            return true;
        }
    }
}