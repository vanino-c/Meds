namespace Meds
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPhar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonDrug = new System.Windows.Forms.Button();
            this.buttonAval = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPhar
            // 
            this.buttonPhar.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPhar.Location = new System.Drawing.Point(12, 167);
            this.buttonPhar.Name = "buttonPhar";
            this.buttonPhar.Size = new System.Drawing.Size(199, 48);
            this.buttonPhar.TabIndex = 0;
            this.buttonPhar.Text = "Аптеки";
            this.buttonPhar.UseVisualStyleBackColor = true;
            this.buttonPhar.Click += new System.EventHandler(this.buttonPhar_Click);
            // 
            // buttonDrug
            // 
            this.buttonDrug.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrug.Location = new System.Drawing.Point(12, 221);
            this.buttonDrug.Name = "buttonDrug";
            this.buttonDrug.Size = new System.Drawing.Size(199, 48);
            this.buttonDrug.TabIndex = 0;
            this.buttonDrug.Text = "Лекарства";
            this.buttonDrug.UseVisualStyleBackColor = true;
            this.buttonDrug.Click += new System.EventHandler(this.buttonDrug_Click);
            // 
            // buttonAval
            // 
            this.buttonAval.Font = new System.Drawing.Font("Calibri", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAval.Location = new System.Drawing.Point(12, 275);
            this.buttonAval.Name = "buttonAval";
            this.buttonAval.Size = new System.Drawing.Size(199, 48);
            this.buttonAval.TabIndex = 0;
            this.buttonAval.Text = "Наличие";
            this.buttonAval.UseVisualStyleBackColor = true;
            this.buttonAval.Click += new System.EventHandler(this.buttonAval_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Meds.Properties.Resources._119_1192900_pharmacy_icon_svg_png_icon_free_download_healthcare_innovation_icon_1_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 334);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAval);
            this.Controls.Add(this.buttonDrug);
            this.Controls.Add(this.buttonPhar);
            this.MaximumSize = new System.Drawing.Size(239, 373);
            this.MinimumSize = new System.Drawing.Size(239, 373);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "МедЛайф";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPhar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonDrug;
        private System.Windows.Forms.Button buttonAval;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

