﻿using Projet_fil_rouge_groupeG.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Projet_fil_rouge_groupeG.Classes
{
    public class Specialite
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
        public static Specialite GetSpecialite(int id)
        {
            Specialite spe = null;
            string request = "SELECT id, specialiteMedecin FROM Specialite where id = @id";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id",id));
            DataBase.connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                spe = new Specialite()
                {
                    Id = reader.GetInt32(0),
                    SpecialiteMedecin = reader.GetString(1)
                };
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return spe;
        }





        public override string ToString()

        {
            return SpecialiteMedecin;
        }


    }

}




