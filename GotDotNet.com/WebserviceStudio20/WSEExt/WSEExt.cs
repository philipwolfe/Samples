/*============================================================
 **
 ** Purpose: The MainWindow UI
 ** Date:  Jan 12, 2003
 ** Author: Sowmy Srinivasan
 **
 ===========================================================*/
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System;
using Microsoft.Web.Services.Security.X509;
using Microsoft.Web.Services.Security;
using Microsoft.Web.Services.Dime;
using Microsoft.Web.Services;
using WebServiceStudio;

public class WSEProxyProperties : IAdditionalProperties{
    public WSETimestamp Timestamp;
    public WSESecurity Security;
    public WSEDimeAttachment[] Attachments;
    public WSEProxyProperties(HttpWebClientProtocol proxy){
        WebServicesClientProtocol wseProxy = (WebServicesClientProtocol)proxy;
        Timestamp = new WSETimestamp(wseProxy);
        Security = new WSESecurity(wseProxy);
        Attachments = null;
    }
    public void UpdateProxy(HttpWebClientProtocol proxy){
        if (Timestamp != null)
            Timestamp.UpdateProxy((WebServicesClientProtocol)proxy);
        if (Security != null)
            Security.UpdateProxy((WebServicesClientProtocol)proxy);
        if (Attachments != null){
            foreach(WSEDimeAttachment attachment in Attachments){
                attachment.UpdateProxy((WebServicesClientProtocol)proxy);
            }
        }
    }
}

public class WSETimestamp {
    public long Ttl;
    public WSETimestamp(WebServicesClientProtocol wseProxy){
        Ttl = wseProxy.RequestSoapContext.Timestamp.Ttl;
    }
    public void UpdateProxy(WebServicesClientProtocol wseProxy){
        wseProxy.RequestSoapContext.Timestamp.Ttl = Ttl;
    }
}

public class WSESecurity {
    public WSESignature Signature;
    public WSEEncryption Encryption;
    public WSESecurity(WebServicesClientProtocol wseProxy){
        Signature = null;
        Encryption = null;
    }
    public void UpdateProxy(WebServicesClientProtocol wseProxy){
        if (Signature != null)
            Signature.UpdateProxy(wseProxy);
        if (Encryption != null)
            Encryption.UpdateProxy(wseProxy);
    }
}

[XmlInclude(typeof(WSEUsernameSignature))]
[XmlInclude(typeof(WSECertificateSignature))]
public abstract class WSESignature{
    public abstract void UpdateProxy(WebServicesClientProtocol wseProxy);
}


public class WSEUsernameSignature: WSESignature{
    public string Username;
    public string Password;
    public PasswordOption PasswordOption;
    public WSEUsernameSignature(){
        Username=null;
        Password=null;
        PasswordOption = PasswordOption.SendPlainText;
    }
    public override void UpdateProxy(WebServicesClientProtocol wseProxy){
        if (this.Username != null && this.Username.Length>0 ){
            UsernameToken token = new UsernameToken(this.Username, this.Password, this.PasswordOption);
            wseProxy.RequestSoapContext.Security.Tokens.Add(token);
            wseProxy.RequestSoapContext.Security.Elements.Add(new Microsoft.Web.Services.Security.Signature(token));
        }
    }
}

public class WSECertificateSignature: WSESignature{
    public X509Certificate Certificate;
    public WSECertificateSignature(){
        Certificate= null;
    }
    public override void UpdateProxy(WebServicesClientProtocol wseProxy){
        if (Certificate != null ){
            if (!Certificate.SupportsDigitalSignature || Certificate.Key == null){
                throw new Exception("The certificate does not support digital signatures or does not have a private key available.");
            }
            X509SecurityToken token = new X509SecurityToken(Certificate);
            wseProxy.RequestSoapContext.Security.Tokens.Add(token);
            wseProxy.RequestSoapContext.Security.Elements.Add(new Microsoft.Web.Services.Security.Signature(token));
        }
    }
}

