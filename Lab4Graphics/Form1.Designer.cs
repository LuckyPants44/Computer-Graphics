namespace Lab4Graphics
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.CohenSutherland = new System.Windows.Forms.Button();
            this.textBoxLineX1 = new System.Windows.Forms.TextBox();
            this.textBoxLineX2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLineY2 = new System.Windows.Forms.TextBox();
            this.textBoxLineY1 = new System.Windows.Forms.TextBox();
            this.textBoxKSY2 = new System.Windows.Forms.TextBox();
            this.textBoxKSX2 = new System.Windows.Forms.TextBox();
            this.textBoxKSY1 = new System.Windows.Forms.TextBox();
            this.textBoxKSX1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CyrusBeck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.Location = new System.Drawing.Point(167, 9);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(913, 497);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // CohenSutherland
            // 
            this.CohenSutherland.Location = new System.Drawing.Point(12, 444);
            this.CohenSutherland.Name = "CohenSutherland";
            this.CohenSutherland.Size = new System.Drawing.Size(144, 62);
            this.CohenSutherland.TabIndex = 1;
            this.CohenSutherland.Text = "Алгоритм Коэна — Сазерленда";
            this.CohenSutherland.UseVisualStyleBackColor = true;
            this.CohenSutherland.Click += new System.EventHandler(this.CohenSutherland_Click);
            // 
            // textBoxLineX1
            // 
            this.textBoxLineX1.Location = new System.Drawing.Point(12, 29);
            this.textBoxLineX1.Name = "textBoxLineX1";
            this.textBoxLineX1.Size = new System.Drawing.Size(65, 22);
            this.textBoxLineX1.TabIndex = 2;
            this.textBoxLineX1.TextChanged += new System.EventHandler(this.textBoxLineX1_TextChanged);
            // 
            // textBoxLineX2
            // 
            this.textBoxLineX2.Location = new System.Drawing.Point(12, 57);
            this.textBoxLineX2.Name = "textBoxLineX2";
            this.textBoxLineX2.Size = new System.Drawing.Size(65, 22);
            this.textBoxLineX2.TabIndex = 3;
            this.textBoxLineX2.TextChanged += new System.EventHandler(this.textBoxLineX2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Координаты прямой:";
            // 
            // textBoxLineY2
            // 
            this.textBoxLineY2.Location = new System.Drawing.Point(88, 57);
            this.textBoxLineY2.Name = "textBoxLineY2";
            this.textBoxLineY2.Size = new System.Drawing.Size(65, 22);
            this.textBoxLineY2.TabIndex = 6;
            this.textBoxLineY2.TextChanged += new System.EventHandler(this.textBoxLineY2_TextChanged);
            // 
            // textBoxLineY1
            // 
            this.textBoxLineY1.Location = new System.Drawing.Point(88, 29);
            this.textBoxLineY1.Name = "textBoxLineY1";
            this.textBoxLineY1.Size = new System.Drawing.Size(65, 22);
            this.textBoxLineY1.TabIndex = 5;
            this.textBoxLineY1.TextChanged += new System.EventHandler(this.textBoxLineY1_TextChanged);
            // 
            // textBoxKSY2
            // 
            this.textBoxKSY2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxKSY2.Location = new System.Drawing.Point(88, 151);
            this.textBoxKSY2.Name = "textBoxKSY2";
            this.textBoxKSY2.Size = new System.Drawing.Size(65, 22);
            this.textBoxKSY2.TabIndex = 10;
            this.textBoxKSY2.Text = "y2";
            this.textBoxKSY2.TextChanged += new System.EventHandler(this.textBoxKSY2_TextChanged);
            this.textBoxKSY2.Enter += new System.EventHandler(this.textBoxKSY2_Enter);
            // 
            // textBoxKSX2
            // 
            this.textBoxKSX2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxKSX2.Location = new System.Drawing.Point(88, 123);
            this.textBoxKSX2.Name = "textBoxKSX2";
            this.textBoxKSX2.Size = new System.Drawing.Size(65, 22);
            this.textBoxKSX2.TabIndex = 9;
            this.textBoxKSX2.Text = "x2";
            this.textBoxKSX2.TextChanged += new System.EventHandler(this.textBoxKSX2_TextChanged);
            this.textBoxKSX2.Enter += new System.EventHandler(this.textBoxKSX2_Enter);
            // 
            // textBoxKSY1
            // 
            this.textBoxKSY1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxKSY1.Location = new System.Drawing.Point(12, 151);
            this.textBoxKSY1.Name = "textBoxKSY1";
            this.textBoxKSY1.Size = new System.Drawing.Size(65, 22);
            this.textBoxKSY1.TabIndex = 8;
            this.textBoxKSY1.Text = "y1";
            this.textBoxKSY1.TextChanged += new System.EventHandler(this.textBoxKSY1_TextChanged);
            this.textBoxKSY1.Enter += new System.EventHandler(this.textBoxKSY1_Enter);
            // 
            // textBoxKSX1
            // 
            this.textBoxKSX1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxKSX1.Location = new System.Drawing.Point(12, 123);
            this.textBoxKSX1.Name = "textBoxKSX1";
            this.textBoxKSX1.Size = new System.Drawing.Size(65, 22);
            this.textBoxKSX1.TabIndex = 7;
            this.textBoxKSX1.Text = "x1";
            this.textBoxKSX1.TextChanged += new System.EventHandler(this.textBoxKSX1_TextChanged);
            this.textBoxKSX1.Enter += new System.EventHandler(this.textBoxKSX1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Координаты экрана:";
            // 
            // CyrusBeck
            // 
            this.CyrusBeck.Location = new System.Drawing.Point(12, 376);
            this.CyrusBeck.Name = "CyrusBeck";
            this.CyrusBeck.Size = new System.Drawing.Size(144, 62);
            this.CyrusBeck.TabIndex = 12;
            this.CyrusBeck.Text = "Алгоритм Цируса-Бека:";
            this.CyrusBeck.UseVisualStyleBackColor = true;
            this.CyrusBeck.Click += new System.EventHandler(this.CyrusBeck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 518);
            this.Controls.Add(this.CyrusBeck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxKSY2);
            this.Controls.Add(this.textBoxKSX2);
            this.Controls.Add(this.textBoxKSY1);
            this.Controls.Add(this.textBoxKSX1);
            this.Controls.Add(this.textBoxLineY2);
            this.Controls.Add(this.textBoxLineY1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLineX2);
            this.Controls.Add(this.textBoxLineX1);
            this.Controls.Add(this.CohenSutherland);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button CohenSutherland;
        private System.Windows.Forms.TextBox textBoxLineX1;
        private System.Windows.Forms.TextBox textBoxLineX2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLineY2;
        private System.Windows.Forms.TextBox textBoxLineY1;
        private System.Windows.Forms.TextBox textBoxKSY2;
        private System.Windows.Forms.TextBox textBoxKSX2;
        private System.Windows.Forms.TextBox textBoxKSY1;
        private System.Windows.Forms.TextBox textBoxKSX1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CyrusBeck;
    }
}

