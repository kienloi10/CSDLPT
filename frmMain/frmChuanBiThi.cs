using System;
using System.Collections;
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
    public partial class frmChuanBiThi : Form
    {
        public static List<CAUHOI> ds;
        public static int socauthi;
        public static int socaudk;
        public static String mamonhoc = "";
        public static String ngaythi = DateTime.Now.ToString("yyyy-MM-dd").Trim();
        public static String malop = "";
        public static String trinhdo = "";
        public static int thoigian;
        public static int lan;
        public frmChuanBiThi()
        {
            InitializeComponent();
        }
        public List<CAUHOI> DsCauHoi(int socauthi, String Trinhdo, String MaMH, String MaLop)
        {
            //var a = new List<CAUHOI>();
            DataTable dt;

            String strLenh = "EXEC SP_LAYCAUHOITHI '" + MaMH + "','" + socauthi + "','" + Trinhdo + "','" + MaLop + "'";
            dt = Program.ExecSqlDataTable(strLenh,Program.connstr);
            if (dt == null) return null;


            List<CAUHOI> listCauHoi = dt.AsEnumerable().Select(m => new CAUHOI(m.Field<int>("CAUHOI"), m.Field<string>("DAP_AN")
                , m.Field<string>("A"), m.Field<string>("B"), m.Field<string>("C"), m.Field<string>("D"), m.Field<string>("NOIDUNG"))
            {

                //MACH1 = m.Field<int>("CAUHOI"),
                //MAMH1 = m.Field<string>("MAMH"),
                //TRINHDO1 = m.Field<string>("TRINHDO"),
               /* NOIDUNG1 = m.Field<string>("NOIDUNG"),
                A1 = m.Field<string>("A"),
                B1 = m.Field<string>("B"),
                C1 = m.Field<string>("C"),
                D1 = m.Field<string>("D"),
                DAP_AN1 = m.Field<char>("DAP_AN"),*/
                //MAGV1 = m.Field<string>("MAGV"),
            }).ToList();
            return listCauHoi;
        }
        private void frmChuanBiThi_Load(object sender, EventArgs e)
        {

            txtHoTen.Enabled = false;
            txtMaSV.Enabled = false;
            txtLop.Enabled = false;

            //MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd").Trim(), "Ngày hôm nay", MessageBoxButtons.OK);


            if (Program.mGroup == "SINHVIEN")
            {
                    txtHoTen.Text = Program.mHoten;
                    txtMaSV.Text = Program.username;

                    String strlenh = "EXEC SP_TimLopCuaSV '" + Program.username + "'";
                    Program.myReader = Program.ExecSqlDataReader(strlenh);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();
                    
                    txtLop.Text = Program.myReader.GetString(0);
                    malop = Program.myReader.GetString(1);
                Program.myReader.Close();
                    


                    string sql = " EXEC SP_MonHocCuaSinhVienThi '" + Program.username.Trim() + "','"+ngaythi+"'";
                   // SqlCommand com = new SqlCommand(sql, Program.conn);
                   // SqlDataAdapter da = new SqlDataAdapter(com);
                   // DataTable dt = new DataTable();
                   // da.Fill(Program);
                    cmbMH.DataSource = Program.ExecSqlDataTable(sql,Program.connstr);
                    cmbMH.ValueMember = Program.ExecSqlDataTable(sql, Program.connstr).Columns["MAMH"].ToString();
                    cmbMH.DisplayMember = Program.ExecSqlDataTable(sql, Program.connstr).Columns["TENMH"].ToString();

                
                
                mamonhoc = cmbMH.SelectedValue.ToString();

                /*String sql1 = "EXEC SP_LAYLANTHI '" + mamonhoc.ToString().Trim() + "','" + txtLop.Text.ToString().Trim() + "','" + ngaythi.ToString().Trim() + "'";
                Program.myReader = Program.ExecSqlDataReader(sql1);
                if (Program.myReader == null) return;
                Program.myReader.Read();

            //txtChonLan.Text = Program.myReader.GetInt32(0).ToString().Trim();
                MessageBox.Show(Program.myReader.GetInt32(0).ToString());
                Program.myReader.Close();
                Program.conn.Close();*/
                if (cmbMH.SelectedValue == null)
                {
                    MessageBox.Show("Lớp của sinh viên chưa có môn nào được đăng kí");

                }
                else
                {
                    int lanthi;
                    SqlDataReader myReader;
                    String sql1 = "SELECT GIAOVIEN_DANGKY.LAN,GIAOVIEN_DANGKY.TRINHDO,GIAOVIEN_DANGKY.SOCAUTHI,GIAOVIEN_DANGKY.THOIGIAN FROM GIAOVIEN_DANGKY WHERE MAMH = '" + mamonhoc.Trim() + "' AND MALOP = '" + malop.Trim() + "' AND NGAYTHI = '" + ngaythi + "'";
                    myReader = Program.ExecSqlDataReader(sql1);
                    myReader.Read();
                    /*if(myReader.Read())
                    {*/

                    lanthi = myReader.GetInt16(0);
                    lan = myReader.GetInt16(0);
                    trinhdo = myReader.GetString(1);
                    socaudk = myReader.GetInt16(2);
                    txtChonLan.Text = lanthi.ToString();
                    thoigian = myReader.GetInt16(3);
                    myReader.Close();
                    //}
                } 

                
          
                    
                    Program.conn.Close();
            }


            if (Program.mGroup == "GIANGVIEN")
                {
                    txtHoTen.Text = Program.mHoten;
                    txtMaSV.Text = Program.username;
                    txtLop.Text = "";
                }

            

           

        }

       

        private void btnHuy_Click(object sender, EventArgs e)
        {
             this.Dispose();
           // MessageBox.Show(mamonhoc, "", MessageBoxButtons.OK);
        }

        private void btnThi_Click(object sender, EventArgs e)
        {
            frmThi f;
            ds = new List<CAUHOI>();
            //ds = DsCauHoi(3, "A", "AVCB", "TH04");
            ds = DsCauHoi(socaudk, trinhdo.Trim(), mamonhoc.Trim(), malop.Trim());


            if (ds.Count == 0)
            {
                return;
            }


            socauthi = ds.Count();
            Form frm = Program.frmChinh.CheckExists(typeof(frmThi));
            if (frm != null)
            {
                frm.Activate();
            }

            else
            {
                f = new frmThi();
                f.MdiParent = Program.frmChinh;
                f.Show();

            }
           
           /* if(ds.Count == 0)
            {
                return;
            }
            else
            {
                f.setPanelCauHoi(ds[0].NOIDUNG1);
            }*/
        }

        private void cmbMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mamonhoc.Trim() == "")
            {
                return;
            }
            mamonhoc = cmbMH.SelectedValue.ToString().Trim();
            int lanthi;
            SqlDataReader myReader;
            String sql1 = "SELECT GIAOVIEN_DANGKY.LAN,GIAOVIEN_DANGKY.TRINHDO,GIAOVIEN_DANGKY.SOCAUTHI FROM GIAOVIEN_DANGKY WHERE MAMH = '" + mamonhoc.Trim() + "' AND MALOP = '" + malop.Trim() + "' AND NGAYTHI = '" + ngaythi + "'";
            myReader = Program.ExecSqlDataReader(sql1);
            myReader.Read();
            /*if(myReader.Read())
            {*/

            lanthi = myReader.GetInt16(0);
            lan = myReader.GetInt16(0);
            trinhdo = myReader.GetString(1);
            socaudk = myReader.GetInt16(2);
            txtChonLan.Text = lanthi.ToString();
            myReader.Close();
        }
    }
}
