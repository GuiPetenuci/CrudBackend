using System.ComponentModel.DataAnnotations;
using Confitec.Application.ViewModels.Base;

namespace Confitec.Application.ViewModels;

public enum EscolaridadeViewModel
{
	Infantil,
	Fundamental,
	Medio,
	Superior
}

public class CheckDateRangeAttribute: ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        DateTime dt = (DateTime)value;
        if (dt < DateTime.UtcNow) {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Make sure your date is lower than today");
    }

}

public class UsuarioViewModel : BaseViewModel
{
	[Required]
	public string Nome { get; set; } = string.Empty;

	[Required]
	public string Sobrenome { get; set; } = string.Empty;

	[EmailAddress]
	public string Email { get; set; } = string.Empty;

	[Required]
	[CheckDateRange]
	public DateTime DataNascimento { get; set; }

	
	[Required]
	[Range(0, 3)]
	public EscolaridadeViewModel Escolaridade { get; set; }
}