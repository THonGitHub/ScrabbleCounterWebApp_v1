Public Class results
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Po načítaní stránky sa zobrazí meno víťaza.
    ''' V časti "Bodový stav na konci hry" sa zobrazí pre každého hráča celkový počet víťazstiev
    ''' a súčet bodov za ostatnú (práve skončenú) hru.
    ''' Tlačidlom "Ukončiť počítadlo" ... ?
    ''' Mohol by som toto tlačidlo zmeniť na "návrat na úvodnú stránku" resp. na "nová hra".
    ''' Uvidím.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Elzi_wins_cumul As Integer = Session("Elzi_wins_cumul")
        Label_elzi_pocet_vitazstiev.Text = Elzi_wins_cumul
        Dim Tomas_wins_cumul As Integer = Session("Tomas_wins_cumul")
        Label_tomas_pocet_vitazstiev.Text = Tomas_wins_cumul

        Dim elzi_body_spolu As String = Session("elzi_body_spolu")
        Label_elzi_body_spolu.Text = elzi_body_spolu
        Dim tomas_body_spolu As String = Session("tomas_body_spolu")
        Label_tomas_body_spolu.Text = tomas_body_spolu

        Dim vitaz_hry As String = Session("vitaz_hry")

        If vitaz_hry = "Elzička" Then
            Label_last_winner.Text = "Víťazom tejto hry je:"
            Label_vitaz_tejto_hry.Text = vitaz_hry
            Label_elzi_pocet_vitazstiev.Text = Elzi_wins_cumul + 1

            If CInt(Label_elzi_pocet_vitazstiev.Text) > CInt(Label_tomas_pocet_vitazstiev.Text) Then
                div_elzi_pocet_vitazstiev.Style("background-color") = "LightGreen"
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightPink"

            ElseIf CInt(Label_elzi_pocet_vitazstiev.Text) < CInt(Label_tomas_pocet_vitazstiev.Text) Then
                div_elzi_pocet_vitazstiev.Style("background-color") = "LightPink"
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightGreen"

            ElseIf CInt(Label_elzi_pocet_vitazstiev.Text) = CInt(Label_tomas_pocet_vitazstiev.Text) Then
                div_elzi_pocet_vitazstiev.Style("background-color") = "LightBlue"
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightBlue"

            End If
            div_elzi_body_spolu.Style("background-color") = "LightGreen"
            div_tomas_body_spolu.Style("background-color") = "LightPink"

        ElseIf vitaz_hry = "Tomáš" Then
            Label_last_winner.Text = "Víťazom tejto hry je:"
            Label_vitaz_tejto_hry.Text = vitaz_hry
            Label_tomas_pocet_vitazstiev.Text = Tomas_wins_cumul + 1

            If CInt(Label_tomas_pocet_vitazstiev.Text) > CInt(Label_elzi_pocet_vitazstiev.Text) Then
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightGreen"
                div_elzi_pocet_vitazstiev.Style("background-color") = "LightPink"

            ElseIf CInt(Label_tomas_pocet_vitazstiev.Text) < CInt(Label_elzi_pocet_vitazstiev.Text) Then
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightPink"
                div_elzi_pocet_vitazstiev.Style("background-color") = "LightGreen"

            ElseIf CInt(Label_elzi_pocet_vitazstiev.Text) = CInt(Label_tomas_pocet_vitazstiev.Text) Then

                div_elzi_pocet_vitazstiev.Style("background-color") = "LightBlue"
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightBlue"
            End If

            div_elzi_body_spolu.Style("background-color") = "LightPink"
            div_tomas_body_spolu.Style("background-color") = "LightGreen"

        ElseIf vitaz_hry = "remiza" Then
            Label_last_winner.Text = "Táto hra skončila remízou."
            Label_vitaz_tejto_hry.Visible = False
            div_elzi_body_spolu.Style("background-color") = "LightBlue"
            div_tomas_body_spolu.Style("background-color") = "LightBlue"

            If CInt(Label_elzi_pocet_vitazstiev.Text) > CInt(Label_tomas_pocet_vitazstiev.Text) Then
                div_elzi_pocet_vitazstiev.Style("background-color") = "LightGreen"
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightPink"

            ElseIf CInt(Label_elzi_pocet_vitazstiev.Text) < CInt(Label_tomas_pocet_vitazstiev.Text) Then
                div_elzi_pocet_vitazstiev.Style("background-color") = "LightPink"
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightGreen"

            ElseIf CInt(Label_elzi_pocet_vitazstiev.Text) = CInt(Label_tomas_pocet_vitazstiev.Text) Then
                div_elzi_pocet_vitazstiev.Style("background-color") = "LightBlue"
                div_tomas_pocet_vitazstiev.Style("background-color") = "LightBlue"

            End If
        End If
    End Sub

    Protected Sub Button_nova_hra_Click(sender As Object, e As EventArgs)

        Response.Redirect("default1.aspx")
    End Sub


End Class