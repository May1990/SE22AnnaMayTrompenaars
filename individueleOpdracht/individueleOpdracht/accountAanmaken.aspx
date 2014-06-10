<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountAanmaken.aspx.cs" Inherits="individueleOpdracht.accountAanmaken" %>

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
    
        <div id="upperBlock"></div>

        <div id="centerBlock">
            <div id="accinfoMkAcc">
                
                    <table id="tblAccAanm">
                        <tr>
                            <td>
                                <p>Naam</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxNaam" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFldValNaam" runat="server" ErrorMessage="GeenNaamIngevuld" ValidationGroup="CheckAccAanm" CssClass="validationMakeUp" ControlToValidate="TxtBxNaam">Vul je naam in.</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>Geslacht</p>
                            </td>
                            <td>
                                <asp:RadioButton ID="RdBttnMan" runat="server" GroupName="geslacht" CssClass="radioButtons" Text="Man" />
                                <asp:RadioButton ID="RdBttnVrouw" runat="server" GroupName="geslacht" CssClass="radioButtons" Text="Vrouw" />
                            </td>
                            <td>
                                
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>Geboortedatum</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxGeboorte" runat="server" CssClass="TextboxAccAanm" TextMode="Date"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFldValGeboorte" runat="server" ErrorMessage="GeenGeboortedatumIngevuld" ValidationGroup="CheckAccAanm" CssClass="validationMakeUp" Display="Dynamic" ControlToValidate="TxtBxGeboorte">Vul een geboortedatum in.</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegExpValGeboorte" runat="server" ErrorMessage="" ControlToValidate="TxtBxGeboorte" CssClass="validationMakeUp" Display="Dynamic" ValidationExpression="dd-MM-yyyy"></asp:RegularExpressionValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>Straat</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxStaat" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFldValStraat" runat="server" ErrorMessage="GeenstraatIngevuld" ValidationGroup="CheckAccAanm" CssClass="validationMakeUp" ControlToValidate="TxtBxStaat">Vul je straat in.</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <p>Huisnummer</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxHsNr" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFldValHsNr" runat="server" ErrorMessage="GeenHuisnummerIngevuld" ValidationGroup="CheckAccAanm" CssClass="validationMakeUp" ControlToValidate="TxtBxHsNr">Vul je huisnummer in.</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>Woonplaats</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxPlaats" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFldValPLaats" runat="server" ErrorMessage="GeenPlaatsIngevuld" ValidationGroup="CheckAccAanm" CssClass="validationMakeUp" ControlToValidate="TxtBxPlaats">Vul je woonplaats ib</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>Beroep</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxBeroep" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                            
                        </tr>

                        <tr>
                            <td>
                                <p>Opleiding</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxOpleiding" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <p>E-mail</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxEmail" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFldValEmail" runat="server" ErrorMessage="GeenEmailIngevuld" ValidationGroup="CheckAccAanm" CssClass="validationMakeUp" ControlToValidate="TxtBxEmail">Vul je e-mail in.</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>Skype</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxSkype" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p>Wachtwoord</p>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBxWWNieuw" runat="server" CssClass="TextboxAccAanm"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFldValWWEen" runat="server" ErrorMessage="GeenWachtwoordIngevuld" ValidationGroup="CheckAccAanm" CssClass="validationMakeUp" ControlToValidate="TxtBxWWNieuw" >Vul een wachtwoord in.</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                    </table>

            </div>

            <asp:Button ID="BttnAccAanm" runat="server" Text="Account aanmaken" ValidationGroup="CheckAccAanm" OnClick="BttnAccAanm_Click"/>
            <asp:Button ID="BttnCn" runat="server" Text="Cancel" OnClick="BttnCn_Click" />
            
        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copyright 2014</h3></div>
        </div>

    </form>
    </div>
    
</body>
</html>
