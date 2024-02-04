using HrSystem.Models;

namespace HrSystem.Server
{
    public interface ICityInterface
    {
        void InsertCity(VmCountryCity vm);

        List<CityDto> ListCityDto();

        List<CityDto> ListSearchByCountry(int Country_id);

         List<CityDto> SearchbyName(VmTest vm);
    }
}
