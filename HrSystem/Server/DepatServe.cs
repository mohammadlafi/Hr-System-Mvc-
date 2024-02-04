using AutoMapper;
using HrSystem.Data;
using HrSystem.Models;

namespace HrSystem.Server
{
    public class DepatServe:IDeptInterface
    {
        HrContext context;
        Department department;
        IMapper mapper;
        public DepatServe(HrContext _hrContext, IMapper _mapper)
        {
            department=new Department();
            context = _hrContext;
            mapper = _mapper;
        }
        public void SaveDept(DepartmentDto departmentDto)
        {
            department = mapper.Map<Department>(departmentDto);

            context.department.Add(department);
            context.SaveChanges();
        }

        public List<DepartmentDto> SeatchDepdto(string Name)
        {
            department.Name = Name;

            List<Department> allDepartment = context.department.Where(d => d.Name == department.Name).ToList();

            List<DepartmentDto> departmentList = mapper.Map<List<DepartmentDto>>(allDepartment);

            return departmentList;
        }

        public List<DepartmentDto> departmentDtos()
        {
            HrContext context = new HrContext();

            List<Department> allDepartment = (from dept in context.department
                                              select dept).ToList();
            List<DepartmentDto> departmentList = mapper.Map<List<DepartmentDto>>(allDepartment);

            return departmentList;
        }
    }
}
