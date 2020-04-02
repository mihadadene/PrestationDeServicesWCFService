using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PrestationDeServicesWCFService
{
    public class DataProvider
    {
        public List<Prestation> GetPrestation()
        {
            List<Prestation> resultats = new List<Prestation>();
            Prestation prestation;

            //connection a la base de donnée
            MySqlConnection cnx = new MySqlConnection();
            try
            {
                cnx.ConnectionString = "Server = 127.0.0.1; Uid = root; Pwd = root; Database = prestations; ";
                Console.WriteLine("Connection sur MySql...");
                cnx.Open();

                //preparer l'excution de la requete'
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Prestation";
                cmd.CommandType = CommandType.TableDirect;
                cmd.Connection = cnx;

                //recuperation du reader
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    prestation = new Prestation();
                    prestation.Id = "" + dr["ID"];
                    prestation.Nom = "" + dr["NOM"];
                    prestation.Type = "" + dr["TYPE"];

                    resultats.Add(prestation);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnx.Close();
               
            }
            return resultats;
        }

    
        public bool delete(string IdPrestation)
        {

            bool resultat = false;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server = 127.0.0.1; Uid = root; Pwd = root; Database = prestations; ";
            cnx.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE From prestation WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", IdPrestation);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnx;

            int n = cmd.ExecuteNonQuery();
            if (n > 0) resultat = true;


            cnx.Close();
            return resultat;
        }
    }
}