[XmlInclude(typeof(WSETripleDESSymmetricEncryption))]
[XmlInclude(typeof(WSERijndaelSymmetricEncryption))]
public abstract class WSEEncryption{
    public string Name;
    public byte[] Bytes;
    public virtual void UpdateProxy(WebServicesClientProtocol wseProxy){
        if (this.Bytes != null && this.Bytes.Length>0 ){
            byte[] keyBytes = this.Bytes;
            EncryptionKey key = GetEncryptionKey(keyBytes);
            KeyInfoName keyName = new KeyInfoName();
            keyName.Value  = Name;
            key.KeyInfo.AddClause(keyName);
            wseProxy.RequestSoapContext.Security.Elements.Add(new EncryptedData(key));
        }
    }
    public abstract EncryptionKey GetEncryptionKey(byte[] keyBytes);
}
public class WSETripleDESSymmetricEncryption : WSEEncryption{
    public WSETripleDESSymmetricEncryption(){
        Name="My TripleDES";
        TripleDESCryptoServiceProvider algo = new TripleDESCryptoServiceProvider();
        algo.GenerateKey();
        Bytes=algo.Key;
    }
    public override EncryptionKey GetEncryptionKey(byte[] keyBytes) {
        return new SymmetricEncryptionKey(TripleDES.Create(), keyBytes);
    }
}
public class WSERijndaelSymmetricEncryption : WSEEncryption{
    public WSERijndaelSymmetricEncryption(){
        Name="My Rijndael";
        RijndaelManaged algo = new RijndaelManaged();
        algo.GenerateKey();
        Bytes=algo.Key;
    }
    public override EncryptionKey GetEncryptionKey(byte[] keyBytes) {
        return new SymmetricEncryptionKey(Rijndael.Create(), keyBytes);
    }
}


public class WSEDimeAttachment{
    public int ChunkSize = int.MaxValue;  // only chunk the message if it is greater than 2G by default
    public string Id = "uuid:" + Guid.NewGuid().ToString();
    public string Type = "text/plain";
    public TypeFormatEnum TypeFormat=TypeFormatEnum.MediaType;
    public FileName FileToAttach=null;
    public virtual void UpdateProxy(WebServicesClientProtocol wseProxy){
        DimeAttachment dimeAttachment = new DimeAttachment(Id, Type, TypeFormat, File.OpenRead(FileToAttach.FullPath));
        dimeAttachment.ChunkSize = ChunkSize;
        DimeAttachmentCollection dimeAttachments = wseProxy.RequestSoapContext.Attachments;
        DimeAttachment oldDimeAttachment = dimeAttachments[Id];
        if (oldDimeAttachment != null)
            dimeAttachments.Remove(oldDimeAttachment);
        dimeAttachments.Add(dimeAttachment);
    }
}
//Dummy type to associate a data editor.
public class FileName {
    public string FullPath;
    public FileName(string fullPath){
        this.FullPath = fullPath;
    }
    public override string ToString(){
        return this.FullPath;
    }
}

public class FileEditor : UITypeEditor {
    private OpenFileDialog openFileDialog;

    public override object EditValue(ITypeDescriptorContext context,  IServiceProvider  provider, object value) {
        if (openFileDialog == null){
            openFileDialog = new OpenFileDialog();
        }
        openFileDialog.DefaultExt = "dat";
        openFileDialog.Multiselect = false;
        openFileDialog.Title = "Select Attachment";
        openFileDialog.CheckFileExists = true;
        openFileDialog.CheckPathExists = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
            return new FileName(openFileDialog.FileName);
        return null;
    }

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
        return UITypeEditorEditStyle.Modal;
    }

}
#if DimeLogger
public class DimeLogger : IMessageLogger {
        /*
      0                   1                   2                   3 
      0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 
     +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+ 
     |         |M|M|C|       |       |                               | 
     | VERSION |B|E|F| TYPE_T| RESRVD|         OPTIONS_LENGTH        | 
     +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+ 
     |            ID_LENGTH          |           TYPE_LENGTH         | 
     +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+ 
     |                          DATA_LENGTH                          | 
     +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+ 
     |                                                               / 
     /                     OPTIONS + PADDING                         / 
     /                                                               | 
     +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+ 
     |                                                               / 
     /                          ID + PADDING                         / 
     /                                                               | 
     +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+ 
     |                                                               / 
     /                        TYPE + PADDING                         / 
     /                                                               | 
     +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+ 
     |                                                               / 
     /                        DATA + PADDING                         / 
     /                                                               | 
     +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+ 
         */
        [FlagsAttribute]
        enum FlagsEnum:byte {BeginOfMessage=0x4,EndOfMessage = 0x2,ChunkedMessage = 0x1};
        enum TypeEnum:byte {Unchanged = 0x00, MediaType = 0x10,UriType = 0x20,Unknown=0x30,None=0x40};
        class DimeRecord {
            public int Version;
            public int Flags;
            public int TypeFlags;
            public int OptionsLength;
            public int IdLength;
            public int TypeLength;
            public int ContentLength;
            public byte[] Options;
            public string Id;
            public string Type;
            public byte[] PayLoad;
        }
        const string contentTypeDime = "application/dime";
        
