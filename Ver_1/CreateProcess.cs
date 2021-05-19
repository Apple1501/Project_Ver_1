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
    public partial class CreateProcess : Form
    {
        public CreateProcess()
        {
            InitializeComponent();
            this.panelCreateProcess.AutoSize = true;
            
        }
        DB db = new DB();
        
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        //код выбранной операции
        DataTable table = new DataTable();
        //код и название инструмента по выбранной операции и участку 
        DataTable tableToolName = new DataTable();

        //код и название выбранного участка 
        DataTable tablePlaceid = new DataTable();
          
     
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
                MessageBox.Show("Соединение с базой данных получено");
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

        private void buttonPlusOper_Click(object sender, EventArgs e)
        {
            string NameOper, Worker, Place, DocName, Tool;

            //считывание выбранных данных
            NameOper = comboBoxNameOper.Text.ToString();
            Place = comboBoxPlace.Text.ToString();
            if (NameOper == "" && NameOper == "")
            {
                MessageBox.Show("Проверьте данныe");

            }
            
            else
            {
                Worker = comboBoxWorker.Text.ToString();

                Place = comboBoxPlace.Text.ToString();

                DocName = comboBoxDocName.Text.ToString();

                Tool = comboBoxTool.Text.ToString();

                dataGridView1.Rows.Add(table.Rows[0][0].ToString(), NameOper, Place, Worker, Tool, DocName, 0.5f);
            }
        }

        private void StopWork_Click(object sender, EventArgs e)
        {
            //закрытие программы
            Application.Exit();
        }
        Point LastPoint;
        private iTextSharp.text.Font helvetica;
        private BaseFont helveticaBase;

        private void panelCreateProcess_MouseMove(object sender, MouseEventArgs e)
        {
            
                //код для перемещение главного меню 
                if (e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - LastPoint.X;
                    this.Top += e.Y - LastPoint.Y;
                }
            
        }

        private void panelCreateProcess_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int number = e.RowIndex;
            dataGridView1.Rows.RemoveAt(number);

        }

        //сохранение данных в базу данных
        private void SaveNewProcess_Click(object sender, EventArgs e)
        {
            string NameProject=textBoxNameObject.Text;

            if (NameProject == "")
            {
                MessageBox.Show("Проверьте название объекта");
            }

            else
            {
                //проверка, что ранее процесса по заданному объекту не было уже создано
                if (CheckInfo(NameProject))
                {
                    return;
                }
                    

                //создание нового тех. процесса в бд. Запись в таблицу связи продукта и тех процесса
                //Получения кода инструмента и названия документа
                MySqlCommand commandProduct = new MySqlCommand("INSERT INTO `mpmproduct` (`ProductName`) VALUES (@Name);", db.getConnection());

                //заглушка
                commandProduct.Parameters.Add("@Name", MySqlDbType.VarChar).Value = textBoxNameObject.Text; 

                db.OpenConnection();

                //проверка выполнения запроса
                if (commandProduct.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные по объекту записаны в бд");
                }
                else
                {
                    MessageBox.Show("Данные не были записаны. Такой тех.процесс уже существует");
                }
                db.CloseConnection();

                
                DataTable tableProcessId = new DataTable();

                //Получения кода инструмента и названия документа
                MySqlCommand commandProcessId = new MySqlCommand("SELECT idProcess FROM `mpmproduct` WHERE ProductName = @idProductName", db.getConnection());

                //заглушка
                commandProcessId.Parameters.Add("@idProductName", MySqlDbType.VarChar).Value = NameProject;
                
                //Выполнение запроса к бд
                adapter.SelectCommand = commandProcessId;

                adapter.Fill(tableProcessId);

                if (tableProcessId.Rows.Count == 0)
                {
                    MessageBox.Show("Данные по объекту не найдены в бд");
                }
                else
                {
                    for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                    {
                        

                        try
                        {
                            int idOper = Int32.Parse(dataGridView1.Rows[rows].Cells[0].Value.ToString());

                            string OperName = dataGridView1.Rows[rows].Cells[1].Value.ToString();

                            string WorkerName = dataGridView1.Rows[rows].Cells[3].Value.ToString();

                            string ToolName = dataGridView1.Rows[rows].Cells[4].Value.ToString();

                            string DocName = dataGridView1.Rows[rows].Cells[5].Value.ToString();

                            string Time = dataGridView1.Rows[rows].Cells[6].Value.ToString();

                            if (Time == null)
                            {
                                throw new ArgumentNullException();
                            }

                            //Получения кода инструмента и названия документа
                            MySqlCommand commandProcess = new MySqlCommand("INSERT INTO `mpmprocess` (`idProcess`, `Number`,`idOperation`, `OperName`, `DocName`, `ToolName`, `WorkerName`, `Time`) VALUES (@IdProcess,@Number, @idOper, @OperName, @DocName, @ToolName, @W, @Time)", db.getConnection());
                           
                            //заглушка
                            commandProcess.Parameters.Add("@IdProcess", MySqlDbType.Int32).Value = Int32.Parse(tableProcessId.Rows[0][0].ToString()); ;
                            commandProcess.Parameters.Add("@Number", MySqlDbType.Int32).Value = rows+1;
                            commandProcess.Parameters.Add("@idOper", MySqlDbType.Int32).Value = idOper;
                            commandProcess.Parameters.Add("@OperName", MySqlDbType.VarChar).Value = OperName;
                            commandProcess.Parameters.Add("@DocName", MySqlDbType.VarChar).Value = DocName;
                            commandProcess.Parameters.Add("@ToolName", MySqlDbType.VarChar).Value = ToolName;
                            commandProcess.Parameters.Add("@W", MySqlDbType.VarChar).Value = WorkerName;
                            commandProcess.Parameters.Add("@Time", MySqlDbType.VarChar).Value = Time;

                            db.OpenConnection();
                            commandProcess.ExecuteNonQuery();

                            db.CloseConnection();


                        }
                        catch (ArgumentNullException)
                        {
                            MessageBox.Show("Проверьте, что ввели все данные в таблицу");
                        }
                   
                    }

                    MessageBox.Show("Данные по тех. процессу записаны");

                }


            }

        }

        public Boolean CheckInfo(string NameProject)
        {
            DataTable tableNameProduct = new DataTable();

            //Получения кода инструмента и названия документа
            MySqlCommand commandName = new MySqlCommand("SELECT idProcess FROM `mpmproduct` WHERE ProductName = @idProductName", db.getConnection());

            //заглушка
            commandName.Parameters.Add("@idProductName", MySqlDbType.VarChar).Value = NameProject;

            //Выполнение запроса к бд
            adapter.SelectCommand = commandName;

            adapter.Fill(tableNameProduct);

            if (tableNameProduct.Rows.Count > 0)
            {
                return true;

            }
            else
                return false;

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menupanel = new Menu();
            menupanel.Show();

        }

        //создание документа по тех процессу.
        private void CreateDoc_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pdf files(*.pdf)|*.pdf|All files(*.*)|*.*";
            saveFileDialog1.Title = "Cохранение документа по тех. процессу";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;

            //получаем данные из базы данных
            //берём навзание необходимого объекта 
            string NameProject = textBoxNameObject.Text;
            if (NameProject == "")
            {
                MessageBox.Show("Проверьте название объекта");
            }

            else
            {
                //выбираем из базы данных код тех. процесса объекта 
                DataTable tableProduct = new DataTable();

                //Получения кода инструмента и названия документа
                MySqlCommand commandidProcess = new MySqlCommand("SELECT idProcess FROM `mpmproduct` WHERE ProductName = @ProductName", db.getConnection());

                //заглушка
                commandidProcess.Parameters.Add("@ProductName", MySqlDbType.VarChar).Value = NameProject;

                //Выполнение запроса к бд
                adapter.SelectCommand = commandidProcess;

                adapter.Fill(tableProduct);

                if (tableProduct.Rows.Count > 0)
                {
                    //выбираем из базы данных код тех. процесса объекта 
                    DataTable tableProcess = new DataTable();

                    //Получения кода инструмента и названия документа
                    MySqlCommand commandProcess = new MySqlCommand("SELECT Number,idOperation,OperName,DocName,ToolName,WorkerName,Time FROM `mpmprocess` WHERE idProcess = @idProcess", db.getConnection());

                    //заглушка
                    commandProcess.Parameters.Add("@idProcess", MySqlDbType.Int32).Value = Int32.Parse(tableProduct.Rows[0][0].ToString());

                    //Выполнение запроса к бд
                    adapter.SelectCommand = commandProcess;

                    adapter.Fill(tableProcess);

                    //Создаём новый документ
                    var document = new Document(PageSize.A4, 20, 20, 30, 20);

                    //определение шрифта. Иначе не увидем русский текст 
                      string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALNBI.TTF");

                      var baseFont = BaseFont.CreateFont(ttf,BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                      var font = new iTextSharp.text.Font(baseFont, 8, iTextSharp.text.Font.NORMAL);

                    //прописываем путь для документа
                    using (var writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create)))
                    {
                        //открываем док
                        document.Open();
                        
                        //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
                        PdfPTable table = new PdfPTable(tableProcess.Columns.Count);

                        table.DefaultCell.Padding = 1;
                        table.WidthPercentage = 100;
                        table.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.DefaultCell.BorderWidth = 0.5f;

                        //добавляем новый заголовок
                        document.Add(new Paragraph("Технологический процесс по объекту    " + NameProject, font));

                        document.Add(new Paragraph("   "));

                        //
                        PdfPCell cell;
                        
                        string[] HeaderText = {"№","Код операции","Название операции","Документ","Инструмент","Рабочий","T(час)"};
                        //Сначала добавляем заголовки таблицы
                         for (int j = 0; j < 7; j++)
                         {
                            cell = new PdfPCell(new Phrase(new Phrase(HeaderText[j], font)));
                            //Фоновый цвет (необязательно, просто сделаем по красивее)
                            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                           
                            table.AddCell(cell);
                            
                         }

                        //Добавляем все остальные ячейки
                         for (int j = 0; j < tableProcess.Rows.Count; j++)
                         {
                             for (int k = 0; k < tableProcess.Columns.Count; k++)
                             {
                               
                               table.AddCell(new Phrase(tableProcess.Rows[j][k].ToString(), font));
                             }
                         }
                        //Добавляем таблицу в документ
                        document.Add(table);
                        document.Close();
                        writer.Close();
                    }

                    MessageBox.Show("Документ записан");


                }
  

            }

        }
    }
}
