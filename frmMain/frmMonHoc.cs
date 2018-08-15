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
    public partial class frmMonHoc : Form
    {
        int vitri = 0;
        String macn = "";
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.bODETableAdapter.Fill(this.dS.BODE);
            this.bANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.bANGDIEMTableAdapter.Fill(this.dS.BANGDIEM);
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);

            macn = ((DataRowView)bdsMH[0])["MAMH"].ToString();



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

        private void gcMH_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMH.Position;
            groupBox1.Enabled = true;
            bdsMH.AddNew();            

            txtMAMH.Text = "";
            txtTENMH.Text = "";
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcMH.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được thiếu!", "", MessageBoxButtons.OK);
                txtMAMH.Focus();
                return;
            }
            if (txtTENMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn họcs không được thiếu!", "", MessageBoxButtons.OK);
                txtTENMH.Focus();
                return;
            }
           

            try
            {
                bdsMH.EndEdit();
                bdsMH.ResetCurrentItem();
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Update(this.dS.MONHOC);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỡi ghi môn học.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcMH.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;

            groupBox1.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.mONHOCTableAdapter.Fill(this.dS.MONHOC);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsBD.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì đã có BẢNG ĐIỂM", "",
                       MessageBoxButtons.OK);
                return;
            }
            if (bdsBODE.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì đã có BỘ ĐỀ", "",
                       MessageBoxButtons.OK);
                return;
            }
            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Không thể xóa vì đã có GIẢNG VIÊN ĐĂNG KÝ", "",
                       MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa ?? ", "Xác nhận",
                       MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    // magv = int.Parse(((DataRowView)bdsGV[bdsGV.Position])["MAKH"].ToString()); // giữ lại để khi xóa bij lỗi thì ta sẽ quay về lại
                    bdsMH.RemoveCurrent();
                    // this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.mONHOCTableAdapter.Update(this.dS.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa giáo viên. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
                    //bdsGV.Position = bdsGV.Find("MAKH", magv);
                    return;
                }
            }



            if (bdsMH.Count == 0) btnXoa.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