        public string ReadMessage(Stream stream, int len, string contentType){
            if (contentType != contentTypeDime)
                return null;
            StringBuilder sb = new StringBuilder();
            byte[] buffer = new byte[12];
            while(true){
                int bytesRead = stream.Read(buffer,0, 12);
                if (bytesRead < 12)
                    break;
                string type=null;
                sb.Append("\nVersion : "); sb.Append((buffer[0] & 0xF8)>>3);
                FlagsEnum flags = (FlagsEnum) (buffer[0] & 0x07);
                sb.Append("\nFlags : "); sb.Append(flags.ToString());
                TypeEnum typeFlag = (TypeEnum) (buffer[1] & 0xF0);
                sb.Append("\nType Flags : "); sb.Append(typeFlag.ToString());
                int opLength = (buffer[2] << 8 )+ buffer[3];
                sb.Append("\nOption Length : "); sb.Append(opLength);
                int idLength = (buffer[4] << 8 )+ buffer[5];
                sb.Append("\nId Length : "); sb.Append(idLength);
                int typeLength = (buffer[6] << 8) + buffer[7];
                sb.Append("\nType Length : "); sb.Append(typeLength);
                int contentLength =   (buffer[8] << 24) + (buffer[9] << 16) + (buffer[10] << 8) + buffer[11];
                sb.Append("\nContent Length : "); sb.Append(contentLength);
                if (opLength > 0) {
                    sb.Append("Options {");
                    DumpBytes(stream, ((opLength-1)&~3)+4, sb);//makeMultipleOf4(opLength);
                    sb.Append("} Options");
                }
                if (idLength > 0) {
                    int alignedSize = ((idLength-1)&~3)+4;//makeMultipleOf4(idLength);
                    if (buffer.Length < alignedSize)
                        buffer = new byte[alignedSize];
                    stream.Read(buffer,0, alignedSize);
                    sb.Append("\nId : ");sb.Append(System.Text.Encoding.ASCII.GetString(buffer,0,idLength));
                }
                if (typeLength > 0) {
                    int alignedSize = ((typeLength-1)&~3)+4;//makeMultipleOf4(typeLength);
                    if (buffer.Length < alignedSize)
                        buffer = new byte[alignedSize];
                    stream.Read(buffer,0, alignedSize);
                    type = System.Text.Encoding.ASCII.GetString(buffer,0,typeLength);
                    if (typeFlag == TypeEnum.MediaType)
                        sb.Append("\nMediaType :");
                    else if (typeFlag == TypeEnum.UriType)
                        sb.Append("\nURI :");
                    sb.Append(type);
                }
                sb.Append("\nPayload{\n");
                //sb.Append(ReadMessage(stream, ((contentLength-1)&~3)+4, type));
                DumpBytes(stream, ((contentLength-1)&~3)+4,sb);//makeMultipleOf4(typeLength);
                sb.Append("\n}Payload");
            }

            return sb.ToString();
        }
        static void DumpBytes(Stream stream, int length, StringBuilder sb){
            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);
            sb.Append(Convert.ToBase64String(buffer));
        }

        public int WriteMessage(Stream stream, string contentType, string message){
            return 0;
        }
}
#endif
public class CertificateEditor : UITypeEditor {

    public override object EditValue(ITypeDescriptorContext context,  IServiceProvider  provider, object value) {
        X509CertificateStore store = X509CertificateStore.CurrentUserStore(X509CertificateStore.MyStore);
        store.OpenRead();
        try {
            if ( store.Handle == IntPtr.Zero )
                throw new InvalidOperationException("Store is not open");
            SelectCertificateDialog dlg = new SelectCertificateDialog(store);
            if ( dlg.ShowDialog() == DialogResult.OK )
                return dlg.Certificate;
            return null;
        }
        finally{
            if (store != null) { store.Close(); }
        }
    }

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
        return UITypeEditorEditStyle.Modal;
    }

}

