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
    public class AccountRepository 
    {
       

        public decimal GetBalanceByClientIdCard(string clientIdCard)
        {
            string query = @" select top 1 a.Balance 
                              from Accounts as a
                              left join Users as u on u.ID=a.UserID
                              where u.IDCardNumber=@clientIDCard";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@clientIDCard", SqlDbType.NVarChar).Value = clientIdCard;

                        return Convert.ToDecimal(command.ExecuteScalar());



                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error happend during query \n {ex.Message}");
                        return 0;
                    }


                }
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during connecting \n {e.Message}");
                return 0;
            }


        }

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

        public void CreateNewAccount(AccountsModel acc)
        {
            string query = @"insert into Accounts 
                             values (@IBAN,@Balance,@DebtLimit,@UserID,getdate())";

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
        
        public DataSet FillDataSet()
        {
            string query = @"select a.IBAN,a.Balance,a.DebtLimit,u.LastName,u.FirstName
                             from Accounts as a
                             left join Users as u on a.UserID = u.ID";
            DataSet ds = new DataSet();

            SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.Fill(ds, "AccountsWithNames");



            return ds;
        }

        public DataSet FilterDataAccounts(string filter, string filterWord)
        {
            string query = $@"select a.IBAN,a.Balance,a.DebtLimit,u.LastName,u.FirstName
                             from Accounts as a
                             left join Users as u on a.UserID = u.ID
							 where {filter} like @filterWord";

            filterWord = $"%{filterWord}%";        
            DataSet ds = new DataSet();

            SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@filterWord", SqlDbType.NVarChar).Value = filterWord;


            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(ds, "FilteredAccountsWithNames");



            return ds;
        }

        public string GetIbanByID(int id)
        {
            string query = @" select IBAN from Accounts where id=@id";
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                    return command.ExecuteScalar().ToString();


                }
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during connecting \n {e.Message}");
                return null;
            }
        }

        public void CloseAccount(string cardNumber)
        {
            string query = @"Update accounts 
                             set closeDate = getDate()
                             where IBAN=(select IBAN from Accounts as a
                             left join Users as u on u.ID= a .UserID where u.IDCardNumber=@cardNumber)";

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
                            command.Parameters.Add("@cardNumber", SqlDbType.VarChar).Value =cardNumber;
                        
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

        public void UpdateAccount(AccountsModel account)
        {
            string query = @"update Accounts
                             set DebtLimit=@debtLimit
                             where IBAN= @iban";

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
                            command.Parameters.Add("@iban", SqlDbType.NVarChar).Value = account.IBAN;
                            command.Parameters.Add("@debtLimit", SqlDbType.Money).Value = account.DebtLimit;

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

        public string GetUserCardIdbyIban(string iban)
        {
            string query = @"select top 1 u.IDCardNumber 
                            from Users  as u
                            left join Accounts as a on a.UserID=u.ID
                            where a.IBAN=@Iban";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@Iban", SqlDbType.NVarChar).Value = iban;
                    return command.ExecuteScalar().ToString();


                }
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during connecting \n {e.Message}");
                return null;
            }

        }
    }
}
