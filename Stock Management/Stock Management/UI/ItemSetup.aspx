<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetup.aspx.cs" Inherits="Stock_Management.UI.ItemSetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 522px;
            text-align: right;
        }
        .auto-style2 {
            width: 234px;
        }
    </style>
</head>
<body>
<% Response.WriteFile("Menu.html");%>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <h1>Item Setup</h1>
        </div>
        <div  >

            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Category  :  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="categoryDropDownList" runat="server" Height="29px" style="margin-left: 0px" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td> <asp:RequiredFieldValidator
                             ID="RequiredFieldValidator1"
                             runat="server"
                             ControlToValidate="categoryDropDownList"
                             InitialValue="--Select Category--"
                             ErrorMessage="* Please select Category"
                             ForeColor="Red"
                             Display="Dynamic">
                         
                    </asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Company :  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Height="29px" style="margin-left: 0px" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            runat="server"
                            ControlToValidate="companyDropDownList"
                            InitialValue="--Select company--"
                            ErrorMessage="* Please select Company"
                            ForeColor="Red"
                            Display="Dynamic">
                         
                    </asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="itemNameTextBox" runat="server" Height="22px" style="margin-left: 0px" Width="189px"></asp:TextBox>
                    </td>
                    <td><asp:RequiredFieldValidator runat="server" id="req" controltovalidate="itemNameTextBox" ForeColor="Red" errormessage="Please Select an Item!!">
                    </asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="Re Order Level  :  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="reorderTextBox" runat="server" Height="22px" style="margin-left: 0px" Width="189px"></asp:TextBox>
                    </td>
                    <td><asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="reorderTextBox" ForeColor="Red" errormessage="Please Fill Up This Field!!">
                    </asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="saveBtn" runat="server" Height="43px" Text="Save" Width="111px" OnClick="saveBtn_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="msgLabel" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </div>
    </form>
</body>
</html>
