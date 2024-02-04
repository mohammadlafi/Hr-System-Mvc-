using HrSystem.Models;

namespace HrSystem.Server
{
    public interface IEmpInterface
    {
        void SavrEmp(VmEmpDeptCitCount vm);

        List<EmployeeDto> EmployeeDtos(string FName);

        void updateEmp(VmEmpDeptCitCount vm);   
        EmployeeDto getUser(int id);    

        void Delete(int id);
    }
}
