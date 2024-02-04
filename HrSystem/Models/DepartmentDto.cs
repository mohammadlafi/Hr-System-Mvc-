using AutoMapper;
using HrSystem.Data;

namespace HrSystem.Models
{
    [AutoMap(typeof(Department), ReverseMap = true)]
    public class DepartmentDto
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
