<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LandLyst2.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>  
                    <td  class="auto-style2">
                        <asp:Label Text="Name" runat="server" />
                    </td>
                    <td  class="auto-style2">
                        <asp:TextBox ID="txtFullName" runat="server" />
                    </td>
                </tr>
                <tr>  
                    <td class="auto-style2">
                        <asp:Label Text="Phone Number" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style4">
                        <asp:TextBox ID="txtPhoneNumber" runat="server" />
                    </td>
                </tr>
                <tr>  
                    <td class="auto-style2">
                        <asp:Label Text="Email" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style4">
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </td>
                </tr>
                <tr>  
                    <td class="auto-style2">
                        <asp:Label Text="Period of stay" runat="server" />
                    </td>
                    </tr>
                <tr>
                    <td colspan="2">
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                        <asp:Button Text="Check In Date " ID="txtCheckIn" runat="server" OnClick="txtCheckIn_Click" Width="150px" />
                        <asp:Button Text="Check Out Date" ID="txtCheckOut" runat="server" OnClick="txtCheckOut_Click" Width="151px" />
                    </td>
                </tr>
                <tr>  
                    <td colspan="2">
                        <asp:Label Text="Extra" runat="server" />
                    </td>
                </tr>
                <tr>  
                    <td class="auto-style2">  
                        <asp:CheckBoxList ID="extra" runat="server" OnSelectedIndexChanged="extra_SelectedIndexChanged">
                            <asp:ListItem Value="150" Text="Altan" />
                            <asp:ListItem Value="175" Text="Jacuzzi" />
                            <asp:ListItem Value= "50" Text="Bathtub" />
                            <asp:ListItem Value="200" Text="Double Bed" />
                            <asp:ListItem Value="350" Text="Kitchen" />
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>  
                    <td class="auto-style2">  
                        &nbsp;</td>
                </tr>
                
                <tr>  
                    <td class="auto-style2">
                        <asp:Button Text="Calculate Price" ID="CalculatePrice" runat="server" OnClick="CalculatePrice_Click" />
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="txtPrice" Text="$$$$$" runat="server" />
                    </td>
                    
                </tr>
                <tr>  
                    <td colspan="2">
                    </td>
                </tr>
                <tr>  
                    <td colspan="2">
                        <asp:TextBox colspan="3" ID="txtOrderDetails" TextMode="MultiLine"  Text="If there is something else you want to let us know type it here" runat="server" Height="56px" Width="288px"/>
                    </td>
                </tr>
                <tr>  
                    <td colspan="2">
                        <asp:Button Text="Submit Request" runat="server" OnClick="Unnamed6_Click" />
                    </td>
                </tr>
                <tr>  
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" Text="" runat="server" OnClick="Unnamed6_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
