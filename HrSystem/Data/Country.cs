using System.ComponentModel.DataAnnotations.Schema;

namespace HrSystem.Data
{
    [Table("Countrys")]
    public class Country
    {
        public int id { get; set; }

        public string  Name { get; set; }

        public virtual List<City> cities { get; set; }

        public virtual List<Employee> employees { get; set; }
        
        
    }
}
