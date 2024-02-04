using HrSystem.Data;
using HrSystem.Models;
using HrSystem.Server;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace HrSystem.Controllers
{
    public class CityController : Controller
    {
        ICountryInterface countryServer;
        ICityInterface citServer;

        public CityController(ICountryInterface _countryServer,ICityInterface _citServer) 
        {
            countryServer= _countryServer;
            citServer = _citServer;
        } 
        public IActionResult Index()
        {
            VmCountryCity vm = new VmCountryCity();

            vm.countryDtos =countryServer.ListCountry() ;

            return View("NewCity", vm);
        }

        public IActionResult SaveCity(VmCountryCity vm)
        {
           
            citServer.InsertCity(vm);
            vm.countryDtos = countryServer.ListCountry();

            return Content("Sucess");
        }
        public IActionResult AllList() 
        {
            List<CityDto> listcityDto= new List<CityDto>();

            listcityDto = citServer.ListCityDto();

            return View("ListCity", listcityDto);
        }
    }
}
