using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace Stock_Management.UI
{
    using System.IO;

    using Stock_Management.Logic_Layer;
    using Stock_Management.Models;

    using ListItem = System.Web.UI.WebControls.ListItem;

    public partial class Search_View_Item_Summery : System.Web.UI.Page
    {
        SearchViewManager aSearchViewManager= new SearchViewManager();
        CategoryManager aCategoryManager = new CategoryManager();
        CompanyManager aCompanyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllcategory();
                GetAllCompany();
               
            }
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            SearchVM aSearchVm = new SearchVM();
            aSearchVm.CompanyId = Convert.ToInt32(this.companyDropDownList.SelectedValue);
            aSearchVm.CategoryId = Convert.ToInt32(this.categoryDropDownList.SelectedValue);
            

            if (aSearchVm.CompanyId > 0 && aSearchVm.CategoryId<1)
            {
               
                List<SearchVM> report = this.aSearchViewManager.ViewReportByCompany(aSearchVm.CompanyId);
                this.viewReportGridView.DataSource = report;
                this.viewReportGridView.DataBind();
                pdfBtn.Visible = true;
                clearField();


            }
            else if (aSearchVm.CategoryId > 0 &&  aSearchVm.CompanyId < 1)
            {
                
               List<SearchVM>report=this.aSearchViewManager.ViewReportByCategory(aSearchVm.CategoryId);
               this.viewReportGridView.DataSource = report;
               this.viewReportGridView.DataBind();
                pdfBtn.Visible = true;
                clearField();

            }
            else if (aSearchVm.CompanyId>0 && aSearchVm.CategoryId>0)
            {
               
                List<SearchVM> report = this.aSearchViewManager.ViewReportByCompanyAndCategory(aSearchVm.CompanyId, aSearchVm.CategoryId);
                this.viewReportGridView.DataSource = report;
                this.viewReportGridView.DataBind();
                pdfBtn.Visible = true;
                clearField();

            }
            else if (aSearchVm.CategoryId < 1 && aSearchVm.CompanyId < 1)
            {
                
                List<SearchVM> report = this.aSearchViewManager.ViewAllReport();
                this.viewReportGridView.DataSource = report;
                this.viewReportGridView.DataBind();
                pdfBtn.Visible = true;
                clearField();
            }



        }
        public void GetAllcategory()
        {
            List<Category> categories = this.aCategoryManager.GetAllCategories();
            this.categoryDropDownList.DataSource = categories;
            this.categoryDropDownList.DataTextField = "CategoryName";
            this.categoryDropDownList.DataValueField = "CategoryId";
            this.categoryDropDownList.DataBind();            
            this.categoryDropDownList.Items.Insert(0, new ListItem("--Select Category--", "0"));
        }
        public void GetAllCompany()
        {
            List<Company> Companies = this.aCompanyManager.GetAllCompany();
            this.companyDropDownList.DataSource = Companies;
            this.companyDropDownList.DataTextField = "CompanyName";
            this.companyDropDownList.DataValueField = "CompanyId";
            this.companyDropDownList.DataBind();
            this.companyDropDownList.Items.Insert(0, new ListItem("--Select Company--", "0"));
        }
        public void clearField()
        {
            
            this.companyDropDownList.SelectedIndex = 0;
            this.categoryDropDownList.SelectedIndex = 0;
        }

        protected void pdfBtn_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter swr = new StringWriter();
            HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
            viewReportGridView.AllowPaging = false;
           // refreshdata();
            this.viewReportGridView.RenderControl(htmlwr);
            StringReader srr = new StringReader(swr.ToString());
            Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfdoc);
            PdfWriter.GetInstance(pdfdoc, this.Response.OutputStream);

            pdfdoc.Open();
            htmlparser.Parse(srr);
            pdfdoc.Close();


            Response.Write(pdfdoc);
            Response.End();   
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        } 
    }
}