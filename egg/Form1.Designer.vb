<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextSANo = New System.Windows.Forms.TextBox()
        Me.TextRemark = New System.Windows.Forms.TextBox()
        Me.TextQty = New System.Windows.Forms.TextBox()
        Me.dpt1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboCompany = New System.Windows.Forms.ComboBox()
        Me.ComboLocation = New System.Windows.Forms.ComboBox()
        Me.ComboEggCategory = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkViolet
        Me.Panel1.Location = New System.Drawing.Point(-17, -30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1538, 100)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SA No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(936, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Company"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(936, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Location"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 25)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Remark"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 338)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Egg Category"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(831, 338)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 23)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Qty"
        '
        'TextSANo
        '
        Me.TextSANo.Enabled = False
        Me.TextSANo.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSANo.Location = New System.Drawing.Point(157, 82)
        Me.TextSANo.Multiline = True
        Me.TextSANo.Name = "TextSANo"
        Me.TextSANo.Size = New System.Drawing.Size(100, 35)
        Me.TextSANo.TabIndex = 8
        '
        'TextRemark
        '
        Me.TextRemark.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRemark.Location = New System.Drawing.Point(157, 192)
        Me.TextRemark.Multiline = True
        Me.TextRemark.Name = "TextRemark"
        Me.TextRemark.Size = New System.Drawing.Size(1294, 93)
        Me.TextRemark.TabIndex = 9
        '
        'TextQty
        '
        Me.TextQty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextQty.Location = New System.Drawing.Point(917, 313)
        Me.TextQty.Multiline = True
        Me.TextQty.Name = "TextQty"
        Me.TextQty.Size = New System.Drawing.Size(367, 86)
        Me.TextQty.TabIndex = 10
        '
        'dpt1
        '
        Me.dpt1.CustomFormat = ""
        Me.dpt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpt1.Location = New System.Drawing.Point(1163, 89)
        Me.dpt1.Name = "dpt1"
        Me.dpt1.Size = New System.Drawing.Size(288, 22)
        Me.dpt1.TabIndex = 11
        '
        'ComboCompany
        '
        Me.ComboCompany.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCompany.FormattingEnabled = True
        Me.ComboCompany.Items.AddRange(New Object() {"FARMS PRIDE (PVT) LTD.", "MIDLAND BREEDERS (PVT) LTD.", "GOLDEN GRAINS (PVT) LTD.", "HARE PARK DAIRY (PVT) LTD.", "CONSOLIDATED", "ALTRA GUARD", "WAYAMBA DEVELOPMENT (PVT) LTD", "FORTUNE AGRO INDUSTRIES (PVT) LTD", "CASUAL WAGES - PPL", "CRYSBRO AUTO SERVICE"})
        Me.ComboCompany.Location = New System.Drawing.Point(157, 138)
        Me.ComboCompany.Name = "ComboCompany"
        Me.ComboCompany.Size = New System.Drawing.Size(258, 25)
        Me.ComboCompany.TabIndex = 12
        '
        'ComboLocation
        '
        Me.ComboLocation.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboLocation.FormattingEnabled = True
        Me.ComboLocation.Items.AddRange(New Object() {"#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA", "#272, JAYAMALAPURA,GAMPOLA"})
        Me.ComboLocation.Location = New System.Drawing.Point(1163, 137)
        Me.ComboLocation.Name = "ComboLocation"
        Me.ComboLocation.Size = New System.Drawing.Size(288, 25)
        Me.ComboLocation.TabIndex = 13
        '
        'ComboEggCategory
        '
        Me.ComboEggCategory.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboEggCategory.FormattingEnabled = True
        Me.ComboEggCategory.Items.AddRange(New Object() {"DAMAGED - FARM", "DIRTY - FARM", "MISSHAPEN - FARM", "SMALL - FARM", "THIN SHELL", "DISCARD", "DOUBLE YOLK", "TRANSPORT DAMAGE", "HATCHERY DAMAGE", "FARM DAMAGE - HATCHERY", "MISSHAPEN - HATCHERY", "< 50", "DIRTY - HATCHERY", "CONSUMPTION", "DAMAGED FARM (H/O)", "DAMAGED HATCHERY (H/O)", "NONE - HATCHABLE", "DISCARD H/O", "SMALL - HATCHERY", "SMALL - H/O", "HATCHABLE EGGS"})
        Me.ComboEggCategory.Location = New System.Drawing.Point(167, 340)
        Me.ComboEggCategory.Name = "ComboEggCategory"
        Me.ComboEggCategory.Size = New System.Drawing.Size(299, 27)
        Me.ComboEggCategory.TabIndex = 14
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.DarkViolet
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(1311, 326)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(140, 48)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(273, 405)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(863, 197)
        Me.DataGridView1.TabIndex = 16
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkViolet
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(16, 608)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(140, 48)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "NEW"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.DarkViolet
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(1311, 608)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(140, 48)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkViolet
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(1075, 608)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(140, 48)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1493, 668)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.ComboEggCategory)
        Me.Controls.Add(Me.ComboLocation)
        Me.Controls.Add(Me.ComboCompany)
        Me.Controls.Add(Me.dpt1)
        Me.Controls.Add(Me.TextQty)
        Me.Controls.Add(Me.TextRemark)
        Me.Controls.Add(Me.TextSANo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextSANo As TextBox
    Friend WithEvents TextRemark As TextBox
    Friend WithEvents TextQty As TextBox
    Friend WithEvents dpt1 As DateTimePicker
    Friend WithEvents ComboCompany As ComboBox
    Friend WithEvents ComboLocation As ComboBox
    Friend WithEvents ComboEggCategory As ComboBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSave As Button
End Class
