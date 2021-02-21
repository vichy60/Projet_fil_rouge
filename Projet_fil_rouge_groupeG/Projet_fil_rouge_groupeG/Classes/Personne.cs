using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    abstract class Personne
    {
        private string codePersonne;
        private string nomPersonne;

        protected Personne(string codePersonne, string nomPersonne)
        {
           CodePersonne = codePersonne;
           NomPersonne = nomPersonne;
        }

        public string CodePersonne { get => codePersonne; set => codePersonne = value; }
        public string NomPersonne { get => nomPersonne; set => nomPersonne = value; }



       


    }
}
