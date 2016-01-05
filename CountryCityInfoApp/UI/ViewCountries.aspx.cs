using CountryCityInfoApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountryCityInfoApp.UI
{
    public partial class ViewCountries : System.Web.UI.Page
    {
        CountryManager countryManager = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            PopulateGridview();
        }

        public void PopulateGridview()
        {
            showGridView.DataSource = countryManager.GetCountryInfo();
            showGridView.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (countryNameTextBox.Text == "")
            {
                messageLabel.Text="Please enter values";
            }
            else
            {
                string countryName = countryNameTextBox.Text;
                showGridView.DataSource = countryManager.GetCountryInfoByCountryName(countryName);
                showGridView.DataBind();
                countryNameTextBox.Text = "";
            }
        }

        protected void showGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            showGridView.PageIndex = e.NewPageIndex;
            PopulateGridview();
        }
    }
}