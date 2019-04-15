using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ManagerOverview
    {
        /// <summary>
        /// this class is for working with manager overview
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// method returns daaset with top ten clients 
        /// with most money on their account 
        /// </summary>
        /// <returns></returns>
        public DataSet GetTopTenClients()
        {
            string query = @"select top 10 u.LastName,u.FirstName,a.Balance
                             from Users as u
                             left join Accounts as a on a.UserID=u.ID
                             order by a.Balance desc";
            DataSet ds = new DataSet();

            SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.Fill(ds, "TopTenClients");

            return ds;

        }


        /// <summary>
        /// method return dataset with all money bank got
        /// on all its accounts
        /// </summary>
        /// <returns></returns>
       public  DataSet GetBankAssets()
        {
            string query = @"select sum(Balance) as [Bank Assets] from Accounts ";
            DataSet ds = new DataSet();

            SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.Fill(ds, "BankAssets");

            return ds;
        }

        /// <summary>
        /// 
        /// methods returns dataset with number of accounts
        /// </summary>
        /// <returns></returns>
       public DataSet GetAccountsCount()
        {
            string query = @"select count(*) as [Number of Accounts] 
                             from Accounts ";
            DataSet ds = new DataSet();

            SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.Fill(ds, "AccountCount");

            return ds;
        }

        /// <summary>
        /// methods return data set with number of accounts created by
        /// the past 6 months divided by every month
        /// </summary>
        /// <returns></returns>
       public DataSet GetAccountsCountForMonth()
        {
            string query = @"SELECT COUNT (IBAN) AS 'Number of Accounts', DATEPART(YEAR,OpenDate) as 'Year', Format(OpenDate,'MMMM') as 'Month'
                             FROM Accounts
                             WHERE DATEDIFF(MONTH,OpenDate,GETDATE()) < 6
                             GROUP BY DATEPART(YEAR,OpenDate), Format(OpenDate,'MMMM')
                             ORDER BY DATEPART(YEAR,opendate) DESC, Format(OpenDate,'MMMM') DESC";

            DataSet ds = new DataSet();

            SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.Fill(ds, "AccountCountForMonth");

            return ds;
        }


        /// <summary>
        /// methods return dataset with number of active accounts in every city
        /// with name of the city and number of active accounts in this city
        /// </summary>
        /// <returns></returns>
        public DataSet GetDemography()
        {
            string query = @"select top 5 ad.City, count(ad.City) as 'City Count'
                             from (Addreses as ad
                             left join Users as u on u.AddressID = ad.ID )
                             left join Accounts as a on u.ID=a.UserID
                             where   isnull(a.CloseDate,'1900-05-05')='1900-05-05'
                             group by ad.city
                             order by Count(City) desc";

            DataSet ds = new DataSet();

            SqlConnection connection = new SqlConnection(DbCons.CONNECTIONSTRING);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.Fill(ds, "Demography");

            return ds;
        }
    }
}
