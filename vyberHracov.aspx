<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="vyberHracov.aspx.vb" Inherits="ScrabbleCounter_webApp.vyberHracov" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>výber hráčov</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
   <form id="formVyberHracov" runat="server">
       <div class="container pb-3" style="background-color: antiquewhite">
           <%-- názov aplikácie --%>
            <div class="row mb-3">
                <div class="col d-flex align-items-center justify-content-center bg-success text-white" style="height: 100px; text-shadow: 2px 2px 7px">
                    <h1>Počítadlo skóre pre hru SCRABBLE</h1>
                </div>                
            </div>           

           <%-- Vyber mená hráčov zo zoznamu (nápis) --%>
           <div class="row mb-2">
               <div class="col text-center">
                   <h3>Vyber mená hráčov zo zoznamu:</h3>
               </div>
           </div>                     
           
           <div class="row">
               <%-- chybové hlásenie --%>
               <div class="col-5 text-center text-danger">
                    <asp:Label ID="Label_chybove_hlasenie" runat="server" Text=""></asp:Label>
               </div>

               <%-- roletové menu s menami hráčov --%>              
               <div class="col-2 text-center dropdown">
                <asp:DropDownList ID="DropDownList_players" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_players_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="" Selected="True" />
                </asp:DropDownList>
                </div>
               <%-- zobraziť vybraté meno --%>
               <div class="col-5">                   
                   <asp:Label ID="Label_selectedPlayer" runat="server" Text=""></asp:Label>
               </div>
           </div>

           <%-- prejsť na zoznam vybratých hráčov (button) --%>
           <div class="row mt-3">
               <div class="col text-center">
                   <input id="Button_prejst_na_zoznam_vybratych_hracov" type="button" value="Prejsť na zoznam vybratých hráčov" onclick="Button_prejst_na_zoznam_vybratych_hracov_Click()" />
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
