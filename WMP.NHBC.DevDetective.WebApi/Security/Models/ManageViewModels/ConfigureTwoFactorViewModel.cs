using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WMP.NHBC.DevDetective.WebApi.Security.Models.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
