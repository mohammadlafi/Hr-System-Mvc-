using HrSystem.Data;
using HrSystem.helper;
using HrSystem.Models;
using HrSystem.Server;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    public class CountryController : Controller
    {
        ICountryInterface countryServer;
        ICityInterface cityServer;

        public CountryController(ICountryInterface _countryServer,ICityInterface _cityInterface) 
        {
            countryServer= _countryServer;
            cityServer= _cityInterface;
        }  
        public IActionResult Index()
        {
            return View("NewCountry");
        }

  
        public IActionResult SaveCountry(CountryDto countryDto)
        {

            countryServer.SaveCountry(countryDto);
            
            return View("NewCountry");
        }

        public IActionResult AllCountry(int PageNumber)
        {
            PaginatedList <CountryDto> country = countryServer.LoadAll(PageNumber);

            return View("ListCountry", country);
        }

        public IActionResult indexSerch()
        {
            VmTest vm = new VmTest();

            List<CityDto> dtos = new List<CityDto>();

            vm.listcityDto = dtos;

            vm.listcountryDtos = countryServer.ListCountry();

            return View("NEwSearchByCountry", vm);
        }

        public IActionResult SearchCountryByName(VmTest vm)
        {
            string nameCountry = Request.Form["txtName"];
            vm.listcountryDtos = countryServer.ListCountry();
            vm.listcityDto= cityServer.SearchbyName(vm);

            return View("NEwSearchByCountry", vm);
        }
    }
}
