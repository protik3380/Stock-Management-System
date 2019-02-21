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

    public partial class StockIn : System.Web.UI.Page
    {
        ItemSetupManager aItemSetupManager = new ItemSetupManager();       
        CompanyManager aCompanyManager = new CompanyManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                GetAllCompany();
             
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            int stockIn = Convert.ToInt32(this.stockInTextBox.Text);
            int itemId = Convert.ToInt32(this.itemDropDownList.SelectedValue);
            this.msgLabel.Text = this.aItemSetupManager.UpdateAvailableQuantity(stockIn, itemId);
            clearField();

        }
        public void GetAllCompany()
        {
            List<Company> Companies = this.aCompanyManager.GetAllCompany();
            this.companyDropDownList.DataSource = Companies;
            this.companyDropDownList.DataTextField = "CompanyName";
            this.companyDropDownList.DataValueField = "CompanyId";
            this.companyDropDownList.DataBind();
            this.companyDropDownList.Items.Insert(0, "--Select Company--");
        }
        
        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(this.companyDropDownList.SelectedValue);
            List<Item> aItems = this.aItemSetupManager.GetAllItemsByCompanyId(companyId);
            this.itemDropDownList.DataSource = aItems;
            this.itemDropDownList.DataTextField = "ItemName";
            this.itemDropDownList.DataValueField = "ItemId";
            this.itemDropDownList.DataBind();
            this.itemDropDownList.Items.Insert(0, "--Select items--");
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(this.itemDropDownList.SelectedValue);
            Item aItem = this.aItemSetupManager.GetReOrderAndQuantiti(itemId);
            this.reorderTextBox.Text = aItem.ReOrder.ToString();
            this.quantityTextBox.Text = aItem.AvaiableQuantity.ToString();
        }

        public void clearField()
        {
            this.companyDropDownList.SelectedIndex = 0;
            this.itemDropDownList.SelectedIndex = 0;
            this.reorderTextBox.Text = string.Empty;
            this.quantityTextBox.Text = string.Empty;
            this.stockInTextBox.Text = string.Empty;
        }
        
    }
}