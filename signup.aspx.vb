Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports BCrypt.Net

Public Class Signup
    Inherits System.Web.UI.Page

    Protected Sub BtnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click

        Dim name As String = TextBox_name.Text.Trim()
        Dim email As String = TextBox_email.Text.Trim()
        Dim password As String = TextBox_password.Text.Trim()
        Dim confirmPassword As String = TextBox_ConfirmPassword.Text.Trim()

        If password = confirmPassword Then

            If CreateUser(name, email, password) Then
                Label_signup_message.Text = "Účet bol úspešne vytvorený. Prejdi na log in."
                Response.Redirect("login.aspx")
            Else
                Label_signup_message.Text = "Chyba pri vytváraní účtu. Skús znova prosím."
            End If
        Else
            Label_signup_message.Text = "Heslá sa nezhodujú."
        End If
    End Sub


    ' Implement this method to create a new user in the database
    Private Function CreateUser(name As String, email As String, password As String) As Boolean

        ' Hash the password (you should use a proper password hashing algorithm)
        Dim passwordHash As String = YourPasswordHashingFunction(password)
        Dim connectionString As String = "insert connection string here"
        Dim query As String = "INSERT INTO GameCounter_players (
            date_time,
            players,
            Email,
            PasswordHash
            )
            VALUES (
            UTC_TIMESTAMP(),
            @players,
            @Email,
            @passwordHash
            )"

        Using mydbConnection As New MySqlConnection(connectionString)
            Dim myDbCommand As New MySqlCommand(query, mydbConnection)
            myDbCommand.Parameters.AddWithValue("@players", name)
            myDbCommand.Parameters.AddWithValue("@Email", email)
            myDbCommand.Parameters.AddWithValue("@passwordHash", passwordHash)
            myDbCommand.Connection.Open()
            myDbCommand.ExecuteNonQuery()
            myDbCommand.Connection.Close()
        End Using
        Return True
    End Function


    Private Function YourPasswordHashingFunction(password As String) As String
        Dim salt As String = BCrypt.Net.BCrypt.GenerateSalt(12)
        Dim passwordHash As String = BCrypt.Net.BCrypt.HashPassword(password, salt)
        Return passwordHash
    End Function

End Class

