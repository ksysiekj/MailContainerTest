using MailContainerTest.Domain;
using MailContainerTest.Services.Model;
using MailContainerTest.Services.Validators;
using MailContainerTest.Services.Validators.Abstract;
using Xunit;

namespace MailContainerTest.Tests.Services.Validators;

public class SmallParcelMailTransferValidatorTests
{
    private static IMailTransferValidator PrepareSut()
    {
        return new SmallParcelMailTransferValidator();
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
            new MakeMailTransferRequest { MailType = MailType.LargeLetter },
            new MailContainer { AllowedMailType = AllowedMailType.LargeLetter, Status = MailContainerStatus.NoTransfersIn},
            false
        };
        yield return new object[]
        {
            new MakeMailTransferRequest { MailType = MailType.LargeLetter },
            new MailContainer { AllowedMailType = AllowedMailType.LargeLetter, Status = MailContainerStatus.OutOfService},
            false
        };
        yield return new object[]
        {
            new MakeMailTransferRequest { MailType = MailType.LargeLetter},
            new MailContainer { AllowedMailType = AllowedMailType.LargeLetter, Status = MailContainerStatus.Operational },
            true
        };
    }
}