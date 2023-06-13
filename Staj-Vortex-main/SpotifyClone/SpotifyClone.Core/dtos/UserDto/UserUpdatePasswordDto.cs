
namespace SpotifyClone.Core.dtos.UserDto
{
   public class UserUpdatePasswordDto
    {
       
        public int id { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string newPasswordRepeat { get; set; }
    }

}
