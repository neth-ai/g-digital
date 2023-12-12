// Models/Staff.cs
using System;

public class Staff
{
    
    [Key]
    [StringLength(8)]
    public string StaffID { get; set; }

    [StringLength(100)]
    public string FullName { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Birthday { get; set; }


    public int GenderType Gender { get; set; }
    public enum GenderType
    {
        [Display(Name = "Male")]
        Male = 1,

        [Display(Name = "Female")]
        Female = 2
    }
}

// Models/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Staff> Staffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=127.0.0.1;database=gdigital;user=root;password=");
    }
}
