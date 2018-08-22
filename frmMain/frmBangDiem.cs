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
    public partial class frmBangDiem : Form
    {
        List<BANGDIEM> bd;
        String malop;
        String mamh;
        int lan;

        public frmBangDiem()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tRACNGHIEMDataSet);

        }

        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.tRACNGHIEMDataSet.MONHOC);
            // TODO: This line of code loads data into the 'tRACNGHIEMDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.tRACNGHIEMDataSet.LOP);

        }
        public List<BANGDIEM> DsDiem()
        {
            //var a = new List<CAUHOI>();
            DataTable dt;
            
            String strLenh = "EXEC SP_BANGDIEM '" + malop + "','" + mamh + "'," + lan;
            dt = Program.ExecSqlDataTable(strLenh, Program.connstr);
            if (dt == null) return null;


            List<BANGDIEM> listBD = dt.AsEnumerable().Select(m => new BANGDIEM(m.Field<String>("MASV"), m.Field<String>("HOSV"), m.Field<String>("TENSV"), m.Field<double>("DIEM"))
            ).ToList();
            return listBD;
        }


        private void btnINDIEM_Click(object sender, EventArgs e)
        {
            /*malop = cmbTENLOP.SelectedValue.ToString().Trim();
            mamh = cmbTENMH.SelectedValue.ToString().Trim();
            lan = Int16.Parse(txtLan.ToString().Trim());
            String sql = "EXEC SP_BANGDIEM '"+malop+"','"+mamh+"',"+lan;
            Program.myReader = Program.ExecSqlDataReader(sql);
            if (Program.myReader == null) return;
            while(Program.myReader.Read())
            {
                BANGDIEM temp = new BANGDIEM(Program.myReader.GetString(0).Trim(), 
                    Program.myReader.GetString(1).Trim(), 
                    Program.myReader.GetString(2).Trim(), 
                    Program.myReader.GetDouble(4));
                bd.Add(temp);
            }*/
            rptBangDiem2 obj;
            obj = new rptBangDiem2();
            malop = cmbTENLOP.SelectedValue.ToString().Trim();
            mamh = cmbTENMH.SelectedValue.ToString().Trim();
            lan = Int16.Parse(txtLan.ToString().Trim());
            String sql = "EXEC SP_BANGDIEM '" + malop + "','" + mamh + "'," + lan;
            DataTable myDataTable;
            myDataTable = Program.ExecSqlDataTable(sql,Program.connstr);
            obj.SetDataSource(myDataTable);
            obj.SetParameterValue("LOP", cmbTENLOP.SelectedText.ToString().Trim());
            obj.SetParameterValue("MONHOC", cmbTENMH.SelectedText.ToString().Trim());
            obj.SetParameterValue("LAN", lan);
            crptView.ReportSource = obj;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
