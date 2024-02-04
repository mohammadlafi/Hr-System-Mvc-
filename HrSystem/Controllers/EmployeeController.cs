using HrSystem.Data;
using HrSystem.Models;
using HrSystem.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace HrSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class EmployeeController : Controller
    {
        ICountryInterface countryServer;
        ICityInterface cityServe;
        IDeptInterface depatServe;
        IEmpInterface emploServes;
        public EmployeeController(ICountryInterface _countryInterface,ICityInterface _cityInterface,IDeptInterface _deptInterface,IEmpInterface _empInterface) 
        {
            countryServer = _countryInterface;
            cityServe = _cityInterface;
            depatServe = _deptInterface;
            emploServes = _empInterface;
        }

       
        public IActionResult Index()
        {
            List<CityDto> cityDtos = new List<CityDto>();
            List<EmployeeDto> employees = new List<EmployeeDto>();
            VmEmpDeptCitCount vm = new VmEmpDeptCitCount();
            vm.countryDtos = countryServer.ListCountry();
            vm.cityDtos = cityDtos;
            vm.departmentDtos = depatServe.departmentDtos();
            vm.listempDto=employees;

            return View("NewEmployee",vm);
        }

        public IActionResult SaveEmp(VmEmpDeptCitCount vm)
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();

            ModelState.Remove("employeeDto.id");
            ModelState.Remove("countryDtos");
            ModelState.Remove("cityDtos");
            ModelState.Remove("departmentDtos");
            ModelState.Remove("listempDto");
            ModelState.Remove("employeeDto.country");
            ModelState.Remove("employeeDto.department");
            ModelState.Remove("employeeDto.city");
            ModelState.Remove("employeeDto.hierDate");
            ModelState.Remove("employeeDto.ImageName");
           

            if (ModelState.IsValid==true)
            {

                string extention = vm.employeeDto.iformfile.FileName.Split('.')[1];
                string guid = Guid.NewGuid().ToString();
                string fileName = guid + "." + extention;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
                vm.employeeDto.iformfile.CopyTo(new FileStream(path, FileMode.Create));

                vm.employeeDto.ImageName = fileName;

                emploServes.SavrEmp(vm);
            }
            List<CityDto> cityDtos = new List<CityDto>();
            vm.countryDtos = countryServer.ListCountry();
            vm.cityDtos = cityDtos;
            vm.departmentDtos = depatServe.departmentDtos();
            vm.listempDto = employees;

            
            vm.employeeDto = null;
            ModelState.Clear();
            
            return View("NewEmployee", vm);
        }

        public IActionResult UpdateEmp(VmEmpDeptCitCount vm )
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();

            ModelState.Remove("countryDtos");
            ModelState.Remove("cityDtos");
            ModelState.Remove("departmentDtos");
            ModelState.Remove("listempDto");
            ModelState.Remove("employeeDto.country");
            ModelState.Remove("employeeDto.department");
            ModelState.Remove("employeeDto.city");
            ModelState.Remove("employeeDto.hierDate");
            ModelState.Remove("employeeDto.ImageName");

            if (ModelState.IsValid == true)
            {

                if (vm.employeeDto.iformfile != null)
                {
                    string extention = vm.employeeDto.iformfile.FileName.Split('.')[1];
                    string guid = Guid.NewGuid().ToString();
                    string fileName = guid + "." + extention;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
                    vm.employeeDto.iformfile.CopyTo(new FileStream(path, FileMode.Create));

                    vm.employeeDto.ImageName = fileName;
                }

                emploServes.updateEmp(vm);
            }
            List<CityDto> cityDtos = new List<CityDto>();
            vm.countryDtos = countryServer.ListCountry();
            vm.cityDtos = cityDtos;
            vm.departmentDtos = depatServe.departmentDtos();
            vm.listempDto = employees;
            vm.employeeDto = emploServes.getUser(vm.employeeDto.id);

            return View("NewEmployee", vm);
        }

        public IActionResult DeleteEmp(int id) 
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();
            VmEmpDeptCitCount vm = new VmEmpDeptCitCount();
            emploServes.Delete(id);

            List<CityDto> cityDtos = new List<CityDto>();

            vm.countryDtos = countryServer.ListCountry();
            vm.cityDtos = cityDtos;
            vm.departmentDtos = depatServe.departmentDtos();
            vm.listempDto = employees;

            return View("SearchEmp",vm );
        }
            

        public IActionResult IndexSearchEmp()
        {
            VmEmpDeptCitCount vm = new VmEmpDeptCitCount();
            List<EmployeeDto> employees = new List<EmployeeDto>();

            List<CityDto> cityDtos = new List<CityDto>();
            vm.countryDtos = countryServer.ListCountry();
            vm.cityDtos = cityDtos;
            vm.departmentDtos = depatServe.departmentDtos();
            vm.listempDto = employees;

            return View("SearchEmp", vm);
        }
        public IActionResult SearchEmp()
        {
            VmEmpDeptCitCount vm = new VmEmpDeptCitCount();
            List<EmployeeDto> employees = new List<EmployeeDto>();
            string Name = Request.Form["txtFName"];

            employees = emploServes.EmployeeDtos(Name);

            List<CityDto> cityDtos = new List<CityDto>();
            vm.countryDtos = countryServer.ListCountry();
            vm.cityDtos = cityDtos;
            vm.departmentDtos = depatServe.departmentDtos();
            vm.listempDto = employees;

            return View("SearchEmp", vm);
        }
        public IActionResult UpdateEmp1(int id)
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();

            VmEmpDeptCitCount vm = new VmEmpDeptCitCount();
           var empDto= emploServes.getUser(id);
            List<CityDto> cityDtos = new List<CityDto>();
            vm.countryDtos = countryServer.ListCountry();
            vm.cityDtos = cityDtos;
            vm.departmentDtos = depatServe.departmentDtos();
            vm.listempDto = employees;
            vm.employeeDto = empDto;
            return View("NewEmployee",vm);
        }

        public IActionResult getCityBYCountry(int Country_id)
        {
            var x=cityServe.ListSearchByCountry(Country_id);  

          return Json(x);
        }
     
        }

   
    }

