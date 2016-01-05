using CountryCityInfoApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CountryCityInfoApp.DAL
{
    public class CityGateway
    {
        SqlConnection connection = new SqlConnection();
        string connectionString =
                WebConfigurationManager.ConnectionStrings["CountryCityConnection"].ConnectionString;
        public int SaveCityInfo(City aCity)
        {
            string query = "INSERT INTO Cities(Name,About,No_Of_Dwellers,Location,Weather,CountryId) VALUES('" + aCity.Name + "','" + aCity.About + "','" + aCity.No_Of_Dwellers + "','" + aCity.Location + "','" + aCity.Weather + "','" + aCity.CountryId + "')";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
       }
        public bool IsCityNameAlreadyExists(City acity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            bool isCountryNameAlreadyExists = false;
            string query = string.Format("Select * From Cities Where Name='{0}'", acity.Name);


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
        public List<DisplayCity> Getcity()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("Select Cities.Name,Cities.No_Of_Dwellers,Countries.Name AS Country From Countries INNER JOIN Cities ON Countries.Id=Cities.CountryId ORDER BY Cities.Name");

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<DisplayCity> cities = new List<DisplayCity>();

            while (reader.Read())
            {
                DisplayCity displaycity = new DisplayCity();

                displaycity.CityName = reader["Name"].ToString();
                displaycity.No_Of_Dwellers = int.Parse(reader["No_Of_Dwellers"].ToString());
                displaycity.CountryName = reader["Country"].ToString();
               
                cities.Add(displaycity);
           }
            reader.Close();
            connection.Close();
            return cities;

         }
        public List<DisplayCityCountry> GetAllCity_CountryByCityName(string cityName)
        {
            List<DisplayCityCountry> cityCountryList = new List<DisplayCityCountry>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format(@"Select Cities.Name as CityName,Cities.About," +
                                         "Cities.No_Of_Dwellers,Cities.Location,Cities.Weather," +
                                         "Countries.Name as Country,Countries.About AboutCountry" +
                                         " From Countries INNER JOIN Cities " +
                                         "ON Countries.ID=Cities.CountryId Where Cities.Name like '%{0}%'", cityName);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
          
            while (reader.Read())
            {
                DisplayCityCountry aCity = new DisplayCityCountry();
                aCity.Name = reader["CityName"].ToString();
                aCity.About = reader["About"].ToString();
                aCity.No_Of_Dwellers = Convert.ToInt32(reader["No_Of_Dwellers"]);
                aCity.Location = reader["Location"].ToString();
                aCity.Weather = reader["Weather"].ToString();
                aCity.CountryName = reader["Country"].ToString();
                aCity.AboutCountry = reader["AboutCountry"].ToString();
                cityCountryList.Add(aCity);
               
            }
            reader.Close();
            connection.Close();
            return cityCountryList;


        }
        public List<DisplayCityCountry> GetAllCity_CountryByCountryName(string countryName)
        {
            List<DisplayCityCountry> cityCountryList = new List<DisplayCityCountry>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format(@"Select Cities.Name as CityName,Cities.About," +
                                         "Cities.No_Of_Dwellers,Cities.Location,Cities.Weather," +
                                         "Countries.Name as Country,Countries.About AboutCountry" +
                                         " From Countries INNER JOIN Cities " +
                                         "ON Countries.ID=Cities.CountryId Where Countries.Name='{0}'", countryName);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
           
            while (reader.Read())
            {
                DisplayCityCountry aCity = new DisplayCityCountry();
            
                aCity.Name = reader["CityName"].ToString();
                aCity.About = reader["About"].ToString();
                aCity.No_Of_Dwellers = Convert.ToInt32(reader["No_Of_Dwellers"]);
                aCity.Location = reader["Location"].ToString();
                aCity.Weather = reader["Weather"].ToString();
                aCity.CountryName = reader["Country"].ToString();
                aCity.AboutCountry = reader["AboutCountry"].ToString();
                cityCountryList.Add(aCity);
             }
            reader.Close();
            connection.Close();
            return cityCountryList;

        }

        public List<DisplayCityCountry> GetAllCity_ByCountryName()
        {
            List<DisplayCityCountry> cityCountryList = new List<DisplayCityCountry>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format(@"Select Cities.Name as CityName,Cities.About," +
                                         "Cities.No_Of_Dwellers,Cities.Location,Cities.Weather," +
                                         "Countries.Name as Country,Countries.About AboutCountry" +
                                         " From Countries INNER JOIN Cities " +
                                         "ON Countries.ID=Cities.CountryId ");

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                DisplayCityCountry aCity = new DisplayCityCountry();
              
                aCity.Name = reader["CityName"].ToString();
                aCity.About = reader["About"].ToString();

                aCity.No_Of_Dwellers = Convert.ToInt32(reader["No_of_Dwellers"]);
                aCity.Location = reader["Location"].ToString();
                aCity.Weather = reader["Weather"].ToString();
                aCity.CountryName = reader["Country"].ToString();
                aCity.AboutCountry = reader["AboutCountry"].ToString();
                cityCountryList.Add(aCity);
            
            }
            reader.Close();
            connection.Close();
            return cityCountryList;
        }
    }
}