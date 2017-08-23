using System.ComponentModel.DataAnnotations;

namespace WMP.NHBC.DevDetective.WebApi.Security.Models.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
