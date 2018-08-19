using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmMain
{
   
    public partial class frmThi : Form
    {
        List<CAUHOI> listCH = new List<CAUHOI>();

        int i = 0;
        private System.Windows.Forms.Timer timer1;
        private int counter = frmChuanBiThi.thoigian;
        public frmThi()
        {
            InitializeComponent();
        }

       

        private void frmThi_Load(object sender, EventArgs e)
        {
            
            txtTen.Enabled = false;
            txtMa.Enabled = false;
            txtLop.Enabled = false;
            if(Program.mGroup == "GIANGVIEN")
            {
                txtTen.Text = Program.mHoten;
                txtMa.Text = Program.username;
            }
            if (Program.mGroup == "SINHVIEN")
            {

                String strlenh = "EXEC SP_TimLopCuaSV '" + Program.username + "'";
                Program.myReader = Program.ExecSqlDataReader(strlenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                String aa = Program.myReader.GetString(0);
                txtLop.Text = aa;
                txtTen.Text = Program.mHoten;
                txtMa.Text = Program.username;
                Program.myReader.Close();
            }

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            lbTime.Text = counter.ToString();

            // lấy du74 lieu
            lbCau.Text = "Câu " + (i + 1);
            lbNoiDung.Text = frmChuanBiThi.ds[0].NOIDUNG1;
            rdA.Text = frmChuanBiThi.ds[0].A1;
            rdB.Text = frmChuanBiThi.ds[0].B1;
            rdC.Text = frmChuanBiThi.ds[0].C1;
            rdD.Text = frmChuanBiThi.ds[0].D1;
            rdA.Checked = false;
            rdB.Checked = false;
            rdC.Checked = false;
            rdD.Checked = false;

        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
                timer1.Stop();
            lbTime.Text = counter.ToString();
        }

        private void btnDauTien_Click(object sender, EventArgs e)
        {

        }

        private void btnLuiLai_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                i = frmChuanBiThi.socauthi;
            }
            i--;
            lbCau.Text = "Câu " + (i + 1);
 
            lbNoiDung.Text = frmChuanBiThi.ds[i].NOIDUNG1.ToString();
            rdA.Text = frmChuanBiThi.ds[i].A1.ToString();
            rdB.Text = frmChuanBiThi.ds[i].B1.ToString();
            rdC.Text = frmChuanBiThi.ds[i].C1.ToString();
            rdD.Text = frmChuanBiThi.ds[i].D1.ToString();

            rdA.Checked = false;
            rdB.Checked = false;
            rdC.Checked = false;
            rdD.Checked = false;

            if(frmChuanBiThi.ds[i].Chon1 != null)
            {
                if(frmChuanBiThi.ds[i].Chon1 == "A")
                {
                    rdA.Checked = true;
                }
                if (frmChuanBiThi.ds[i].Chon1 == "B")
                {
                    rdB.Checked = true;
                }
                if (frmChuanBiThi.ds[i].Chon1 == "C")
                {
                    rdC.Checked = true;
                }
                if (frmChuanBiThi.ds[i].Chon1 == "D")
                {
                    rdD.Checked = true;
                }
            }

        }

        private void btnKeTiep_Click(object sender, EventArgs e)
        {
            
            if (i == (frmChuanBiThi.socauthi - 1))
            {
                i = -1;
            }
            i++;
            lbNoiDung.Text = frmChuanBiThi.ds[i].NOIDUNG1.ToString();
            rdA.Text = frmChuanBiThi.ds[i].A1.ToString();
            rdB.Text = frmChuanBiThi.ds[i].B1.ToString();
            rdC.Text = frmChuanBiThi.ds[i].C1.ToString();
            rdD.Text = frmChuanBiThi.ds[i].D1.ToString();
            rdA.Checked = false;
            rdB.Checked = false;
            rdC.Checked = false;
            rdD.Checked = false;
            lbCau.Text = "Câu " + (i + 1);

            if (frmChuanBiThi.ds[i].Chon1 != null)
            {
                if (frmChuanBiThi.ds[i].Chon1 == "A")
                {
                    rdA.Checked = true;
                }
                if (frmChuanBiThi.ds[i].Chon1 == "B")
                {
                    rdB.Checked = true;
                }
                if (frmChuanBiThi.ds[i].Chon1 == "C")
                {
                    rdC.Checked = true;
                }
                if (frmChuanBiThi.ds[i].Chon1 == "D")
                {
                    rdD.Checked = true;
                }
            }
        }

        private void btnCuoiCung_Click(object sender, EventArgs e)
        {

        }

        private void btnNopBaiThi_Click(object sender, EventArgs e)
        {
            int dung = 0;
            float diem = 0;
            for(int d = 0; d < frmChuanBiThi.ds.Count();d++)
            {
                if(frmChuanBiThi.ds[d].Chon1 != null)
                {

                    if (frmChuanBiThi.ds[d].Chon1.Trim() == frmChuanBiThi.ds[d].DAP_AN1.Trim())
                    {
                        dung++;
                    }
                }
            }
            diem = (dung * 10) / frmChuanBiThi.ds.Count();
            LuuBangDiem(diem);
            timer1.Stop();
            MessageBox.Show(diem.ToString(), " Điểm", MessageBoxButtons.OK);
        }

        private void LuuBangDiem(float diem)
        {
            String baithi = "";
            String mamon = frmChuanBiThi.mamonhoc.Trim();
            String masv = Program.username.Trim();
            SqlDataReader myReader;
            for (int t = 0; t < frmChuanBiThi.ds.Count(); t++)
            {
                if(frmChuanBiThi.ds[t].Chon1 == null)
                {
                    baithi += frmChuanBiThi.ds[t].MACH1 + "-" + " ";
                }
                else
                {
                    baithi += frmChuanBiThi.ds[t].MACH1 + "-" + frmChuanBiThi.ds[t].Chon1 + " ";
                }
                
            }

            String sql = "INSERT INTO BANGDIEM(MASV, MAMH, LAN, NGAYTHI,DIEM, BAITHI) values ('"+masv+"','"+mamon+"','"+frmChuanBiThi.lan+"','"+frmChuanBiThi.ngaythi+"',"+diem+",'"+baithi+"')";
            myReader = Program.ExecSqlDataReader(sql);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát ?? ", "Xác nhận",
                       MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Dispose();
            }
        }
        public void setPanelCauHoi(string nd)
        {
            lbNoiDung.Text = nd;
        }

        private void lbNoiDung_Click(object sender, EventArgs e)
        {

        }

        private void rdA_CheckedChanged(object sender, EventArgs e)
        {
            if(rdA.Checked==true)
            {
                frmChuanBiThi.ds[i].Chon1 = "A";
            }
        }
        private void rdB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdB.Checked==true)
            {
                frmChuanBiThi.ds[i].Chon1 = "B";
            }
        }
        

        private void rdC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdC.Checked==true)
            {
                frmChuanBiThi.ds[i].Chon1 = "C";
            }
        }

        private void rdD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdD.Checked==true)
            {
                frmChuanBiThi.ds[i].Chon1 = "D";
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
