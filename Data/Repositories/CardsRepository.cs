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
    public class CardsRepository 
    {
        
        /// <summary>
        /// Reads sql database and save it to a list of all cardModels
        /// and returns it 
        /// </summary>
        /// <returns></returns>
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
                                card.IsValid = reader.GetBoolean(5);
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
        
        /// <summary>
        /// gets specific card from database searching by Client IDCard
        /// </summary>
        /// <param name="clientCardID"></param>
        /// <returns></returns>
        public IEnumerable<CardModel> GetCardsByClientCardID(string clientCardID)
        {
            string query = @"select Validity,CardNumber,isValid 
                             from (Cards as c 
                             left join Accounts as a on c.Account_ID=a.ID )
                             left join Users as u on u.ID= a.UserID
                             where u.IDCardNumber= @clientCardID";
            List<CardModel> cardsList = new List<CardModel>();

            using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@clientCardID", SqlDbType.NVarChar).Value = clientCardID;

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CardModel card = new CardModel
                            {
                                Validity = reader.GetDateTime(0),
                                CardNumber = reader.GetString(1),
                                IsValid = reader.GetBoolean(2)
                            };

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
        
        /// <summary>
        /// method for hashing pins into hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// checks if the entered pin is correct,hashing it comparing to a hash in the database
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
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

        /// <summary>
        /// generate new random credit cardNumber
        /// </summary>
        /// <returns></returns>
        public  string GenerateCreditCardNumber()
        {
            Random random = new Random();
            string creditcardNumber = "";
            for (int i = 0; i < 16; i++)
            {
                creditcardNumber = $"{creditcardNumber}{random.Next(0, 9).ToString()}";
            }
            return creditcardNumber;
        }

        /// <summary>
        /// Method for creating new credit card and give it to the right account using 
        /// user IDcard as identifier
        /// </summary>
        /// <param name="clientCardID"></param>
        /// <param name="pin"></param>
        /// <param name="generatedNumber"></param>
        public void CreateNewCreditcard(string clientCardID,int pin,string generatedNumber)
        {
                    string query = @"INSERT INTO Cards
                                     values(dateadd (YEAR,4,GETDATE()),@hashedpin,@creditcardNumber, (select top 1 a.id
                                     from Accounts as a
                                     left join Users as u on u.ID=a.UserID
                                     where u.IDCardNumber= @clientCardID) ,1)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            
                            command.Parameters.Add("@hashedpin", SqlDbType.NVarChar).Value = CalculateMD5Hash(pin.ToString());
                            command.Parameters.Add("@clientCardID", SqlDbType.NVarChar).Value = clientCardID;
                            command.Parameters.Add("@creditcardNumber", SqlDbType.NVarChar).Value = generatedNumber;
                            command.ExecuteNonQuery();

                          
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error ocured while quering " + ex.Message);
                       
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error ocured while connecting " + e.Message);
                
            }


        }
        
        /// <summary>
        /// method for blocking or unblocking Card
        /// if blocked then unblock 
        /// if unblock then block
        /// </summary>
        /// <param name="creditCardNumber"></param>
        public void BlockUnblockCard(string creditCardNumber)
        {
            string query = @"update cards 
                             set isValid = case
                                          when isValid = 1 then 0
				                          else 1
                                end
                                where CardNumber = @cardNumber";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;

                            command.Parameters.Add("@cardNumber", SqlDbType.NVarChar).Value = creditCardNumber;
                            
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error ocured while quering " + ex.Message);

                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error ocured while connecting " + e.Message);

            }


        }

        /// <summary>
        /// method for Pin reset
        /// </summary>
        /// <param name="clientCardID"></param>
        /// <param name="pin"></param>
        public void ChangePin(string clientCardID,int pin)
        {
            string query = @"update Cards
                             set Pin = @hashedPin
                             where CardNumber = @Cardnumber";
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.Parameters.Add("@hashedPin", SqlDbType.VarChar).Value = CalculateMD5Hash(pin.ToString());
                            command.Parameters.Add("@Cardnumber", SqlDbType.VarChar).Value = clientCardID;

                            command.ExecuteNonQuery();

                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error ocured while quering " + ex.Message);

                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error ocured while connecting " + e.Message);

            }

        }
        
        /// <summary>
        /// this methods give us count of active cards of the client based on his 
        /// ID card number
        /// </summary>
        /// <param name="clientIDCard"></param>
        /// <returns></returns>
        public int GetAcitiveCardsCount(string clientIDCard)
        {
            string query = @"select count(c.isValid)
                            from(Cards as c
                            left join Accounts as a on a.ID = c.Account_ID)
                            left join Users as u on u.ID = a.UserID
                            where u.IDCardNumber = @clientIDCard and c.isvalid = 1";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@clientIDCard", SqlDbType.NVarChar).Value = clientIDCard;
                    return Convert.ToInt32(command.ExecuteScalar().ToString());


                }
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during connecting \n {e.Message}");
                return -1;
            }
        }

    }
}
