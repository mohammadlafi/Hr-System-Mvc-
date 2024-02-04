using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace HrSystem.helper
{
    public class DBoValdtion:ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Convert.ToDateTime(value) <= DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("DBO should be less than or equal today");
            }

            return new ValidationResult("Write you DBO");
        }
    }
}
