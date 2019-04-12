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
    public class TransactionRepository : IRepositories
    {
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
                                transaction.IDFrom = reader.GetInt32(1);
                                transaction.IDTo = reader.GetInt32(2);
                                transaction.Date = reader.GetDateTime(3);
                                transaction.Value = reader.GetDecimal(4);
                                transaction.Type = reader.GetString(5);

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

        public void SaveTransaction(TransactionModel transaction)
        {
            string query = @"insert into [dbo].[Transactions] values (@idFrom,@idTO,GETDATE(),@Value,@Type)";
     
            try
            {

                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@idFrom", SqlDbType.Int).Value = transaction.IDFrom;
                        command.Parameters.Add("@idTo", SqlDbType.Int).Value = transaction.IDTo;
                        command.Parameters.Add("@Value", SqlDbType.Money).Value = transaction.Value;
                        command.Parameters.Add("@Type", SqlDbType.NVarChar).Value = transaction.Type;
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
