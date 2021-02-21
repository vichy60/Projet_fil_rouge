using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    class Patient :Personne
    {
        private string adressePatient;
        private DateTime dateNaissance;
        private string sexePatient;

        public Patient(string codePatient, string nomPatient, string adressePatient, DateTime dateNaissance, string sexePatient) : base (codePatient, nomPatient)
        {
            AdressePatient = adressePatient;
            DateNaissance = dateNaissance;
            SexePatient = sexePatient;
        }

        public string AdressePatient { get => adressePatient; set => adressePatient = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string SexePatient { get => sexePatient; set => sexePatient = value; }


        public override string ToString()
        {
            return $"codePatient : {CodePersonne}; nomPatient : {NomPersonne}; adressePatient : {adressePatient}; dateNaissance : {dateNaissance}; sexePatient: {sexePatient}";
        }
    }
}
