namespace CS669GevandBalayanHomework2
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.pictInput = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictInput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(12, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 50);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Open Picture";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pictInput
            // 
            this.pictInput.Location = new System.Drawing.Point(12, 60);
            this.pictInput.Name = "pictInput";
            this.pictInput.Size = new System.Drawing.Size(579, 564);
            this.pictInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictInput.TabIndex = 1;
            this.pictInput.TabStop = false;
            this.pictInput.Click += new System.EventHandler(this.pictInput_Click);
            this.pictInput.Paint += new System.Windows.Forms.PaintEventHandler(this.pictInput_Paint);
            this.pictInput.MouseEnter += new System.EventHandler(this.pictInput_MouseEnter);
            this.pictInput.MouseLeave += new System.EventHandler(this.pictInput_MouseLeave);
            this.pictInput.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictInput_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 861);
            this.Controls.Add(this.pictInput);
            this.Controls.Add(this.btnUpload);
            this.Name = "Form1";
            this.Text = "Gevand Balayan -- Homework 2";
            ((System.ComponentModel.ISupportInitialize)(this.pictInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pictInput;
    }
}

