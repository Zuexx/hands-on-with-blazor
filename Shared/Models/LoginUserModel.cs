using System.ComponentModel.DataAnnotations;

namespace HandsOnWithBlazor.Shared.Models
{
    public struct LoginUserModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

    }
}