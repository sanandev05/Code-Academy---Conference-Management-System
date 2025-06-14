using System.ComponentModel.DataAnnotations;

namespace Code_Academy___Conference_Management_System.Models
{
    public class SignInVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public SignInVM()
        {
            RememberMe = true;
        }
    }
}
