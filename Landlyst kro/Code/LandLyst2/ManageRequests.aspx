<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRequests.aspx.cs" Inherits="LandLyst2.ManageRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfRequestID" runat="server" />
            <table>

                <tr>
                    <td>
                        <asp:Label Text="Requester" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtRequester" runat="server" />
                        
                    </td>
                    
                </tr>


                <tr>
                    <td>
                        <asp:Label Text="Phone Number" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumber" runat="server" ReadOnly="true" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Email" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Creation Date" runat="server" ReadOnly="true" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderDate" runat="server" OnClick="txtOrderDate_Click" OnTextChanged="false" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Check in" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtCheckInDate" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Check out" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtCheckOutDate" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Requested Attributes" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtRequestedAttributes" Text="" runat="server" OnTextChanged="TextBox1_TextChanged" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Order details" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderDetails" TextMode="MultiLine" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="RoomNumber" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoomNumber" runat="server" />
                    </td>
                </tr>


                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="updateButton" Text="Update" runat="server" OnClick="updateButton_Click" />
                        <asp:Button ID="deleteButton" Text="Delete" runat="server" OnClick="deleteButton_Click" />
                        <asp:Button ID="clearButton" Text="Clear" runat="server" OnClick="clearButton_Click" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvRequests" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvRequests_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%# string.Format("{0} {1} {2}", Eval("FirstName") ,Eval("MiddleName") ,Eval("LastName"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FirstName" HeaderText="Name" Visible="false"/>
                    <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" Visible="false" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" Visible="false"/>
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Contact" />
                    <asp:BoundField DataField="Email" HeaderText="Email" Visible="false" />
                    <asp:BoundField DataField="RequestDate" HeaderText="Creation Date"  />
                    <asp:BoundField DataField="CheckInDate" HeaderText="CheckInDate" Visible="false" />
                    <asp:BoundField DataField="CheckInDate" HeaderText="CheckOutDate" Visible="false" />
                    <asp:BoundField DataField="RequestedAttributes" HeaderText="Attributes" Visible="false" />
                    <asp:BoundField DataField="RequestInformation" HeaderText="Info" Visible="false" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkVIew" runat="server" CommandArgument='<%# Eval("RequestID") %>' OnClick="lnk_OnClick">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
