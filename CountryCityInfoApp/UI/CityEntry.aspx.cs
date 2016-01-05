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

    public partial class CityEntry : System.Web.UI.Page
    {
        CityManager citymanager = new CityManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountryComboBox();
              
            }
            
        }

       

        private void LoadCountryComboBox()
        {
            List<CountryList> countryList = citymanager.GetAllCountry();

            countryDropDownList.DataSource = countryList;
            countryDropDownList.DataTextField = "Name";
            countryDropDownList.DataValueField = "Id";
            countryDropDownList.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "" || noOfDwellersTextBox.Text == "" ||
                locationTextBox.Text == ""
                || weatherTextBox.Text == "")
            {
                showLabel.Text = "Please fill all fields";
            }
            else
            {
                int selectedCountryListtId = Convert.ToInt32(countryDropDownList.SelectedValue);

                if (selectedCountryListtId == -1)
                {
                    showLabel.Text = "Please select a department to save a City!";
                    return;
                }

                City acity = new City();
                acity.Name = nameTextBox.Text;
                acity.About = Request.Form["edit"];
                acity.No_Of_Dwellers = Convert.ToInt32(noOfDwellersTextBox.Text);
                acity.Location = locationTextBox.Text;
                acity.Weather = weatherTextBox.Text;
                // acity.Country = countryDropDownList.Text;
                acity.CountryId = selectedCountryListtId;

                showLabel.Text = citymanager.SaveCity(acity);
              

            }
            LoadCityGridView();
        }
        public void LoadCityGridView()
        {
            cityShowGridView.DataSource = citymanager.Getcity();
            cityShowGridView.DataBind();
        }

        

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
         

        public void Clear()
        {
            //nameTextBox.Text = "";
            //noOfDwellersTextBox.Text = "";
            //locationTextBox.Text = "";
            //weatherTextBox.Text = "";
            Response.Redirect("../UI/Index.aspx");
        }
    }
}