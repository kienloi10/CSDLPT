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
        public frmXemKQ()
        {
            InitializeComponent();
            PhanTichBaiThi();
        }

        private void frmXemKQ_Load(object sender, EventArgs e)
        {

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
            String cautraloi = "26-D 42-A 68-B 41-C 25-D 31- 23- 225- 69- 21- 38- 57- 52- 51- 36- 72- 67- 50- 60- 53-";
            String[] arrListStr = cautraloi.Split(' ');
            for(int i=0; i<arrListStr.Length; i++)
            {
                String[] temp = arrListStr[i].Split('-');
                String tam1 = temp[0];
                String tam2 = temp[1];
                CAUHOI chtam = new CAUHOI();
                chtam.MACH1 = Int16.Parse(tam1);
                chtam.Chon1 = tam2;
                ch.Add(chtam);
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

        }
    }
}
