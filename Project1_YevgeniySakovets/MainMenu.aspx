<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Project1_YevgeniySakovets.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Menu</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnTechnician" runat="server" style="z-index: 1; left: 660px; top: 400px; position: absolute" Text="Technician" OnClick="btnTechnician_Click" />
            <asp:Button ID="btnServiceEvent" runat="server" OnClick="btnServiceEvent_Click" style="z-index: 1; left: 660px; top: 250px; position: absolute" Text="Service Event" />
            <asp:Label ID="lblMainMenu" runat="server" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 692px; top: 150px; position: absolute" Text="Main Menu"></asp:Label>
            <asp:Button ID="btnProblemResolution" runat="server" style="z-index: 1; left: 660px; top: 300px; position: absolute" Text="Problem Resolution" OnClick="btnProblemResolution_Click" />
            <asp:Button ID="btnReports" runat="server" OnClick="btnReports_Click" style="z-index: 1; left: 660px; top: 350px; position: absolute" Text="Reports" />
        </div>
    </form>
</body>
</html>
