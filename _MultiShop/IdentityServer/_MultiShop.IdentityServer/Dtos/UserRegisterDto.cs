using System.ComponentModel.DataAnnotations;

namespace _MultiShop.IdentityServer.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
