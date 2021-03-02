using System;
using FluentValidation;
using Invoice.Core.DTOs;

namespace Invoice.Infrastructure.Validators
{
    public class SalesInvoiceValidator : AbstractValidator<SalesInvoiceDto>
    {
        public SalesInvoiceValidator()
        {
            RuleFor(SalesInvoice => SalesInvoice.Country)
                .NotNull()
                .WithMessage("El país no pude ser nulo");

            RuleFor(SalesInvoice => SalesInvoice.Country)
                .Length(1, 100)
                .WithMessage("La longitud del país debe estar entre 1 y 100 caracteres");

            RuleFor(SalesInvoice => SalesInvoice.City)
                .NotNull()
                .WithMessage("La ciudad no pude ser nula");

            RuleFor(SalesInvoice => SalesInvoice.City)
                .Length(1, 100)
                .WithMessage("La longitud de la ciudad debe estar entre 1 y 100 caracteres");

            RuleFor(SalesInvoice => SalesInvoice.Address)
                .NotNull()
                .WithMessage("La dirección no pude ser nula");

            RuleFor(SalesInvoice => SalesInvoice.Address)
                .Length(1, 100)
                .WithMessage("La longitud de la dirección debe estar entre 1 y 100 caracteres");

        }
    }
}
