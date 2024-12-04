<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExtractForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnSelectFile2Analyze = New System.Windows.Forms.Button()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.txtFile2Analyze = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSelectFile2Analyze
        '
        Me.btnSelectFile2Analyze.Location = New System.Drawing.Point(20, 19)
        Me.btnSelectFile2Analyze.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnSelectFile2Analyze.Name = "btnSelectFile2Analyze"
        Me.btnSelectFile2Analyze.Size = New System.Drawing.Size(222, 32)
        Me.btnSelectFile2Analyze.TabIndex = 0
        Me.btnSelectFile2Analyze.Text = "Select File to Analyze"
        Me.btnSelectFile2Analyze.UseVisualStyleBackColor = True
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(575, 66)
        Me.btnExtract.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(212, 50)
        Me.btnExtract.TabIndex = 1
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'txtSteganoFile
        '
        Me.txtFile2Analyze.Location = New System.Drawing.Point(252, 19)
        Me.txtFile2Analyze.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtFile2Analyze.Name = "txtFile2Analyze"
        Me.txtFile2Analyze.Size = New System.Drawing.Size(535, 25)
        Me.txtFile2Analyze.TabIndex = 2
        '
        'ExtractForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 138)
        Me.Controls.Add(Me.txtFile2Analyze)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.btnSelectFile2Analyze)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "ExtractForm"
        Me.Text = "Extract Steganography"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents btnSelectFile2Analyze As System.Windows.Forms.Button
    Private WithEvents btnExtract As System.Windows.Forms.Button
    Private WithEvents txtFile2Analyze As System.Windows.Forms.TextBox
End Class
