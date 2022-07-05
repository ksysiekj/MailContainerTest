using MailContainerTest.DataStore.Abstract;
using MailContainerTest.Services.Abstract;
using MailContainerTest.Services.Model;
using MailContainerTest.Services.Validators.Abstract;

namespace MailContainerTest.Services
{
    public sealed class MailTransferService : IMailTransferService
    {
        private readonly IMailTransferConfiguration _mailTransferConfiguration;
        private readonly IMailContainerDataStoreProvider _mailContainerDataStoreProvider;
        private readonly IMailTransferMailTypeValidatorProvider _mailTransferMailTypeValidatorProvider;

        public MailTransferService(IMailTransferConfiguration mailTransferConfiguration, IMailContainerDataStoreProvider mailContainerDataStoreProvider, IMailTransferMailTypeValidatorProvider mailTransferValidator)
        {
            _mailTransferConfiguration = mailTransferConfiguration;
            _mailContainerDataStoreProvider = mailContainerDataStoreProvider;
            _mailTransferMailTypeValidatorProvider = mailTransferValidator;
        }

        public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
        {
            // TODO: do request validation - check if it makes sense

            var mailContainerDataStore = _mailContainerDataStoreProvider
                .GetMailContainerDataStore(_mailTransferConfiguration.IsDataStoreTypeBackup);

            var result = new MakeMailTransferResult();

            var mailContainer = mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

            if (mailContainer == null)
            {
                return result;
            }

            result.Success = _mailTransferMailTypeValidatorProvider
                .CreateValidator(request.MailType)
                .Validate(request, mailContainer);

            if (result.Success)
            {
                mailContainer.Capacity -= request.NumberOfMailItems;

                mailContainerDataStore.UpdateMailContainer(mailContainer);
            }

            return result;
        }
    }
}
