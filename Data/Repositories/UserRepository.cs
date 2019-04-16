using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Data.Repositories
{
    public class UserRepository {
        /// <summary>
        /// saves Last ID
        /// used to save to database
        /// </summary>
        private int _lastID;

        /// <summary>
        /// Create new User and saves it to the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="addressRep"></param>
        /// <param name="addressMod"></param>
        /// <returns></returns>
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
                                _lastID = Convert.ToInt32(command2.ExecuteScalar());
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

        /// <summary>
        /// send last used ID to the Logic
        /// </summary>
        /// <returns></returns>
        public int GetLastID()
        {
            return _lastID;
        }

        /// <summary>
        /// returns User list filtered by IDcard
        /// </summary>
        /// <param name="filterBy"></param>
        /// <returns></returns>
        public  IEnumerable<UserModel> GetUsersByIDCardList (string filterBy)
            {
            string query = @"select distinct u.* 
                             from users as u 
                             left join Accounts as a on u.ID=a.UserID
                             where u.IDCardNumber like @filter and isnull(a.CloseDate,'1900-05-05')='1900-05-05'";

            filterBy = $"%{filterBy}%";
            List<UserModel> filteredUsers = new List<UserModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@filter", SqlDbType.NVarChar).Value = filterBy;


                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                UserModel user = new UserModel();
                                user.ID = reader.GetInt32(0);
                                user.FirstName = reader.GetString(1);
                                user.LastName = reader.GetString(2);
                                user.IDCardName = reader.GetString(3);
                                user.PhoneNumber = reader.GetString(4);
                                user.Email = reader.GetString(5);
                                user.AddressID = reader.GetInt32(6);


                                filteredUsers.Add(user);
                               

                            }


                        }
                        return filteredUsers ;
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
        /// Loads data from database about user his address and account and sends them to the app
        /// for upadate purposes
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        public string[] GetDataForUpdate (string idCard)
        {
            string query = @"select top 1 u.*,ad.*,a.IBAN,a.DebtLimit
                            from (Users as u 
                            left join Addreses as ad on ad.ID=u.AddressID)
                            left join Accounts as a on a.UserID=u.ID
                            where u.IDCardNumber=@clientIdcard";

            string[] returnField = new string[20];

            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@clientIdcard", SqlDbType.NVarChar).Value = idCard;

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                
                                for (int i = 0; i < 14; i++)
                                {
                                    returnField[i] = reader.GetValue(i).ToString();
                                }                               
                              

                            }
                            return returnField;
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

        /// <summary>
        /// get usermodel from app and saves it to the database
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(UserModel user)
        {
            string query = @"update Users
                             set FirstName= @firstName, LastName=@lastName,IDCardNumber=@idCardNumber,
                             PhoneNumber=@phoneNumber,Email=@email
                             where ID = @ID";
            try
            {
                using (SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = user.ID;
                        command.Parameters.Add("@firstName", SqlDbType.VarChar).Value = user.FirstName;
                        command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = user.LastName;
                        command.Parameters.Add("@idCardNumber", SqlDbType.VarChar).Value = user.IDCardName;
                        command.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = user.PhoneNumber;
                        command.Parameters.Add("@email", SqlDbType.NVarChar).Value = user.Email;

                        command.ExecuteNonQuery();

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
