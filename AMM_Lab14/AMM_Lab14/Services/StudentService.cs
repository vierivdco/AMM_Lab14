using AMM_Lab14.DataContext;
using AMM_Lab14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMM_Lab14.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;
        public StudentService() => _context = App.GetContext();
        public List<Student> Get()
        {
            return _context.Students.ToList();
        }
        public void Create(Student item)
        {
            _context.Students.Add(item);
            _context.SaveChanges();
        }
        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public void Delete(Student student)
        {
            var Student = _context.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
            _context.Students.Remove(Student);
            _context.SaveChanges();
        }
    }
}