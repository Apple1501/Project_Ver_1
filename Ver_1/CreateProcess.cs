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
    public partial class CreateProcess : Form
    {
        public CreateProcess()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        //Загружаем данные об операция из базы данных
        private void LoadInfoOper_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //формируем запрос к базе данных
            MySqlCommand command = new MySqlCommand("SELECT OperName,WorkerName,ToolName FROM `mpmoperation`",db.getConnection());

            //указываем какой именно запрос будет выполняться к базе данных
            adapter.SelectCommand = command;

            //заполняем таблицу данными, которые были загружены из бд
            adapter.Fill(table);

            //проверка, что в базе данных есть информация
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Данные из базы данных загружены");
            }
            else
            {
                MessageBox.Show("В базе данных нет информации");
            }
            int a = table.Rows.Count;



        }
    }
}
