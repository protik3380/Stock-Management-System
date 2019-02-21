<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySetup.aspx.cs" Inherits="Stock_Management.UI.CategorySetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <% Response.WriteFile("Menu.html");%>
    <form id="form1" runat="server">

        <div style="text-align: center">
            <h1>Category Setup</h1>
        </div>
        <div style="text-align: center">
            <p>
                <asp:Label ID="msgLavel" runat="server" ForeColor="#669900"></asp:Label>
            </p>
        </div>
        <div style="text-align: center">


            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


            <asp:Label ID="Label1" runat="server" Text="Name  :  "></asp:Label>
            <asp:TextBox ID="categoryNameTextBox" runat="server" Width="303px" Height="26px"></asp:TextBox>
            &nbsp;&nbsp;
            &nbsp;<asp:RequiredFieldValidator runat="server" id="req" controltovalidate="categoryNameTextBox" ForeColor="Red" errormessage="please Enter Category Name.!!!!">
            </asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="saveButton" runat="server" Text="Save" Width="104px" OnClick="saveButton_Click" />

            <br />

            <br />
           
        </div>
        
         <div>
             <asp:GridView ID="ShowCategoryView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                 <Columns> 
                     <asp:TemplateField HeaderText="Sr No">
                         <ItemTemplate>
                             <%# Container.DataItemIndex + 1 %>
                         </ItemTemplate>
                
                     </asp:TemplateField>
                 </Columns>
                 <Columns>
                     <asp:TemplateField HeaderText="Category Name">
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%#Eval("CategoryName") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lbStart" 
                                             runat="server" 
                                             CausesValidation="false" 
                                             OnClick="edit_Btn"
                                             Text="Edit"
                                             CommandArgument='<%# Eval("CategoryId") %>'
                                             EnableTheming="False">
                             </asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>

               
                 </Columns>
                 <AlternatingRowStyle BackColor="White" />
                 <EditRowStyle BackColor="#2461BF" />
                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EFF3FB" />
                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
             </asp:GridView>
        </div>


    </form>
</body>
</html>
