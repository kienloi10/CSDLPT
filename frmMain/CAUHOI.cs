using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmMain
{
    public class CAUHOI
    {
        private int MACH;
        private String DAP_AN;
        private String A;
        private String B;
        private String C;
        private String D;
        private String NOIDUNG;
        private String TRINHDO;
        private String Chon;
        

        public CAUHOI()
        {

        }
        public int MACH1
        {
            get
            {
                return MACH;
            }

            set
            {
                MACH = value;
            }
        }

        public string DAP_AN1
        {
            get
            {
                return DAP_AN;
            }

            set
            {
                DAP_AN = value;
            }
        }

        public string A1
        {
            get
            {
                return A;
            }

            set
            {
                A = value;
            }
        }

        public string B1
        {
            get
            {
                return B;
            }

            set
            {
                B = value;
            }
        }

        public string C1
        {
            get
            {
                return C;
            }

            set
            {
                C = value;
            }
        }

        public string D1
        {
            get
            {
                return D;
            }

            set
            {
                D = value;
            }
        }

        public string NOIDUNG1
        {
            get
            {
                return NOIDUNG;
            }

            set
            {
                NOIDUNG = value;
            }
        }

        public string TRINHDO1
        {
            get
            {
                return TRINHDO;
            }

            set
            {
                TRINHDO = value;
            }
        }

        public string Chon1
        {
            get
            {
                return Chon;
            }

            set
            {
                Chon = value;
            }
        }


        

        public CAUHOI(int mACH, string dAP_AN, string a, string b, string c, string d, string nOIDUNG)
        {
            MACH1 = mACH;
            DAP_AN1 = dAP_AN;
            A1 = a;
            B1 = b;
            C1 = c;
            D1 = d;
            NOIDUNG1 = nOIDUNG;
           
        }

    }
}
