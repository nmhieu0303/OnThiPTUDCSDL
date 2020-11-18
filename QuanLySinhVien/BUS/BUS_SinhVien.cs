using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_SinhVien
    {
        DAL_SINHVIEN dalsv = new DAL_SINHVIEN();
        DBConnect dbConnect = new DBConnect();
        
        public DTO_SINHVIEN inputSV()
        {
            DTO_SINHVIEN sv = new DTO_SINHVIEN();
            float dtb;

            Console.Write("MaSV :");
            sv.docGhiMaSV =  Console.ReadLine();
            Console.Write("Ten :");
            sv.docGhiHoTen = Console.ReadLine();
            Console.Write("Ngay sinh :");
            sv.docGhiNgaySinh = DateTime.Parse(Console.ReadLine());

            Console.Write("Phai (Nam:1/Nu:0) :");
            var gender = Console.ReadLine();
            if (gender == "1") sv.docGhiPhai = true;
            else if(gender =="0") sv.docGhiPhai = false;

            Console.Write("Lop :");
            sv.docGhiLop = Console.ReadLine();
            Console.Write("Diem trung binh :");
            float.TryParse(Console.ReadLine(), out dtb);
            sv.docGhiDTB = dtb;
            return sv;
        }
        public void outputSV(DTO_SINHVIEN sv)
        {
            Console.WriteLine("MaSV : {0}", sv.docGhiMaSV);
            Console.WriteLine("Ten : {0}", sv.docGhiHoTen);
            Console.WriteLine("Ngay sinh : {0}", sv.docGhiNgaySinh);
            Console.WriteLine("Phai : {0}", sv.docGhiPhai == true ? "nam":"nu");
            Console.WriteLine("Diem trung binh : {0}", sv.docGhiDTB);
            Console.WriteLine("Lop : {0}", sv.docGhiLop);
        }
        public void outputSV(string id,string name,string birth,string gender,float score,string idClass)
        {
            Console.WriteLine("MaSV : {0}", id);
            Console.WriteLine("Ten : {0}", name);
            Console.WriteLine("Ngay sinh : {0}", birth);
            Console.WriteLine("Phai : {0}", gender);
            Console.WriteLine("Diem trung binh : {0}", score);
            Console.WriteLine("Lop : {0}", idClass);
        }
        public void inputListStudent(List<DTO_SINHVIEN> list,int n)
        {
            Console.WriteLine("\t\t\t------Nhap danh sach sinh vien---------");
            for(var i = 0; i < n; i++)
            {
                Console.WriteLine("------Sinh vien thu {0}---------",i+1);
                list.Add(inputSV());
            }
        }
        public void outputListStudent() { 
            var dt = dbConnect.loadData("SELECT * FROM SINHVIEN");
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine("\n-----Sinh vien {0}------",i+1);
                outputSV(dt.Rows[i]["MaSV"].ToString(), dt.Rows[i]["HoTen"].ToString(), dt.Rows[i]["NgaySinh"].ToString(),
                    dt.Rows[i]["Phai"].ToString(), float.Parse(dt.Rows[i]["DTB"].ToString()), dt.Rows[i]["Lop"].ToString());
            }
        }
        public float scoreMax(List<DTO_SINHVIEN> list)
        {
            var result = list.Max(x => x.docGhiDTB);
            return result;
        }
        public float scoreMin(List<DTO_SINHVIEN> list)
        {
            var result = list.Min(x => x.docGhiDTB);
            return result;
        }
        public void findStudentWithScore(List<DTO_SINHVIEN> list,float score)
        {
            DTO_SINHVIEN sv = list.Find(item => item.docGhiDTB == score);
            outputSV(sv);
        }
        public DTO_SINHVIEN findStudentWithID(List<DTO_SINHVIEN> list, string id)
        {
            foreach (var sv in list)
            {
                if (sv.docGhiMaSV == id) return sv;
            }
            return null;
        }
        public void filterByGender(List<DTO_SINHVIEN> list, bool gender)
        {
            foreach(var sv in list)
            {
                if (sv.docGhiPhai == gender) outputSV(sv);
            }
        }

        /*
        public float avgScoreOfList(List<DTO_SINHVIEN> list)
        {
            return list.Average(sv => sv.docGhiDTB);

           
        }

        public void searchSV (string id)
        {
            
            DTO_SINHVIEN sv =  dalsv.selectStudentById(id);
            if (sv == null) Console.WriteLine("Khong ton tai SV co MaSV {0}", id);
            else outputSV(sv);
        }
        public void printListStudentByIdClass(string idClass)
        {
            string strSql;
            DataTable dt = new DataTable();
            strSql = string.Format( $"SELECT * FROM SINHVIEN WHERE Lop = '{idClass}'");
            dt = dbConnect.loadData(strSql);
            for(var i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine("MaSV: {0}",dt.Rows[i]["MaSV"].ToString());
            }
        }
        */
        public void printDataTable(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                    Console.WriteLine(item);
                Console.WriteLine("\n");
            }
        }
    }
}
