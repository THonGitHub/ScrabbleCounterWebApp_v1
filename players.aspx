<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="players.aspx.vb" Inherits="ScrabbleCounter_webApp.players" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>vybratí hráči</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="formVybratiHraci" runat="server">
        <div class="container" style="background-color: antiquewhite">
           <%-- názov aplikácie --%>
            <div class="row mb-3">
                <div class="col d-flex align-items-center justify-content-center bg-success text-white" style="height: 100px; text-shadow: 2px 2px 7px">
                    <h1>Počítadlo skóre pre hru SCRABBLE</h1>
                </div>                
            </div>

            <%-- zoznam vybratých hráčov--%>
            <div class="col text-center">
                <h2>Zoznam vybratých hráčov</h2>
            </div>
            
            <div class="row">
                <%-- tabuľka s menami vybratých hráčov --%>
                <div class="col-3 offset-5 d-flex text-center">
                   
                    <asp:Table ID="Table_players" runat="server">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell CssClass="">por. číslo</asp:TableHeaderCell>
                            <asp:TableHeaderCell CssClass="">Meno hráča</asp:TableHeaderCell>
                        </asp:TableHeaderRow>                    
                    </asp:Table>
                </div>
                <%-- chybové hlásenie --%>
                <div class="col text-danger">
                    <asp:Label ID="Label_chybove_hlasenie" runat="server" Text=""></asp:Label>
                </div>                
            </div>
            
            <div class="row mt-5 pb-3">
                <%-- tlačítko "Zmeniť hráčov" --%>
                <div class="col-2 offset-4">
                    <input id="Button_zmenit_hracov" type="button" value="Zmeniť hráčov" onclick="Button_zmenit_hracov_Click()" />
                </div>

                <%-- tlačítko "Prejsť na hru" --%>
                <div class="col-2 d-flex">                    
                    <input id="Button_prejst_na_hru" type="button" value="Prejsť na hru" onclick="Button_prejst_na_hru_Click()"/>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script src="JavaScript.js" defer="defer"></script>
</body>
</html>
