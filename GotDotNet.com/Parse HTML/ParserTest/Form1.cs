using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Data;
using ParserEngine;
using HtmlAgilityPack;


namespace ParserTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGet_Url;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.TextBox txtHtml;
		private System.Windows.Forms.Button btnParse;
		private System.Windows.Forms.ComboBox cmbRegex;
		private System.Windows.Forms.DataGrid dgParse;
		private System.Windows.Forms.Button btnConvert;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.btnGet_Url = new System.Windows.Forms.Button();
			this.txtHtml = new System.Windows.Forms.TextBox();
			this.btnParse = new System.Windows.Forms.Button();
			this.cmbRegex = new System.Windows.Forms.ComboBox();
			this.dgParse = new System.Windows.Forms.DataGrid();
			this.btnConvert = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgParse)).BeginInit();
			this.SuspendLayout();
			// 
			// txtUrl
			// 
			this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUrl.Location = new System.Drawing.Point(32, 32);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(384, 20);
			this.txtUrl.TabIndex = 0;
			this.txtUrl.Text = "";
			// 
			// btnGet_Url
			// 
			this.btnGet_Url.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGet_Url.Location = new System.Drawing.Point(432, 32);
			this.btnGet_Url.Name = "btnGet_Url";
			this.btnGet_Url.TabIndex = 1;
			this.btnGet_Url.Text = "Get URL";
			this.btnGet_Url.Click += new System.EventHandler(this.btnGet_Url_Click);
			// 
			// txtHtml
			// 
			this.txtHtml.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHtml.Location = new System.Drawing.Point(32, 64);
			this.txtHtml.Multiline = true;
			this.txtHtml.Name = "txtHtml";
			this.txtHtml.Size = new System.Drawing.Size(472, 168);
			this.txtHtml.TabIndex = 2;
			this.txtHtml.Text = "";
			// 
			// btnParse
			// 
			this.btnParse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnParse.Location = new System.Drawing.Point(424, 296);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(80, 23);
			this.btnParse.TabIndex = 4;
			this.btnParse.Text = "Regex-Parse";
			this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
			// 
			// cmbRegex
			// 
			this.cmbRegex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRegex.Location = new System.Drawing.Point(32, 296);
			this.cmbRegex.Name = "cmbRegex";
			this.cmbRegex.Size = new System.Drawing.Size(376, 21);
			this.cmbRegex.TabIndex = 5;
			// 
			// dgParse
			// 
			this.dgParse.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.dgParse.BackColor = System.Drawing.Color.Gainsboro;
			this.dgParse.BackgroundColor = System.Drawing.Color.DarkGray;
			this.dgParse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgParse.CaptionBackColor = System.Drawing.Color.DarkKhaki;
			this.dgParse.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dgParse.CaptionForeColor = System.Drawing.Color.Black;
			this.dgParse.DataMember = "";
			this.dgParse.FlatMode = true;
			this.dgParse.Font = new System.Drawing.Font("Times New Roman", 9F);
			this.dgParse.ForeColor = System.Drawing.Color.Black;
			this.dgParse.GridLineColor = System.Drawing.Color.Silver;
			this.dgParse.HeaderBackColor = System.Drawing.Color.Black;
			this.dgParse.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dgParse.HeaderForeColor = System.Drawing.Color.White;
			this.dgParse.LinkColor = System.Drawing.Color.DarkSlateBlue;
			this.dgParse.Location = new System.Drawing.Point(32, 344);
			this.dgParse.Name = "dgParse";
			this.dgParse.ParentRowsBackColor = System.Drawing.Color.LightGray;
			this.dgParse.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dgParse.PreferredColumnWidth = 200;
			this.dgParse.SelectionBackColor = System.Drawing.Color.Firebrick;
			this.dgParse.SelectionForeColor = System.Drawing.Color.White;
			this.dgParse.Size = new System.Drawing.Size(472, 128);
			this.dgParse.TabIndex = 6;
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(32, 248);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(184, 23);
			this.btnConvert.TabIndex = 7;
			this.btnConvert.Text = "Convert using HTML Agility Pack";
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 510);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.dgParse);
			this.Controls.Add(this.cmbRegex);
			this.Controls.Add(this.btnParse);
			this.Controls.Add(this.txtHtml);
			this.Controls.Add(this.btnGet_Url);
			this.Controls.Add(this.txtUrl);
			this.Name = "Form1";
			this.Text = "HTML parsing using Regex ...";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgParse)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnGet_Url_Click(object sender, System.EventArgs e)
		{
			if( txtUrl.Text.Length > 0 )
			{
				txtHtml.Text = GetDataFromUrl(txtUrl.Text);
			}
		}

		private string GetDataFromUrl(string urlString)
		{	
			WebClient wclient = new WebClient();
			byte[] btData = wclient.DownloadData( urlString );
			return Encoding.ASCII.GetString( btData );
		}

		private void btnParse_Click(object sender, System.EventArgs e)
		{
			if ( txtHtml.Text.Length > 0 && cmbRegex.Text.Length > 0 )
			{
				FindMatches(txtHtml.Text, cmbRegex.Text);
			}
			
		}

		private void FindMatches(string html, string regex)
		{
			RegexEngine regEng = new RegexEngine(html, regex);
			BindData(regEng.ParseHtml());
			
		}

		private void BindData(ArrayList arrList)
		{
			DataView view = new DataView();
			view.Table = new DataTable("Parsed HTML");
			view.Table.Columns.Add( "Elements/Attributes", typeof(string) );

			foreach ( String str in arrList )
			{
				DataRow row = view.Table.NewRow();
				row[0] = str;
				view.Table.Rows.Add( row );
			}
			
			this.dgParse.DataSource = view;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			ArrayList regexStringList = new ArrayList();
			
			regexStringList.Add(@"http://(www\.)?([^\.]+)\.com");
			regexStringList.Add(@"lbl");
			regexStringList.Add("</?\b(?!\b(br|p)\b)\b[^>]+?>");
			regexStringList.Add("&lt;table&gt;(&lt;tr&gt;((&lt;td&gt;([A-Za-z0-9])*&lt;/td&gt;)+)&lt;/tr&gt;)*&lt;/table&gt");

			cmbRegex.DataSource = regexStringList;
		}

		private void btnConvert_Click(object sender, System.EventArgs e)
		{			
			HtmlToText htt = new HtmlToText();
			string s = htt.ConvertHtml(txtHtml.Text);
			StreamWriter sw = new StreamWriter("test.txt");
			sw.Write(s);
			sw.Flush();
			sw.Close();			
		}
	}
}
