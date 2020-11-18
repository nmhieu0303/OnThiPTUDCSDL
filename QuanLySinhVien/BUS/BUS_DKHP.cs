using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class BUS_DKHP
    {
        BUS_SinhVien busSV = new BUS_SinhVien();
        public DTO_DKHP input()
        {

            DTO_DKHP dk = new DTO_DKHP();
            float score;

            Console.Write("Nam hoc :");
            dk.docGhiNamHoc = Console.ReadLine();
            Console.Write("Hoc ki :");
            dk.docGhiHocKi = Console.ReadLine();
            Console.Write("Ma sinh vien :");
            dk.docGhiMaSV = Console.ReadLine();
            Console.Write("Ma mon hoc :");
            dk.docGhiMaMH = Console.ReadLine();
            Console.Write("Số tính chỉ:");
            dk.docGhiSoTC = int.Parse(Console.ReadLine());
            Console.Write("Dia diem :");
            dk.docGhiDiaDiem = Console.ReadLine();
            Console.Write("Diem :");
            float.TryParse(Console.ReadLine(), out score);
            dk.docGhiDiem = score;
            return dk;
        }
        public void output(DTO_DKHP dk)
        {
            Console.WriteLine("Nam hoc : {0}", dk.docGhiNamHoc);
            Console.WriteLine("Hoc ki : {0}", dk.docGhiHocKi);
            Console.WriteLine("Ma sinh vien : {0}", dk.docGhiMaSV);
            Console.WriteLine("Ma mon hoc : {0}", dk.docGhiMaMH);
            Console.WriteLine("SSo tinh chi : {0}", dk.docGhiSoTC);
            Console.WriteLine("Dia diem : {0}", dk.docGhiDiaDiem);
            Console.WriteLine("Diem : {0}", dk.docGhiDiem);
        }

        public void printInfoAndListCourseOfStudent(List<DTO_DKHP> listCourse, List<DTO_SINHVIEN> listStudent, string id)
        {
            var sv = busSV.findStudentWithID(listStudent, id);
            if (sv != null)
            {
                busSV.outputSV(sv);
                listCourseOfStudent(listCourse, id);
            }
            else Console.WriteLine("Sinh vien {0} khong ton tai",id);
        }

        public void listCourseOfStudent(List<DTO_DKHP> listCourse, string id)
        {
            foreach (var course in listCourse)
            {
                if (course.docGhiMaSV == id) output(course);
                Console.WriteLine("");
            }
        }

        public void printCourseCreditsLess10(List<DTO_DKHP> listCourse)
        {
            foreach (var course in listCourse)
            {
                if (course.docGhiSoTC <10) output(course);
                Console.WriteLine("");
            }
        }

    }
}
