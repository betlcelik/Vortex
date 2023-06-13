using FluentValidation;
using SpotifyClone.Core.dtos.MembershipDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.Validation
{
    public class MembershipPaymentValidator:AbstractValidator<MembershipPaymentDto>
    {
        public MembershipPaymentValidator()
        {
            RuleFor(payment => payment.cardNo).NotNull().Length(16).WithMessage("Kart Numarası 16 Haneden Küçük Olamaz");
            RuleFor(payment => payment.cvc).NotNull().Length(3);
        }
    }
}
