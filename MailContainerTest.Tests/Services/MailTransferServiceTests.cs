using MailContainerTest.DataStore;
using MailContainerTest.DataStore.Abstract;
using MailContainerTest.Domain;
using MailContainerTest.Services;
using MailContainerTest.Services.Abstract;
using MailContainerTest.Services.Model;
using MailContainerTest.Services.Validators;
using MailContainerTest.Services.Validators.Abstract;
using NSubstitute;
using Xunit;

namespace MailContainerTest.Tests.Services
{
    public class MailTransferServiceTests
    {
        private static IMailTransferService PrepareSut(IMailTransferConfiguration mailTransferConfiguration = null,
            IMailContainerDataStoreProvider mailContainerDataStoreProvider = null,
            IMailTransferMailTypeValidatorProvider mailTransferValidator = null)
        {
            mailTransferValidator ??= PrepareMailTransferValidator();
            mailContainerDataStoreProvider ??= PrepareMailContainerDataStoreProvider();
            mailTransferConfiguration ??= PrepareMailTransferConfiguration();

            return new MailTransferService(mailTransferConfiguration, mailContainerDataStoreProvider,
                mailTransferValidator);
        }

        private static IMailTransferMailTypeValidatorProvider PrepareMailTransferValidator()
        {
            return new MailTransferMailTypeValidatorProvider();
        }

        private static IMailContainerDataStoreProvider PrepareMailContainerDataStoreProvider(
            bool isBackupDataStore = true)
        {
            return new MailContainerDataStoreProvider();
        }

        private static IMailTransferConfiguration PrepareMailTransferConfiguration(bool isBackupDataStore = true)
        {
            var mock = Substitute.For<IMailTransferConfiguration>();
            mock.IsDataStoreTypeBackup.Returns(isBackupDataStore);

            return mock;
        }

        [Fact]
        public void MakeMailTransfer_Test()
        {
            var sut = PrepareSut();

            var result = sut.MakeMailTransfer(new MakeMailTransferRequest
                { MailType = MailType.LargeLetter, NumberOfMailItems = 150 });

            Assert.False(result.Success);
        }
    }
}
