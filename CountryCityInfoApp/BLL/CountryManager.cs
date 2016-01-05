using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CountryCityInfoApp.DAL;
using CountryCityInfoApp.Model;

namespace CountryCityInfoApp.BLL
{
    public class CountryManager
    {
         CountryGateway countryGateway = new CountryGateway();
         public string SaveCountry(Country acountry)
         {
            if (!countryGateway.IsCountryNameAlreadyExists(acountry))
            {
                if ((countryGateway.SaveCountryInfo(acountry) > 0))
                {
                    return "Country Information Saved Succesfully";

                }
                else
                {
                    return "Country Information Saving Failed";
                }
            }
            else
            {
                return "Country Name Already Exists";
            }

        }

        public List<Country> Getcountries()
        {
            return countryGateway.GetAllCountry();
        }

        public List<CountryInfo> GetCountryInfo()
        {
            return countryGateway.GetCountryInfo();
        }

        public List<CountryInfo> GetCountryInfoByCountryName(string countryName)
        {
            return countryGateway.GetCountryInfoByCountryName(countryName);
        }
    }
}