<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="signup.aspx.vb" Inherits="ScrabbleCounter_webApp.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>sign up</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="CSS.css" rel="stylesheet" />

</head>
    <body>
        <form id="formSignup" runat="server">
            <div class="container" style="background-color: antiquewhite">
                <%-- názov aplikácie --%>
                <div class="row mb-3">
                    <div class="col d-flex align-items-center justify-content-center bg-success text-white" style="height: 100px; text-shadow: 2px 2px 7px">
                        <h1>Počítadlo skóre pre hru SCRABBLE</h1>
                    </div>                
                </div>

                <%-- Vytvoriť účet (nápis) --%>
                <div class="row">
                    <div class="col text-center">
                       <h2>Vytvoriť účet</h2>
                    </div>
                </div>
                
                <%-- polia na vstupné údaje hráča pre vytvorenie účtu --%>
                <div class="row pb-3">
                    <%-- meno hráča --%>
                    <div class="col-6 text-end">
                        <label>Meno hráča (také, aké sa má zobraziť pri hre):</label>
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
                    </div>
                    <%-- Email --%>
                    <div class="col-6 text-end">
                        <asp:Label ID="Label_signup_message" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
                        <label>Email:</label>
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox>
                    </div>
                    <%-- heslo --%>
                    <div class="col-6 text-end"><label>Heslo:</label>
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="TextBox_password" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <%-- heslo znovu --%>
                    <div class="col-6 text-end">
                        <label>Heslo znovu:</label>
                    </div>
                    <div class="col-6">
                        <asp:TextBox ID="TextBox_ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="row">                   
                    <%-- vytvoriť účet (button) --%>
                    <div class="col-6 offset-6 mt-2">
                        <asp:Button ID="btnSignUp" runat="server" Text="Vytvoriť účet" OnClick="btnSignUp_Click" />                        
                    </div>
                    <div class="row pb-3">                        
                        <div class="col-6 text-end">
                            <label>Už mám účet:</label>
                        </div>
                         <%-- login - podokno s button --%>
                         <div class="col-6 mt-2">
                             <input type="button" id="loginButton" value="Login" />
                             <div id="overlay" class="overlay">
                                 <div class="login-box">
                                     <h2>Prihlásiť sa</h2>
                                     <label for="username">Meno hráča:</label>
                                     <input type="text" id="username" name="username" /><br /><br />
                                     <label for="password">Heslo:</label>
                                     <input type="password" id="password" name="password" /><br /><br />
                                     <input type="button" value="Login" id="submitButton" onclick="submitLogin()" />
                                     <input type="button" value="Close" id="closeButton" onclick="closePopup()" />
                                 </div>
                             </div>
                         </div>
                    </div>
                </div>
            </div>
        </form>
        
    </body>
</html>
