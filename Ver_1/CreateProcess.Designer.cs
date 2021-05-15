namespace Ver_1
{
    partial class CreateProcess
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
            this.panelCreateProcess = new System.Windows.Forms.Panel();
            this.comboBoxTool = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxWorker = new System.Windows.Forms.ComboBox();
            this.comboBoxPlace = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LoadInfoOper = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDKODOPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNameOper = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SaveNewProcess = new System.Windows.Forms.Button();
            this.panelCreateProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCreateProcess
            // 
            this.panelCreateProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelCreateProcess.Controls.Add(this.comboBoxTool);
            this.panelCreateProcess.Controls.Add(this.label5);
            this.panelCreateProcess.Controls.Add(this.label6);
            this.panelCreateProcess.Controls.Add(this.comboBoxWorker);
            this.panelCreateProcess.Controls.Add(this.comboBoxPlace);
            this.panelCreateProcess.Controls.Add(this.label4);
            this.panelCreateProcess.Controls.Add(this.LoadInfoOper);
            this.panelCreateProcess.Controls.Add(this.label3);
            this.panelCreateProcess.Controls.Add(this.button4);
            this.panelCreateProcess.Controls.Add(this.dataGridView1);
            this.panelCreateProcess.Controls.Add(this.label2);
            this.panelCreateProcess.Controls.Add(this.comboBoxNameOper);
            this.panelCreateProcess.Controls.Add(this.label1);
            this.panelCreateProcess.Controls.Add(this.textBox1);
            this.panelCreateProcess.Controls.Add(this.SaveNewProcess);
            this.panelCreateProcess.Location = new System.Drawing.Point(0, -2);
            this.panelCreateProcess.Name = "panelCreateProcess";
            this.panelCreateProcess.Size = new System.Drawing.Size(1239, 763);
            this.panelCreateProcess.TabIndex = 0;
            // 
            // comboBoxTool
            // 
            this.comboBoxTool.FormattingEnabled = true;
            this.comboBoxTool.Location = new System.Drawing.Point(3, 278);
            this.comboBoxTool.Name = "comboBoxTool";
            this.comboBoxTool.Size = new System.Drawing.Size(371, 24);
            this.comboBoxTool.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(133, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "Инструмент";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(148, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Рабочий\r\n";
            // 
            // comboBoxWorker
            // 
            this.comboBoxWorker.FormattingEnabled = true;
            this.comboBoxWorker.Location = new System.Drawing.Point(3, 224);
            this.comboBoxWorker.Name = "comboBoxWorker";
            this.comboBoxWorker.Size = new System.Drawing.Size(371, 24);
            this.comboBoxWorker.TabIndex = 15;
            // 
            // comboBoxPlace
            // 
            this.comboBoxPlace.FormattingEnabled = true;
            this.comboBoxPlace.Location = new System.Drawing.Point(3, 170);
            this.comboBoxPlace.Name = "comboBoxPlace";
            this.comboBoxPlace.Size = new System.Drawing.Size(371, 24);
            this.comboBoxPlace.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(152, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Участок";
            // 
            // LoadInfoOper
            // 
            this.LoadInfoOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadInfoOper.Location = new System.Drawing.Point(3, 35);
            this.LoadInfoOper.Name = "LoadInfoOper";
            this.LoadInfoOper.Size = new System.Drawing.Size(371, 51);
            this.LoadInfoOper.TabIndex = 12;
            this.LoadInfoOper.Text = "Загрузить данные об операциях";
            this.LoadInfoOper.UseVisualStyleBackColor = true;
            this.LoadInfoOper.Click += new System.EventHandler(this.LoadInfoOper_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(491, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Создание тех. процесса";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(3, 322);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(371, 51);
            this.button4.TabIndex = 9;
            this.button4.Text = "Добавить операцию";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nomer,
            this.IDKODOPE,
            this.NameOp,
            this.Time});
            this.dataGridView1.Location = new System.Drawing.Point(401, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(808, 525);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nomer
            // 
            this.Nomer.HeaderText = "№";
            this.Nomer.Name = "Nomer";
            // 
            // IDKODOPE
            // 
            this.IDKODOPE.HeaderText = "Код операции";
            this.IDKODOPE.Name = "IDKODOPE";
            // 
            // NameOp
            // 
            this.NameOp.HeaderText = "Название операции";
            this.NameOp.Name = "NameOp";
            // 
            // Time
            // 
            this.Time.HeaderText = "Длительность ";
            this.Time.Name = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(143, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Операция";
            // 
            // comboBoxNameOper
            // 
            this.comboBoxNameOper.FormattingEnabled = true;
            this.comboBoxNameOper.Location = new System.Drawing.Point(3, 116);
            this.comboBoxNameOper.Name = "comboBoxNameOper";
            this.comboBoxNameOper.Size = new System.Drawing.Size(371, 24);
            this.comboBoxNameOper.TabIndex = 5;
            this.comboBoxNameOper.SelectedIndexChanged += new System.EventHandler(this.OperNameSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(107, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название объекта";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 470);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(371, 22);
            this.textBox1.TabIndex = 3;
            // 
            // SaveNewProcess
            // 
            this.SaveNewProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveNewProcess.Location = new System.Drawing.Point(3, 509);
            this.SaveNewProcess.Name = "SaveNewProcess";
            this.SaveNewProcess.Size = new System.Drawing.Size(371, 51);
            this.SaveNewProcess.TabIndex = 2;
            this.SaveNewProcess.Text = "Сохранить результат";
            this.SaveNewProcess.UseVisualStyleBackColor = true;
            // 
            // CreateProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 761);
            this.Controls.Add(this.panelCreateProcess);
            this.Name = "CreateProcess";
            this.Text = "CreateProcess";
            this.panelCreateProcess.ResumeLayout(false);
            this.panelCreateProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCreateProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SaveNewProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxNameOper;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDKODOPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.Button LoadInfoOper;
        private System.Windows.Forms.ComboBox comboBoxTool;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxWorker;
        private System.Windows.Forms.ComboBox comboBoxPlace;
        private System.Windows.Forms.Label label4;
    }
}