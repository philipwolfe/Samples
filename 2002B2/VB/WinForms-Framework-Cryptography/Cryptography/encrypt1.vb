Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Public Class Encrypt
    Private Shared symkey(8) As Byte
    Private Shared symIV(8) As Byte

    ''/////////////////////////////////////////////////////////////
    ' Compute DESProvider Key and IV Values
    Public Function GenerateKeyFromPassPhrase(ByVal phrase As String) As Boolean
        Try

            ' change the pass phrase into a form we can use
            Dim i As Integer
            Dim Len As Integer
            Dim CharPhrase() As Char = phrase.ToCharArray()
            Len = CharPhrase.GetLength(0)
            ' convert to byte array -  discard upper byte since is usually 0 in Eng.
            Dim BinPhrase(Len) As Byte
            For i = 0 To Len - 1
                BinPhrase(i) = CByte(AscW(CharPhrase(i)))  ' truncate char value
            Next i

            'do the hash operation 
            Dim SHAProvider As New SHA1CryptoServiceProvider()
            SHAProvider.ComputeHash(BinPhrase)

            ' use the low 64-bits for the key value 
            For i = 0 To 7
                symkey(i) = SHAProvider.Hash(i)
            Next i

            For i = 8 To 15
                symIV(i - 8) = SHAProvider.Hash(i)
            Next i

            GenerateKeyFromPassPhrase = True
        Catch e As Exception
            Console.WriteLine(e)
            GenerateKeyFromPassPhrase = False
        End Try
    End Function

    '/////////////////////////////////////////////////////////////
    ' Encrypt/Decrypt Data
    Public Shared Sub EncryptData(ByVal inName As String, ByVal outName As String)


        Try
            Dim i As Integer

            ' Open the input and output files
            Dim FileIn As FileStream = New FileStream(inName, FileMode.Open, FileAccess.Read)

            Dim FileOut As FileStream = New FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write)
            FileOut.SetLength(0)

            ' setup up variable to help with read
            Dim Bin(1024) As Byte
            Dim Len As Integer
            Dim FileLen As Long = FileIn.Length

            ' Crypto specific code starts here 
            ' create the DESProvider encryptor
            Dim DESProvider As New DESCryptoServiceProvider()

            Dim CryptTransform As System.Security.Cryptography.ICryptoTransform = DESProvider.CreateEncryptor(symkey, symIV)
            Dim DESEncrypt As CryptoStream = New CryptoStream(FileIn, CryptTransform, CryptoStreamMode.Read)

            Do
                Len = DESEncrypt.Read(Bin, 0, 1024)
                FileOut.Write(Bin, 0, Len)
                Console.WriteLine("Processed {0} bytes, {1} bytes total", Len, FileLen)
            Loop While Len > 0

            ' Crypto specific code ends here 
            FileOut.Close()
            FileIn.Close()

        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub

    Public Shared Sub DecryptData(ByVal inName As String, ByVal outName As String)
        Try
            Dim i As Integer

            ' Open the input and output files
            Dim FileIn As FileStream = New FileStream(inName, FileMode.Open, FileAccess.Read)

            Dim FileOut As FileStream = New FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write)
            FileOut.SetLength(0)

            ' setup up variable to help with read
            Dim Bin(1024) As Byte
            Dim Len As Integer
            Dim FileLen As Long = FileIn.Length



            ' Crypto specific code starts here 
            ' create the DESProvider encryptor and the SymmetricStreamEncryptor obj 
            Dim DESProvider As New DESCryptoServiceProvider()

            Dim CryptTransform As System.Security.Cryptography.ICryptoTransform = DESProvider.CreateDecryptor(symkey, symIV)
            Dim DESDecrypt As CryptoStream = New CryptoStream(FileIn, CryptTransform, CryptoStreamMode.Read)

            Do
                Len = DESDecrypt.Read(Bin, 0, 1024)
                FileOut.Write(Bin, 0, Len)
                Console.WriteLine("Processed {0} bytes, {1} bytes total", Len, FileLen)
            Loop While Len > 0

            ' Crypto specific code ends here 
            FileOut.Close()
            FileIn.Close()

        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub
End Class

