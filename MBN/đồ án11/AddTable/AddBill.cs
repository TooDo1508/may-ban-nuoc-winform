using đồ_án11.DULIEU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án11.AddTable
{
    public class AddBill
    {
        private static AddBill instance;


        public static AddBill Instance
        {
            get { if (instance == null) instance = new AddBill(); return AddBill.instance; }
            private set { AddBill.instance = value; }

        }
        private AddBill() { }         
                
        public void AdddBill(int id,int sl)
        {
            DataProvider.Instance.ExcuteNonQuery("exec USP_InserBill @idDrink , @sl", new object[]{id,sl});
        }

        

        public DataTable SearchBillM1(DateTime datea, DateTime dateb)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_GetListBillM1 @datea , @dateb", new object[]{datea,dateb});
        }

        public DataTable SearchBillM2(DateTime datec, DateTime dated)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_GetListBillM2 @datec , @dated", new object[] { datec, dated });
        }

        public DataTable SeachBillM1D(DateTime dateD)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_GetListBillM1Day @dateD",new object[] { dateD});
        }
        public DataTable SeachBillM2D(DateTime dateD)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_GetListBillM2Day @dateD", new object[] { dateD });
        }

        public DataTable DoanhThuSP1(DateTime datec,DateTime dated)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_DoanhThuSP1 @datec , @dated", new object[] { datec, dated });
        }

        public DataTable DoanhThuSP2(DateTime datec, DateTime dated)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_DoanhThuSP2 @datec , @dated", new object[] { datec, dated });
        }
    }
}
