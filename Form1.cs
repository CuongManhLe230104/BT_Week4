using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BTVN_week4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<NhanVien> nhanvien;
        private void btnThem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.delegatePassData += (id, hoten, luong) =>
            {
                dtgNhanVien.Rows.Add(id, hoten, luong);
            };
            frm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.SelectedCells.Count > 0)
            {
                int rowIndex = dtgNhanVien.SelectedCells[0].RowIndex;

                string id = dtgNhanVien.Rows[rowIndex].Cells[0].Value.ToString();
                string hoten = dtgNhanVien.Rows[rowIndex].Cells[1].Value.ToString();
                double luong = Convert.ToDouble(dtgNhanVien.Rows[rowIndex].Cells[2].Value);

                Form2 form2 = new Form2();
                {
                    form2.nhanVien.MSNV = id;
                    form2.nhanVien.Name = hoten;
                    form2.nhanVien.Luong = luong;
                }

                form2.delegatePassData += (newId, newHoten, newLuong) =>
                {
                    dtgNhanVien.Rows[rowIndex].Cells[0].Value = newId;
                    dtgNhanVien.Rows[rowIndex].Cells[1].Value = newHoten;
                    dtgNhanVien.Rows[rowIndex].Cells[2].Value = Convert.ToDouble(newLuong);
                };

                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy chọn một ô trong DataGridView để sửa!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dtgNhanVien.SelectedCells.Count > 0)
            {
                dtgNhanVien.Rows.RemoveAt(dtgNhanVien.SelectedCells[0].RowIndex);
            } 
                
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Thoat ?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Application.Exit();
            } 
                
        }
    }
}
