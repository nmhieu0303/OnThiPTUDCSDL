using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    public class DAL_SINHVIEN:DBConnect
    {
        
        public DTO_SINHVIEN selectStudentById(string id)
        {
            var dt = new DataTable();
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();
            cmd.CommandText = string.Format($"SELECT * FROM SINHVIEN WHERE MaSV = '{id}'");
            cmd.Connection = connection;
            adapter.SelectCommand = cmd;

            OpenConnection();
            adapter.Fill(dt);
            CloseConnection();
            DTO_SINHVIEN student = new DTO_SINHVIEN();
            if (dt.Rows.Count > 0)
            {
                student.docGhiMaSV = dt.Rows[0]["MaSV"].ToString();
                student.docGhiHoTen = dt.Rows[0]["HoTen"].ToString();
                student.docGhiNgaySinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
                student.docGhiPhai = (dt.Rows[0]["Phai"] == "Nam") ? true : false;
                student.docGhiLop = dt.Rows[0]["Lop"].ToString();
                student.docGhiDTB = float.Parse(dt.Rows[0]["DTB"].ToString());
                return student;
            }
            else return null;
        }

        public void addStudentToDB(DTO_SINHVIEN student)
        {
            var gender = student.docGhiPhai == true ? "Nam" : "Nữ";
            OpenConnection();
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format($"INSERT INTO SINHVIEN " +
                $"VALUES ('{student.docGhiMaSV}',N'{student.docGhiHoTen}','{student.docGhiNgaySinh}',N'{gender}','{student.docGhiLop}',{student.docGhiDTB})");
            cmd.Connection = connection;
            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("\t\t\t============= DANH SACH SINH VIEN =============\n");
                var dt = loadData("SELECT * FROM SINHVIEN");
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    Console.WriteLine("MaSV: {0}", dt.Rows[i]["MaSV"].ToString());
                }
            }
            CloseConnection();
        }

        public void deleteStudentById(string id)
        {
            OpenConnection();
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format($"DELETE FROM SINHVIEN WHERE MaSV = {id}");
            cmd.Connection = connection;
            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("\tXóa thành công");
            }
            CloseConnection();
        }
        public void updateStudentById(string id,DTO_SINHVIEN student)
        {
            var gender = student.docGhiPhai == true ? "Nam" : "Nu";
            OpenConnection();
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format($"UPDATE SINHVIEN SET MaSV = '{student.docGhiMaSV}',HoTen = N'{student.docGhiHoTen}',NgaySinh = '{student.docGhiNgaySinh}'," +
                $"Phai = N'{gender}',Lop = '{student.docGhiLop}',DTB = {student.docGhiDTB} WHERE MaSV = {id}");
            cmd.Connection = connection;
            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("\tCập nhật thành công");
            }
            CloseConnection();
        }
        public float getScoreById(string id)
        {
            var student = selectStudentById(id);
            if (student == null) return -1;
            return student.docGhiDTB;
        }

        public DataTable usp_selectLeadersInSchool()
        {
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();
            var dt = new DataTable();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "printLeadersInSchool";
            OpenConnection();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }


        public DataTable usp_selectStudentByIdClass(string idClass)
        {
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();
            var dt = new DataTable();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "printStudentByIdClass";

            cmd.Parameters.Add(new SqlParameter("@idClass",idClass));
            OpenConnection();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }

        public DataTable usp_courseRegistrationResults(string idStudent, string semester, string schoolYear)
        {

            DataTable dt = new DataTable();
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_courseRegistrationResults";
            cmd.Parameters.Add(new SqlParameter("@idStudent", idStudent));
            cmd.Parameters.Add(new SqlParameter("@semester", semester));
            cmd.Parameters.Add(new SqlParameter("@schoolYear", schoolYear));

            OpenConnection();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }
        public int uf_countStudent()
        {
            int rs;
            var cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT dbo.uf_countStudent()";
            OpenConnection();
            rs = int.Parse(cmd.ExecuteScalar().ToString());
            CloseConnection();
            return rs;
        }

        public float uf_avgScore(string idStudent)
        {
            float rs;
            var cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT dbo.uf_avgScore(@idStudent)";
            cmd.Parameters.Add(new SqlParameter("@idStudent", idStudent));
            OpenConnection();
            rs = float.Parse(cmd.ExecuteScalar().ToString());
            CloseConnection();
            return rs;
        }

        public DataTable uf_courseRegistrationResults(string idStudent,string semester , string schoolYear)
        {

            DataTable dt = new DataTable();
            var cmd = new SqlCommand();
            var adapter = new SqlDataAdapter();

            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM dbo.uf_courseRegistrationResults(@idStudent,@semester,@schoolYear)";
            cmd.Parameters.Add(new SqlParameter("@idStudent", idStudent));
            cmd.Parameters.Add(new SqlParameter("@semester", semester));
            cmd.Parameters.Add(new SqlParameter("@schoolYear", schoolYear));

            OpenConnection();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }





    }
}
