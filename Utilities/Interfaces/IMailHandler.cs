namespace Utilities.Interfaces
{
    public interface IMailHandler
    {
        public void SendMail(string receiverEmailAdress, string subject, string body);
    }
}
