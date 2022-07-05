using MailContainerTest.Domain;
using MailContainerTest.Services.Model;
using MailContainerTest.Services.Validators.Abstract;

namespace MailContainerTest.Services.Validators;

public sealed class StandardLetterMailTransferValidator : MailTransferValidatorBase
{
    public override MailType MailType => MailType.StandardLetter;

    protected override bool ValidateInternal(MakeMailTransferRequest request, MailContainer mailContainer)
    {
        return true;
    }
}