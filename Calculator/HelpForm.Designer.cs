namespace Calculator
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.engTab = new System.Windows.Forms.TabPage();
            this.engHelpRTB = new System.Windows.Forms.RichTextBox();
            this.matTab = new System.Windows.Forms.TabPage();
            this.matHelpRTB = new System.Windows.Forms.RichTextBox();
            this.graTab = new System.Windows.Forms.TabPage();
            this.graHelpRTB = new System.Windows.Forms.RichTextBox();
            this.curTab = new System.Windows.Forms.TabPage();
            this.curHelpRTB = new System.Windows.Forms.RichTextBox();
            this.datTab = new System.Windows.Forms.TabPage();
            this.datHelpRTB = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.engTab.SuspendLayout();
            this.matTab.SuspendLayout();
            this.graTab.SuspendLayout();
            this.curTab.SuspendLayout();
            this.datTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.engTab);
            this.tabControl1.Controls.Add(this.matTab);
            this.tabControl1.Controls.Add(this.graTab);
            this.tabControl1.Controls.Add(this.curTab);
            this.tabControl1.Controls.Add(this.datTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 442);
            this.tabControl1.TabIndex = 0;
            // 
            // engTab
            // 
            this.engTab.Controls.Add(this.engHelpRTB);
            this.engTab.Location = new System.Drawing.Point(4, 22);
            this.engTab.Name = "engTab";
            this.engTab.Size = new System.Drawing.Size(616, 416);
            this.engTab.TabIndex = 5;
            this.engTab.Text = "Инженерный";
            this.engTab.UseVisualStyleBackColor = true;
            this.engTab.Layout += new System.Windows.Forms.LayoutEventHandler(this.engTab_Layout);
            // 
            // engHelpRTB
            // 
            this.engHelpRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.engHelpRTB.Location = new System.Drawing.Point(0, 0);
            this.engHelpRTB.Name = "engHelpRTB";
            this.engHelpRTB.ReadOnly = true;
            this.engHelpRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.engHelpRTB.Size = new System.Drawing.Size(616, 416);
            this.engHelpRTB.TabIndex = 2;
            this.engHelpRTB.Text = "";
            // 
            // matTab
            // 
            this.matTab.Controls.Add(this.matHelpRTB);
            this.matTab.Location = new System.Drawing.Point(4, 22);
            this.matTab.Name = "matTab";
            this.matTab.Size = new System.Drawing.Size(616, 416);
            this.matTab.TabIndex = 6;
            this.matTab.Text = "Матрицы";
            this.matTab.UseVisualStyleBackColor = true;
            this.matTab.Layout += new System.Windows.Forms.LayoutEventHandler(this.matTab_Layout);
            // 
            // matHelpRTB
            // 
            this.matHelpRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matHelpRTB.Location = new System.Drawing.Point(0, 0);
            this.matHelpRTB.Name = "matHelpRTB";
            this.matHelpRTB.ReadOnly = true;
            this.matHelpRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.matHelpRTB.Size = new System.Drawing.Size(616, 416);
            this.matHelpRTB.TabIndex = 2;
            this.matHelpRTB.Text = "";
            // 
            // graTab
            // 
            this.graTab.Controls.Add(this.graHelpRTB);
            this.graTab.Location = new System.Drawing.Point(4, 22);
            this.graTab.Name = "graTab";
            this.graTab.Size = new System.Drawing.Size(616, 416);
            this.graTab.TabIndex = 2;
            this.graTab.Text = "Графики";
            this.graTab.UseVisualStyleBackColor = true;
            this.graTab.Layout += new System.Windows.Forms.LayoutEventHandler(this.graTab_Layout);
            // 
            // graHelpRTB
            // 
            this.graHelpRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graHelpRTB.Location = new System.Drawing.Point(0, 0);
            this.graHelpRTB.Name = "graHelpRTB";
            this.graHelpRTB.ReadOnly = true;
            this.graHelpRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.graHelpRTB.Size = new System.Drawing.Size(616, 416);
            this.graHelpRTB.TabIndex = 1;
            this.graHelpRTB.Text = "";
            // 
            // curTab
            // 
            this.curTab.Controls.Add(this.curHelpRTB);
            this.curTab.Location = new System.Drawing.Point(4, 22);
            this.curTab.Name = "curTab";
            this.curTab.Size = new System.Drawing.Size(616, 416);
            this.curTab.TabIndex = 3;
            this.curTab.Text = "Валюта";
            this.curTab.UseVisualStyleBackColor = true;
            this.curTab.Layout += new System.Windows.Forms.LayoutEventHandler(this.curTab_Layout);
            // 
            // curHelpRTB
            // 
            this.curHelpRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curHelpRTB.Location = new System.Drawing.Point(0, 0);
            this.curHelpRTB.Name = "curHelpRTB";
            this.curHelpRTB.ReadOnly = true;
            this.curHelpRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.curHelpRTB.Size = new System.Drawing.Size(616, 416);
            this.curHelpRTB.TabIndex = 1;
            this.curHelpRTB.Text = "";
            // 
            // datTab
            // 
            this.datTab.Controls.Add(this.datHelpRTB);
            this.datTab.Location = new System.Drawing.Point(4, 22);
            this.datTab.Name = "datTab";
            this.datTab.Size = new System.Drawing.Size(616, 416);
            this.datTab.TabIndex = 4;
            this.datTab.Text = "Даты";
            this.datTab.UseVisualStyleBackColor = true;
            this.datTab.Layout += new System.Windows.Forms.LayoutEventHandler(this.datTab_Layout);
            // 
            // datHelpRTB
            // 
            this.datHelpRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datHelpRTB.Location = new System.Drawing.Point(0, 0);
            this.datHelpRTB.Name = "datHelpRTB";
            this.datHelpRTB.ReadOnly = true;
            this.datHelpRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.datHelpRTB.Size = new System.Drawing.Size(616, 416);
            this.datHelpRTB.TabIndex = 1;
            this.datHelpRTB.Text = "";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.Text = "Справка";
            this.tabControl1.ResumeLayout(false);
            this.engTab.ResumeLayout(false);
            this.matTab.ResumeLayout(false);
            this.graTab.ResumeLayout(false);
            this.curTab.ResumeLayout(false);
            this.datTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage graTab;
        private System.Windows.Forms.TabPage curTab;
        private System.Windows.Forms.RichTextBox curHelpRTB;
        private System.Windows.Forms.TabPage datTab;
        private System.Windows.Forms.RichTextBox datHelpRTB;
        private System.Windows.Forms.TabPage engTab;
        private System.Windows.Forms.RichTextBox engHelpRTB;
        private System.Windows.Forms.TabPage matTab;
        private System.Windows.Forms.RichTextBox matHelpRTB;
        private System.Windows.Forms.RichTextBox graHelpRTB;
    }
}