using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    class Medecin 
    {
        private int codeMedecin;
        private string nomMedecin;
        private string telMedecin;
        private DateTime dateEmbauhe;
        private string specialiteMedecin;

        public Medecin(int codeMedecin, string nomMedecin, string telMedecin, DateTime dateEmbauhe, string specialiteMedecin)
        {
            this.NomMedecin = nomMedecin;
            this.CodeMedecin = codeMedecin;
            this.TelMedecin = telMedecin;
            this.DateEmbauhe = dateEmbauhe;
            this.SpecialiteMedecin = specialiteMedecin;
        }
        public int CodeMedecin { get => codeMedecin; set => codeMedecin = value; }
        public string NomMedecin { get => nomMedecin; set => nomMedecin = value; }
        public string TelMedecin { get => telMedecin; set => telMedecin = value; }
        public DateTime DateEmbauhe { get => dateEmbauhe; set => dateEmbauhe = value; }
        public string SpecialiteMedecin { get => specialiteMedecin; set => specialiteMedecin = value; }


        public override string ToString()
        {
            return $"codeMedecin : {CodeMedecin}; nomMedecin : {NomMedecin}; telMedecin : {telMedecin}; dateEmbauche : {dateEmbauhe}; spécialité: {specialiteMedecin}";
        }



    }
}
