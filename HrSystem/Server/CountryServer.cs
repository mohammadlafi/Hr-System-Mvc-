using AutoMapper;
using HrSystem.Data;
using HrSystem.helper;
using HrSystem.Models;
using System.Diagnostics.Metrics;

namespace HrSystem.Server
{
    public class CountryServer:ICountryInterface
    {
        HrContext context;
        IMapper mapper;
        public CountryServer(HrContext _context,IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;   
        }
        public List<CountryDto> ListCountry()
        {
            List<Country> allCountry =context.country.ToList();

            List<CountryDto> listcountryDtos = mapper.Map<List<CountryDto>>(allCountry);

            return listcountryDtos;
        } 
        public PaginatedList<CountryDto> LoadAll(int PageNumber)
        {
            List<Country> allCountry =context.country.ToList();

            List<CountryDto> listcountryDtos = mapper.Map<List<CountryDto>>(allCountry);

            return PaginatedList<CountryDto>.CreatePagnation(listcountryDtos, PageNumber);
        }

        public void SaveCountry(CountryDto countryDto)
        {

            Country newcountry = mapper.Map<Country>(countryDto);

            context.country.Add(newcountry);

            context.SaveChanges();
        }
    }
}
