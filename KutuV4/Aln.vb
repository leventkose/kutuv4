Public Class Aln
    Enum KarTipi
        TamSayi
        OndalikliSayi
        BuyukHarf
        BuyukHarfRakam
        KucukHarf
        KucukHarfRakam
        SerbestKarekter
    End Enum
    Dim m_AAKarekter As KarTipi = KarTipi.SerbestKarekter
    Dim m_AAEnterTab As Boolean = False
    Event TextDegisti()
    Private Sub Dgr_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Dgr.KeyPress
        If Asc(e.KeyChar) = 13 And m_AAEnterTab = True Then SendKeys.Send("{TAB}") : Exit Sub
        Select Case AAKarekter
            Case KarTipi.BuyukHarf
                If AAKarSay <= Len(Dgr.Text) And Asc(e.KeyChar) > 31 And Dgr.SelectionLength = 0 Then
                    Beep()
                    e.Handled = True
                Else
                    e.KeyChar = CChar(CStr(e.KeyChar).ToString.ToUpper())
                End If
            Case KarTipi.BuyukHarfRakam
                If Asc(e.KeyChar) < 31 Then
                ElseIf AAKarSay <= Len(Dgr.Text) And Dgr.SelectionLength = 0 Then
                    Beep() : e.Handled = True
                ElseIf (Asc(e.KeyChar) < 64 Or Asc(e.KeyChar) > 91) And (Asc(e.KeyChar) > 57 Or Asc(e.KeyChar) < 48) Then
                    Beep() : e.Handled = True
                Else
                    e.KeyChar = CChar(CStr(e.KeyChar).ToString.ToUpper())
                End If
            Case KarTipi.KucukHarf
                If AAKarSay <= Len(Dgr.Text) And Asc(e.KeyChar) > 31 And Dgr.SelectionLength = 0 Then
                    Beep()
                    e.Handled = True
                Else
                    e.KeyChar = CChar(CStr(e.KeyChar).ToString.ToLower())
                End If
            Case KarTipi.KucukHarfRakam
                If Asc(e.KeyChar) < 31 Then
                ElseIf AAKarSay <= Len(Dgr.Text) And Dgr.SelectionLength = 0 Then
                    Beep() : e.Handled = True
                ElseIf (Asc(e.KeyChar) < 96 Or Asc(e.KeyChar) > 123) And (Asc(e.KeyChar) > 57 Or Asc(e.KeyChar) < 48) Then
                    Beep() : e.Handled = True
                Else
                    e.KeyChar = CChar(CStr(e.KeyChar).ToString.ToLower())
                End If
            Case KarTipi.TamSayi
                If Asc(e.KeyChar) < 31 Then
                ElseIf AAKarSay <= Len(Dgr.Text) And Dgr.SelectionLength = 0 Then
                    Beep() : e.Handled = True
                ElseIf IsNumeric(e.KeyChar) = False Then
                    Beep() : e.Handled = True
                End If
            Case KarTipi.OndalikliSayi
                If Asc(e.KeyChar) < 31 Then
                ElseIf e.KeyChar = "," And (InStr(Dgr.Text, ",") > 0 Or Len(Dgr.Text) = 0) Then
                    Beep() : e.Handled = True
                ElseIf e.KeyChar = "," Then
                ElseIf e.KeyChar <> "," And Dgr.SelectionStart - 1 < Len(Dgr.Text.Trim.Split(CChar(","))(0)) And AAKarSay = Len(Dgr.Text.Trim.Split(CChar(","))(0)) And Dgr.SelectionLength = 0 Then
                    Beep() : e.Handled = True
                ElseIf IsNumeric(e.KeyChar) = False Then
                    Beep() : e.Handled = True
                End If
            Case KarTipi.SerbestKarekter
                If AAKarSay <= Len(Dgr.Text) And Asc(e.KeyChar) > 31 And Dgr.SelectionLength = 0 Then Beep() : e.Handled = True
        End Select
    End Sub
    Public Property AAKarekter() As KarTipi
        Get
            AAKarekter = m_AAKarekter
        End Get
        Set(ByVal Value As KarTipi)
            m_AAKarekter = Value
        End Set
    End Property
    Public Overridable Property AAKarSay() As Integer
        Get
            Return Dgr.MaxLength
        End Get
        Set(ByVal Value As Integer)
            Dgr.MaxLength = Value
        End Set
    End Property
    Public Overrides Property Text() As String
        Get
            Return Dgr.Text.Trim
        End Get
        Set(ByVal Value As String)
            Dgr.Text = Value
        End Set
    End Property
    Public Function TextSayiInt() As Integer
        If AAKarekter <> KarTipi.TamSayi Then
            MsgBox("Bu Alan Tamsayi Değil !")
            Return 0
        Else
            If Dgr.Text.Trim = "" Then
                Return 0
            Else
                Return CInt(Val(Dgr.Text.Trim))
            End If
        End If
    End Function
    Public Function TextSayiLng() As Long
        If AAKarekter <> KarTipi.TamSayi Then
            MsgBox("Bu Alan Tamsayi Değil !")
            Return 0
        Else
            If Dgr.Text.Trim = "" Then
                Return 0
            Else
                Return CLng(Val(Dgr.Text.Trim))
            End If
        End If
    End Function
    Public Function TextSayiDcml() As Decimal
        If AAKarekter <> KarTipi.OndalikliSayi Then
            MsgBox("Bu Alan Ondalikli Değil !")
            Return 0
        Else
            If InStr(Dgr.Text.Trim, ",") > 0 Then
                Return CDec(Dgr.Text.Trim.Split(CChar(","))(0).Trim + Mid(CStr(3 / 2).Trim, 2, 1) + Dgr.Text.Trim.Split(CChar(","))(1).Trim)
            Else
                Return CDec(Val(Dgr.Text.Trim))
            End If
        End If
    End Function
    Private Sub Dgr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgr.TextChanged
        RaiseEvent TextDegisti()
    End Sub
    Public Property AAEnterTab() As Boolean
        Get
            AAEnterTab = m_AAEnterTab
        End Get
        Set(ByVal Value As Boolean)
            m_AAEnterTab = Value
        End Set
    End Property
    Public Overridable Property AAScrollBars() As System.Windows.Forms.ScrollBars
        Get
            Return Dgr.ScrollBars
        End Get
        Set(ByVal Value As System.Windows.Forms.ScrollBars)
            Dgr.ScrollBars = Value
        End Set
    End Property
    Public Overridable Property AAPasswordChar() As Char
        Get
            Return Dgr.PasswordChar
        End Get
        Set(ByVal Value As Char)
            Dgr.PasswordChar = Value
        End Set
    End Property
    Public Overridable Property AAMultiLine() As Boolean
        Get
            Return Dgr.Multiline
        End Get
        Set(ByVal Value As Boolean)
            Dgr.Multiline = Value
        End Set
    End Property
    Public Property AAFont() As System.Drawing.Font
        Get
            Return Dgr.Font
        End Get
        Set(ByVal Value As System.Drawing.Font)
            Dgr.Font = Value
        End Set
    End Property
    Public Property AARightToLeft() As System.Windows.Forms.RightToLeft
        Get
            Return Dgr.RightToLeft
        End Get
        Set(ByVal Value As System.Windows.Forms.RightToLeft)
            Dgr.RightToLeft = Value
        End Set
    End Property
    Private Sub Gnl_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        Dgr.Height = Me.Height - 1
        Dgr.Width = Me.Width - 1
    End Sub
    Private Sub Dgr_SizeChanged(sender As Object, e As System.EventArgs) Handles Dgr.SizeChanged
        Dgr.Height = Me.Height - 1
        Dgr.Width = Me.Width - 1
    End Sub
End Class
