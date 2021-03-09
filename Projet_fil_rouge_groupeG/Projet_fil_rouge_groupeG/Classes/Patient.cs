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

        public Patient(int codePatient, string nomPatient, string adressePatient, DateTime dateNaissance, string sexePatient) : base(codePatient, nomPatient)
        {
            CodePatient = codePatient;
            NomPatient = nomPatient;
            AdressePatient = adressePatient;
            DateNaissance = dateNaissance;
            SexePatient = sexePatient;
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

        public static Contact GetContactById(int id)
        {
            Contact contact = null;
            //Une méthode pour récupérer un contact avec son id
            string request = "SELECT id, nom, prenom, telephone from contact where id = @id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                contact = new Contact
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3)
                };
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return contact;
        }

        public static List<Contact> GetContacts()
        {
            //Pour une récupération totale avec les mails, 
            //on modifie la requete en ajoutant la jointure avec la table mail
            List<Contact> contacts = new List<Contact>();
            string request = "SELECT " +
                "c.id as contactId, c.nom, c.prenom, c.telephone, m.id as mailId, m.mail" +
                " from contact c left join Mail m on c.id = m.contactId";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            Contact contact = null;
            while (reader.Read())
            {
                if (contact == null || contact.Id != reader.GetInt32(0))
                {
                    contact = new Contact
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        Prenom = reader.GetString(2),
                        Telephone = reader.GetString(3)
                    };
                    contacts.Add(contact);
                }
                if (reader.GetValue(4).GetType() != typeof(DBNull))
                {
                    Email e = new Email
                    {
                        Id = reader.GetInt32(4),
                        Mail = reader.GetString(5)
                    };
                    contact.Mails.Add(e);
                }
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return contacts;
        }

        public static List<Contact> SearchContacts(string search)
        {

            List<Contact> contacts = new List<Contact>();
            string request = "SELECT id, nom, prenom, telephone from contact where " +
                "nom like @search OR prenom like @search OR telephone like @search";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@search", $"{search}%"));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Contact contact = new Contact
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3)
                };
                contacts.Add(contact);
            }
            reader.Close();
            command.Dispose();

            //Requete 2
            request = "deuxième requete";
            command = new SqlCommand(request, DataBase.Connection);
            //executer la commande


            DataBase.Connection.Close();
            return contacts;
        }





        public override string ToString()
        {
            return $"codePatient : {CodePatient}; nomPatient : {NomPatient}; adressePatient : {adressePatient}; dateNaissance : {dateNaissance}; sexePatient: {sexePatient}";
        }
    }
}
