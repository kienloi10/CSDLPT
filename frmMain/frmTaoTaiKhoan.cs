using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace frmMain
{
    public partial class frmTaoTaiKhoan : Form
    {
        String role = "";
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
            if (Program.mGroup == "TRUONG")
            {
                radioButtonCoSo.Visible = false;
                radioButtonGiangVien.Visible = false;
                radioButtonSinhVien.Visible = false;
                radioButtonTruong.Visible = true;
            }
            label2.Visible = false;
            cmbDSChuaTao.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioButtonTruong_CheckedChanged(object sender, EventArgs e)
        {
            try { 
                if ((radioButtonTruong.Checked == true) || (radioButtonCoSo.Checked == true) || (radioButtonGiangVien.Checked == true))
                {
                    role = "TRUONG";
                   /* string dsgv = "exec SP_DSLOGIN";
                    SqlCommand com = new SqlCommand(dsgv, Program.conn);
                    if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbDSChuaTao.DataSource = dt;
                    cmbDSChuaTao.DisplayMember = dt.Columns["TEN"].ToString();
                    cmbDSChuaTao.ValueMember = dt.Columns["MAGV"].ToString();
                    txtTenTaiKhoan.Text = cmbDSChuaTao.SelectedValue.ToString();
                    txtTenDangNhap.Text = cmbDSChuaTao.SelectedValue.ToString();*/
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK); }
        }

        private void radioButtonCoSo_CheckedChanged(object sender, EventArgs e)
        {
            try { 
                if ((radioButtonTruong.Checked == true) || (radioButtonCoSo.Checked == true) || (radioButtonGiangVien.Checked == true))
                {
                    role = "COSO";
                  /* string dsgv = "exec SP_DSLOGIN";
                    SqlCommand com = new SqlCommand(dsgv, Program.conn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbDSChuaTao.DataSource = dt;
                    cmbDSChuaTao.DisplayMember = dt.Columns["TEN"].ToString();
                    cmbDSChuaTao.ValueMember = dt.Columns["MAGV"].ToString();
                    txtTenTaiKhoan.Text = cmbDSChuaTao.SelectedValue.ToString();
                    txtTenDangNhap.Text = cmbDSChuaTao.SelectedValue.ToString();*/
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK); }
        }

        private void radioButtonGiangVien_CheckedChanged(object sender, EventArgs e)
        {
            try { 
                if ((radioButtonTruong.Checked == true) || (radioButtonCoSo.Checked == true) || (radioButtonGiangVien.Checked == true))
                {
                    role = "GIANGVIEN";
                   /* string dsgv = "exec SP_DSLOGIN";
                    SqlCommand com = new SqlCommand(dsgv, Program.conn);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbDSChuaTao.DataSource = dt;
                    cmbDSChuaTao.DisplayMember = dt.Columns["TEN"].ToString();
                    cmbDSChuaTao.ValueMember = dt.Columns["MAGV"].ToString();
                    txtTenTaiKhoan.Text = cmbDSChuaTao.SelectedValue.ToString();
                    txtTenDangNhap.Text = cmbDSChuaTao.SelectedValue.ToString();*/
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK); }
        }

        private void radioButtonSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            try { 
                if (radioButtonSinhVien.Checked == true)
                {
                    role = "SINHVIEN";
                   /* string dssv = "exec SP_DSLOGIN";
                    SqlCommand com1 = new SqlCommand(dssv, Program.conn);
                    SqlDataAdapter da1 = new SqlDataAdapter(com1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    cmbDSChuaTao.DataSource = dt1;
                    cmbDSChuaTao.DisplayMember = dt1.Columns["TEN"].ToString();
                    cmbDSChuaTao.ValueMember = dt1.Columns["MASV"].ToString();
                    txtTenTaiKhoan.Text = cmbDSChuaTao.SelectedValue.ToString();
                    txtTenDangNhap.Text = cmbDSChuaTao.SelectedValue.ToString();*/

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK); }
        }

        private void cmbDSChuaTao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            using (IDbCommand spCommand = Program.conn.CreateCommand())
            {

                if (txtMatKhau.Text.Trim() == "" || txtTenDangNhap.Text.Trim() == "" || txtTenTaiKhoan.Text.Trim() == "")
                {
                    MessageBox.Show("không được trống");
                }
                else
                {
                   

                    try
                    {
                        String strlenh = "EXEC SP_TaOTaiKhoan '" + txtTenDangNhap.Text.Trim() + "','"+ txtMatKhau.Text.Trim() + "','"+ txtTenTaiKhoan.Text.Trim() + "','"+ role + "'";
                        Program.ExecSqlNonQuery(strlenh);
                        MessageBox.Show("Tạo tài khoản thành công.!.");
                        txtMatKhau.Text = "";
                        txtTenDangNhap.Text = "";
                        txtTenTaiKhoan.Text = "";
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Tạo tài khoản Thất bại.!." + ex);
                        
                    }
                }
            }
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {

        }
    }
}
