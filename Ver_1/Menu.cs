using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ver_1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.CreateNewProcess.AutoSize = true;
            this.Work.AutoSize = true;
            this.CheckWork.AutoSize = true;

        }

        private void StopWork_Click(object sender, EventArgs e)
        {
            //закрытие программы
            Application.Exit();
        }

        private void StopWork_MouseEnter(object sender, EventArgs e)
        {
            StopWork.ForeColor = Color.Black;
        }

        private void StopWork_MouseLeave(object sender, EventArgs e)
        {
            StopWork.ForeColor = Color.White;
        }
        Point LastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            //код для перемещение главного меню 
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }
                private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void CreateNewProcess_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateProcess CreateProcess = new CreateProcess();
            CreateProcess.Show();

        }

        private void Work_Click(object sender, EventArgs e)
        {
            this.Hide();
            Optim Optim = new Optim();
            Optim.Show();
        }

        private void CheckWork_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckZ checkZ = new CheckZ();
            checkZ.Show();
        }
    }
}
