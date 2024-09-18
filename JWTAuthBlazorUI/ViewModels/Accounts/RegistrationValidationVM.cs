using FluentValidation;

namespace JWTAuthBlazorUI.ViewModels.Accounts
{
    public class RegistrationValidationVM : AbstractValidator<RegistrationVM>
    {
        public RegistrationValidationVM()
        {
            RuleFor(x => x.FristName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty").MinimumLength(6).WithMessage("Your password lungth must be at least 6.").MaximumLength(16).WithMessage("Your password lungth must not least 16.").Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.").Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.").Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.").Matches(@"[\@\!\?\*\.]+").WithMessage("Your password must contain at least one (@!? *.).");
            RuleFor(x => x.ComfirmPassword).Equal(_ => _.Password).WithMessage("'Confirm Password' must be equalb'Password'");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<RegistrationVM>.CreateWithOptions((RegistrationVM)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}