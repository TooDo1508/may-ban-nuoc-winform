using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using đồ_án11.AddTable;

namespace đồ_án11
{
    public partial class DoanhThu : UserControl
    {
        public DoanhThu()
        {
            InitializeComponent();
            LoadBill();
            Tongtien();
        }
        void Tongtien()
        {
            int n = dataGridView1.Rows.Count;
            int tdt = 0;
            for (int i = 0; i < n - 1; i++)
            {
                tdt += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            label2.Text = tdt.ToString("c", culture);
            }
        void LoadBill()
        {
            string query = "select m.name as TênMáy,Datecheckout as NgàyMua,d.name As TênĐồUống,sl as SốLượng,price as Giá,sl*price as TổngTiền from Bill as b,Drink as d , May as m where d.idD=b.idDrink and d.idM =m.id";
            dataGridView1.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }
    }
}
