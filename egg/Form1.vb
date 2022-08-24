Imports System.Data.SqlClient


Public Class Form1

    Dim table1 As New DataTable
    Dim con As New SqlConnection
    Dim query As String


    'DataGridView Details-----
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DBConnection.connect()

        table1.Columns.Add("Egg Category", Type.GetType("System.String"))
        table1.Columns.Add("Qty", Type.GetType("System.String"))
        DataGridView1.DataSource = table1
        If con.State = ConnectionState.Open Then
            con.Close()
        End If


        '----ComboCompany Items------

        ComboCompany.Items.Add("FARMS PRIDE (PVT) LTD")
        ComboCompany.Items.Add("MIDLAND BREEDERS (PVT) LTD")
        ComboCompany.Items.Add("GOLDEN GRAINS (PVT) LTD")
        ComboCompany.Items.Add("HARE PARK DAIRY (PVT) LTD")
        ComboCompany.Items.Add("CONSOLIDATED")
        ComboCompany.Items.Add("ALTRA GUARD")
        ComboCompany.Items.Add("WAYAMBA DEVELOPMENT (PVT) LTD")
        ComboCompany.Items.Add("FORTUNE AGRO INDUSTRIES (PVT) LTD")
        ComboCompany.Items.Add("CASUAL WAGES - PPL")
        ComboCompany.Items.Add("CRYSBRO AUTO SERVICE")

    End Sub

    Private Sub ComboCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCompany.SelectedIndexChanged
        ComboLocation.Items.Clear()

        'Company Locations

        If ComboCompany.SelectedItem = "FARMS PRIDE (PVT) LTD" Then

            ComboLocation.Items.Add("CONSOLIDATED  ")
            ComboLocation.Items.Add("NORTH ")
            ComboLocation.Items.Add("CENTRAL")
            ComboLocation.Items.Add("UVA & EAST")
            ComboLocation.Items.Add("HABARANA AREA")
            ComboLocation.Items.Add("IPOLOGAMA AREA")
            ComboLocation.Items.Add("GAMPOLA AREA")
            ComboLocation.Items.Add("MATALE AREA")
            ComboLocation.Items.Add("MAHIYANGANAYA AREA")
            ComboLocation.Items.Add("DEHIATTHAKANDIYA AREA")
            ComboLocation.Items.Add("CG - NORTH CENTRAL")
            ComboLocation.Items.Add("GANEWALPOLA")
            ComboLocation.Items.Add("PADIKARAMADUWA - 1")
            ComboLocation.Items.Add("NEKATHUNAWEWA")
            ComboLocation.Items.Add("NETHIYAGAMA")
            ComboLocation.Items.Add("IPOLOGAMA - 1")
            ComboLocation.Items.Add("EPPAWALA")
            ComboLocation.Items.Add("SELESTIMADUWA")
            ComboLocation.Items.Add("GALKULAMA - 1")
            ComboLocation.Items.Add("VILACHCHIYA")
            ComboLocation.Items.Add("GAMPOLA - 1")
            ComboLocation.Items.Add("DAMBULLA")
            ComboLocation.Items.Add("BAKAMOONA - 1")
            ComboLocation.Items.Add("MAPAKADAWEWA - 1")
            ComboLocation.Items.Add("BIBILE - 1")
            ComboLocation.Items.Add("SADUNPURA - 1")
            ComboLocation.Items.Add("BANDANAGALA - 1")
            ComboLocation.Items.Add("MADIRIGIRIYA")
            ComboLocation.Items.Add("GAMPOLA - GATE")
            ComboLocation.Items.Add("PPL - GATE")
            ComboLocation.Items.Add("BATTARAMULLA - GATE")
            ComboLocation.Items.Add("BALAPITIYA - GATE")
            ComboLocation.Items.Add("PUPURESSA REGION")
            ComboLocation.Items.Add("PUPURESSA AREA")
            ComboLocation.Items.Add("PUPURESSA")
            ComboLocation.Items.Add("HABARANA - GATE")
            ComboLocation.Items.Add("MAPAKADAWEWA - GATE")
            ComboLocation.Items.Add("PROCESSING PLANT")
            ComboLocation.Items.Add("DAMBULLA - GATE")
            ComboLocation.Items.Add("PUPURESSA - GATE")
            ComboLocation.Items.Add("SADUNPURA - GATE")
            ComboLocation.Items.Add("TRANSPORT")
            ComboLocation.Items.Add("GAMPOLA - HO")
            ComboLocation.Items.Add("BALAPITIYA - 1")
            ComboLocation.Items.Add("FARMS PRIDE")
            ComboLocation.Items.Add("CG-CENTRAL")
            ComboLocation.Items.Add("TESS AGRO - GATE")
            ComboLocation.Items.Add("BATTARAMULLA - STO")
            ComboLocation.Items.Add("LAB")
            ComboLocation.Items.Add("FINLAY GATE")
            ComboLocation.Items.Add("GOLDEN GRAINS PROJECT")
            ComboLocation.Items.Add("GALGAMUWA")
            ComboLocation.Items.Add("GALGAMUWA (WD)")
            ComboLocation.Items.Add("GAMPOLA - FMG")
            ComboLocation.Items.Add("FPP - STORE")
            ComboLocation.Items.Add("GAMPOLA - 1 (WD)")
            ComboLocation.Items.Add("SISILCO - GATE")
            ComboLocation.Items.Add("SBO")
            ComboLocation.Items.Add("KADUWELA - GATE")
            ComboLocation.Items.Add("ULHITIYA_GATE")
            ComboLocation.Items.Add("ULHITIYA")
            ComboLocation.Items.Add("GG-MAH")
            ComboLocation.Items.Add("FAIRLINE")
            ComboLocation.Items.Add("GAMPOLA (TECH)")
            ComboLocation.Items.Add("KOSMO FARM")
            ComboLocation.Items.Add("WARIYAPOLA")
            ComboLocation.Items.Add("MILAN FARM")
            ComboLocation.Items.Add("Colombo 01 ")
            ComboLocation.Items.Add("Colombo 02")
            ComboLocation.Items.Add("Central 01")
            ComboLocation.Items.Add("Central 02")
            ComboLocation.Items.Add("Down South")
            ComboLocation.Items.Add("Institution")
            ComboLocation.Items.Add("HR & Admin")
            ComboLocation.Items.Add("Finance")
            ComboLocation.Items.Add("IT")
            ComboLocation.Items.Add("Management")
            ComboLocation.Items.Add("KOSMO - GATE")
            ComboLocation.Items.Add("KOSMO")
            ComboLocation.Items.Add("TRANSPORT")


        ElseIf ComboCompany.SelectedItem = "MIDLAND BREEDERS (PVT) LTD" Then

            ComboLocation.Items.Add("BREEDER")
            ComboLocation.Items.Add("NAWALAPITIYA")
            ComboLocation.Items.Add("PARAGALA")
            ComboLocation.Items.Add("FAIRLINE")
            ComboLocation.Items.Add("HATCHERY")
            ComboLocation.Items.Add("FAIRLENE - GATE")
            ComboLocation.Items.Add("PARAGALA - GATE")
            ComboLocation.Items.Add("NAWALAPITIYA - GATE")
            ComboLocation.Items.Add("HATCHERY - GATE")
            ComboLocation.Items.Add("LAB")
            ComboLocation.Items.Add("MIDLAND BREEDERS")
            ComboLocation.Items.Add("GAMPOLA - 1")
            ComboLocation.Items.Add("GAMPOLA - 1")
            ComboLocation.Items.Add("GAMPOLA - HO")
            ComboLocation.Items.Add("TRANSPORT")
            ComboLocation.Items.Add("PPL")
            ComboLocation.Items.Add("GALGAMUWA")
            ComboLocation.Items.Add("GOLDEN GRAINS-NC")

        ElseIf ComboCompany.SelectedItem = "GOLDEN GRAINS (PVT) LTD" Then
            ComboLocation.Items.Add("GOLDEN GRAINS")
            ComboLocation.Items.Add("MAHIYANGANA")
            ComboLocation.Items.Add("KANTHALE")
            ComboLocation.Items.Add("MAHIYANGANA(GG) - GATE")
            ComboLocation.Items.Add("KANTHALE(GG) - GATE")
            ComboLocation.Items.Add("GAMPOLA - 1")
            ComboLocation.Items.Add("GAMPOLA - HO")
            ComboLocation.Items.Add("GAMPOLA - FMG")
            ComboLocation.Items.Add("HEBARAWA - GATE")
            ComboLocation.Items.Add("TRANSPORT")

        ElseIf ComboCompany.SelectedItem = "HARE PARK DAIRY (PVT) LTD" Then
            ComboLocation.Items.Add("GALABODA")
            ComboLocation.Items.Add("HARE PARK DAIRY (PVT) LTD")

        ElseIf ComboCompany.SelectedItem = "CONSOLIDATED" Then
            ComboLocation.Items.Add("MAIN STORES")
            ComboLocation.Items.Add("WAYAMBA")
            ComboLocation.Items.Add("WAYAMBA AREA")
            ComboLocation.Items.Add("GALGAMUWA - GATE")
            ComboLocation.Items.Add("PPL - 2")

        ElseIf ComboCompany.SelectedItem = "ALTRA GUARD" Then
            ComboLocation.Items.Add("ALTRA GUARD")

        ElseIf ComboCompany.SelectedItem = "WAYAMBA DEVELOPMENT (PVT) LTD" Then
            ComboLocation.Items.Add("GAMPOLA - HO ")
            ComboLocation.Items.Add("LAB")
            ComboLocation.Items.Add("TRANSPORT")

        ElseIf ComboCompany.SelectedItem = "FORTUNE AGRO INDUSTRIES (PVT) LTD" Then
            ComboLocation.Items.Add("FORTUNE AGRO INDUSTRIES")
            ComboLocation.Items.Add("KURUNAGALA AREA")
            ComboLocation.Items.Add("FORTUNE AGRO")
            ComboLocation.Items.Add("FORTUNE AGRO - GATE")
            ComboLocation.Items.Add("GAMPOLA - HO")
            ComboLocation.Items.Add("FORTUNE AGRO INDUSTRIES(PVT) LTD")
            ComboLocation.Items.Add("FORTUNE-GP INDUSTRIES")
            ComboLocation.Items.Add("GALEWELA")
            ComboLocation.Items.Add("GP HATCHERY")
            ComboLocation.Items.Add("MONARAGALA AREA")
            ComboLocation.Items.Add("FORTUNE AGRO - (SYD)")
            ComboLocation.Items.Add("SIYAMBALANDUWA_GATE")
            ComboLocation.Items.Add("ANURADHAPURA AREA")
            ComboLocation.Items.Add("FORTUNE AGRO - (THALAWA)")
            ComboLocation.Items.Add("THALAWA_GATE")
            ComboLocation.Items.Add("GP CHICKS")

        ElseIf ComboCompany.SelectedItem = "CASUAL WAGES - PPL" Then
            ComboLocation.Items.Add("")

        ElseIf ComboCompany.SelectedItem = "CRYSBRO AUTO SERVICE" Then
            ComboLocation.Items.Add("")
        End If

        'Company ID

        If ComboCompany.Text = "FARMS PRIDE (PVT) LTD" Then
            cid.Text = 1

        ElseIf ComboCompany.Text = "MIDLAND BREEDERS (PVT) LTD" Then
            cid.Text = 2

        ElseIf ComboCompany.Text = "GOLDEN GRAINS (PVT) LTD" Then
            cid.Text = 3

        ElseIf ComboCompany.Text = "HARE PARK DAIRY (PVT) LTD" Then
            cid.Text = 4

        ElseIf ComboCompany.Text = "CONSOLIDATED" Then
            cid.Text = 5

        ElseIf ComboCompany.Text = "ALTRA GUARD" Then
            cid.Text = 6

        ElseIf ComboCompany.Text = "WAYAMBA DEVELOPMENT (PVT) LTD" Then
            cid.Text = 7

        ElseIf ComboCompany.Text = "FORTUNE AGRO INDUSTRIES (PVT) LTD" Then
            cid.Text = 8

        ElseIf ComboCompany.Text = "CASUAL WAGES - PPL" Then
            cid.Text = 9

        ElseIf ComboCompany.Text = "CRYSBRO AUTO SERVICE" Then
            cid.Text = 10

        End If
    End Sub


    'save button
    'Insert,Save Query
    'Date & DataBae Query
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim getDate As Date = Date.Now
        Dim addDate As String = getDate.ToString(" yyyy-MM-dd ")
        query = "INSERT into egg values ((Select ISNULL(MAX(SANo)+1,1) From egg),'" & addDate & "','" & ComboCompany.Text & "','" & ComboLocation.Text & "','" & TextRemark.Text & "','" & cid.Text & "')"
        If (DBConnection.ExecuteSql(query)) Then
            MsgBox("Save To Details")
        End If
    End Sub

    'GridView Form--------
    'Add Button ----------
    'EggCategory DataBase Details
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        table1.Rows.Add(ComboEggCategory.Text.Trim, TextQty.Text.Trim)
        DataGridView1.DataSource = table1

        query = "INSERT into EggCategory values('" & ComboEggCategory.Text & "','" & TextQty.Text & "')"
        If (DBConnection.ExecuteSql(query)) Then
        End If
    End Sub

    'To Close Btn
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    'New Button----------
    'Clear to All Details
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextSANo.Text = ""
        TextRemark.Text = ""
        TextQty.Text = ""
        ComboCompany.Text = ""
        ComboLocation.Text = ""
        ComboEggCategory.Text = ""
        cid.Text = ""
    End Sub


End Class

