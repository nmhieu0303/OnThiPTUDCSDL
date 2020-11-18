using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BUS;
using DAL;
using System.Data;

namespace QuanLySinhVien
{
    class Program
    {
        public static BUS_SinhVien busSV = new BUS_SinhVien();
        public static BUS_Lop busLop = new BUS_Lop();
        public static BUS_DKHP busDK = new BUS_DKHP();
        public static DAL_SINHVIEN dalSV = new DAL_SINHVIEN();
        public static DBConnect dbConnect = new DBConnect();
        public static List<DTO_SINHVIEN> list = new List<DTO_SINHVIEN>();
        public static List<DTO_Lop> listClass = new List<DTO_Lop>();
        public static List<DTO_DKHP> listCourse = new List<DTO_DKHP>();


        static void Main(string[] args)
        {

            menu();
            
            Console.ReadKey();
        }

        public static void menu()
        {
            int choice = -1;
            string idLop;
            DTO_Lop lop = new DTO_Lop();
            menuSV();
        }

        public static void menuSV()
        {
            int choice = -1;
            do
            {

                Console.WriteLine("\t\t=====MENU SINH VIEN=====");
                //Console.WriteLine("1. Truy xuat du lieu tu cau truy van bat ky");
                //Console.WriteLine("2. Them thong tin mot sinh vien");
                //Console.WriteLine("3. Xuat danh sach sinh vien");
                //Console.WriteLine("4. Xoa sinh vien bang id");
                //Console.WriteLine("5. Cap nhat sinh vien bang id");
                //Console.WriteLine("6. Diem trung binh cua sinh vien bang id");


                Console.WriteLine("1. Xuat danh sach lop truong cua truong");
                Console.WriteLine("2 Xuat danh sach sinh vien theo ma lop");
                Console.WriteLine("3. Tong so sinh vien cua truong ");
                Console.WriteLine("4. Diem trung binh cua mot sinh vien");
                Console.WriteLine("5. Xuat ket qua dang ky hoc phan cua mot sinh vien trong mot hoc ky");

                Console.WriteLine("0. Thoat");
                Console.Write("Lua chon cua ban : ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Vui long kiem tra lai lua chon!!");
                    choice = -1;
                    continue;
                }
                Console.Clear();
                switch (choice)
                {
                    //case 1:
                    //    Console.WriteLine("\t\t\t1. Truy xuat du lieu tu cau truy van bat ky");
                    //    Console.Write("Nhap query : ");
                    //    var str = Console.ReadLine();
                    //    var dt = dbConnect.loadData(str);
                    //    foreach (DataRow row in dt.Rows)
                    //    {
                    //        foreach(var item in row.ItemArray)
                    //            Console.WriteLine(item);
                    //        Console.WriteLine("\n");
                    //    }
                    //    break;
                    //case 2:
                    //    Console.WriteLine("\t\t\t2. Them thong tin mot sinh vien");            
                    //    dalSV.addStudentToDB(busSV.inputSV());
                    //    break;
                    //case 3:
                    //    Console.WriteLine("\t\t\t3. Xuat danh sach sinh vien");
                    //    busSV.outputListStudent();
                    //    break;
                    //case 4:
                    //    Console.WriteLine("\t\t\t4. Xoa sinh vien bang id");
                    //    Console.Write("ID sinh vien : ");
                    //    var id = Console.ReadLine();
                    //    dalSV.deleteStudentById(id);
                    //    break;
                    //case 5:
                    //    Console.WriteLine("\t\t\t5. Cap nhat sinh vien bang id");
                    //    Console.Write("ID sinh vien : ");
                    //    id = Console.ReadLine();
                    //    busSV.outputSV( dalSV.selectStudentById(id));
                    //    Console.WriteLine("\tThong tin moi cua sinh vien");
                    //    var datanew = busSV.inputSV();
                    //    dalSV.updateStudentById(id,datanew);
                    //    break;
                    //case 6:
                    //    Console.WriteLine("\t\t\t6. Diem trung binh cua sinh vien bang id");
                    //    Console.Write("ID sinh vien : ");
                    //    id = Console.ReadLine();
                    //    var score = dalSV.getScoreById(id);
                    //    if (score == -1)
                    //    {
                    //        Console.WriteLine("\tSinh vien {0} khong ton tai", id );
                    //    }
                    //    else Console.WriteLine("\tDiem trung binh cua sinh vien {0} : {1}",id, score);
                    //    break;
                    case 1:
                        Console.WriteLine("\t\t\t1. Xuat danh sach lop truong cua truong");
                        busSV.printDataTable(dalSV.usp_selectLeadersInSchool());
                        break;

                    case 2:
                        Console.WriteLine("\t\t\t2 Xuat danh sach sinh vien theo ma lop");
                        Console.Write("Nhap id lop: ");
                        var idClass = Console.ReadLine();
                        Console.WriteLine("\t\t\tDanh sach sinh vien cua lop {0}",idClass);
                        busSV.printDataTable(dalSV.usp_selectStudentByIdClass(idClass));
                        break;
                    case 3:
                        Console.WriteLine("\t3. Tong so sinh vien cua truong : {0} \n",dalSV.uf_countStudent());
                        break;
                    case 4:
                        Console.WriteLine("\t4. Diem trung binh cua mot sinh vien");
                        Console.Write("Nhap id sinh vien : ");
                        var id = Console.ReadLine();
                        Console.WriteLine("\tDiem trung binh cua {0} la {1}",id,dalSV.uf_avgScore(id));
                        break;
                    case 5:
                        Console.WriteLine("5 Xuat ket qua dang ky hoc phan cua mot sinh vien trong mot hoc ky");
                        Console.Write("Nhap id sinh vien : ");
                        id = Console.ReadLine();
                        Console.Write("Nhap hoc ky : ");
                        var semester = Console.ReadLine();
                        Console.Write("Nhap nam hoc : ");
                        var schoolYear = Console.ReadLine();
                        Console.WriteLine("\tKet qua dang ky cua {0} trong hoc ky {1} nam ", id, semester,schoolYear);
                        busSV.printDataTable(dalSV.usp_courseRegistrationResults(id, semester, schoolYear));
                        break;
                    case 0: break;
                    default:
                        Console.WriteLine("\t===Chuc nang khong ton tai");
                        break;
                }
            } while (choice != 0);
            Console.Clear();
        }
    }
}
