using AutoMapper;
using HrSystem.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrSystem.Models
{
    [AutoMap(typeof(City), ReverseMap = true)]
    public class CityDto
    {
        public int id { get; set; }

        public string Name { get; set; }

        public int Country_Id { get; set; }

        public CountryDto Country { get; set; }
    }
}
