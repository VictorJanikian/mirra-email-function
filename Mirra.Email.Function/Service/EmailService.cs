using Microsoft.Extensions.Configuration;
using Mirra.Email.Function.Model;
using Mirra.Email.Function.Service.Interfaces;
using Resend;

namespace Mirra.Email.Function.Service
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task sendEmailAsync(EmailOutBoundRequest outboundRequest)
        {
            var apiKey = _configuration["Resend:ApiKey"];
            IResend resend = ResendClient.Create(apiKey);

            var resp = await resend.EmailSendAsync(new EmailMessage()
            {
                From = outboundRequest.From,
                To = outboundRequest.To,
                Subject = outboundRequest.Subject,
                HtmlBody = outboundRequest.HtmlBody,
            });
        }
    }
}
