'*********************** In the name of Allah, Most Merciful, Most Compassionate ****************
Imports System.Data.SqlClient
Imports System.Xml

Module Common

    Public Con As SqlConnection
    Public SQL As String = ""
    Public ConStr As String = "Data Source=192.168.0.220;Initial Catalog=eWarehouse1213;user id=sa;password=sa#999s%5"
    'Public ConStr As String = ""
    'Public ConStr As String = "Data Source=DEV-PC;Initial Catalog=eWarehouse1213;user id=sa;password=essa123"
    Public ShopID As Byte = 0
    Public ShopCode As String = ""
    Public ShopNm As String = ""
    Public UserID As Byte = 1
    Public UserName As String
    Public IsAdmin As Boolean
    Public SDate As Date
    Public EDate As Date
    Public TerminalID As SByte
    Public POSPrinterName As String = ""
    Public BarcodeFormat As String = ""
    Public BarcodeFileLocation As String = ""
    Public BarcodeBatchLocation As String = ""
    Public ExportFileLocation As String = ""
    Public wSpaceWidth As Short = 0
    Public wSpaceHeight As Short = 0
    Public TaxVersion As Short = 0


    Dim One(19) As String
    Dim Ten(9) As String
    Dim Value(6) As String
    Dim Rup As Double
    Dim RupS As String
    Dim Temp As String
    Dim str As String

    Public Function Rupees(ByVal Rup As Double) As String
        On Error Resume Next
        Call Init()
        Dim vale As Integer
        vale = 1
        str = ""
        Temp = ""

        'Rup = Val(Text1.Text)
        RupS = Format(Rup, "000000000.00")
        For I = 1 To 12 Step 2
            If I = 10 Then I = 11
            If I = 7 Then
                Temp = Mid(RupS, I, 1)
                I = 6
            Else
                Temp = Mid(RupS, I, 2)
            End If

            If Val(Temp) > 0 Then
                If Val(Temp) < 20 Then
                    If Val(Mid(RupS, I + 2, Len(RupS))) <= 0 And (Rup > 100 Or Val(Mid(RupS, InStr(RupS, ".") + 1, 2)) > 0) Then str = str & "and "
                    If I = 11 Then str = str & Value(vale)
                    str = str & One(Val(Temp))
                    If I < 11 Then str = str & Value(vale)
                    'If I = 6 And Val(Mid(RupS, I + 2, 2)) > 0 Then str = str & "and "
                    If I = 6 And Val(Mid(RupS, I + 2, 2)) > 0 And Val(Mid(RupS, InStr(RupS, ".") + 1, 2)) > 0 Then str = str & "and "
                ElseIf Val(Temp) >= 20 Then

                    'If Val(Mid(RupS, i + 2, Len(RupS))) <= 0 And Rup > 100 Then str = str & "and "

                    If Val(Mid(RupS, I + 2, Len(RupS))) <= 0 And (Rup > 100 Or Val(Mid(RupS, InStr(RupS, ".") + 1, 2)) > 0) Then str = str & "and "
                    If I = 11 Then str = str & Value(vale)
                    str = str & Ten(Val(Mid(Temp, 1, 1)))
                    str = str & One(Val(Mid(Temp, 2, 1)))
                    If I < 11 Then str = str & Value(vale)
                    If I = 6 And Val(Mid(RupS, I + 2, 2)) > 0 And Val(Mid(RupS, InStr(RupS, ".") + 1, 2)) > 0 Then str = str & "and "
                End If
            End If
            vale = vale + 1
        Next I

        Dim Tmp = Rup - Int(Rup)

        If Tmp > 0 Then
            str = str.Replace("Paise ", "")
            str &= "Paise Only."
        Else
            str = str & "Only."
        End If

        Rupees = str

    End Function


    Private Sub Init()
        One(1) = "One "
        One(2) = "Two "
        One(3) = "Three "
        One(4) = "Four "
        One(5) = "Five "
        One(6) = "Six "
        One(7) = "Seven "
        One(8) = "Eight "
        One(9) = "Nine "
        One(10) = "Ten "
        One(11) = "Eleven "
        One(12) = "Twelve "
        One(13) = "Thirteen "
        One(14) = "Fourteen "
        One(15) = "Fifteen "
        One(16) = "Sixteen "
        One(17) = "Seventeen "
        One(18) = "Eighteen "
        One(19) = "Ninteen "

        Ten(2) = "Twenty "
        Ten(3) = "Thirty "
        Ten(4) = "Fourty "
        Ten(5) = "Fifty "
        Ten(6) = "Sixty "
        Ten(7) = "Seventy "
        Ten(8) = "Eighty "
        Ten(9) = "Ninty "


        Value(1) = "Crore "
        Value(2) = "Lakh "
        Value(3) = "Thousand "
        Value(4) = "Hundred "
        Value(5) = ""
        Value(6) = "Paise "
    End Sub

    Public Sub isDevelopmentMode()

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\StoreSettings.xml") = True Then

            Dim xDoc As XmlReader = XmlReader.Create(My.Application.Info.DirectoryPath & "\StoreSettings.xml")
            While xDoc.Read
                If xDoc.Name = "DBSettings" Then
                    ConStr = ClsEncodeDecode.DCode(xDoc.ReadElementString("DBSettings"))
                ElseIf xDoc.Name = "ShopCode" Then
                    ShopCode = xDoc.ReadElementString("ShopCode")
                End If
            End While
            xDoc.Close()

        End If

        Dim username As String = "admin"
        Dim password As String = "nimdaessa"

        SQL = "select userid,username,isadmin from users where username='" _
         & username & "' and password='" & ClsEncodeDecode.Encode(password) & "'"

        With ESSA.OpenReader(SQL)
            If .Read Then
                UserID = .Item(0)
                username = .GetString(1).Trim
                IsAdmin = IIf(.Item(2) = 0, False, True)
            End If

            .Close()

        End With

        LoadAppSettings()

    End Sub

    Private Sub LoadAppSettings()

        SQL = "select * from settings"
        With ESSA.OpenReader(SQL)
            While .Read
                If .GetString(0) = "LableFormat" Then
                    BarcodeFormat = .GetString(1).Trim
                ElseIf .GetString(0) = "BarcodeFileLocation" Then
                    BarcodeFileLocation = .GetString(1).Trim
                ElseIf .GetString(0) = "BarcodeBatchLocation" Then
                    BarcodeBatchLocation = .GetString(1).Trim
                ElseIf .GetString(0) = "POSPrinterName" Then
                    POSPrinterName = .GetString(1).Trim
                ElseIf .GetString(0) = "ExportFileLocation" Then
                    ExportFileLocation = .GetString(1).Trim
                End If
            End While
            .Close()
        End With

    End Sub

    Public Function SqlDate(value As Date) As String

        Return Format(value, "yyyy-MM-dd")

    End Function

End Module
