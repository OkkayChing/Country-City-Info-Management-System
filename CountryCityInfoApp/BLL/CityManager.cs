using CountryCityInfoApp.DAL;
using CountryCityInfoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryCityInfoApp.BLL
{

    public class CityManager
    {
        CityGateway citygateway = new CityGateway();
        CountryListGateway countrylistgateway = new CountryListGateway();
       
        
        public string SaveCity(City acity)
        {
            if (!citygateway.IsCityNameAlreadyExists(acity))
            {
                if ((citygateway.SaveCityInfo(acity) > 0))
                {
                    return "City Information Saved Succesfully";

                }
                else
                {
                    return "City Information Saving Failed";
                }
            }
            else
            {
                return "City Name Already Exists";
            }

        }

        public List<DisplayCity> Getcity()
        {
            return citygateway.Getcity();
        }
        public List<CountryList> GetAllCountry()
        {
            return countrylistgateway.GetAllCountry();
        }
        public List<DisplayCityCountry> GetAllCity_CountryByCityName(string cityName)
        {
            return citygateway.GetAllCity_CountryByCityName(cityName);
        }

        public List<DisplayCityCountry> GetAllCity_CountryByCountryName(string countryName)
        {
            return citygateway.GetAllCity_CountryByCountryName(countryName);
        }
        public List<DisplayCityCountry> GetAllCity_Country()
        {
            return citygateway.GetAllCity_ByCountryName();
        }
    }
}