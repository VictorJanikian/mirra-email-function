using Mirra.Email.Function.Model.Request;

namespace Mirra.Email.Function.Service.Interfaces
{
    public interface IPreOrderService
    {
        public Task SaveUserInterestOnEmail(PreOrderInterestRequest preOrderInterestRequest);
        public Task SendWelcomeEmail(PreOrderInterestRequest preOrderInterestRequest);
    }
}
