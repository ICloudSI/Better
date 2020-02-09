using Better.Infrastructure.Commands.Users;
using FluentValidation;

namespace Better.Infrastructure.Validator
{
    public class RegisterValidator : AbstractValidator<Register>
    {
       public RegisterValidator()
       {
           RuleFor(model => model.Email).EmailAddress();
           RuleFor(model => model.Password).NotEmpty().Length(8,100);
           
       } 
    }
}