﻿namespace MedicalPJ
{
    partial class QuestionForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.questionLbl = new System.Windows.Forms.Label();
            this.yesBtn = new System.Windows.Forms.RadioButton();
            this.noBtn = new System.Windows.Forms.RadioButton();
            this.questionGroupBox = new System.Windows.Forms.GroupBox();
            this.registerclickBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.questionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MedicalPJ.Properties.Resources.coollogo_com_228681207;
            this.pictureBox1.Location = new System.Drawing.Point(75, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // questionLbl
            // 
            this.questionLbl.AutoSize = true;
            this.questionLbl.Location = new System.Drawing.Point(236, 117);
            this.questionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.questionLbl.Name = "questionLbl";
            this.questionLbl.Size = new System.Drawing.Size(71, 15);
            this.questionLbl.TabIndex = 1;
            this.questionLbl.Text = "questionLbl";
            // 
            // yesBtn
            // 
            this.yesBtn.AutoSize = true;
            this.yesBtn.Location = new System.Drawing.Point(11, 8);
            this.yesBtn.Margin = new System.Windows.Forms.Padding(2);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(38, 19);
            this.yesBtn.TabIndex = 2;
            this.yesBtn.TabStop = true;
            this.yesBtn.Text = "כן";
            this.yesBtn.UseVisualStyleBackColor = true;
            // 
            // noBtn
            // 
            this.noBtn.AutoSize = true;
            this.noBtn.Location = new System.Drawing.Point(11, 35);
            this.noBtn.Margin = new System.Windows.Forms.Padding(2);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(43, 19);
            this.noBtn.TabIndex = 3;
            this.noBtn.TabStop = true;
            this.noBtn.Text = "לא";
            this.noBtn.UseVisualStyleBackColor = true;
            // 
            // questionGroupBox
            // 
            this.questionGroupBox.Controls.Add(this.noBtn);
            this.questionGroupBox.Controls.Add(this.yesBtn);
            this.questionGroupBox.Location = new System.Drawing.Point(241, 146);
            this.questionGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.questionGroupBox.Name = "questionGroupBox";
            this.questionGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.questionGroupBox.Size = new System.Drawing.Size(55, 55);
            this.questionGroupBox.TabIndex = 4;
            this.questionGroupBox.TabStop = false;
            // 
            // registerclickBtn
            // 
            this.registerclickBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerclickBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.registerclickBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.registerclickBtn.Image = global::MedicalPJ.Properties.Resources.bluebutton;
            this.registerclickBtn.Location = new System.Drawing.Point(182, 239);
            this.registerclickBtn.Margin = new System.Windows.Forms.Padding(2);
            this.registerclickBtn.Name = "registerclickBtn";
            this.registerclickBtn.Size = new System.Drawing.Size(155, 32);
            this.registerclickBtn.TabIndex = 11;
            this.registerclickBtn.Text = "לשאלה הבאה";
            this.registerclickBtn.UseCompatibleTextRendering = true;
            this.registerclickBtn.UseVisualStyleBackColor = true;
            this.registerclickBtn.Click += new System.EventHandler(this.registerclickBtn_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.registerclickBtn);
            this.Controls.Add(this.questionGroupBox);
            this.Controls.Add(this.questionLbl);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuestionForm";
            this.Text = "QuestionForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.questionGroupBox.ResumeLayout(false);
            this.questionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label questionLbl;
        private System.Windows.Forms.RadioButton yesBtn;
        private System.Windows.Forms.RadioButton noBtn;
        private System.Windows.Forms.GroupBox questionGroupBox;
        private System.Windows.Forms.Button registerclickBtn;
    }
}