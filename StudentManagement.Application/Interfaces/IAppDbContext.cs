using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Student> Students { get; }
        DbSet<Course> Courses { get; }
        DbSet<Enrollment> Enrollments { get; }
        DbSet<Grade> Grades { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
