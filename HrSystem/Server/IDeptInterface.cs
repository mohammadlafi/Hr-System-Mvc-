using HrSystem.Models;

namespace HrSystem.Server
{
    public interface IDeptInterface
    {
        void SaveDept(DepartmentDto departmentDto);

        List<DepartmentDto> SeatchDepdto(string Name);

        List<DepartmentDto> departmentDtos();
    }
}
