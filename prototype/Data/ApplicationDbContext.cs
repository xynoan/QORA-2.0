using Microsoft.EntityFrameworkCore;
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
    }

    public class User
    {
        public int UserId { get; set; }  // Maps to USERID

        public string? ACC_STUDENT_ID { get; set; }  // Maps to ACC_STUDENT_ID (nullable)
        public string? EMAIL { get; set; }  // Maps to EMAIL (nullable)
        public string? PASSWORD { get; set; }  // Maps to PASSWORD (nullable)
        public string? ENROLLMENT_STATUS { get; set; }  // Maps to ENROLLMENT_STATUS (nullable)
        public string? OTP { get; set; }  // Maps to OTP (nullable)
        public string? REFERENCE_STATUS { get; set; }  // Maps to REFERENCE_STATUS (nullable)
        public string? STATUS { get; set; }  // Maps to STATUS (nullable)
        public string? USER_TYPE { get; set; }  // Maps to USER_TYPE (nullable)
        public string? VERIFICATION { get; set; }  // Maps to VERIFICATION (nullable)
    }
}
