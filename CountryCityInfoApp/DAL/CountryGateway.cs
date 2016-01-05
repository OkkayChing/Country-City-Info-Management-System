using CountryCityInfoApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CountryCityInfoApp.DAL
{
    public class CountryGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CountryCityConnection"].ConnectionString;
        public int SaveCountryInfo(Country aCountry)
        {
            string query = "INSERT INTO Countries(Name,About) VALUES('" + aCountry.Name + "','" + aCountry.About + "')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
            
        }

        public bool IsCountryNameAlreadyExists(Country acountry)
        {
            bool isCountryNameAlreadyExists = false;
            string query = string.Format("Select * From Countries Where Name='{0}'", acountry.Name);
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                isCountryNameAlreadyExists = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isCountryNameAlreadyExists;

        }

        public List<Country> GetAllCountry()
        {
           
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("SELECT * FROM Countries");
            
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
          
            SqlDataReader reader = command.ExecuteReader();
            List<Country> countryList = new List<Country>();
           
            while (reader.Read())
            {
                Country aCountries = new Country();
              
                aCountries.Name = reader["Name"].ToString();
                aCountries.About = reader["About"].ToString();
                countryList.Add(aCountries);
             
            }
            reader.Close();
            connection.Close();
            return countryList;

        }
        public List<CountryInfo> GetCountryInfo()
        {
            List<CountryInfo> countryList = new List<CountryInfo>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select Countries.Name, Countries.About, Count(Cities.Name) as Number_OF_City, SUM(Cities.No_Of_Dwellers) as No_OF_Dwellers FROM Countries INNER JOIN Cities ON Countries.Id=Cities.CountryId GROUP BY Countries.Name");
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
         
            while (reader.Read())
            {
                CountryInfo countryInfo = new CountryInfo();
                countryInfo.CountryName = reader["Name"].ToString();
                countryInfo.About = reader["About"].ToString();
                countryInfo.No_OF_City = Convert.ToInt32(reader["Number_OF_City"]);
                countryInfo.No_of_Dwellers = Convert.ToInt32(reader["No_OF_Dwellers"]);
                countryList.Add(countryInfo);
             }
            reader.Close();
            connection.Close();
            return countryList;

        }
        public List<CountryInfo> GetCountryInfoByCountryName(string countryName)
        {
            List<CountryInfo> countryList = new List<CountryInfo>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format(@"Select Countries.Name, Countries.About," +
                                         " Count(Cities.Name) as Number_OF_City, SUM(Cities.No_OF_Dwellers) as No_OF_Dwellers " +
                                         "FROM Countries INNER JOIN Cities ON" +
                                         " Countries.Id=Cities.CountryId " +
                                         "Where Countries.Name like '%{0}%'  GROUP BY Countries.Name");
         
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CountryInfo countryInfo = new CountryInfo();
                countryInfo.CountryName = reader["Name"].ToString();
                countryInfo.About = reader["About"].ToString();
                countryInfo.No_OF_City = Convert.ToInt32(reader["Number_OF_City"]);
                countryInfo.No_of_Dwellers = Convert.ToInt32(reader["No_OF_Dwellers"]);
                countryList.Add(countryInfo);
               
            }
            reader.Close();
            connection.Close();
            return countryList;

        }
    }
}