using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmMain
{
    public class BANGDIEM
    {
        private String maSV;
        private String hoSV;
        private String tenSV;
        private double diem;

        public BANGDIEM(String masv, String hosv, String tensv, double d)
        {
            maSV1 = masv;
            hoSV1 = hosv;
            tenSV1 = tensv;
            diem1 = d;
        }

        public BANGDIEM()
        {

        }

        public String maSV1
        {
            get
            {
                return maSV;
            }

            set
            {
                maSV = value;
            }
        }

        public String hoSV1
        {
            get
            {
                return hoSV;
            }

            set
            {
                hoSV = value;
            }
        }

        public String tenSV1
        {
            get
            {
                return tenSV;
            }

            set
            {
                tenSV = value;
            }
        }

        public double diem1
        {
            get
            {
                return diem;
            }

            set
            {
                diem = value;
            }
        }
    }
}