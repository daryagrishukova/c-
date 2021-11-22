using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace QuateProject
{
    class DataClass
    {
        MySqlConnectionStringBuilder connectionStr;
        MySqlConnection connection;

        // Метод создания Строки подключения, и Коннекшина
        public void CreateStrConnection()
        {
            connectionStr = new MySqlConnectionStringBuilder();
            connectionStr.Server = "localhost";
            connectionStr.UserID = "root";
            connectionStr.Password = "k403";
            connectionStr.Database = "quote";
            connection = new MySqlConnection(connectionStr.ToString());
        }

        public void AddQuote(string Text, string Author, string Link )
        {

            string CommandText = $"INSERT INTO quotes (Text,Author,Link) VALUES ('{Text}','{Author}','{Link}');";


            try
            {

                connection.Open();

                MySqlCommand command = new MySqlCommand(CommandText, connection);

                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(error.Message);
            }
            connection.Close();

        }
        public List<QuotesData> ReadQuote()
        {
            List<QuotesData> quotes = new List<QuotesData>();

            string CommandText = $"SELECT * FROM quotes;";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(CommandText, connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        quotes.Add(new QuotesData()
                        {
                            id = reader.GetInt32(0),
                            Text = reader.GetString(1),
                            Author = reader.GetString(2),
                            Link = reader.GetString(3)
                        });
                    }
                }

            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(error.Message);
            }
            connection.Close();
            return quotes;
        }
    }
}
