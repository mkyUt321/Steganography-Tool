' ExtractionResultsForm.vb
Public Class ExtractionResultsForm
    Inherits Form

    Private steganoFile As String
    Private lblDescription As New Label()
    Private lstFiles As New ListBox()
    Private btnDownloadAll As New Button()

    ' Define file signatures and their end markers
    Private ReadOnly fileSignatures As New Dictionary(Of Byte(), Byte()) From {
            {New Byte() {&H25, &H50, &H44, &H46}, New Byte() {&H25, &H25, &H45, &H4F, &H46}}, ' PDF (%PDF ... %%EOF)
            {New Byte() {&H3C, &H68, &H74, &H6D, &H6C}, New Byte() {&H3C, &H2F, &H68, &H74, &H6D, &H6C, &H3E}}, ' HTML (<html ... </html>)
            {New Byte() {&H3C, &H3F, &H78, &H6D, &H6C}, New Byte() {&H3C, &H2F, &H78, &H6D, &H6C, &H3E}}, ' XML (<?xml ... </xml>)
            {New Byte() {&H63, &H73, &H76}, New Byte() {&H63, &H73, &H76}}, ' CSV (csv ... csv)
            {New Byte() {&HD0, &HCF, &H11, &HE0, &HA1, &HB1, &H1A, &HE1}, New Byte() {}}, ' DOC / XLS / PPT (D0 CF 11 E0 A1 B1 1A E1)
            {New Byte() {&H50, &H4B, &H3, &H4}, New Byte() {&H50, &H4B, &H5, &H6}}, ' DOCX / XLSX / PPTX (PK... ... PK...)
            {New Byte() {&HFF, &HD8, &HFF}, New Byte() {&HFF, &HD9}}, ' JPG / JPEG (FF D8 FF ... FF D9)
            {New Byte() {&H89, &H50, &H4E, &H47, &HD, &HA, &H1A, &HA}, New Byte() {&H49, &H45, &H4E, &H44, &HAE, &H42, &H60, &H82}}, ' PNG (‰PNG ... IEND®B`‚)
            {New Byte() {&H47, &H49, &H46, &H38}, New Byte() {&H3B}}, ' GIF (GIF8 ... ;)
            {New Byte() {&H49, &H49, &H2A, &H0}, New Byte() {}}, ' TIFF (II*...)
            {New Byte() {&H4D, &H4D, &H0, &H2A}, New Byte() {}}, ' TIFF (MM..*)
            {New Byte() {&H3C, &H73, &H76, &H67}, New Byte() {&H3C, &H2F, &H73, &H76, &H67, &H3E}}, ' SVG (<svg ... </svg>)
            {New Byte() {&H52, &H49, &H46, &H46}, New Byte() {&H57, &H45, &H42, &H50}}, ' WEBP (RIFF ... WEBP)
            {New Byte() {&H49, &H44, &H33}, New Byte() {}}, ' MP3 (ID3)
            {New Byte() {&H52, &H49, &H46, &H46}, New Byte() {&H57, &H41, &H56, &H45}}, ' WAV (RIFF ... WAVE)
            {New Byte() {&H66, &H4C, &H61, &H43}, New Byte() {}}, ' FLAC (fLaC)
            {New Byte() {&H4F, &H67, &H67, &H53}, New Byte() {}}, ' OGG (OggS)
            {New Byte() {&H0, &H0, &H0, &H18, &H66, &H74, &H79, &H70}, New Byte() {}}, ' MP4 (....ftyp)
            {New Byte() {&H52, &H49, &H46, &H46}, New Byte() {&H41, &H56, &H49, &H20}}, ' AVI (RIFF....AVI )
            {New Byte() {&H0, &H0, &H0, &H14, &H66, &H74, &H79, &H70, &H71, &H74}, New Byte() {}}, ' MOV (....ftypqt)
            {New Byte() {&H30, &H26, &HB2, &H75, &H8E, &H66, &HCF, &H11, &HA6, &HD9, &H0, &HAA, &H0, &H62, &HCE, &H6C}, New Byte() {}}, ' WMV (0&²u†fÏ.¦Ù.ª.bÎl)
            {New Byte() {&H1A, &H45, &HDF, &HA3}, New Byte() {&H42, &H82}}, ' MKV (....Eß£...B‚)
            {New Byte() {&H50, &H4B, &H3, &H4}, New Byte() {&H50, &H4B, &H5, &H6}}, ' ZIP (PK... ... PK...)
            {New Byte() {&H52, &H61, &H72, &H21, &H1A, &H7}, New Byte() {}}, ' RAR (Rar!... )
            {New Byte() {&H37, &H7A, &HBC, &HAF, &H27, &H1C}, New Byte() {}}, ' 7Z (7z¼¯'...)
            {New Byte() {&H75, &H73, &H74, &H61, &H72}, New Byte() {}} ' TAR (ustar)
        }
    'とりあえず諦めたやつらリスト [gz json bmp aac txt]
    'txt はシグネチャなしで別処理になりそう
    'デバッグ済リスト [pdf html jpg jpeg png tiff]

    Public Sub New(steganoFile As String)
        Me.steganoFile = steganoFile
        Me.Text = "Extraction Results"
        Me.Size = New Size(500, 420)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

        ' 説明ラベル
        lblDescription.Text = "The following hidden file has been detected !!!" & Environment.NewLine & "If the list is empty, it means either no hidden files were found or the hidden file is of a type not supported by the software."
        lblDescription.Location = New Point(10, 10)
        lblDescription.Size = New Size(460, 60)
        lblDescription.AutoSize = False
        lblDescription.MaximumSize = New Size(460, 0)
        lblDescription.AutoSize = True
        Me.Controls.Add(lblDescription)

        ' ファイルリストのリストボックス
        lstFiles.Location = New Point(10, 140)
        lstFiles.Size = New Size(460, 140)
        lstFiles.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        AddHandler lstFiles.DoubleClick, AddressOf lstFiles_DoubleClick
        Me.Controls.Add(lstFiles)

        ' 一括ダウンロードボタン
        btnDownloadAll.Text = "Download All"
        btnDownloadAll.Location = New Point(10, 290)
        btnDownloadAll.Size = New Size(460, 50)
        AddHandler btnDownloadAll.Click, AddressOf btnDownloadAll_Click
        Me.Controls.Add(btnDownloadAll)

        ExtractFiles()
    End Sub

    Private Sub ExtractFiles()
        Try
            Dim steganoData As Byte() = IO.File.ReadAllBytes(steganoFile)
            Dim hiddenFiles As New List(Of String)()

            For Each signature In fileSignatures
                Dim identifier As Byte() = signature.Key
                Dim eofIdentifier As Byte() = signature.Value

                Dim identifierIndex As Integer = FindPattern(steganoData, identifier, 0)
                While identifierIndex <> -1
                    Dim endIndex As Integer = FindPattern(steganoData, eofIdentifier, identifierIndex + identifier.Length)
                    If endIndex <> -1 Then
                        endIndex += eofIdentifier.Length
                        Dim fileData As Byte() = steganoData.Skip(identifierIndex).Take(endIndex - identifierIndex).ToArray()

                        ' 隠しファイルが存在するか確認
                        If fileData.Length > 0 Then
                            Dim fileName As String = $"HiddenFile_{identifierIndex}{GetFileExtension(identifier)}"
                            hiddenFiles.Add(fileName)
                        End If
                    End If
                    identifierIndex = FindPattern(steganoData, identifier, endIndex)
                End While
            Next

            ' ファイル名でソート
            ' カバーファイルを除外
            hiddenFiles.Sort()
            If hiddenFiles.Count > 0 Then
                hiddenFiles.RemoveAt(0)
            End If

            ' リストボックスに追加
            lstFiles.Items.AddRange(hiddenFiles.ToArray())
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
            Me.DialogResult = DialogResult.Cancel
        End Try
    End Sub

    Private Function GetFileExtension(identifier As Byte()) As String
        If identifier.SequenceEqual(New Byte() {&H25, &H50, &H44, &H46}) Then
            Return ".pdf"
        ElseIf identifier.SequenceEqual(New Byte() {&H3C, &H68, &H74, &H6D, &H6C}) Then
            Return ".html"
        ElseIf identifier.SequenceEqual(New Byte() {&H3C, &H3F, &H78, &H6D, &H6C}) Then
            Return ".xml"
        ElseIf identifier.SequenceEqual(New Byte() {&H63, &H73, &H76}) Then
            Return ".csv"
        ElseIf identifier.SequenceEqual(New Byte() {&HD0, &HCF, &H11, &HE0, &HA1, &HB1, &H1A, &HE1}) Then
            Return ".doc" ' Could be .doc, .xls, or .ppt
        ElseIf identifier.SequenceEqual(New Byte() {&H50, &H4B, &H3, &H4}) Then
            Return ".docx" ' Could be .docx, .xlsx, or .pptx
        ElseIf identifier.SequenceEqual(New Byte() {&HFF, &HD8, &HFF}) Then
            Return ".jpg"
        ElseIf identifier.SequenceEqual(New Byte() {&H89, &H50, &H4E, &H47, &HD, &HA, &H1A, &HA}) Then
            Return ".png"
        ElseIf identifier.SequenceEqual(New Byte() {&H47, &H49, &H46, &H38}) Then
            Return ".gif"
        ElseIf identifier.SequenceEqual(New Byte() {&H49, &H49, &H2A, &H0}) OrElse identifier.SequenceEqual(New Byte() {&H4D, &H4D, &H0, &H2A}) Then
            Return ".tiff"
        ElseIf identifier.SequenceEqual(New Byte() {&H3C, &H73, &H76, &H67}) Then
            Return ".svg"
        ElseIf identifier.SequenceEqual(New Byte() {&H52, &H49, &H46, &H46}) Then
            Return ".webp"
        ElseIf identifier.SequenceEqual(New Byte() {&H49, &H44, &H33}) Then
            Return ".mp3"
        ElseIf identifier.SequenceEqual(New Byte() {&H52, &H49, &H46, &H46}) Then
            Return ".wav"
        ElseIf identifier.SequenceEqual(New Byte() {&H66, &H4C, &H61, &H43}) Then
            Return ".flac"
        ElseIf identifier.SequenceEqual(New Byte() {&H4F, &H67, &H67, &H53}) Then
            Return ".ogg"
        ElseIf identifier.SequenceEqual(New Byte() {&H0, &H0, &H0, &H18, &H66, &H74, &H79, &H70}) Then
            Return ".mp4"
        ElseIf identifier.SequenceEqual(New Byte() {&H52, &H49, &H46, &H46}) Then
            Return ".avi"
        ElseIf identifier.SequenceEqual(New Byte() {&H0, &H0, &H0, &H14, &H66, &H74, &H79, &H70, &H71, &H74}) Then
            Return ".mov"
        ElseIf identifier.SequenceEqual(New Byte() {&H30, &H26, &HB2, &H75, &H8E, &H66, &HCF, &H11, &HA6, &HD9, &H0, &HAA, &H0, &H62, &HCE, &H6C}) Then
            Return ".wmv"
        ElseIf identifier.SequenceEqual(New Byte() {&H1A, &H45, &HDF, &HA3}) Then
            Return ".mkv"
        ElseIf identifier.SequenceEqual(New Byte() {&H50, &H4B, &H3, &H4}) Then
            Return ".zip"
        ElseIf identifier.SequenceEqual(New Byte() {&H52, &H61, &H72, &H21, &H1A, &H7}) Then
            Return ".rar"
        ElseIf identifier.SequenceEqual(New Byte() {&H37, &H7A, &HBC, &HAF, &H27, &H1C}) Then
            Return ".7z"
        ElseIf identifier.SequenceEqual(New Byte() {&H75, &H73, &H74, &H61, &H72}) Then
            Return ".tar"
        Else
            Return ".bin"
        End If
    End Function

    Private Function FindPattern(data As Byte(), pattern As Byte(), startIndex As Integer) As Integer
        If data Is Nothing OrElse pattern Is Nothing OrElse startIndex < 0 OrElse startIndex >= data.Length Then
            Return -1
        End If

        For i As Integer = startIndex To data.Length - pattern.Length
            Dim found As Boolean = True
            For j As Integer = 0 To pattern.Length - 1
                If data(i + j) <> pattern(j) Then
                    found = False
                    Exit For
                End If
            Next
            If found Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub lstFiles_DoubleClick(sender As Object, e As EventArgs)
        If lstFiles.SelectedItem Is Nothing Then
            Return
        End If

        Dim selectedFile As String = lstFiles.SelectedItem.ToString()
        Dim identifierIndex As Integer

        ' ファイル名からインデックスを取得
        Try
            identifierIndex = Integer.Parse(selectedFile.Split("_"c)(1).Split("."c)(0))
        Catch ex As Exception
            MessageBox.Show("Failed to parse the file index from the file name.")
            Return
        End Try

        Try
            Dim steganoData As Byte() = IO.File.ReadAllBytes(steganoFile)
            For Each signature In fileSignatures
                Dim identifier As Byte() = signature.Key
                Dim eofIdentifier As Byte() = signature.Value

                If steganoData.Skip(identifierIndex).Take(identifier.Length).SequenceEqual(identifier) Then
                    Dim endIndex As Integer = FindPattern(steganoData, eofIdentifier, identifierIndex + identifier.Length)
                    If endIndex = -1 Then
                        MessageBox.Show("EOF not found for the selected file.")
                        Return
                    End If

                    endIndex += eofIdentifier.Length
                    Dim fileData As Byte() = steganoData.Skip(identifierIndex).Take(endIndex - identifierIndex).ToArray()

                    Using fbd As New FolderBrowserDialog()
                        If fbd.ShowDialog() = DialogResult.OK Then
                            Dim savePath As String = IO.Path.Combine(fbd.SelectedPath, selectedFile)
                            IO.File.WriteAllBytes(savePath, fileData)
                            MessageBox.Show("Hidden file saved successfully.")
                        End If
                    End Using
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDownloadAll_Click(sender As Object, e As EventArgs)
        If lstFiles.Items.Count = 0 Then
            MessageBox.Show("No files to download.")
            Return
        End If

        Using fbd As New FolderBrowserDialog()
            If fbd.ShowDialog() = DialogResult.OK Then
                Dim savePath As String = fbd.SelectedPath
                For Each fileName As String In lstFiles.Items
                    ' Ensure the file name has the expected format
                    If Not fileName.Contains("_") OrElse Not fileName.Contains(".") Then
                        MessageBox.Show($"Invalid file name format: {fileName}")
                        Continue For
                    End If

                    Dim identifierIndex As Integer
                    Try
                        identifierIndex = Integer.Parse(fileName.Split("_"c)(1).Split("."c)(0))
                    Catch ex As Exception
                        MessageBox.Show($"Failed to parse the file index from the file name: {fileName}")
                        Continue For
                    End Try

                    Try
                        Dim steganoData As Byte() = IO.File.ReadAllBytes(steganoFile)
                        For Each signature In fileSignatures
                            Dim identifier As Byte() = signature.Key
                            Dim eofIdentifier As Byte() = signature.Value

                            If steganoData.Skip(identifierIndex).Take(identifier.Length).SequenceEqual(identifier) Then
                                Dim endIndex As Integer = FindPattern(steganoData, eofIdentifier, identifierIndex + identifier.Length)
                                If endIndex = -1 Then
                                    MessageBox.Show($"EOF not found for the file: {fileName}")
                                    Continue For
                                End If

                                endIndex += eofIdentifier.Length
                                Dim fileData As Byte() = steganoData.Skip(identifierIndex).Take(endIndex - identifierIndex).ToArray()
                                Dim fullPath As String = IO.Path.Combine(savePath, fileName)
                                IO.File.WriteAllBytes(fullPath, fileData)
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        MessageBox.Show("An error occurred: " & ex.Message)
                    End Try
                Next
                MessageBox.Show("All hidden files saved successfully.")
            End If
        End Using
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ExtractionResultsForm
        '
        Me.ClientSize = New System.Drawing.Size(278, 244)
        Me.Name = "ExtractionResultsForm"
        Me.ResumeLayout(False)

    End Sub

    Private Sub ExtractionResultsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class