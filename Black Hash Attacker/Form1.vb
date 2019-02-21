Imports System.Security.Cryptography
Imports System.Text
Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim a As New OpenFileDialog
        With a
            .Filter = "txt (*.txt)|*.txt"
            .Title = "select password list"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox6.Text = .FileName
            Else
                Return
            End If
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim a As New OpenFileDialog
        With a
            .Filter = "txt (*.txt)|*.txt"
            .Title = "select password list"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox5.Text = .FileName
            Else
                Return
            End If
        End With
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim attacker As New Threading.Thread(AddressOf Attack)
        attacker.Start()
    End Sub
    Function Attack()
        On Error Resume Next
        Dim PasswordList() As String = IO.File.ReadAllLines(TextBox6.Text)
        Dim HashList() As String = IO.File.ReadAllLines(TextBox5.Text)
        IO.File.Create("OutputMD5.txt")
        For Each password As String In PasswordList
            For Each hash As String In HashList
                If GetHashMD5(password) = hash.ToUpper Then
                    IO.File.AppendAllText("OutputMD5.txt", "Password Found [ " & password & ":" & hash & " ]" & vbNewLine)
                End If
            Next
        Next
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox3.Text = "Please Wait..."
        Dim attacker As New Threading.Thread(AddressOf SingleAttack)
        attacker.Start(ComboBox1.Text)
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New OpenFileDialog
        With a
            .Filter = "txt (*.txt)|*.txt"
            .Title = "select password list"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox1.Text = .FileName
            Else
                Return
            End If
        End With
    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text.Length = 32 Then
            ComboBox1.Text = "MD5"
        ElseIf TextBox2.Text.Length = 40 Then
            ComboBox1.Text = "SHA1"
        ElseIf TextBox2.Text.Length = 64 Then
            ComboBox1.Text = "SHA256"
        ElseIf TextBox2.Text.Length = 96 Then
            ComboBox1.Text = "SHA384"
        ElseIf TextBox2.Text.Length = 128 Then
            ComboBox1.Text = "SHA512"
        End If
    End Sub
    Private Delegate Sub UpdateStatusLabelDelegate(ByVal status As String)
    Private Sub UpdateStatusLabel(ByVal status As String)
        Try
            BeginInvoke(New UpdateStatusLabelDelegate(AddressOf UpdateStatusLabelSub), status)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdateStatusLabelSub(ByVal status As String)
        Try
            TextBox3.Text = status
        Catch ex As Exception

        End Try
    End Sub
    Sub SingleAttack(ByVal HashType As String)
        Dim PasswordList() As String = IO.File.ReadAllLines(TextBox1.Text)
        For Each hash As String In PasswordList
            Select Case HashType
                Case "MD5"
                    If GetHashMD5(hash) = TextBox2.Text.ToUpper Then
                        UpdateStatusLabel("Password Found : " & hash)
                        Return
                    End If
                Case "SHA1"
                    If GetHashSHA1(hash) = TextBox2.Text.ToUpper Then
                        UpdateStatusLabel("Password Found : " & hash)
                        Return
                    End If
                Case "SHA256"
                    If GetHashSHA256(hash) = TextBox2.Text.ToUpper Then
                        UpdateStatusLabel("Password Found : " & hash)
                        Return
                    End If
                Case "SHA384"
                    If GetHashSHA384(hash) = TextBox2.Text.ToUpper Then
                        UpdateStatusLabel("Password Found : " & hash)
                        Return
                    End If
                Case "SHA512"
                    If GetHashSHA512(hash) = TextBox2.Text.ToUpper Then
                        UpdateStatusLabel("Password Found : " & hash)
                        Return
                    End If
            End Select
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
End Class