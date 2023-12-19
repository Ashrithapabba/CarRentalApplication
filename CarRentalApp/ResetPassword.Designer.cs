namespace CarRentalApp
{
    partial class ResetPassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbenterpassword = new System.Windows.Forms.TextBox();
            this.tbconfirmpassword = new System.Windows.Forms.TextBox();
            this.btnresetpassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm Password";
            // 
            // tbenterpassword
            // 
            this.tbenterpassword.Location = new System.Drawing.Point(89, 43);
            this.tbenterpassword.Name = "tbenterpassword";
            this.tbenterpassword.PasswordChar = '*';
            this.tbenterpassword.Size = new System.Drawing.Size(128, 22);
            this.tbenterpassword.TabIndex = 2;
            // 
            // tbconfirmpassword
            // 
            this.tbconfirmpassword.Location = new System.Drawing.Point(89, 114);
            this.tbconfirmpassword.Name = "tbconfirmpassword";
            this.tbconfirmpassword.PasswordChar = '*';
            this.tbconfirmpassword.Size = new System.Drawing.Size(128, 22);
            this.tbconfirmpassword.TabIndex = 3;
            // 
            // btnresetpassword
            // 
            this.btnresetpassword.Location = new System.Drawing.Point(98, 172);
            this.btnresetpassword.Name = "btnresetpassword";
            this.btnresetpassword.Size = new System.Drawing.Size(119, 23);
            this.btnresetpassword.TabIndex = 4;
            this.btnresetpassword.Text = "Reset Password";
            this.btnresetpassword.UseVisualStyleBackColor = true;
            this.btnresetpassword.Click += new System.EventHandler(this.btnresetpassword_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 220);
            this.Controls.Add(this.btnresetpassword);
            this.Controls.Add(this.tbconfirmpassword);
            this.Controls.Add(this.tbenterpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ResetPassword";
            this.Text = "Reset Password";
            this.Load += new System.EventHandler(this.ResetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbenterpassword;
        private System.Windows.Forms.TextBox tbconfirmpassword;
        private System.Windows.Forms.Button btnresetpassword;
    }
}