using MailContainerTest.Domain;
using MailContainerTest.Services.Model;

namespace MailContainerTest.Services.Validators.Abstract;

public abstract class MailTransferValidatorBase : IMailTransferValidator
{
    private static readonly IDictionary<MailType, AllowedMailType> _mailTypeMapper =
        new Dictionary<MailType, AllowedMailType>
        {
            { MailType.LargeLetter, AllowedMailType.LargeLetter },
            { MailType.StandardLetter, AllowedMailType.StandardLetter },
            { MailType.SmallParcel, AllowedMailType.SmallParcel }
        };

    public abstract MailType MailType { get; }

    public bool Validate(MakeMailTransferRequest request, MailContainer mailContainer)
    {
        if (!mailContainer.AllowedMailType.HasFlag(_mailTypeMapper[request.MailType]))
        {
            return false;
        }

        return ValidateInternal(request, mailContainer);
    }

    protected abstract bool ValidateInternal(MakeMailTransferRequest request, MailContainer mailContainer);
}