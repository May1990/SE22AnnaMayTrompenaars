<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="individueleOpdracht.logIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Social Media Event - Inchecken</title>
    <script src="jquery.js" type="text/javascript"></script>
    <link href="StyleSheetOntOpdracht.css" rel="stylesheet" type="text/css" />
</head>
<body>
	
    <div id="container">
    <form id="form1" runat="server">
    
        <div id="upperBlock">
        </div>

        <div id="centerBlock">
            <div id="logIn">

                <div id="text"><p>Email</p></div>
                <asp:TextBox ID="TxtBxEmail" runat="server" Width="214px" Height="16px"></asp:TextBox>

                <div id="text"><p>Wachtwoord</p></div>
                <asp:TextBox ID="TxtBxWW" runat="server" Width="214px" Height="15px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqFldValWW" runat="server" ErrorMessage="WachtwoordIncorrect." ControlToValidate="TxtBxWW" ValidationGroup="inlog" Display="Dynamic" CssClass="validationMakeUp">Vul een wachtwoord in.</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="ReqFldValEmail" runat="server" ErrorMessage="E-mailIncorrect" ControlToValidate="TxtBxEmail" ValidationGroup="inlog" Display="Dynamic" CssClass="validationMakeUp">Vul je e-mail in.</asp:RequiredFieldValidator>

                <asp:Button ID="BttnLogIn" runat="server" Text="Log in" Height="25px" ValidationGroup="inlog"/>
                
                <asp:Button ID="BttnCanc" runat="server" style="width: 131px; " Text="Cancel" />
                <asp:Button ID="BttnAanmAcc" runat="server" style="width: 131px" Text="Account aanmaken" />
                
            </div>
        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copywrite 2014</h3></div>
        </div>

    </form>
    </div>
    
