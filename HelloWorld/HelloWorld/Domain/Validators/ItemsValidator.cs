using FluentValidation;
using HelloWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Domain.Validators
{
    public class ItemsValidator : AbstractValidator<Item>
    {
        public ItemsValidator()
        {
            RuleFor(x=> x.SerialNumber)
                .NotEmpty()
                .MinimumLength(4)
                .WithMessage("GEef een serialnummer in die langer is dan 4 tekens");
            
            RuleFor(x => x.Article)
                .NotNull()
                .WithMessage("Een article is verplicht");

            RuleFor(x=>x.IsAvailable)
                .NotEqual(false)
                .WithMessage("Het item moet beschikbaar zijn");
        }
    }
}
