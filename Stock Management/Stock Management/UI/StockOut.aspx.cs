using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Management.UI
{
    using System.Data;

    using Stock_Management.Logic_Layer;
    using Stock_Management.Models;

    public partial class StockOut : System.Web.UI.Page
    {
        ItemSetupManager aItemSetupManager = new ItemSetupManager();
        CompanyManager aCompanyManager = new CompanyManager();
        Inventory aInventory =new Inventory();
        InventoryManager aInventoryManager = new InventoryManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetAllCompany();

            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            this.aInventory.CompanyId = Convert.ToInt32(this.companyDropDownList.SelectedValue);
            this.aInventory.CompanyName = this.companyDropDownList.SelectedItem.Text;
            this.aInventory.ItemId = Convert.ToInt32(this.itemDropDownList.SelectedValue);
            this.aInventory.ItemName = this.itemDropDownList.SelectedItem.Text;
            this.aInventory.StockOut = Convert.ToInt32(this.stockoutTextBox.Text);
            this.aInventory.date = Convert.ToDateTime(System.DateTime.Today.ToString("dd/MM/yy"));  
            int itemId = Convert.ToInt32(this.itemDropDownList.SelectedValue);
            Item aItem = this.aItemSetupManager.GetReOrderAndQuantiti(itemId);

            if (aItem.AvaiableQuantity>this.aInventory.StockOut)
            {
                this.msgLabel.Text = this.aInventoryManager.SaveStockOut(this.aInventory);
                ShowReport();
            }
            else
            {
                this.msgLabel.Text = "Product Out of stock !!!!!!";
            }
           
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
        public void ShowReport()
        {
            List<Inventory> inventories = this.aInventoryManager.GetReport();
            this.stockOutGridView.DataSource = inventories;
            this.stockOutGridView.DataBind();
            this.sellButton.Visible = true;
            this.damageButton.Visible = true;
            this.lostButton.Visible = true;
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            String type = "Sell";
            List<Inventory> inventoryList = this.aInventoryManager.GetReport();
            foreach (Inventory Inventory in inventoryList)
            {
                this.aInventoryManager.SaveStockOutQuantity(Inventory, type);
            }
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            this.aInventoryManager.DeleteStockOutTable();
            
            Response.Redirect("StockOut.aspx");
           
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            String type = "Damage";
            List<Inventory> inventoryList = this.aInventoryManager.GetReport();
            foreach (Inventory Inventory in inventoryList)
            {
                this.aInventoryManager.SaveStockOutQuantity(Inventory, type);
            }
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            this.aInventoryManager.DeleteStockOutTable();

            Response.Redirect("StockOut.aspx");
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            String type = "Lost";
            List<Inventory> inventoryList = this.aInventoryManager.GetReport();
            foreach (Inventory Inventory in inventoryList)
            {
                this.aInventoryManager.SaveStockOutQuantity(Inventory, type);
            }
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            this.aInventoryManager.DeleteStockOutTable();

            Response.Redirect("StockOut.aspx");
        }
        public void clearField()
        {
            
            this.companyDropDownList.SelectedIndex = 0;
            this.itemDropDownList.SelectedIndex = 0;
            this.reorderTextBox.Text = string.Empty;
            this.quantityTextBox.Text = string.Empty;
            this.stockoutTextBox.Text = string.Empty;
        }
    }
}