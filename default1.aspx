<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default1.aspx.vb" Inherits="ScrabbleCounter_webApp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Game counter</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/jquery-ui.css" rel="stylesheet" />
</head>
<body>   
    <form id="formDefault" runat="server">
        <div class="container" style="background-color: antiquewhite">
            <%-- názov aplikácie --%>
            <div class="row mb-4">
                <div class="col d-flex align-items-center justify-content-center bg-success text-white" style="height: 100px; text-shadow: 2px 2px 7px">
                    <h1>Počítadlo skóre pre hru SCRABBLE</h1>
                </div>                
            </div>     
            
            <%-- víťaz predošlej hry (row) --%>
            <div class="row pb-4">
                <%-- víťaz predošlej hry (text) --%>
               <div class="col-4 text-body-emphasis text-end">
                    <h3><asp:Label ID="Label_vitaz_predoslej_hry" runat="server"></asp:Label></h3>
                </div>
                <%-- víťaz predošlej hry (meno) --%>
                <div class="col-2 text-body-emphasis">                    
                        <h3><asp:Label ID="Label_vitaz_predoslej_hry_meno" runat="server"></asp:Label></h3>                    
                </div>
                <%-- počet kôl (nápis) --%>
                <div class="col-2 text-body-emphasis text-end">
                    <h3>Počet kôl:</h3>
                </div>
                <%-- počet kôl (číslo) --%>
                <div class="col-1 text-body-emphasis">
                    <h3><asp:Label ID="Label_pocet_kol" runat="server" Text=""></asp:Label></h3>
                </div>
                <%-- RadioButtonList na výber "testovanie" alebo "hra" --%>
                <div class="col-2 offset-1">
                     <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                         <asp:ListItem Text="&nbsp testovanie" Value="1"></asp:ListItem>
                         <asp:ListItem Text="&nbsp hra" Value="2"></asp:ListItem>
                     </asp:RadioButtonList>
                </div>
            </div>

            <%-- pomocné hlášky (row) --%>                
            <div class="row mb-2">
                <div class="col-6 text-end text-white">
                    <asp:Label ID="Label_1sprava"  Visible="false" font-size="12pt" runat="server" BackColor="LightBlue" ForeColor="White"></asp:Label>
                </div>
                <div id="div_2sprava" class="col-6 text-end text-white">
                    <asp:Label ID="Label_2sprava" Visible="false" font-size="12pt" runat="server" BackColor="lightBlue" ForeColor="White"></asp:Label>
                </div>                
            </div>
           

            <%-- doterajší stav zápolenia (row) --%>
            <div class="row pt-1 pb-2 border-top border-bottom bg-secondary-subtle">
                <%-- doterajší stav zápolenia (nápis) --%>
                <div class="col-4 offset-4 pb-2 text-center">
                    <h4>Doterajší stav zápolenia:</h4>
                </div>                

                <%-- mená hráčov (row) --%>
                <div class="row">
                    <div class="col-2"></div>
                    <%-- meno hráča (button) --%>
                    <div class="col-3  mb-3 text-center">
                        <asp:Button
                            ID="Button_elzi_loads_competition_page"
                            Font-Size="22pt"
                            CssClass="btn btn-lg btn-info text-white"
                            runat="server"
                            Text="Elzička" OnClick="Button_elzi_loads_competition_page_Click" />                        
                    </div>
                    <div class="col-2"></div>
                    <%-- meno hráča (button) --%>
                    <div class="col-3 mb-3 text-center">
                        <asp:Button ID="Button_tomas_loads_competition_page"
                            Font-Size="22pt"
                            CssClass="btn btn-lg btn-info text-white"
                            runat="server"
                            Text="Tomáš" OnClick="Button_tomas_loads_competition_page_Click" />
                    </div>
                    <div class="col-2"></div>
                </div>

                <%-- počet víťazstiev (row) --%>
                <div class="row">
                    <div class="col-2"></div>
                    <%-- počet víťazstiev (text) --%>
                    <div class="col-3 text-center">
                        <h5>počet víťazstiev:</h5>
                    </div>
                    <div class="col-2"></div>
                    <%-- počet víťazstiev (text) --%>
                    <div class="col-3 text-center">
                        <h5>počet víťazstiev:</h5>
                    </div>
                    <div class="col-2"></div>
                </div>

                <%-- body z minulej hry (row) --%>
                <div class="row">                    
                    <div class="col-2"></div>
                    <%-- body z minulej hry (label) --%>
                    <div class="col-3 text-center">
                        <div class="badge" 
                            id="div_elzi_body_z_minulej_hry" 
                            style="height:50px" 
                            runat="server">
                            <asp:Label ID="Label_elzi_cislo_pocet_vitazstiev" 
                                font-size="28pt" 
                                runat="server" 
                                Text="">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="col-2"></div>
                    <%-- body z minulej hry (label) --%>
                    <div class="col-3 text-center">
                        <div class="badge" id="div_tomas_body_z_minulej_hry" style="height:50px" runat="server">
                        <asp:Label ID="Label_tomas_cislo_pocet_vitazstiev" runat="server" font-size="28pt" text=""></asp:Label>
                    </div>
                    </div>
                    <div class="col-2"></div>
                </div>    
                
                <%-- klikni na meno začínajúceho hráča (row) --%>
                <div class="row pt-2">
                    <div class="col text-center">
                        Klikni na meno začínajúceho hráča.
                    </div>
                </div>
            </div>   
            
            <%-- obrázok SCRABBLE BOARD (row) --%>
            <div class="row pt-3 pb-3">
                <div class="col text-center">
                    <img class="img-fluid" src="Pictures/scrabble.jpg" alt="scrabble board"/>
                </div>
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
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>  
    <script src="Scripts/JavaScript.js"></script>
</body>
</html>
