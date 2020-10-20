<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceEvent.aspx.cs" Inherits="Project1_YevgeniySakovets.ServiceEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Event</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnMainMenu" runat="server" OnClick="btnMainMenu_Click" style="z-index: 1; left: 30px; top: 165px; position: absolute; width: 284px" Text="Return To Main Menu" />
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" style="z-index: 1; left: 556px; top: 91px; position: absolute" Text="Service Event Entry"></asp:Label>
            <asp:Label ID="lblEventDate" runat="server" style="z-index: 1; left: 102px; top: 289px; position: absolute" Text="Event Date:"></asp:Label>
            <asp:Label ID="lblClient" runat="server" style="z-index: 1; left: 110px; top: 383px; position: absolute; bottom: 528px" Text="*Client:"></asp:Label>
            <asp:Label ID="lblContact" runat="server" style="z-index: 1; left: 108px; top: 467px; position: absolute" Text="*Contact:"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 116px; top: 551px; position: absolute" Text="*Phone:"></asp:Label>
            <asp:DropDownList ID="drpClient" runat="server" style="z-index: 1; left: 264px; top: 379px; position: absolute; width: 296px">
            </asp:DropDownList>
            <asp:TextBox ID="txtContact" runat="server" style="z-index: 1; left: 266px; top: 471px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 268px; top: 555px; position: absolute" MaxLength="10" TextMode="Phone"></asp:TextBox>
            <asp:Button ID="btnNext" runat="server" style="z-index: 1; left: 128px; top: 723px; position: absolute; width: 110px; height: 36px; right: 1488px" Text="Next" OnClick="btnNext_Click" />
            <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 430px; top: 721px; position: absolute; height: 34px; width: 107px" Text="Clear" />
            <asp:Label ID="lblRequiredInfo" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 140px; top: 629px; position: absolute" Text="* indicates required information"></asp:Label>
            <asp:Label ID="lblDateOfEvent" runat="server" style="z-index: 1; left: 266px; top: 287px; position: absolute" Text="(event date here)"></asp:Label>
            <asp:Label ID="lblError" runat="server" Font-Size="Medium" ForeColor="Red" style="z-index: 1; left: 157px; top: 657px; position: absolute" Text="(error)"></asp:Label>
        </div>
    </form>
</body>
</html>
