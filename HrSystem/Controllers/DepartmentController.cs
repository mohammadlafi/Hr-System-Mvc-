using HrSystem.Data;
using HrSystem.Models;
using HrSystem.Server;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    public class DepartmentController : Controller
    {
        IDeptInterface depatServe;

        public DepartmentController(IDeptInterface _deptInterface)
        {
            depatServe = _deptInterface;
        }
        public IActionResult Index()
        {
            return View("NewDepartment");
        }

        public IActionResult SaveDepartment(DepartmentDto departmentDto)
        {


            depatServe.SaveDept(departmentDto);

            return View("NewDepartment");
        }
        
        public IActionResult IndexSearchDept()
        {
            List<DepartmentDto> departmentList = new List<DepartmentDto>();   
            return View("SearchDepartment", departmentList);
        }

        public IActionResult SearchDept()
        {
            string Name= Request.Form["txtName"];
            
            List<DepartmentDto> departmentDtos = new List<DepartmentDto>();
            departmentDtos= depatServe.SeatchDepdto(Name);
           
            return View("SearchDepartment", departmentDtos);
        }
      
    }
}
