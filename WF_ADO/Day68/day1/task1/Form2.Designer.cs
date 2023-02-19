namespace task1
{
    partial class Form2
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
            this.bf1 = new System.Windows.Forms.Button();
            this.bf2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bf1
            // 
            this.bf1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bf1.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bf1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bf1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bf1.ForeColor = System.Drawing.Color.Transparent;
            this.bf1.Location = new System.Drawing.Point(331, 24);
            this.bf1.Name = "bf1";
            this.bf1.Size = new System.Drawing.Size(147, 70);
            this.bf1.TabIndex = 2;
            this.bf1.Text = "Cancle";
            this.bf1.UseVisualStyleBackColor = false;
            this.bf1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bf2
            // 
            this.bf2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bf2.BackColor = System.Drawing.Color.PaleVioletRed;
            this.bf2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bf2.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bf2.ForeColor = System.Drawing.Color.Transparent;
            this.bf2.Location = new System.Drawing.Point(12, 162);
            this.bf2.Name = "bf2";
            this.bf2.Size = new System.Drawing.Size(147, 70);
            this.bf2.TabIndex = 1;
            this.bf2.Text = "OK";
            this.bf2.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(475, 27);
            this.textBox1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AcceptButton = this.bf2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.CancelButton = this.bf1;
            this.ClientSize = new System.Drawing.Size(499, 254);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bf2);
            this.Controls.Add(this.bf1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bf1;
        private Button bf2;
        private TextBox textBox1;
    }
}