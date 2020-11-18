using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BUS;


namespace BUS
{
    public class BUS_Lop
    {
        BUS_SinhVien busSV = new BUS_SinhVien();
        public DTO_Lop inputLop()
        {
            DTO_Lop lop = new DTO_Lop();
            Console.Write("MaLop :");
            lop.docGhiMaLop = Console.ReadLine();
            Console.Write("Khoa :");
            lop.docGhiKhoa = Console.ReadLine();
            Console.Write("Loai :");
            lop.docGhiMaLop = Console.ReadLine();
            Console.Write("LopTruong :");
            lop.docGhiLopTruong = Console.ReadLine();
            return lop;
        }
        public void outputLop(DTO_Lop lop)
        {
            Console.WriteLine("MaLop : {0}", lop.docGhiMaLop);            
            Console.WriteLine("Khoa : {0}", lop.docGhiKhoa);            
            Console.WriteLine("Loai : {0}", lop.docGhiMaLop);            
            Console.WriteLine("LopTruong : {0}", lop.docGhiLopTruong);
        }
        public DTO_SINHVIEN timLopTruong(DTO_Lop lop,List<DTO_SINHVIEN> list)
        {
            DTO_SINHVIEN lopTruong = list.Find(sv => sv.docGhiMaSV == lop.docGhiLopTruong);
            return lopTruong;
        }
        public void filterByClass (List<DTO_SINHVIEN> list,string idClass)
        {
            foreach(var sv in list)
            {
                if (sv.docGhiLop == idClass) busSV.outputSV(sv);
            }
        }
        public float scoreMaxOfClass(List<DTO_SINHVIEN> list, string idClass)
        {
            float max = 0;
            foreach (var sv in list)
            {
                if (sv.docGhiLop == idClass && sv.docGhiDTB>= max) max = sv.docGhiDTB;
            }
            return max;
        }
        public void filterByScore(List<DTO_SINHVIEN> list,string idClass, float score)
        {
            foreach (var sv in list)
            {
                if (sv.docGhiLop == idClass && sv.docGhiDTB == score) busSV.outputSV(sv);
            }
        }
        public DTO_Lop findClassWithID(List<DTO_Lop> list, string id)
        {
            return list.Find(item => item.docGhiMaLop == id);
        }

      
    }
}
