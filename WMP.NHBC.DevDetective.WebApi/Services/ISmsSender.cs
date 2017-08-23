using System.Threading.Tasks;

namespace WMP.NHBC.DevDetective.WebApi.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
