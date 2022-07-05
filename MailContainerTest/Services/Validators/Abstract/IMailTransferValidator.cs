using MailContainerTest.Domain;
using MailContainerTest.Services.Model;

namespace MailContainerTest.Services.Validators.Abstract;

public interface IMailTransferValidator
{
    bool Validate(MakeMailTransferRequest request, MailContainer mailContainer);

    MailType MailType { get; }
}