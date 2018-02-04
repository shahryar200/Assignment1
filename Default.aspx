<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>

     <script type="text/javascript">
         page.open('https://twitter.com/realDonaldTrump', function () {window.setInterval(function() {page.evaluate(function() {window.document.body.scrollTop = document.body.scrollHeight;});}, 500);});
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" ID="cell">Title of CNN NEWS related to Trump</asp:TableCell>
                    <asp:TableCell ID="num" runat="server">Num</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
           <asp:Table ID="Table2" runat="server" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" ID="TableCell1">Trump's Tweets</asp:TableCell>
                    <asp:TableCell ID="TableCell3" runat="server">Num</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <p>These entries and values shows that which tweets are somehow related to CNN NEWS title! </p>
            <asp:Table ID="Table3" runat="server" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" ID="TableCell2">Levenshtain Distances of news with tweets</asp:TableCell>
                    <asp:TableCell ID="TableCell4" runat="server">Num</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
