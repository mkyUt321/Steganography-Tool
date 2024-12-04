' CreateForm.vb
Public Class CreateForm
    Inherits Form

    Public Sub New()
        InitializeComponent()
        Me.Text = "Create Steganography"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.Size = New Size(620, 250)

        ' Select Cover FIle Button
        btnSelectCoverFile.Text = "Select Cover File"
        btnSelectCoverFile.Size = New Size(200, 35)
        btnSelectCoverFile.Location = New Point(10, 10)
        Me.Controls.Add(btnSelectCoverFile)

        ' Cover File Path Textbox
        txtCoverFile.Size = New Size(360, 40)
        txtCoverFile.Location = New Point(215, 10)
        Me.Controls.Add(txtCoverFile)

        ' Select File to Hide Button
        btnSelectFile2Hide.Text = "Select File to Hide"
        btnSelectFile2Hide.Size = New Size(200, 35)
        btnSelectFile2Hide.Location = New Point(10, 60)
        Me.Controls.Add(btnSelectFile2Hide)

        ' File to Hide Path Textbox
        txtFile2Hide.Size = New Size(360, 40)
        txtFile2Hide.Location = New Point(215, 60)
        Me.Controls.Add(txtFile2Hide)

        ' Create Button
        btnCreate.Text = "Create"
        btnCreate.Size = New Size(200, 50)
        btnCreate.Location = New Point(370, 120)
        Me.Controls.Add(btnCreate)
    End Sub

    Private Sub btnSelectCoverFile_Click(sender As Object, e As EventArgs) Handles btnSelectCoverFile.Click
        ' Select Cover File Button Click Event
        Using ofd As New OpenFileDialog()
            If ofd.ShowDialog() = DialogResult.OK Then
                txtCoverFile.Text = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub btnSelectFile2Hide_Click(sender As Object, e As EventArgs) Handles btnSelectFile2Hide.Click
        ' Select File to Hide Button Click Event
        Using ofd As New OpenFileDialog()
            If ofd.ShowDialog() = DialogResult.OK Then
                txtFile2Hide.Text = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ' Create Button Click Event
        Dim coverFile As String = txtCoverFile.Text
        Dim file2Hide As String = txtFile2Hide.Text

        If String.IsNullOrEmpty(coverFile) OrElse String.IsNullOrEmpty(file2Hide) Then
            MessageBox.Show("Please select a cover file and a file to hide.")
            Return
        End If

        ' Get the file extension of the cover file
        Dim coverFileExtension As String = IO.Path.GetExtension(coverFile)

        ' Show SaveFileDialog to save the combined file
        Using sfd As New SaveFileDialog()
            sfd.Filter = $"Cover File (*{coverFileExtension})|*{coverFileExtension}|All Files (*.*)|*.*"
            sfd.DefaultExt = coverFileExtension
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim saveLocation As String = sfd.FileName

                ' Combine the files and save the combined file
                Try
                    ' Read the cover file and the file to hide
                    Dim coverData As Byte() = IO.File.ReadAllBytes(coverFile)
                    Dim file2HideData As Byte() = IO.File.ReadAllBytes(file2Hide)
                    Dim combinedData As Byte() = coverData.Concat(file2HideData).ToArray()
                    IO.File.WriteAllBytes(saveLocation, combinedData)
                    MessageBox.Show("Files combined and saved successfully.")
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    Private Sub CreateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtCoverFile_TextChanged(sender As Object, e As EventArgs) Handles txtCoverFile.TextChanged

    End Sub
End Class