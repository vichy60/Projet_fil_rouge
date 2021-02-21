using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    class RDV
    {
        private int numeroRDV;
        private DateTime dateRDV;
        private string heureRDV;
        private string codeMedecin;
        private string codePatient;

        public RDV(int numeroRDV, DateTime dateRDV, string heureRDV, string codeMedecin, string codePatient)
        {
            this.NumeroRDV = numeroRDV;
            this.DateRDV = dateRDV;
            this.HeureRDV = heureRDV;
            this.CodeMedecin = codeMedecin;
            this.CodePatient = codePatient;
        }

        public int NumeroRDV { get => numeroRDV; set => numeroRDV = value; }
        public DateTime DateRDV { get => dateRDV; set => dateRDV = value; }
        public string HeureRDV { get => heureRDV; set => heureRDV = value; }
        public string CodeMedecin { get => codeMedecin; set => codeMedecin = value; }
        public string CodePatient { get => codePatient; set => codePatient = value; }






        public override string ToString()
        {
            return $"numéro de rendez-vous: {numeroRDV}, date du rendez-vous : {dateRDV}, heure du rendez-vous : {heureRDV} , le code du médecin : {codeMedecin}, le code patient : {codePatient}";
        }
    }
}
