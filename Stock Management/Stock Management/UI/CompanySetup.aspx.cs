using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Management.UI
{
    using Stock_Management.Logic_Layer;
    using Stock_Management.Models;

    public partial class CompanySetup : System.Web.UI.Page
    {
        CompanyManager aCompanyManager= new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAllCompanies();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company aCompany = new Company();
            aCompany.CompanyName = this.companyNameTextBox.Text;
            this.msgLabel.Text = this.aCompanyManager.SaveCompany(aCompany);
            this.companyNameTextBox.Text = string.Empty;
            ShowAllCompanies();
        }

        public void ShowAllCompanies()
        {
            List<Company> categories = this.aCompanyManager.GetAllCompany();
            this.ShowCompanyView.DataSource = categories;
            this.ShowCompanyView.DataBind();
        }
    }
}