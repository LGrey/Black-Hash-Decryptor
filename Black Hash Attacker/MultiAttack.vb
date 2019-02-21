Imports System.Security.Cryptography
Imports System.Text
Module BuruteForce
    Public Function GetHashMD5(theInput) As String
        Using hasher As MD5 = MD5.Create
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))
            Dim sBuilder As New StringBuilder()
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n
            Return sBuilder.ToString()
        End Using
    End Function
    Public Function GetHashSHA1(theInput) As String
        Using hasher As SHA1 = SHA1.Create
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))
            Dim sBuilder As New StringBuilder()
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n
            Return sBuilder.ToString()
        End Using
    End Function
    Public Function GetHashSHA256(theInput) As String
        Using hasher As SHA256 = SHA256.Create
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))
            Dim sBuilder As New StringBuilder()
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n
            Return sBuilder.ToString()
        End Using
    End Function
    Public Function GetHashSHA384(theInput) As String
        Using hasher As SHA384 = SHA384.Create
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))
            Dim sBuilder As New StringBuilder()
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n
            Return sBuilder.ToString()
        End Using
    End Function
    Public Function GetHashSHA512(theInput) As String
        Using hasher As SHA512 = SHA512.Create
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))
            Dim sBuilder As New StringBuilder()
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n
            Return sBuilder.ToString()
        End Using
    End Function
End Module
