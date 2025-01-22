using Microsoft.Data.SqlClient;

namespace SQLTest
{
    internal class Program
    {
        private static string sql_conn = "Server=tcp:sqlservercboxtest.database.windows.net,1433;Initial Catalog=xxxxxxxxxxxxx;Persist Security Info=False;User ID=xxxxxxxxxx;Password=xxxxxxxxxxx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        static void Main(string[] args)
        {
            FirstTest();
            SecondTest();
        }

        private static void SecondTest()
        {
            
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
