using MailContainerTest.Domain;
using MailContainerTest.Services.Validators.Abstract;

namespace MailContainerTest.Services.Validators;

public sealed class MailTransferMailTypeValidatorProvider : IMailTransferMailTypeValidatorProvider
{
    private static readonly IReadOnlyList<IMailTransferValidator> _mailTransferValidators
        = new List<IMailTransferValidator>
        {
            new LargeLetterMailTransferValidator(),
            new SmallParcelMailTransferValidator(),
            new StandardLetterMailTransferValidator()
        };

    public IMailTransferValidator CreateValidator(MailType mailType)
    {
        return _mailTransferValidators.First(q => q.MailType == mailType);
    }
}