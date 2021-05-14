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
        DB db = new DB();
               
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        //Загружаем данные об операция из базы данных
        private void LoadInfoOper_Click(object sender, EventArgs e)
        {
            //формируем запрос к базе данных
            MySqlCommand command = new MySqlCommand("SELECT OperName FROM `mpmopername`", db.getConnection());
            //MySqlCommand command = new MySqlCommand("SELECT idOperation,idPlace,idWorker,idTool,DocName FROM `mpmoperation`",db.getConnection());

            DataTable table = new DataTable();
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

            //Rows[0][0]-[строка][столбец]
            for (int i=0;i< table.Rows.Count;i++)
            {
                //вывод названий операций в меню
                string test = table.Rows[i][0].ToString();
                comboBoxNameOper.Items.Add(test);
            }

        }

        private void OperNameSelected(object sender, EventArgs e)
        {
            string selectedOperName = comboBoxNameOper.SelectedItem.ToString();
            //формируем запрос по выбранному пункту в бд
            MySqlCommand command = new MySqlCommand("SELECT idOperation FROM `mpmopername` WHERE OperName=@SOperName", db.getConnection());
            //заглушка
            command.Parameters.Add("@SOperName", MySqlDbType.VarChar).Value = selectedOperName;

            //Выполнение запроса к бд
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            DataTable tableInfo = new DataTable();
            adapter.Fill(table);

            int idOperName = Int32.Parse(table.Rows[0][0].ToString());

            //выбор участка, на котором выполяется операция           
            MySqlCommand commandInfo = new MySqlCommand("SELECT DISTINCT idPlace FROM `mpmoperation` WHERE idOperation=@IdOp", db.getConnection());
            commandInfo.Parameters.Add("@IdOp", MySqlDbType.Int32).Value = idOperName;

            adapter.SelectCommand = commandInfo;
           
            adapter.Fill(tableInfo);
            if (tableInfo.Rows.Count < 0)
            {
                MessageBox.Show("Данных по выбранной операции нет в базе данных");
            }

            string[] stringPlace = new string[6];

        }

    }
}
