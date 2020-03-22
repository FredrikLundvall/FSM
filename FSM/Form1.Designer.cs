namespace FSM
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
            this.btnGenerateName = new System.Windows.Forms.Button();
            this.lblGeneratedName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateName
            // 
            this.btnGenerateName.Location = new System.Drawing.Point(12, 12);
            this.btnGenerateName.Name = "btnGenerateName";
            this.btnGenerateName.Size = new System.Drawing.Size(132, 23);
            this.btnGenerateName.TabIndex = 3;
            this.btnGenerateName.Text = "Generate name";
            this.btnGenerateName.UseVisualStyleBackColor = true;
            this.btnGenerateName.Click += new System.EventHandler(this.btnGenerateName_Click);
            // 
            // lblGeneratedName
            // 
            this.lblGeneratedName.AutoSize = true;
            this.lblGeneratedName.Location = new System.Drawing.Point(35, 78);
            this.lblGeneratedName.Name = "lblGeneratedName";
            this.lblGeneratedName.Size = new System.Drawing.Size(92, 13);
            this.lblGeneratedName.TabIndex = 4;
            this.lblGeneratedName.Text = "Not generated yet";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Create FSM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblGeneratedName);
            this.Controls.Add(this.btnGenerateName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerateName;
        private System.Windows.Forms.Label lblGeneratedName;
        private System.Windows.Forms.Button button1;
    }
}

