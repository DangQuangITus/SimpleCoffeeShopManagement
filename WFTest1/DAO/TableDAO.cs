using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFTest1.DTO;

namespace WFTest1.DAO
{
    class TableDAO
    {
        public static int tbWidth = 105;
        public static int tbHeight = 110;
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAO();
                return TableDAO.instance;
            }
            private set => TableDAO.instance = value;
        }

        private TableDAO() { }

        public List<Table> loadTableList()//load ds bàn lên
        {
            List<Table> tb = new List<Table>();
            string query = " dbo.USP_getTableList  ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table temp = new Table(item);
                tb.Add(temp);
            }

            return tb;
        }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1, @idTable2", new object[] { id1, id2 });
        }

        //ban
        public List<Table> GetListTableFoodByCateID(int id)
        {
            List<Table> list = new List<Table>();
            string query = "SELECT * FROM dbo.TableFood WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    Table temp = new Table(item);
                    list.Add(temp);
                }
            }


            return list;
        }

        //17 them, xoa sửa chưa lm dk vì cái id table phải để identity r lm sau
        /*    public bool InsertTableFood(string name, string status)
             {
                 string query = string.Format("INSERT dbo.TableFood ( name, status )VALUES  ( N'{0}', N'{1}')", name, status);//dung string format nhanh hơn
                 int result = DataProvider.Instance.ExecuteNonQuery(query);

                 return result > 0;
             }

             public bool UpdateTableFood(string name, string status, int id)
             {
                 string query = string.Format("UPDATE dbo.TableFood SET name = N'{0}', status = N'{1}' WHERE id = {2}", name, status, id);
                 int result = DataProvider.Instance.ExecuteNonQuery(query);

                 return result > 0;
             }

             public bool DeleteTableFood(int idFoodTable) //khi xoa phai xoa billinfo trk
             {
                 string query = string.Format("Delete TableFood where id = {0}", idFoodTable);
                 int result = DataProvider.Instance.ExecuteNonQuery(query);

                 return result > 0;
             }*/

        public Table GetTableStatusByID(int id)
        {
            Table status = null;
            string query = "SELECT * FROM dbo.TableFood WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                status = new Table(item);
                return status;
            }
            return status;
        }
        // chèn bàn mới theo thông tin bàn cũ
        public bool InsertTable()
        {
            string query = " USP_InsertTable ";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteTable @idTable", new object[] { id});
            return result > 0;
        }

    }
}
