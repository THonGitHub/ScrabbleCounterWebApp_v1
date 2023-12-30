<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="competition.aspx.vb" Inherits="ScrabbleCounter_webApp.competition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Game counter</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/jquery-ui.css" rel="stylesheet" />
</head>
    <body>
        <form id="form_competition" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="container pb-2" style="background-color: aliceblue">
                <%-- názov aplikácie --%>
                <div class="row mb-3">
                    <div class="col d-flex align-items-center justify-content-center bg-success text-white" style="height: 100px; text-shadow: 2px 2px 7px">
                        <h1>Počítadlo skóre pre hru SCRABBLE</h1>
                    </div>                
                </div>    
                
                <%-- na ťahu je hráč a body za slovo (row) --%>
                <div class="row">
                    <%-- na ťahu je hráč (popis) --%>
                    <div class="col-4 text-body-emphasis text-end">
                       <asp:Label ID="Label_na_tahu_je_hrac" font-size="18pt" runat="server" Text="Na ťahu je hráč(ka):"></asp:Label>
                    </div>
                    <%-- na ťahu je hráč (meno hráča) --%>
                    <div class="col-2 text-center badge" id="div_tomas_body_z_minulej_hry" style="height:40px; background-color: hotpink" runat="server">
                        <asp:Label ID="Label_meno_hraca_na_tahu" Text="" font-size="22pt" runat="server"></asp:Label>                        
                    </div>                    
                    <%-- zadaj body za slovo (popis) --%>
                    <div class="col-4 text-body-emphasis text-end">
                        <asp:Label ID="Label_zadaj_body_za_slovo" font-size="18pt" runat="server" Text="Zadaj body za slovo:"></asp:Label>
                    </div>
                    <%-- zadaj body za slovo (TextBox) --%>
                    <div class="col-1" font-size="22pt">
                        <asp:TextBox ID="TextBox_zadat_body_za_slovo" Font-Size="18pt" runat="server" OnTextChanged="TextBox_zadat_body_za_slovo_TextChanged" AutoPostBack="true" Width="50px"></asp:TextBox>
                    </div>                     
                    <div class="col-1"></div>
                </div>

                <%-- pomocné hlášky (row) --%>                
                <div class="row mt-2 mb-2">
                    <div class="col-2 text-end text-white">
                        <asp:Label ID="Label_1sprava"  Visible="false" font-size="12pt" runat="server" BackColor="LightBlue" ForeColor="White"></asp:Label>
                    </div>
                    <div class="col-2 text-end">
                        <asp:Label ID="Label_pomocny_text1" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-4">
                        <asp:Label ID="Label_pomocny_text2" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="div_2sprava" class="col-4 text-end text-white">
                        <asp:Label ID="Label_2sprava" Visible="false" font-size="12pt" runat="server" BackColor="LightBlue" ForeColor="White"></asp:Label>
                    </div>
                    <%--<a href="PriebehHry.aspx" target="_blank" id="linkToPriebehHry" style="display: none;"></a>--%>
                </div>
                
                <%-- túto hru začal a číslo ťahu (row) --%> 
                <div class="row pb-4">                    
                    <%-- túto hru začal (popis) --%>
                    <div class="col-4 mt-4 text-body-emphasis text-end">
                        <asp:Label ID="Label_tuto_hru_zacal_napis" font-size="18pt" runat="server" Text="Túto hru začal(a):"></asp:Label>
                    </div>

                    <%-- túto hru začal (meno hráča) --%>
                    <div class="col-2 mt-4 text-center badge" id="div_tuto_hru_zacal" style="height:40px; background-color: mediumaquamarine" runat="server">                        
                        <asp:Label ID="Label_tuto_hru_zacal" font-size="22pt" Text="" runat="server"></asp:Label>
                    </div>

                    <%-- číslo ťahu (text) --%>
                    <div class="col-4 mt-4 text-body-emphasis text-end">
                        <asp:Label ID="Label_cislo_tahu_popis" font-size="18pt" runat="server" Text="Číslo ťahu:"></asp:Label>
                    </div>

                    <%-- číslo ťahu (label) --%>
                    <div class="col-1 mt-4 mr-2 text-center badge" id="div_cislo_tahu" style="height:40px; background-color: mediumaquamarine" runat="server">                        
                        <asp:Label ID="Label_cislo_tahu" font-size="22pt" runat="server"></asp:Label>
                    </div>
                    <div class="col-1"></div>
                    <a href="PriebehHry.aspx" target="_blank" id="linkToPriebehHry" style="display: none;"></a>
                </div>

                <%-- priebežný stav hry (nápis) --%>
                <div class="row pt-2 pb-2 bg-secondary-subtle">
                    <div class="col-4 offset-4 text-center">
                        <h4>Priebežný stav hry</h4>
                    </div>
                    <%-- prehľad bodov aktuálnej hry (tlačítko) --%>
                    <div class="col-2">
                        <input type="button" class="btn btn-outline-light" value="Prehľad hry" onclick="Button_prehlad_aktualnej_hry_Click();" />                        
                    </div>
                </div>

                <%-- mená hráčov (row) --%>
                <div class="row bg-body-secondary border-black border-top">
                    <%-- meno hráča (label) --%>
                    <div class="col-2 pt-3 border-black border-start"></div>
                    <div class="col-2 pt-3 mb-3 text-center badge">
                        <asp:Label ID="Label_elzi_loads_competition_page_inactive" font-size="22pt" CssClass="btn btn-lg btn-info text-white" Text="Elzička" runat="server"></asp:Label>         
                    </div>
                    <div class="col-2 pt-3 border-black border-end"></div>
                    <%-- meno hráča (label) --%>
                    <div class="col-2 pt-3"></div>                        
                    <div class="col-2 pt-3 mb-3 text-center badge">
                        <asp:Label ID="Label_tomas_loads_competition_page_inactive" font-size="22pt" CssClass="btn btn-lg btn-info text-white" Text="Tomáš" runat="server"></asp:Label>
                    </div>
                    <div class="col-2 pt-3 border-black border-end"></div>
                </div>

                <%-- body za slovo - (nápisy) --%>
                <div class="row bg-body-secondary">
                    <div class="col-2 text-center border-black border-start">top</div>
                    <div class="col-2 text-center">body spolu:</div>          
                    <div class="col-2 text-center border-black border-end">body za slovo:</div>
                    <div class="col-2 text-center">body za slovo:</div>
                    <div class="col-2 text-center">body spolu:</div>
                    <div class="col-2 text-center border-black border-end">top</div>
                </div>

                <%-- body za slovo a body spolu (čísla) --%>
                <div class="row bg-body-secondary border-black border-bottom">
                    <%-- top body za slovo (číslo) --%>
                    <div class="col-2 pb-3 text-center border-black border-start">
                        <div class="badge" id="div_elzi_najviac_bodov_za_slovo" style="height:50px; width:90px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_elzi_najviac_bodov_za_slovo" runat="server" font-size="28pt" Text="0"></asp:Label>
                        </div>
                    </div>
                    <%-- body spolu (číslo) --%>
                    <div class="col-2 pb-3 text-center">
                        <div class="badge" id="div_elzi_body_spolu" style="height:50px; width:90px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_elzi_body_spolu_cislo" runat="server" font-size="28pt" Text="0"></asp:Label>
                        </div>                            
                    </div>
                    <%-- body za slovo (číslo) --%>
                    <div class="col-2 pb-3 text-center border-black border-end">
                        <div class="badge" id="div_elzi_body_za_slovo" style="height:50px; width:90px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_elzi_body_za_slovo_cislo" runat="server" font-size="28pt" Text="0"></asp:Label>
                        </div>
                    </div>                            
                    <%-- body za slovo (číslo) --%>
                    <div class="col-2 pb-3 text-center">
                        <div class="badge" id="div_tomas_body_za_slovo" style="height:50px; width:90px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_tomas_body_za_slovo_cislo" runat="server" font-size="28pt" Text="0"></asp:Label>
                        </div>
                    </div>
                    <%-- body spolu (číslo) --%>
                    <div class="col-2 pb-3 text-center">
                        <div class="badge" id="div_tomas_body_spolu" style="height:50px; width:90px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_tomas_body_spolu_cislo" runat="server" font-size="28pt" Text="0"></asp:Label>
                        </div>
                    </div>
                    <%-- top body za slovo (číslo) --%>
                    <div class="col-2 pb-3 text-center border-black border-end">
                        <div class="badge" id="div_tomas_najviac_bodov_za_slovo" style="height:50px; width:90px; background-color: lightcoral" runat="server">
                            <asp:Label ID="Label_tomas_najviac_bodov_za_slovo" runat="server" font-size="28pt" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>  
                
                <%-- doterajšie rekordy (nápis) --%>
                <div class="row pt-4 pb-2 bg-secondary-subtle">
                    <div class="col text-center">
                        <h4>Doterajšie rekordy:</h4>                            
                    </div>                        
                </div>
                
                <%-- doterajšie rekordy (tabuľka) --%>
                <div class="row bg-secondary-subtle">
                    <div class="col mb-3 text-center">
                            <asp:Table ID="Table_rekordy" CssClass="mx-auto bg-body-secondary" BorderWidth="1" CellPadding="5" runat="server">
                                <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="1">
                                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1">názov</asp:TableHeaderCell>
                                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1">držiteľ</asp:TableHeaderCell>
                                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1">bodová hodnota</asp:TableHeaderCell>
                                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1">dátum vytvorenia</asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                                <asp:TableRow>
                                    <asp:TableCell BorderStyle="Solid" BorderWidth="1">najviac bodov za slovo</asp:TableCell>
                                    <asp:TableCell ID="TableCell_drzitel_rekordu_najviac_bodov_za_slovo" Text="" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                    <asp:TableCell ID="TableCell_bodova_hodnota_rekordu_najviac_bodov_za_slovo" Text="" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                    <asp:TableCell ID="TableCell_datum_vytvorenia_rekordu_najviac_bodov_za_slovo" Text="" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell BorderStyle="Solid" BorderWidth="1">najviac bodov za hru</asp:TableCell>
                                    <asp:TableCell ID="TableCell_drzitel_rekordu_najviac_bodov_za_hru" Text="" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                    <asp:TableCell ID="TableCell_bodova_hodnota_rekordu_najviac_bodov_za_hru" Text="" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                    <asp:TableCell ID="TableCell_datum_vytvorenia_rekordu_najviac_bodov_za_hru" Text="" BorderStyle="Solid" BorderWidth="1"></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>                
                    </div>
                </div>
                        
                <%-- koniec hry a vyhodnotenie výsledkov (row a button) --%>
                <div class="row mt-3 mb-2">
                    <div class="col-2"></div>
                    <%-- koniec hry a vyhodnotenie výsledkov (button) --%>
                    <div class="col-8 d-flex align-items-center justify-content-center bg-warning">
                        <asp:Button 
                            ID="Button_koniec_hry_a_vyhodnotenie_vysledkov" 
                            CssClass="btn btn-warning text-bg-warning text-white" 
                            Font-Size="15pt" 
                            runat="server" 
                            Text="Koniec hry a vyhodnotenie výsledkov" 
                            OnClick="Button_koniec_hry_a_vyhodnotenie_vysledkov_Click"/>
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
        <script src="JavaScript.js"></script>
    </body>
</html>
