Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports BCrypt.Net


Partial Class Login
    Inherits System.Web.UI.Page

    Public passwordHash As String
    Protected Sub Button_login_Click(sender As Object, e As EventArgs) Handles Button_login.Click
        Dim email As String = TextBox_login_email.Text.Trim()
        Dim password As String = TextBox_Login_Password.Text.Trim()
        passwordHash = YourPasswordHashingFunction(password)

        ' Call a method to validate user credentials (implement as needed)
        If ValidateUser(email, password) Then
            ' Redirect to the main application page
            Response.Redirect("default1.aspx")
        Else
            Label_login_message.Text = "Neplatné meno alebo heslo. Skús znova prosím."
        End If
    End Sub

    ' Implement this method to validate user credentials
    Private Function ValidateUser(email As String, password As String) As Boolean
        Dim connectionString As String = "insert connection string here"
        Dim query As String = "SELECT id, PasswordHash FROM GameCounter_players_test WHERE Email = @email"
        Dim storedPasswordHash As String

        ' Validate user against the database
        Using con As New MySqlConnection(connectionString)
            con.Open()
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Email", email)
                Using reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        ' Check the password (you should use a proper password hashing comparison)
                        storedPasswordHash = reader("PasswordHash").ToString()

                        'If passwordHash = storedPasswordHash Then
                        If YourPasswordHashComparisonFunction(password, storedPasswordHash) Then
                            ' Login successful
                            Session("UserID") = reader("id")
                            ' Redirect to the main page or do something else
                            Response.Redirect("default1.aspx")
                        Else
                            ' Incorrect password
                            Label_login_message.Text = "Nesprávne heslo."
                        End If

                    Else
                        ' User not found
                        Label_login_message.Text = "Meno užívateľa nenájdené."
                    End If
                End Using
            End Using
        End Using

        ' Return True if user credentials are valid, otherwise, return False
        Return YourPasswordHashComparisonFunction(password, storedPasswordHash)
    End Function

    ' Your password hashing comparison function goes here
    Private Function YourPasswordHashComparisonFunction(password As String, storedPasswordHash As String) As Boolean
        If String.IsNullOrEmpty(storedPasswordHash) Then
            ' Handle the case where storedPasswordHash is null or empty
            Return False
        Else
            Return BCrypt.Net.BCrypt.Verify(password, storedPasswordHash)
        End If
    End Function


    Private Function YourPasswordHashingFunction(password As String) As String
        Dim salt As String = BCrypt.Net.BCrypt.GenerateSalt(12)
        Dim passwordHash As String = BCrypt.Net.BCrypt.HashPassword(password, salt)
        Return passwordHash
    End Function

    Protected Sub Button_vytvorit_ucet_Click(sender As Object, e As EventArgs)
        Response.Redirect("signup.aspx")
    End Sub
End Class
