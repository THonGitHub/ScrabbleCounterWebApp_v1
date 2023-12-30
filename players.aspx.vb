Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports BCrypt.Net

Partial Class players
    Inherits System.Web.UI.Page
    Public vyberHracov As New vyberHracov
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ' vyvolať zoznam vybratých hráčov zo session
            Dim selectedPlayersList As List(Of SelectedPlayer) = DirectCast(Session("SelectedPlayersList"), List(Of SelectedPlayer))

            If selectedPlayersList IsNot Nothing AndAlso selectedPlayersList.Count > 0 Then
                For Each selectedPlayer As SelectedPlayer In selectedPlayersList
                    AddRowToTable(selectedPlayer.PlayerID, selectedPlayer.PlayerName)
                Next
            Else
                Label_chybove_hlasenie.Text = "žiadne dáta"
            End If
        End If

    End Sub

    Private Sub AddRowToTable(playerID As Integer, playerName As String)
        Dim row As New TableRow()
        Dim cellPlayerID As New TableCell() With {
            .Text = playerID.ToString()
        }

        Dim cellPlayerName As New TableCell() With {
            .Text = playerName
        }

        row.Cells.Add(cellPlayerID)
        row.Cells.Add(cellPlayerName)

        Table_players.Rows.Add(row)
    End Sub

End Class
