using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Projet_fil_rouge_groupeG.Tools
{
    class DataBase
    {
        private static string chaine = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yannick\Desktop\documents m2i\Projet_fil_rouge\base_projet_fil_rouge.mdf;Integrated Security=True;Connect Timeout=30";
        public static SqlConnection connection = new SqlConnection(chaine);
    }
}
