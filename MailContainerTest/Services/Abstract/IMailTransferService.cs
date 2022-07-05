using MailContainerTest.Services.Model;

namespace MailContainerTest.Services.Abstract
{
    public interface IMailTransferService
    {
        MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request);
    }
}