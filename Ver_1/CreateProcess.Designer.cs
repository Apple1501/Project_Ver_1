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
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Nomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDKODOPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCreateProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCreateProcess
            // 
            this.panelCreateProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelCreateProcess.Controls.Add(this.label3);
            this.panelCreateProcess.Controls.Add(this.button5);
            this.panelCreateProcess.Controls.Add(this.button4);
            this.panelCreateProcess.Controls.Add(this.dataGridView1);
            this.panelCreateProcess.Controls.Add(this.button3);
            this.panelCreateProcess.Controls.Add(this.label2);
            this.panelCreateProcess.Controls.Add(this.comboBox1);
            this.panelCreateProcess.Controls.Add(this.label1);
            this.panelCreateProcess.Controls.Add(this.textBox1);
            this.panelCreateProcess.Controls.Add(this.button2);
            this.panelCreateProcess.Controls.Add(this.button1);
            this.panelCreateProcess.Controls.Add(this.listView1);
            this.panelCreateProcess.Location = new System.Drawing.Point(0, 1);
            this.panelCreateProcess.Name = "panelCreateProcess";
            this.panelCreateProcess.Size = new System.Drawing.Size(1242, 765);
            this.panelCreateProcess.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(867, 230);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(360, 379);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(867, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(360, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "Создать тех.процесс";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(867, 697);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(360, 51);
            this.button2.TabIndex = 2;
            this.button2.Text = "Сохранить результат";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(867, 658);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(965, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название объекта";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(867, 110);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(360, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(951, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Название операций";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(867, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(360, 51);
            this.button3.TabIndex = 7;
            this.button3.Text = "Посмотреть данные об операции";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nomer,
            this.IDKODOPE,
            this.NameOp,
            this.Time});
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(838, 639);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(12, 697);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(360, 51);
            this.button4.TabIndex = 9;
            this.button4.Text = "Добавить операцию";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(490, 697);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(360, 51);
            this.button5.TabIndex = 10;
            this.button5.Text = "Удалить операцию";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(311, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Создание тех. процесса";
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDKODOPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
    }
}