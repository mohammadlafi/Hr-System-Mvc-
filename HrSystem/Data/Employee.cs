using HrSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrSystem.Data
{
    [Table("Employees")]
    public class Employee
    {
        public int id { get; set; }

        [StringLength(50)]
        public string FName { get; set; }

        [StringLength(50)]
        public string LName { get; set; }

        public int? phone { get; set; }

        public string? Address { get; set; }

        public string Email { get; set; }

        [StringLength(6)]
        public string gender { get; set; }
        public double Salary { get; set; }
        public double ExpcetedSalary { get; set; }
        public DateTime hierDate { get; set; }

        [ForeignKey("country")]
        public int country_id { get; set; }

        public virtual Country country { get; set; }

        [ForeignKey("city")]
        public int city_id { get; set; }

        public virtual City city { get; set; }

        [ForeignKey("department")]
        public int dept_id { get; set; }

        public virtual Department department { get; set; }

        public string? ImageName { get; set; }

    }
}
