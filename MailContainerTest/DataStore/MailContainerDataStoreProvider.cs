using MailContainerTest.DataStore.Abstract;

namespace MailContainerTest.DataStore;

public sealed class MailContainerDataStoreProvider : IMailContainerDataStoreProvider
{
    public IMailContainerDataStore GetMailContainerDataStore(bool isDataStoreTypeBackup)
    {
        return isDataStoreTypeBackup ? new BackupMailContainerDataStore() : new MailContainerDataStore();
    }
}