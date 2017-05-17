using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Opdracht1
{
    public class Database
    {
        private string conn_string;

        public Database()
        {
            //Bouw de connection string
            conn_string = "Server=" + mysql_server + ";Port=3306;Database=" + mysql_database + ";Uid=" + mysql_username + ";Pwd=" + mysql_password;
        }

        public ArrayList getAllPersoneelAL()
        {
            //Maak verbinding met de MySQL server
            MySqlConnection conn = new MySqlConnection(conn_string);
            conn.Open();

            //Maak de query
            string query = "SELECT * FROM mcsh5_personeel ORDER BY achternaam ASC";

            //Maak het command-object
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Maak de lege ArrayList
            ArrayList result = new ArrayList();

            //Voer de query uit
            MySqlDataReader reader = cmd.ExecuteReader();

            //Zolang er nog data te lezen is
            while (reader.Read())
            {
                //Maak een tijdelijke ArrayList
                ArrayList temp = new ArrayList();

                //Lees de data voor dit record
                temp.Add(reader["id"]);
                temp.Add(reader["voornaam"]);
                temp.Add(reader["achternaam"]);
                temp.Add(reader["geboren"]);
                temp.Add(reader["geslacht"]);

                //Sla de tijdelijke ArrayList op in het resultaat
                result.Add(temp);
            }

            //Sluit de verbinding
            reader.Close();
            conn.Close();

            //Geef het antwoord terug
            return result;
        }

        public DataTable getAllPersoneelDT()
        {
            //Lees alle peroneelsleden als ArrayList
            ArrayList personeel = getAllPersoneelAL();

            //Maak de DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Geslacht", Type.GetType("System.String"));
            dt.Columns.Add("Voornaam", Type.GetType("System.String"));
            dt.Columns.Add("Achternaam", Type.GetType("System.String"));
            dt.Columns.Add("Geboren", Type.GetType("System.String"));

            foreach (ArrayList temp in personeel)
            {
                //Voeg een regel toe aan de DataTable
                dt.Rows.Add();

                //Vul de rij met data
                dt.Rows[dt.Rows.Count - 1]["ID"] = temp[0];
                dt.Rows[dt.Rows.Count - 1]["Geslacht"] = temp[4];
                dt.Rows[dt.Rows.Count - 1]["Voornaam"] = temp[1];
                dt.Rows[dt.Rows.Count - 1]["Achternaam"] = temp[2];

                string geborenText = temp[3].ToString();
                DateTime geboren = DateTime.Parse(geborenText);
                dt.Rows[dt.Rows.Count - 1]["Geboren"] = geboren.ToString("dd-MM-yyyy");
            }

            //Geef het antwoord terug
            return dt;
        }

        public ArrayList getPersoonAL(string ID)
        {
            //Maak verbinding met de MySQL server
            MySqlConnection conn = new MySqlConnection(conn_string);
            conn.Open();

            //Maak de query
            string query = "SELECT * FROM mcsh5_personeel WHERE id = " + ID;

            //Maak het commando-object
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Maak een lege ArrayList
            ArrayList result = new ArrayList();

            //Voer het commando uit, sla op in een reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //Lees de reader, plaats de data in de ArrayList
            reader.Read();
            result.Add(reader["id"]);
            result.Add(reader["voornaam"]);
            result.Add(reader["achternaam"]);
            result.Add(reader["geboren"]);
            result.Add(reader["geslacht"]);

            //Return de resultaten
            return result;
        }

        public void updaten(ArrayList gegevens, string ID)
        {
            //Maak verbinding met de MySQL server
            MySqlConnection conn = new MySqlConnection(conn_string);
            conn.Open();

            //Lees de ArrayList uit
            string voornaam = gegevens[0].ToString();
            string achternaam = gegevens[1].ToString();
            string geboren = gegevens[2].ToString();
            string geslacht = gegevens[3].ToString();

            //Maak de query
            string query = "UPDATE mcsh5_personeel SET voornaam='" + voornaam + "', achternaam='" + achternaam + "', geboren='" + geboren + "', geslacht='" + geslacht + "'WHERE id = " + ID;

            //Maak het commando-object
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Voer het commando uit, sla op in een reader
            cmd.ExecuteNonQuery();
        }

        public void toevoegen(ArrayList gegevens)
        {
            //Maak verbinding met de MySQL server
            MySqlConnection conn = new MySqlConnection(conn_string);
            conn.Open();

            //Lees de ArrayList uit
            string voornaam = gegevens[0].ToString();
            string achternaam = gegevens[1].ToString();
            string geboren = gegevens[2].ToString();
            string geslacht = gegevens[3].ToString();

            //Maak de query
            string query = "INSERT INTO mcsh5_personeel (`voornaam`, `achternaam`, `geboren`, `geslacht`) VALUES ('" + voornaam + "', '" + achternaam + "', '" + geboren + "', '" + geslacht + "')";

            //Maak het commando-object
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Voer het commando uit, sla op in een reader
            cmd.ExecuteNonQuery();
        }

        public void verwijderen(string ID)
        {
            //Maak verbinding met de MySQL server
            MySqlConnection conn = new MySqlConnection(conn_string);
            conn.Open();

            //Maak de query
            string query = "DELETE FROM mcsh5_personeel WHERE ID=" + ID;

            //Maak het commando-object
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Voer het commando uit, sla op in een reader
            cmd.ExecuteNonQuery();
        }
    }
}