using Projet_fil_rouge_groupeG.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    class Specialite
    {
        private int id;
        private string specialiteMedecin;

        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string SpecialiteMedecin { get => specialiteMedecin; set => specialiteMedecin = value; }
        public Specialite()
        {

        }



        public static List<Specialite> GetListSpecialite()
        {
            List<Specialite> specialites = new List<Specialite>();
            string request = "SELECT id, specialiteMedecin FROM Specialite";
            command = new SqlCommand(request, DataBase.connection);
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Specialite spe = new Specialite();
                spe.Id = reader.GetInt32(0);
                spe.SpecialiteMedecin = reader.GetString(1);
                specialites.Add(spe);

            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return specialites;
        }
    }

}



}
