using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using Firebase.Storage;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace LocketImageUploader
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.MaskedTextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.UploadProgessBar = new System.Windows.Forms.ProgressBar();
            this.LinkTextBox = new System.Windows.Forms.TextBox();
            this.BtnChooseFile = new System.Windows.Forms.Button();
            this.TxtBoxFilePath = new System.Windows.Forms.TextBox();
            this.CheckBoxUploadVideo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(75, 9);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(192, 20);
            this.UserNameTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(75, 42);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(192, 20);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(302, 13);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(79, 42);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "Đăng nhập";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Enabled = false;
            this.LogoutBtn.Location = new System.Drawing.Point(387, 13);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(79, 42);
            this.LogoutBtn.TabIndex = 6;
            this.LogoutBtn.Text = "Đăng xuất";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // UploadProgessBar
            // 
            this.UploadProgessBar.Location = new System.Drawing.Point(11, 112);
            this.UploadProgessBar.Name = "UploadProgessBar";
            this.UploadProgessBar.Size = new System.Drawing.Size(529, 23);
            this.UploadProgessBar.TabIndex = 7;
            // 
            // LinkTextBox
            // 
            this.LinkTextBox.Location = new System.Drawing.Point(12, 152);
            this.LinkTextBox.Multiline = true;
            this.LinkTextBox.Name = "LinkTextBox";
            this.LinkTextBox.ReadOnly = true;
            this.LinkTextBox.Size = new System.Drawing.Size(528, 85);
            this.LinkTextBox.TabIndex = 8;
            // 
            // BtnChooseFile
            // 
            this.BtnChooseFile.Location = new System.Drawing.Point(16, 78);
            this.BtnChooseFile.Name = "BtnChooseFile";
            this.BtnChooseFile.Size = new System.Drawing.Size(75, 23);
            this.BtnChooseFile.TabIndex = 9;
            this.BtnChooseFile.Text = "Chọn file";
            this.BtnChooseFile.UseVisualStyleBackColor = true;
            this.BtnChooseFile.Click += new System.EventHandler(this.BtnChooseFile_Click);
            // 
            // TxtBoxFilePath
            // 
            this.TxtBoxFilePath.Location = new System.Drawing.Point(110, 78);
            this.TxtBoxFilePath.Name = "TxtBoxFilePath";
            this.TxtBoxFilePath.ReadOnly = true;
            this.TxtBoxFilePath.Size = new System.Drawing.Size(356, 20);
            this.TxtBoxFilePath.TabIndex = 10;
            // 
            // CheckBoxUploadVideo
            // 
            this.CheckBoxUploadVideo.AutoSize = true;
            this.CheckBoxUploadVideo.Location = new System.Drawing.Point(473, 83);
            this.CheckBoxUploadVideo.Name = "CheckBoxUploadVideo";
            this.CheckBoxUploadVideo.Size = new System.Drawing.Size(89, 17);
            this.CheckBoxUploadVideo.TabIndex = 11;
            this.CheckBoxUploadVideo.Text = "Upload video";
            this.CheckBoxUploadVideo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 313);
            this.Controls.Add(this.CheckBoxUploadVideo);
            this.Controls.Add(this.TxtBoxFilePath);
            this.Controls.Add(this.BtnChooseFile);
            this.Controls.Add(this.LinkTextBox);
            this.Controls.Add(this.UploadProgessBar);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Locket Image Upload Tool By HoanNK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.MaskedTextBox PasswordTextBox;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.ProgressBar UploadProgessBar;
        private System.Windows.Forms.TextBox LinkTextBox;
        private System.Windows.Forms.Button BtnChooseFile;
        private System.Windows.Forms.TextBox TxtBoxFilePath;
        private System.Windows.Forms.CheckBox CheckBoxUploadVideo;
    }
}

