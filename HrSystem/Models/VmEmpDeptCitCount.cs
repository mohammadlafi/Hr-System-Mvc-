namespace HrSystem.Models
{
    public class VmEmpDeptCitCount
    {
        public List<CountryDto> countryDtos { get; set; }

        public List<CityDto> cityDtos { get;set; }

        public List<DepartmentDto> departmentDtos { get; set; }
        public List<EmployeeDto> listempDto { get; set; }

        public EmployeeDto employeeDto { get; set; }


    }
}
