using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    public class NhanVien
    {
        public NhanVien(int id, string ten, DateTime ngaysinh , string gioitinh, string diachi, string sdt, float luong)
        {
            this.id = id;
            this.ten = ten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.luong = luong;
        }

        public NhanVien(DataRow row)
        {
            this.id = (int)row["id"];
            this.ten = row["Ten"].ToString();
            this.ngaysinh = (DateTime)row["NgaySinh"];

            this.gioitinh = row["GioiTinh"].ToString();
            this.diachi = row["DiaChi"].ToString();
            this.sdt = row["Sdt"].ToString(); 
            this.luong = (float)Convert.ToDouble(row["TienLuong"].ToString());


        }
        int id;
        string ten;
        DateTime? ngaysinh;
        string gioitinh;
        string diachi;
        string sdt;

        float luong;

        public int Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime? NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string GioiTinh { get => gioitinh; set => gioitinh = value; }
        public string DiaChi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }

        public float Luong { get => luong; set => luong = value; }
    }
}
