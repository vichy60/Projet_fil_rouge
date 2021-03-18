using Projet_fil_rouge_groupeG.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    public class Medecin
    {
        private int codeMedecin;
        private string nomMedecin;
        private string telMedecin;
        private DateTime dateEmbauche;
        private int specialiteMedecinId;
        private static SqlCommand command;
        private static SqlDataReader reader;


        public Medecin()
        {

        }
        public Medecin(int codeMedecin, string nomMedecin, string telMedecin, DateTime dateEmbauche, int specialiteMedecinId)
        {
            this.NomMedecin = nomMedecin;
            this.CodeMedecin = codeMedecin;
            this.TelMedecin = telMedecin;
            this.DateEmbauche = dateEmbauche;
            this.SpecialiteMedecinId = specialiteMedecinId;
        }
        public int CodeMedecin { get => codeMedecin; set => codeMedecin = value; }
        public string NomMedecin { get => nomMedecin; set => nomMedecin = value; }
        public string TelMedecin { get => telMedecin; set => telMedecin = value; }
        public DateTime DateEmbauche { get => dateEmbauche; set => dateEmbauche = value; }
        public int SpecialiteMedecinId { get => specialiteMedecinId; set => specialiteMedecinId = value; }




        public bool Save()
        {
            string request = "INSERT INTO Medecin (nomMedecin, telMedecin, dateEmbauche, specialiteMedecinId) OUTPUT INSERTED.ID VALUES (@nom, @tel, @date,@spe)";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@nom", NomMedecin));
            command.Parameters.Add(new SqlParameter("@tel", TelMedecin));
            command.Parameters.Add(new SqlParameter("@date", DateEmbauche));
            command.Parameters.Add(new SqlParameter("@spe", SpecialiteMedecinId));
            DataBase.connection.Open();
            CodeMedecin = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.connection.Close();
            return CodeMedecin > 0;
        }

        public bool Delete()
        {
            //Instruction de suppression dans la base de données
            string request = "DELETE FROM Medecin where id=@id";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id", CodeMedecin));
            DataBase.connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.connection.Close();
            return nbRow == 1;
        }



        //public bool Update()
        //{
        //    //Instruction Mise à jour dans la base de données après modification
        //    string request = "update Patient set nomPatient = @nom, adressePatient=@adresse, dateNaissance=@date, sexePatient=@sexe where id=@id";
        //    command = new SqlCommand(request, DataBase.connection);
        //    command.Parameters.Add(new SqlParameter("@nom", NomPatient));
        //    command.Parameters.Add(new SqlParameter("@adresse", AdressePatient));
        //    command.Parameters.Add(new SqlParameter("@date", DateNaissance));
        //    command.Parameters.Add(new SqlParameter("@sexe", SexePatient));
        //    command.Parameters.Add(new SqlParameter("@id", CodePatient));
        //    DataBase.connection.Open();
        //    int nbRow = command.ExecuteNonQuery();
        //    command.Dispose();
        //    DataBase.connection.Close();
        //    return nbRow == 1;
        //}

        public static Medecin GetMedecinById(int id)
        {
            Medecin medecin = null;
            //Une méthode pour récupérer un medecin avec son id
            string request = "SELECT " +
                "id, nomMedecin, telMedecin, dateEmbauche, specialiteMedecinId" +
                " from Medecin" +" where id = @id";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                medecin = new Medecin()
                {
                    CodeMedecin = reader.GetInt32(0),
                    NomMedecin = reader.GetString(1),
                    TelMedecin = reader.GetString(2),
                    DateEmbauche = reader.GetDateTime(3),
                    SpecialiteMedecinId = reader.GetInt32(4)
                };
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return medecin;
        }

        public static List<Medecin> GetMedecins()
        {

            List<Medecin> medecins = new List<Medecin>();
            string request = "SELECT " +
                "id,nomMedecin, telMedecin, dateEmbauche, specialiteMedecinId" +
                " from Medecin";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Medecin medecin = new Medecin()
                {
                    CodeMedecin = reader.GetInt32(0),
                    NomMedecin = reader.GetString(1),
                    TelMedecin = reader.GetString(2),
                    DateEmbauche = reader.GetDateTime(3),
                    SpecialiteMedecinId = reader.GetInt32(4),
                };
                medecins.Add(medecin);
            }

            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return medecins;
        }


        public override string ToString()
        {
            return $"codeMedecin : {CodeMedecin}; nomMedecin : {NomMedecin}; telMedecin : {telMedecin}; dateEmbauche : {dateEmbauche}; spécialité: {specialiteMedecinId}";
        }
















    }
}

