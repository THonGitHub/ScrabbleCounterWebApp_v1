<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PriebehHry.aspx.vb" Inherits="ScrabbleCounter_webApp.PriebehHry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Game counter</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <link href="CSS.css" rel="stylesheet" />
</head>
    <body>
        <form id="form_competition" runat="server">
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <div class="container pb-2" style="background-color: aliceblue">

                <%-- názov aplikácie --%>
                <div class="row mb-3">
                    <div class="col d-flex align-items-center justify-content-center bg-success text-white" style="height: 100px; text-shadow: 2px 2px 7px">
                        <h1>Priebeh hry SCRABBLE</h1>
                    </div>                
                </div>    

                <%-- pomocné hlášky (row) --%>                
                <div class="row mt-2 mb-2">
                    <div class="col-1 text-end text-white">
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
                </div>
                
                <%-- tabuľka s priebehom hry (GridView) --%>
                <div class="row">
                    <div class="col">
                        <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="PageChange" PageSize="15" CssClass="table bg-gradient table-hover text-center">--%>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="PageChange" PageSize="25" CssClass="table table-hover text-center dark-mode text-white">
                                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="<<" LastPageText=">>" PreviousPageText="<" NextPageText=">" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="číslo ťahu" />
                                        <asp:BoundField DataField="body_za_slovo_elzi" HeaderText="body za slovo Elzička" />
                                        <asp:BoundField DataField="body_spolu_elzi" HeaderText="body spolu Elzička" />
                                        <asp:BoundField DataField="body_za_slovo_tomas" HeaderText="body za slovo Tomáš" />
                                        <asp:BoundField DataField="body_spolu_tomas" HeaderText="body spolu Tomáš" />                                        
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
        <%--<script src="JavaScript.js"></script>--%>
    </body>
</html>
