using System.Threading;
using System.ComponentModel;

namespace WinSudoku
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAutoplay = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.t0 = new System.Windows.Forms.TextBox();
            this.t1 = new System.Windows.Forms.TextBox();
            this.t2 = new System.Windows.Forms.TextBox();
            this.t3 = new System.Windows.Forms.TextBox();
            this.t4 = new System.Windows.Forms.TextBox();
            this.t5 = new System.Windows.Forms.TextBox();
            this.t6 = new System.Windows.Forms.TextBox();
            this.t7 = new System.Windows.Forms.TextBox();
            this.t8 = new System.Windows.Forms.TextBox();
            this.t9 = new System.Windows.Forms.TextBox();
            this.t10 = new System.Windows.Forms.TextBox();
            this.t11 = new System.Windows.Forms.TextBox();
            this.t12 = new System.Windows.Forms.TextBox();
            this.t13 = new System.Windows.Forms.TextBox();
            this.t14 = new System.Windows.Forms.TextBox();
            this.t15 = new System.Windows.Forms.TextBox();
            this.t16 = new System.Windows.Forms.TextBox();
            this.t17 = new System.Windows.Forms.TextBox();
            this.t18 = new System.Windows.Forms.TextBox();
            this.t19 = new System.Windows.Forms.TextBox();
            this.t20 = new System.Windows.Forms.TextBox();
            this.t21 = new System.Windows.Forms.TextBox();
            this.t22 = new System.Windows.Forms.TextBox();
            this.t23 = new System.Windows.Forms.TextBox();
            this.t24 = new System.Windows.Forms.TextBox();
            this.t25 = new System.Windows.Forms.TextBox();
            this.t26 = new System.Windows.Forms.TextBox();
            this.t27 = new System.Windows.Forms.TextBox();
            this.t28 = new System.Windows.Forms.TextBox();
            this.t29 = new System.Windows.Forms.TextBox();
            this.t30 = new System.Windows.Forms.TextBox();
            this.t31 = new System.Windows.Forms.TextBox();
            this.t32 = new System.Windows.Forms.TextBox();
            this.t33 = new System.Windows.Forms.TextBox();
            this.t34 = new System.Windows.Forms.TextBox();
            this.t35 = new System.Windows.Forms.TextBox();
            this.t36 = new System.Windows.Forms.TextBox();
            this.t37 = new System.Windows.Forms.TextBox();
            this.t38 = new System.Windows.Forms.TextBox();
            this.t39 = new System.Windows.Forms.TextBox();
            this.t40 = new System.Windows.Forms.TextBox();
            this.t41 = new System.Windows.Forms.TextBox();
            this.t42 = new System.Windows.Forms.TextBox();
            this.t43 = new System.Windows.Forms.TextBox();
            this.t44 = new System.Windows.Forms.TextBox();
            this.t45 = new System.Windows.Forms.TextBox();
            this.t46 = new System.Windows.Forms.TextBox();
            this.t47 = new System.Windows.Forms.TextBox();
            this.t48 = new System.Windows.Forms.TextBox();
            this.t49 = new System.Windows.Forms.TextBox();
            this.t50 = new System.Windows.Forms.TextBox();
            this.t51 = new System.Windows.Forms.TextBox();
            this.t52 = new System.Windows.Forms.TextBox();
            this.t53 = new System.Windows.Forms.TextBox();
            this.t54 = new System.Windows.Forms.TextBox();
            this.t55 = new System.Windows.Forms.TextBox();
            this.t56 = new System.Windows.Forms.TextBox();
            this.t57 = new System.Windows.Forms.TextBox();
            this.t58 = new System.Windows.Forms.TextBox();
            this.t59 = new System.Windows.Forms.TextBox();
            this.t60 = new System.Windows.Forms.TextBox();
            this.t61 = new System.Windows.Forms.TextBox();
            this.t62 = new System.Windows.Forms.TextBox();
            this.t63 = new System.Windows.Forms.TextBox();
            this.t64 = new System.Windows.Forms.TextBox();
            this.t65 = new System.Windows.Forms.TextBox();
            this.t66 = new System.Windows.Forms.TextBox();
            this.t67 = new System.Windows.Forms.TextBox();
            this.t68 = new System.Windows.Forms.TextBox();
            this.t69 = new System.Windows.Forms.TextBox();
            this.t70 = new System.Windows.Forms.TextBox();
            this.t71 = new System.Windows.Forms.TextBox();
            this.t72 = new System.Windows.Forms.TextBox();
            this.t73 = new System.Windows.Forms.TextBox();
            this.t74 = new System.Windows.Forms.TextBox();
            this.t75 = new System.Windows.Forms.TextBox();
            this.t76 = new System.Windows.Forms.TextBox();
            this.t77 = new System.Windows.Forms.TextBox();
            this.t78 = new System.Windows.Forms.TextBox();
            this.t79 = new System.Windows.Forms.TextBox();
            this.t80 = new System.Windows.Forms.TextBox();
            this.bw1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(194, 24);
            this.menuStrip1.TabIndex = 82;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(107, 22);
            this.MenuExit.Text = "EXIT";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAutoplay,
            this.MenuClear,
            this.MenuEdit});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // MenuAutoplay
            // 
            this.MenuAutoplay.Name = "MenuAutoplay";
            this.MenuAutoplay.Size = new System.Drawing.Size(199, 22);
            this.MenuAutoplay.Text = "Solve it!";
            this.MenuAutoplay.Click += new System.EventHandler(this.MenuAutoplay_Click);
            // 
            // MenuClear
            // 
            this.MenuClear.Name = "MenuClear";
            this.MenuClear.Size = new System.Drawing.Size(199, 22);
            this.MenuClear.Text = "Clear All";
            this.MenuClear.Click += new System.EventHandler(this.MenuClear_Click);
            // 
            // MenuEdit
            // 
            this.MenuEdit.Name = "MenuEdit";
            this.MenuEdit.Size = new System.Drawing.Size(199, 22);
            this.MenuEdit.Text = "Clear Calculatedl Values";
            this.MenuEdit.Click += new System.EventHandler(this.MenuEdit_Click);
            // 
            // t0
            // 
            this.t0.BackColor = System.Drawing.Color.White;
            this.t0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t0.ForeColor = System.Drawing.Color.Black;
            this.t0.Location = new System.Drawing.Point(4, 26);
            this.t0.MaxLength = 1;
            this.t0.Name = "t0";
            this.t0.Size = new System.Drawing.Size(20, 20);
            this.t0.TabIndex = 83;
            this.t0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t1
            // 
            this.t1.BackColor = System.Drawing.Color.White;
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t1.ForeColor = System.Drawing.Color.Black;
            this.t1.Location = new System.Drawing.Point(24, 26);
            this.t1.MaxLength = 1;
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(20, 20);
            this.t1.TabIndex = 84;
            this.t1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t2
            // 
            this.t2.BackColor = System.Drawing.Color.White;
            this.t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2.ForeColor = System.Drawing.Color.Black;
            this.t2.Location = new System.Drawing.Point(44, 26);
            this.t2.MaxLength = 1;
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(20, 20);
            this.t2.TabIndex = 85;
            this.t2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t3
            // 
            this.t3.BackColor = System.Drawing.Color.White;
            this.t3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t3.ForeColor = System.Drawing.Color.Black;
            this.t3.Location = new System.Drawing.Point(67, 26);
            this.t3.MaxLength = 1;
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(20, 20);
            this.t3.TabIndex = 86;
            this.t3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t4
            // 
            this.t4.BackColor = System.Drawing.Color.White;
            this.t4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t4.ForeColor = System.Drawing.Color.Black;
            this.t4.Location = new System.Drawing.Point(86, 26);
            this.t4.MaxLength = 1;
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(20, 20);
            this.t4.TabIndex = 87;
            this.t4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t5
            // 
            this.t5.BackColor = System.Drawing.Color.White;
            this.t5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t5.ForeColor = System.Drawing.Color.Black;
            this.t5.Location = new System.Drawing.Point(106, 26);
            this.t5.MaxLength = 1;
            this.t5.Name = "t5";
            this.t5.Size = new System.Drawing.Size(20, 20);
            this.t5.TabIndex = 88;
            this.t5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t6
            // 
            this.t6.BackColor = System.Drawing.Color.White;
            this.t6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t6.ForeColor = System.Drawing.Color.Black;
            this.t6.Location = new System.Drawing.Point(129, 26);
            this.t6.MaxLength = 1;
            this.t6.Name = "t6";
            this.t6.Size = new System.Drawing.Size(20, 20);
            this.t6.TabIndex = 89;
            this.t6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t7
            // 
            this.t7.BackColor = System.Drawing.Color.White;
            this.t7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t7.ForeColor = System.Drawing.Color.Black;
            this.t7.Location = new System.Drawing.Point(149, 26);
            this.t7.MaxLength = 1;
            this.t7.Name = "t7";
            this.t7.Size = new System.Drawing.Size(20, 20);
            this.t7.TabIndex = 90;
            this.t7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t8
            // 
            this.t8.BackColor = System.Drawing.Color.White;
            this.t8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t8.ForeColor = System.Drawing.Color.Black;
            this.t8.Location = new System.Drawing.Point(169, 26);
            this.t8.MaxLength = 1;
            this.t8.Name = "t8";
            this.t8.Size = new System.Drawing.Size(20, 20);
            this.t8.TabIndex = 91;
            // 
            // t9
            // 
            this.t9.BackColor = System.Drawing.Color.White;
            this.t9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t9.ForeColor = System.Drawing.Color.Black;
            this.t9.Location = new System.Drawing.Point(4, 47);
            this.t9.MaxLength = 1;
            this.t9.Name = "t9";
            this.t9.Size = new System.Drawing.Size(20, 20);
            this.t9.TabIndex = 92;
            this.t9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t10
            // 
            this.t10.BackColor = System.Drawing.Color.White;
            this.t10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t10.ForeColor = System.Drawing.Color.Black;
            this.t10.Location = new System.Drawing.Point(24, 47);
            this.t10.MaxLength = 1;
            this.t10.Name = "t10";
            this.t10.Size = new System.Drawing.Size(20, 20);
            this.t10.TabIndex = 93;
            this.t10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t11
            // 
            this.t11.BackColor = System.Drawing.Color.White;
            this.t11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t11.ForeColor = System.Drawing.Color.Black;
            this.t11.Location = new System.Drawing.Point(44, 47);
            this.t11.MaxLength = 1;
            this.t11.Name = "t11";
            this.t11.Size = new System.Drawing.Size(20, 20);
            this.t11.TabIndex = 94;
            this.t11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t12
            // 
            this.t12.BackColor = System.Drawing.Color.White;
            this.t12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t12.ForeColor = System.Drawing.Color.Black;
            this.t12.Location = new System.Drawing.Point(67, 47);
            this.t12.MaxLength = 1;
            this.t12.Name = "t12";
            this.t12.Size = new System.Drawing.Size(20, 20);
            this.t12.TabIndex = 95;
            this.t12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t13
            // 
            this.t13.BackColor = System.Drawing.Color.White;
            this.t13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t13.ForeColor = System.Drawing.Color.Black;
            this.t13.Location = new System.Drawing.Point(86, 47);
            this.t13.MaxLength = 1;
            this.t13.Name = "t13";
            this.t13.Size = new System.Drawing.Size(20, 20);
            this.t13.TabIndex = 96;
            this.t13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t14
            // 
            this.t14.BackColor = System.Drawing.Color.White;
            this.t14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t14.ForeColor = System.Drawing.Color.Black;
            this.t14.Location = new System.Drawing.Point(106, 47);
            this.t14.MaxLength = 1;
            this.t14.Name = "t14";
            this.t14.Size = new System.Drawing.Size(20, 20);
            this.t14.TabIndex = 97;
            this.t14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t15
            // 
            this.t15.BackColor = System.Drawing.Color.White;
            this.t15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t15.ForeColor = System.Drawing.Color.Black;
            this.t15.Location = new System.Drawing.Point(129, 47);
            this.t15.MaxLength = 1;
            this.t15.Name = "t15";
            this.t15.Size = new System.Drawing.Size(20, 20);
            this.t15.TabIndex = 98;
            this.t15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t16
            // 
            this.t16.BackColor = System.Drawing.Color.White;
            this.t16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t16.ForeColor = System.Drawing.Color.Black;
            this.t16.Location = new System.Drawing.Point(149, 47);
            this.t16.MaxLength = 1;
            this.t16.Name = "t16";
            this.t16.Size = new System.Drawing.Size(20, 20);
            this.t16.TabIndex = 99;
            this.t16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t17
            // 
            this.t17.BackColor = System.Drawing.Color.White;
            this.t17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t17.ForeColor = System.Drawing.Color.Black;
            this.t17.Location = new System.Drawing.Point(169, 47);
            this.t17.MaxLength = 1;
            this.t17.Name = "t17";
            this.t17.Size = new System.Drawing.Size(20, 20);
            this.t17.TabIndex = 100;
            this.t17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t18
            // 
            this.t18.BackColor = System.Drawing.Color.White;
            this.t18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t18.ForeColor = System.Drawing.Color.Black;
            this.t18.Location = new System.Drawing.Point(4, 68);
            this.t18.MaxLength = 1;
            this.t18.Name = "t18";
            this.t18.Size = new System.Drawing.Size(20, 20);
            this.t18.TabIndex = 101;
            this.t18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t19
            // 
            this.t19.BackColor = System.Drawing.Color.White;
            this.t19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t19.ForeColor = System.Drawing.Color.Black;
            this.t19.Location = new System.Drawing.Point(25, 68);
            this.t19.MaxLength = 1;
            this.t19.Name = "t19";
            this.t19.Size = new System.Drawing.Size(20, 20);
            this.t19.TabIndex = 102;
            this.t19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t20
            // 
            this.t20.BackColor = System.Drawing.Color.White;
            this.t20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t20.ForeColor = System.Drawing.Color.Black;
            this.t20.Location = new System.Drawing.Point(44, 68);
            this.t20.MaxLength = 1;
            this.t20.Name = "t20";
            this.t20.Size = new System.Drawing.Size(20, 20);
            this.t20.TabIndex = 103;
            this.t20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t21
            // 
            this.t21.BackColor = System.Drawing.Color.White;
            this.t21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t21.ForeColor = System.Drawing.Color.Black;
            this.t21.Location = new System.Drawing.Point(67, 68);
            this.t21.MaxLength = 1;
            this.t21.Name = "t21";
            this.t21.Size = new System.Drawing.Size(20, 20);
            this.t21.TabIndex = 104;
            this.t21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t22
            // 
            this.t22.BackColor = System.Drawing.Color.White;
            this.t22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t22.ForeColor = System.Drawing.Color.Black;
            this.t22.Location = new System.Drawing.Point(86, 68);
            this.t22.MaxLength = 1;
            this.t22.Name = "t22";
            this.t22.Size = new System.Drawing.Size(20, 20);
            this.t22.TabIndex = 105;
            this.t22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t23
            // 
            this.t23.BackColor = System.Drawing.Color.White;
            this.t23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t23.ForeColor = System.Drawing.Color.Black;
            this.t23.Location = new System.Drawing.Point(106, 68);
            this.t23.MaxLength = 1;
            this.t23.Name = "t23";
            this.t23.Size = new System.Drawing.Size(20, 20);
            this.t23.TabIndex = 106;
            this.t23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t24
            // 
            this.t24.BackColor = System.Drawing.Color.White;
            this.t24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t24.ForeColor = System.Drawing.Color.Black;
            this.t24.Location = new System.Drawing.Point(129, 68);
            this.t24.MaxLength = 1;
            this.t24.Name = "t24";
            this.t24.Size = new System.Drawing.Size(20, 20);
            this.t24.TabIndex = 107;
            this.t24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t25
            // 
            this.t25.BackColor = System.Drawing.Color.White;
            this.t25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t25.ForeColor = System.Drawing.Color.Black;
            this.t25.Location = new System.Drawing.Point(149, 68);
            this.t25.MaxLength = 1;
            this.t25.Name = "t25";
            this.t25.Size = new System.Drawing.Size(20, 20);
            this.t25.TabIndex = 108;
            this.t25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t26
            // 
            this.t26.BackColor = System.Drawing.Color.White;
            this.t26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t26.ForeColor = System.Drawing.Color.Black;
            this.t26.Location = new System.Drawing.Point(169, 68);
            this.t26.MaxLength = 1;
            this.t26.Name = "t26";
            this.t26.Size = new System.Drawing.Size(20, 20);
            this.t26.TabIndex = 109;
            this.t26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t27
            // 
            this.t27.BackColor = System.Drawing.Color.White;
            this.t27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t27.ForeColor = System.Drawing.Color.Black;
            this.t27.Location = new System.Drawing.Point(4, 91);
            this.t27.MaxLength = 1;
            this.t27.Name = "t27";
            this.t27.Size = new System.Drawing.Size(20, 20);
            this.t27.TabIndex = 110;
            this.t27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t28
            // 
            this.t28.BackColor = System.Drawing.Color.White;
            this.t28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t28.ForeColor = System.Drawing.Color.Black;
            this.t28.Location = new System.Drawing.Point(24, 91);
            this.t28.MaxLength = 1;
            this.t28.Name = "t28";
            this.t28.Size = new System.Drawing.Size(20, 20);
            this.t28.TabIndex = 111;
            this.t28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t29
            // 
            this.t29.BackColor = System.Drawing.Color.White;
            this.t29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t29.ForeColor = System.Drawing.Color.Black;
            this.t29.Location = new System.Drawing.Point(44, 91);
            this.t29.MaxLength = 1;
            this.t29.Name = "t29";
            this.t29.Size = new System.Drawing.Size(20, 20);
            this.t29.TabIndex = 112;
            this.t29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t30
            // 
            this.t30.BackColor = System.Drawing.Color.White;
            this.t30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t30.ForeColor = System.Drawing.Color.Black;
            this.t30.Location = new System.Drawing.Point(66, 91);
            this.t30.MaxLength = 1;
            this.t30.Name = "t30";
            this.t30.Size = new System.Drawing.Size(20, 20);
            this.t30.TabIndex = 113;
            this.t30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t31
            // 
            this.t31.BackColor = System.Drawing.Color.White;
            this.t31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t31.ForeColor = System.Drawing.Color.Black;
            this.t31.Location = new System.Drawing.Point(87, 91);
            this.t31.MaxLength = 1;
            this.t31.Name = "t31";
            this.t31.Size = new System.Drawing.Size(20, 20);
            this.t31.TabIndex = 114;
            this.t31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t32
            // 
            this.t32.BackColor = System.Drawing.Color.White;
            this.t32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t32.ForeColor = System.Drawing.Color.Black;
            this.t32.Location = new System.Drawing.Point(106, 91);
            this.t32.MaxLength = 1;
            this.t32.Name = "t32";
            this.t32.Size = new System.Drawing.Size(20, 20);
            this.t32.TabIndex = 115;
            this.t32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t33
            // 
            this.t33.BackColor = System.Drawing.Color.White;
            this.t33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t33.ForeColor = System.Drawing.Color.Black;
            this.t33.Location = new System.Drawing.Point(129, 91);
            this.t33.MaxLength = 1;
            this.t33.Name = "t33";
            this.t33.Size = new System.Drawing.Size(20, 20);
            this.t33.TabIndex = 116;
            this.t33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t34
            // 
            this.t34.BackColor = System.Drawing.Color.White;
            this.t34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t34.ForeColor = System.Drawing.Color.Black;
            this.t34.Location = new System.Drawing.Point(149, 91);
            this.t34.MaxLength = 1;
            this.t34.Name = "t34";
            this.t34.Size = new System.Drawing.Size(20, 20);
            this.t34.TabIndex = 117;
            this.t34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t35
            // 
            this.t35.BackColor = System.Drawing.Color.White;
            this.t35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t35.ForeColor = System.Drawing.Color.Black;
            this.t35.Location = new System.Drawing.Point(169, 91);
            this.t35.MaxLength = 1;
            this.t35.Name = "t35";
            this.t35.Size = new System.Drawing.Size(20, 20);
            this.t35.TabIndex = 118;
            this.t35.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t36
            // 
            this.t36.BackColor = System.Drawing.Color.White;
            this.t36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t36.ForeColor = System.Drawing.Color.Black;
            this.t36.Location = new System.Drawing.Point(4, 112);
            this.t36.MaxLength = 1;
            this.t36.Name = "t36";
            this.t36.Size = new System.Drawing.Size(20, 20);
            this.t36.TabIndex = 119;
            this.t36.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t37
            // 
            this.t37.BackColor = System.Drawing.Color.White;
            this.t37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t37.ForeColor = System.Drawing.Color.Black;
            this.t37.Location = new System.Drawing.Point(25, 112);
            this.t37.MaxLength = 1;
            this.t37.Name = "t37";
            this.t37.Size = new System.Drawing.Size(20, 20);
            this.t37.TabIndex = 120;
            this.t37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t38
            // 
            this.t38.BackColor = System.Drawing.Color.White;
            this.t38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t38.ForeColor = System.Drawing.Color.Black;
            this.t38.Location = new System.Drawing.Point(44, 112);
            this.t38.MaxLength = 1;
            this.t38.Name = "t38";
            this.t38.Size = new System.Drawing.Size(20, 20);
            this.t38.TabIndex = 121;
            this.t38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t39
            // 
            this.t39.BackColor = System.Drawing.Color.White;
            this.t39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t39.ForeColor = System.Drawing.Color.Black;
            this.t39.Location = new System.Drawing.Point(67, 112);
            this.t39.MaxLength = 1;
            this.t39.Name = "t39";
            this.t39.Size = new System.Drawing.Size(20, 20);
            this.t39.TabIndex = 122;
            this.t39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t40
            // 
            this.t40.BackColor = System.Drawing.Color.White;
            this.t40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t40.ForeColor = System.Drawing.Color.Black;
            this.t40.Location = new System.Drawing.Point(87, 112);
            this.t40.MaxLength = 1;
            this.t40.Name = "t40";
            this.t40.Size = new System.Drawing.Size(20, 20);
            this.t40.TabIndex = 123;
            this.t40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t41
            // 
            this.t41.BackColor = System.Drawing.Color.White;
            this.t41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t41.ForeColor = System.Drawing.Color.Black;
            this.t41.Location = new System.Drawing.Point(106, 112);
            this.t41.MaxLength = 1;
            this.t41.Name = "t41";
            this.t41.Size = new System.Drawing.Size(20, 20);
            this.t41.TabIndex = 124;
            this.t41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t42
            // 
            this.t42.BackColor = System.Drawing.Color.White;
            this.t42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t42.ForeColor = System.Drawing.Color.Black;
            this.t42.Location = new System.Drawing.Point(129, 112);
            this.t42.MaxLength = 1;
            this.t42.Name = "t42";
            this.t42.Size = new System.Drawing.Size(20, 20);
            this.t42.TabIndex = 125;
            this.t42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t43
            // 
            this.t43.BackColor = System.Drawing.Color.White;
            this.t43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t43.ForeColor = System.Drawing.Color.Black;
            this.t43.Location = new System.Drawing.Point(149, 112);
            this.t43.MaxLength = 1;
            this.t43.Name = "t43";
            this.t43.Size = new System.Drawing.Size(20, 20);
            this.t43.TabIndex = 126;
            this.t43.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t44
            // 
            this.t44.BackColor = System.Drawing.Color.White;
            this.t44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t44.ForeColor = System.Drawing.Color.Black;
            this.t44.Location = new System.Drawing.Point(169, 112);
            this.t44.MaxLength = 1;
            this.t44.Name = "t44";
            this.t44.Size = new System.Drawing.Size(20, 20);
            this.t44.TabIndex = 127;
            this.t44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t45
            // 
            this.t45.BackColor = System.Drawing.Color.White;
            this.t45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t45.ForeColor = System.Drawing.Color.Black;
            this.t45.Location = new System.Drawing.Point(4, 132);
            this.t45.MaxLength = 1;
            this.t45.Name = "t45";
            this.t45.Size = new System.Drawing.Size(20, 20);
            this.t45.TabIndex = 128;
            this.t45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t46
            // 
            this.t46.BackColor = System.Drawing.Color.White;
            this.t46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t46.ForeColor = System.Drawing.Color.Black;
            this.t46.Location = new System.Drawing.Point(25, 132);
            this.t46.MaxLength = 1;
            this.t46.Name = "t46";
            this.t46.Size = new System.Drawing.Size(20, 20);
            this.t46.TabIndex = 129;
            this.t46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t47
            // 
            this.t47.BackColor = System.Drawing.Color.White;
            this.t47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t47.ForeColor = System.Drawing.Color.Black;
            this.t47.Location = new System.Drawing.Point(44, 132);
            this.t47.MaxLength = 1;
            this.t47.Name = "t47";
            this.t47.Size = new System.Drawing.Size(20, 20);
            this.t47.TabIndex = 130;
            this.t47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t48
            // 
            this.t48.BackColor = System.Drawing.Color.White;
            this.t48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t48.ForeColor = System.Drawing.Color.Black;
            this.t48.Location = new System.Drawing.Point(67, 132);
            this.t48.MaxLength = 1;
            this.t48.Name = "t48";
            this.t48.Size = new System.Drawing.Size(20, 20);
            this.t48.TabIndex = 131;
            this.t48.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t49
            // 
            this.t49.BackColor = System.Drawing.Color.White;
            this.t49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t49.ForeColor = System.Drawing.Color.Black;
            this.t49.Location = new System.Drawing.Point(87, 132);
            this.t49.MaxLength = 1;
            this.t49.Name = "t49";
            this.t49.Size = new System.Drawing.Size(20, 20);
            this.t49.TabIndex = 132;
            this.t49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t50
            // 
            this.t50.BackColor = System.Drawing.Color.White;
            this.t50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t50.ForeColor = System.Drawing.Color.Black;
            this.t50.Location = new System.Drawing.Point(106, 132);
            this.t50.MaxLength = 1;
            this.t50.Name = "t50";
            this.t50.Size = new System.Drawing.Size(20, 20);
            this.t50.TabIndex = 133;
            this.t50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t51
            // 
            this.t51.BackColor = System.Drawing.Color.White;
            this.t51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t51.ForeColor = System.Drawing.Color.Black;
            this.t51.Location = new System.Drawing.Point(129, 132);
            this.t51.MaxLength = 1;
            this.t51.Name = "t51";
            this.t51.Size = new System.Drawing.Size(20, 20);
            this.t51.TabIndex = 134;
            this.t51.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t52
            // 
            this.t52.BackColor = System.Drawing.Color.White;
            this.t52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t52.ForeColor = System.Drawing.Color.Black;
            this.t52.Location = new System.Drawing.Point(149, 132);
            this.t52.MaxLength = 1;
            this.t52.Name = "t52";
            this.t52.Size = new System.Drawing.Size(20, 20);
            this.t52.TabIndex = 135;
            this.t52.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t53
            // 
            this.t53.BackColor = System.Drawing.Color.White;
            this.t53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t53.ForeColor = System.Drawing.Color.Black;
            this.t53.Location = new System.Drawing.Point(169, 132);
            this.t53.MaxLength = 1;
            this.t53.Name = "t53";
            this.t53.Size = new System.Drawing.Size(20, 20);
            this.t53.TabIndex = 136;
            this.t53.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t54
            // 
            this.t54.BackColor = System.Drawing.Color.White;
            this.t54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t54.ForeColor = System.Drawing.Color.Black;
            this.t54.Location = new System.Drawing.Point(3, 155);
            this.t54.MaxLength = 1;
            this.t54.Name = "t54";
            this.t54.Size = new System.Drawing.Size(20, 20);
            this.t54.TabIndex = 137;
            this.t54.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t55
            // 
            this.t55.BackColor = System.Drawing.Color.White;
            this.t55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t55.ForeColor = System.Drawing.Color.Black;
            this.t55.Location = new System.Drawing.Point(24, 155);
            this.t55.MaxLength = 1;
            this.t55.Name = "t55";
            this.t55.Size = new System.Drawing.Size(20, 20);
            this.t55.TabIndex = 138;
            this.t55.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t56
            // 
            this.t56.BackColor = System.Drawing.Color.White;
            this.t56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t56.ForeColor = System.Drawing.Color.Black;
            this.t56.Location = new System.Drawing.Point(44, 155);
            this.t56.MaxLength = 1;
            this.t56.Name = "t56";
            this.t56.Size = new System.Drawing.Size(20, 20);
            this.t56.TabIndex = 139;
            this.t56.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t57
            // 
            this.t57.BackColor = System.Drawing.Color.White;
            this.t57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t57.ForeColor = System.Drawing.Color.Black;
            this.t57.Location = new System.Drawing.Point(67, 155);
            this.t57.MaxLength = 1;
            this.t57.Name = "t57";
            this.t57.Size = new System.Drawing.Size(20, 20);
            this.t57.TabIndex = 140;
            this.t57.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t58
            // 
            this.t58.BackColor = System.Drawing.Color.White;
            this.t58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t58.ForeColor = System.Drawing.Color.Black;
            this.t58.Location = new System.Drawing.Point(87, 155);
            this.t58.MaxLength = 1;
            this.t58.Name = "t58";
            this.t58.Size = new System.Drawing.Size(20, 20);
            this.t58.TabIndex = 141;
            this.t58.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t59
            // 
            this.t59.BackColor = System.Drawing.Color.White;
            this.t59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t59.ForeColor = System.Drawing.Color.Black;
            this.t59.Location = new System.Drawing.Point(106, 155);
            this.t59.MaxLength = 1;
            this.t59.Name = "t59";
            this.t59.Size = new System.Drawing.Size(20, 20);
            this.t59.TabIndex = 142;
            this.t59.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t60
            // 
            this.t60.BackColor = System.Drawing.Color.White;
            this.t60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t60.ForeColor = System.Drawing.Color.Black;
            this.t60.Location = new System.Drawing.Point(129, 155);
            this.t60.MaxLength = 1;
            this.t60.Name = "t60";
            this.t60.Size = new System.Drawing.Size(20, 20);
            this.t60.TabIndex = 143;
            this.t60.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t61
            // 
            this.t61.BackColor = System.Drawing.Color.White;
            this.t61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t61.ForeColor = System.Drawing.Color.Black;
            this.t61.Location = new System.Drawing.Point(149, 155);
            this.t61.MaxLength = 1;
            this.t61.Name = "t61";
            this.t61.Size = new System.Drawing.Size(20, 20);
            this.t61.TabIndex = 144;
            this.t61.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t62
            // 
            this.t62.BackColor = System.Drawing.Color.White;
            this.t62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t62.ForeColor = System.Drawing.Color.Black;
            this.t62.Location = new System.Drawing.Point(169, 155);
            this.t62.MaxLength = 1;
            this.t62.Name = "t62";
            this.t62.Size = new System.Drawing.Size(20, 20);
            this.t62.TabIndex = 145;
            this.t62.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t63
            // 
            this.t63.BackColor = System.Drawing.Color.White;
            this.t63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t63.ForeColor = System.Drawing.Color.Black;
            this.t63.Location = new System.Drawing.Point(2, 175);
            this.t63.MaxLength = 1;
            this.t63.Name = "t63";
            this.t63.Size = new System.Drawing.Size(20, 20);
            this.t63.TabIndex = 146;
            this.t63.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t64
            // 
            this.t64.BackColor = System.Drawing.Color.White;
            this.t64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t64.ForeColor = System.Drawing.Color.Black;
            this.t64.Location = new System.Drawing.Point(24, 175);
            this.t64.MaxLength = 1;
            this.t64.Name = "t64";
            this.t64.Size = new System.Drawing.Size(20, 20);
            this.t64.TabIndex = 147;
            this.t64.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t65
            // 
            this.t65.BackColor = System.Drawing.Color.White;
            this.t65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t65.ForeColor = System.Drawing.Color.Black;
            this.t65.Location = new System.Drawing.Point(44, 175);
            this.t65.MaxLength = 1;
            this.t65.Name = "t65";
            this.t65.Size = new System.Drawing.Size(20, 20);
            this.t65.TabIndex = 148;
            this.t65.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t66
            // 
            this.t66.BackColor = System.Drawing.Color.White;
            this.t66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t66.ForeColor = System.Drawing.Color.Black;
            this.t66.Location = new System.Drawing.Point(67, 175);
            this.t66.MaxLength = 1;
            this.t66.Name = "t66";
            this.t66.Size = new System.Drawing.Size(20, 20);
            this.t66.TabIndex = 149;
            this.t66.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t67
            // 
            this.t67.BackColor = System.Drawing.Color.White;
            this.t67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t67.ForeColor = System.Drawing.Color.Black;
            this.t67.Location = new System.Drawing.Point(87, 175);
            this.t67.MaxLength = 1;
            this.t67.Name = "t67";
            this.t67.Size = new System.Drawing.Size(20, 20);
            this.t67.TabIndex = 150;
            this.t67.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t68
            // 
            this.t68.BackColor = System.Drawing.Color.White;
            this.t68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t68.ForeColor = System.Drawing.Color.Black;
            this.t68.Location = new System.Drawing.Point(106, 175);
            this.t68.MaxLength = 1;
            this.t68.Name = "t68";
            this.t68.Size = new System.Drawing.Size(20, 20);
            this.t68.TabIndex = 151;
            this.t68.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t69
            // 
            this.t69.BackColor = System.Drawing.Color.White;
            this.t69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t69.ForeColor = System.Drawing.Color.Black;
            this.t69.Location = new System.Drawing.Point(129, 175);
            this.t69.MaxLength = 1;
            this.t69.Name = "t69";
            this.t69.Size = new System.Drawing.Size(20, 20);
            this.t69.TabIndex = 152;
            this.t69.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t70
            // 
            this.t70.BackColor = System.Drawing.Color.White;
            this.t70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t70.ForeColor = System.Drawing.Color.Black;
            this.t70.Location = new System.Drawing.Point(149, 175);
            this.t70.MaxLength = 1;
            this.t70.Name = "t70";
            this.t70.Size = new System.Drawing.Size(20, 20);
            this.t70.TabIndex = 153;
            this.t70.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t71
            // 
            this.t71.BackColor = System.Drawing.Color.White;
            this.t71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t71.ForeColor = System.Drawing.Color.Black;
            this.t71.Location = new System.Drawing.Point(169, 175);
            this.t71.MaxLength = 1;
            this.t71.Name = "t71";
            this.t71.Size = new System.Drawing.Size(20, 20);
            this.t71.TabIndex = 154;
            this.t71.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t72
            // 
            this.t72.BackColor = System.Drawing.Color.White;
            this.t72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t72.ForeColor = System.Drawing.Color.Black;
            this.t72.Location = new System.Drawing.Point(2, 195);
            this.t72.MaxLength = 1;
            this.t72.Name = "t72";
            this.t72.Size = new System.Drawing.Size(20, 20);
            this.t72.TabIndex = 155;
            this.t72.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t73
            // 
            this.t73.BackColor = System.Drawing.Color.White;
            this.t73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t73.ForeColor = System.Drawing.Color.Black;
            this.t73.Location = new System.Drawing.Point(24, 195);
            this.t73.MaxLength = 1;
            this.t73.Name = "t73";
            this.t73.Size = new System.Drawing.Size(20, 20);
            this.t73.TabIndex = 156;
            this.t73.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t74
            // 
            this.t74.BackColor = System.Drawing.Color.White;
            this.t74.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t74.ForeColor = System.Drawing.Color.Black;
            this.t74.Location = new System.Drawing.Point(44, 195);
            this.t74.MaxLength = 1;
            this.t74.Name = "t74";
            this.t74.Size = new System.Drawing.Size(20, 20);
            this.t74.TabIndex = 157;
            this.t74.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t75
            // 
            this.t75.BackColor = System.Drawing.Color.White;
            this.t75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t75.ForeColor = System.Drawing.Color.Black;
            this.t75.Location = new System.Drawing.Point(67, 195);
            this.t75.MaxLength = 1;
            this.t75.Name = "t75";
            this.t75.Size = new System.Drawing.Size(20, 20);
            this.t75.TabIndex = 158;
            this.t75.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t76
            // 
            this.t76.BackColor = System.Drawing.Color.White;
            this.t76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t76.ForeColor = System.Drawing.Color.Black;
            this.t76.Location = new System.Drawing.Point(87, 195);
            this.t76.MaxLength = 1;
            this.t76.Name = "t76";
            this.t76.Size = new System.Drawing.Size(20, 20);
            this.t76.TabIndex = 159;
            this.t76.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t77
            // 
            this.t77.BackColor = System.Drawing.Color.White;
            this.t77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t77.ForeColor = System.Drawing.Color.Black;
            this.t77.Location = new System.Drawing.Point(106, 195);
            this.t77.MaxLength = 1;
            this.t77.Name = "t77";
            this.t77.Size = new System.Drawing.Size(20, 20);
            this.t77.TabIndex = 160;
            this.t77.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t78
            // 
            this.t78.BackColor = System.Drawing.Color.White;
            this.t78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t78.ForeColor = System.Drawing.Color.Black;
            this.t78.Location = new System.Drawing.Point(129, 195);
            this.t78.MaxLength = 1;
            this.t78.Name = "t78";
            this.t78.Size = new System.Drawing.Size(20, 20);
            this.t78.TabIndex = 161;
            this.t78.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t79
            // 
            this.t79.BackColor = System.Drawing.Color.White;
            this.t79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t79.ForeColor = System.Drawing.Color.Black;
            this.t79.Location = new System.Drawing.Point(149, 195);
            this.t79.MaxLength = 1;
            this.t79.Name = "t79";
            this.t79.Size = new System.Drawing.Size(20, 20);
            this.t79.TabIndex = 162;
            this.t79.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t80
            // 
            this.t80.BackColor = System.Drawing.Color.White;
            this.t80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t80.ForeColor = System.Drawing.Color.Black;
            this.t80.Location = new System.Drawing.Point(169, 195);
            this.t80.MaxLength = 1;
            this.t80.Name = "t80";
            this.t80.Size = new System.Drawing.Size(20, 20);
            this.t80.TabIndex = 163;
            this.t80.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bw1
            // 
            this.bw1.WorkerReportsProgress = true;
            this.bw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw1_DoWork);
            this.bw1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw1_RunWorkerCompleted);
            this.bw1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw1_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(194, 219);
            this.Controls.Add(this.t80);
            this.Controls.Add(this.t79);
            this.Controls.Add(this.t78);
            this.Controls.Add(this.t77);
            this.Controls.Add(this.t76);
            this.Controls.Add(this.t75);
            this.Controls.Add(this.t74);
            this.Controls.Add(this.t73);
            this.Controls.Add(this.t72);
            this.Controls.Add(this.t71);
            this.Controls.Add(this.t70);
            this.Controls.Add(this.t69);
            this.Controls.Add(this.t68);
            this.Controls.Add(this.t67);
            this.Controls.Add(this.t66);
            this.Controls.Add(this.t65);
            this.Controls.Add(this.t64);
            this.Controls.Add(this.t63);
            this.Controls.Add(this.t62);
            this.Controls.Add(this.t61);
            this.Controls.Add(this.t60);
            this.Controls.Add(this.t59);
            this.Controls.Add(this.t58);
            this.Controls.Add(this.t57);
            this.Controls.Add(this.t56);
            this.Controls.Add(this.t55);
            this.Controls.Add(this.t54);
            this.Controls.Add(this.t53);
            this.Controls.Add(this.t52);
            this.Controls.Add(this.t51);
            this.Controls.Add(this.t50);
            this.Controls.Add(this.t49);
            this.Controls.Add(this.t48);
            this.Controls.Add(this.t47);
            this.Controls.Add(this.t46);
            this.Controls.Add(this.t45);
            this.Controls.Add(this.t44);
            this.Controls.Add(this.t43);
            this.Controls.Add(this.t42);
            this.Controls.Add(this.t41);
            this.Controls.Add(this.t40);
            this.Controls.Add(this.t39);
            this.Controls.Add(this.t38);
            this.Controls.Add(this.t37);
            this.Controls.Add(this.t36);
            this.Controls.Add(this.t35);
            this.Controls.Add(this.t34);
            this.Controls.Add(this.t33);
            this.Controls.Add(this.t32);
            this.Controls.Add(this.t31);
            this.Controls.Add(this.t30);
            this.Controls.Add(this.t29);
            this.Controls.Add(this.t28);
            this.Controls.Add(this.t27);
            this.Controls.Add(this.t26);
            this.Controls.Add(this.t25);
            this.Controls.Add(this.t24);
            this.Controls.Add(this.t23);
            this.Controls.Add(this.t22);
            this.Controls.Add(this.t21);
            this.Controls.Add(this.t20);
            this.Controls.Add(this.t19);
            this.Controls.Add(this.t18);
            this.Controls.Add(this.t17);
            this.Controls.Add(this.t16);
            this.Controls.Add(this.t15);
            this.Controls.Add(this.t14);
            this.Controls.Add(this.t13);
            this.Controls.Add(this.t12);
            this.Controls.Add(this.t11);
            this.Controls.Add(this.t10);
            this.Controls.Add(this.t9);
            this.Controls.Add(this.t8);
            this.Controls.Add(this.t7);
            this.Controls.Add(this.t6);
            this.Controls.Add(this.t5);
            this.Controls.Add(this.t4);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.t0);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Walt\'s WinSuDoku";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
