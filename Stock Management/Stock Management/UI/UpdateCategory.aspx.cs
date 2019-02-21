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

    public partial class UpdateCategory : System.Web.UI.Page
    {
         int id;
        CategoryManager aCategoryManager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
          id = Convert.ToInt32(Request.QueryString["Category_id"].ToString());
            if (!IsPostBack)
            {
                ShowDataTextBox();
            }
          
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = companyNameEditTextBox.Text;
            string msg = this.aCategoryManager.Update(category,this.id);
            Response.Redirect("CategorySetup.aspx");
        }



        public void ShowDataTextBox()
        {
            Category category = aCategoryManager.GetCategoryById(this.id);
            if (category != null)
            {
                companyNameEditTextBox.Text = category.CategoryName;               
            }
            else
            {

                companyNameEditTextBox.Text = String.Empty;         
               this.msgLabel.Text = "Category not Found";
            }
        }
    }
}