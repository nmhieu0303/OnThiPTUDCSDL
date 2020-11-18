using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnThi
{
    class Program
    {
        protected static SqlConnection connection = new SqlConnection("Data Source=HOMEPHO-K8TC9OO;Initial Catalog=SINHVIEN;Integrated Security=True");
        static void Main(string[] args)
        {
            int choice = -1;
            string id, year, semester;
            DataTable dt;
            do
            {
                Console.WriteLine("\n\t\t====Menu======");
                Console.WriteLine("1. Tinh tong tinh chi cua mot sinh vien trong 1 hoc ky");
                Console.WriteLine("2 Tra ve ket qua hoc tap cua 1 sinh vien torng 1 hoc ky");
                Console.WriteLine("0.Thoat");
                Console.Write("Nhap lua chon : ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap nam hoc : ");
                        year=  Console.ReadLine();
                        Console.Write("Nhap hoc ky: ");
                        semester = Console.ReadLine();
                        Console.Write("Nhap mssv: ");
                        id = Console.ReadLine();
                        int rs = countCreditsOfStudent(year, semester, id); 
                        Console.WriteLine("\n====Tong tin chi cua sinh vien {0} trong hoc ky {1} nam {2} la {3} tin chi",id,semester,year,rs);
                        break;
                    case 2:
                        Console.Write("Nhap nam hoc : ");
                        year = Console.ReadLine();
                        Console.Write("Nhap hoc ky: ");
                        semester = Console.ReadLine();
                        Console.Write("Nhap mssv: ");
                        id = Console.ReadLine();
                        dt = usp_learningOutcomes(id, semester, year);
                        foreach (DataRow row in dt.Rows)
                        {
                            Console.WriteLine("");
                            foreach (var item in row.ItemArray)
                            {
                                Console.Write(item);
                                Console.Write("  ---  ");
                            }
                        }


                        break;
                }
            } while (choice != 0);

          
            
        }
        public static void openConnect()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public static void closeConnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static int countCreditsOfStudent(string @schoolYear, string @semester, string @idStudent)
        {
            int rs;
            var cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT dbo.countCreditsOfStudent(@schoolYear,@semester, @idStudent)";
            cmd.Parameters.Add(new SqlParameter("@schoolYear", @schoolYear));
            cmd.Parameters.Add(new SqlParameter("@semester", @semester));
            cmd.Parameters.Add(new SqlParameter("@idStudent", @idStudent));
            openConnect();
            var strRs = cmd.ExecuteScalar().ToString();
            if (strRs != "")
            {
                rs = int.Parse(strRs.ToString());
            }
            else rs = 0;
            closeConnect();
            return rs;
        }

        public static DataTable usp_learningOutcomes(string idStudent, string semester, string schoolYear)
        {
            var dt = new DataTable();
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "EXEC usp_learningOutcomes @idStudent,@semester, @schoolYear ";
            cmd.Parameters.Add(new SqlParameter("@schoolYear", schoolYear));
            cmd.Parameters.Add(new SqlParameter("@semester", semester));
            cmd.Parameters.Add(new SqlParameter("@idStudent", idStudent));

            openConnect();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            closeConnect();
            return dt;
        }
    }
}
