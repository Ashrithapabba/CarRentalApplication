namespace CarRentalApp
{
    partial class AddUser
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbUsername = new System.Windows.Forms.Label();
            this.tbNameUser = new System.Windows.Forms.TextBox();
            this.tbRoles = new System.Windows.Forms.Label();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(95, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 55);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Add User";
//            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tbRoles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbUsername, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbNameUser, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbRoles, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(47, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(299, 151);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tbUsername
            // 
            this.tbUsername.AutoSize = true;
            this.tbUsername.Location = new System.Drawing.Point(3, 0);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(70, 16);
            this.tbUsername.TabIndex = 0;
            this.tbUsername.Text = "Username";
            // 
            // tbNameUser
            // 
            this.tbNameUser.Location = new System.Drawing.Point(152, 3);
            this.tbNameUser.Name = "tbNameUser";
            this.tbNameUser.Size = new System.Drawing.Size(144, 22);
            this.tbNameUser.TabIndex = 1;
            // 
            // tbRoles
            // 
            this.tbRoles.AutoSize = true;
            this.tbRoles.Location = new System.Drawing.Point(3, 75);
            this.tbRoles.Name = "tbRoles";
            this.tbRoles.Size = new System.Drawing.Size(36, 16);
            this.tbRoles.TabIndex = 2;
            this.tbRoles.Text = "Role";
            // 
            // cbRoles
            // 
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(152, 78);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(144, 24);
            this.cbRoles.TabIndex = 3;
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(80, 262);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 23);
            this.btnsubmit.TabIndex = 3;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(229, 262);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 4;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 306);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "AddUser";
            this.Text = "Add User";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tbRoles;
        private System.Windows.Forms.Label tbUsername;
        private System.Windows.Forms.TextBox tbNameUser;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Button btncancel;
    }
}