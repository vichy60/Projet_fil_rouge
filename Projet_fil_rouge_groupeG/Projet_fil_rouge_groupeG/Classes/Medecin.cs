using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    class Medecin : Personne
    {
        private string telMedecin;
        private DateTime dateEmbauhe;
        private string specialiteMedecin;

        public Medecin(string codeMedecin, string nomMedecin, string telMedecin, DateTime dateEmbauhe, string specialiteMedecin) : base (codeMedecin,nomMedecin)
        {
            this.TelMedecin = telMedecin;
            this.DateEmbauhe = dateEmbauhe;
            this.SpecialiteMedecin = specialiteMedecin;
        }

        public string TelMedecin { get => telMedecin; set => telMedecin = value; }
        public DateTime DateEmbauhe { get => dateEmbauhe; set => dateEmbauhe = value; }
        public string SpecialiteMedecin { get => specialiteMedecin; set => specialiteMedecin = value; }



        public override string ToString()
        {
            return $"codeMedecin : {CodePersonne}; nomMedecin : {NomPersonne}; telMedecin : {telMedecin}; dateEmbauche : {dateEmbauhe}; spécialité: {specialiteMedecin}";
        }



    }
}
