using CountryCityInfoApp.BLL;
using CountryCityInfoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountryCityInfoApp.UI
{
    public partial class ViewCities : System.Web.UI.Page
    {
        CityManager citymanager = new CityManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountryComboBox();

            }
           LoadCityGridView();
        }

       
        private void LoadCountryComboBox()
        {
            List<CountryList> countryList = citymanager.GetAllCountry();

            //if (countryList == null)
            //{
            //    countryList = new List<CountryList>();
            //}

            //CountryList defaultCountryList = new CountryList();
            //defaultCountryList.Id = -1;
            //defaultCountryList.Name = "Select...";

            //defaultCountryList.Insert(0, defaultCountryList);

            //countryDropDownList.DataSource = defaultCountryList;
            countryDropDownList.DataSource = countryList;
            countryDropDownList.DataTextField = "Name";
            countryDropDownList.DataValueField = "Id";
            countryDropDownList.DataBind();
        }
        public void PopulateGridViewByCityName()
        {
            if (cityNameTextBox.Text == "")
            {
                messageLabel.Text="Please Enter City name of partial City Name";
            }
            else
            {
                string cityName = cityNameTextBox.Text;
                cityViewGridView.DataSource = citymanager.GetAllCity_CountryByCityName(cityName);
                cityViewGridView.DataBind();

            }

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (cityRadioButton.Checked)
            {
                PopulateGridViewByCityName();
                cityNameTextBox.Text = "";
            }
            else if (countryRadioButton.Checked)
            {
                PopulateGridViewByCountryName();
                cityNameTextBox.Text = "";

            }
        }
        public void PopulateGridViewByCountryName()
        {
            string countryName = countryDropDownList.SelectedItem.Text;
            cityViewGridView.DataSource = citymanager.GetAllCity_CountryByCountryName(countryName);
            cityViewGridView.DataBind();

        }
        public void LoadCityGridView()
        {
            cityViewGridView.DataSource = citymanager.GetAllCity_Country();
            cityViewGridView.DataBind();
        }

        protected void cityViewGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cityViewGridView.PageIndex = e.NewPageIndex;
            LoadCityGridView();
        }

    }
}