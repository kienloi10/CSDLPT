using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmMain
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.tRACNGHIEMDataSet.V_DS_PHANMANH);
            tENCNComboBox.SelectedIndex = 1;
            tENCNComboBox.SelectedIndex = 0;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản không được trống", "Lỗi Đăng Nhập", MessageBoxButtons.OK);
                txtID.Focus();
                return;
            }
            Program.mlogin = txtID.Text;
            Program.password = txtPass.Text;
            if (Program.KetNoi() == 0) return;
            MessageBox.Show("Đăng nhập thành công", "", MessageBoxButtons.OK);

            Program.mChinhanh = tENCNComboBox.SelectedIndex;
            Program.bds_dspm = bdsDSPM;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;


            String strlenh = "EXEC SP_DANGNHAP '" + Program.mlogin + "'";
            Program.myReader = Program.ExecSqlDataReader(strlenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            Program.username = Program.myReader.GetString(0);
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            MessageBox.Show(Program.username + "," + Program.mGroup, "", MessageBoxButtons.OK);

            /*Program.frmChinh.MAGV.Text = "Mã giảng viên: " + Program.username;
            Program.frmChinh.HOTEN.Text = "Họ tên: " + Program.mHoten;
            Program.frmChinh.NHOM.Text = "Nhóm: " + Program.mGroup;*/
        }

        private void tENCNComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.servername = tENCNComboBox.SelectedValue.ToString();
        }
    }
}
