using AutoMapper;
using HrSystem.Data;
using HrSystem.helper;
using HrSystem.Models;

namespace HrSystem.Server
{
    public class EmploServes:IEmpInterface
    {

        HrContext context;
        Employee emp;
        IMapper mapper;
        public EmploServes(HrContext _Context, IMapper _mapper) 
        {
            context=_Context;
            emp = new Employee();
            mapper = _mapper;
        }
        public void SavrEmp(VmEmpDeptCitCount vm)
        {
            emp = mapper.Map<Employee>(vm.employeeDto);

            context.employee.Add(emp);
            context.SaveChanges();

            
        }

        public void updateEmp(VmEmpDeptCitCount vm) 
        {
            emp = mapper.Map<Employee>(vm.employeeDto);

            context.employee.Attach(emp);

            context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            context.SaveChanges();

        }

        public EmployeeDto getUser(int id) 
        {
            
            Employee emp= context.employee.Find(id);

            EmployeeDto employeeDto = mapper.Map<EmployeeDto>(emp);

            return employeeDto;
        }



        public void Delete(int id)
        {
           Employee empD= context.employee.Find(id);    

            context.employee.Remove(empD);

            context.SaveChanges();
        }

        public List<EmployeeDto> EmployeeDtos(string FName)
        {
            emp.FName = FName;

            List<Employee> serachemp = context.employee.Where(e => e.FName == FName).ToList();

            List<EmployeeDto> listEmpDto = mapper.Map<List<EmployeeDto>>(serachemp); 

            return listEmpDto;
        }        
   
    }
}
