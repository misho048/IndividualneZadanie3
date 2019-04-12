using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Data.Repositories
{
   public  class AddressRepository :IRepositories
    {
        public int CreateAddress(AddressModel address)
        {
            string query = @"insert into [dbo].[Addreses] values (@StreetName,@HomeNumber,@City,@PostalCode)";

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
                            command.Parameters.Add("@StreetName", SqlDbType.VarChar).Value = address.StreetName;
                            command.Parameters.Add("@HomeNumber", SqlDbType.Int).Value = address.HomeNumber;
                            command.Parameters.Add("@City", SqlDbType.VarChar).Value = address.City;
                            command.Parameters.Add("@PostalCode", SqlDbType.NVarChar).Value = address.PostalCode;

                            if (command.ExecuteNonQuery() > 0)
                            {
                                using (SqlCommand command2 = connection.CreateCommand())
                                {
                                    command2.CommandText = "Select @@Identity from Addreses";
                                    return  Convert.ToInt32(command2.ExecuteScalar());
                                    
                                }
                            }
                            return 0;
                        }
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

    }
}
