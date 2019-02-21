<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOut.aspx.cs" Inherits="Stock_Management.UI.StockOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 531px;
        }
        .auto-style2 {
            width: 220px;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
     <% Response.WriteFile("Menu.html");%>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <h1>Stock Out Items</h1>
        </div>
        <div >

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
                        <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity : "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="stockoutTextBox" runat="server" Height="22px" style="margin-left: 0px" Width="189px"></asp:TextBox>
                    </td>
                    <td><asp:RequiredFieldValidator runat="server" id="req" controltovalidate="stockoutTextBox" ForeColor="Red" errormessage="Please Enter Quantity Amount!!">
                    </asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="saveBtn" runat="server" Height="28px" Text="Add" Width="111px" OnClick="saveBtn_Click" />
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
        <div style="alignment: center; width: 812px;">
            <asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
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
                    <asp:TemplateField HeaderText="Stock Out Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("StockOut") %>'></asp:Label>
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
        </div>
        <table class="auto-style15">
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="sellButton" runat="server" Text="Sell" Width="66px" OnClick="sellButton_Click" Visible="False" CausesValidation="False"/>
                </td>
                <td class="auto-style3">
                    <asp:Button ID="damageButton" runat="server" Text="Damage" Width="66px" OnClick="damageButton_Click"  Visible="False" CausesValidation="False" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="lostButton" runat="server" Text="Lost" Width="66px" OnClick="lostButton_Click" Visible="False" CausesValidation="False"/>
                </td>
            </tr>
        </table>
        
    </form>

</body>
</html>
