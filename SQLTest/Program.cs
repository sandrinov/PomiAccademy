using Microsoft.Data.SqlClient;

namespace SQLTest
{
    internal class Program
    {
        private static string sql_conn = "Server=tcp:sqlservercboxtest.database.windows.net,1433;Initial Catalog=xxxxxxxxx;Persist Security Info=False;User ID=xxxxxxxx;Password=xxxxxxxx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        static void Main(string[] args)
        {
            //FirstTest();
            SecondTest();
        }

        private static void SecondTest()
        {
            // Query SQL per ottenere il conteggio degli asset document per ogni asset
            string query = @"
            SELECT 
                a.ID_Asset AS AssetId, 
                a.AssetName AS AssetName, 
                COUNT(ad.AssetContainer) AS DocumentCount
            FROM Asset a
            LEFT JOIN AssetDocument ad ON a.ID_Asset = ad.AssetContainer
            GROUP BY a.ID_Asset, a.AssetName
            ORDER BY a.ID_Asset;
            ";

            try
            {
                using (SqlConnection connection = new SqlConnection(sql_conn))
                {
                    connection.Open();
                    Console.WriteLine("Connessione al database riuscita.");

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Elenco degli asset e dei documenti collegati:\n");

                            while (reader.Read())
                            {
                                int assetId = reader.GetInt32(0);
                                string assetName = reader.GetString(1);
                                int documentCount = reader.GetInt32(2);

                                Console.WriteLine($"Asset ID: {assetId}, Nome: {assetName}, Numero Documenti: {documentCount}");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
        }

        private static void FirstTest()
        {
            string query = "SELECT * FROM Asset";

            using (SqlConnection connection = new SqlConnection(sql_conn))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connessione al database riuscita.");

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
