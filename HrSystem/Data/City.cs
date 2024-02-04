using System.ComponentModel.DataAnnotations.Schema;

namespace HrSystem.Data
{
    [Table("Citys")]
    public class City
    {
        public int id { get; set; }

        [Column("CityName")]
        public string Name { get; set; }

        [ForeignKey("country")]
        public  int Country_Id { get; set; }

        public virtual Country country { get; set; }

        public virtual List<Employee>  employees { get; set; }
    }
}
