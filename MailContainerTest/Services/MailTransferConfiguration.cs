using MailContainerTest.Services.Abstract;
using System.Configuration;

namespace MailContainerTest.Services;

public sealed class MailTransferConfiguration: IMailTransferConfiguration
{
    public bool IsDataStoreTypeBackup => string.Equals(ConfigurationManager.AppSettings[MailTransferConsts.DataStoreTypeAppSettingsName], MailTransferConsts.BackupDataStoreType,
        StringComparison.OrdinalIgnoreCase);
}