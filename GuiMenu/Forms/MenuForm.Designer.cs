namespace Blueberry.Forms
{
    partial class MenuForm
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
            this.title = new System.Windows.Forms.Label();
            this.GameLabel = new System.Windows.Forms.Label();
            this.Page = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.title.Font = new System.Drawing.Font("Arial", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(147, -1);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(111, 34);
            this.title.TabIndex = 0;
            this.title.Text = "Cheats";
            this.title.UseMnemonic = false;
            this.title.Click += new System.EventHandler(this.title_Click);
            // 
            // GameLabel
            // 
            this.GameLabel.AutoSize = true;
            this.GameLabel.BackColor = System.Drawing.Color.Transparent;
            this.GameLabel.Font = new System.Drawing.Font("Segoe UI", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameLabel.ForeColor = System.Drawing.Color.White;
            this.GameLabel.Location = new System.Drawing.Point(115, 33);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(66, 28);
            this.GameLabel.TabIndex = 1;
            this.GameLabel.Text = "Game";
            this.GameLabel.UseMnemonic = false;
            // 
            // Page
            // 
            this.Page.AutoSize = true;
            this.Page.BackColor = System.Drawing.Color.Brown;
            this.Page.Font = new System.Drawing.Font("Segoe UI", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Page.ForeColor = System.Drawing.Color.White;
            this.Page.Location = new System.Drawing.Point(148, 535);
            this.Page.Name = "Page";
            this.Page.Size = new System.Drawing.Size(59, 28);
            this.Page.TabIndex = 2;
            this.Page.Text = "Page";
            this.Page.UseMnemonic = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Bisque;
            this.panel2.Location = new System.Drawing.Point(22, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 468);
            this.panel2.TabIndex = 3;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(382, 564);
            this.Controls.Add(this.title);
            this.Controls.Add(this.GameLabel);
            this.Controls.Add(this.Page);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Menu";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title;
        public System.Windows.Forms.Label GameLabel;
        internal System.Windows.Forms.Label Page;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel panel2;
    }
}