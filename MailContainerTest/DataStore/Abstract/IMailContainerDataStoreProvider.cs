namespace MailContainerTest.DataStore.Abstract;

public interface IMailContainerDataStoreProvider
{
    IMailContainerDataStore GetMailContainerDataStore(bool isDataStoreTypeBackup);
}