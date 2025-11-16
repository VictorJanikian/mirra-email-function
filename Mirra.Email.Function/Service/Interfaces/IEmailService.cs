using Mirra.Email.Function.Model;

namespace Mirra.Email.Function.Service.Interfaces
{
    public interface IEmailService
    {
        Task sendEmailAsync(EmailOutBoundRequest outboundRequest);
    }
}
