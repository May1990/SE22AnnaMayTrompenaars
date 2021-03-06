﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="individueleOpdracht.main" %>

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
            <asp:Button ID="BttnLogUit" runat="server" Text="Uitloggen" CssClass="button" OnClick="BttnLogUit_Click"/>
            <asp:Button ID="BttnAccount" runat="server" Text="Inloggen" CssClass="button" OnClick="BttnAccount_Click" />
        </div>

        <div id="centerBlockMain">
            
            <asp:DropDownList ID="DDLstZoek" runat="server" >
                <asp:ListItem>Camera</asp:ListItem>
                <asp:ListItem>Laptops, desktops en servers</asp:ListItem>
                <asp:ListItem>Laptops</asp:ListItem>
                <asp:ListItem>Tablets en telefoon</asp:ListItem>
                <asp:ListItem>Mobiele telefoons</asp:ListItem>
                </asp:DropDownList>
            <asp:TextBox ID="TxtBxZoek" runat="server" Height="17px" ></asp:TextBox>
            
            <asp:Button ID="BttnZoek" runat="server" Text="Zoeken" ValidationGroup="Zoek" OnClick="BttnZoek_Click"/>
            
            <div id="validationMn">
                <asp:RequiredFieldValidator ID="ReqFldValZoek" runat="server" CssClass="validationMakeUp" ErrorMessage="ZoekTekstveldLeeg" ControlToValidate="TxtBxZoek" ValidationGroup="Zoek">Vul het zoek-tekstveld in.</asp:RequiredFieldValidator>
            </div>
            
            <asp:ListBox ID="LstBxResultaat" runat="server"></asp:ListBox>
            <asp:Button ID="BttnSelecteer" runat="server" Text="Selecteer" ValidationGroup="select" OnClick="BttnSelecteer_Click"/>

            <div id="validationMain">
                <asp:RequiredFieldValidator ID="ReqFldValSelect" runat="server" ErrorMessage="GeenItemGeselecteerd" ValidationGroup="select" ControlToValidate="LstBxResultaat" CssClass="validationMakeUp"> Selecteer een item in de lijst.</asp:RequiredFieldValidator>
            </div>

        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copyright 2014</h3></div>
        </div>

    </form>
    </div>
    
</body>
</html>
