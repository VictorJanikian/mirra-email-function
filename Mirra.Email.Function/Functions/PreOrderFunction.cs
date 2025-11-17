using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mirra.Email.Function.Model.Request;
using Mirra.Email.Function.Service.Interfaces;

namespace Mirra.Email.Function.Functions;

public class PreOrderFunction
{
    private readonly ILogger<PreOrderFunction> _logger;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private IEmailService _emailService;
    private IPreOrderService _preOrderService;

    public PreOrderFunction(ILogger<PreOrderFunction> logger,
        IMapper mapper,
        IConfiguration configuration,
        IEmailService emailService,
        IPreOrderService preOrderService)
    {
        _logger = logger;
        _mapper = mapper;
        _configuration = configuration;
        _emailService = emailService;
        _preOrderService = preOrderService;
    }

    [Function("PreOrderEmailFunction")]
    public async Task<IActionResult> PreOrderEmailFunction([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        var preOrderRequest = await req.ReadFromJsonAsync<PreOrderInterestRequest>();
        await _preOrderService.SaveUserInterestOnEmail(preOrderRequest);
        await _preOrderService.SendWelcomeEmail(preOrderRequest);
        return new OkResult();
    }
}