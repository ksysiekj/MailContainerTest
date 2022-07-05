using MailContainerTest.DataStore.Abstract;
using MailContainerTest.Domain;

namespace MailContainerTest.DataStore
{
    public sealed class BackupMailContainerDataStore: IMailContainerDataStore
    {
        public MailContainer GetMailContainer(string mailContainerNumber)
        {
            // Access the database and return the retrieved mail container. Implementation not required for this exercise.
            return new MailContainer();
        }

        public void UpdateMailContainer(MailContainer mailContainer)
        {
            // Update mail container in the database. Implementation not required for this exercise.
        }
    }
}
