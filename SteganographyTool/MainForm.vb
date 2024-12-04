' MainForm.vb
Public Class MainForm
    Inherits Form

    ' declare CreateButton and ExtractButton
    Private WithEvents CreateButton As New Button()
    Private WithEvents ExtractButton As New Button()
    Private InfoLabel As New Label()

    Public Sub New()
        ' Initialize MainForm
        InitializeComponent()
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.Size = New Size(640, 180)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create Stegano Button
        CreateButton.Text = "Create"
        CreateButton.Size = New Size(150, 50)
        CreateButton.Location = New Point(250, 60)
        Me.Controls.Add(CreateButton)

        ' Extract Hidden Button
        ExtractButton.Text = "Extract"
        ExtractButton.Size = New Size(150, 50)
        ExtractButton.Location = New Point(440, 60)
        Me.Controls.Add(ExtractButton)

        ' Info Label
        InfoLabel.Text = "This software allows you to create and extract files with steganography."
        InfoLabel.Size = New Size(600, 30)
        InfoLabel.Location = New Point(10, 10)
        Me.Controls.Add(InfoLabel)
    End Sub

    Private Sub CreateButton_Click(sender As Object, e As EventArgs) Handles CreateButton.Click
        ' Transfer CreateForm
        Dim createForm As New CreateForm()
        createForm.Show()
    End Sub

    Private Sub ExtractButton_Click(sender As Object, e As EventArgs) Handles ExtractButton.Click
        ' Transfer RemoveForm
        Dim removeForm As New ExtractForm()
        removeForm.Show()
    End Sub
End Class