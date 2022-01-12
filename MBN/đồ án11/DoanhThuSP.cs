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
    public partial class DoanhThuSP : UserControl
    {
        public DoanhThuSP()
        {
            InitializeComponent();
            Vao();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            label6.Text = "";
            LoadDT1(dateTimePicker1.Value, dateTimePicker2.Value);
            Tongtien();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            label5.Text = "";
            LoadDT2(dateTimePicker1.Value, dateTimePicker2.Value);
            Tongtien();
            
        }
        void LoadDT1(DateTime datec, DateTime dated)
        {
            dataGridView1.DataSource = AddBill.Instance.DoanhThuSP1(datec, dated);
        }
        void LoadDT2(DateTime datec, DateTime dated)
        {
            dataGridView1.DataSource = AddBill.Instance.DoanhThuSP2(datec, dated);
        }

        private void button1_Click(object sender, EventArgs e)
        {            
                if (label5.Text != string.Empty)
                {
                    LoadDT1(dateTimePicker1.Value, dateTimePicker2.Value);
                }
                if (label6.Text != string.Empty)
                {
                    LoadDT2(dateTimePicker1.Value, dateTimePicker2.Value);
                }
            Tongtien();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        void Tongtien()
        {
            int n = dataGridView1.Rows.Count;
            int tdt = 0;
            for (int i = 0; i < n - 1; i++)
            {
                tdt += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            label3.Text = tdt.ToString("c", culture);           
        }
        void Vao()
        {
            LoadDT1(dateTimePicker1.Value, dateTimePicker2.Value);
            label5.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            Tongtien();
        }
    }
}
