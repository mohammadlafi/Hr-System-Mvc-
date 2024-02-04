using System.ComponentModel.DataAnnotations.Schema;

namespace HrSystem.Data
{
    [Table("Departments")]
    public class Department
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public virtual List<Employee> employees { get; set; }

    }
}
