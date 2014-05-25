<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reviewMaken.aspx.cs" Inherits="individueleOpdracht.reviewMaken" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Social Media Event - File-sharing</title>
    <script src="jquery.js" type="text/javascript"></script>
    <link href="StyleSheetOntOpdracht.css" rel="stylesheet" type="text/css" />
</head>
<body>
	
    <div id="containerMain">
    <form id="form1" runat="server">
    
        <div id="upperBlock">
            
        </div>

        <div id="centerBlockMain">
            
            <div id="MkRev">
                <div id="textVoorBox"><p>Titel</p></div>
                <asp:TextBox ID="TxtBxTitel" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtBxInhoud" runat="server" ></asp:TextBox>

                <div id="validations">
                    <asp:RequiredFieldValidator ID="ReqFldValTilel" runat="server" CssClass="validationMakeUp" Display="Dynamic" ValidationGroup="Review" ErrorMessage="geenTitel" ControlToValidate="TxtBxTitel">Vergeet de titel niet.</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="ReqFldValInhoud" runat="server" CssClass="validationMakeUp" Display="Dynamic" ValidationGroup="Review" ErrorMessage="geenReview" ControlToValidate="TxtBxInhoud">Type een review.</asp:RequiredFieldValidator>
                </div>

            </div>
 
            
            
            <asp:Button ID="BttnPlRev" runat="server" Text="Plaats review" ValidationGroup="Review"/>
            <asp:Button ID="BttnCan" runat="server" Text="Cancel" />
            
        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copywrite 2014</h3></div>
        </div>

    </form>
    </div>
    
</body>
</html>