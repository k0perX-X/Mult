namespace Mult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.FPS = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFPS = new System.Windows.Forms.Label();
            this.numeriсM = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericB = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericSootn = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeriсM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSootn)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(215, 29);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Запустить мультик ";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кадров в секунду";
            // 
            // numeric
            // 
            this.numeric.Location = new System.Drawing.Point(138, 82);
            this.numeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric.Name = "numeric";
            this.numeric.Size = new System.Drawing.Size(89, 22);
            this.numeric.TabIndex = 4;
            this.numeric.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 282);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(215, 28);
            this.progressBar.TabIndex = 5;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(12, 47);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(215, 29);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Остоновить мультик ";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 110);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(190, 21);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Бесконечная анимация ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FPS
            // 
            this.FPS.AutoSize = true;
            this.FPS.Checked = true;
            this.FPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FPS.Location = new System.Drawing.Point(12, 137);
            this.FPS.Name = "FPS";
            this.FPS.Size = new System.Drawing.Size(147, 21);
            this.FPS.TabIndex = 7;
            this.FPS.Text = "Отслеживать FPS";
            this.FPS.UseVisualStyleBackColor = true;
            this.FPS.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Фактический FPS:";
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Location = new System.Drawing.Point(145, 161);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(28, 17);
            this.labelFPS.TabIndex = 9;
            this.labelFPS.Text = "0.0";
            // 
            // numeriсM
            // 
            this.numeriсM.Location = new System.Drawing.Point(144, 181);
            this.numeriсM.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numeriсM.Name = "numeriсM";
            this.numeriсM.Size = new System.Drawing.Size(84, 22);
            this.numeriсM.TabIndex = 10;
            this.numeriсM.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Кол-во маленьких";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Кол-во больших";
            // 
            // numericB
            // 
            this.numericB.Location = new System.Drawing.Point(144, 209);
            this.numericB.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericB.Name = "numericB";
            this.numericB.Size = new System.Drawing.Size(84, 22);
            this.numericB.TabIndex = 12;
            this.numericB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Соотношение масс и радиусов ";
            // 
            // numericSootn
            // 
            this.numericSootn.Location = new System.Drawing.Point(12, 254);
            this.numericSootn.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericSootn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSootn.Name = "numericSootn";
            this.numericSootn.Size = new System.Drawing.Size(216, 22);
            this.numericSootn.TabIndex = 15;
            this.numericSootn.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 322);
            this.Controls.Add(this.numericSootn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numeriсM);
            this.Controls.Add(this.labelFPS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FPS);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Mult.Properties.Settings.Default, "Loc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::Mult.Properties.Settings.Default.Loc;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Мультик";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeriсM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSootn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numeric;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox FPS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.NumericUpDown numeriсM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericSootn;
    }
}

