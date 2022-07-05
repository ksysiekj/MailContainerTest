namespace MailContainerTest.Services.Abstract;

public interface IMailTransferConfiguration
{
    bool IsDataStoreTypeBackup { get; }
}