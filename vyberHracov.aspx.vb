Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports BCrypt.Net

''' <summary>
''' stránka na výber mien hráčov zo zoznamu
''' </summary>
Public Class vyberHracov
    Inherits System.Web.UI.Page

    'deklarovať "SelectedPlayersList" na úrovni class
    Public SelectedPlayersList As List(Of SelectedPlayer)
    Public selectedPlayerID As Integer
    Public player_name As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("clear") = "true" Then
                ' Clear the session variable
                Session("selectedPlayersList") = Nothing
                ' Redirect back to the page after clearing the session
                Response.Redirect("vyberHracov.aspx")
            Else
                ' Check if it's a new session or if the selectedPlayersList is null
                If Session("selectedplayerslist") Is Nothing Then
                    ' Initialize the list if it's a new session
                    Session("selectedplayerslist") = New List(Of SelectedPlayer)()
                    ' Bind the dropdown
                    LoadPlayers()
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' z DB tabuľky načítať zoznam mien registrovaných hráčov a zobraziť ho v roletovom menu
    ''' </summary>
    Protected Sub LoadPlayers()
        If SelectedPlayersList Is Nothing Then
            SelectedPlayersList = New List(Of SelectedPlayer)
        End If

        Dim dt_read_players As New DataTable
        Dim connectionString As String = "insert connection string here"
        Dim query As String = "SELECT * FROM GameCounter_players;"

        Using con As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query)
                Using sda As New MySqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt_read_players
                        sda.Fill(dt_read_players)

                        ' vytvoriť default položku a pridať ju do DataTable
                        Dim defaultRow As DataRow = dt_read_players.NewRow()
                        defaultRow("id") = 0
                        defaultRow("players") = "Zoznam hráčov"
                        dt_read_players.Rows.InsertAt(defaultRow, 0)

                        ' pripoj hráčov do roletového menu
                        DropDownList_players.DataTextField = "players"
                        DropDownList_players.DataValueField = "id"
                        DropDownList_players.DataSource = dt_read_players
                        DropDownList_players.DataBind()
                    End Using
                End Using
            End Using
            con.Close()
        End Using
    End Sub

    ''' <summary>
    ''' Sub na výber hráčov z roletového menného zoznamu hráčov tabuľke
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub DropDownList_players_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' získať potrebné údaje o hráčoch z roletového menu
        Dim selectedPlayerID As Integer = Convert.ToInt32(DropDownList_players.SelectedValue)
        Dim player_name As String = DropDownList_players.SelectedItem.Text

        ' vytvoriť nový object z triedy "SelectedPlayer" a pridať ho do zoznamu
        Dim selectedPlayer As New SelectedPlayer With {
            .PlayerID = selectedPlayerID,
            .PlayerName = player_name
        }

        ' získať "playersList" zo session a pridať ďalšieho vybratého hráča
        Dim playersList As List(Of SelectedPlayer) = CType(Session("SelectedPlayersList"), List(Of SelectedPlayer))
        playersList.Add(selectedPlayer)

        ' Updatovať session modifikovaným zoznamom "playersList"
        Session("SelectedPlayersList") = playersList

        ' Updatovať label o meno vybratého hráča - zobrazí sa ako doplnková informácia vedľa roletového menu
        ' je to potrebné len počas vývoja aplikácie
        Label_selectedPlayer.Text = "Vybratý hráč: " & selectedPlayerID & ". " & player_name

    End Sub

End Class

''' <summary>
''' trieda s vlastnosťami hráčov
''' </summary>
Public Class SelectedPlayer
    Public Property PlayerID As Integer
    Public Property PlayerName As String
End Class