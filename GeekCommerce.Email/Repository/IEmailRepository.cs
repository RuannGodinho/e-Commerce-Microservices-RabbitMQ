
using GeekCommerce.Email.Messages;

namespace GeekCommerce.Email.Repository
{
    public interface IEmailRepository
    {
        public Task LogEmail(UpdatePaymentResultMessage message);

    }
}
