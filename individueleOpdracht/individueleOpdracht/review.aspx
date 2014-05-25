<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="review.aspx.cs" Inherits="individueleOpdracht.review" %>

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
                  
        <div id="upperBlock"></div>

        <div id="centerBlockMain">
            <div id="infoRev">
                <div id="titel"><p><b>Nikon D5100 Zwart Review</b></p></div>
                <div id="tekstreview"><p>Toen Nikon met de D700 FX camera op de markt kwam keek ik als Canon user en eigenaar van een Canon EOS 40D al jaloers naar het Nikon kamp en speelde met de gedachte over te stappen. Toen kwam de Canon 5DmkII uit en na een paar maanden deze camera te hebben gebruikt, kwam ik tot de conclusie dat dit toch niet de camera was voor mij, vooral vanwege de matige AF. Het onderbuik gevoel bleef dat het bij Nikon toch wel beter toeven was. En dat werd versterkt door een aantal camera's dat Nikon daarna nog uitbracht. Deze camera's waren echter zo duur dat het niet 'even uitproberen' zou worden, maar meteen een volledige overstap en dat vond ik niet zo'n goed idee aangezien ik een aantal L-lenzen van Canon bezit.

Toen Nikon uitkwam met de D5100 was dat voor mij een mooie gelegenheid om toch eens te proberen. Ik zocht een DSLR waarmee je kon filmen en ook nog redelijk goede foto's kon maken. De keuze tussen de D5100 en de 600D van Canon viel ten gunste van de Nikon uit, met name door de film mogelijkheden (AF tijdens filmen wat niet totaal crap was) en de beeldkwaliteit. 

Dus aangeschaft werd een D5100 met de 35mm f18. DX lens van Nikon. Ik had nog een paar Nikkor lenzen uit het Ai tijdperk die ik ook wou gebruiken. Ik kwam er ook meteen achter dat lenzen op het Nikon platform een factor duurder waren dan bij Canon. Zo kost de hele goede 17-55f2.8 van Nikon meteen 1250,- tegen de (net zo goede) Canon 17-55f2.8 IS die rond de 850,- kost en ook meteen beeldstabilisatie heeft. Dus voor het normale bereik heb ik een Sigma 17-50 f2.8 OS gekocht. Deze lens is niet totaal crap en heeft beeldstabilisatie. De tamron tegenhanger is veel minder qua optische kwaliteiten (volgens reviews). Om geluid op te nemen had ik een Rode videomic gekocht die je op de flitser hot-shoe kon schroeven.

Over de beeldkwaliteit is al veel geschreven, dus ik hou het kort op dat vlak. Deze is gewoon goed, zeker op hetzelfde niveau als de Canon 600D. 
</p></div>
            </div>
            
            <asp:TextBox ID="TxtBxComm" runat="server"></asp:TextBox>
            <asp:Button ID="BttnComm" runat="server" Text="Commentaar" ValidationGroup="comment"/>
            <asp:RequiredFieldValidator ID="ReqFldValComm" runat="server" ErrorMessage="GeenCommentIngevuld" ValidationGroup="comment" CssClass="validationMakeUp" Display="Dynamic" ControlToValidate="TxtBxComm">Type een commentaar in.</asp:RequiredFieldValidator>
            <div id="accNaam"><p><b>Lisa Doorn</b></p></div>
            <div id="commentaarA"><p>Wat een uitstekende review. Ik ga ook zo'n ding kopen.</p></div>

            

        </div>

        <div id="lowerBlock">
            <div id="copyright"><h3>Copywrite 2014</h3></div>
        </div>

    </form>
    </div>
    
    <p>
        &nbsp;</p>
    
</body>
</html>

