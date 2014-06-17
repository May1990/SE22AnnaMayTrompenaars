<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reviewMaken.aspx.cs" Inherits="individueleOpdracht.reviewMaken" %>

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
            
            <div id="MkRev">
                <div id="textVoorBox"><p>Titel</p></div>
                <asp:TextBox ID="TxtBxTitel" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxInhoud" runat="server" TextMode="MultiLine" ></asp:TextBox>

                <div id="validations">
                    <asp:RequiredFieldValidator ID="ReqFldValTilel" runat="server" CssClass="validationMakeUp" Display="Dynamic" ValidationGroup="Review" ErrorMessage="geenTitel" ControlToValidate="TxtBxTitel">Vergeet de titel niet.</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="ReqFldValInhoud" runat="server" CssClass="validationMakeUp" Display="Dynamic" ValidationGroup="Review" ErrorMessage="geenReview" ControlToValidate="TxtBxInhoud">Type een review.</asp:RequiredFieldValidator>
                </div>

            </div>
 
            
            
            <asp:Button ID="BttnPlRev" runat="server" Text="Plaats review" ValidationGroup="Review" OnClick="BttnPlRev_Click"/>
            <asp:Button ID="BttnCan" runat="server" Text="Cancel" OnClick="BttnCan_Click" />
            
        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copyright 2014</h3></div>
        </div>

    </form>
    </div>
    
</body>
</html>