using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Lop
    {
        private string MaLop;
        private string Khoa;
        private string Loai;// loại lớp(CQ, TN, TT, CLC,…)
        private string LopTruong;

      

        public string docGhiMaLop
        {
            get { return MaLop; }
            set { MaLop = value; }
        }
        public string docGhiKhoa
        {
            get { return Khoa; }
            set { Khoa = value; }
        }
        public string docGhiLoai
        {
            get { return Loai; }
            set { Loai = value; }
        }
        public string docGhiLopTruong
        {
            get { return LopTruong; }
            set { LopTruong = value; }
        }
        public DTO_Lop()
        {
            MaLop = Khoa = Loai = LopTruong = "";
        }
        public DTO_Lop(string malop, string khoa, string loai, string loptruong)
        {
            MaLop = malop;
            Khoa = khoa;
            Loai = loai;
            LopTruong = loptruong;
        }

        public DTO_Lop(DTO_Lop lop)
        {
            MaLop = lop.MaLop;
            Khoa = lop.Khoa;
            Loai = lop.Loai;
            LopTruong = lop.LopTruong;
        }



    }


}

