<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="individueleOpdracht.product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Social Media Event - File-sharing</title>
    <script src="jquery.js" type="text/javascript"></script>
    <link href="StyleSheetOntOpdracht.css" rel="stylesheet" type="text/css" />
</head>
<body>
	
    <div id="container">
    <form id="form1" runat="server">
    
        <div id="upperBlock"></div>

        <div id="centerBlock">
            
            <asp:Image ID="Image2" runat="server" ImageUrl="images/cameraD510.png"/>

            <div id="productinfo">
                

                <div id="text"><p><b>Aparaat</b></p></div>
                <asp:Label ID="LblAparaat" runat="server" Text="Camera Nikon D5100" CssClass="labels" Height="20px" Width="148px"></asp:Label>

                <div id="text"><p><b>Merk</b></p></div>
                <asp:Label ID="LblMerk" runat="server" Text="Nikon" CssClass="labels" Height="20px" Width="148px"></asp:Label>

                <div id="text"><p><b>Serie</b></p></div>
                <asp:Label ID="LblSerie" runat="server" Text="D5" CssClass="labels" Height="20px" Width="148px"></asp:Label>

                <div id="text"><p><b>Versie</b></p></div>
                <asp:Label ID="LblVersie" runat="server" Text="D5100" CssClass="labels" Height="20px" Width="148px"></asp:Label>

                <div id="text"><p><b>Prijs</b></p></div>
                <asp:Label ID="LblPrijs" runat="server" Text="€400,00" CssClass="labels" Height="20px" Width="148px"></asp:Label>

                <div id="text"><p><b>Categorie</b></p></div>
                <asp:Label ID="LblCategorie" runat="server" Text="Camera's" CssClass="labels" Height="20px" Width="148px"></asp:Label>
                
            </div>
            <asp:ListBox ID="LstBxProduct" runat="server"></asp:ListBox>
            <div id="validationsPr">
                <asp:RequiredFieldValidator ID="ReqFldValSelect" runat="server" ErrorMessage="GeenItemGeselecteerd" CssClass="validationMakeUp" ValidationGroup="select" ControlToValidate="LstBxProduct">Selecteer een review in de lijst.</asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="BttnBkRev" runat="server" style="width: 146px; " Text="Bekijk review" ValidationGroup="select"/>
            <asp:Button ID="BttnNwRev" runat="server" style="width: 145px" Text="Review toevoegen" ValidationGroup="select"/>
        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copywrite 2014</h3></div>
        </div>

    </form>
    </div>
    
</body>
</html>
