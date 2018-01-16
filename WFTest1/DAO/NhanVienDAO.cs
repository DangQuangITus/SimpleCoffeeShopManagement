using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFTest1.DTO;

namespace WFTest1.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get
            {
                if (NhanVienDAO.instance == null)
                    instance = new NhanVienDAO();
                return NhanVienDAO.instance;

            }
            private set => instance = value;
        }
        public NhanVien GetNhanVienByID(int id)
        {
            NhanVien nv = null;
            string query = "SELECT * FROM dbo.NhanVien WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    nv = new NhanVien(item);
                    return nv;
                }
            }
            return nv;
        }
        public NhanVienDAO() { }
        public List<NhanVien> GetListNhanVienByCateID(int id)
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = "SELECT * FROM dbo.Staff WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    NhanVien temp = new NhanVien(item);
                    list.Add(temp);
                }
            }


            return list;
        }

        public List<NhanVien> GetListNhanVien()//15
        {
            List<NhanVien> list = new List<NhanVien>();//tra ve 1 danh sach

            string query = "select * from dbo.NhanVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                list.Add(nv);
            }

            return list;
        }

        //
        //17 them, xoa sửa
        public bool InsertNhanVien(string ten, DateTime ngaysinh, string gioitinh, string diachi, string sdt, float luong)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_InsertNhanVien @ten, @ngaysinh, @gioitinh, @diachi, @sdt, @luong", new object[] { ten, ngaysinh, gioitinh, diachi, sdt, luong });

            return result > 0;
        }

        public bool UpdateNhanVien(int id, string ten, DateTime ngaysinh, string gioitinh, string diachi, string sdt, float luong)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateNhanVien @id, @ten, @ngaysinh, @gioitinh, @diachi, @sdt, @luong", new object[] {id, ten, ngaysinh, gioitinh, diachi, sdt, luong });

            return result > 0;
        }

        public bool DeleteNhanVien(int idNV) //khi xoa 
        {

            string query = string.Format("Delete dbo.NhanVien where id = {0}", idNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
