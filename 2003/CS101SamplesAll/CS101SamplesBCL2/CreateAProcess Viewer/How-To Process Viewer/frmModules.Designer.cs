namespace How_To_Process_Viewer
{
    partial class frmModules
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModules));
            this.chItem = new System.Windows.Forms.ColumnHeader();
            this.mnuClose = new System.Windows.Forms.MenuItem();
            this.splVert = new System.Windows.Forms.Splitter();
            this.lvModDetail = new System.Windows.Forms.ListView();
            this.chValue = new System.Windows.Forms.ColumnHeader();
            this.lvModules = new System.Windows.Forms.ListView();
            this.chModName = new System.Windows.Forms.ColumnHeader();
            this.sbInfo = new System.Windows.Forms.StatusBar();
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.SuspendLayout();
            // 
            // chItem
            // 
            this.chItem.Text = "Item";
            this.chItem.Width = 150;
            // 
            // mnuClose
            // 
            this.mnuClose.Index = 0;
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // splVert
            // 
            this.splVert.Location = new System.Drawing.Point(184, 0);
            this.splVert.Name = "splVert";
            this.splVert.Size = new System.Drawing.Size(3, 181);
            this.splVert.TabIndex = 7;
            this.splVert.TabStop = false;
            // 
            // lvModDetail
            // 
            this.lvModDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chItem,
            this.chValue});
            this.lvModDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvModDetail.FullRowSelect = true;
            this.lvModDetail.Location = new System.Drawing.Point(184, 0);
            this.lvModDetail.MultiSelect = false;
            this.lvModDetail.Name = "lvModDetail";
            this.lvModDetail.Size = new System.Drawing.Size(536, 181);
            this.lvModDetail.TabIndex = 6;
            this.lvModDetail.UseCompatibleStateImageBehavior = false;
            this.lvModDetail.View = System.Windows.Forms.View.Details;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 570;
            // 
            // lvModules
            // 
            this.lvModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chModName});
            this.lvModules.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvModules.FullRowSelect = true;
            this.lvModules.Location = new System.Drawing.Point(0, 0);
            this.lvModules.MultiSelect = false;
            this.lvModules.Name = "lvModules";
            this.lvModules.Size = new System.Drawing.Size(184, 181);
            this.lvModules.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvModules.TabIndex = 5;
            this.lvModules.UseCompatibleStateImageBehavior = false;
            this.lvModules.View = System.Windows.Forms.View.Details;
            this.lvModules.SelectedIndexChanged += new System.EventHandler(this.lvModules_SelectedIndexChanged);
            // 
            // chModName
            // 
            this.chModName.Text = "Module Name";
            this.chModName.Width = 150;
            // 
            // sbInfo
            // 
            this.sbInfo.Location = new System.Drawing.Point(0, 181);
            this.sbInfo.Name = "sbInfo";
            this.sbInfo.Size = new System.Drawing.Size(720, 22);
            this.sbInfo.TabIndex = 4;
            this.sbInfo.Text = "Ready";
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuClose});
            this.mnuFile.Text = "&File";
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile});
            // 
            // frmModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 203);
            this.Controls.Add(this.splVert);
            this.Controls.Add(this.lvModDetail);
            this.Controls.Add(this.lvModules);
            this.Controls.Add(this.sbInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mnuMain;
            this.Name = "frmModules";
            this.Text = "Module Detail";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader chItem;
        private System.Windows.Forms.MenuItem mnuClose;
        private System.Windows.Forms.Splitter splVert;
        private System.Windows.Forms.ListView lvModDetail;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ListView lvModules;
        private System.Windows.Forms.ColumnHeader chModName;
        private System.Windows.Forms.StatusBar sbInfo;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MainMenu mnuMain;

    }
}