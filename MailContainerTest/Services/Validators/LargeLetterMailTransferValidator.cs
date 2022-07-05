using MailContainerTest.Domain;
using MailContainerTest.Services.Model;
using MailContainerTest.Services.Validators.Abstract;

namespace MailContainerTest.Services.Validators;

public sealed class LargeLetterMailTransferValidator : MailTransferValidatorBase
{
    public override MailType MailType => MailType.LargeLetter;

    protected override bool ValidateInternal(MakeMailTransferRequest request, MailContainer mailContainer)
    {
        if (mailContainer.Capacity < request.NumberOfMailItems)
        {
            return false;
        }

        return true;
    }
}