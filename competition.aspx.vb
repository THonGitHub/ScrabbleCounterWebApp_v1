Imports MySql.Data.MySqlClient
''' <summary>
''' Na stránke sa zobrazí meno hráča na ťahu, ktoré je totožné s menom na ktoré sa kliklo
''' na stránke default1.aspx pre spustenie počítadla.
''' To isté meno sa zobrazí ako meno hráča, ktorý začal hru. Toto meno sa počas celej hry nemení.
''' Meno hráča na ťahu sa strieda podľa toho, ktorý hráč je na ťahu.
''' V poli "Číslo ťahu" sa zobrazuje a postupne zvyšuje aktuálne číslo ťahu hráčov.
''' V časti "Priebežný stav hry" sa pre každého z hráčov zobrazuje hodnota akutálne zadaného
''' slova, zároveň súčet hodnôt slov od začiatku hry a taktiež najvyššia hodnota doteray zadaných slov.
''' Na konci hry treba zadať hodnoty za nepoužité písmená (ako záporné čísla) a tieto sa odpočítajú
''' z celkového súčtu bodov každého hráča.
''' Stlačením tlačítka "Koniec hry a vyhodnotenie výsledkov" sa zobrazí stránka results.aspx.
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>

Public Class competition
    Inherits System.Web.UI.Page
    Public query As String
    Public body_za_slovo_elzi As String
    Public body_za_slovo_tomas As String
    Public body_spolu_elzi As String
    Public body_spolu_tomas As String

    ''' <summary>
    ''' Definovanie premennej "Body_pocas_hry"
    ''' </summary>
    ''' <returns></returns>
    Private Property Body_pocas_hry As String
        Get
            If Session("Body_pocas_hry") IsNot Nothing Then
                Return Session("Body_pocas_hry").ToString()
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal value As String)
            Session("Body_pocas_hry") = value
        End Set
    End Property

    ''' <summary>
    ''' čo sa vykoná pri načítaní stránky competition.aspx
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim defaultClass As New _default

        If Not IsPostBack Then

            'do poľa "číslo ťahu" dať 1
            Label_cislo_tahu.Text = "1"

            'meno začínajúceho hráča dať do príslušných polí
            If Session("meno_hraca_z_default") IsNot Nothing Then
                Dim meno_hraca As String = Session("meno_hraca_z_default").ToString()
                Label_meno_hraca_na_tahu.Text = meno_hraca
                Label_tuto_hru_zacal.Text = meno_hraca
            End If

            'zobraziť doterajší rekord v bodoch za slovo
            TableCell_datum_vytvorenia_rekordu_najviac_bodov_za_slovo.Text = Session("datum_rekordu")
            TableCell_drzitel_rekordu_najviac_bodov_za_slovo.Text = Session("Drzitel_rekordu_za_slovo")
            TableCell_bodova_hodnota_rekordu_najviac_bodov_za_slovo.Text = Session("Rekord_body_za_slovo")

            'zobraziť doterajší rekord v bodoch za hru
            If Session("Rekord_body_za_hru_elzi") > Session("Rekord_body_za_hru_tomas") Then
                TableCell_bodova_hodnota_rekordu_najviac_bodov_za_hru.Text = Session("Rekord_body_za_hru_elzi")
                TableCell_drzitel_rekordu_najviac_bodov_za_hru.Text = "Elzička"
                TableCell_datum_vytvorenia_rekordu_najviac_bodov_za_hru.Text = Session("datum_rekordu_za_hru_elzi")
            Else
                TableCell_bodova_hodnota_rekordu_najviac_bodov_za_hru.Text = Session("Rekord_body_za_hru_tomas")
                TableCell_drzitel_rekordu_najviac_bodov_za_hru.Text = "Tomáš"
                TableCell_datum_vytvorenia_rekordu_najviac_bodov_za_hru.Text = Session("datum_rekordu_za_hru_tomas")
            End If
        End If

        'zaistiť, že pole na zadávanie bodov bude vždy aktívne
        If ScriptManager1.IsInAsyncPostBack Then
            ScriptManager.RegisterStartupScript(TextBox_zadat_body_za_slovo, TextBox_zadat_body_za_slovo.GetType(), "SetFocusScript", "$get('" & TextBox_zadat_body_za_slovo.ClientID & "').focus();", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "SetFocusScript", "$get('" & TextBox_zadat_body_za_slovo.ClientID & "').focus();", True)
        End If

    End Sub

    ''' <summary>
    ''' čo sa má vykonať po zadaní čísla a stlačení ENTER
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub TextBox_zadat_body_za_slovo_TextChanged(sender As Object, e As EventArgs)

        Dim input As String = TextBox_zadat_body_za_slovo.Text.Trim()

        'skontrolovať, či na vstupe bolo zadané číslo alebo písmeno
        Dim input_INT As Integer
        Dim input_Char As Char
        Dim isChar As Boolean = Char.TryParse(input, input_Char)
        Dim isInteger As Boolean = Integer.TryParse(input, input_INT)

        'ak bol zadaný INTEGER
        If isInteger Then
            If input_INT <> 0 Then

                Pridat_body_za_slovo(input)

            ElseIf input_INT = 0 Then

                Label_2sprava.Text = "Zadal si 0. Bude hráč v tomto kole stáť? Vyber a/n"
                Label_2sprava.Visible = True
            End If

            'ak bolo zadané písmeno
        ElseIf isChar Then

            If input.Length = 1 Then

                'ak sa stlačilo a - znamená to, že hráč stojí a priráta sa mu nula bodov
                If input.ToLower = "a" Then
                    Label_2sprava.Text = "Stlačil si [a], hráč bude stáť."
                    Label_2sprava.Visible = True
                    'hráčovi sa priráto 0 bodov
                    Pridat_body_za_slovo(0)
                    Label_2sprava.Visible = False

                    'ak sa stlačilo n, znamená to, že hráč nestojí a pokračuje v hre
                ElseIf input.ToLower = "n" Then
                    Label_2sprava.Text = "Stlačil si [n], hráč pokračuje v hre."

                End If
                Label_2sprava.Visible = False
            End If
        End If

        ' Label_cislo_tahu.Text = cislo_tahu.ToString()
        TextBox_zadat_body_za_slovo.Text = ""
    End Sub

    ''' <summary>
    ''' Počas prídávania bodov vykonávať aj ďalšie operácie:
    ''' - pripočítavať body
    ''' - porovnávať hodnoty a meniť pozadie čísel
    ''' - nulovať pomocné počítadlá
    ''' </summary>
    ''' <param name="Input"></param>
    Public Sub Pridat_body_za_slovo(Input As String)

        Dim CurrentDateTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        If Label_meno_hraca_na_tahu.Text = "Elzička" Then

            Label_elzi_body_za_slovo_cislo.Text = Input

            'porovnanie bodov za slovo s maximálnym počtom bodov za slovo
            If CInt(Label_elzi_body_za_slovo_cislo.Text) > CInt(Label_elzi_najviac_bodov_za_slovo.Text) Then
                Label_elzi_najviac_bodov_za_slovo.Text = Label_elzi_body_za_slovo_cislo.Text

            End If

            'prirátanie bodov za slovo k celkovému počtu bodov
            Label_elzi_body_spolu_cislo.Text = CInt(Label_elzi_body_spolu_cislo.Text) + CInt(Input)

            'zobraziť meno nasledujúceho hráča
            Label_meno_hraca_na_tahu.Text = "Tomáš"

            'zmeniť hodnotu na 1 (používa sa na zmenu čísla ťahu)
            Label_1sprava.Text = "1"

        ElseIf Label_meno_hraca_na_tahu.Text = "Tomáš" Then

            Label_tomas_body_za_slovo_cislo.Text = Input

            'porovnanie bodov za slovo s maximálnym počtom bodov za slovo
            If CInt(Label_tomas_body_za_slovo_cislo.Text) > CInt(Label_tomas_najviac_bodov_za_slovo.Text) Then
                Label_tomas_najviac_bodov_za_slovo.Text = Label_tomas_body_za_slovo_cislo.Text
            End If

            'prirátanie bodov za slovo k celkovému počtu bodov
            Label_tomas_body_spolu_cislo.Text = CInt(Label_tomas_body_spolu_cislo.Text) + CInt(Input)

            'zobraziť meno nasledujúceho hráča
            Label_meno_hraca_na_tahu.Text = "Elzička"

            'zmeniť hodnotu na 1 (používa sa na zmenu čísla ťahu)
            Label_2sprava.Text = "1"
        End If

        'porovnávanie počtu bodov kvoli zmenám farieb pozadia

        'porovnanie najväčšieho počtu bodov za slovo
        If CInt(Label_elzi_najviac_bodov_za_slovo.Text) > CInt(Label_tomas_najviac_bodov_za_slovo.Text) Then
            div_elzi_najviac_bodov_za_slovo.Style("background-color") = "LightGreen"
            div_tomas_najviac_bodov_za_slovo.Style("background-color") = "LightPink"
        ElseIf CInt(Label_elzi_najviac_bodov_za_slovo.Text) < CInt(Label_tomas_najviac_bodov_za_slovo.Text) Then
            div_elzi_najviac_bodov_za_slovo.Style("background-color") = "LightPink"
            div_tomas_najviac_bodov_za_slovo.Style("background-color") = "LightGreen"
        Else
            div_elzi_najviac_bodov_za_slovo.Style("background-color") = "LightBlue"
            div_tomas_najviac_bodov_za_slovo.Style("background-color") = "LightBlue"
        End If

        'porovnanie počtu bodov za slovo
        If CInt(Label_elzi_body_za_slovo_cislo.Text) > CInt(Label_tomas_body_za_slovo_cislo.Text) Then
            div_elzi_body_za_slovo.Style("background-color") = "LightGreen"
            div_tomas_body_za_slovo.Style("background-color") = "LightPink"
        ElseIf CInt(Label_elzi_body_za_slovo_cislo.Text) < CInt(Label_tomas_body_za_slovo_cislo.Text) Then
            div_elzi_body_za_slovo.Style("background-color") = "LightPink"
            div_tomas_body_za_slovo.Style("background-color") = "LightGreen"
        Else
            div_elzi_body_za_slovo.Style("background-color") = "LightBlue"
            div_tomas_body_za_slovo.Style("background-color") = "LightBlue"
        End If

        'porovnanie súčtov bodov
        If CInt(Label_elzi_body_spolu_cislo.Text) > CInt(Label_tomas_body_spolu_cislo.Text) Then
            div_elzi_body_spolu.Style("background-color") = "LightGreen"
            div_tomas_body_spolu.Style("background-color") = "LightPink"
        ElseIf CInt(Label_elzi_body_spolu_cislo.Text) < CInt(Label_tomas_body_spolu_cislo.Text) Then
            div_elzi_body_spolu.Style("background-color") = "LightPink"
            div_tomas_body_spolu.Style("background-color") = "LightGreen"
        Else
            div_elzi_body_spolu.Style("background-color") = "LightBlue"
            div_tomas_body_spolu.Style("background-color") = "LightBlue"
        End If

        'ak sú obe hodnoty = 1, vynulovať pomocné počítadlá a zapísať príslušné hodnoty so tabuľky "Priebeh hry"
        If Label_1sprava.Text = "1" And Label_2sprava.Text = "1" Then
            'vynulovať pomocné počítadlá
            Label_1sprava.Text = "0"
            Label_2sprava.Text = "0"

            'pridať do "Body_pocas_hry" číslo ťahu, body za slová hráčov v danom ťahu, čas ťahu
            Body_pocas_hry += "{
                                """ & Label_cislo_tahu.Text & """, """ & Label_elzi_body_za_slovo_cislo.Text & """, """ & Label_tomas_body_za_slovo_cislo.Text & """,""" & CurrentDateTime & """
                                },"
            'zvýšiť číslo kola o 1
            Label_cislo_tahu.Text = CInt(Label_cislo_tahu.Text) + 1

            'vložiť príslušné hodnoty do premenných pre zápis do DB tabuľky "Priebeh hry"
            body_za_slovo_elzi = CInt(Label_elzi_body_za_slovo_cislo.Text)
            body_za_slovo_tomas = CInt(Label_tomas_body_za_slovo_cislo.Text)
            body_spolu_elzi = CInt(Label_elzi_body_spolu_cislo.Text)
            body_spolu_tomas = CInt(Label_tomas_body_spolu_cislo.Text)

            'po zadaní bodov pre oboch hráčov v danom kole, zavolť Sub na zapísanie hodnút do DB tabuľky
            Zapis_do_tabulky_priebeh_hry(body_za_slovo_elzi, body_za_slovo_tomas, body_spolu_elzi, body_spolu_tomas)
        End If
    End Sub

    ''' <summary>
    ''' Sub vyhodnotí výsledky hry
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Button_koniec_hry_a_vyhodnotenie_vysledkov_Click(sender As Object, e As EventArgs)

        Dim Rekord_body_za_slovo As Integer
        Dim Drzitel_rekordu_za_slovo As String

        'odstrániť čiarku za posledným záznamom a uložiť priebeh hry do session
        Session("Body_pocas_hry") = Body_pocas_hry.Trim(","c) & "]"

        'porovnať
        If CInt(Label_elzi_najviac_bodov_za_slovo.Text) > CInt(Label_tomas_najviac_bodov_za_slovo.Text) Then
            Rekord_body_za_slovo = Label_elzi_najviac_bodov_za_slovo.Text
            Drzitel_rekordu_za_slovo = "Elzička"
        Else
            Rekord_body_za_slovo = Label_tomas_najviac_bodov_za_slovo.Text
            Drzitel_rekordu_za_slovo = "Tomáš"
        End If

        Session("elzi_body_spolu") = Label_elzi_body_spolu_cislo.Text
        Session("tomas_body_spolu") = Label_tomas_body_spolu_cislo.Text

        Dim Elzi_points_for_game As Integer = CInt(Label_elzi_body_spolu_cislo.Text)
        Dim Tomas_points_for_game As Integer = CInt(Label_tomas_body_spolu_cislo.Text)
        Dim Elzi_wins_cumul As Integer = Session("Elzi_wins_cumul")
        Dim Tomas_wins_cumul As Integer = Session("Tomas_wins_cumul")


        'porovnať súčty bodov a určiť, kto je víťaz hry
        If CInt(Label_elzi_body_spolu_cislo.Text) > CInt(Label_tomas_body_spolu_cislo.Text) Then
            Session("vitaz_hry") = "Elzička"
            Elzi_wins_cumul = Elzi_wins_cumul + 1
        ElseIf CInt(Label_elzi_body_spolu_cislo.Text) < CInt(Label_tomas_body_spolu_cislo.Text) Then
            Session("vitaz_hry") = "Tomáš"
            Tomas_wins_cumul = Tomas_wins_cumul + 1
        Else
            Session("vitaz_hry") = "remiza"
        End If

        'zavolať Sub na zápis výsledkov hry do DB tabuľky
        Zapis_do_tabulky_GameCounter_results(Elzi_points_for_game, Tomas_points_for_game, Elzi_wins_cumul, Tomas_wins_cumul, Rekord_body_za_slovo, Drzitel_rekordu_za_slovo, Body_pocas_hry)

        'otvoriť nasledujúcu stránku "results.aspx"
        Response.Redirect("results.aspx")
    End Sub

    ''' <summary>
    ''' Sub zapíše výsledky hry do DB tabuľky
    ''' </summary>
    ''' <param name="connectionString"></param>
    ''' <param name="query"></param>
    ''' <param name="Elzi_points_for_game"></param>
    ''' <param name="Tomas_points_for_game"></param>
    ''' <param name="Elzi_wins_cumul"></param>
    ''' <param name="Tomas_wins_cumul"></param>
    Public Sub Zapis_do_tabulky_GameCounter_results(Elzi_points_for_game As Integer, Tomas_points_for_game As Integer, Elzi_wins_cumul As Integer, Tomas_wins_cumul As Integer, Rekord_body_za_slovo As Integer, Drzitel_Rekordu_za_slovo As String, Body_pocas_hry As String)

        Dim connectionString As String = "insert connection string here"

        'vyberie sa tabuľka na zapísanie výsledkov hry podľa toho, či sa zvolilo na stránke default.aspx "testovanie" alebo "hra"
        If Session("tabulka") = "test" Then
            query = "INSERT INTO GameCounter_results_test (
                                        date_time,
                                        Elzi_points_for_game,
                                        Tomas_points_for_game,
                                        Elzi_wins_cumul,
                                        Tomas_wins_cumul,
                                        Rekord_body_za_slovo,
                                        Drzitel_rekordu_za_slovo,
                                        Body_pocas_hry) 
                                    VALUES (
                                        UTC_TIMESTAMP(),
                                        @Elzi_points_for_game,
                                        @Tomas_points_for_game,
                                        @Elzi_wins_cumul,
                                        @Tomas_wins_cumul,
                                        @Rekord_body_za_slovo,
                                        @Drzitel_rekordu_za_slovo,
                                        @Body_pocas_hry)"
        Else
            query = "INSERT INTO GameCounter_results (
                                        date_time,
                                        Elzi_points_for_game,
                                        Tomas_points_for_game,
                                        Elzi_wins_cumul,
                                        Tomas_wins_cumul,
                                        Rekord_body_za_slovo,
                                        Drzitel_rekordu_za_slovo,
                                        Body_pocas_hry) 
                                    VALUES (
                                        UTC_TIMESTAMP(),
                                        @Elzi_points_for_game,
                                        @Tomas_points_for_game,
                                        @Elzi_wins_cumul,
                                        @Tomas_wins_cumul,
                                        @Rekord_body_za_slovo,
                                        @Drzitel_rekordu_za_slovo,
                                        @Body_pocas_hry)"
        End If

        'zapísať výsledky hry do príslušnej DB tabuľky
        Using mydbConnection As New MySqlConnection(connectionString)
            Dim myDbCommand As New MySqlCommand(query, mydbConnection)
            myDbCommand.Parameters.AddWithValue("@Elzi_points_for_game", Elzi_points_for_game)
            myDbCommand.Parameters.AddWithValue("@Tomas_points_for_game", Tomas_points_for_game)
            myDbCommand.Parameters.AddWithValue("@Elzi_wins_cumul", Elzi_wins_cumul)
            myDbCommand.Parameters.AddWithValue("@Tomas_wins_cumul", Tomas_wins_cumul)
            myDbCommand.Parameters.AddWithValue("@Rekord_body_za_slovo", Rekord_body_za_slovo)
            myDbCommand.Parameters.AddWithValue("@Drzitel_rekordu_za_slovo", Drzitel_Rekordu_za_slovo)
            myDbCommand.Parameters.AddWithValue("@Body_pocas_hry", Body_pocas_hry)
            myDbCommand.Connection.Open()
            myDbCommand.ExecuteNonQuery()
            myDbCommand.Connection.Close()
        End Using
    End Sub

    Public Sub Zapis_do_tabulky_priebeh_hry(body_za_slovo_elzi As Integer, body_za_slovo_tomas As Integer, body_spolu_elzi As Integer, body_spolu_tomas As Integer)
        Dim connectionString As String = "insert connection string here"
        query = "INSERT INTO Priebeh_hry (
                                        date_time,
                                        body_za_slovo_elzi,
                                        body_za_slovo_tomas,
                                        body_spolu_elzi,
                                        body_spolu_tomas) 
                                    VALUES (
                                        UTC_TIMESTAMP(),
                                        @body_za_slovo_elzi,
                                        @body_za_slovo_tomas,
                                        @body_spolu_elzi,
                                        @body_spolu_tomas)"

        Using mydbConnection As New MySqlConnection(connectionString)
            Dim myDbCommand As New MySqlCommand(query, mydbConnection)
            'myDbCommand.Parameters.AddWithValue("@date_time", Now())
            myDbCommand.Parameters.AddWithValue("@body_za_slovo_elzi", body_za_slovo_elzi)
            myDbCommand.Parameters.AddWithValue("@body_za_slovo_tomas", body_za_slovo_tomas)
            myDbCommand.Parameters.AddWithValue("@body_spolu_elzi", body_spolu_elzi)
            myDbCommand.Parameters.AddWithValue("@body_spolu_tomas", body_spolu_tomas)
            myDbCommand.Connection.Open()
            myDbCommand.ExecuteNonQuery()
            myDbCommand.Connection.Close()
        End Using
    End Sub

    ''' <summary>
    ''' po kliknutí na tlačítko sa z DB tabuľky načíta a zobrazí priebeh aktuálnej hry
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    'Protected Sub Button_prehlad_aktualnej_hry_Click(sender As Object, e As EventArgs)
    '    'Response.Redirect("PriebehHry.aspx?openInNewTab=True", False)
    '    'ClientScript.RegisterStartupScript(Me.GetType(), "OpenNewTab", "window.open('PriebehHry.aspx', '_blank');", True)
    '    Response.Redirect("PriebehHry.aspx")
    'End Sub

End Class