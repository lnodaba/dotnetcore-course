using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Trailers.MVC.Models;

namespace Trailers.MVC.DAL
{
    public class CompaniesDAL
    {
        private string _connectionString = "Server=NODA;Database=AwesomeProject;User Id=AwesomeUser;Password=123qwe;";

        public bool AddCompany(Company company)
        {
            string commandText =
                $"INSERT INTO [dbo].[Companies]([Name], [Contact], [Location])" +
                $"VALUES ('{company.Name}', '{company.Contact}', '{company.Country}')";

            int result = runQuery(company, commandText);

            return result == 1 
                ? true : false;
        }

        public bool RemoveCompany(Company company)
        {
            string commandText =
               $"DELETE FROM[dbo].[Companies] WHERE[Name] = '{company.Name}'";

            int result = runQuery(company, commandText);

            return result >= 0
                ? true : false;
        }

        private int runQuery(Company company,string commandText)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();

            return result;
        }
    }
}
