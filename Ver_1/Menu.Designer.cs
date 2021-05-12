namespace Ver_1
{
    partial class Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckWork = new System.Windows.Forms.Button();
            this.Work = new System.Windows.Forms.Button();
            this.CreateNewProcess = new System.Windows.Forms.Button();
            this.StopWork = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(193)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.CheckWork);
            this.panel1.Controls.Add(this.Work);
            this.panel1.Controls.Add(this.CreateNewProcess);
            this.panel1.Controls.Add(this.StopWork);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 309);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // CheckWork
            // 
            this.CheckWork.BackColor = System.Drawing.Color.White;
            this.CheckWork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckWork.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.CheckWork.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.CheckWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckWork.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.CheckWork.Location = new System.Drawing.Point(59, 213);
            this.CheckWork.Name = "CheckWork";
            this.CheckWork.Size = new System.Drawing.Size(260, 54);
            this.CheckWork.TabIndex = 3;
            this.CheckWork.Text = "Активные заказы";
            this.CheckWork.UseVisualStyleBackColor = false;
            // 
            // Work
            // 
            this.Work.BackColor = System.Drawing.Color.White;
            this.Work.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Work.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.Work.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.Work.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Work.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Work.Location = new System.Drawing.Point(59, 127);
            this.Work.Name = "Work";
            this.Work.Size = new System.Drawing.Size(260, 54);
            this.Work.TabIndex = 2;
            this.Work.Text = "Оптимизация процессов";
            this.Work.UseVisualStyleBackColor = false;
            // 
            // CreateNewProcess
            // 
            this.CreateNewProcess.BackColor = System.Drawing.Color.White;
            this.CreateNewProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateNewProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.CreateNewProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(26)))), ((int)(((byte)(255)))));
            this.CreateNewProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateNewProcess.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewProcess.Location = new System.Drawing.Point(59, 35);
            this.CreateNewProcess.Name = "CreateNewProcess";
            this.CreateNewProcess.Size = new System.Drawing.Size(260, 54);
            this.CreateNewProcess.TabIndex = 1;
            this.CreateNewProcess.Text = "Создать тех.процесс";
            this.CreateNewProcess.UseVisualStyleBackColor = false;
            this.CreateNewProcess.Click += new System.EventHandler(this.CreateNewProcess_Click);
            // 
            // StopWork
            // 
            this.StopWork.AutoSize = true;
            this.StopWork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopWork.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.StopWork.Location = new System.Drawing.Point(345, 0);
            this.StopWork.Name = "StopWork";
            this.StopWork.Size = new System.Drawing.Size(25, 24);
            this.StopWork.TabIndex = 0;
            this.StopWork.Text = "X";
            this.StopWork.Click += new System.EventHandler(this.StopWork_Click);
            this.StopWork.MouseEnter += new System.EventHandler(this.StopWork_MouseEnter);
            this.StopWork.MouseLeave += new System.EventHandler(this.StopWork_MouseLeave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(807, 487);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 309);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label StopWork;
        private System.Windows.Forms.Button CheckWork;
        private System.Windows.Forms.Button Work;
        private System.Windows.Forms.Button CreateNewProcess;
    }
}