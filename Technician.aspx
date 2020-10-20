<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Technician.aspx.cs" Inherits="Project1_YevgeniySakovets.Technician" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Technician</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnMainMenu" runat="server" OnClick="btnMainMenu_Click" style="z-index: 1; left: 162px; top: 91px; position: absolute; width: 276px" Text="Return To Main Menu" />
            <asp:Label ID="lblTechnician" runat="server" style="z-index: 1; left: 166px; top: 189px; position: absolute" Text="Technician:"></asp:Label>
            <asp:Label ID="lblFirstName" runat="server" style="z-index: 1; left: 162px; top: 255px; position: absolute" Text="*First Name:"></asp:Label>
            <asp:Label ID="lblMiddleInit" runat="server" style="z-index: 1; left: 168px; top: 321px; position: absolute; right: 1373px;" Text="Middle Initial:"></asp:Label>
            <asp:Label ID="lblLastName" runat="server" style="z-index: 1; left: 166px; top: 389px; position: absolute; margin-bottom: 0px" Text="*Last Name:"></asp:Label>
            <asp:Label ID="lblEmail" runat="server" style="z-index: 1; left: 172px; top: 451px; position: absolute" Text="Email:"></asp:Label>
            <asp:Label ID="lblDepartment" runat="server" style="z-index: 1; left: 168px; top: 513px; position: absolute" Text="Department:"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 164px; top: 589px; position: absolute; margin-bottom: 0px" Text="*Phone:"></asp:Label>
            <asp:Label ID="lblHourlyRate" runat="server" style="z-index: 1; left: 164px; top: 657px; position: absolute" Text="*Hourly Rate:"></asp:Label>
            <asp:Label ID="lblRequiredInfo" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 124px; top: 717px; position: absolute" Text="* indicates required field"></asp:Label>
            <asp:Button ID="btnAccept" runat="server" style="z-index: 1; left: 122px; top: 779px; position: absolute; height: 36px" Text="Accept" OnClick="btnAccept_Click" />
            <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 278px; top: 781px; position: absolute; height: 36px; right: 1319px;" Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button ID="btnRemove" runat="server" style="z-index: 1; left: 434px; top: 781px; position: absolute; height: 36px; right: 1044px;" Text="Remove" OnClick="btnRemove_Click" />
            <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 640px; top: 781px; position: absolute; height: 36px" Text="Clear" OnClick="btnClear_Click" />
            <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 124px; top: 853px; position: absolute" Text="(error message)"></asp:Label>
            <asp:Button ID="btnNewTechnician" runat="server" style="z-index: 1; left: 824px; top: 187px; position: absolute" Text="New Technician" OnClick="btnNewTechnician_Click" />
            <asp:DropDownList ID="drpTechnician" AutoPostBack ="true" runat="server" style="z-index: 1; left: 360px; top: 189px; position: absolute; width: 318px" OnSelectedIndexChanged="drpTechnician_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:TextBox ID="txtFirstName" runat="server" style="z-index: 1; left: 368px; top: 257px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtMiddleInit" runat="server" style="z-index: 1; left: 370px; top: 327px; position: absolute; width: 144px" MaxLength="1"></asp:TextBox>
            <asp:TextBox ID="txtLastName" runat="server" style="z-index: 1; left: 366px; top: 393px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; left: 368px; top: 453px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDepartment" runat="server" style="z-index: 1; left: 368px; top: 519px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" style="z-index: 1; left: 368px; top: 591px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtHourlyRate" runat="server" style="z-index: 1; left: 368px; top: 659px; position: absolute"></asp:TextBox>
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" style="z-index: 1; left: 526px; top: 81px; position: absolute" Text="Technician Maintenance"></asp:Label>
        </div>
    </form>
</body>
</html>
