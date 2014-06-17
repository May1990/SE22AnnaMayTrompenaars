<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="individueleOpdracht.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Tweakers</title>
    <script src="jquery.js" type="text/javascript"></script>
    <link href="StyleSheetOntOpdracht.css" rel="stylesheet" type="text/css" />
</head>
<body>
	
    <div id="container">
    <form id="form1" runat="server">
    
        <div id="upperBlock">
            <asp:Button ID="BttnMain" runat="server" Text="Ga naar begin pagina" />
            <asp:Button ID="BttnLogUit" runat="server" Text="Uitloggen" CssClass="button" OnClick="BttnLogUit_Click"/>
            <asp:Button ID="BttnAccount" runat="server" Text="Inloggen" CssClass="button" OnClick="BttnAccount_Click" />
        </div>

        <div id="centerBlock">
            <div id="accountinfo">

                <div id="text"><p><b>Naam</b></p></div>
                <asp:Label ID="LblNaam" runat="server" Text="Sandra Gruibels"></asp:Label>

                <div id="text"><p><b>Geslacht</b></p></div>
                <asp:Label ID="LblGeslacht" runat="server" Text="Vrouw"></asp:Label>

                <div id="text"><p><b>Geboortedatum</b></p></div>
                <asp:Label ID="LblGebDatum" runat="server" Text="17-09-1990"></asp:Label>

                <div id="text"><p><b>Adres</b></p></div>
                <asp:Label ID="LblAdres" runat="server" Text="Wiedenwijk 12, Vught"></asp:Label>

                <div id="text"><p><b>Beroep</b></p></div>
                <asp:Label ID="LblBeroep" runat="server" Text="Leraar verpleegkunde"></asp:Label>

                <div id="text"><p><b>Opleiding</b></p></div>
                <asp:Label ID="LblOpleiding" runat="server" Text="Lerarenopleiding"></asp:Label>

                <div id="text"><p><b>E-mail</b></p></div>
                <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>

                <div id="text"><p><b>Skype</b></p></div>
                <asp:Label ID="LblSkype" runat="server" Text="Skype"></asp:Label>

                <div id="text"><p><b>Abbonement</b></p></div>
                <asp:Label ID="LblAbbo" runat="server" Text="Abbonement"></asp:Label>

                <div id="text"><p><b>Modstatus</b></p></div> 
                <asp:Label ID="LblMStatus" runat="server" Text="Modstatus"></asp:Label>
                               
            </div>

            <div id="reviewInfo">

                <div id="text"><p><b>Eigen reviews</b></p></div>
                <asp:ListBox ID="LstBxEigRev" runat="server"></asp:ListBox>
                <asp:RequiredFieldValidator ID="ReqFldValRev" runat="server" ValidationGroup="selRev" ErrorMessage="GeenReviewGeselecteerd" CssClass="validationMakeUp" ControlToValidate="LstBxEigRev">Selecteer een review.</asp:RequiredFieldValidator>
                <asp:Button ID="BttnKijkRev" runat="server" Text="Bekijk review" ValidationGroup="selRev" OnClick="BttnKijkRev_Click"/>
                <asp:Button ID="BttnVerwRev" runat="server" Text="Verwijder review" OnClick="BttnVerwRev_Click" />

            </div>

            <div id="WWinfo">

                <asp:Button ID="BttnAanpWW" runat="server" Text="Wachtwoord aanpassen" OnClick="BttnAanpWW_Click" />

                <div id="textVoorBox"><p><b>Oud wachtwoord</b></p></div>
                <asp:TextBox ID="TxtBxOudWW" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegExpValOldWW" runat="server" ValidationGroup="wachtwoord" ErrorMessage="WachtwoordIncorrect" Height="20px" Width="145px" ControlToValidate="TxtBxOudWW">Wachtwoord incorrect.</asp:RegularExpressionValidator>

                <asp:Button ID="BttnAanp" runat="server" Text="Aanpassen" ValidationGroup="wachtwoord" OnClick="BttnAanp_Click" Visible="False"/>

                <div id="textVoorBoxNw"><p><b>Nieuw wachtwoord</b></p></div>
                <asp:TextBox ID="TxtBxNieuwWW" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegExpValNwWW" runat="server" ValidationGroup="wachtwoord" ErrorMessage="TeWeinigCharacters" Height="20px" Width="145px" ControlToValidate="TxtBxNieuwWW">Te weinig characters.</asp:RegularExpressionValidator>

            </div>

        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copyright 2014</h3></div>
        </div>

    </form>
    </div>
    
</body>
</html>

