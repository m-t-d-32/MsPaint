Public Class Form1
    Dim programname = "画图"
    Dim img As Bitmap
    Dim drawing As Boolean = False
    Dim imggra As Graphics
    Dim imgpen As Pen
    Dim nowcolor As Color = Color.Black
    Enum things
        PENCIL
        ERASER
        GETCOLOR
        FILL
        LINE
        CIRCLE
    End Enum
    Dim nowthing As things
    Dim lastpoint As New Point
    Dim fillcolor As Color
    Dim addedimg As Image
    Dim imgflex As Color(,)
    Dim neversaved = True
    Dim hassaved = True
    Dim NowFile As String = "*.bmp"
    Dim NowTitle As String = "无标题"

    Private Sub Fill(x As Integer, y As Integer)
        Dim judge(,) As Boolean
        ReDim judge(img.Width, img.Height)
        For i = 0 To img.Width
            For j = 0 To img.Height
                judge(i, j) = False
            Next
        Next
        Dim spaces As New Queue(Of Point)
        spaces.Enqueue(New Point(x, y))
        Dim tempx, tempy As Integer
        Do While spaces.Count > 0
            Dim p As Point = spaces.Dequeue
            img.SetPixel(p.X, p.Y, nowcolor)
            If p.X - 1 > 0 Then
                tempx = p.X - 1 : tempy = p.Y
                If img.GetPixel(tempx, tempy) = fillcolor And judge(tempx, tempy) = False Then
                    spaces.Enqueue(New Point(tempx, tempy))
                    judge(tempx, tempy) = True
                End If
            End If
            If p.Y - 1 > 0 Then
                tempx = p.X : tempy = p.Y - 1
                If img.GetPixel(tempx, tempy) = fillcolor And judge(tempx, tempy) = False Then
                    spaces.Enqueue(New Point(tempx, tempy))
                    judge(tempx, tempy) = True
                End If
            End If
            If p.X + 1 < img.Width Then
                tempx = p.X + 1 : tempy = p.Y
                If img.GetPixel(tempx, tempy) = fillcolor And judge(tempx, tempy) = False Then
                    spaces.Enqueue(New Point(tempx, tempy))
                    judge(tempx, tempy) = True
                End If
            End If
            If p.Y + 1 < img.Height Then
                tempx = p.X : tempy = p.Y + 1
                If img.GetPixel(tempx, tempy) = fillcolor And judge(tempx, tempy) = False Then
                    spaces.Enqueue(New Point(tempx, tempy))
                    judge(tempx, tempy) = True
                End If
            End If
        Loop

    End Sub
    Private Sub begindraw(ByVal e As Point)
        Select Case nowthing
            Case things.PENCIL
                drawing = True
                lastpoint.x = e.X
                lastpoint.Y = e.Y
                imgpen.Width = 2
                imgpen.Color = nowcolor
            Case things.ERASER
                drawing = True
                lastpoint.X = e.X
                lastpoint.Y = e.Y
                imgpen.Width = 10
                imgpen.Color = Color.White
            Case things.LINE
                drawing = True
                lastpoint.X = e.X
                lastpoint.Y = e.Y
                imgpen.Width = 2
                imgpen.Color = nowcolor
            Case things.GETCOLOR
                nowcolor = img.GetPixel(e.X, e.Y)
                ShowColor.BackColor = nowcolor
            Case things.FILL
                fillcolor = img.GetPixel(e.X, e.Y)
                If fillcolor.ToArgb() <> nowcolor.ToArgb Then
                    Fill(e.X, e.Y)
                End If
                PictureLoc.Image = img
            Case things.CIRCLE
                drawing = True
                lastpoint.X = e.X
                lastpoint.Y = e.Y
                imgpen.Width = 2
                imgpen.Color = nowcolor
        End Select
    End Sub
    Private Sub enddraw(ByVal e As Point)
        Select Case nowthing
            Case things.PENCIL
                drawing = False
            Case things.ERASER
                drawing = False
            Case things.LINE
                If (e.X <> -1) Then
                    imggra.DrawLine(imgpen, lastpoint, e)
                    PictureLoc.Image = img
                End If
                drawing = False
            Case things.CIRCLE
                If (e.X <> -1) Then
                    imggra.DrawEllipse(imgpen, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y)
                    PictureLoc.Image = img
                End If
                drawing = False
        End Select
    End Sub
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        img = New Bitmap(PictureLoc.Width, PictureLoc.Height)
        PictureLoc.Image = img
        imggra = Graphics.FromImage(img)
        imgpen = New Pen(Brushes.Black)
        ShowColor.BackColor = nowcolor
        Me.Text = NowTitle + " - " + programname
    End Sub

    Private Sub PictureLoc_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureLoc.MouseDown
        begindraw(New Point(e.X, e.Y))
    End Sub

    Private Sub PictureLoc_MouseLeave(sender As Object, e As EventArgs) Handles PictureLoc.MouseLeave
        enddraw(New Point(-1, -1))
    End Sub

    Private Sub PictureLoc_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureLoc.MouseMove
        If drawing = True Then
            hassaved = False
            Select Case nowthing
                Case things.PENCIL
                    imggra.DrawLine(imgpen, lastpoint, New Point(e.X, e.Y))
                    lastpoint.X = e.X
                    lastpoint.Y = e.Y
                    PictureLoc.Image = img
                Case things.ERASER
                    imggra.DrawLine(imgpen, lastpoint, New Point(e.X, e.Y))
                    lastpoint.X = e.X
                    lastpoint.Y = e.Y
                    PictureLoc.Image = img
                Case things.LINE
                    Dim tempimg As Bitmap = New Bitmap(img)
                    Dim tempgra = Graphics.FromImage(tempimg)
                    tempgra.DrawLine(imgpen, lastpoint.X, lastpoint.Y, e.X, e.Y)
                    PictureLoc.Image = tempimg
                Case things.CIRCLE
                    Dim tempimg As Bitmap = New Bitmap(img)
                    Dim tempgra = Graphics.FromImage(tempimg)
                    tempgra.DrawEllipse(imgpen, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y)
                    PictureLoc.Image = tempimg
            End Select
        End If
    End Sub

    Private Sub PictureLoc_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureLoc.MouseUp
        enddraw(New Point(e.X, e.Y))
    End Sub
    Private Sub PencilCmd_Click(sender As Object, e As EventArgs) Handles PencilCmd.Click
        nowthing = things.PENCIL
    End Sub
    Private Sub EraserCmd_Click(sender As Object, e As EventArgs) Handles EraserCmd.Click
        nowthing = things.ERASER
    End Sub

    Private Sub LineCmd_Click(sender As Object, e As EventArgs) Handles LineCmd.Click
        nowthing = things.LINE
    End Sub

    Private Sub GetColorCmd_Click(sender As Object, e As EventArgs) Handles GetColorCmd.Click
        nowthing = things.GETCOLOR
    End Sub

    Private Sub FillCmd_Click(sender As Object, e As EventArgs) Handles FillCmd.Click
        nowthing = things.FILL
    End Sub
    Private Sub CircleCmd_Click(sender As Object, e As EventArgs) Handles CircleCmd.Click
        nowthing = things.CIRCLE
    End Sub
    Private Sub Color1_Click(sender As Object, e As EventArgs) Handles Color1.Click
        nowcolor = Color1.BackColor
        ShowColor.BackColor = nowcolor
    End Sub

    Private Sub Color2_Click(sender As Object, e As EventArgs) Handles Color2.Click
        nowcolor = Color2.BackColor
        ShowColor.BackColor = nowcolor
    End Sub

    Private Sub Color3_Click(sender As Object, e As EventArgs) Handles Color3.Click
        nowcolor = Color3.BackColor
        ShowColor.BackColor = nowcolor
    End Sub

    Private Sub Color4_Click(sender As Object, e As EventArgs) Handles Color4.Click
        nowcolor = Color4.BackColor
        ShowColor.BackColor = nowcolor
    End Sub

    Private Sub Color5_Click(sender As Object, e As EventArgs) Handles Color5.Click
        nowcolor = Color5.BackColor
        ShowColor.BackColor = nowcolor
    End Sub

    Private Sub Color6_Click(sender As Object, e As EventArgs) Handles Color6.Click
        nowcolor = Color6.BackColor
        ShowColor.BackColor = nowcolor
    End Sub

    Private Sub Color7_Click(sender As Object, e As EventArgs) Handles Color7.Click
        nowcolor = Color7.BackColor
        ShowColor.BackColor = nowcolor
    End Sub
    Private Sub Color8_Click(sender As Object, e As EventArgs) Handles Color8.Click
        nowcolor = Color8.BackColor
        ShowColor.BackColor = nowcolor
    End Sub

    Private Sub NewItem_Click(sender As Object, e As EventArgs) Handles NewItem.Click
        If hassaved = False Then
            If askifsave() = True Then
                img = New Bitmap(PictureLoc.Width, PictureLoc.Height)
                NowTitle = "无标题"
                NowFile = "*.bmp"
                Me.Text = NowTitle + " - " + programname
                imggra = Graphics.FromImage(img)
                PictureLoc.Image = img
            End If
        Else
            img = New Bitmap(PictureLoc.Width, PictureLoc.Height)
            NowTitle = "无标题"
            NowFile = "*.bmp"
            Me.Text = NowTitle + " - " + programname
            imggra = Graphics.FromImage(img)
            PictureLoc.Image = img
        End If
    End Sub

    Private Sub OpenItem_Click(sender As Object, e As EventArgs) Handles OpenItem.Click
        If getopenname() = True Then
            If hassaved = False Then
                If askifsave() = True Then
                    NowFile = tempfilename
                    NowTitle = tempfiletitle
                    openfile()
                    Me.Text = tempfiletitle + " - " + programname
                End If
            Else
                NowFile = tempfilename
                NowTitle = tempfiletitle
                openfile()
                Me.Text = tempfiletitle + " - " + programname
            End If
        End If
    End Sub

    Private Sub SaveItem_Click(sender As Object, e As EventArgs) Handles SaveItem.Click
        If neversaved = True Then
            If getsavename() = True Then
                savefile()
            End If
        Else
            savefile()
        End If
    End Sub

    Private Sub OtherSaveItem_Click(sender As Object, e As EventArgs) Handles OtherSaveItem.Click
        If getsavename() = True Then
            savefile()
        End If
    End Sub

    Private Sub ExitItem_Click(sender As Object, e As EventArgs) Handles ExitItem.Click
        If hassaved = False Then
            If askifsave() = True Then
                End
            End If
        Else
            End
        End If
    End Sub

    Private Sub GetColorItem_Click(sender As Object, e As EventArgs) Handles GetColorItem.Click
        If ColorDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            nowcolor = ColorDialog.Color
            ShowColor.BackColor = nowcolor
        End If
    End Sub

    Private Sub AboutItem_Click(sender As Object, e As EventArgs) Handles AboutItem.Click
        About.ShowDialog()
    End Sub

    Private Function getsavename() As Boolean
        If SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            NowFile = SaveFileDialog.FileName
            SaveFileDialog.FileName = "*.bmp"
            NowTitle = Split(NowFile, "\")(UBound(Split(NowFile, "\")))
            Me.Text = NowTitle + " - " + programname
            Return True
        Else
            Return False
        End If
    End Function
    Dim tempfilename, tempfiletitle As String
    Private Function getopenname() As Boolean
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tempfilename = OpenFileDialog.FileName
            OpenFileDialog.FileName = "*.bmp"
            tempfiletitle = Split(tempfilename, "\")(UBound(Split(tempfilename, "\")))
            Return True
        Else
            Return False
        End If
    End Function
    Private Function askifsave() As Boolean
        Dim temp As Integer = MsgBox("文件" + NowTitle + "未保存，是否保存？", vbYesNoCancel + 48, programname)
        Select Case temp
            Case vbYes
                If neversaved = True Then
                    If getsavename() = True Then
                        savefile()
                    End If
                Else
                    savefile()
                End If
                Return True
            Case vbNo
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private Sub savefile()
        Try
            img.Save(NowFile)
        Catch ex As Exception
            MsgBox("出现错误，文件未成功保存，请使用管理员权限重试！", 48, programname)
        End Try
        neversaved = False
        hassaved = True
    End Sub

    Private Sub openfile()
        Dim tempimg As New Bitmap(NowFile)
        For i = 1 To img.Width - 1
            For j = 1 To img.Height - 1
                img.SetPixel(i, j, tempimg.GetPixel(i, j))
            Next
        Next
        tempimg.Dispose()
        imggra = Graphics.FromImage(img)
        PictureLoc.Image = img

        neversaved = False
        hassaved = True
    End Sub

End Class
