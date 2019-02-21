using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Logic_Layer
{
    using Stock_Management.Gate_Way;
    using Stock_Management.Models;

    public class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();
        public bool IsExist(string companyName)
        {
            return this.aCompanyGateway.IsExist(companyName);
        }

        public String SaveCompany(Company aCompany)
        {
            if (IsExist(aCompany.CompanyName))
            {
                return "Company Name is Already Exist.";
            }
            int row = this.aCompanyGateway.SaveCompany(aCompany);
            if (row > 0)
            {
                return "Saved";
            }
            else
            {
                return "Failed";
            }
        }
        public List<Company> GetAllCompany()
        {
            return this.aCompanyGateway.GetAllCompany();
        }
    }
}