/// <summary>
/// SelectCertificateDialog.
/// </summary>
class SelectCertificateDialog : System.Windows.Forms.Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.Windows.Forms.Button _okBtn;
    private System.Windows.Forms.Button _cancelBtn;

    private X509CertificateStore _store;
    private System.Windows.Forms.ListView _certList;
    private System.Windows.Forms.ColumnHeader _certName;
    private X509Certificate _certificate = null;

    public SelectCertificateDialog(X509CertificateStore store) : base()
    {
        _store = store;

        // Required for Windows Form Designer support
        //
        InitializeComponent();

        // Create columns for the items and subitems.
        _certList.Columns.Add("Name", 200, HorizontalAlignment.Left);
        _certList.Columns.Add("Digital Signature", -2, HorizontalAlignment.Left);
        _certList.Columns.Add("Has Private Key", -2, HorizontalAlignment.Left);
        _certList.Columns.Add("Issued By", -2, HorizontalAlignment.Left);
        _certList.Columns.Add("Full Name", -2, HorizontalAlignment.Left);
        _certList.Columns.Add("Certificate Identifier", -2, HorizontalAlignment.Left);
    }

    public X509Certificate Certificate
    {
        get
        {
            return _certificate;
        }
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this._okBtn = new System.Windows.Forms.Button();
        this._cancelBtn = new System.Windows.Forms.Button();
        this._certList = new System.Windows.Forms.ListView();
        this._certName = new System.Windows.Forms.ColumnHeader();
        this.SuspendLayout();
        // 
        // _okBtn
        // 
        this._okBtn.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this._okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
        this._okBtn.Location = new System.Drawing.Point(288, 256);
        this._okBtn.Name = "_okBtn";
        this._okBtn.TabIndex = 1;
        this._okBtn.Text = "OK";
        this._okBtn.Click += new System.EventHandler(this.OkBtn_Click);
        // 
        // _cancelBtn
        // 
        this._cancelBtn.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this._cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this._cancelBtn.Location = new System.Drawing.Point(368, 256);
        this._cancelBtn.Name = "_cancelBtn";
        this._cancelBtn.TabIndex = 2;
        this._cancelBtn.Text = "Cancel";
        this._cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
        // 
        // _certList
        // 
        this._certList.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                  | System.Windows.Forms.AnchorStyles.Left) 
                                 | System.Windows.Forms.AnchorStyles.Right);
        this._certList.FullRowSelect = true;
        this._certList.MultiSelect = false;
        this._certList.Name = "_certList";
        this._certList.Size = new System.Drawing.Size(456, 248);
        this._certList.TabIndex = 3;
        this._certList.View = System.Windows.Forms.View.Details;
        // 
        // _certName
        // 
        this._certName.Text = "Name";
        this._certName.Width = 92;
        // 
        // SelectCertificateDialog
        // 
        this.AcceptButton = this._okBtn;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.CancelButton = this._cancelBtn;
        this.ClientSize = new System.Drawing.Size(456, 286);
        this.Controls.AddRange(new System.Windows.Forms.Control[] {
            this._certList,
            this._cancelBtn,
            this._okBtn});
            this.Name = "SelectCertificateDialog";
            this.Text = "SelectCertificateDialog";
            this.ResumeLayout(false);

    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if ( _store == null )
        {
            throw new Exception("No store to open");
        }

        if ( _store.Handle == IntPtr.Zero )
        {
            throw new Exception("Store not open for reading");
        }

        X509CertificateCollection coll = _store.Certificates;

        foreach(X509Certificate cert in coll)
        {
            ListViewItem item = new CertificateListViewItem(cert);
            _certList.Items.Add(item);
        }
    }

    private void OkBtn_Click(object sender, System.EventArgs e)
    {
        _certificate = null;

        if ( _certList.SelectedItems != null && _certList.SelectedItems.Count == 1 )
        {                
            _certificate = ((CertificateListViewItem)_certList.SelectedItems[0]).Certificate;
        }

        this.Close();
        this.DialogResult = DialogResult.OK;
    }

    private void CancelBtn_Click(object sender, System.EventArgs e)
    {
        _certificate = null;
        this.DialogResult = DialogResult.Cancel;
    }

    class CertificateListViewItem : ListViewItem
    {
        X509Certificate cert;

        public CertificateListViewItem(X509Certificate certificate) : base(GetSubItems(certificate))
        {
            cert = certificate;
        }

        static string GetCommonName(string name)
        {
            if (name == null || name.Length == 0)
            {
                return string.Empty;
            }

            string [] fields = name.Split(',');
            for (int i = 0; i < fields.Length; i++)
            {
                string field = fields[i];
                if (field == null)
                    break;

                field = field.Trim();
                if (field.StartsWith("CN="))
                {
                    return field.Substring(3);
                }
            }
            return "<Common Name not found>";
        }

        static string[] GetSubItems(X509Certificate certificate)
        {
            string issuedTo = certificate.GetName();
            string issuedBy = GetCommonName(certificate.GetIssuerName());
            string certKeyId = Convert.ToBase64String(certificate.GetKeyIdentifier());

            string simpleName = GetCommonName(issuedTo);
            string digitalSign = certificate.SupportsDigitalSignature.ToString();
            string hasKey =    (certificate.Key != null).ToString();
            return new string [] { simpleName, digitalSign, hasKey, issuedBy, issuedTo, certKeyId };
        }

        public X509Certificate Certificate
        {
            get
            {
                return cert;
            }
        }
    }
}



