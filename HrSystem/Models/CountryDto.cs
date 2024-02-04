using AutoMapper;
using HrSystem.Data;

namespace HrSystem.Models
{
    [AutoMap(typeof(Country),ReverseMap =true)]
    public class CountryDto
    {
        
        public int id { get; set; }

        public string Name { get; set; }
    }
}
