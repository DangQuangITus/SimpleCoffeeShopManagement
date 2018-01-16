using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFTest1.DTO
{
    class BIll
    {
        public BIll(int ID, DateTime? dateCheckIn, DateTime dateCheckOut, int status,int discount=0)
        {
            this.id = ID;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.status = status;
            this.disCount = discount;
        }
        public BIll(DataRow row)
        {
            this.id = (int)row["id"];
            this.dateCheckIn = (DateTime)row["DateCheckIn"];
            var dateCheckOutTemp = row["DateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")//nó trả ra rỗng ta k cast dk
                this.dateCheckOut = (DateTime)row["DateCheckOut"];
            this.status = (int)row["status"];
            this.disCount = (int)row["disCount"];
        }
        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;
        private int disCount;

        public int ID { get => id; set => id = value; }
        public DateTime? DayCheckIn { get => dateCheckIn; set => dateCheckIn = value; }//dấu ? kiểu dl can null
        public DateTime? DayCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int DisCount { get => disCount; set => disCount = value; }
    }
}
