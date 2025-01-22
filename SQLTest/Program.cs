﻿using Microsoft.Data.SqlClient;

namespace SQLTest
{
    internal class Program
    {
        private static string sql_conn = "Server=tcp:sqlservercboxtest.database.windows.net,1433;Initial Catalog=AvioAssetChainDB;Persist Security Info=False;User ID=pomi-admin;Password=Addtech2021!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        static void Main(string[] args)
        {
            string query = "SELECT * FROM Asset";

            SqlConnection connection = new SqlConnection(sql_conn);
            connection.Open();
            Console.WriteLine("Connessione al database riuscita.");

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                int id = reader.GetInt32(0);
                string assetname = reader.GetString(1);
                string assettype = reader.GetString(3);

                Console.WriteLine($"ID: {id}, Name: {assetname}, type: {assettype}");
            }
            reader.Close();
            connection.Close();
        }
    }
}
