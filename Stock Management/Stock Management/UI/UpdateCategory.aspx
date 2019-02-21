<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCategory.aspx.cs" Inherits="Stock_Management.UI.UpdateCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<% Response.WriteFile("Menu.html");%>
<form id="form1" runat="server">

<div style="text-align: center">
    <h1>Category Setup Update</h1>
</div>
<div style="text-align: center">



&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;



<asp:Label ID="Label1" runat="server" Text="Category Name  :  "></asp:Label>
<asp:TextBox ID="companyNameEditTextBox" runat="server" Width="303px" Height="26px"></asp:TextBox>



&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" id="req" controltovalidate="companyNameEditTextBox" ForeColor="Red" errormessage="please Enter Category Name.!!!!">
    </asp:RequiredFieldValidator>



<br />



<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
<asp:Button ID="updateButton" runat="server" Text="Update" Width="104px" OnClick="updateButton_Click" />



<br />
<br />



<br />

<asp:Label ID="msgLabel" runat="server"></asp:Label>
</div>
</form>

</body>
</html>
