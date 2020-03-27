namespace LaunchApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUninstall = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnViewCache = new System.Windows.Forms.Button();
            this.lvNativeImageCache = new System.Windows.Forms.ListView();
            this.columnBaseName = new System.Windows.Forms.ColumnHeader();
            this.columnVersion = new System.Windows.Forms.ColumnHeader();
            this.columnCulture = new System.Windows.Forms.ColumnHeader();
            this.columnPublicKeyToken = new System.Windows.Forms.ColumnHeader();
            this.chkConfirm = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUninstall
            // 
            this.btnUninstall.Enabled = false;
            this.btnUninstall.Location = new System.Drawing.Point(409, 100);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(153, 23);
            this.btnUninstall.TabIndex = 3;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(368, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Uninstall: Removes the selected assemblies from the Native Image Cache.";
            // 
            // btnViewCache
            // 
            this.btnViewCache.Location = new System.Drawing.Point(409, 59);
            this.btnViewCache.Name = "btnViewCache";
            this.btnViewCache.Size = new System.Drawing.Size(153, 23);
            this.btnViewCache.TabIndex = 12;
            this.btnViewCache.Text = "View Native Image Cache";
            this.btnViewCache.UseVisualStyleBackColor = true;
            this.btnViewCache.Click += new System.EventHandler(this.btnViewCache_Click);
            // 
            // lvNativeImageCache
            // 
            this.lvNativeImageCache.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnBaseName,
            this.columnVersion,
            this.columnCulture,
            this.columnPublicKeyToken});
            this.lvNativeImageCache.Location = new System.Drawing.Point(15, 202);
            this.lvNativeImageCache.Name = "lvNativeImageCache";
            this.lvNativeImageCache.Size = new System.Drawing.Size(604, 233);
            this.lvNativeImageCache.TabIndex = 13;
            this.lvNativeImageCache.UseCompatibleStateImageBehavior = false;
            this.lvNativeImageCache.View = System.Windows.Forms.View.Details;
            this.lvNativeImageCache.SelectedIndexChanged += new System.EventHandler(this.lvNativeImageCache_SelectedIndexChanged);
            // 
            // columnBaseName
            // 
            this.columnBaseName.Text = "Assembly Name";
            this.columnBaseName.Width = 209;
            // 
            // columnVersion
            // 
            this.columnVersion.Text = "Version";
            this.columnVersion.Width = 77;
            // 
            // columnCulture
            // 
            this.columnCulture.Text = "Culture";
            this.columnCulture.Width = 72;
            // 
            // columnPublicKeyToken
            // 
            this.columnPublicKeyToken.Text = "Public Key Token";
            this.columnPublicKeyToken.Width = 241;
            // 
            // chkConfirm
            // 
            this.chkConfirm.AutoSize = true;
            this.chkConfirm.Checked = true;
            this.chkConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConfirm.Location = new System.Drawing.Point(15, 136);
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.Size = new System.Drawing.Size(177, 17);
            this.chkConfirm.TabIndex = 14;
            this.chkConfirm.Text = "Prompt for Uninstall confirmation";
            this.chkConfirm.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Install: Browse for an assembly file to install into the .NET Native Image Cache." +
                " ";
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(409, 21);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(153, 23);
            this.btnInstall.TabIndex = 1;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "View the contents of the Native Image Cache.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Native Image Cache:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 447);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.chkConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvNativeImageCache);
            this.Controls.Add(this.btnViewCache);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnUninstall);
            this.Name = "Form1";
            this.Text = "Using NGEN Launch Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnViewCache;
        private System.Windows.Forms.ListView lvNativeImageCache;
        private System.Windows.Forms.ColumnHeader columnBaseName;
        private System.Windows.Forms.ColumnHeader columnVersion;
        private System.Windows.Forms.ColumnHeader columnCulture;
        private System.Windows.Forms.ColumnHeader columnPublicKeyToken;
        private System.Windows.Forms.CheckBox chkConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

