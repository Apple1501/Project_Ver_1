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
        //код выбранной операции
        DataTable table = new DataTable();
        //код и название инструмента по выбранной операции и участку 
        DataTable tableToolName = new DataTable();


        DataTable tablePlaceid = new DataTable();

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

        //выбор операции и получения данных по выбранной операции
        private void OperNameSelected(object sender, EventArgs e)
        {
            string selectedOperName = comboBoxNameOper.SelectedItem.ToString();
            //формируем запрос по выбранному пункту в бд
            MySqlCommand command = new MySqlCommand("SELECT idOperation FROM `mpmopername` WHERE OperName=@SOperName", db.getConnection());
            //заглушка
            command.Parameters.Add("@SOperName", MySqlDbType.VarChar).Value = selectedOperName;

            //Выполнение запроса к бд
            adapter.SelectCommand = command;

            //чистка информации о коде операции
            table.Clear();

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

                    int a = 0;

                }             

            }
               
        }

        //вывод информацию об инструментах на основе выбора участка
        private void PlaceNameSelected(object sender, EventArgs e)
        {
            string selectedPlaceName = comboBoxPlace.SelectedItem.ToString();
            //формируем запрос по выбранному пункту в бд
            MySqlCommand commandPlaceName = new MySqlCommand("SELECT idPlace,PlaceName FROM `mpmplaceinfo` WHERE PlaceName=@SPlaceName", db.getConnection());
            //заглушка
            commandPlaceName.Parameters.Add("@SPlaceName", MySqlDbType.VarChar).Value = selectedPlaceName;

            //Выполнение запроса к бд
            adapter.SelectCommand = commandPlaceName;

            tablePlaceid.Clear();

            DataTable tableToolid = new DataTable();

            tableToolName.Clear();
       
            adapter.Fill(tablePlaceid);

            //код выбранного участка
            int Placeid = Int32.Parse(tablePlaceid.Rows[0][0].ToString());

            //код выбранной операции 
            int idOper = Int32.Parse(table.Rows[0][0].ToString());

            //Получения кода инструмента и названия документа
            MySqlCommand commandidTool = new MySqlCommand("SELECT DISTINCT idTool FROM `mpmoperation` WHERE idPlace=@Placeid AND idOperation=@idOper", db.getConnection());
          
            //заглушка
            commandidTool.Parameters.Add("@Placeid", MySqlDbType.Int32).Value = Placeid;
            commandidTool.Parameters.Add("@idOper", MySqlDbType.Int32).Value = idOper;

            //Выполнение запроса к бд
            adapter.SelectCommand = commandidTool;

            
            adapter.Fill(tableToolid);

            if (tableToolid.Rows.Count == 0)
            {
                MessageBox.Show("Данных по выбранному участку не найдены");
            }
            else
            {

                comboBoxTool.Items.Clear();
               // comboBoxTool.Items[0].Remove();
                //получения названия инструмента
                for (int i = 0; i < tableToolid.Rows.Count; i++)
                {
                    //код инструмента
                    int idTool = Int32.Parse(tableToolid.Rows[i][0].ToString());

                    //Получения кода инструмента и названия документа
                    MySqlCommand commandToolName = new MySqlCommand("SELECT * FROM `mpmtoolinfo` WHERE idTool=@idTool", db.getConnection());

                    //заглушка
                    commandToolName.Parameters.Add("@idTool", MySqlDbType.Int32).Value = idTool;

                    //Выполнение запроса к бд
                    adapter.SelectCommand = commandToolName;

                    adapter.Fill(tableToolName);

                    if (tableToolName.Rows.Count == 0)
                    {
                        MessageBox.Show("Данные по инструменту не найдены");
                    }

                    else
                    {
                        comboBoxTool.Items.Add(tableToolName.Rows[i][1].ToString());
                    }

                }

            }

        }

        //выбор документа по ранее выбранным данным
        private void ToolNameSelected(object sender, EventArgs e)
        {
            //считываем название инструмента 
            string selectedToolName = comboBoxTool.SelectedItem.ToString();
            int idTool=0;
            for (int i = 0; i < tableToolName.Rows.Count; i++)
            {
                if (Equals(tableToolName.Rows[i][1].ToString(), selectedToolName) == true)
                {
                    idTool = Int32.Parse(tableToolName.Rows[i][0].ToString());
                }

            }

            if (idTool == 0)
            {
                MessageBox.Show("Данные по документу не найдены");

            }

            else
            {
                comboBoxDocName.Items.Clear();

                DataTable tableDocName = new DataTable();

                //Получения кода инструмента и названия документа
                MySqlCommand commandDocName = new MySqlCommand("SELECT DocName FROM `mpmoperation` WHERE idOperation = @idOper AND idPlace = @idPlace AND idTool=@idT", db.getConnection());

                //заглушка
                commandDocName.Parameters.Add("@idOper", MySqlDbType.Int32).Value = Int32.Parse(table.Rows[0][0].ToString());
                commandDocName.Parameters.Add("@idPlace", MySqlDbType.Int32).Value = Int32.Parse(tablePlaceid.Rows[0][0].ToString());
                commandDocName.Parameters.Add("@idT", MySqlDbType.Int32).Value = idTool;

                //Выполнение запроса к бд
                adapter.SelectCommand = commandDocName;

                adapter.Fill(tableDocName);

                if (tableDocName.Rows.Count == 0)
                {
                    MessageBox.Show("Данные по документу не найдены");

                }
                else
                {
                    comboBoxDocName.Items.Add(tableDocName.Rows[0][0].ToString());
                }
            }
           




        }
    }
}
