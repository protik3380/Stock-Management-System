using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Logic_Layer
{
    using Stock_Management.Gate_Way;
    using Stock_Management.Models;

    public class CategoryManager
    {
        CategoryGateway aCategoryGateway = new CategoryGateway();
        public bool IsExist(string categoryName)
        {
            return this.aCategoryGateway.IsExist(categoryName);
        }

        public String SaveCategory(Category aCategory)
        {
            if (IsExist(aCategory.CategoryName))
            {
                return "Category is Already Exist.";
            }
            int row = this.aCategoryGateway.SaveCategory(aCategory);
            if (row > 0)
            {
                return "Saved";
            }
            else
            {
                return "Failed";
            }
        }
        public List<Category> GetAllCategories()
        {
            return this.aCategoryGateway.GetAllCategories();
        }
        public Category GetCategoryById(int id)
        {
            return this.aCategoryGateway.GetCategoryById(id);
        }
        public string Update(Category category,int id)
        {
            if (this.aCategoryGateway.Update(category,id) > 0)
            {
                return "data Updated sucessfully";
            }
            return "Not Updated";
        }
    }
}