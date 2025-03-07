using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs
{
    public class StudentGpaDTO
    {
        public int StudentID { get; set; }
        public string? FullName { get; set; }
        public double GPA { get; set; }
    }
}
