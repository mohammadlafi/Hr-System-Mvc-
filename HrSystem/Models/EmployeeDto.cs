using HrSystem.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HrSystem.helper;
using AutoMapper;

namespace HrSystem.Models
{
    [AutoMap(typeof(Employee), ReverseMap = true)]
    public class EmployeeDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please Fill Your First Name")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Please Fill Your Last Name")]
        public string LName { get; set; }
        public int? phone { get; set; }
        public string Email { get; set; }
        public string?Address { get; set; }

        [Required(ErrorMessage = "Please Fill Your Gender")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Please Fill Your Salary")]
        public double Salary { get; set; }
        public double ExpcetedSalary { get; set; }

        [DBoValdtion]
        public DateTime hierDate { get; set; }
        public int country_id { get; set; }
        public int city_id { get; set; }
        public int dept_id { get; set; }

        public IFormFile? iformfile { get; set; }

        public CountryDto country { get; set; }
        public DepartmentDto department { get; set; }
        public CityDto city { get; set; }

        public string ImageName { get; set; }
    }
}
