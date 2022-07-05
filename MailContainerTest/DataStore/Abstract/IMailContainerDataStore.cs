using MailContainerTest.Domain;

namespace MailContainerTest.DataStore.Abstract;

public interface IMailContainerDataStore
{
    MailContainer GetMailContainer(string mailContainerNumber);
    void UpdateMailContainer(MailContainer mailContainer);
}