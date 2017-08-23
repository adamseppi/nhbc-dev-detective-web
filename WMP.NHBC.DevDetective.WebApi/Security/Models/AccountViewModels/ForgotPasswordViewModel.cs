using System.ComponentModel.DataAnnotations;

namespace WMP.NHBC.DevDetective.WebApi.Security.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
