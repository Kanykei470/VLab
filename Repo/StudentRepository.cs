using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VLab.Models;
using VLab.Repo;


namespace VLab.Resourses
{
    public class StudentRepository : RepositoryBase, IStudentRepository
    {
        public void Add(Student student)
        {
            throw new NotImplementedException();
        }

        private string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool AuthorizationStudent(string FullName, string Password)
        {
            bool ValidStudent;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Students WHERE FullName = @FullName AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FullName", FullName);
                command.Parameters.AddWithValue("@Password", Password);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public void Edit(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(int IdStudent)
        {
            throw new NotImplementedException();
        }

        public Student GetByStudentName(string FullName)
        {
            throw new NotImplementedException();
        }

        public void Remove(int IdStudents)
        {
            throw new NotImplementedException();
        }
    }
}
