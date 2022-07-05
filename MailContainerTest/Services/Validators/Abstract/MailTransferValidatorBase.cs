using MailContainerTest.Domain;
using MailContainerTest.Services.Model;

namespace MailContainerTest.Services.Validators.Abstract;

public abstract class MailTransferValidatorBase : IMailTransferValidator
{
    public abstract MailType MailType { get; }

    public bool Validate(MakeMailTransferRequest request, MailContainer mailContainer)
    {
        if (!mailContainer.AllowedMailType.HasFlag(request.MailType))
        {
            return false;
        }

        return ValidateInternal(request, mailContainer);
    }

    protected abstract bool ValidateInternal(MakeMailTransferRequest request, MailContainer mailContainer);
}