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
    public partial class frmBoDe : Form
    { 

        int vitri = 0;
        String macn = "";
        public frmBoDe()
        {
            InitializeComponent();
        }

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsBODE.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmBoDe_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.bODETableAdapter.Fill(this.dS.BODE);
            
            macn = ((DataRowView)bdsBODE[0])["CAUHOI"].ToString();
            if (Program.mGroup == "TRUONG")
            {
                
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnGhi.Enabled = false;
                btnUndo.Enabled = false;
                btnReload.Enabled = false;
            }
            if (Program.mGroup == "COSO")
            {
                
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnGhi.Enabled = false;
                btnUndo.Enabled = false;
                btnReload.Enabled = true;
            }
            if (Program.mGroup == "GIANGVIEN")
            {
                
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnGhi.Enabled = false;
                btnUndo.Enabled = false;
                btnReload.Enabled = false;
            }
            if (Program.mGroup == "SINHVIEN")
            {
                
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnGhi.Enabled = false;
                btnUndo.Enabled = false;
                btnReload.Enabled = false;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
