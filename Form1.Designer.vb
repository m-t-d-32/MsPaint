<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CircleCmd = New System.Windows.Forms.Button()
        Me.FillCmd = New System.Windows.Forms.Button()
        Me.GetColorCmd = New System.Windows.Forms.Button()
        Me.LineCmd = New System.Windows.Forms.Button()
        Me.EraserCmd = New System.Windows.Forms.Button()
        Me.PictureLoc = New System.Windows.Forms.PictureBox()
        Me.PencilCmd = New System.Windows.Forms.Button()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtherSaveItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.编辑ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetColorItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.LabelC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ShowColor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Seg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Color1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Color2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Color3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Color4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Color5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Color6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Color7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Color8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'CircleCmd
        '
        Me.CircleCmd.BackgroundImage = Global.MsPaint.My.Resources.Resources.圆
        Me.CircleCmd.Location = New System.Drawing.Point(130, 221)
        Me.CircleCmd.Name = "CircleCmd"
        Me.CircleCmd.Size = New System.Drawing.Size(64, 64)
        Me.CircleCmd.TabIndex = 6
        Me.CircleCmd.UseVisualStyleBackColor = True
        '
        'FillCmd
        '
        Me.FillCmd.BackColor = System.Drawing.SystemColors.Control
        Me.FillCmd.BackgroundImage = Global.MsPaint.My.Resources.Resources.填充
        Me.FillCmd.Location = New System.Drawing.Point(130, 131)
        Me.FillCmd.Name = "FillCmd"
        Me.FillCmd.Size = New System.Drawing.Size(64, 64)
        Me.FillCmd.TabIndex = 5
        Me.FillCmd.UseVisualStyleBackColor = False
        '
        'GetColorCmd
        '
        Me.GetColorCmd.BackColor = System.Drawing.SystemColors.Control
        Me.GetColorCmd.BackgroundImage = Global.MsPaint.My.Resources.Resources.取色
        Me.GetColorCmd.Location = New System.Drawing.Point(130, 45)
        Me.GetColorCmd.Name = "GetColorCmd"
        Me.GetColorCmd.Size = New System.Drawing.Size(64, 64)
        Me.GetColorCmd.TabIndex = 4
        Me.GetColorCmd.UseVisualStyleBackColor = False
        '
        'LineCmd
        '
        Me.LineCmd.BackgroundImage = Global.MsPaint.My.Resources.Resources.直线
        Me.LineCmd.Location = New System.Drawing.Point(35, 221)
        Me.LineCmd.Name = "LineCmd"
        Me.LineCmd.Size = New System.Drawing.Size(64, 64)
        Me.LineCmd.TabIndex = 3
        Me.LineCmd.UseVisualStyleBackColor = True
        '
        'EraserCmd
        '
        Me.EraserCmd.BackgroundImage = Global.MsPaint.My.Resources.Resources.橡皮
        Me.EraserCmd.Location = New System.Drawing.Point(35, 131)
        Me.EraserCmd.Name = "EraserCmd"
        Me.EraserCmd.Size = New System.Drawing.Size(64, 64)
        Me.EraserCmd.TabIndex = 2
        Me.EraserCmd.UseVisualStyleBackColor = True
        '
        'PictureLoc
        '
        Me.PictureLoc.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.PictureLoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureLoc.Location = New System.Drawing.Point(223, 45)
        Me.PictureLoc.Name = "PictureLoc"
        Me.PictureLoc.Size = New System.Drawing.Size(320, 240)
        Me.PictureLoc.TabIndex = 1
        Me.PictureLoc.TabStop = False
        '
        'PencilCmd
        '
        Me.PencilCmd.BackgroundImage = Global.MsPaint.My.Resources.Resources.铅笔
        Me.PencilCmd.Location = New System.Drawing.Point(35, 44)
        Me.PencilCmd.Name = "PencilCmd"
        Me.PencilCmd.Size = New System.Drawing.Size(64, 64)
        Me.PencilCmd.TabIndex = 0
        Me.PencilCmd.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.编辑ToolStripMenuItem, Me.帮助ToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(580, 25)
        Me.MenuStrip.TabIndex = 7
        Me.MenuStrip.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewItem, Me.OpenItem, Me.ToolStripMenuItem1, Me.SaveItem, Me.OtherSaveItem, Me.ToolStripMenuItem2, Me.ExitItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        'NewItem
        '
        Me.NewItem.Name = "NewItem"
        Me.NewItem.Size = New System.Drawing.Size(152, 22)
        Me.NewItem.Text = "新建"
        '
        'OpenItem
        '
        Me.OpenItem.Name = "OpenItem"
        Me.OpenItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenItem.Text = "打开"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'SaveItem
        '
        Me.SaveItem.Name = "SaveItem"
        Me.SaveItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveItem.Text = "保存"
        '
        'OtherSaveItem
        '
        Me.OtherSaveItem.Name = "OtherSaveItem"
        Me.OtherSaveItem.Size = New System.Drawing.Size(152, 22)
        Me.OtherSaveItem.Text = "另存为"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(149, 6)
        '
        'ExitItem
        '
        Me.ExitItem.Name = "ExitItem"
        Me.ExitItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitItem.Text = "退出"
        '
        '编辑ToolStripMenuItem
        '
        Me.编辑ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetColorItem})
        Me.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem"
        Me.编辑ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.编辑ToolStripMenuItem.Text = "编辑"
        '
        'GetColorItem
        '
        Me.GetColorItem.Name = "GetColorItem"
        Me.GetColorItem.Size = New System.Drawing.Size(133, 22)
        Me.GetColorItem.Text = "选择颜色..."
        '
        '帮助ToolStripMenuItem
        '
        Me.帮助ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutItem})
        Me.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem"
        Me.帮助ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.帮助ToolStripMenuItem.Text = "帮助"
        '
        'AboutItem
        '
        Me.AboutItem.Name = "AboutItem"
        Me.AboutItem.Size = New System.Drawing.Size(100, 22)
        Me.AboutItem.Text = "关于"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelC, Me.ShowColor, Me.Seg, Me.Color1, Me.Color2, Me.Color3, Me.Color4, Me.Color5, Me.Color6, Me.Color7, Me.Color8})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 299)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(580, 26)
        Me.StatusStrip.TabIndex = 8
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'LabelC
        '
        Me.LabelC.BackColor = System.Drawing.SystemColors.Control
        Me.LabelC.Name = "LabelC"
        Me.LabelC.Size = New System.Drawing.Size(88, 21)
        Me.LabelC.Text = "      Color      "
        '
        'ShowColor
        '
        Me.ShowColor.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ShowColor.Name = "ShowColor"
        Me.ShowColor.Size = New System.Drawing.Size(192, 21)
        Me.ShowColor.Text = "                                             "
        '
        'Seg
        '
        Me.Seg.Name = "Seg"
        Me.Seg.Size = New System.Drawing.Size(32, 21)
        Me.Seg.Text = "      "
        '
        'Color1
        '
        Me.Color1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Color1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Color1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Color1.Name = "Color1"
        Me.Color1.Size = New System.Drawing.Size(28, 21)
        Me.Color1.Text = "    "
        '
        'Color2
        '
        Me.Color2.BackColor = System.Drawing.Color.White
        Me.Color2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Color2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Color2.Name = "Color2"
        Me.Color2.Size = New System.Drawing.Size(28, 21)
        Me.Color2.Text = "    "
        '
        'Color3
        '
        Me.Color3.BackColor = System.Drawing.Color.Red
        Me.Color3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Color3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Color3.Name = "Color3"
        Me.Color3.Size = New System.Drawing.Size(28, 21)
        Me.Color3.Text = "    "
        '
        'Color4
        '
        Me.Color4.BackColor = System.Drawing.Color.Blue
        Me.Color4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Color4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Color4.Name = "Color4"
        Me.Color4.Size = New System.Drawing.Size(28, 21)
        Me.Color4.Text = "    "
        '
        'Color5
        '
        Me.Color5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Color5.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Color5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Color5.Name = "Color5"
        Me.Color5.Size = New System.Drawing.Size(28, 21)
        Me.Color5.Text = "    "
        '
        'Color6
        '
        Me.Color6.BackColor = System.Drawing.Color.Yellow
        Me.Color6.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Color6.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Color6.Name = "Color6"
        Me.Color6.Size = New System.Drawing.Size(28, 21)
        Me.Color6.Text = "    "
        '
        'Color7
        '
        Me.Color7.BackColor = System.Drawing.Color.Fuchsia
        Me.Color7.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Color7.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Color7.Name = "Color7"
        Me.Color7.Size = New System.Drawing.Size(28, 21)
        Me.Color7.Text = "    "
        '
        'Color8
        '
        Me.Color8.BackColor = System.Drawing.Color.Silver
        Me.Color8.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Color8.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Color8.Name = "Color8"
        Me.Color8.Size = New System.Drawing.Size(28, 21)
        Me.Color8.Text = "    "
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.DefaultExt = "bmp"
        Me.SaveFileDialog.FileName = "*.bmp"
        Me.SaveFileDialog.Filter = "位图图像(*.bmp)|*.bmp"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "*.bmp"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 325)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.CircleCmd)
        Me.Controls.Add(Me.FillCmd)
        Me.Controls.Add(Me.GetColorCmd)
        Me.Controls.Add(Me.LineCmd)
        Me.Controls.Add(Me.EraserCmd)
        Me.Controls.Add(Me.PictureLoc)
        Me.Controls.Add(Me.PencilCmd)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureLoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PencilCmd As System.Windows.Forms.Button
    Friend WithEvents PictureLoc As System.Windows.Forms.PictureBox
    Friend WithEvents EraserCmd As System.Windows.Forms.Button
    Friend WithEvents LineCmd As System.Windows.Forms.Button
    Friend WithEvents GetColorCmd As System.Windows.Forms.Button
    Friend WithEvents FillCmd As System.Windows.Forms.Button
    Friend WithEvents CircleCmd As System.Windows.Forms.Button
    Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtherSaveItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 帮助ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents LabelC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ShowColor As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Color1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Color2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Color3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Color4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Color5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Color6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Color7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents 编辑ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GetColorItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Seg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Color8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog

End Class
