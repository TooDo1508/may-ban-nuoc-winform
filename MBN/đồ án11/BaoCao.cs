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
using Microsoft.Office.Interop.Excel;

namespace đồ_án11
{
    public partial class BaoCao : UserControl
    {
        public dynamic WS { get; private set; }

        public BaoCao()
        {
            InitializeComponent();           
            label1.Text = DateTime.Now.ToLongDateString();
            
            LoadBillM1D(dateTimePicker1.Value);
            dateTimePicker1.Visible = false;
            label2.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
        }

       
        void LoadBillM1D(DateTime dateD)
        {
            dataGridView1.DataSource = AddBill.Instance.SeachBillM1D(dateD);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            label3.Text = "";
            LoadBillM1D(dateTimePicker1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            label2.Text = "";
            LoadBillM2D(dateTimePicker1.Value);
        }
        void LoadBillM2D(DateTime dateD)
        {
            dataGridView1.DataSource = AddBill.Instance.SeachBillM2D(dateD);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application ex = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel._Workbook wb = ex.Workbooks.Add(Type.Missing);

            Microsoft.Office.Interop.Excel._Worksheet ws = null;

            ws = wb.Sheets["Sheet1"];
            ws = wb.ActiveSheet;
            ex.Visible = true;

            ws.Cells[1, 1] = "Đại Học Xây Dựng";
            ws.Cells[2, 2] = "HÓA ĐƠN NHẬP HÀNG";
            ws.Cells[3, 4] = "Hà Nội, Ngày  " + dateTimePicker1.Value;
            if(label2.Text!= string.Empty)
            {
                ws.Cells[4, 5] = button4.Text;
            }else
            {
                ws.Cells[4, 5] = button3.Text;
            }    
            ws.Cells[5, 1] = "STT";
            ws.Cells[5, 2] = "Đồ Uống";
            ws.Cells[5, 3] = "Số Lượng";
            for (int i = 0; i< dataGridView1.RowCount -1;i++)
            {
                for(int j=0;j<2;j++)
                {
                    ws.Cells[i + 6,1] = i + 1;
                    ws.Cells[i + 6, j+2] = dataGridView1.Rows[i].Cells[j].Value;
                }
                
            }    
            
        }
    }
}
