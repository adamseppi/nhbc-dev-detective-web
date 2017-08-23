using System.Threading.Tasks;

namespace WMP.NHBC.DevDetective.WebApi.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
