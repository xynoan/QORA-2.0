using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using prototype.Models;
using prototype.Models.Register;
using prototype.Models.Student;
using System.Collections.Generic;

namespace prototype.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }  // This line remains unchanged
        public DbSet<AccountCreationModel> Accounts { get; set; } // Maps to USERS table
                                                                  // Define DbSet for each model
        public DbSet<BasicInformation> BASIC_INFORMATION { get; set; }
        public DbSet<PersonalInformation> PERSONAL_INFORMATION { get; set; }
        public DbSet<Educations> EDUCATION { get; set; }
        public DbSet<Family> FAMILY { get; set; }

        public DbSet<EmergencyContact> PERSON_INCASEOF_EMERGENCY { get; set; }

        public DbSet<StudentEnlistment> StudentEnlistment { get; set; }

        public DbSet<StudentYrScreening> StudentYrScreenings { get; set; }
        public DbSet<StudentGrading> StudentGradings { get; set; }


    }
}

