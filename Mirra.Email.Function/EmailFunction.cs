using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mirra.Email.Function.Model;
using Mirra.Email.Function.Model.Request;
using Mirra.Email.Function.Service.Interfaces;

namespace Mirra.Email.Function;

public class EmailFunction
{
    private readonly ILogger<EmailFunction> _logger;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IEmailService _emailService;

    public EmailFunction(ILogger<EmailFunction> logger, IMapper mapper, IConfiguration configuration, IEmailService emailService)
    {
        _logger = logger;
        _mapper = mapper;
        _configuration = configuration;
        _emailService = emailService;
    }

    [Function("InterestEmailFunction")]
    public async Task<IActionResult> InterestEmailFunction([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        var inboundRequest = await req.ReadFromJsonAsync<EmailInboundRequest>();
        var outboundRequest = _mapper.Map<EmailOutBoundRequest>(inboundRequest);
        outboundRequest.To = "mirra-ai@outlook.com";

        await _emailService.sendEmailAsync(outboundRequest);

        return new OkResult();
    }
}