using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitectureBoilerplate.Models.Requests;
using CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces;

namespace CleanArchitectureBoilerplate.Domain.Validators
{
    public class PersonCreateValidator : AbstractValidator<PersonCreateRequest>
    {
        private readonly IPersonRepository Repository;

        public PersonCreateValidator(IPersonRepository repository)
        {
            Repository = repository;

            RuleFor(x => x.Email).EmailAddress().WithMessage("The email is not in the right format.");
            RuleFor(x => x.Email).Custom((email, context) =>
            {
                if (!Repository.IsEmailUnique(email))
                {
                    context.AddFailure("The email is not unique.");
                }
            });
        }
    }
}
