using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.dtos.UserDto
{
    public class UserLoginDto
    {
        public string loginCredential { get; set; }
        public string password { get; set; }
    }
}
