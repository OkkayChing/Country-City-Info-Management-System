using CountryCityInfoApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CountryCityInfoApp.DAL
{
    public class CountryListGateway
    {
        SqlConnection connection = new SqlConnection();
        string connectionString = WebConfigurationManager.ConnectionStrings["CountryCityConnection"].ConnectionString;
                
        public List<CountryList> GetAllCountry()
        {
            string query = "SELECT * FROM Countries";

            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<CountryList> countryList = new List<CountryList>();

            while (reader.Read())
            {
                CountryList aCountryList = new CountryList();
                aCountryList.Id = (int)reader["Id"];
                aCountryList.Name = reader["Name"].ToString();
                countryList.Add(aCountryList);
            }
            reader.Close();
            connection.Close();

            return countryList;
        }

    }
}