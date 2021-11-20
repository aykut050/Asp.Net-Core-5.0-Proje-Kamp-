using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş geçilemez");
            RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş geçilemez");
            RuleFor(x=>x.BlogThumbNailImage).NotEmpty().WithMessage("Blog Görseli Boş geçilemez");
            RuleFor(x=>x.BlogTitle).MaximumLength(150).WithMessage("150 Karakteri aşmayınız.");
            RuleFor(x=>x.BlogTitle).MinimumLength(5).WithMessage("5 Karakteri geçmediniz");
        }

    }
}
