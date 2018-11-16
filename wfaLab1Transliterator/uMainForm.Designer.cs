namespace nsLexMainForm
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
            this.btnFStart = new System.Windows.Forms.Button();
            this.tbFSource = new System.Windows.Forms.TextBox();
            this.lblFSource = new System.Windows.Forms.Label();
            this.symbols = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numbers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.reserved = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFStart
            // 
            this.btnFStart.Location = new System.Drawing.Point(197, 189);
            this.btnFStart.Name = "btnFStart";
            this.btnFStart.Size = new System.Drawing.Size(75, 23);
            this.btnFStart.TabIndex = 0;
            this.btnFStart.Text = "Пуск";
            this.btnFStart.UseVisualStyleBackColor = true;
            this.btnFStart.Click += new System.EventHandler(this.btnFStart_Click);
            // 
            // tbFSource
            // 
            this.tbFSource.AcceptsReturn = true;
            this.tbFSource.AcceptsTab = true;
            this.tbFSource.Location = new System.Drawing.Point(12, 23);
            this.tbFSource.Multiline = true;
            this.tbFSource.Name = "tbFSource";
            this.tbFSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbFSource.Size = new System.Drawing.Size(456, 146);
            this.tbFSource.TabIndex = 1;
            // 
            // lblFSource
            // 
            this.lblFSource.AutoSize = true;
            this.lblFSource.Location = new System.Drawing.Point(20, 10);
            this.lblFSource.Name = "lblFSource";
            this.lblFSource.Size = new System.Drawing.Size(89, 13);
            this.lblFSource.TabIndex = 3;
            this.lblFSource.Text = "Исходный текст";
            // 
            // symbols
            // 
            this.symbols.AcceptsReturn = true;
            this.symbols.AcceptsTab = true;
            this.symbols.Location = new System.Drawing.Point(23, 239);
            this.symbols.Multiline = true;
            this.symbols.Name = "symbols";
            this.symbols.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.symbols.Size = new System.Drawing.Size(213, 149);
            this.symbols.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Символы";
            // 
            // numbers
            // 
            this.numbers.AcceptsReturn = true;
            this.numbers.AcceptsTab = true;
            this.numbers.Location = new System.Drawing.Point(270, 239);
            this.numbers.Multiline = true;
            this.numbers.Name = "numbers";
            this.numbers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.numbers.Size = new System.Drawing.Size(213, 149);
            this.numbers.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Цифры";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "РезервдСимболс";
            // 
            // reserved
            // 
            this.reserved.AcceptsReturn = true;
            this.reserved.AcceptsTab = true;
            this.reserved.Location = new System.Drawing.Point(514, 239);
            this.reserved.Multiline = true;
            this.reserved.Name = "reserved";
            this.reserved.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reserved.Size = new System.Drawing.Size(213, 149);
            this.reserved.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 416);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reserved);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numbers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.symbols);
            this.Controls.Add(this.lblFSource);
            this.Controls.Add(this.tbFSource);
            this.Controls.Add(this.btnFStart);
            this.Name = "Form1";
            this.Text = "Отладка транслитератора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFStart;
        private System.Windows.Forms.TextBox tbFSource;
        private System.Windows.Forms.Label lblFSource;
        private System.Windows.Forms.TextBox symbols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reserved;
    }
}

