using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AccountRepository : IRepositories
    {
        public AccountsModel GetAccountsByCard(string cardNumber)
        {
            string query = @"select a.*
                            from[dbo].[Accounts] as a
                            left join[dbo].[Cards] as c on c.Account_ID=a.ID
                            where c.CardNumber=@cardNumber";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@cardNumber", SqlDbType.NVarChar).Value = cardNumber;

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                AccountsModel ac = new AccountsModel
                                {
                                    ID = reader.GetInt32(0),
                                    IBAN = reader.GetString(1),
                                    Balance = reader.GetDecimal(2),
                                    DebtLimit = reader.GetDecimal(3),
                                    UserID = reader.GetInt32(4)
                                };
                                
                                return ac;
                            }
                            else
                            {
                                return null;
                            }
                        }

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
      
        public string GetAccountOwnerName(string cardNumber)
        {
            string query = @"select (u.FirstName+' '+u.LastName) as FullName
                        from (Users as u
                        left join Accounts as a on u.ID=a.UserID)
                        left join Cards as c on a.ID=c.Account_ID
                        where c.CardNumber = @CardNumber";
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@cardNumber", SqlDbType.NVarChar).Value = cardNumber;
                    return command.ExecuteScalar().ToString();          


                }
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during connecting \n {e.Message}");
                return null;
            }
        }

        public int SelectAccountIDByCard(string cardNumber)
        {
            string query = @"select  a.ID 
                            from[dbo].[Accounts] as a
                            left join Cards as c on c.[Account_ID] = a.ID
                            where c.CardNumber = @cardNumber";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@cardNumber", SqlDbType.NVarChar).Value = cardNumber;
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during connecting \n {e.Message}");
                return 0;
            }

        }

        public void MakeWithdraw(string cardNumber,decimal value)
        {
            string query = @"update accounts 
                             set Balance = Balance - @Value
                             where ID = @AccountID";

            try
            {

                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@Value", SqlDbType.Int).Value = value;
                        command.Parameters.Add("@AccountID", SqlDbType.Int).Value = SelectAccountIDByCard(cardNumber);
   

                        command.ExecuteNonQuery();
                       

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error ocured while quering " + ex.Message);

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error ocured while connecting " + e.Message);

            }
        }

        public void CreateNewAccount(AccountsModel acc)
        {
            string query = @"insert into Accounts 
                             values (@IBAN,@Balance,@DebtLimit,@UserID)";

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
                            command.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = acc.IBAN;
                            command.Parameters.Add("@Balance", SqlDbType.Int).Value = acc.Balance;
                            command.Parameters.Add("@DebtLimit", SqlDbType.VarChar).Value = acc.DebtLimit;
                            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = acc.UserID;
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
    }
}
