using MailContainerTest.DataStore;
using MailContainerTest.DataStore.Abstract;
using Xunit;

namespace MailContainerTest.Tests.Data
{
    public class MailContainerDataStoreProviderTests
    {
        private static IMailContainerDataStoreProvider PrepareSut()
        {
            return new MailContainerDataStoreProvider();
        }

        [Theory]
        [InlineData(true, typeof(BackupMailContainerDataStore))]
        [InlineData(false, typeof(MailContainerDataStore))]
        public void GetMailContainerDataStore_Tests(bool isDataStoreTypeBackup, Type expectedDataStoreType)
        {
            var sut = PrepareSut();
            var containerDataStore = sut.GetMailContainerDataStore(isDataStoreTypeBackup);

            Assert.IsType(expectedDataStoreType, containerDataStore);
        }
    }
}
