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

    public partial class ItemSetup : System.Web.UI.Page
    {
        ItemSetupManager aItemSetupManager =new ItemSetupManager();
        CategoryManager aCategoryManager =new CategoryManager();
        CompanyManager aCompanyManager  =new CompanyManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetAllcategory();
                //GetAllCompany();
                GetAllCompanyAndCategory();
                this.reorderTextBox.Text = 0.ToString();
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            Item aItem = new Item();            
            aItem.CategoryId = Convert.ToInt32(this.categoryDropDownList.SelectedValue);
            aItem.CompanyId = Convert.ToInt32(this.companyDropDownList.SelectedValue);
            aItem.ItemName = this.itemNameTextBox.Text;
            aItem.ReOrder = Convert.ToInt32(this.reorderTextBox.Text);
            aItem.AvaiableQuantity = 0;
            this.msgLabel.Text = this.aItemSetupManager.SaveItem(aItem);
            ClearField();
        }
        public void GetAllcategory()
        {
            List<Category> categories = this.aCategoryManager.GetAllCategories();
            this.categoryDropDownList.DataSource = categories;
            this.categoryDropDownList.DataTextField = "CategoryName";
            this.categoryDropDownList.DataValueField = "CategoryId";
            this.categoryDropDownList.DataBind();
        }
        public void GetAllCompany()
        {
            List<Company> Companies = this.aCompanyManager.GetAllCompany();
            this.companyDropDownList.DataSource = Companies;
            this.companyDropDownList.DataTextField = "CompanyName";
            this.companyDropDownList.DataValueField = "CompanyId";
            this.companyDropDownList.DataBind();
        }
        public void GetAllCompanyAndCategory()
        {
           
            List<Company> Companies = this.aCompanyManager.GetAllCompany();
            this.companyDropDownList.DataSource = Companies;
            this.companyDropDownList.DataTextField = "CompanyName";
            this.companyDropDownList.DataValueField = "CompanyId";
            this.companyDropDownList.DataBind();
            this.companyDropDownList.Items.Insert(0, "--Select company--");
            List<Category> categories = this.aCategoryManager.GetAllCategories();
            this.categoryDropDownList.DataSource = categories;
            this.categoryDropDownList.DataTextField = "CategoryName";
            this.categoryDropDownList.DataValueField = "CategoryId";
            this.categoryDropDownList.DataBind();
            this.categoryDropDownList.Items.Insert(0, "--Select Category--");
        }

        public void ClearField()
        {
            this.companyDropDownList.SelectedIndex = 0;
            this.categoryDropDownList.SelectedIndex = 0;
            this.itemNameTextBox.Text = string.Empty;
            this.reorderTextBox.Text = 0.ToString();
        }
    }
}