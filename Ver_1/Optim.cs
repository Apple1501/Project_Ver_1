using MySql.Data.MySqlClient;
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
    public partial class Optim : Form
    {
        public Optim()
        {
            InitializeComponent();
        }


        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DB db = new DB();

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu Menu = new Menu();
            Menu.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        Point LastPoint;
        //двигать поле по экрану
        private void panelOpti_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);

        }

        private void panelOpti_MouseMove(object sender, MouseEventArgs e)
        {
            // код для перемещение главного меню
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }

        }

        //оптимизация процесса. Создание плана на заказ 
        private void button3_Click(object sender, EventArgs e)
        {

            string NameProject = textBoxNameObject.Text;
            int PartValue = 0;
            PartValue = Int32.Parse(textBoxValuePart.Text);

            if (NameProject == "" && PartValue == 0)
            {
                MessageBox.Show("Проверьте входные данные объекта");

            }

            else
            {
                //поиск объекта в базе данных по продуктам. Получаем тех. процесс для объекта 
                DataTable tableProcessId = new DataTable();

                //Получения кода инструмента и названия документа
                MySqlCommand commandProcessid = new MySqlCommand("SELECT idProcess FROM `mpmproduct` WHERE ProductName = @ProcessName", db.getConnection());

                //заглушка
                commandProcessid.Parameters.Add("@ProcessName", MySqlDbType.VarChar).Value = NameProject;
                

                //Выполнение запроса к бд
                adapter.SelectCommand = commandProcessid;

                adapter.Fill(tableProcessId);

                if (tableProcessId.Rows.Count > 0)
                {
                    MessageBox.Show("Код получен");

                }




            }



        }
    }
}
