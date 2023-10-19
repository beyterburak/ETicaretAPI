using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator() 
        { 
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(3)
                    .WithMessage("Lütfen ürün adını 3 ile 150 karakter arasında giriniz.");

            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini boş geçmeyiniz.")
                .Must(s => s >= 0)
                    .WithMessage("Stok bilgisi negatif olamaz!");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.")
                .Must(p => p >= 0)
                    .WithMessage("Fiyat bilgisi negatif olamaz!");
        }
    }
}
