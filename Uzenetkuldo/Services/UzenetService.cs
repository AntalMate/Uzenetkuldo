using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzenetkuldo.Interfaces;
using Uzenetkuldo.Models;

namespace Uzenetkuldo.Services
{
    public class UzenetService : ICRUD
    {
        public string Create(Tablazat tablazat)
        {
            try
            {
                string connectionString = "SERVER = localhost;" +
                              "DATABASE= uzenetkuldo;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "INSERT INTO uzenet(Szoveg, KüldesiIdo, UzenetTipus, Telefon, Email) VALUES (@szoveg,@kuldesiido,@uzenettipus,@telefon,@email)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@szoveg", (tablazat as Uzenet).Szoveg);
                cmd.Parameters.AddWithValue("@kuldesiido", (tablazat as Uzenet).KuldesiIdo);
                cmd.Parameters.AddWithValue("@uzenettipus", (tablazat as Uzenet).UzenetTipus);
                if ((tablazat as Uzenet).UzenetTipus == "SMS")
                {
                    cmd.Parameters.AddWithValue("@email", null);
                    cmd.Parameters.AddWithValue("@telefon", (tablazat as Uzenet).Telefon);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@telefon", null);
                    cmd.Parameters.AddWithValue("@email", (tablazat as Uzenet).Email);
                }
                int sorokSzama = cmd.ExecuteNonQuery();
                conn.Close();

                return sorokSzama > 0 ? "Sikeres beszúrás" : "Sikertelen beszúrás";
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex);
            }
        }

        public string Delete(int id)
        {
            string connectionString = "SERVER = localhost;" +
                        "DATABASE= uzenetkuldo;" +
                        "UID = root;" +
                        "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "DELETE FROM uzenet WHERE Id=@id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@id", id);
            int sorokSzama = cmd.ExecuteNonQuery();
            conn.Close();

            return sorokSzama > 0 ? "Sikeres törlés" : "Sikertelen törlés";
        }

        public List<Tablazat> Read()
        {
           
                List<Tablazat> tablazatok = new List<Tablazat>();

                string connectionString = "SERVER = localhost;" +
                              "DATABASE= uzenetkuldo;" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM uzenet";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //A beolvasott adatok feldolgozása
                    Uzenet uzenet = new Uzenet();
                    uzenet.Id = reader.GetInt32("Id");
                    uzenet.Szoveg = reader.GetString("Szoveg");
                    uzenet.KuldesiIdo = reader.GetDateTime("KüldesiIdo");
                    uzenet.UzenetTipus = reader.GetString("UzenetTipus");
                if (uzenet.UzenetTipus == "SMS")
                {
                    uzenet.Telefon = reader.GetString("Telefon");
                }
                else
                {
                    uzenet.Email = reader.GetString("Email");
                }
                    tablazatok.Add(uzenet);
                }
                conn.Close();

                return tablazatok;
            
            

        }

        public bool LetezikId(int id)
        {
            string connectionString = "SERVER = localhost;" +
                        "DATABASE= uzenetkuldo;" +
                        "UID = root;" +
                        "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "SELECT Id FROM uzenet WHERE Id=@id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool letezik = reader.HasRows;
            conn.Close();

            return letezik;
        }

        public string Update(Tablazat tablazat)
        {
            string connectionString = "SERVER = localhost;" +
                        "DATABASE= uzenetkuldo;" +
                        "UID = root;" +
                        "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "UPDATE uzenet SET Szoveg=@szoveg, KüldesiIdo=@kuldesiido, UzenetTipus=@uzenettipus, Telefon=@telefon, Email=@email WHERE Id=@id";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@szoveg", (tablazat as Uzenet).Szoveg);
            cmd.Parameters.AddWithValue("@kuldesiido", (tablazat as Uzenet).KuldesiIdo);
            cmd.Parameters.AddWithValue("@uzenettipus", (tablazat as Uzenet).UzenetTipus);
            if ((tablazat as Uzenet).UzenetTipus == "SMS")
            {
                cmd.Parameters.AddWithValue("@email", null);
                cmd.Parameters.AddWithValue("@telefon", (tablazat as Uzenet).Telefon);
            }
            else
            {
                cmd.Parameters.AddWithValue("@telefon", null);
                cmd.Parameters.AddWithValue("@email", (tablazat as Uzenet).Email);
            }
            cmd.Parameters.AddWithValue("@id", (tablazat as Uzenet).Id);
            int sorokSzama = cmd.ExecuteNonQuery();
            conn.Close();

            return sorokSzama > 0 ? "Sikeres frissítés" : "Sikertelen frissítés";
        }
    }
}