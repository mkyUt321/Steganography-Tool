' ExtractForm.vb﻿
Public Class ExtractForm
    Inherits Form

    Public Sub New()
        InitializeComponent()
        Me.Text = "Extract Steganography"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.Size = New Size(620, 200)

        ' Select File to Analyze Button
        btnSelectFile2Analyze.Text = "Select File to Analyze"
        btnSelectFile2Analyze.Size = New Size(200, 35)
        btnSelectFile2Analyze.Location = New Point(10, 10)
        Me.Controls.Add(btnSelectFile2Analyze)

        ' File to Analyze Path Textbox
        txtFile2Analyze.Size = New Size(360, 40)
        txtFile2Analyze.Location = New Point(215, 10)
        Me.Controls.Add(txtFile2Analyze)

        ' Extract Button
        btnExtract.Text = "Extract"
        btnExtract.Size = New Size(200, 50)
        btnExtract.Location = New Point(370, 70)
        Me.Controls.Add(btnExtract)
    End Sub

    Private Sub btnSelectFile2Analyze_Click(sender As Object, e As EventArgs) Handles btnSelectFile2Analyze.Click
        ' Select File to Analyze Button Click Event
        Using ofd As New OpenFileDialog()
            If ofd.ShowDialog() = DialogResult.OK Then
                txtFile2Analyze.Text = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnExtract.Click
        ' ExtractionResultsForm を表示
        Dim file2Analyze As String = txtFile2Analyze.Text

        If String.IsNullOrEmpty(file2Analyze) Then
            MessageBox.Show("Please select a file to analyze.")
            Return
        End If

        Dim extractionResultsForm As New ExtractionResultsForm(file2Analyze)
        extractionResultsForm.ShowDialog()
    End Sub

    Private Sub ExtractForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class