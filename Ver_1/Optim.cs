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
                    //получаем все данные длятех. процесса по данному объекту для формирование тех. паспорта
                    DataTable table = new DataTable();

                    //Получения кода инструмента и названия документа
                    MySqlCommand commandProcessInfo = new MySqlCommand("SELECT Number,idOperation,OperName,ToolName,WorkerName,Time FROM `mpmprocess` WHERE idProcess = @idProcess", db.getConnection());

                    //заглушка
                    commandProcessInfo.Parameters.Add("@idProcess", MySqlDbType.Int32).Value = Int32.Parse(tableProcessId.Rows[0][0].ToString());

                    //Выполнение запроса к бд
                    adapter.SelectCommand = commandProcessInfo;

                    adapter.Fill(table);

                                        
                    if (table.Rows.Count > 0)
                    {
                        //заполнение контрольной таблицы
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            for (int j = 1; j < PartValue+1; j++)
                            {
                                string kod = table.Rows[i][0].ToString() + "."+ j;
                                dataGridView1.Rows.Add(table.Rows[i][0].ToString(),kod, table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(),0,table.Rows[i][4].ToString(),0,table.Rows[i][5].ToString());

                            }

                        }

                        int a=0;

                        //поиск кода инструмента 
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            //таблица для хранения результата 
                            DataTable tableTool = new DataTable();

                            //Получения кода инструмента и названия документа
                            MySqlCommand commandTool = new MySqlCommand("SELECT idTool FROM `mpmtoolinfo` WHERE ToolName = @ToolName", db.getConnection());

                            //заглушка
                            commandTool.Parameters.Add("@ToolName", MySqlDbType.VarChar).Value = table.Rows[i][3].ToString();

                            //Выполнение запроса к бд
                            adapter.SelectCommand = commandTool;

                            adapter.Fill(tableTool);

                            for (int j = 0; j < PartValue; j++)
                            {
                                dataGridView1.Rows[a + j].Cells[5].Value = tableTool.Rows[0][0].ToString();

                            }
                            a = a + PartValue;
                            tableTool.Clear();
                        }

                        a = 0;
                        //поиск кода рабочего
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            //таблица для хранения результата 
                            DataTable tableWorker = new DataTable();

                            //Получения кода инструмента и названия документа
                            MySqlCommand commandWorker = new MySqlCommand("SELECT idWorker FROM `mpmworkerinfo` WHERE WorkerName = @Name", db.getConnection());

                            //заглушка
                            commandWorker.Parameters.Add("@Name", MySqlDbType.VarChar).Value = table.Rows[i][4].ToString();

                            //Выполнение запроса к бд
                            adapter.SelectCommand = commandWorker;

                            adapter.Fill(tableWorker);

                            for (int j = 0; j < PartValue; j++)
                            {
                                dataGridView1.Rows[a + j].Cells[7].Value = tableWorker.Rows[0][0].ToString();

                            }
                            a = a + PartValue;
                            tableWorker.Clear();

                        }

                        //назначение ресурсов
                        // dataGridView1.Rows[rows].Cells[1].Value.ToString();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            int kodtool=Int32.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());

                            //таблица для хранения результата 
                            DataTable tabletool = new DataTable();

                            
                            MySqlCommand commandToolFree = new MySqlCommand("SELECT* FROM `mpmresource` WHERE idtype=@kodtool ORDER BY `mpmresource`.`hour` ASC", db.getConnection());

                            //заглушка
                            commandToolFree.Parameters.Add("@kodtool", MySqlDbType.Int32).Value = kodtool;

                            //Выполнение запроса к бд
                            adapter.SelectCommand = commandToolFree;

                            adapter.Fill(tabletool);
                            int flag = 0;
                            //если в бд есть информация по данному объекту 
                            if (tabletool.Rows.Count > 0)
                            {
                                for (int j = 0; j < tabletool.Rows.Count; j++)
                                {
                                    if (tabletool.Rows[j][3].Equals("free") == true)
                                    {
                                        MySqlCommand commandResourceChangeInfo = new MySqlCommand("UPDATE `mpmresource` SET `status`=@b,`hour`=@hour WHERE `idResource`=@idR", db.getConnection());

                                        //заглушка
                                        commandResourceChangeInfo.Parameters.Add("@idR", MySqlDbType.Int32).Value = Int32.Parse(tabletool.Rows[j][0].ToString());

                                        commandResourceChangeInfo.Parameters.Add("@b", MySqlDbType.VarChar).Value ="busy";

                                        commandResourceChangeInfo.Parameters.Add("@hour", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());

                                        dataGridView1.Rows[i].Cells[11].Value = tabletool.Rows[j][0].ToString();
                                        flag = 1;
                                        db.OpenConnection();
                                        commandResourceChangeInfo.ExecuteNonQuery();
                                        db.CloseConnection();
                                        break;

                                    }

                                }

                                if (flag != 1)
                                {
                                    for (int j = 0; j < tabletool.Rows.Count; j++)
                                    {

                                        MySqlCommand commandResourceChangeInfo = new MySqlCommand("UPDATE `mpmresource` SET `hour`=@hour WHERE `idResource`=@idR", db.getConnection());

                                        //заглушка
                                        commandResourceChangeInfo.Parameters.Add("@idR", MySqlDbType.Int32).Value = Int32.Parse(tabletool.Rows[j][0].ToString());


                                        commandResourceChangeInfo.Parameters.Add("@hour", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()) + Int32.Parse(tabletool.Rows[j][4].ToString());

                                        dataGridView1.Rows[i].Cells[11].Value = tabletool.Rows[j][0].ToString();
                                        flag = 0;
                                        db.OpenConnection();
                                        commandResourceChangeInfo.ExecuteNonQuery();
                                        db.CloseConnection();
                                        break;

                                    }
                                }
                               
                            }




                        }













                    }


                }

            }



        }
    }
}
