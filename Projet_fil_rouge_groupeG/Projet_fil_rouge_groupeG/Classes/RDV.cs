using Projet_fil_rouge_groupeG.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    public class RDV
    {
        private int numeroRDV;
        private DateTime dateRDV;
        private string heureRDV;
        private int medecinId;
        private int patientId;
        private static SqlCommand command;
        private static SqlDataReader reader;


        public RDV()
        {

        }
        public RDV(int numeroRDV, DateTime dateRDV, string heureRDV, int medecinId, int patientId)
        {
            this.NumeroRDV = numeroRDV;
            this.DateRDV = dateRDV;
            this.HeureRDV = heureRDV;
            this.MedecinId = medecinId;
            this.PatientId = patientId;
        }

        public int NumeroRDV { get => numeroRDV; set => numeroRDV = value; }
        public DateTime DateRDV { get => dateRDV; set => dateRDV = value; }
        public string HeureRDV { get => heureRDV; set => heureRDV = value; }
        public int MedecinId { get => medecinId; set => medecinId = value; }
        public int PatientId { get => patientId; set => patientId = value; }



        public bool Save()
        {
            string request = "INSERT INTO RDV (dateRDV, heureRDV, medecinId, patientId) OUTPUT INSERTED.ID VALUES (@date, @heure, @medId,@patId)";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@date", DateRDV));
            command.Parameters.Add(new SqlParameter("@heure", HeureRDV));
            command.Parameters.Add(new SqlParameter("@medId", MedecinId));
            command.Parameters.Add(new SqlParameter("@patId", PatientId));
            DataBase.connection.Open();
            NumeroRDV = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.connection.Close();
            return NumeroRDV > 0;
        }

        //public bool Delete()
        //{
        //    //Instruction de suppression dans la base de données
        //    string request = "DELETE FROM Medecin where id=@id";
        //    command = new SqlCommand(request, DataBase.connection);
        //    command.Parameters.Add(new SqlParameter("@id", CodeMedecin));
        //    DataBase.connection.Open();
        //    int nbRow = command.ExecuteNonQuery();
        //    command.Dispose();
        //    DataBase.connection.Close();
        //    return nbRow == 1;
        //}



        //public bool Update()
        //{
        //    //Instruction Mise à jour dans la base de données après modification
        //    string request = "update Medecin set nomMedecin = @nom, telMedecin=@tel, dateEmbauche=@date, specialiteMedecinId=@spe where id=@id";
        //    command = new SqlCommand(request, DataBase.connection);
        //    command.Parameters.Add(new SqlParameter("@nom", NomMedecin));
        //    command.Parameters.Add(new SqlParameter("@tel", TelMedecin));
        //    command.Parameters.Add(new SqlParameter("@date", DateEmbauche));
        //    command.Parameters.Add(new SqlParameter("@spe", SpecialiteMedecinId));
        //    command.Parameters.Add(new SqlParameter("@id", CodeMedecin));
        //    DataBase.connection.Open();
        //    int nbRow = command.ExecuteNonQuery();
        //    command.Dispose();
        //    DataBase.connection.Close();
        //    return nbRow == 1;
        //}

        //public static Medecin GetMedecinById(int id)
        //{
        //    Medecin medecin = null;
        //    //Une méthode pour récupérer un medecin avec son id
        //    string request = "SELECT " +
        //        "id, nomMedecin, telMedecin, dateEmbauche, specialiteMedecinId" +
        //        " from Medecin" + " where id = @id";
        //    command = new SqlCommand(request, DataBase.connection);
        //    command.Parameters.Add(new SqlParameter("@id", id));
        //    DataBase.connection.Open();
        //    reader = command.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        medecin = new Medecin()
        //        {
        //            CodeMedecin = reader.GetInt32(0),
        //            NomMedecin = reader.GetString(1),
        //            TelMedecin = reader.GetString(2),
        //            DateEmbauche = reader.GetDateTime(3),
        //            SpecialiteMedecinId = reader.GetInt32(4)
        //        };
        //    }
        //    reader.Close();
        //    command.Dispose();
        //    DataBase.connection.Close();
        //    return medecin;
        //}

        public static List<RDV> GetRdvs()
        {

            List<RDV> Rdvs = new List<RDV>();
            string request = "SELECT " +
                "id,dateRDV, heureRDV, medecinId, patientId" +
                " from RDV";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                RDV r = new RDV()
                {
                    NumeroRDV = reader.GetInt32(0),
                    DateRDV = reader.GetDateTime(1),
                    HeureRDV = reader.GetString(2),
                    MedecinId = reader.GetInt32(3),
                    PatientId = reader.GetInt32(4),
                };
                Rdvs.Add(r);
            }

            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return Rdvs;
        }







        public override string ToString()
        {
            return $"numéro de rendez-vous: {numeroRDV}, date du rendez-vous : {dateRDV}, heure du rendez-vous : {heureRDV} , le code du médecin : {MedecinId}, le code patient : {PatientId}";
        }
    }
}
