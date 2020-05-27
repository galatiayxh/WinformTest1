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

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_out = New System.Windows.Forms.Button()
        Me.dateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'btn_out
        '
        Me.btn_out.Location = New System.Drawing.Point(207, 171)
        Me.btn_out.Name = "btn_out"
        Me.btn_out.Size = New System.Drawing.Size(75, 23)
        Me.btn_out.TabIndex = 3
        Me.btn_out.Text = "button1"
        Me.btn_out.UseVisualStyleBackColor = True
        '
        'dateTimePicker1
        '
        Me.dateTimePicker1.Location = New System.Drawing.Point(70, 68)
        Me.dateTimePicker1.Name = "dateTimePicker1"
        Me.dateTimePicker1.Size = New System.Drawing.Size(200, 21)
        Me.dateTimePicker1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_out)
        Me.Controls.Add(Me.dateTimePicker1)
        Me.Name = "Form1"
        Me.Text = "vb"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents btn_out As Button
    Private WithEvents dateTimePicker1 As DateTimePicker
End Class
