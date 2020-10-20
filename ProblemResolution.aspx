<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemResolution.aspx.cs" Inherits="Project1_YevgeniySakovets.ProblemResolution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Resolution</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnMainMenu" runat="server" style="z-index: 1; left: 48px; top: 91px; position: absolute" Text="Return to Main Menu" OnClick="btnMainMenu_Click" />
            <asp:GridView ID="gvResolutions" runat="server" style="z-index: 1; left: 83px; top: 210px; position: absolute; height: 346px; width: 611px">
            </asp:GridView>
            <asp:Label ID="lblError" runat="server" Font-Size="Medium" ForeColor="Red" style="z-index: 1; left: 87px; top: 568px; position: absolute" Text="(error)"></asp:Label>
        </div>
    </form>
</body>
</html>
