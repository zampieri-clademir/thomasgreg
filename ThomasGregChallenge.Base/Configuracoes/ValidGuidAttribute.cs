using System;
using System.ComponentModel.DataAnnotations;

namespace ThomasGregChallenge.API.Base
{
    public class ValidGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = Guid.TryParse(value.ToString(), out Guid guidValue);

            if (result)
            {
                if (guidValue == Guid.Empty)
                {
                    return new ValidationResult("O Guid n�o pode ser o valor padr�o (Guid.Empty).");
                }
            }
            else
            {
                return new ValidationResult("Valor inv�lido para Guid.");
            }

            return ValidationResult.Success;
        }
    }
}
