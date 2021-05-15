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
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDocName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTool = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxWorker = new System.Windows.Forms.ComboBox();
            this.comboBoxPlace = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LoadInfoOper = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPlusOper = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDKODOPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNameOper = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNameObject = new System.Windows.Forms.TextBox();
            this.SaveNewProcess = new System.Windows.Forms.Button();
            this.panelCreateProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCreateProcess
            // 
            this.panelCreateProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelCreateProcess.Controls.Add(this.label8);
            this.panelCreateProcess.Controls.Add(this.comboBoxDocName);
            this.panelCreateProcess.Controls.Add(this.label7);
            this.panelCreateProcess.Controls.Add(this.comboBoxTool);
            this.panelCreateProcess.Controls.Add(this.label5);
            this.panelCreateProcess.Controls.Add(this.label6);
            this.panelCreateProcess.Controls.Add(this.comboBoxWorker);
            this.panelCreateProcess.Controls.Add(this.comboBoxPlace);
            this.panelCreateProcess.Controls.Add(this.label4);
            this.panelCreateProcess.Controls.Add(this.LoadInfoOper);
            this.panelCreateProcess.Controls.Add(this.label3);
            this.panelCreateProcess.Controls.Add(this.buttonPlusOper);
            this.panelCreateProcess.Controls.Add(this.dataGridView1);
            this.panelCreateProcess.Controls.Add(this.label2);
            this.panelCreateProcess.Controls.Add(this.comboBoxNameOper);
            this.panelCreateProcess.Controls.Add(this.label1);
            this.panelCreateProcess.Controls.Add(this.textBoxNameObject);
            this.panelCreateProcess.Controls.Add(this.SaveNewProcess);
            this.panelCreateProcess.Location = new System.Drawing.Point(3, 12);
            this.panelCreateProcess.Name = "panelCreateProcess";
            this.panelCreateProcess.Size = new System.Drawing.Size(1445, 749);
            this.panelCreateProcess.TabIndex = 0;
            this.panelCreateProcess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCreateProcess_MouseDown);
            this.panelCreateProcess.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCreateProcess_MouseMove);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(1368, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "X";
            this.label8.Click += new System.EventHandler(this.StopWork_Click);
            // 
            // comboBoxDocName
            // 
            this.comboBoxDocName.FormattingEnabled = true;
            this.comboBoxDocName.Location = new System.Drawing.Point(6, 369);
            this.comboBoxDocName.Name = "comboBoxDocName";
            this.comboBoxDocName.Size = new System.Drawing.Size(371, 24);
            this.comboBoxDocName.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(146, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = "Документ";
            // 
            // comboBoxTool
            // 
            this.comboBoxTool.FormattingEnabled = true;
            this.comboBoxTool.Location = new System.Drawing.Point(6, 315);
            this.comboBoxTool.Name = "comboBoxTool";
            this.comboBoxTool.Size = new System.Drawing.Size(371, 24);
            this.comboBoxTool.TabIndex = 18;
            this.comboBoxTool.SelectedIndexChanged += new System.EventHandler(this.ToolNameSelected);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(136, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "Инструмент";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(151, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Рабочий\r\n";
            // 
            // comboBoxWorker
            // 
            this.comboBoxWorker.FormattingEnabled = true;
            this.comboBoxWorker.Location = new System.Drawing.Point(6, 207);
            this.comboBoxWorker.Name = "comboBoxWorker";
            this.comboBoxWorker.Size = new System.Drawing.Size(371, 24);
            this.comboBoxWorker.TabIndex = 15;
            // 
            // comboBoxPlace
            // 
            this.comboBoxPlace.FormattingEnabled = true;
            this.comboBoxPlace.Location = new System.Drawing.Point(6, 261);
            this.comboBoxPlace.Name = "comboBoxPlace";
            this.comboBoxPlace.Size = new System.Drawing.Size(371, 24);
            this.comboBoxPlace.TabIndex = 14;
            this.comboBoxPlace.SelectedIndexChanged += new System.EventHandler(this.PlaceNameSelected);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(152, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Участок";
            // 
            // LoadInfoOper
            // 
            this.LoadInfoOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadInfoOper.Location = new System.Drawing.Point(6, 72);
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(494, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 36);
            this.label3.TabIndex = 11;
            this.label3.Text = "Создание тех. процесса";
            // 
            // buttonPlusOper
            // 
            this.buttonPlusOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlusOper.Location = new System.Drawing.Point(6, 401);
            this.buttonPlusOper.Name = "buttonPlusOper";
            this.buttonPlusOper.Size = new System.Drawing.Size(371, 51);
            this.buttonPlusOper.TabIndex = 9;
            this.buttonPlusOper.Text = "Добавить операцию";
            this.buttonPlusOper.UseVisualStyleBackColor = true;
            this.buttonPlusOper.Click += new System.EventHandler(this.buttonPlusOper_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDKODOPE,
            this.NameOp,
            this.Time,
            this.Worker,
            this.Tool,
            this.DocName,
            this.Hour,
            this.Delete});
            this.dataGridView1.Location = new System.Drawing.Point(395, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 525);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // IDKODOPE
            // 
            this.IDKODOPE.HeaderText = "Код операции";
            this.IDKODOPE.Name = "IDKODOPE";
            this.IDKODOPE.Width = 90;
            // 
            // NameOp
            // 
            this.NameOp.HeaderText = "Название операции";
            this.NameOp.Name = "NameOp";
            this.NameOp.Width = 150;
            // 
            // Time
            // 
            this.Time.HeaderText = "Участок";
            this.Time.Name = "Time";
            this.Time.Width = 150;
            // 
            // Worker
            // 
            this.Worker.HeaderText = "Рабочий";
            this.Worker.Name = "Worker";
            // 
            // Tool
            // 
            this.Tool.HeaderText = "Ресурс";
            this.Tool.Name = "Tool";
            // 
            // DocName
            // 
            this.DocName.HeaderText = "Документ";
            this.DocName.Name = "DocName";
            this.DocName.Width = 80;
            // 
            // Hour
            // 
            this.Hour.HeaderText = "Длительность(час)";
            this.Hour.Name = "Hour";
            this.Hour.Width = 145;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Удалить";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Удалить";
            this.Delete.ToolTipText = "Удалить";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(146, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Операция";
            // 
            // comboBoxNameOper
            // 
            this.comboBoxNameOper.FormattingEnabled = true;
            this.comboBoxNameOper.Location = new System.Drawing.Point(6, 153);
            this.comboBoxNameOper.Name = "comboBoxNameOper";
            this.comboBoxNameOper.Size = new System.Drawing.Size(371, 24);
            this.comboBoxNameOper.TabIndex = 5;
            this.comboBoxNameOper.SelectedIndexChanged += new System.EventHandler(this.OperNameSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(110, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название объекта";
            // 
            // textBoxNameObject
            // 
            this.textBoxNameObject.Location = new System.Drawing.Point(6, 491);
            this.textBoxNameObject.Multiline = true;
            this.textBoxNameObject.Name = "textBoxNameObject";
            this.textBoxNameObject.Size = new System.Drawing.Size(371, 34);
            this.textBoxNameObject.TabIndex = 3;
            // 
            // SaveNewProcess
            // 
            this.SaveNewProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveNewProcess.Location = new System.Drawing.Point(6, 546);
            this.SaveNewProcess.Name = "SaveNewProcess";
            this.SaveNewProcess.Size = new System.Drawing.Size(371, 51);
            this.SaveNewProcess.TabIndex = 2;
            this.SaveNewProcess.Text = "Сохранить результат";
            this.SaveNewProcess.UseVisualStyleBackColor = true;
            this.SaveNewProcess.Click += new System.EventHandler(this.SaveNewProcess_Click);
            // 
            // CreateProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 698);
            this.Controls.Add(this.panelCreateProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.TextBox textBoxNameObject;
        private System.Windows.Forms.Button SaveNewProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxNameOper;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPlusOper;
        private System.Windows.Forms.Button LoadInfoOper;
        private System.Windows.Forms.ComboBox comboBoxTool;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxWorker;
        private System.Windows.Forms.ComboBox comboBoxPlace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDocName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDKODOPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tool;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hour;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}