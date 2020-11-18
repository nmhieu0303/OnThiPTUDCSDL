using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
     public class DTO_SINHVIEN
    {
        private string MaSV;
        private string HoTen;
        private DateTime NgaySinh;
        private bool Phai;
        private string Lop;
        private float DTB;
        

        public DTO_SINHVIEN()
        {
            MaSV = HoTen = Lop = "";
            Phai = true;
            DTB = 0;
            NgaySinh = new DateTime(1900,1,1);
        }

        public DTO_SINHVIEN(string masv,string hoten, string lop,bool phai, float dtb,DateTime ngaysinh)
        {
            MaSV = masv;
            HoTen = hoten;
            Lop = lop;
            Phai = phai;
            DTB = dtb;
            NgaySinh = ngaysinh;
        }

        public DTO_SINHVIEN(DTO_SINHVIEN sv)
        {
            MaSV = sv.MaSV;
            HoTen = sv.HoTen;
            Lop = sv.Lop;
            Phai = sv.Phai;
            DTB = sv.DTB;
            NgaySinh = sv.NgaySinh;
        }
        public DTO_SINHVIEN(ref DTO_SINHVIEN sv1 , DTO_SINHVIEN sv2)
        {
            sv1.MaSV = sv2.MaSV;
            sv1.HoTen = sv2.HoTen;
            sv1.Lop = sv2.Lop;
            sv1.Phai = sv2.Phai;
            sv1.DTB = sv2.DTB;
            sv1.NgaySinh = sv2.NgaySinh;
        }

        public string docGhiMaSV
        {
            get { return MaSV; }
            set { MaSV = value; }
        }

        public string docGhiHoTen
        {
            get { return HoTen; }
            set { HoTen = value; }
        }
        public string docGhiLop
        {
            get { return Lop; }
            set { Lop = value; }
        }
        public bool docGhiPhai
        {
            get { return Phai; }
            set { Phai = value; }
        }
        public float docGhiDTB
        {
            get { return DTB; }
            set { DTB = value; }
        }
        public DateTime docGhiNgaySinh
        {
            get { return NgaySinh; }
            set { NgaySinh = value; }
        }
    }
}
