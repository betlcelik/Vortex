using FluentValidation;
using Spotify.entities.concretes;
using SpotifyClone.Core.dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.Validation
{
    public class UserUpdatePasswordValidator:AbstractValidator<UserUpdatePasswordDto>
    {
        public UserUpdatePasswordValidator()
        {
            RuleFor(user => user.newPassword)
               .NotNull()
               .MinimumLength(6)
               .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
               .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
               .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");
        }
    }
}
