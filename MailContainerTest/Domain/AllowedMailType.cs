namespace MailContainerTest.Domain
{
    [Flags]
    public enum AllowedMailType
    {
        StandardLetter = 1 ,
        LargeLetter = 2,   
        SmallParcel = 4
    }
}