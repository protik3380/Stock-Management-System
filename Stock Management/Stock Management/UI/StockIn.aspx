<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockIn.aspx.cs" Inherits="Stock_Management.UI.StockIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 558px;
        }
        .auto-style2 {
            width: 255px;
        }
    </style>
</head>
<body>
    <% Response.WriteFile("Menu.html");%>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <h1>Stock In Items</h1>
        </div>
        <div style="text-align: center" >

            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Company  :  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Height="29px" AutoPostBack="True" style="margin-left: 0px" Width="200px" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            runat="server"
                            ControlToValidate="companyDropDownList"
                            InitialValue="--Select Company--"
                            ErrorMessage="* Please select Company"
                            ForeColor="Red"
                            Display="Dynamic">              
                    </asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Item :  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="itemDropDownList" AutoPostBack="True" runat="server" Height="29px" style="margin-left: 0px" Width="200px" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1"
                            runat="server"
                            ControlToValidate="itemDropDownList"
                            InitialValue="--Select items--"
                            ErrorMessage="* Please select an Item"
                            ForeColor="Red"
                            Display="Dynamic">                         
                    </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="Re Order Level  :  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="reorderTextBox" runat="server" Height="22px" style="margin-left: 0px" Width="189px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="Available Quantity : "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="quantityTextBox" runat="server" Height="22px" style="margin-left: 0px" Width="189px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server" Text="Stock In Quantity : "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="stockInTextBox" runat="server" Height="22px" style="margin-left: 0px" Width="189px"></asp:TextBox>
                    </td>
                    <td><asp:RequiredFieldValidator runat="server" id="req" controltovalidate="stockInTextBox" ForeColor="Red" errormessage="Please Enter Quantity Amount!!">
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
