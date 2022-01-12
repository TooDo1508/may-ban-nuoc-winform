using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án11.AddTable
{
    class AddMay
    {
        private static AddMay instance;


        public static AddMay Instance
        {
            get { if (instance == null) instance = new AddMay(); return AddMay.instance; }
            private set { AddMay.instance = value; }

        }
        private AddMay() { }

        public bool NapTien1(int DoanhThu)
        {
            string query = "update May set DoanhThu = DoanhThu +" + DoanhThu + "where id = 1";
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;

        }
        public bool NapTien2(int DoanhThu)
        {
            string query = "update May set DoanhThu = DoanhThu +" + DoanhThu + "where id = 2";
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;

        }





    }
}
