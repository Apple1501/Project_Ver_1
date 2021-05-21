using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        //код активной задачи 
        DataTable tablekod = new DataTable();

        //время выполнения заказа 
        float SumTime = 0;
        
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

                //Получения кода процесса для выбранного объекта
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
                                    //сначала назначаем свободные ресурсы 
                                    if (tabletool.Rows[j][3].Equals("free") == true)
                                    {
                                        MySqlCommand commandResourceChangeInfo = new MySqlCommand("UPDATE `mpmresource` SET `status`=@b,`hour`=@hour WHERE `idResource`=@idR", db.getConnection());

                                        //заглушка
                                        commandResourceChangeInfo.Parameters.Add("@idR", MySqlDbType.Int32).Value = Int32.Parse(tabletool.Rows[j][0].ToString());

                                        commandResourceChangeInfo.Parameters.Add("@b", MySqlDbType.VarChar).Value ="busy";

                                        commandResourceChangeInfo.Parameters.Add("@hour", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()) + Int32.Parse(tabletool.Rows[j][4].ToString());

                                        dataGridView1.Rows[i].Cells[11].Value = tabletool.Rows[j][0].ToString();
                                        flag = 1;
                                        db.OpenConnection();
                                        commandResourceChangeInfo.ExecuteNonQuery();
                                        db.CloseConnection();
                                        break;

                                    }

                                }

                                //теперь ресурсы, которые обладают наименьшим количеством часов работы
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


                        //назначение рабочего на задачу  
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            //считывание кода рабочего 
                            int kodworker = Int32.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());

                            //таблица для хранения результата 
                            DataTable tableworker = new DataTable();

                            MySqlCommand commandWorkerFree = new MySqlCommand("SELECT* FROM `mpmresource` WHERE idtype=@kodworker ORDER BY `mpmresource`.`hour` ASC", db.getConnection());

                            //заглушка
                            commandWorkerFree.Parameters.Add("@kodworker", MySqlDbType.Int32).Value = kodworker;

                            //Выполнение запроса к бд
                            adapter.SelectCommand = commandWorkerFree;

                            //рабочие, выбранные по данному профилю
                            adapter.Fill(tableworker);

                            int flag = 0;

                            //если в бд есть информация 
                            if (tableworker.Rows.Count > 0)
                            {
                                for (int j = 0; j < tableworker.Rows.Count; j++)
                                {
                                    if (tableworker.Rows[j][3].Equals("free") == true)
                                    {
                                        MySqlCommand commandResourceChangeInfo = new MySqlCommand("UPDATE `mpmresource` SET `status`=@b,`hour`=@hour WHERE `idResource`=@idR", db.getConnection());

                                        //заглушка. Обновление данных. По личному коду ресурса
                                        commandResourceChangeInfo.Parameters.Add("@idR", MySqlDbType.Int32).Value = Int32.Parse(tableworker.Rows[j][0].ToString());
                                        //замена статуса
                                        commandResourceChangeInfo.Parameters.Add("@b", MySqlDbType.VarChar).Value = "busy";
                                        //увеличение часов
                                        commandResourceChangeInfo.Parameters.Add("@hour", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()) + Int32.Parse(tableworker.Rows[j][4].ToString());

                                        //код личный рабочего
                                        dataGridView1.Rows[i].Cells[9].Value = tableworker.Rows[j][0].ToString();
                                        //Фамилия
                                        dataGridView1.Rows[i].Cells[10].Value = tableworker.Rows[j][2].ToString();
                                       
                                        flag = 1;
                                        db.OpenConnection();
                                        commandResourceChangeInfo.ExecuteNonQuery();
                                        db.CloseConnection();
                                        break;





                                    }

                                }

                                if (flag != 1)
                                {
                                    for (int j = 0; j < tableworker.Rows.Count; j++)
                                    {

                                        MySqlCommand commandResourceChangeInfo = new MySqlCommand("UPDATE `mpmresource` SET `hour`=@hour WHERE `idResource`=@idR", db.getConnection());

                                        //заглушка
                                        commandResourceChangeInfo.Parameters.Add("@idR", MySqlDbType.Int32).Value = Int32.Parse(tableworker.Rows[j][0].ToString());


                                        commandResourceChangeInfo.Parameters.Add("@hour", MySqlDbType.Int32).Value = Int32.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()) + Int32.Parse(tableworker.Rows[j][4].ToString());

                                        //код личный рабочего
                                        dataGridView1.Rows[i].Cells[9].Value = tableworker.Rows[j][0].ToString();
                                        //Фамилия
                                        dataGridView1.Rows[i].Cells[10].Value = tableworker.Rows[j][2].ToString();
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

                GetDocActiv.Visible = true;
                
            }


            //расчёт общего времени выполнения заказа 

        }

        //формирование активной задачи 
        private void GetDocActiv_Click(object sender, EventArgs e)
        {
            string NameProduct = textBoxNameObject.Text;
            int number = 0;
            number=Int32.Parse(textBoxValuePart.Text);

            if (NameProduct == "" && number == 0)
            {
                MessageBox.Show("Проверьте входные данные по заказу");
            }

            MySqlCommand commandNewTask = new MySqlCommand("INSERT INTO `mpmactivetask` (`idtask`, `number`, `producttype`) VALUES(NULL, @N, @Type)", db.getConnection());

            //заглушка
            commandNewTask.Parameters.Add("@N", MySqlDbType.Int32).Value = number;
            commandNewTask.Parameters.Add("@Type", MySqlDbType.VarChar).Value = NameProduct;

            db.OpenConnection();
            commandNewTask.ExecuteNonQuery();
            db.CloseConnection();

            MySqlCommand commandGetKodTask = new MySqlCommand("SELECT idtask FROM `mpmactivetask` WHERE number=@Num AND producttype=@Product ORDER BY `mpmactivetask`.`idtask` DESC", db.getConnection());

            //заглушка
            commandGetKodTask.Parameters.Add("@Num", MySqlDbType.Int32).Value = number;
            commandGetKodTask.Parameters.Add("@Product", MySqlDbType.VarChar).Value = NameProduct;

            tablekod.Clear();


            //Выполнение запроса к бд
            adapter.SelectCommand = commandGetKodTask;

            adapter.Fill(tablekod);
            
            for (int i = 0;i < dataGridView1.Rows.Count;i++)
            {
                //код активной задачи
                int kod = Int32.Parse(tablekod.Rows[0][0].ToString());

                //номер операции
                string idtask = dataGridView1.Rows[i].Cells[1].Value.ToString();

                //номер операции
                int idoper= Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());

                //название операции
                string OperName = dataGridView1.Rows[i].Cells[3].Value.ToString();

                // личный код рабочего  
                int idLworker = Int32.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());

                //Фамили и инициалы рабочего 
                string surname = dataGridView1.Rows[i].Cells[10].Value.ToString();

                //код установки 
                int idKodTool = Int32.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());

                //продолжительность 
                
                string Time = dataGridView1.Rows[i].Cells[8].Value.ToString();


               //Получения кода инструмента и названия документа
                MySqlCommand commandActiveTaskInfo = new MySqlCommand("INSERT INTO `mpmtaskinfo` (`idtask`, `idnumber`, `idOper`, `OperName`, `idLWorker`, `surname`, `idLTool`, `Time`, `type`) VALUES (@Kod, @idtask, @idoper, @OperName, @idLWorker, @surname, @idKodTool, @Time, @T)", db.getConnection()); 

                //заглушка
                commandActiveTaskInfo.Parameters.Add("@Kod", MySqlDbType.Int32).Value = kod;
                commandActiveTaskInfo.Parameters.Add("@idtask", MySqlDbType.VarChar).Value = idtask;
                commandActiveTaskInfo.Parameters.Add("@idoper", MySqlDbType.Int32).Value = idoper;
                commandActiveTaskInfo.Parameters.Add("@OperName", MySqlDbType.VarChar).Value = OperName;
                commandActiveTaskInfo.Parameters.Add("@idLWorker", MySqlDbType.VarChar).Value = idLworker;
                commandActiveTaskInfo.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                commandActiveTaskInfo.Parameters.Add("@idKodTool", MySqlDbType.VarChar).Value = idKodTool;
                commandActiveTaskInfo.Parameters.Add("@Time", MySqlDbType.VarChar).Value = Time;

                if (i < number)
                {
                    commandActiveTaskInfo.Parameters.Add("@T", MySqlDbType.VarChar).Value = "active";
                }
                else
                {
                    commandActiveTaskInfo.Parameters.Add("@T", MySqlDbType.VarChar).Value = "ready";
                }

                db.OpenConnection();
                commandActiveTaskInfo.ExecuteNonQuery();
          
            }

            CreateDoc.Visible = true;
            MessageBox.Show("Активная задача создана");

        }

        //формирование документа по выбранным людям и оборудованию 
        private void CreateDoc_Click(object sender, EventArgs e)
        {
            MySqlCommand commandTaskInfo = new MySqlCommand("SELECT idnumber,idOper,OperName,idLWorker,surname,idLTool,Time FROM `mpmtaskinfo` WHERE idtask=@Task ORDER BY `mpmtaskinfo`.`idnumber` ASC", db.getConnection());
           
            //код активной задачи 
            DataTable tableinfo = new DataTable();

            //заглушка
            commandTaskInfo.Parameters.Add("@Task", MySqlDbType.Int32).Value = Int32.Parse(tablekod.Rows[0][0].ToString());

            //Выполнение запроса к бд
            adapter.SelectCommand = commandTaskInfo;

            adapter.Fill(tableinfo);

            if (tableinfo.Rows.Count>0)
            {
                //выбор пути 
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Pdf files(*.pdf)|*.pdf|All files(*.*)|*.*";
                saveFileDialog1.Title = "Cохранение документа по тех. процессу";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;

                while (filename == "")
                {

                    MessageBox.Show("Введите название документа");

                }

                //Создаём новый документ
                var document = new Document(PageSize.A4, 20, 20, 30, 20);

                //определение шрифта. Иначе не увидем русский текст 
                string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALNBI.TTF");

                var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                var font = new iTextSharp.text.Font(baseFont, 8, iTextSharp.text.Font.NORMAL);

                //прописываем путь для документа
                using (var writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create)))
                {
                    //открываем док
                    document.Open();

                    //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
                    PdfPTable table = new PdfPTable(tableinfo.Columns.Count);

                    table.DefaultCell.Padding = 1;
                    table.WidthPercentage = 100;
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.DefaultCell.BorderWidth = 0.5f;

                    //добавляем новый заголовок
                    document.Add(new Paragraph("Код активной задачи  " + tablekod.Rows[0][0].ToString(), font));

                    document.Add(new Paragraph("   "));

                    //
                    PdfPCell cell;

                    string[] HeaderText = { "№", "Код операции", "Название операции", "Код рабочего", "ФИО", "Код инструмента", "T(час)" };
                    //Сначала добавляем заголовки таблицы
                    for (int j = 0; j < 7; j++)
                    {
                        cell = new PdfPCell(new Phrase(new Phrase(HeaderText[j], font)));
                        //Фоновый цвет (необязательно, просто сделаем по красивее)
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;

                        table.AddCell(cell);

                    }

                    //Добавляем все остальные ячейки
                    for (int j = 0; j < tableinfo.Rows.Count; j++)
                    {
                        for (int k = 0; k < tableinfo.Columns.Count; k++)
                        {

                            table.AddCell(new Phrase(tableinfo.Rows[j][k].ToString(), font));
                        }
                    }
                    //Добавляем таблицу в документ
                    document.Add(table);
                    document.Close();
                    writer.Close();
                }

                //открытие, созданного файла
                System.Diagnostics.Process.Start(filename);

            }




        }
    }
}
