'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO
Imports System.Security.Cryptography
Imports System.Threading

Class SampleCrypto

    ' This routine creates a new symmetric algorithm object of the chosen type.
    Public Sub New(ByVal strCryptoName As String)
        ' The shared Create method of the abstract symmetric algorithm base class
        ' implements a factory design for the creation of its concrete classes.
        crpSym = SymmetricAlgorithm.Create(strCryptoName)

        ' Initialize the byte arrays to the proper length for the 
        ' instantiated crypto class.
        ReDimByteArrays()
    End Sub

    Private abytIV() As Byte
    Private abytKey() As Byte
    Private abytSalt() As Byte
    Private crpSym As SymmetricAlgorithm
    Private strPassword As String = ""
    Private strSaltIVFile As String = ""
    Private strSourceFile As String = ""

    Public Property Password() As String
        Get
            Return strPassword
        End Get
        Set(ByVal Value As String)
            strPassword = Value
        End Set
    End Property

    Public Property SaltIVFile() As String
        Get
            Return strSaltIVFile
        End Get
        Set(ByVal Value As String)
            If File.Exists(Value) Then
                strSaltIVFile = Value
            Else
                Throw New FileNotFoundException("The SaltIV .dat file for the " & _
                    "selected crypto type was not found. Before encrypting or " & _
                    "decrypting you must create this file.")
            End If
        End Set
    End Property

    Public Property SourceFileName() As String
        Get
            Return strSourceFile
        End Get
        Set(ByVal Value As String)
            If File.Exists(Value) Then
                strSourceFile = Value
            Else
                Throw New FileNotFoundException(Value & " does not exist.")
            End If
        End Set
    End Property

    ' This routine creates a .dat file containing the salt and IV.
    Public Function CreateSaltIVFile(ByVal strSaveToPath As String) As Boolean

        ' Initialize the byte arrays to the proper length for the 
        ' instantiated crypto class.
        ReDimByteArrays()

        ' Create a Filestream object to write the salt and IV to a file.
        Dim fsKey As New FileStream(strSaveToPath, FileMode.OpenOrCreate, _
            FileAccess.Write)

        ' Generate a random "salt" value. These random bytes are appended to the
        ' password before the key derivation, making what a "Dictionary
        ' Attack" much more difficult. The concept is similar to the use of an IV.
        Dim rng As RandomNumberGenerator = RandomNumberGenerator.Create()
        rng.GetBytes(abytSalt)

        Dim pdb As New PasswordDeriveBytes(strPassword, abytSalt)
        ' Get the same amount of bytes as the current abytKey length as set in 
        ' ReDimByteArrays().
        abytKey = pdb.GetBytes(abytKey.Length)

        ' Generate a new random IV.
        crpSym.GenerateIV()
        abytIV = crpSym.IV

        Try
            fsKey.Write(abytSalt, 0, abytSalt.Length)
            fsKey.Write(abytIV, 0, abytIV.Length)
            strSaltIVFile = strSaveToPath
            Return True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            fsKey.Close()
        End Try
    End Function

    ' This routine decrypts a file.
    Public Sub DecryptFile()

        ' If the password is an empty string assume the user has not checked the 
        ' "Advanced" CheckBox or has not entered a password and thus is not using
        ' a password-derived key. In such a case the symmetric algorithm object 
        ' will just use its default values.
        If strPassword <> "" Then
            OpenSaltIVFileAndSetKeyIV()
        End If

        ' Create a FileStream object to read back the encrypted file.
        Dim fsCipherText As New FileStream(strSourceFile, FileMode.Open, FileAccess.Read)
        ' Create a FileStream object to write to the temp file.
        Dim fsPlainText As New FileStream("temp.dat", FileMode.Create, FileAccess.Write)

        ' Read in the encrypted file and decrypt.
        Dim csDecrypted As New CryptoStream(fsCipherText, crpSym.CreateDecryptor(), _
            CryptoStreamMode.Read)
        ' Create a StreamWriter to write to the temp file.
        Dim swWriter As New StreamWriter(fsPlainText)
        ' Read the decrypted stream into a StreamReader.
        Dim srReader As New StreamReader(csDecrypted)

        Try
            ' Write out the decrypted stream.
            swWriter.Write(srReader.ReadToEnd)
        Catch expCrypto As CryptographicException
            Throw New CryptographicException()
        Finally
            ' Close and clean up.
            swWriter.Close()
            csDecrypted.Close()
        End Try

        SwapFiles(True)
    End Sub

    ' This routine encrypts a file.
    Public Sub EncryptFile()

        ' If the password is an empty string assume the user has not checked the 
        ' "Advanced" CheckBox and thus is not using a password-derived key. In such
        ' a case the symmetric algorithm object will just its default values.
        If strPassword <> "" Then
            OpenSaltIVFileAndSetKeyIV()
        End If

        ' Create a FileStream object to read in the source file.
        Dim fsInput As New FileStream(strSourceFile, FileMode.Open, FileAccess.Read)

        ' Create a byte array from the FileStream object by reading in the 
        ' source file.
        Dim abytInput(CInt(fsInput.Length - 1)) As Byte
        fsInput.Read(abytInput, 0, CInt(fsInput.Length))
        fsInput.Close()

        ' Create a FileStream object to write to a temp file.
        Dim fsCipherText As New FileStream("temp.dat", FileMode.Create, FileAccess.Write)
        fsCipherText.SetLength(0)

        ' Create a Crypto Stream that transforms the file stream using the chosen 
        ' encryption and writes it to the output FileStream object.
        Dim csEncrypted As New CryptoStream(fsCipherText, crpSym.CreateEncryptor(), _
            CryptoStreamMode.Write)

        ' Pass in the unencrypted source file byte array and write out 
        ' the encrypted bytes to the temp.dat file. Thus, the logic flow is:
        ' abytInput ----> Encryption ----> fsCipherText.
        csEncrypted.Write(abytInput, 0, abytInput.Length)

        ' When the bytes are all written it's important to indicate to the crypto 
        ' stream that you are through using it, and thus to finish processing any 
        ' bytes remaining in the buffer used by the crypto stream. Typically this 
        ' involves padding the last output block to a complete multiple of the crypto 
        ' object's block size (for Rijndael this is 16 bytes, or 128 bits), 
        ' encrypting it, and then writing this final block to the memory stream.
        csEncrypted.FlushFinalBlock()

        ' Clean up. There is no need to call fsCipherText.Close() because closing the
        ' crypto stream automatically encloses the stream that was passed into it.
        csEncrypted.Close()

        SwapFiles(False)
    End Sub

    ' This routine opens the .dat file, reads in the salt and IV, and then
    ' sets the crypto object's key and IV.
    Private Sub OpenSaltIVFileAndSetKeyIV()

        ' Initialize the byte arrays to the proper length for the 
        ' instantiated crypto class.
        ReDimByteArrays()

        ' Create a Filestream object to read in the contents of the .dat file
        ' that contains the salt and IV.
        Dim fsKey As New FileStream(strSaltIVFile, FileMode.Open, FileAccess.Read)
        fsKey.Read(abytSalt, 0, abytSalt.Length)
        fsKey.Read(abytIV, 0, abytIV.Length)
        fsKey.Close()

        ' Derive the key from the salted password.
        Dim pdb As New PasswordDeriveBytes(strPassword, abytSalt)
        ' Get the same amount of bytes as the current abytKey length as set in 
        ' ReDimByteArrays().
        abytKey = pdb.GetBytes(abytKey.Length)

        ' If the current crypto class is TripleDES, check to make sure the key being 
        ' used is not listed among the Weak Keys (i.e., keys known to have been 
        ' successfully attacked).
        If crpSym.GetType Is GetType(TripleDESCryptoServiceProvider) Then
            ' To access the IsWeakKey method you have to cast the SymmetricAlgorithm
            ' variable type to the TripleDES base class or 
            ' TripleDESCryptoServiceProvider.
            Dim tdes As TripleDES = CType(crpSym, TripleDES)
            If tdes.IsWeakKey(abytKey) Then
                Throw New Exception("The current key is listed as a Weak Key. " & _
                    "You should generate a different key before proceeding further.")
            End If
        End If

        ' Assign the byte arrays to the Key and IV properties of the instantiated
        ' symmetric crypto class. 
        crpSym.Key = abytKey
        crpSym.IV = abytIV

    End Sub

    ' This routine redimensions the byte arrays to the proper length for the 
    ' instantiated crypto class.
    Private Sub ReDimByteArrays()
        ' For demo/info purposes only, write out the legal key sizes.
        Debug.WriteLine(crpSym.GetType.ToString & " legal key sizes in bits:")
        Dim myKeySizes As KeySizes
        For Each myKeySizes In crpSym.LegalKeySizes
            With myKeySizes
                Debug.WriteLine("Max=" & .MaxSize & " bits " & _
                    "(" & (.MaxSize / 8) & " bytes)")
                Debug.WriteLine("Min=" & .MinSize & " bits " & _
                   "(" & (.MinSize / 8) & " bytes)")
                Debug.WriteLine("Skip=" & .SkipSize & " bits " & _
                   "(" & (.SkipSize / 8) & " bytes)")
            End With
        Next

        If crpSym.GetType Is GetType(System.Security.Cryptography.RijndaelManaged) Then
            ' The Key byte array size was retrieved via the LegalKeySizes property 
            ' of the crypto object. See the Debug.WriteLine statements that follow. 
            ' Keep in mind that the array size is always one more than the upper 
            ' bound, which you use to initialize the array. So the ReDim sizes are 
            ' 1 less than the legal key sizes acquired above.
            ReDim abytKey(31)
            ' A good rule-of-thumb is to make the salt 1/2 the length of the key. For
            ' more information on what "salt" is, see SetKeyIVAndSaveToFile().
            ReDim abytSalt(15)
            ' There is no "LegalIVSizes" property like there is for key sizes. 
            ' Therefore, to figure out the valid IV byte array length you can do the
            ' following:
            '       crpSym.GenerateIV()
            '       abytIV = crpSym.IV
            '       Debug.WriteLine("Valid abytIV.Length=" & abytIV.Length.ToString)
            ReDim abytIV(15)
        Else
            ReDim abytKey(23)
            ReDim abytSalt(11)
            ReDim abytIV(7)
        End If
    End Sub

    ' This helper routine copies the temp file contents to the source file
    ' during encryption and decryption.
    Private Sub SwapFiles(ByVal UseFileAccessWait As Boolean)
        If UseFileAccessWait Then
            WaitForExclusiveAccess(strSourceFile)
        End If

        ' Replace the source file with the temp file and delete the temp file.
        File.Copy("temp.dat", strSourceFile, True)
        File.Delete("temp.dat")
    End Sub

    ' This helper routine is needed to gain access to a file that has recently
    ' been read from. It is used only after decryption.
    Private Sub WaitForExclusiveAccess(ByVal fullPath As String)
        While (True)
            Try
                Dim fs As FileStream
                fs = New FileStream(fullPath, FileMode.Append, _
                    FileAccess.Write, FileShare.None)
                fs.Close()
                Exit Sub
            Catch e As Exception
                Thread.Sleep(300)
            End Try
        End While
    End Sub

End Class
