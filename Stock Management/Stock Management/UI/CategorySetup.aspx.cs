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

    public partial class CategorySetup : System.Web.UI.Page
    {
        CategoryManager aCategoryManager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
                ShowAllCategories();
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Category aCategory = new Category();
            aCategory.CategoryName = this.categoryNameTextBox.Text;
            this.msgLavel.Text = this.aCategoryManager.SaveCategory(aCategory);
            this.categoryNameTextBox.Text = string.Empty;            
            ShowAllCategories();

        }

        public void ShowAllCategories()
        {
            List<Category> categories = this.aCategoryManager.GetAllCategories();
            this.ShowCategoryView.DataSource = categories;
            this.ShowCategoryView.DataBind();
        }

        protected void edit_Btn(object sender, EventArgs e)
        {
           int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
           Response.Redirect("UpdateCategory.aspx?category_id="+id);
        }
        




    }
}