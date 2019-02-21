using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Logic_Layer
{
    using Stock_Management.Gate_Way;
    using Stock_Management.Models;

    public class SearchViewManager
    {
        SearchViewGateway aSearchViewGateway = new SearchViewGateway();

        public List<SearchVM> ViewReportByCompany(int companyId)
        {
            return aSearchViewGateway.ViewReportByCompany(companyId);
        }
        public List<SearchVM> ViewReportByCategory(int categoryId)
        {
            return aSearchViewGateway.ViewReportByCategory(categoryId);
        }
        public List<SearchVM> ViewReportByCompanyAndCategory(int companyId,int categoryId)
        {
            return aSearchViewGateway.ViewReportByCompanyAndCategory(companyId, categoryId);
        }
        public List<SearchVM> ViewAllReport()
        {
            return aSearchViewGateway.ViewAllReport();
        }
        


    }
}