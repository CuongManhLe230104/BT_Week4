using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BTVN_week4
{
    public partial class Form2 : Form 
    {
        public Form2()
        {
            InitializeComponent();
        }


        public delegate void delegPassData(string id, string hoten, double luong);
        public event delegPassData delegatePassData;
        public NhanVien nhanVien = new NhanVien();

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                nhanVien.MSNV = txtMSNV.Text;
                nhanVien.Name = txtTenNV.Text;
                nhanVien.Luong = int.Parse(txtLuong.Text);
                if (delegatePassData != null)
                {
                    delegatePassData?.Invoke(nhanVien.MSNV, nhanVien.Name, nhanVien.Luong);
                    MessageBox.Show("Dữ liệu đã được truyền qua Form1");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
