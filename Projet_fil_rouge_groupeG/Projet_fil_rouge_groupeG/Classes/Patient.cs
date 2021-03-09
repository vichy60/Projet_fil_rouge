using Projet_fil_rouge_groupeG.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    class Patient
    {
        private int codePatient;
        private string nomPatient;
        private string adressePatient;
        private DateTime dateNaissance;
        private string sexePatient;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public Patient()
        {

        }
        public Patient(int CodePatient, string NomPatient, string AdressePatient, DateTime DateNaissance, string SexePatient)
        {
            this.CodePatient = CodePatient;
            this.NomPatient = NomPatient;
            this.AdressePatient = AdressePatient;
            this.DateNaissance = DateNaissance;
            this.SexePatient = SexePatient;
        }
        public int CodePatient { get => codePatient; set => codePatient = value; }
        public string NomPatient { get => nomPatient; set => nomPatient = value; }
        public string AdressePatient { get => adressePatient; set => adressePatient = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string SexePatient { get => sexePatient; set => sexePatient = value; }


        public bool Save()
        {
            string request = "INSERT INTO Patient (nomPatient, adressePatient, dateNaissance, sexePatient) VALUES (@nom, @adresse, @date,@sexe)"; 
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", NomPatient));
            command.Parameters.Add(new SqlParameter("@adresse", AdressePatient));
            command.Parameters.Add(new SqlParameter("@date", dateNaissance));
            command.Parameters.Add(new SqlParameter("@sexe", sexePatient));
            DataBase.Connection.Open();
            CodePatient = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.Connection.Close();
            return CodePatient > 0;
        }

        public bool Delete()
        {
            //Instruction de suppression dans la base de données
            string request = "DELETE FROM Patient where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", CodePatient));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        

        public bool Update()
        {
            //Instruction Mise à jour dans la base de données après modification
            string request = "update Patient set nomPatient = @nom, adressePatient=@adresse, dateNaissance=@date sexePatient=@sexe where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", NomPatient));
            command.Parameters.Add(new SqlParameter("@prenom", AdressePatient));
            command.Parameters.Add(new SqlParameter("@telephone", DateNaissance));
            command.Parameters.Add(new SqlParameter("@sexe", SexePatient));
            command.Parameters.Add(new SqlParameter("@id", CodePatient));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public static Patient GetPatientById(int id)
        {
            Patient patient = null;
            //Une méthode pour récupérer un contact avec son id
            string request = "SELECT id, nomPatient, adressePatient, dateNaissance, sexePatient from Patient where id = @id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                patient = new Patient()
                {
                    CodePatient = reader.GetInt32(0),
                    NomPatient = reader.GetString(1),
                    AdressePatient = reader.GetString(2),
                    DateNaissance = reader.GetDateTime(3),
                    SexePatient = reader.GetString(4),
                };
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return patient;
        }

        public static List<Patient> GetPatients()
        {
            
            List<Patient> patients = new List<Patient>();
            string request = "SELECT " +
                "id,nomPatient,adressePatient,dateNaissance, sexePatient" +
                " from Patient";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
           Patient patient = null;
            while (reader.Read())
            {
                if (patient == null || patient.CodePatient != reader.GetInt32(0))
                {
                    patient = new Patient
                    {
                        CodePatient = reader.GetInt32(0),
                        NomPatient = reader.GetString(1),
                        AdressePatient = reader.GetString(2),
                        DateNaissance = reader.GetDateTime(3),
                        SexePatient = reader.GetString(4),
                    };
                    patients.Add(patient);
                }
            }  
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return patients;
        }

        //public static List<Contact> SearchContacts(string search)
        //{

        //    List<Contact> contacts = new List<Contact>();
        //    string request = "SELECT id, nom, prenom, telephone from contact where " +
        //        "nom like @search OR prenom like @search OR telephone like @search";
        //    command = new SqlCommand(request, DataBase.Connection);
        //    command.Parameters.Add(new SqlParameter("@search", $"{search}%"));
        //    DataBase.Connection.Open();
        //    reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Contact contact = new Contact
        //        {
        //            Id = reader.GetInt32(0),
        //            Nom = reader.GetString(1),
        //            Prenom = reader.GetString(2),
        //            Telephone = reader.GetString(3)
        //        };
        //        contacts.Add(contact);
        //    }
        //    reader.Close();
        //    command.Dispose();

        //    //Requete 2
        //    request = "deuxième requete";
        //    command = new SqlCommand(request, DataBase.Connection);
        //    //executer la commande


        //    DataBase.Connection.Close();
        //    return contacts;
        //}





        public override string ToString()
        {
            return $"codePatient : {CodePatient}; nomPatient : {NomPatient}; adressePatient : {adressePatient}; dateNaissance : {dateNaissance}; sexePatient: {sexePatient}";
        }
    }
}
