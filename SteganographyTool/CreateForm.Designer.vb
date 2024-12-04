<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CreateForm
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
        btnSelectCoverFile = New Button()
        btnSelectFile2Hide = New Button()
        btnCreate = New Button()
        txtCoverFile = New TextBox()
        txtFile2Hide = New TextBox()
        SuspendLayout()
        ' 
        ' btnSelectCoverFile
        ' 
        btnSelectCoverFile.Location = New Point(12, 12)
        btnSelectCoverFile.Name = "btnSelectCoverFile"
        btnSelectCoverFile.Size = New Size(180, 23)
        btnSelectCoverFile.TabIndex = 0
        btnSelectCoverFile.Text = "Select Cover File"
        btnSelectCoverFile.UseVisualStyleBackColor = True
        ' 
        ' btnSelectFile2Hide
        ' 
        btnSelectFile2Hide.Location = New Point(12, 41)
        btnSelectFile2Hide.Name = "btnSelectFile2Hide"
        btnSelectFile2Hide.Size = New Size(180, 23)
        btnSelectFile2Hide.TabIndex = 1
        btnSelectFile2Hide.Text = "Select File to Hide"
        btnSelectFile2Hide.UseVisualStyleBackColor = True
        ' 
        ' btnCreate
        ' 
        btnCreate.Location = New Point(329, 74)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(137, 32)
        btnCreate.TabIndex = 2
        btnCreate.Text = "Create"
        btnCreate.UseVisualStyleBackColor = True
        ' 
        ' txtCoverFile
        ' 
        txtCoverFile.Location = New Point(198, 12)
        txtCoverFile.Name = "txtCoverFile"
        txtCoverFile.Size = New Size(268, 31)
        txtCoverFile.TabIndex = 3
        ' 
        ' txtFile2Hide
        ' 
        txtFile2Hide.Location = New Point(198, 43)
        txtFile2Hide.Name = "txtFile2Hide"
        txtFile2Hide.Size = New Size(268, 31)
        txtFile2Hide.TabIndex = 4
        ' 
        ' CreateForm
        ' 
        ClientSize = New Size(478, 119)
        Controls.Add(txtFile2Hide)
        Controls.Add(txtCoverFile)
        Controls.Add(btnCreate)
        Controls.Add(btnSelectFile2Hide)
        Controls.Add(btnSelectCoverFile)
        Name = "CreateForm"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents btnSelectCoverFile As Button
    Friend WithEvents btnSelectFile2Hide As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents txtCoverFile As TextBox
    Friend WithEvents txtFile2Hide As TextBox
End Class