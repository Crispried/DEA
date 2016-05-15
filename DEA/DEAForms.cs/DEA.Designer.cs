namespace DEAForms.cs
{
    partial class DEA
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
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfEntryParams = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfExitParams = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numberOfObjects = new System.Windows.Forms.TextBox();
            this.createInputButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 25);
            this.label1.MaximumSize = new System.Drawing.Size(150, 25);
            this.label1.MinimumSize = new System.Drawing.Size(150, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of entry parameters";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberOfEntryParams
            // 
            this.numberOfEntryParams.Location = new System.Drawing.Point(250, 25);
            this.numberOfEntryParams.MaximumSize = new System.Drawing.Size(100, 25);
            this.numberOfEntryParams.MaxLength = 2;
            this.numberOfEntryParams.MinimumSize = new System.Drawing.Size(100, 25);
            this.numberOfEntryParams.Name = "numberOfEntryParams";
            this.numberOfEntryParams.Size = new System.Drawing.Size(100, 20);
            this.numberOfEntryParams.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 25);
            this.label2.MaximumSize = new System.Drawing.Size(150, 25);
            this.label2.MinimumSize = new System.Drawing.Size(150, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of exit parameters";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberOfExitParams
            // 
            this.numberOfExitParams.Location = new System.Drawing.Point(558, 25);
            this.numberOfExitParams.MaximumSize = new System.Drawing.Size(100, 25);
            this.numberOfExitParams.MaxLength = 2;
            this.numberOfExitParams.MinimumSize = new System.Drawing.Size(100, 25);
            this.numberOfExitParams.Name = "numberOfExitParams";
            this.numberOfExitParams.Size = new System.Drawing.Size(100, 20);
            this.numberOfExitParams.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(719, 25);
            this.label3.MaximumSize = new System.Drawing.Size(150, 25);
            this.label3.MinimumSize = new System.Drawing.Size(150, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number of objects";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberOfObjects
            // 
            this.numberOfObjects.ForeColor = System.Drawing.Color.Black;
            this.numberOfObjects.Location = new System.Drawing.Point(855, 25);
            this.numberOfObjects.MaximumSize = new System.Drawing.Size(100, 25);
            this.numberOfObjects.MaxLength = 2;
            this.numberOfObjects.MinimumSize = new System.Drawing.Size(100, 25);
            this.numberOfObjects.Name = "numberOfObjects";
            this.numberOfObjects.Size = new System.Drawing.Size(100, 20);
            this.numberOfObjects.TabIndex = 9;
            // 
            // createInputButton
            // 
            this.createInputButton.Location = new System.Drawing.Point(855, 67);
            this.createInputButton.MaximumSize = new System.Drawing.Size(100, 30);
            this.createInputButton.MinimumSize = new System.Drawing.Size(100, 30);
            this.createInputButton.Name = "createInputButton";
            this.createInputButton.Size = new System.Drawing.Size(100, 30);
            this.createInputButton.TabIndex = 10;
            this.createInputButton.Text = "Next";
            this.createInputButton.UseVisualStyleBackColor = true;
            this.createInputButton.Click += new System.EventHandler(this.createInputButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1087, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTaskToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newTaskToolStripMenuItem
            // 
            this.newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            this.newTaskToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.newTaskToolStripMenuItem.Text = "New Task";
            this.newTaskToolStripMenuItem.Click += new System.EventHandler(this.newTaskToolStripMenuItem_Click);
            // 
            // DEA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1087, 719);
            this.Controls.Add(this.createInputButton);
            this.Controls.Add(this.numberOfObjects);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberOfExitParams);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberOfEntryParams);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DEA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numberOfEntryParams;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numberOfExitParams;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numberOfObjects;
        private System.Windows.Forms.Button createInputButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem;
    }
}