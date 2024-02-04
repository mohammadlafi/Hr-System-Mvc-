using AutoMapper;
using HrSystem.Data;
using HrSystem.Models;

namespace HrSystem.Server
{
    public class CityServe:ICityInterface
    {
        HrContext context;
        IMapper mapper;

        public CityServe(HrContext _hrContext,IMapper _mapper)
        {
        context= _hrContext;
        mapper=_mapper;
        }
        public void InsertCity(VmCountryCity vm)
        {
           
            City city =mapper.Map<City>(vm.cityDto);
            context.city.Add(city);
            context.SaveChanges();
        }
        public List<CityDto> ListCityDto()
        {
            List<City> allCity = context.city.ToList();

            List<CityDto> listcitDto = mapper.Map<List<CityDto>>(allCity);

            return listcitDto;
        }

        public List<CityDto> ListSearchByCountry(int Country_id)
        {
            List<City> allCity = context.city.Where(e => e.Country_Id == Country_id).ToList();

            List<CityDto> listcitDto = mapper.Map<List<CityDto>>(allCity);

            return listcitDto;
        }

        public List<CityDto> SearchbyName(VmTest vm)
        {
            Country country = mapper.Map<Country>(vm.country);

            List<City> searchCitys = context.city.Where(e => e.Country_Id == country.id).ToList();
            

            List<CityDto> listCity = mapper.Map<List<CityDto>>(searchCitys);

            return listCity;
        }
    }
}
