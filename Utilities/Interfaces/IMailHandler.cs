namespace Utilities.Interfaces
{
    public interface IMailHandler
    {
        public void SendSystemMail(string receiverEmailAdress, string subject, string body);
    }
}
