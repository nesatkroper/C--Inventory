namespace InventorySys.View
{
    partial class HomePage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbAppname = new System.Windows.Forms.Label();
            this.pnSidebar = new System.Windows.Forms.Panel();
            this.pnMaster = new System.Windows.Forms.Panel();
            this.tmToggle = new System.Windows.Forms.Timer(this.components);
            this.btnPro = new System.Windows.Forms.Button();
            this.btnDash = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Controls.Add(this.lbDate);
            this.panel1.Controls.Add(this.lbAppname);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1334, 50);
            this.panel1.TabIndex = 0;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.AutoSize = true;
            this.lbDate.ForeColor = System.Drawing.Color.White;
            this.lbDate.Location = new System.Drawing.Point(1139, 2);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(54, 26);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "label1";
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(1176, 24);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(58, 26);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "label2";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbAppname
            // 
            this.lbAppname.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbAppname.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppname.ForeColor = System.Drawing.Color.White;
            this.lbAppname.Location = new System.Drawing.Point(0, 0);
            this.lbAppname.Name = "lbAppname";
            this.lbAppname.Size = new System.Drawing.Size(1334, 45);
            this.lbAppname.TabIndex = 2;
            this.lbAppname.Text = "Mini Mart Inventory Management System";
            this.lbAppname.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnSidebar
            // 
            this.pnSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.pnSidebar.Controls.Add(this.btnPro);
            this.pnSidebar.Controls.Add(this.btnDash);
            this.pnSidebar.Controls.Add(this.btnMenu);
            this.pnSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSidebar.Location = new System.Drawing.Point(0, 50);
            this.pnSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.pnSidebar.Name = "pnSidebar";
            this.pnSidebar.Size = new System.Drawing.Size(170, 761);
            this.pnSidebar.TabIndex = 1;
            // 
            // pnMaster
            // 
            this.pnMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMaster.Location = new System.Drawing.Point(170, 50);
            this.pnMaster.Margin = new System.Windows.Forms.Padding(0);
            this.pnMaster.Name = "pnMaster";
            this.pnMaster.Size = new System.Drawing.Size(1164, 761);
            this.pnMaster.TabIndex = 2;
            // 
            // tmToggle
            // 
            this.tmToggle.Interval = 10;
            this.tmToggle.Tick += new System.EventHandler(this.tmToggle_Tick);
            // 
            // btnPro
            // 
            this.btnPro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnPro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPro.FlatAppearance.BorderSize = 0;
            this.btnPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPro.ForeColor = System.Drawing.Color.White;
            this.btnPro.Image = global::InventorySys.Properties.Resources.shopping_bags_solid_24;
            this.btnPro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPro.Location = new System.Drawing.Point(0, 80);
            this.btnPro.Name = "btnPro";
            this.btnPro.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnPro.Size = new System.Drawing.Size(170, 40);
            this.btnPro.TabIndex = 2;
            this.btnPro.Text = "Product";
            this.btnPro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPro.UseVisualStyleBackColor = false;
            this.btnPro.Click += new System.EventHandler(this.btnPro_Click);
            // 
            // btnDash
            // 
            this.btnDash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnDash.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDash.FlatAppearance.BorderSize = 0;
            this.btnDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDash.ForeColor = System.Drawing.Color.White;
            this.btnDash.Image = global::InventorySys.Properties.Resources.bar_chart_alt_2_solid_24__2_1;
            this.btnDash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDash.Location = new System.Drawing.Point(0, 40);
            this.btnDash.Name = "btnDash";
            this.btnDash.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnDash.Size = new System.Drawing.Size(170, 40);
            this.btnDash.TabIndex = 1;
            this.btnDash.Text = "Dashboard";
            this.btnDash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDash.UseVisualStyleBackColor = false;
            this.btnDash.Click += new System.EventHandler(this.btnDash_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(83)))));
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Image = global::InventorySys.Properties.Resources.spreadsheet_regular_24;
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnMenu.Size = new System.Drawing.Size(170, 40);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Text = "Menu";
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 811);
            this.Controls.Add(this.pnMaster);
            this.Controls.Add(this.pnSidebar);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MinimumSize = new System.Drawing.Size(1350, 850);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomePage_FormClosed);
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbAppname;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel pnSidebar;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnDash;
        private System.Windows.Forms.Panel pnMaster;
        private System.Windows.Forms.Timer tmToggle;
        private System.Windows.Forms.Button btnPro;
    }
}