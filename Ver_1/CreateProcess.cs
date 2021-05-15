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
                //Rows[0][0]-[строка][столбец]
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    //вывод названий операций в меню
                    string test = table.Rows[i][0].ToString();
                    comboBoxNameOper.Items.Add(test);
                }
            }
            else
            {
                MessageBox.Show("В базе данных нет информации");

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
            DataTable tablePlace = new DataTable();
            DataTable tableWorker = new DataTable();
            adapter.Fill(table);

            int idOperName = Int32.Parse(table.Rows[0][0].ToString());

            //выбор участка, на котором  может выполяется операция по коду операции          
            MySqlCommand commandPlace = new MySqlCommand("SELECT DISTINCT idPlace,idWorker FROM `mpmoperation` WHERE idOperation=@IdOp", db.getConnection());
            commandPlace.Parameters.Add("@IdOp", MySqlDbType.Int32).Value = idOperName;

            adapter.SelectCommand = commandPlace;

            adapter.Fill(tableInfo);
            if (tableInfo.Rows.Count == 0)
            {
                MessageBox.Show("Данных по выбранной операции нет в базе данных");
            }
            else
            {
                //рабочий на операцию не зависит от участка 
                int worker = Int32.Parse(tableInfo.Rows[0][1].ToString());

                //выбор участка, на котором  может выполяется операция по коду операции          
                MySqlCommand commandWorker = new MySqlCommand("SELECT* FROM `mpmworkerinfo` WHERE idWorker=@IdW", db.getConnection());
                commandWorker.Parameters.Add("@IdW", MySqlDbType.Int32).Value = worker;

                adapter.SelectCommand = commandWorker;

                adapter.Fill(tableWorker);
                if (tableInfo.Rows.Count == 0)
                {
                    MessageBox.Show("Данных по выбранному рабочему нет в базе данных");
                }

                else
                {
                    comboBoxWorker.Items.Clear();
                    //вывод названий операций в меню
                    string test = tableWorker.Rows[0][1].ToString();
                    comboBoxWorker.Items.Add(test);

                    comboBoxPlace.Items.Clear();

                    //массив для названия участка
                    string[] stringPlace = new string[tableInfo.Rows.Count];

                    for (int i = 0; i < tableInfo.Rows.Count; i++)
                    {
                        int idPlace = Int32.Parse(tableInfo.Rows[i][0].ToString());

                        MySqlCommand commandPlaceName = new MySqlCommand("SELECT idPlace,PlaceName FROM `mpmplaceinfo` WHERE idPlace=@IdPlace", db.getConnection());
                        commandPlaceName.Parameters.Add("@IdPlace", MySqlDbType.Int32).Value = idPlace;

                        adapter.SelectCommand = commandPlaceName;

                        adapter.Fill(tablePlace);

                        //вывод названий участка в меню
                        stringPlace[i] = tablePlace.Rows[i][1].ToString();
                        comboBoxPlace.Items.Add(stringPlace[i]);
                    }

                }             

            }
               
        }

    }
}
