<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemEntry.aspx.cs" Inherits="Project1_YevgeniySakovets.ProblemEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Entry</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="X-Large" style="z-index: 1; left: 592px; top: 75px; position: absolute" Text="Problem Entry"></asp:Label>
            <asp:Label ID="lblTicket" runat="server" style="z-index: 1; left: 63px; top: 178px; position: absolute" Text="Ticket No:"></asp:Label>
            <asp:Label ID="lblProblem" runat="server" style="z-index: 1; left: 63px; top: 246px; position: absolute" Text="Problem No:"></asp:Label>
            <asp:Label ID="lblProductNo" runat="server" style="z-index: 1; left: 68px; top: 308px; position: absolute" Text="*Product No:"></asp:Label>
            <asp:Label ID="lblTProblem" runat="server" style="z-index: 1; left: 68px; top: 359px; position: absolute" Text="*Problem:"></asp:Label>
            <asp:Label ID="lblTechnician" runat="server" style="z-index: 1; left: 63px; top: 496px; position: absolute" Text="*Technician:"></asp:Label>
            <asp:Label ID="lblRequiredField" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 63px; top: 540px; position: absolute" Text="* indicates required information"></asp:Label>
            <asp:Label ID="lblTicketNo" runat="server" style="z-index: 1; left: 244px; top: 181px; position: absolute" Text="ticket No. Here"></asp:Label>
            <asp:Label ID="lblProblemNo" runat="server" style="z-index: 1; left: 244px; top: 244px; position: absolute" Text="prob No. Here"></asp:Label>
            <asp:Button ID="btnService" runat="server" OnClick="btnService_Click" style="z-index: 1; left: 67px; top: 123px; position: absolute" Text="Return to Service" />
            <asp:DropDownList ID="drpProduct" runat="server" style="z-index: 1; left: 242px; top: 306px; position: absolute; width: 268px">
            </asp:DropDownList>
            <asp:TextBox ID="txtProblem" runat="server" style="z-index: 1; left: 205px; top: 344px; position: absolute; height: 127px; width: 388px" TextMode="MultiLine" ToolTip="Enter problem"></asp:TextBox>
            <asp:DropDownList ID="drpTechnician" runat="server" style="z-index: 1; left: 220px; top: 493px; position: absolute; width: 271px">
            </asp:DropDownList>
            <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 62px; top: 620px; position: absolute; height: 33px" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnMainMenu" runat="server" OnClick="btnMainMenu_Click" style="z-index: 1; left: 309px; top: 620px; position: absolute; height: 33px" Text="Main Menu" />
        </div>
            <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 70px; top: 576px; position: absolute" Text="(Error)"></asp:Label>
        <p>
            <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 198px; top: 617px; position: absolute; height: 32px; margin-top: 3px; margin-bottom: 5px;" Text="Clear" OnClick="btnClear_Click" />
            </p>
    </form>
</body>
</html>
