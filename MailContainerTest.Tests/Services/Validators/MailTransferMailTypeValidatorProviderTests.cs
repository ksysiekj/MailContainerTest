using MailContainerTest.Domain;
using MailContainerTest.Services.Validators;
using MailContainerTest.Services.Validators.Abstract;
using Xunit;

namespace MailContainerTest.Tests.Services.Validators
{
    public class MailTransferMailTypeValidatorProviderTests
    {
        private static IMailTransferMailTypeValidatorProvider PrepareSut()
        {
            return new MailTransferMailTypeValidatorProvider();
        }

        [Theory]
        [InlineData(MailType.LargeLetter, typeof(LargeLetterMailTransferValidator))]
        [InlineData(MailType.SmallParcel, typeof(SmallParcelMailTransferValidator))]
        [InlineData(MailType.StandardLetter, typeof(StandardLetterMailTransferValidator))]
        public void GetMailContainerDataStore_Tests(MailType mailType, Type expectedValidatorType)
        {
            var sut = PrepareSut();
            var mailTransferValidator = sut.CreateValidator(mailType);

            Assert.IsType(expectedValidatorType, mailTransferValidator);
        }
    }
}
