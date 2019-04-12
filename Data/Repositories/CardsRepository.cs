using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repositories
{
    public class CardsRepository : IRepositories
    {
        

        public IEnumerable<CardModel> GetCards()
        {
            List<CardModel> cardsList = new List<CardModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand("select * from [dbo].[Cards]", connection);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CardModel card = new CardModel();
                                card.ID = reader.GetInt32(0);
                                card.Validity = reader.GetDateTime(1);
                                card.Pin = reader.GetString(2);
                                card.CardNumber = reader.GetString(3);
                                card.Account_ID = reader.GetInt32(4);
                                cardsList.Add(card);
                            }
                            

                        }
                        return cardsList;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error happend during query \n {ex.Message}");
                        return null;
                    }


                }
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during connecting \n {e.Message}");
                return null;
            }
        }

        public DataSet FillDataSet()
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING);

            SqlDataAdapter adapter = new SqlDataAdapter("select * from [dbo].[Cards]", connection);

            adapter.Fill(ds, "Cards");

            return ds;
        }

        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        public bool CheckPin(string cardNumber, int pin)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select * from [dbo].[Cards]", connection);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {                               

                                if (reader.GetString(3).Equals(cardNumber))
                                {                                    
                                    if (reader.GetString(2).Equals(CalculateMD5Hash(pin.ToString())))
                                    {
                                        return true;
                                    }
                                }

                            }
                            return false;

                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error happend during query \n {ex.Message}");
                        return false;
                    }


                }
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during connecting \n {e.Message}");
                return false;
            }

        }
    }
}
