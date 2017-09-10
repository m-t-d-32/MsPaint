Public Class Form1
    Dim programname = "画图"
    Dim img As Bitmap
    Dim drawing As Boolean = False
    Dim moving As Boolean = False
    Dim imggra As Graphics
    Dim imgpen As Pen
    Dim nowcolor As Color = Color.Black
    Dim nowwidth As Integer = 2
    Enum things
        PENCIL
        ERASER
        GETCOLOR
        FILL
        LINE
        CIRCLE
        SQUARE
        SEL
        TEXT
    End Enum
    Enum state
        DRAW
        GOT
        SELECTED
    End Enum
    Dim nowthing As things
    Dim lastpoint As New Point
    Dim fillcolor As Color
    Dim imgflex As Color(,)
    Dim neversaved = True
    Dim hassaved = True
    Dim selimg As Bitmap
    Dim nowstate As Integer = State.draw
    Dim selection(,) As Color
    Dim selectedrectangle As Rectangle
    Dim NowFile As String = "*.bmp"
    Dim NowTitle As String = "无标题"
    Dim tempfilename, tempfiletitle As String
    Dim threadx, thready As Integer
    Dim intexts As New TextBox
    Dim minusex, minusey As Integer
    Private Sub LoadProgram()
        For i = 1 To img.Width - 1
            For j = 1 To img.Height - 1
                img.SetPixel(i, j, Color.White)
            Next
        Next
    End Sub
    Private Sub clone()
        Dim tempimg As New Bitmap(img)
        img = New Bitmap(PictureLoc.Width, PictureLoc.Height)
        For i = 1 To img.Width - 1
            For j = 1 To img.Height - 1
                If i < tempimg.Width And j < tempimg.Height Then
                    Dim tmpcolor As Color = tempimg.GetPixel(i, j)
                    img.SetPixel(i, j, tmpcolor)
                Else
                    img.SetPixel(i, j, Color.White)
                End If
            Next
        Next
        tempimg.Dispose()
        imggra = Graphics.FromImage(img)
        PictureLoc.Image = img
    End Sub
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
    Private Sub updatepen()
        imgpen.Width = nowwidth
        imgpen.Color = nowcolor
        imgpen.DashStyle = Drawing2D.DashStyle.Solid
    End Sub
    Private Sub begindraw(ByVal e As Point)
        Select Case nowthing
            Case things.PENCIL
                drawing = True
                lastpoint.x = e.X
                lastpoint.Y = e.Y
                updatepen()
            Case things.ERASER
                drawing = True
                lastpoint.X = e.X
                lastpoint.Y = e.Y
                imgpen.Width = 10
                imgpen.Color = Color.White
            Case things.GETCOLOR
                nowcolor = img.GetPixel(e.X, e.Y)
                ShowColor.BackColor = nowcolor
            Case things.FILL
                fillcolor = img.GetPixel(e.X, e.Y)
                If fillcolor.ToArgb() <> nowcolor.ToArgb Then
                    Fill(e.X, e.Y)
                End If
                PictureLoc.Image = img
            Case things.LINE
                drawing = True
                lastpoint.X = e.X
                lastpoint.Y = e.Y
                updatepen()
            Case things.CIRCLE
                drawing = True
                lastpoint.X = e.X
                lastpoint.Y = e.Y
                updatepen()
            Case things.SQUARE
                drawing = True
                lastpoint.X = e.X
                lastpoint.Y = e.Y
                updatepen()
            Case things.SEL
                drawing = True
                lastpoint.X = e.X
                lastpoint.Y = e.Y
                imgpen.Width = 2
                Dim tempcolor As Color = img.GetPixel(e.X, e.Y)
                imgpen.Color = Color.FromArgb(255, 255 - tempcolor.R, 255 - tempcolor.G, 255 - tempcolor.B)
                imgpen.DashStyle = Drawing2D.DashStyle.Dash
            Case things.TEXT
                If intexts.Text <> "" Then
                    intexts.BorderStyle = BorderStyle.None
                    intexts.Left += 3
                    intexts.Top += 3
                    Dim temp As New Bitmap(intexts.Width, intexts.Height)
                    intexts.DrawToBitmap(temp, New Rectangle(0, 0, intexts.Width, intexts.Height))
                    For i = 1 To intexts.Width - 1
                        For j = 1 To intexts.Height - 1
                            If intexts.Left + i < img.Width And intexts.Top + j < img.Height Then
                                img.SetPixel(intexts.Left + i, intexts.Top + j, temp.GetPixel(i, j))
                            End If
                        Next
                    Next
                End If
                intexts.Dispose()
                intexts = New TextBox
                intexts.Left = e.X
                intexts.Top = e.Y
                PictureLoc.Controls.Add(intexts)
                intexts.Width = 100
                intexts.Height = 100
                intexts.Visible = True
                intexts.Multiline = True
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
            Case things.SQUARE
                If (e.X <> -1) Then
                    imggra.DrawRectangle(imgpen, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y)
                    PictureLoc.Image = img
                End If
                drawing = False
            Case things.SEL
                If (e.X <> -1) Then
                    selimg = New Bitmap(img)
                    Dim selgra As Graphics = Graphics.FromImage(selimg)
                    If lastpoint.X > e.X Then
                        Dim temp As Integer = e.X
                        e.X = lastpoint.X
                        lastpoint.X = temp
                    End If
                    If lastpoint.Y > e.Y Then
                        Dim temp As Integer = e.Y
                        e.Y = lastpoint.Y
                        lastpoint.Y = temp
                    End If
                    selectedrectangle = New Rectangle(lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y)
                    selgra.DrawRectangle(imgpen, selectedrectangle)
                    PictureLoc.Image = selimg
                    ReDim selection(selectedrectangle.Width, selectedrectangle.Height)
                    For i = 0 To selectedrectangle.Width
                        For j = 0 To selectedrectangle.Height
                            If i + selectedrectangle.X < img.Width And j + selectedrectangle.Y < img.Height Then
                                selection(i, j) = img.GetPixel(i + selectedrectangle.X, j + selectedrectangle.Y)
                            End If
                        Next
                    Next
                    drawing = False
                    nowstate = state.GOT
                End If
        End Select
    End Sub
    Private Sub beginmove(ByVal e As Point)
        moving = True
        lastpoint.X = e.X - lastpoint.X
        lastpoint.Y = e.Y - lastpoint.Y
    End Sub
    Private Sub endmove(ByVal e As Point)
        imggra = Graphics.FromImage(img)
        lastpoint.X = e.X - lastpoint.X
        lastpoint.Y = e.Y - lastpoint.Y
        moving = False
    End Sub
    Private Sub disposemove()
        img = New Bitmap(selimg)
        imggra = Graphics.FromImage(img)
        PictureLoc.Image = img
        nowstate = state.DRAW
        moving = False
    End Sub
    Private Sub restart()
        Select Case nowstate
            Case state.GOT
                imggra = Graphics.FromImage(img)
                PictureLoc.Image = img
                nowstate = state.DRAW
                moving = False
            Case state.SELECTED
                nowstate = state.DRAW
                disposemove()
        End Select
        If nowthing = things.TEXT Then
            If intexts.Text <> "" Then
                Dim temp As New Bitmap(intexts.Width, intexts.Height)
                intexts.BorderStyle = BorderStyle.None
                intexts.Left += 1
                intexts.Width += 1
                intexts.DrawToBitmap(temp, New Rectangle(0, 0, intexts.Width, intexts.Height))
                For i = 1 To temp.Width - 1
                    For j = 1 To temp.Height - 1
                        If intexts.Left + i < img.Width And intexts.Top + j < img.Height Then
                            Dim tempcolor As Color = temp.GetPixel(i, j)
                            img.SetPixel(intexts.Left + i, intexts.Top + j, tempcolor)
                        End If
                    Next
                Next
            End If
            intexts.Dispose()
        End If
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
        Try
            Dim tempimg As New Bitmap(tempfilename)
            For i = 1 To img.Width - 1
                For j = 1 To img.Height - 1
                    img.SetPixel(i, j, tempimg.GetPixel(i, j))
                Next
            Next
            tempimg.Dispose()
            imggra = Graphics.FromImage(img)
            PictureLoc.Image = img
            NowFile = tempfilename
            NowTitle = tempfiletitle
            Me.Text = tempfiletitle + " - " + programname
            neversaved = False
            hassaved = True
            LoadProgram()
        Catch ex As Exception
            MsgBox(programname + "无法打开此文件。", 48, "错误")
        End Try

    End Sub
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        img = New Bitmap(PictureLoc.Width, PictureLoc.Height)
        imggra = Graphics.FromImage(img)
        imgpen = New Pen(Brushes.Black)
        ShowColor.BackColor = nowcolor
        Me.Text = NowTitle + " - " + programname
    End Sub
    Private Sub PictureLoc_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureLoc.MouseDown
        Select Case nowstate
            Case state.DRAW
                begindraw(New Point(e.X, e.Y))
            Case state.GOT
                If selectedrectangle.Contains(New Point(e.X, e.Y)) Then
                    lastpoint.X = 0
                    lastpoint.Y = 0
                    beginmove(New Point(e.X, e.Y))
                    nowstate = state.SELECTED
                    selimg = New Bitmap(img)
                Else
                    imggra = Graphics.FromImage(img)
                    PictureLoc.Image = img
                    nowstate = state.DRAW
                    moving = False
                    lastpoint.X = e.X
                    lastpoint.Y = e.Y
                    begindraw(New Point(e.X, e.Y))
                End If
            Case state.SELECTED
                Dim reprectangle As Rectangle = selectedrectangle
                reprectangle.X = threadx
                reprectangle.Y = thready
                If reprectangle.Contains(New Point(e.X, e.Y)) Then
                    beginmove(New Point(e.X, e.Y))
                Else
                    nowstate = state.DRAW
                    disposemove()
                    begindraw(New Point(e.X, e.Y))
                End If
        End Select
    End Sub
    Private Sub PictureLoc_MouseLeave(sender As Object, e As EventArgs) Handles PictureLoc.MouseLeave
        If drawing = True Then
            enddraw(New Point(-1, -1))
        End If
    End Sub
    Private Sub PictureLoc_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureLoc.MouseMove
        If nowstate = state.DRAW Then
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
                    Case things.SQUARE
                        Dim tempimg As Bitmap = New Bitmap(img)
                        Dim tempgra = Graphics.FromImage(tempimg)
                        tempgra.DrawRectangle(imgpen, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y)
                        PictureLoc.Image = tempimg
                    Case things.SEL
                        Dim tempimg As Bitmap = New Bitmap(img)
                        Dim tempgra = Graphics.FromImage(tempimg)
                        tempgra.DrawRectangle(imgpen, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y)
                        PictureLoc.Image = tempimg
                End Select
            End If
        Else
            If moving = True Then
                hassaved = False
                For i = 0 To selectedrectangle.Width
                    For j = 0 To selectedrectangle.Height
                        selimg.SetPixel(i + selectedrectangle.X, j + selectedrectangle.Y, Color.White)
                    Next
                Next
                For i = 0 To selectedrectangle.Width
                    For j = 0 To selectedrectangle.Height
                        Dim tx = i + selectedrectangle.X + e.X - lastpoint.X, ty = j + selectedrectangle.Y + e.Y - lastpoint.Y
                        If tx > 0 And tx < selimg.Width And ty > 0 And ty < selimg.Height Then
                            selimg.SetPixel(tx, ty, selection(i, j))
                        End If
                    Next
                Next
                threadx = selectedrectangle.X + e.X - lastpoint.X
                thready = selectedrectangle.Y + e.Y - lastpoint.Y
                Dim tmpimg As Bitmap = New Bitmap(selimg)
                imggra = Graphics.FromImage(tmpimg)
                imggra.DrawRectangle(imgpen, threadx, thready, selectedrectangle.Width, selectedrectangle.Height)
                PictureLoc.Image = tmpimg
            End If
        End If
    End Sub
    Private Sub PictureLoc_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureLoc.MouseUp
        If nowstate = state.DRAW Then
            enddraw(New Point(e.X, e.Y))
        Else
            endmove(New Point(e.X, e.Y))
        End If
    End Sub
    Private Sub PencilCmd_Click(sender As Object, e As EventArgs) Handles PencilCmd.Click
        restart()
        nowthing = things.PENCIL
    End Sub
    Private Sub EraserCmd_Click(sender As Object, e As EventArgs) Handles EraserCmd.Click
        restart()
        nowthing = things.ERASER
    End Sub
    Private Sub LineCmd_Click(sender As Object, e As EventArgs) Handles LineCmd.Click
        restart()
        nowthing = things.LINE
    End Sub
    Private Sub GetColorCmd_Click(sender As Object, e As EventArgs) Handles GetColorCmd.Click
        restart()
        nowthing = things.GETCOLOR
    End Sub
    Private Sub FillCmd_Click(sender As Object, e As EventArgs) Handles FillCmd.Click
        restart()
        nowthing = things.FILL
    End Sub
    Private Sub CircleCmd_Click(sender As Object, e As EventArgs) Handles CircleCmd.Click
        restart()
        nowthing = things.CIRCLE
    End Sub
    Private Sub SquareCmd_Click(sender As Object, e As EventArgs) Handles SquareCmd.Click
        restart()
        nowthing = things.SQUARE
    End Sub
    Private Sub SelectCmd_Click(sender As Object, e As EventArgs) Handles SelectCmd.Click
        restart()
        nowthing = things.SEL
    End Sub
    Private Sub TextCmd_MouseDown(sender As Object, e As MouseEventArgs) Handles TextCmd.MouseDown
        nowthing = things.TEXT
        intexts.Dispose()
        intexts = New TextBox
        intexts.Left = e.X
        intexts.Top = e.Y
        PictureLoc.Controls.Add(intexts)
        intexts.Width = 100
        intexts.Height = 100
        intexts.Visible = True
        intexts.Multiline = True
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
                    openfile()
                End If
            Else
                openfile()
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
    Private Sub LineWid1_Click(sender As Object, e As EventArgs) Handles LineWid1.Click
        LineWid1.Checked = True
        LineWid2.Checked = False
        LineWid3.Checked = False
        LineWid5.Checked = False
        LineWid10.Checked = False
        nowwidth = 1
    End Sub
    Private Sub LineWid2_Click(sender As Object, e As EventArgs) Handles LineWid2.Click
        LineWid1.Checked = False
        LineWid2.Checked = True
        LineWid3.Checked = False
        LineWid5.Checked = False
        LineWid10.Checked = False
        nowwidth = 2
    End Sub
    Private Sub LineWid3_Click(sender As Object, e As EventArgs) Handles LineWid3.Click
        LineWid1.Checked = False
        LineWid2.Checked = False
        LineWid3.Checked = True
        LineWid5.Checked = False
        LineWid10.Checked = False
        nowwidth = 3
    End Sub
    Private Sub LineWid5_Click(sender As Object, e As EventArgs) Handles LineWid5.Click
        LineWid1.Checked = False
        LineWid2.Checked = False
        LineWid3.Checked = False
        LineWid5.Checked = True
        LineWid10.Checked = False
        nowwidth = 5
    End Sub
    Private Sub LineWid10_Click(sender As Object, e As EventArgs) Handles LineWid10.Click
        LineWid1.Checked = False
        LineWid2.Checked = False
        LineWid3.Checked = False
        LineWid5.Checked = False
        LineWid10.Checked = True
        nowwidth = 10
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        PictureLoc.Image = img
        LoadProgram()
        minusex = Me.Width - PictureLoc.Width + 1
        minusey = Me.Height - PictureLoc.Height + 1
    End Sub
    Private Sub Large_Click(sender As Object, e As EventArgs) Handles Large.Click
        PictureLoc.Width += 30
        PictureLoc.Height += 30
        clone()
    End Sub
    Private Sub Small_Click(sender As Object, e As EventArgs) Handles Small.Click
        If PictureLoc.Width > 30 And PictureLoc.Height > 30 Then
            PictureLoc.Width -= 30
            PictureLoc.Height -= 30
            clone()
        End If
    End Sub


End Class
