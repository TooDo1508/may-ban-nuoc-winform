using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using đồ_án11.AddTable;
using System.Globalization;

namespace đồ_án11
{
    public partial class LichSuGiaoDich : UserControl
    {
        public LichSuGiaoDich()
        {
            InitializeComponent();
            Vao();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            label4.Text = "";
            LoadBillM1(dateTimePicker1.Value, dateTimePicker2.Value);
            TongTien();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            label3.Text = "";
            LoadBillM2(dateTimePicker1.Value, dateTimePicker2.Value);
            TongTien();
        }
        void LoadBillM2(DateTime datec, DateTime dated)
        {
            dataGridView1.DataSource = AddBill.Instance.SearchBillM2(datec, dated);
        }
        void LoadBillM1(DateTime datea, DateTime dateb)
        {
            dataGridView1.DataSource = AddBill.Instance.SearchBillM1(datea, dateb);

        }
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (label3.Text != string.Empty)
            {
                LoadBillM1(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            if (label4.Text != string.Empty)
            {
                LoadBillM2(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            TongTien();
            
        }
        void TongTien()
        {
            int n = dataGridView1.Rows.Count;
            int tdt = 0;
            for (int i = 0; i < n - 1; i++)
            {
                tdt += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            label6.Text = tdt.ToString("c", culture);
        }     
         private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
         {
            
         }
       void Vao()
       {
            LoadBillM1(dateTimePicker1.Value, dateTimePicker2.Value);
            label3.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            TongTien();
       }
    }
}
