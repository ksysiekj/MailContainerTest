using MailContainerTest.Domain;
using MailContainerTest.Services.Model;
using MailContainerTest.Services.Validators;
using MailContainerTest.Services.Validators.Abstract;
using Xunit;

namespace MailContainerTest.Tests.Services.Validators
{
    public class LargeLetterMailTransferValidatorTests
    {
        private static IMailTransferValidator PrepareSut()
        {
            return new LargeLetterMailTransferValidator();
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Validate_Tests(MakeMailTransferRequest request, MailContainer mailContainer, bool expectedResul)
        {
            var sut = PrepareSut();

            var result = sut.Validate(request, mailContainer);

            Assert.Equal(expectedResul, result);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new MakeMailTransferRequest { MailType = MailType.LargeLetter, NumberOfMailItems = 150 },
                new MailContainer { AllowedMailType = AllowedMailType.LargeLetter, Capacity = 100 },
                false
            };
            yield return new object[]
            {
                new MakeMailTransferRequest { MailType = MailType.LargeLetter, NumberOfMailItems = 150 },
                new MailContainer { AllowedMailType = AllowedMailType.LargeLetter, Capacity = 180 },
                true
            };
        }
    }
}
