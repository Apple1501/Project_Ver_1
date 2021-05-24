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
    public partial class CheckZ : Form
    {
        public CheckZ()
        {
            InitializeComponent();
        }

        Point LastPoint;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DB db = new DB();

        DataTable table = new DataTable();
        DataTable tablenumber = new DataTable();
        string taskkod;



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //выход из приложения
            Application.Exit();
        }

        //возращение в меню
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu Menu = new Menu();
            Menu.Show();

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // код для перемещение главного меню
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            taskkod = textBoxTaskKod.Text;
            if (taskkod == "")
            {
                MessageBox.Show("Введите код задачи");
            }

            else
            {

                table.Clear();
                tablenumber.Clear();
                MySqlCommand commandNumber = new MySqlCommand("SELECT number FROM `mpmactivetask` WHERE idtask=@idtask", db.getConnection());

                //заглушка
                commandNumber.Parameters.Add("@idtask", MySqlDbType.Int32).Value = taskkod;

                //Выполнение запроса к бд
                adapter.SelectCommand = commandNumber;

                adapter.Fill(tablenumber);

                MySqlCommand commandInfo = new MySqlCommand("SELECT idnumber,idOper,OperName,idLWorker,surname,idLTool,type FROM `mpmtaskinfo` WHERE idtask=@idtask ORDER BY `mpmtaskinfo`.`idnumber` ASC", db.getConnection());

                //заглушка
                commandInfo.Parameters.Add("@idtask", MySqlDbType.Int32).Value = taskkod;

                //Выполнение запроса к бд
                adapter.SelectCommand = commandInfo;

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    //добавление данных по активной задаче
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(table.Rows[i][0].ToString(), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), table.Rows[i][4].ToString(), table.Rows[i][5].ToString(), table.Rows[i][6].ToString());
                    }

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (Equals(dataGridView1.Rows[i].Cells[6].Value.ToString(), "active") == true)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        if (Equals(dataGridView1.Rows[i].Cells[6].Value.ToString(), "completed") == true)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        }

                    }
                }

                else
                {
                    MessageBox.Show("Активных задач с таким кодом не найдено");
                }

            }



        }
        //обновление данных 
        private void button2_Click(object sender, EventArgs e)
        {
            string number = textBoxnumberOfOper.Text;
            string LwKod = textBoxLkodW.Text;

            if (number == "" && LwKod == "")
            {
                MessageBox.Show("Проверьте входные данные");
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if ((Equals(dataGridView1.Rows[i].Cells[3].Value.ToString(), LwKod) == true)&&(Equals(dataGridView1.Rows[i].Cells[0].Value.ToString(), number) == true)&& (Equals(dataGridView1.Rows[i].Cells[6].Value.ToString(), "active") == true))
                {
                    dataGridView1.Rows[i].Cells[6].Value = "completed";
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;

                    //обновлние инфы в базе данных

                    MySqlCommand commandCompleted = new MySqlCommand("UPDATE `mpmtaskinfo` SET `type`=@type WHERE idnumber=@number AND idLWorker=@LWKod AND idtask=@idtask", db.getConnection());

                    //заглушка
                    commandCompleted.Parameters.Add("@idtask", MySqlDbType.Int32).Value = Int32.Parse(taskkod);
                    commandCompleted.Parameters.Add("@LWKod", MySqlDbType.Int32).Value = LwKod;
                    commandCompleted.Parameters.Add("@number", MySqlDbType.VarChar).Value = number;
                    commandCompleted.Parameters.Add("@type", MySqlDbType.VarChar).Value = "completed";
                    
                    db.OpenConnection();
                    commandCompleted.ExecuteNonQuery();
                    db.CloseConnection();

                    int y = 0;

                    DataTable tablewor = new DataTable();
                    DataTable tabletool = new DataTable();

                    MySqlCommand commandwor = new MySqlCommand("SELECT idLWorker,type FROM `mpmtaskinfo` WHERE idLWorker=@idW", db.getConnection());

                    //заглушка
                    commandwor.Parameters.Add("@idW", MySqlDbType.Int32).Value = LwKod;

                    //Выполнение запроса к бд
                    adapter.SelectCommand = commandwor;
                    adapter.Fill(tablewor);

                    for (int b=0;b<tablewor.Rows.Count;b++)
                    {
                        //если ещё рабочий в данной задаче
                        if (Equals(table.Rows[b][1].ToString(), "completed") == true)
                        {
                            y++;
                        }
                    }
                    if (y == tablewor.Rows.Count)
                    {
                        MySqlCommand commandWorkerFree = new MySqlCommand("UPDATE `mpmresource` SET `status`=@free WHERE `idResource`=@idRes", db.getConnection());

                        //заглушка
                        commandWorkerFree.Parameters.Add("@idRes", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        commandWorkerFree.Parameters.Add("@free", MySqlDbType.VarChar).Value = "free";

                        db.OpenConnection();
                        commandWorkerFree.ExecuteNonQuery();
                        db.CloseConnection();

                    }

                    int d = 0;

                    MySqlCommand commandtool = new MySqlCommand("SELECT idLTool,type FROM `mpmtaskinfo` WHERE idLTool=@idT", db.getConnection());

                    //заглушка
                    commandtool.Parameters.Add("@idT", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                      
                    //Выполнение запроса к бд
                    adapter.SelectCommand = commandtool;
                    adapter.Fill(tabletool);

                    for (int b = 0; b < tabletool.Rows.Count; b++)
                    {
                        //если ещё рабочий в данной задаче
                        if (Equals(table.Rows[b][1].ToString(), "completed") == true)
                        {
                            d++;
                        }
                    }

                    if (d == tabletool.Rows.Count)
                    {
                        MySqlCommand commandToolFree = new MySqlCommand("UPDATE `mpmresource` SET `status`=@free WHERE `idResource`=@idRes", db.getConnection());

                        //заглушка
                        commandToolFree.Parameters.Add("@idRes", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        commandToolFree.Parameters.Add("@free", MySqlDbType.VarChar).Value = "free";

                        db.OpenConnection();
                        commandToolFree.ExecuteNonQuery();
                        db.CloseConnection();
                    }


                    if (i < table.Rows.Count && i + Int32.Parse(tablenumber.Rows[0][0].ToString())< table.Rows.Count)
                    {
                        dataGridView1.Rows[i+ Int32.Parse(tablenumber.Rows[0][0].ToString())].Cells[6].Value = "active";
                        dataGridView1.Rows[i+Int32.Parse(tablenumber.Rows[0][0].ToString())].DefaultCellStyle.BackColor = Color.Yellow;

                        MySqlCommand commandActive = new MySqlCommand("UPDATE `mpmtaskinfo` SET `type`=@type WHERE idnumber=@number AND idLWorker=@LWKod AND idtask=@idtask", db.getConnection());

                        //заглушка
                        commandActive.Parameters.Add("@idtask", MySqlDbType.Int32).Value = Int32.Parse(taskkod);
                        commandActive.Parameters.Add("@LWKod", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i + Int32.Parse(tablenumber.Rows[0][0].ToString())].Cells[3].Value.ToString());
                        commandActive.Parameters.Add("@number", MySqlDbType.VarChar).Value = dataGridView1.Rows[i + Int32.Parse(tablenumber.Rows[0][0].ToString())].Cells[0].Value.ToString();
                        commandActive.Parameters.Add("@type", MySqlDbType.VarChar).Value = "active";

                        db.OpenConnection();
                        commandActive.ExecuteNonQuery();
                        db.CloseConnection();

                         MessageBox.Show("Изменения внесены в базу данных");

                        break;
                    
                    }

                }
            }
            int k = 0;
            //удаление задачи, если все операции выполнены
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if (Equals(dataGridView1.Rows[j].Cells[6].Value.ToString(), "completed") == true)
                {
                    k++;
                }
            }
            if (k == dataGridView1.Rows.Count)
            {
                MySqlCommand commandDelete = new MySqlCommand("DELETE FROM `mpmtaskinfo` WHERE `idtask`=@idtask", db.getConnection());

                //заглушка
                commandDelete.Parameters.Add("@idtask", MySqlDbType.Int32).Value = Int32.Parse(taskkod);
                
                db.OpenConnection();
                commandDelete.ExecuteNonQuery();
                db.CloseConnection();

                MySqlCommand commandDeleteActive = new MySqlCommand("DELETE FROM `mpmactivetask` WHERE `idtask`=@idtask", db.getConnection());

                //заглушка
                commandDeleteActive.Parameters.Add("@idtask", MySqlDbType.Int32).Value = Int32.Parse(taskkod);

                db.OpenConnection();
                commandDeleteActive.ExecuteNonQuery();
                db.CloseConnection();

                MessageBox.Show("Задача выполнена. Данные удалены из базы данных");
            }



        }
    }
}
