<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="results.aspx.vb" Inherits="ScrabbleCounter_webApp.results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Game counter</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/jquery-ui.css" rel="stylesheet" />    
</head>
<body>
    <form id="form_results" runat="server">
        <div class="container pb-2" style="background-color: aliceblue">
             <%-- názov aplikácie - nadpis --%>
             <div class="row mb-5">
                 <div class="col d-flex align-items-center justify-content-center bg-success text-white" style="height: 100px; text-shadow: 2px 2px 7px">
                     <h1>Počítadlo skóre pre hru SCRABBLE</h1>
                 </div>                
             </div>    

            <%-- víťaz tejto hry (row) --%>
            <div class="row pb-4">
                <%-- víťaz tejto hry (text) --%>
               <div class="col-6 text-body-emphasis text-end align-content-center">
                    <asp:Label ID="Label_last_winner" font-size="18pt" runat="server" Text=""></asp:Label>
                </div>
                <%-- víťaz tejto hry (meno) --%>
                <%--<div class="col-2 badge bg-warning d-flex text-white align-content-center justify-content-center" style="height:40px;" runat="server">--%>
                <div class="col-2 badge text-body-emphasis">
                    <h3><asp:Label ID="Label_vitaz_tejto_hry" font-size="22pt" CssClass="btn btn-lg btn-warning text-white" runat="server"></asp:Label></h3>
                </div>
            </div>
             
            <%-- bodový stav na konci hry (row/labels) --%>
            <div class="row pt-1 pb-2 border-top border-bottom bg-secondary-subtle">
                <%-- bodový stav na konci hry (text) --%>
                <div class="col pb-1 text-center">
                    <h4>Bodový stav na konci hry:</h4>
                </div>

                <%-- mená hráčov (row/labels) --%>
                <div class="row">
                     <div class="col-2"></div>
                     <%-- meno hráča (label) --%>
                     <div class="col-3 mb-3 text-center badge">
                         <asp:Label ID="Label_elzi_loads_competition_page_inactive" font-size="22pt" CssClass="btn btn-lg btn-info text-white" Text="Elzička" runat="server"></asp:Label>         
                     </div>
                     <div class="col-2"></div>
                     <%-- meno hráča (label) --%>
                     <div class="col-3 mb-3 text-center text-white-50">
                         <asp:Label ID="Label_tomas_loads_competition_page_inactive" font-size="22pt" CssClass="btn btn-lg btn-info text-white" Text="Tomáš" runat="server"></asp:Label>
                     </div>
                     <div class="col-2"></div>
                 </div>

                <%-- počet víťazstiev a body spolu - texty (row) --%>
                <div class="row">
                    <div class="col-1"></div>        
                    <%-- počet víťazstiev (text) --%>
                    <div class="col-3 text-center">
                        <p>počet víťazstiev:</p>
                    </div>
                    <%-- body spolu (text) --%>
                    <div class="col-2 text-center">
                        <p>body spolu:</p>
                    </div>
                    <%-- body spolu (text) --%>
                    <div class="col-2 text-center">
                        <p>body spolu:</p>
                    </div>
                    <%-- počet víťazstiev (text) --%>
                    <div class="col-3 text-center">
                        <p>počet víťazstiev:</p>
                    </div>
                    <div class="col-1"></div>
                </div>

                <%-- body za slovo a body spolu - cisla (row) --%>
                <div class="row">
                    <div class="col-1"></div>
                    <%-- body za slovo (label) --%>
                    <div class="col-3 text-center">
                        <div class="badge" id="div_elzi_pocet_vitazstiev" style="height:50px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_elzi_pocet_vitazstiev" runat="server" font-size="28pt" Text=""></asp:Label>
                        </div>
                    </div>
                    <%-- body spolu (label) --%>
                    <div class="col-2 text-center">
                        <div class="badge" id="div_elzi_body_spolu" style="height:50px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_elzi_body_spolu" runat="server" font-size="28pt" Text=""></asp:Label>
                        </div>                            
                    </div>
                    <%-- body spolu (label) --%>
                    <div class="col-2 text-center">
                        <div class="badge" id="div_tomas_body_spolu" style="height:50px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_tomas_body_spolu" runat="server" font-size="28pt" Text=""></asp:Label>
                        </div>
                    </div>
                    <%-- body za slovo (label) --%>
                    <div class="col-3 text-center">
                        <div class="badge" id="div_tomas_pocet_vitazstiev" style="height:50px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_tomas_pocet_vitazstiev" runat="server" font-size="28pt" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="col-1"></div>
                </div>                    
            </div>

            <%-- Nová hra (row/buttons) --%>
            <div class="row mt-3 mb-2">
                <%-- nová hra (button) --%>
                <div class="col-8 d-flex offset-2 align-items-center justify-content-center">
                    <asp:Button 
                            ID="Button_nova_hra" 
                            CssClass="btn text-bg-success text-white" 
                            Font-Size="15pt" 
                            runat="server" 
                            Text="Nová hra" 
                            OnClick="Button_nova_hra_Click"/>
                </div>
                <div class="col-2"></div>
            </div>
            <div class="row mt-3 mb-2">

            <%-- ukončiť počítadlo (button) --%>
            <div class="col-8 d-flex offset-2 align-items-center justify-content-center">
                <asp:Button 
                        ID="Button_zavriet_browser" 
                        CssClass="btn btn-danger text-bg-danger text-white" 
                        Font-Size="15pt" 
                        runat="server" 
                        Text="Pre ukončenie počítadla zavri okno prehliadača"                         
                        OnClientClick="return closeWindow();"/>
            </div>
            <div class="col-2"></div>
        </div>
        </div>
    </form>
    <footer>                
        <div class="row text-center">
            <p>© 2023 Game Counter by TomasDiveMan</p>
        </div>
    </footer>
    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script src="JavaScript.js" defer="defer"></script>
</body>
</html>
