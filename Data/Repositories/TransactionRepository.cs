using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Data.Repositories
{/// <summary>
/// class to work with transaction model 
/// </summary>
    public class TransactionRepository 
    {
        /// <summary>
        /// reads all transactions from database and saves them to IEnumerable 
        /// then returns it
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TransactionModel> GetTransactions()  {
            List<TransactionModel> transactions = new List<TransactionModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("select * from transactions", connection);


                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                TransactionModel transaction = new TransactionModel();
                                transaction.ID = reader.GetInt32(0);
                                transaction.IDFrom = reader.GetInt32(1).ToString();
                                transaction.IDTo = reader.GetInt32(2).ToString();
                                transaction.Date = reader.GetDateTime(3);
                                transaction.Value = reader.GetDecimal(4);
                                transaction.Type = reader.GetString(5);
                                transaction.VariableSymbol = reader.IsDBNull(6) ? "" : reader.GetString(6);
                                transaction.SpecificSymbol = reader.IsDBNull(7) ? "" : reader.GetString(7);
                                transaction.ConstantSymbol = reader.IsDBNull(8) ? "" : reader.GetString(8);
                                transaction.Message = reader.IsDBNull(9) ? "" : reader.GetString(9);

                                transactions.Add(transaction);

                            }


                        }
                        return transactions;
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
        /// saves Withdraw transaction 
        /// </summary>
        /// <param name="idFrom"></param>
        /// <param name="value"></param>
        public void SaveTransactionWithdraw(int idFrom, decimal value)
        {
            string query = @"insert into [dbo].[Transactions] 
                             values (@idFrom,@idFrom,GETDATE(),@value,'Withdraw',null,null,null,null);

                             update Accounts
                             set Balance=Balance-@value
                             where Accounts.ID=@idFrom";
     
            try
            {

                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@idFrom", SqlDbType.NVarChar).Value = idFrom;                   
                        command.Parameters.Add("@Value", SqlDbType.Money).Value = value;
                  
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
         
        /// <summary>
        /// Overloading method for situation when we dont know uses ID
        /// but we know his IDCard NUmber
        /// </summary>
        /// <param name="idFrom"></param>
        /// <param name="value"></param>
        public void SaveTransactionWithdraw(string clientIDCard, decimal value)
        {
       string query = @"insert into [dbo].[Transactions] 
                        values ((select top 1 a.ID
                        from Accounts as a
                        left join Users as u on a.UserID=u.ID
                        where u.IDCardNumber=@clientIdCard)
                        ,(select top 1 a.ID
                        from Accounts as a
                        left join Users as u on a.UserID=u.ID
                        where u.IDCardNumber=@clientIdCard)
                        ,GETDATE(),@value,'Withdraw',null,null,null,null)

                        update Accounts
                        set Balance=Balance-@value
                        where Accounts.ID=(select top 1 a.ID
                        from Accounts as a
                        left join Users as u on a.UserID=u.ID
                        where u.IDCardNumber=@clientIdCard)";

            try
            {

                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@clientIdCard", SqlDbType.NVarChar).Value = clientIDCard;
                        command.Parameters.Add("@value", SqlDbType.Money).Value = value;

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

        /// <summary>
        /// makes regular transaction between two accoounts
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="IDfrom"></param>
        /// <param name="idTo"></param>
        public void SaveRegularTransaction(TransactionModel transaction,string IDfrom ,string idTo)
        {
            string query = @" insert into [dbo].[Transactions]
                              values ( (select top 1 a.ID
                              from Accounts as a
                              left join Users as u on a.UserID=u.ID
                              where u.IDCardNumber= @idFrom),( select id from Accounts where IBAN = @idTo),
                                    GETDATE(),@value,@transactionType,@VS,@SS,@CS,@message)

                              update Accounts 
                              set Balance = Balance+@value 
                              where ID=( select id from Accounts where IBAN = @idTo)

                              update Accounts
                              set Balance= Balance-@value
                              where ID=(select top 1 a.ID
                              from Accounts as a
                              left join Users as u on a.UserID=u.ID
                              where u.IDCardNumber= @idFrom)";



            try
            {

                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@idFrom", SqlDbType.NVarChar).Value = IDfrom;
                        command.Parameters.Add("@idTo", SqlDbType.NVarChar).Value = idTo;
                        command.Parameters.Add("@value", SqlDbType.Money).Value = transaction.Value;
                        command.Parameters.Add("@transactionType", SqlDbType.NVarChar).Value = transaction.Type;
                        command.Parameters.Add("@VS", SqlDbType.NVarChar).Value = transaction.VariableSymbol;
                        command.Parameters.Add("@SS", SqlDbType.NVarChar).Value = transaction.SpecificSymbol;
                        command.Parameters.Add("@CS", SqlDbType.NVarChar).Value = transaction.ConstantSymbol;
                        command.Parameters.Add("@message", SqlDbType.NVarChar).Value = transaction.Message;
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
        
        /// <summary>
        /// returns all transaction by a single user based on his ID card
        /// </summary>
        /// <param name="clientIdCard"></param>
        /// <returns></returns>
        public IEnumerable<TransactionModel> GetTransactionsByIDCard (string clientIdCard)
        {
            List<TransactionModel> transactions = new List<TransactionModel>();
            string query = @"select t.*
                             from(Transactions as t
                             left join Accounts as a on t.IDFrom = a.ID or t.IDTo = a.ID)
                             left join Users as u on a.UserID = u.ID
                             where u.IDCardNumber = @clientIdCard";
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@clientIdCard", SqlDbType.NVarChar).Value = clientIdCard;

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                TransactionModel transaction = new TransactionModel();
                                transaction.ID = reader.GetInt32(0);
                                transaction.IDFrom = reader.GetInt32(1).ToString();
                                transaction.IDTo = reader.GetInt32(2).ToString();
                                transaction.Date = reader.GetDateTime(3);
                                transaction.Value = reader.GetDecimal(4);
                                transaction.Type = reader.GetString(5);
                                transaction.VariableSymbol = reader.IsDBNull(6) ? "" : reader.GetString(6);
                                transaction.SpecificSymbol = reader.IsDBNull(7) ? "" : reader.GetString(7);
                                transaction.ConstantSymbol = reader.IsDBNull(8) ? "" : reader.GetString(8);
                                transaction.Message = reader.IsDBNull(9) ? "" : reader.GetString(9);

                                transactions.Add(transaction);

                            }


                        }
                        return transactions;
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
        /// makes deposit transaction
        /// insert new transaction into transactions in database
        /// and update the accounts 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="IDfrom"></param>
        public void SaveTransactionDeposit(decimal value, string IDfrom)
        {
            string query = @" insert into[dbo].[Transactions]
                              values((select top 1 a.ID
                              from Accounts as a
                              left join Users as u on a.UserID= u.ID
                              where u.IDCardNumber= @IDfrom),(select top 1 a.ID
                              from Accounts as a
                              left join Users as u on a.UserID=u.ID
                              where u.IDCardNumber= @IDfrom),getdate(),@value,'Deposit',null,null,null,null);

                              update Accounts 
                              set Balance= Balance+@value
                              where Accounts.ID=(select top 1 a.ID 
                              from Accounts as a
                              left join Users as u on a.UserID=u.ID
                              where  u.IDCardNumber= @IDfrom )";
            Debug.WriteLine(value, IDfrom);


            try
            {

                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@IDfrom", SqlDbType.NVarChar).Value = IDfrom;                      
                        command.Parameters.Add("@value", SqlDbType.Money).Value = value;
               
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

       


    }


}
