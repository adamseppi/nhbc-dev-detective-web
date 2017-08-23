using ClassLibrary1;
using Microsoft.Owin;
using Owin;
using WMP.NHBC.DevDetective.WebForms.Models;

[assembly: OwinStartupAttribute(typeof(WMP.NHBC.DevDetective.WebForms.Startup))]
namespace WMP.NHBC.DevDetective.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
