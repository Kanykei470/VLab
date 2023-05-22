using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VLab.Models
{
    public interface IStudentRepository
    {
        bool AuthorizationStudent(string FullName,string Password);
        void Add(Student student);
        void Edit(Student student);
        void Remove(int IdStudents);
        Student GetById(int IdStudent);
        Student GetByStudentName(string FullName);
        IEnumerable<Student> GetAll();
    }
}
