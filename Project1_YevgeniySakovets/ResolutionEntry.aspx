<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResolutionEntry.aspx.cs" Inherits="Project1_YevgeniySakovets.ResolutionEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" style="z-index: 1; left: 206px; top: 80px; position: absolute" Text="Resolution Entry"></asp:Label>
            <asp:Label ID="lblTicket" runat="server" style="z-index: 1; left: 40px; top: 130px; position: absolute" Text="Ticket No:"></asp:Label>
            <asp:Label ID="lblProblem" runat="server" style="z-index: 1; left: 48px; top: 174px; position: absolute" Text="Problem No:"></asp:Label>
            <asp:Label ID="lblResolution" runat="server" style="z-index: 1; left: 52px; top: 221px; position: absolute" Text="Resolution No:"></asp:Label>
            <asp:Label ID="lblResolutionTxt" runat="server" style="z-index: 1; left: 51px; top: 289px; position: absolute" Text="Resolution:"></asp:Label>
            <asp:Label ID="lblTechnician" runat="server" style="z-index: 1; left: 62px; top: 435px; position: absolute" Text="Technician:"></asp:Label>
            <asp:Label ID="lblHours" runat="server" style="z-index: 1; left: 62px; top: 520px; position: absolute" Text="Hours:"></asp:Label>
            <asp:Label ID="lblSupplies" runat="server" style="z-index: 1; left: 61px; top: 575px; position: absolute" Text="Supplies:"></asp:Label>
            <asp:Label ID="lblDateFixed" runat="server" style="z-index: 1; left: 65px; top: 616px; position: absolute" Text="Date Fixed:"></asp:Label>
            <asp:Label ID="lblMileage" runat="server" style="z-index: 1; left: 349px; top: 522px; position: absolute" Text="Mileage:"></asp:Label>
            <asp:Label ID="lblMisc" runat="server" style="z-index: 1; left: 355px; top: 568px; position: absolute" Text="Misc:"></asp:Label>
            <asp:Label ID="lblCostMiles" runat="server" style="z-index: 1; left: 695px; top: 527px; position: absolute" Text="Cost Miles:"></asp:Label>
            <asp:Label ID="lblDateOnsite" runat="server" style="z-index: 1; left: 699px; top: 614px; position: absolute" Text="Date Onsite:"></asp:Label>
            <asp:Label ID="lblRequiredInfo" runat="server" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 61px; top: 666px; position: absolute" Text="* indicates required information"></asp:Label>
            <asp:Label ID="lblError" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="Red" style="z-index: 1; left: 522px; top: 667px; position: absolute" Text="(error)"></asp:Label>
            <asp:TextBox ID="txtResolution" runat="server" style="z-index: 1; left: 219px; top: 294px; position: absolute; height: 80px; width: 255px" TextMode="MultiLine"></asp:TextBox>
            <asp:TextBox ID="txtHours" runat="server" style="z-index: 1; left: 155px; top: 519px; position: absolute; width: 169px"></asp:TextBox>
            <asp:DropDownList ID="drpTechnician" runat="server" style="z-index: 1; left: 223px; top: 434px; position: absolute; width: 213px">
            </asp:DropDownList>
            <asp:TextBox ID="txtSupplies" runat="server" style="z-index: 1; top: 573px; position: absolute; left: 190px; width: 145px"></asp:TextBox>
            <asp:TextBox ID="txtDateFixed" runat="server" style="z-index: 1; left: 220px; top: 615px; position: absolute; width: 200px; margin-right: 0px"></asp:TextBox>
            <asp:TextBox ID="txtMileage" runat="server" style="z-index: 1; left: 473px; top: 520px; position: absolute; width: 187px"></asp:TextBox>
            <asp:TextBox ID="txtMisc" runat="server" style="z-index: 1; left: 438px; top: 566px; position: absolute; width: 213px"></asp:TextBox>
            <asp:TextBox ID="txtCostMiles" runat="server" style="z-index: 1; left: 845px; top: 528px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDateOnsite" runat="server" style="z-index: 1; left: 866px; top: 613px; position: absolute; width: 227px"></asp:TextBox>
            <asp:Label ID="lblTicketNo" runat="server" style="z-index: 1; left: 192px; top: 133px; position: absolute" Text="(ticketNo here)"></asp:Label>
            <asp:Label ID="lblProblemNo" runat="server" style="z-index: 1; left: 192px; top: 170px; position: absolute" Text="(problemNo here)"></asp:Label>
            <asp:Label ID="lblResolutionNo" runat="server" style="z-index: 1; left: 192px; top: 224px; position: absolute" Text="(resolutionNo here)"></asp:Label>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" style="z-index: 1; left: 65px; top: 707px; position: absolute" Text="Submit" />
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" style="z-index: 1; left: 214px; top: 709px; position: absolute" Text="Clear" />
            <asp:CheckBox ID="chkNoCharge" runat="server" style="z-index: 1; left: 469px; top: 436px; position: absolute" Text="No Charge"/>
            <asp:Button ID="btnGoBack" runat="server" OnClick="btnGoBack_Click" style="z-index: 1; left: 27px; top: 85px; position: absolute" Text="Go Back" />
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
