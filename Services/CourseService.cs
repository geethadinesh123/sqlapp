using sqlapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace sqlapp.Services
{
    public class CourseService
    {
        private string conStr = "Server=tcp:imgsqlservergeetha.database.windows.net,1433;Initial Catalog=imgsqldbgeetha;Persist Security Info=False;User ID=geetha;Password=Sairam@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection GetConnection()
        {
            return new SqlConnection(conStr);
        }

        public IEnumerable<Course> GetCourses(string conStr)
        {
            List<Course> _list = new List<Course>();
            string _statement = "select * from Course";
            SqlConnection _conn = new SqlConnection(conStr);
            _conn.Open();
            SqlCommand _cmd = new SqlCommand(_statement, _conn);
            using (SqlDataReader _reader=_cmd.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseID=_reader.GetInt32(0),
                        CourseName=_reader.GetString(1),
                        Rating=_reader.GetDecimal(2)
                    };
                    _list.Add(_course);
                }
            }
            return _list;
        }
    }
}
