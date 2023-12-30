Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Utilities.Bzip2

''' <summary>
''' Stránka je spúšťaná tlačidlom "Priebeh hry", ktoré je umiestnené na stránke "competition.aspx".
''' Tu sa zobrazí vo forme tabuľky priebeh aktuálnej hry od prvého ťahu.
''' Na stránke je zobrazený obsah tabuľky "Priebeh_hry".
''' </summary>
Public Class priebehHry
    Inherits System.Web.UI.Page

    Public cislo_tahu As Integer
    Public body_za_slovo_elzi As Integer
    Public body_spolu_elzi As Integer
    Public body_za_slovo_tomas As Integer
    Public body_spolu_tomas As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BindGrid()

    End Sub


    Private Sub BindGrid()

        Dim connectionString As String = "insert connection string here"
        Dim query As String = "SELECT * FROM TSI_ASSET_AUTOMATION.Priebeh_hry;"
        Dim dt As New DataTable

        Using con As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query)
                Using sda As New MySqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt
                        sda.Fill(dt)

                        'príprava dát pre GridView:
                        For Each dr As DataRow In dt.Rows
                            cislo_tahu = dr.Item("id")
                            body_za_slovo_elzi = dr.Item("body_za_slovo_elzi")
                            body_spolu_elzi = dr.Item("body_spolu_elzi")
                            body_za_slovo_tomas = dr.Item("body_za_slovo_tomas")
                            body_spolu_tomas = dr.Item("body_spolu_tomas")
                        Next

                        GridView1.DataSource = dt
                        Session("MyDataSet") = dt
                        GridView1.DataBind()

                    End Using
                End Using
            End Using
            con.Close()
        End Using
    End Sub

    Protected Sub PageChange(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging

        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataSource = DirectCast(Session("myDataSet"), DataTable)
        GridView1.DataBind()

    End Sub

End Class