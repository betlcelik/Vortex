using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Core.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.Validation
{
    public class UserAddValidator :AbstractValidator<UserAddDto>
    {
        private IUserRepository _userRepository;
        public UserAddValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
            RuleFor(user => user.userName).NotNull().Length(3, 15)
                .Must(BeUserNameUnique).WithMessage("Kullanıcı adı kayıtlı.Başka bir kullanıcı adı seçiniz");
            RuleFor(user => user.password)
                .NotNull()
                .MinimumLength(6)
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");
            RuleFor(user => user.email).NotNull().EmailAddress().Must(BeEmailUnique).WithMessage("Email zaten kayıtlı");
            RuleFor(user => user.countryId).NotNull();
        }

        private bool BeEmailUnique(string email)
        {
            var user = _userRepository.Get(user => user.email == email && user.state.Equals("active"));
            return user == null;
        }

        private bool BeUserNameUnique(string userName)
        {
            var user = _userRepository.Get(user => user.userName == userName && user.state.Equals("active"));
            return user == null;
        }

    }
}
