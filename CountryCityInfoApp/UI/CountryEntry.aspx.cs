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
    public partial class CountryEntry : System.Web.UI.Page
    {
        Country aCountry = new Country();
        CountryManager countrymanager = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
               showLabel.Text="Please fill the Country Name";
               

            }
            else
            {
                aCountry.Name =nameTextBox.Text;
                aCountry.About = Request.Form["edit"];
                showLabel.Text=countrymanager.SaveCountry(aCountry);  
                LoadGridView();      
            }
         }

        public void LoadGridView()
        {
            {
                countryGridView.DataSource = countrymanager.Getcountries();
                countryGridView.DataBind();
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            //nameTextBox.Text = "";
            Response.Redirect("../UI/Index.aspx");
        }
    }
}