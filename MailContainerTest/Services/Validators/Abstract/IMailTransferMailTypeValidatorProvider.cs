using MailContainerTest.Domain;

namespace MailContainerTest.Services.Validators.Abstract;

public interface IMailTransferMailTypeValidatorProvider
{
    IMailTransferValidator CreateValidator(MailType mailType);
}