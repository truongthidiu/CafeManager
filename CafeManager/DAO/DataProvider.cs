using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; // duy nhất 1 connection tại 1 thời điểm (kiến trúc singleton)

        public static DataProvider Instance //đóng gói (ctrl + R + E)
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; } // nội bộ mới được thay đổi dữ liệu còn bên ngoài thì không
        }

        private DataProvider() { } // tạo hàm dựng để đảm bảo bên ngoài k tác dụng vào được, chỉ lấy ra được

        private string connectionSTR = @"Data Source=DESKTOP-D4NEDSR;Initial Catalog=CafeManager;Integrated Security=True";// kết nối với database

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable(); // tạo kho ảo để lưu trữ dữ liệu

            using (SqlConnection connection = new SqlConnection(connectionSTR)) // tạo kết nối xuống Database
            {
                connection.Open(); // mở kết nối

                SqlCommand command = new SqlCommand(query, connection); // câu truy vấn thực thi

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command); // thực hiện câu truy vấn và lấy dữ liệu ra

                if (adapter!=null)
                {
                    adapter.Fill(data); // đổ dữ liệu vào kho
                }


                connection.Close(); // đóng kết nối
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}