#endregion

        #region event handlers

        /// <summary>
        /// Called by BackgroundWorker to change UI textbox values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains textbox index and new text value</param>
        void bw1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            textUpdate(e);
        }

        /// <summary>
        /// Called by BackgroundWorker upon completion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">e.Result = 0 means success, 1 means could not solve puzzle</param>
        void bw1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                CompleteMessage("Success!");
            }
            else
                CompleteMessage("No solution could be found");
        }

        /// <summary>
        /// Main BackgroundWorker routine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bw1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = solveIt(worker, e);
        }

        /// <summary>
        /// Clear out all calculated values in puzzle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuEdit_Click(object sender, System.EventArgs e)
        {
            editInitial();
        }

        /// <summary>
        /// Clear out puzzle competely
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuClear_Click(object sender, System.EventArgs e)
        {
            clearMenu();
        }

        /// <summary>
        /// event handler to start solving puzzle based on menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuAutoplay_Click(object sender, System.EventArgs e)
        {
            Startwork();
        }

        /// <summary>
        /// What's to say about menu click 'Exit'?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Variables declaration
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuAutoplay;
        private System.Windows.Forms.TextBox t0;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.TextBox t2;
        private System.Windows.Forms.TextBox t3;
        private System.Windows.Forms.TextBox t4;
        private System.Windows.Forms.TextBox t5;
        private System.Windows.Forms.TextBox t6;
        private System.Windows.Forms.TextBox t7;
        private System.Windows.Forms.TextBox t8;
        private System.Windows.Forms.TextBox t9;
        private System.Windows.Forms.TextBox t10;
        private System.Windows.Forms.TextBox t11;
        private System.Windows.Forms.TextBox t12;
        private System.Windows.Forms.TextBox t13;
        private System.Windows.Forms.TextBox t14;
        private System.Windows.Forms.TextBox t15;
        private System.Windows.Forms.TextBox t16;
        private System.Windows.Forms.TextBox t17;
        private System.Windows.Forms.TextBox t18;
        private System.Windows.Forms.TextBox t19;
        private System.Windows.Forms.TextBox t20;
        private System.Windows.Forms.TextBox t21;
        private System.Windows.Forms.TextBox t22;
        private System.Windows.Forms.TextBox t23;
        private System.Windows.Forms.TextBox t24;
        private System.Windows.Forms.TextBox t25;
        private System.Windows.Forms.TextBox t26;
        private System.Windows.Forms.TextBox t27;
        private System.Windows.Forms.TextBox t28;
        private System.Windows.Forms.TextBox t29;
        private System.Windows.Forms.TextBox t30;
        private System.Windows.Forms.TextBox t31;
        private System.Windows.Forms.TextBox t32;
        private System.Windows.Forms.TextBox t33;
        private System.Windows.Forms.TextBox t34;
        private System.Windows.Forms.TextBox t35;
        private System.Windows.Forms.TextBox t36;
        private System.Windows.Forms.TextBox t37;
        private System.Windows.Forms.TextBox t38;
        private System.Windows.Forms.TextBox t39;
        private System.Windows.Forms.TextBox t40;
        private System.Windows.Forms.TextBox t41;
        private System.Windows.Forms.TextBox t42;
        private System.Windows.Forms.TextBox t43;
        private System.Windows.Forms.TextBox t44;
        private System.Windows.Forms.TextBox t45;
        private System.Windows.Forms.TextBox t46;
        private System.Windows.Forms.TextBox t47;
        private System.Windows.Forms.TextBox t48;
        private System.Windows.Forms.TextBox t49;
        private System.Windows.Forms.TextBox t50;
        private System.Windows.Forms.TextBox t51;
        private System.Windows.Forms.TextBox t52;
        private System.Windows.Forms.TextBox t53;
        private System.Windows.Forms.TextBox t54;
        private System.Windows.Forms.TextBox t55;
        private System.Windows.Forms.TextBox t56;
        private System.Windows.Forms.TextBox t57;
        private System.Windows.Forms.TextBox t58;
        private System.Windows.Forms.TextBox t59;
        private System.Windows.Forms.TextBox t60;
        private System.Windows.Forms.TextBox t61;
        private System.Windows.Forms.TextBox t62;
        private System.Windows.Forms.TextBox t63;
        private System.Windows.Forms.TextBox t64;
        private System.Windows.Forms.TextBox t65;
        private System.Windows.Forms.TextBox t66;
        private System.Windows.Forms.TextBox t67;
        private System.Windows.Forms.TextBox t68;
        private System.Windows.Forms.TextBox t69;
        private System.Windows.Forms.TextBox t70;
        private System.Windows.Forms.TextBox t71;
        private System.Windows.Forms.TextBox t72;
        private System.Windows.Forms.TextBox t73;
        private System.Windows.Forms.TextBox t74;
        private System.Windows.Forms.TextBox t75;
        private System.Windows.Forms.TextBox t76;
        private System.Windows.Forms.TextBox t77;
        private System.Windows.Forms.TextBox t78;
        private System.Windows.Forms.TextBox t79;
        private System.Windows.Forms.TextBox t80;
        private int[,] ar;
        private System.Windows.Forms.ToolStripMenuItem MenuClear;
        private System.Windows.Forms.ToolStripMenuItem MenuEdit;
        private System.ComponentModel.BackgroundWorker bw1;
        #endregion
    }
 
}

