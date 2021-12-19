' This program uses a passphrase-derived key and DES encryption to encrypt a test file then decrypt it.

Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Namespace ClassLibrary1
    Public Class encrypt1
        Private Shared symkey(8) As Byte
        Private Shared symIV(8) As Byte
        Private Shared passPhrase As String = "YourDog123"
        Private Shared inputFileName As String = "input.txt"
        Private Shared encrypedFileName As String = "encrypted.txt"
        Private Shared deencrypedFileName As String = "decrypted.txt"
    
        Public Shared Sub Main()
            Console.WriteLine("Creating Key")
            'fills in symKey and symIV arrays
            GenerateKeyFromPassPhrase(passPhrase)
        
            Console.WriteLine("Encrypting {0}", inputFileName)
            EncryptDecryptData(inputFileName, encrypedFileName)
            Console.WriteLine("Decrypting {0}", encrypedFileName)
            EncryptDecryptData(encrypedFileName, deencrypedFileName)

            Console.WriteLine
            Console.WriteLine("Press Return to exit.")
            Console.Read()
        End Sub

        '/////////////////////////////////////////////////////////////
        ' Compute DES Key and IV Values
        Private Shared Function GenerateKeyFromPassPhrase(ByVal phrase As String) As Boolean
            Try
            ' change the pass phrase into a form we can use
                Dim i As Integer
                Dim len As Integer
                Dim cp() As Char = phrase.ToCharArray()
                len = cp.GetLength(0)
                ' convert to byte array -  discard upper byte since is usually 0 in Eng.
                Dim bp(len) As Byte
                For i = 0 To len - 1
                     bp(i) = CByte (cp(i)) ' truncate char value
                Next i

                ' Crypto specific code starts here
                ' allocate the key and IV arrays, assumes DES size
                'Dim symkey(8) As Byte
                'Dim symIV(8) As Byte
                'do the hash operation 
                Dim sha As New SHA1_CSP
                sha.Write(bp)
                sha.CloseStream()
                ' Crypto specific code ends here 
                ' use the low 64-bits for the key value 
                For i = 0 To 7
                    symkey(i) = sha.Hash(i) 
                Next i

                For i = 8 To 15
                    symIV(i - 8) = sha.Hash(i)
                Next i
            
                GenerateKeyFromPassPhrase = True
            Catch e As Exception
                Console.WriteLine(e)
                GenerateKeyFromPassPhrase = False
            End Try
        End Function

        '/////////////////////////////////////////////////////////////
        ' Encrypt/Decrypt Data
        Private Shared Sub EncryptDecryptData(ByVal inName As String, ByVal outName As String)
            Try
				Dim i as Integer
                Dim bEncrypt As Boolean = True
            
                ' Open the input and output files
                Dim fin As FileStream = New FileStream(inName, FileMode.Open, FileAccess.Read)
            
                Dim fout As FileStream = New FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write)
                fout.SetLength(0)
            
                ' setup up variable to help with read
                Dim bin(4096) As Byte
                Dim totlen As Long = fin.Length
                Dim rdlen As Long = 8
                Dim len As Integer

            
                ' figure out if we're encrypting or decrypting 
                Dim tag(8) As Byte
                fin.Read(tag, 0, 8)
                If ((tag(0) = CByte("["c)) And (tag(1) = CByte("E"c)) And (tag(2) = CByte("n"c)) And (tag(3) = CByte("c"c)) And (tag(4) = CByte("]"c))) Then
                    Console.WriteLine("Decrypting data")
                    bEncrypt = False
                Else
                    Console.WriteLine("Encrypting")
                    fin.Seek(0, SeekOrigin.Begin)
                    rdlen = 0
                End If
            
                ' Crypto specific code starts here 
                ' create the DES encryptor and the SymmetricStreamEncryptor obj 
                Dim des As DES_CSP = New DES_CSP
                Dim scs As StoreCryptoStream = New StoreCryptoStream(bEncrypt, fout)
            
                If bEncrypt Then
                    Dim sse As SymmetricStreamEncryptor = des.CreateEncryptor(symkey, symIV)
                
                    ' a little extra feature here to show how to compose crypto  
                    ' components that support ICryptoStream 
                    Dim sha As SHA1_CSP = New SHA1_CSP
                
                    ' wire up the encryptor - hash - StoreCryptoStream 
                    sse.SetSink(sha)
                    sha.SetSource(sse)
                    sha.SetSink(scs)
                    scs.SetSource(sha)
                    While (rdlen < totlen)
                        len = fin.Read(bin, 0, 4096)
                        sse.Write(bin, 0, len)
                        rdlen = rdlen + len
                        Console.WriteLine("Processed {0} bytes, {1} bytes total", len, rdlen)
                    End While
                    sse.CloseStream()
                    Console.WriteLine("HASH of the encrypted stream is:")
					Console.Write(Strings.chr(9))
                    For i = 0 To 19
                        Console.Write("{0} ", sha.Hash(i))
                    Next i
					Console.WriteLine()
                Else
                    Dim ssd As SymmetricStreamDecryptor = des.CreateDecryptor(symkey, symIV)
                    ssd.SetSink(scs)
                    scs.SetSource(ssd)
                    While (rdlen < totlen)
                        len = fin.Read(bin, 0, 4096)
                        ssd.Write(bin, 0, len)
                        rdlen = rdlen + len
                        Console.WriteLine("Processed {0} bytes, {1} bytes total", len, rdlen)
                    End While
                    ssd.CloseStream()
                End If
                ' Crypto specific code ends here 
            
                fin.Close()
        
            Catch e As Exception
                Console.WriteLine(e)
            End Try
        End Sub
    End Class

    Public Class StoreCryptoStream
        Implements ICryptoStream

        Shared tag() As Byte = { CByte("["c), CByte("E"c), CByte("n"c), CByte("c"c), CByte("]"c), &H20, &H20, &H20 }
        Dim fs As FileStream

        '////////////////////////////////////////////////////////////////
        '// Constructor
        Public Sub new(ByVal bEncrypt As Boolean, ByVal fout As FileStream)
            MyBase.new()
            fs = fout
            If bEncrypt Then
                fs.Write(tag, 0, 8)
            End If
        End Sub

        Overloads Public Sub CloseStream() Implements ICryptoStream.CloseStream
            fs.Close()
        End Sub

        Overloads Public Sub CloseStream(ByVal obj As Object) Implements ICryptoStream.CloseStream
            fs.Close()
        End Sub

        Public Sub SetSink(ByVal pstm As ICryptoStream) Implements ICryptoStream.SetSink
        End Sub

        Public Sub SetSource(ByVal co As CryptographicObject) Implements ICryptoStream.SetSource
        End Sub
        
        Public Function  GetSink () As ICryptoStream  Implements ICryptoStream.GetSink
          return Nothing
        End Function

        '////////////////////////////////////////////////////////////////
        '// Write routines just copy output ot the target file
        Overloads Public Sub Write(ByVal bin() As Byte) Implements ICryptoStream.Write
            Dim len As Integer = bin.GetLength(0)
            Write(bin, 0, len)
        End Sub
 
        Overloads Public Sub write(ByVal bin() As Byte, ByVal start As Integer, ByVal len As Integer) Implements ICryptoStream.Write
            fs.Write(bin, start, len)
        End Sub

    End Class


End Namespace