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
    public partial class frmXemKQ : Form
    {
        public List<CAUHOI> ch;
        public static String malop = "";
        public static String mamonhoc = "";
        public static String lan = "";
        public static String ngay = "";
        public static String cautraloi = "";
        public static double diem = 0;
        public frmXemKQ()
        {
            InitializeComponent();
            //HienThi();
        }

        private void frmXemKQ_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "SINHVIEN")
            {
                txtHoTen.Text = Program.mHoten;
                String strlenh = "EXEC SP_TimLopCuaSV '" + Program.username + "'";
                Program.myReader = Program.ExecSqlDataReader(strlenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                txtLop.Text = Program.myReader.GetString(0);
                malop = Program.myReader.GetString(1);
                Program.myReader.Close();
                string sql = "EXEC SP_MonHocXemKQ '" + Program.username.Trim() + "'" ;
                cmbMH.DataSource = Program.ExecSqlDataTable(sql, Program.connstr);
                cmbMH.ValueMember = Program.ExecSqlDataTable(sql, Program.connstr).Columns["MAMH"].ToString();
                cmbMH.DisplayMember = Program.ExecSqlDataTable(sql, Program.connstr).Columns["TENMH"].ToString();
                if(cmbMH.SelectedValue == null)
                {
                    //Messege...
                }
                else
                {
                    mamonhoc = cmbMH.SelectedValue.ToString().Trim();
                }
            }
        }

        public void layCTCauHoi()
        {
            for(int i=0; i<ch.Count(); i++)
            {
                SqlDataReader myReader;
                String sql = "EXEC SP_LAYCHITIETCAUHOI "+ch[i].MACH1;
                myReader = Program.ExecSqlDataReader(sql);
                if(myReader.Read())
                {
                    ch[i].NOIDUNG1 = myReader.GetString(0).ToString().Trim();
                    ch[i].A1 = myReader.GetString(1).ToString().Trim();
                    ch[i].B1 = myReader.GetString(2).ToString().Trim();
                    ch[i].C1 = myReader.GetString(3).ToString().Trim();
                    ch[i].D1 = myReader.GetString(4).ToString().Trim();
                    ch[i].DAP_AN1 = myReader.GetString(5).ToString().Trim();
                }
                myReader.Close();
                
            }
            
        }

        public void PhanTichBaiThi()
        {
            ch = new List<CAUHOI>();
            //cautraloi = "26-D 42-A 68-B 41-C 25-D 31- 23- 225- 69- 21- 38- 57- 52- 51- 36- 72- 67- 50- 60- 53-";
            String[] arrListStr = cautraloi.Trim().Split(' ');
            for(int i=0; i<arrListStr.Length; i++)
            {
                String[] temp = arrListStr[i].Split('-');
                String tam1 = "";
                String tam2 = "";
                if (temp.Length==2)
                {
                    tam1 = temp[0];
                    tam2 = temp[1];
                }
                else
                {
                    tam1 = temp[0];
                }
                if(tam1 != "")
                {
                    CAUHOI chtam = new CAUHOI();
                    chtam.MACH1 = Int16.Parse(tam1);
                    chtam.Chon1 = tam2;
                    ch.Add(chtam);
                }
                
            }
            if(ch.Count!= 0)
            {
                layCTCauHoi();
            }
            else
            {
                return;
            }
        }

        public void HienThi()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("CauSo");
            dt.Columns.Add("NoiDung");
            dt.Columns.Add("CacLuaChon");
            dt.Columns.Add("DapAn");
            dt.Columns.Add("DaChon");
            PhanTichBaiThi();
            for(int i = 0; i<ch.Count; i++)
            {        
                DataRow _ravi = dt.NewRow();
                _ravi["CauSo"] = ch[i].MACH1;
                _ravi["NoiDung"] = ch[i].NOIDUNG1;
                _ravi["CacLuaChon"] = "A: " + ch[i].A1 +Environment.NewLine 
                                       + " B: " + ch[i].B1+ Environment.NewLine
                                      + " C: " + ch[i].C1 + "\n"
                                       + " D: " + ch[i].D1 + "\n".Replace("\n",
                                                         Environment.NewLine); ;
                _ravi["DapAn"] = ch[i].DAP_AN1;
                _ravi["DaChon"] = ch[i].Chon1;
                dt.Rows.Add(_ravi);
            }
            
            this.gvCH.DataSource = dt;
        }

        private void cmbMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mamonhoc.Trim() == "")
            {
                return;
            }
            mamonhoc = cmbMH.SelectedValue.ToString().Trim();
            //SqlDataReader myReader;
            /*string sql1 = "EXEC SP_LanXemKQ '" + Program.username.Trim() + "','" + mamonhoc + "'" ;
            cmbNgay.DataSource = Program.ExecSqlDataTable(sql1, Program.connstr);
            cmbNgay.ValueMember = Program.ExecSqlDataTable(sql1, Program.connstr).Columns["LAN"].ToString();
            cmbNgay.DisplayMember = Program.ExecSqlDataTable(sql1, Program.connstr).Columns["LAN"].ToString();*/

            
            
        }

        private void cmbNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lan = cmbNgay.SelectedValue.ToString().Trim();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lan = textBox2.Text.Trim();
            string sql = "EXEC SP_LAYDSCHSAUKHITHI '"+Program.username+"','"+mamonhoc+"','"+lan+"'";
            SqlDataReader myReader;
            myReader = Program.ExecSqlDataReader(sql);
            if(myReader.Read())
            {
                cautraloi = myReader.GetString(0);
                diem = myReader.GetDouble(1);
                ngay = myReader.GetDateTime(2).ToString();
                txtNgay.Text = ngay;
                txtDiem.Text = diem.ToString();
                myReader.Close();
                HienThi();
            }
            else
            {
                myReader.Close();
                //messege
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
