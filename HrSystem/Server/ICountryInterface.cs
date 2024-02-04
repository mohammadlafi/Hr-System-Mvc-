using HrSystem.helper;
using HrSystem.Models;

namespace HrSystem.Server
{
    public interface ICountryInterface
    {
        List<CountryDto> ListCountry();

        void SaveCountry(CountryDto countryDto);

        PaginatedList<CountryDto> LoadAll(int PageNumber);
    }
}
