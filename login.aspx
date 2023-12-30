<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="ScrabbleCounter_webApp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log in</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="container" style="background-color: antiquewhite">
                <%-- názov aplikácie --%>
                <div class="row mb-3">
                    <div class="col d-flex align-items-center justify-content-center bg-success text-white" 
                        style="height: 100px; text-shadow: 2px 2px 7px">
                        <h1>Počítadlo skóre pre hru SCRABBLE</h1>
                    </div>                
                </div>

                <%-- Log in (nápis) --%>
                <div class="row">
                    <div class="col text-center"><h2>Login</h2></div>
                </div>

                <%-- email a heslo --%>
                <div class="row pb-3">
                    <%-- Email --%>
                    <div class="col-6 text-end">
                        <asp:Label ID="Label_login_message" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
                        <label>Email:</label>
                    </div>                
                    <div class="col-6">
                        <asp:TextBox ID="TextBox_login_email" runat="server"></asp:TextBox>
                    </div>
                    <%-- heslo --%>
                    <div class="col-6 text-end">
                        <label>Password:</label>
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="TextBox_Login_Password" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <%-- Prihlásiť sa (button) --%>
                    <div class="col-6 offset-6 mt-2">
                        <asp:Button ID="Button_login" runat="server" Text="Prihlásiť sa" OnClick="Button_login_Click" />
                    </div>                    
                </div>
                <%-- Prejsť na stránku pre vytvorenie účtu (button) --%>
                <div class="col pb-3 text-center">
                    <asp:Button ID="Label_vytvorit_ucet" runat="server" Text="Ak ešte nemáš účet, vytvor si ho" OnClick="Button_vytvorit_ucet_Click" />
                </div>
            </div>
        </form>
     <script src="Scripts/jquery-3.7.1.js"></script>
     <script src="Scripts/bootstrap.js"></script>
     <script src="Scripts/jquery-ui.js"></script>
     <script src="JavaScript.js" defer="defer"></script>
    </body>
</html>


