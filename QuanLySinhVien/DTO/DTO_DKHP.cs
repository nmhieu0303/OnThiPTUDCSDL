using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DKHP
    {
        private string NH;
        private string HK;
        private string MaSV;
        private string MaMH;
        private int SoTC;
        private string DiaDiem;
        private float Diem;


        public string docGhiNamHoc
        {
            get { return NH; }
            set { NH = value; }
        }
        public string docGhiHocKi
        {
            get { return HK; }
            set { HK = value; }
        }
        public string docGhiMaSV
        {
            get { return MaSV; }
            set { MaSV = value; }
        }
        public string docGhiMaMH
        {
            get { return MaMH; }
            set { MaMH = value; }
        }
        public int docGhiSoTC
        {
            get { return SoTC; }
            set { SoTC = value; }
        }
        public string docGhiDiaDiem
        {
            get { return DiaDiem; }
            set { DiaDiem = value; }
        }
        public float docGhiDiem
        {
            get { return Diem; }
            set { Diem = value; }
        }

        public DTO_DKHP()
        {
             SoTC = 0;
            Diem = 0;
            NH = HK = MaSV = MaMH = DiaDiem = "";
    }

        public DTO_DKHP(string nh, string hk, string masv,string mamh, int sotc, string diadiem, float diem)
        {
            NH = nh;
            HK = hk;
            SoTC = sotc;
            Diem = diem;
            MaSV = masv;
            MaMH = mamh;
            DiaDiem = diadiem; 
        }

        public DTO_DKHP(DTO_DKHP hp)
        {
            NH = hp.NH;
            HK = hp.HK;
            SoTC = hp.SoTC;
            Diem = hp.Diem;
            MaSV = hp.MaSV;
            MaMH = hp.MaMH;
            DiaDiem = hp.DiaDiem; 
        }
    }
}
