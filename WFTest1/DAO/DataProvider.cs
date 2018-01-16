using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;//dung mẫu sigleton để tạo 1 obj duy nhất cho 1 class => bien static
        //phím tắt tạo get set : CTRL R E
        private string connectionSTR = @"Data Source=DESKTOP-B0VGDDV\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";


          public static DataProvider Instance
          {
              get
              {
                  if (instance == null)
                      instance = new DataProvider();
                  return DataProvider.instance;
              }
              private set => DataProvider.instance = value; //k cho bên ngoài tác động private
          }//property

        private DataProvider() { } //để private k cho bên ngoài tác động

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                query = query.Replace(',', ' ');

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
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data); 
                connection.Close();
            }
            return data;
        }//để null k k truyền cx ok

        public int ExecuteNonQuery(string query, object[] parameter = null)//trả về số dòng thành công
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))//bất kì chuyện gì xảy ra thì nó sẽ auto giải phóng
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                query = query.Replace(',', ' ');
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))//nếu chuỗi có chứa dấu @
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

        public object ExecuteScalar(string query, object[] parameter = null)//đếm số lượng object
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
