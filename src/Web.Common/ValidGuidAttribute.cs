using System.ComponentModel.DataAnnotations;

namespace Web.Common;

public class ValidGuidAttribute : ValidationAttribute
{
    public string GetErrorMessage() => $"Guid cannot be empty";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var guid = (Guid)value;
        
        if (guid.Equals(Guid.Empty))
        {
            return new(GetErrorMessage());
        }

        return ValidationResult.Success;
    }
}