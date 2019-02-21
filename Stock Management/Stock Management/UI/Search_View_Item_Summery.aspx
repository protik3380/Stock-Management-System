<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search_View_Item_Summery.aspx.cs" Inherits="Stock_Management.UI.Search_View_Item_Summery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 544px;
        }
        .auto-style2 {
            width: 221px;
        }
        .auto-style3 {
            width: 544px;
            text-align: right;
        }
    </style>
</head>
<body>
    <% Response.WriteFile("Menu.html");%>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <h1>Search & View Items' Summery</h1>
        </div>
        <div style="text-align: center" >

            <table style="width:100%;">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Company  :  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Height="29px"  style="margin-left: 0px" Width="200px" >
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Category :  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="categoryDropDownList" runat="server" Height="29px" style="margin-left: 0px" Width="200px" >
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="searchBtn" runat="server" Height="28px" Text="Search" Width="111px" OnClick="searchBtn_Click"  />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="msgLabel" runat="server"></asp:Label>
                        <br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </div>
        <div style="alignment: center; width: 812px;">
            <asp:GridView ID="viewReportGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="768px">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:TemplateField HeaderText=" SL">
                        <ItemTemplate>
                            <asp:Label ID="SerialNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                
                    <asp:TemplateField HeaderText=" Item Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("ItemName ") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CategoryName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Available Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("AvailableQuantity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Re-Order Label">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("ReOrder") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
                
            </asp:GridView>
            <br />
            <asp:Button ID="pdfBtn" runat="server" Height="42px" Text="Export to Pdf" Width="257px" Visible="False" OnClick="pdfBtn_Click" />
            <br />
            <br />
        </div>
       
    </form>
</body>
</html>
