using Mirra.Email.Function.Model;
using Mirra.Email.Function.Model.Request;
using Mirra.Email.Function.Service.Interfaces;
using Mirra.Email.Function.Templates;

namespace Mirra.Email.Function.Service
{
    public class PreOrderService : IPreOrderService
    {

        private readonly IEmailService _emailService;

        private static StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        private static Dictionary<string, string> WelcomePreOrderTemplates = new Dictionary<string, string>(comparer)
        {
            { "Brasil", WelcomePreOrderPT.htmlBody},
            { "United States", WelcomePreOrderEN.htmlBody}
        };

        public PreOrderService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SaveUserInterestOnEmail(PreOrderInterestRequest preOrderInterestRequest)
        {
            var htmlBody = SavePreOrderInterest.HtmlBody;
            htmlBody = htmlBody.Replace("{preOrderInterestRequest.Name}", preOrderInterestRequest.Name);
            htmlBody = htmlBody.Replace("{preOrderInterestRequest.Email}", preOrderInterestRequest.Email);
            htmlBody = htmlBody.Replace("{preOrderInterestRequest.Country}", preOrderInterestRequest.Country);
            htmlBody = htmlBody.Replace("{preOrderInterestRequest.Phone}", preOrderInterestRequest.Phone);

            var outboundRequest = new EmailOutBoundRequest
            {
                From = "noreply@mirraai.net",
                To = "mirra-ai@outlook.com",
                Subject = "Novo usuário cadastrado para acesso antecipado!",
                HtmlBody = htmlBody
            };

            await _emailService.sendEmailAsync(outboundRequest);
        }





        public async Task SendWelcomeEmail(PreOrderInterestRequest preOrderInterestRequest)
        {
            WelcomePreOrderTemplates.TryGetValue(preOrderInterestRequest.Country.Trim(), out var template);

            var htmlBody = template ?? WelcomePreOrderEN.htmlBody;

            var outboundRequest = new EmailOutBoundRequest
            {
                From = "noreply@mirraai.net",
                To = preOrderInterestRequest.Email,
                Subject = "Seja bem-vindo(a) à lista de acesso antecipado da Mirra AI!",
                HtmlBody = htmlBody

            };

            await _emailService.sendEmailAsync(outboundRequest);
        }
    }
}
