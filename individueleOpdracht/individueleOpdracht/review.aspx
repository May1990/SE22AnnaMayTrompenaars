<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="review.aspx.cs" Inherits="individueleOpdracht.review" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Tweakers</title>
    <script src="jquery.js" type="text/javascript"></script>
    <link href="StyleSheetOntOpdracht.css" rel="stylesheet" type="text/css" />
</head>
<body>
	
    <div id="containerMain">
    <form id="form1" runat="server">
                  
        <div id="upperBlock">
            <asp:Button ID="BttnMain" runat="server" Text="Ga naar begin pagina" CssClass="button" OnClick="BttnMain_Click" />
            <asp:Button ID="BttnLogUit" runat="server" Text="Uitloggen" CssClass="button" OnClick="BttnLogUit_Click"/>
            <asp:Button ID="BttnAccount" runat="server" Text="Inloggen" CssClass="button" OnClick="BttnAccount_Click" />
        </div>

        <div id="centerBlockMain">
            <div id="infoRev">
                <div id="titel">
                    <asp:Label ID="LblTitel" runat="server" Text="titel van review" CssClass="labels"></asp:Label>
                </div>
               
                <asp:TextBox ID="TxtBxInhoud" runat="server" CssClass="textBoxInhoudreview" ReadOnly="True" TextMode="MultiLine">tekst van review</asp:TextBox></div>
            
            <asp:TextBox ID="TxtBxComm" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="BttnComm" runat="server" Text="Commentaar" ValidationGroup="comment" OnClick="BttnComm_Click"/>
            <asp:RequiredFieldValidator ID="ReqFldValComm" runat="server" ErrorMessage="GeenCommentIngevuld" ValidationGroup="comment" CssClass="validationMakeUp" Display="Dynamic" ControlToValidate="TxtBxComm">Type een commentaar in.</asp:RequiredFieldValidator>
            
            <asp:Label ID="LblAccComment" runat="server" CssClass="labelsReview"></asp:Label>
            <asp:TextBox ID="TxtBxAccComm" runat="server" TextMode="MultiLine" CssClass="textBoxenReview" ReadOnly="True"></asp:TextBox>
            
            <asp:Label ID="LblAccComment2" runat="server" CssClass="labelsReview"></asp:Label>
            <asp:TextBox ID="TxtBxAccComm2" runat="server" TextMode="MultiLine" CssClass="textBoxenReview" ReadOnly="True"></asp:TextBox>
            
            <asp:Label ID="LblAccComment3" runat="server" CssClass="labelsReview"></asp:Label>
            <asp:TextBox ID="TxtBxAccComm3" runat="server" TextMode="MultiLine" CssClass="textBoxenReview" ReadOnly="True"></asp:TextBox>
            
            <asp:Label ID="LblAccComment4" runat="server" Text="" CssClass="labelsReview"></asp:Label>
            
            <asp:TextBox ID="TxtBxAccComm4" runat="server" TextMode="MultiLine" CssClass="textBoxenReview" ReadOnly="True"></asp:TextBox>
            
        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copyright 2014</h3></div>
        </div>

    </form>
    </div>
    
    <p>
        &nbsp;</p>
    
</body>
</html>

