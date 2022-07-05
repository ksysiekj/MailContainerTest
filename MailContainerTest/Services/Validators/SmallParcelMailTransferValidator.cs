using MailContainerTest.Domain;
using MailContainerTest.Services.Model;
using MailContainerTest.Services.Validators.Abstract;

namespace MailContainerTest.Services.Validators;

public sealed class SmallParcelMailTransferValidator : MailTransferValidatorBase
{
    public override MailType MailType => MailType.SmallParcel;

    protected override bool ValidateInternal(MakeMailTransferRequest request, MailContainer mailContainer)
    {
        if (mailContainer.Status != MailContainerStatus.Operational)
        {
            return false;
        }

        return true;
    }
}