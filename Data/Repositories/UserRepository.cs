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
    public class UserRepository : IRepositories
    {
        private int _lastID;

        public int CreateUser(UserModel user, AddressRepository addressRep, AddressModel addressMod)
        {
            string query = @"insert into [dbo].[Users] values (@FirstName,@LastName,@IDCard,@PhoneNumber,@Email,@IDAddress)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
                        command.Parameters.Add("@IDCard", SqlDbType.VarChar).Value = user.IDCardName;
                        command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = user.PhoneNumber;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                        command.Parameters.Add("@IDAddress", SqlDbType.Int).Value = addressRep.CreateAddress(addressMod);
                        
                        if (command.ExecuteNonQuery() > 0)
                        {
                            using (SqlCommand command2 = connection.CreateCommand())
                            {
                                command2.CommandText = "Select @@Identity from Addreses";
                                _lastID= Convert.ToInt32(command2.ExecuteScalar());
                                return _lastID;

                            }
                        }
                        return 0;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error ocured while quering " + ex.Message);
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error ocured while connecting " + e.Message);
                return 0;
            }

        }

        public int GetLastID()
        {
            return _lastID;
        }
    }
}
