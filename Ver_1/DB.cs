using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ver_1
{
    //Класс для работы с базой данных
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=processinfo");

        //подключение к базе данных
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        
        //разрыв соединения с базой данных
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        //возращает соединение для изменение данных в базе данных
        public MySqlConnection getConnection()
        {
            return connection;

        }

    }
}
