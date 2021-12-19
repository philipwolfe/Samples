
// This program uses a passphrase-derived key and DES encryption to encrypt a test file then decrypt it.


using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;

public class Encryption
{
    static private byte[] symkey;
    static private byte[] symIV;
    static private String passPhrase = "YourDog123";
    static private String inputFileName = "input.txt";
    static private String encrypedFileName = "encrypted.txt";
    static private String deencrypedFileName = "decrypted.txt";
    
    public static void Main(string[] args) {
        
        
        Console.WriteLine ("Creating Key");
        //fills in symKey and symIV arrays
        GenerateKeyFromPassPhrase(passPhrase);
        
        Console.WriteLine ("Encrypting {0}", inputFileName);
        EncryptDecryptData(inputFileName, encrypedFileName);
        Console.WriteLine ("Decrypting {0}", encrypedFileName);
        EncryptDecryptData(encrypedFileName, deencrypedFileName);

		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
    }
    
    ///////////////////////////////////////////////////////////////
    // Compute DES Key and IV Values
    static private bool GenerateKeyFromPassPhrase(String phrase)
    {
        try {
            
            // change the pass phrase into a form we can use
            int i;
            int len;
            char[] cp = phrase.ToCharArray();
            len = cp.GetLength(0);
            // convert to byte array -  discard upper byte since is usually 0 in Eng.
            byte[] bp = new byte[len];
            for (i=0; i<len; i++) bp[i] = (byte)cp[i]; // truncate char value
            
            // Crypto specific code starts here
            // allocate the key and IV arrays, assumes DES size
            symkey = new byte[8]; 
            symIV = new byte[8];
            //do the hash operation
            SHA1_CSP sha = new SHA1_CSP();
            sha.Write(bp);
            sha.CloseStream();
            // Crypto specific code ends here
            // use the low 64-bits for the key value
            for (i=0; i<8; i++) symkey[i] = sha.Hash[i];
            for (i=8; i<16; i++) symIV[i-8] = sha.Hash[i];
            
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return false;
        }
    }
    
    ///////////////////////////////////////////////////////////////
    // Encrypt/Decrypt Data
    static private void EncryptDecryptData(String inName, String outName)
    {
        try {
            bool bEncrypt = true;
            
            // Open the input and output files
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            
            //setup up variable to help with read
            byte[] bin = new byte[4096];
            long totlen = fin.Length; 
            long rdlen = 8;
            int len;
            int i;
            
            // figure out if we're encrypting or decrypting
            byte[] tag = new byte[8];
            fin.Read(tag,0,8);
            if ((tag[0]==(byte)'[') && (tag[1]==(byte)'E') && (tag[2]==(byte)'n') && (tag[3]==(byte)'c') && (tag[4]==(byte)']')) {
                Console.WriteLine("Decrypting data");
                bEncrypt = false;
            }
            else {
                Console.WriteLine("Encrypting");
                fin.Seek(0, SeekOrigin.Begin);
                rdlen = 0;
            }
            
            // Crypto specific code starts here
            // create the DES encryptor and the SymmetricStreamEncryptor obj
            DES_CSP des = new DES_CSP();
            StoreCryptoStream scs = new StoreCryptoStream(bEncrypt,fout);
            
            if (bEncrypt) {
                SymmetricStreamEncryptor sse = des.CreateEncryptor(symkey, symIV);
                
                // a little extra feature here to show how to compose crypto 
                // components that support ICryptoStream
                SHA1_CSP sha = new SHA1_CSP();
                
                // wire up the encryptor - hash - StoreCryptoStream
                sse.SetSink(sha);	
                sha.SetSource(sse);
                sha.SetSink(scs);	
                scs.SetSource(sha);
                while (rdlen < totlen) {
                    len = fin.Read(bin,0,4096);
                    sse.Write(bin,0,len);
                    rdlen = rdlen + len;
                    Console.WriteLine("Processed {0} bytes, {1} bytes total",len, rdlen);
                }
                sse.CloseStream();
                Console.WriteLine("HASH of the encrypted stream is:");
                Console.Write("\t");
                for (i=0; i< 20; i++) Console.Write("{0} ",sha.Hash[i]);
				Console.WriteLine();
            }
            else {
                SymmetricStreamDecryptor ssd = des.CreateDecryptor(symkey, symIV);
                ssd.SetSink(scs);
                scs.SetSource(ssd);
                while (rdlen < totlen) {
                    len = fin.Read(bin,0,4096);
                    ssd.Write(bin,0,len);
                    rdlen = rdlen + len;
                    Console.WriteLine("Processed {0} bytes, {1} bytes total",len, rdlen);
                }
                ssd.CloseStream();
            }
            // Crypto specific code ends here
            
            fin.Close();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return;
        }
    }
}

/*******************************************************************
* Helper class for capturing the output from the symmetric encryptor
* or decryptor and writing it out to the target file
*******************************************************************/
public class StoreCryptoStream : ICryptoStream
{
    
    static byte[] tag = {(byte)'[',(byte)'E',(byte)'n',(byte)'c',(byte)']',
        0x20, 0x20, 0x20};
    FileStream fs;
    
    ////////////////////////////////////////////////////////////////
    // Constructor
    public StoreCryptoStream(bool bEncrypt, FileStream fout) 
    {
        fs = fout;
        if (bEncrypt) fs.Write(tag,0,8);
    }
    
    public virtual void CloseStream() {fs.Close();}
    public virtual void CloseStream(Object obj) {fs.Close();}
    public virtual void SetSink(ICryptoStream pstm) {}
    public virtual void  SetSource(CryptographicObject co) {}
    public virtual ICryptoStream  GetSink () {return null;}
    
    ////////////////////////////////////////////////////////////////
    // Write routines just copy output to the target file
    public virtual void Write(byte[] bin)
    {
        int len = bin.GetLength(0);
        Write(bin, 0, len);
    }
    
    public virtual void Write(byte[] bin, int start, int len )
    {
        fs.Write(bin,start,len);
    }

}











