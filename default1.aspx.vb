Imports MySql.Data.MySqlClient
''' <summary>
''' Po spustení aplikácie sa v prehliadači zobrazí úvodná stránka default.aspx.
''' Do nej sa z DB tabuľky GameCounter_results načítajú a zobrazia výsledky z predošlej hry.
''' Stlačením tlačítka s menom hráča, ktorý začína hru, sa zobrazí stránka competition.aspx.
''' </summary>
Public Class _default
    Inherits System.Web.UI.Page

    'verejné premenné budú prístupné zo všetkých code-behind:
    Public Elzi_points_for_game As Integer
    Public Elzi_wins_cumul As Integer
    Public Tomas_points_for_game As Integer
    Public Tomas_wins_cumul As Integer
    Public Label_meno_hraca_na_tahu As String
    Public pocet_kol As Integer
    Public datum_rekordu As Date
    Public Rekord_body_za_slovo As Integer
    Public Drzitel_rekordu_za_slovo As String
    Public Rekord_body_za_hru_elzi As Integer
    Public Rekord_body_za_hru_tomas As Integer
    Public connectionString As String = "insert connection string here"

    ''' <summary>
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'vymazať obsah DB tabuľky "Priebeh hry", aby sa do nej mohol začať zapisovať priebeh nasledujúcej hry
        Dim meno_tabulky = "Priebeh_hry"
        TruncateMySQLTable(meno_tabulky)

        'načítať dáta z DB tabuľky pre zistenie výsledkov z minulej hry
        Dim query As String = "SELECT * FROM GameCounter_results  ORDER BY id DESC LIMIT 1;"
        Dim dt_read_results As New DataTable
        If Not IsPostBack Then
            Using con As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query)
                    Using sda As New MySqlDataAdapter()
                        cmd.Connection = con
                        sda.SelectCommand = cmd
                        Using dt_read_results
                            sda.Fill(dt_read_results)

                            For Each dr As DataRow In dt_read_results.Rows
                                pocet_kol = dr.Item("id")
                                Elzi_points_for_game = dr.Item("Elzi_points_for_game")
                                Elzi_wins_cumul = dr.Item("Elzi_wins_cumul")
                                Tomas_points_for_game = dr.Item("Tomas_points_for_game")
                                Tomas_wins_cumul = dr.Item("Tomas_wins_cumul")
                                Session("Elzi_wins_cumul") = Elzi_wins_cumul
                                Session("Tomas_wins_cumul") = Tomas_wins_cumul
                            Next

                        End Using
                    End Using
                End Using
                con.Close()
            End Using

            Label_pocet_kol.Text = pocet_kol
            Label_elzi_cislo_pocet_vitazstiev.Text = Elzi_wins_cumul
            Label_tomas_cislo_pocet_vitazstiev.Text = Tomas_wins_cumul

            Session("Elzi_wins_cumul") = Elzi_wins_cumul
            Session("Tomas_wins_cumul") = Tomas_wins_cumul

            'priradiť farby počtu doterajších výhier
            If Elzi_wins_cumul > Tomas_wins_cumul Then
                div_elzi_body_z_minulej_hry.Style("background-color") = "LightGreen"
                div_tomas_body_z_minulej_hry.Style("background-color") = "LightPink"
            ElseIf Elzi_wins_cumul < Tomas_wins_cumul Then
                div_elzi_body_z_minulej_hry.Style("background-color") = "LightPink"
                div_tomas_body_z_minulej_hry.Style("background-color") = "LightGreen"
            Else
                div_elzi_body_z_minulej_hry.Style("background-color") = "LightBlue"
                div_tomas_body_z_minulej_hry.Style("background-color") = "LightBlue"
            End If

            'zistiť meno víťaza predošlej hry
            If Elzi_points_for_game > Tomas_points_for_game Then
                Label_vitaz_predoslej_hry.Text = "Víťaz predošlej hry je: "
                Label_vitaz_predoslej_hry_meno.Text = "Elzička"


            ElseIf Elzi_points_for_game < Tomas_points_for_game Then
                Label_vitaz_predoslej_hry.Text = "Víťaz predošlej hry je: "
                Label_vitaz_predoslej_hry_meno.Text = "Tomáš"

            Else
                Label_vitaz_predoslej_hry.Text = "Predošlá hra skončila"
                Label_vitaz_predoslej_hry_meno.Text = "remízou."
                'Label_vitaz_predoslej_hry_meno.BackColor = System.Drawing.Color.White
            End If
        End If

        'odstrániť z premennej session priebeh minulej hry
        Session("Body_pocas_hry") = ""

        'zobrazovať, či sa používa DB tabuľka "test"
        If query.Contains("test") Then
            Label_2sprava.Text = "tabuľka: test"
            Label_2sprava.Visible = True
        Else
            Label_2sprava.Visible = False
        End If

        'načítať dáta z DB tabuľky pre zistenie doterajšieho rekordu za body za slovo
        Dim query_rekord_body_za_slovo As String = "SELECT date_time, Rekord_body_za_slovo, Drzitel_rekordu_za_slovo FROM GameCounter_results ORDER BY Rekord_body_za_slovo DESC LIMIT 1;"
        Dim dt_rekord_body_za_slovo As New DataTable
        If Not IsPostBack Then
            Using con As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query_rekord_body_za_slovo)
                    Using sda As New MySqlDataAdapter()
                        cmd.Connection = con
                        sda.SelectCommand = cmd
                        Using dt_rekord_body_za_slovo
                            sda.Fill(dt_rekord_body_za_slovo)

                            For Each dr As DataRow In dt_rekord_body_za_slovo.Rows
                                datum_rekordu = dr.Item("date_time")
                                Rekord_body_za_slovo = dr.Item("Rekord_body_za_slovo")
                                Drzitel_rekordu_za_slovo = dr.Item("Drzitel_rekordu_za_slovo")
                                Session("Rekord_body_za_slovo") = Rekord_body_za_slovo
                                Session("datum_rekordu") = datum_rekordu
                                Session("Drzitel_rekordu_za_slovo") = Drzitel_rekordu_za_slovo
                            Next

                        End Using
                    End Using
                End Using
                con.Close()
            End Using
        End If

        'načítať dáta z DB tabuľky pre zistenie doterajšieho rekordu za body za hru Elzi
        Dim query_rekord_body_za_hru_elzi As String = "SELECT date_time, Elzi_points_for_game FROM GameCounter_results ORDER BY Elzi_points_for_game DESC LIMIT 1;"
        Dim dt_rekord_body_za_hru_elzi As New DataTable
        If Not IsPostBack Then
            Using con As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query_rekord_body_za_hru_elzi)
                    Using sda As New MySqlDataAdapter()
                        cmd.Connection = con
                        sda.SelectCommand = cmd
                        Using dt_rekord_body_za_hru_elzi
                            sda.Fill(dt_rekord_body_za_hru_elzi)

                            For Each dr As DataRow In dt_rekord_body_za_hru_elzi.Rows
                                datum_rekordu = dr.Item("date_time")
                                Rekord_body_za_hru_elzi = dr.Item("Elzi_points_for_game")
                                Session("Rekord_body_za_hru_elzi") = Rekord_body_za_hru_elzi
                                Session("datum_rekordu_za_hru_elzi") = datum_rekordu
                            Next

                        End Using
                    End Using
                End Using
                con.Close()
            End Using
        End If

        'načítať dáta z DB tabuľky pre zistenie rekordu za body za hru Tomas
        Dim query_rekord_body_za_hru_tomas As String = "SELECT date_time, Tomas_points_for_game FROM GameCounter_results ORDER BY Tomas_points_for_game DESC LIMIT 1;"
        Dim dt_rekord_body_za_hru_tomas As New DataTable
        If Not IsPostBack Then
            Using con As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query_rekord_body_za_hru_tomas)
                    Using sda As New MySqlDataAdapter()
                        cmd.Connection = con
                        sda.SelectCommand = cmd
                        Using dt_rekord_body_za_hru_tomas
                            sda.Fill(dt_rekord_body_za_hru_tomas)

                            For Each dr As DataRow In dt_rekord_body_za_hru_tomas.Rows
                                datum_rekordu = dr.Item("date_time")
                                Rekord_body_za_hru_tomas = dr.Item("Tomas_points_for_game")
                                Session("Rekord_body_za_hru_tomas") = Rekord_body_za_hru_tomas
                                Session("datum_rekordu_za_hru_tomas") = datum_rekordu
                            Next

                        End Using
                    End Using
                End Using
                con.Close()
            End Using
        End If

    End Sub

    ''' <summary>
    ''' vymazanie obsahu tabuľky
    ''' </summary>
    ''' <param name="meno_tabulky"></param>
    Public Sub TruncateMySQLTable(meno_tabulky As String)
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand()
                command.Connection = connection
                command.CommandText = $"TRUNCATE TABLE {meno_tabulky};"

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    Label_1sprava.Text = "Tabuľka ""Priebeh hry"" bola úspešne vyprázdnená"
                    Label_1sprava.Visible = False

                Catch ex As Exception
                    Label_1sprava.Text = "Chyba pri vyprázdňovaní tabuľky ""Priebeh hry""."
                    Label_1sprava.Visible = True
                    Label_2sprava.Text = ex.Message
                    Label_2sprava.Visible = True
                End Try
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' tlačítka s menami hráčov, ne ktoré keď sa klikne, tak sa zobrazí stránka competition.aspx,
    ''' na ktorej sa zvolené meno zobrazí v poliach: "Hráč na ťahu:" a "Túto hru začal:"
    ''' Na stránke competition.aspx sú už potom tieto tlačítka inaktívne.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Button_tomas_loads_competition_page_Click(sender As Object, e As EventArgs)

        'otestovať, či bolo zvolené "testovanie" alebo "hra"
        If RadioButtonList1_SelectedIndexChanged(sender, e) Then
            Session("meno_hraca_z_default") = "Tomáš"
            Response.Redirect("competition.aspx")
        Else
            Label_1sprava.Text = "Vyber ""testovanie"" alebo ""hra""."
            Label_1sprava.Visible = True
        End If
    End Sub

    Protected Sub Button_elzi_loads_competition_page_Click(sender As Object, e As EventArgs)

        'otestovať, či bolo zvolené "testovanie" alebo "hra"
        If RadioButtonList1_SelectedIndexChanged(sender, e) Then
            Session("meno_hraca_z_default") = "Elzička"
            Response.Redirect("competition.aspx")
        Else
            Label_1sprava.Text = "Vyber ""testovanie"" alebo ""hra""."
            Label_1sprava.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' RadioButtonList na voľbu "testovanie" alebo "hra".
    ''' Tejto voľbe sa potom použije príslušné "query"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Protected Function RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) As Boolean
        If RadioButtonList1.SelectedValue = "1" Then
            Session("tabulka") = "test"
            Return True

        ElseIf RadioButtonList1.SelectedValue = "2" Then
            Session("tabulka") = "hra"
            Return True

        Else
            Return False
        End If
    End Function

End Class