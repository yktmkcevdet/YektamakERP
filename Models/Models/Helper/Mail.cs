namespace Models
{
    public class Mail:IEntity
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? SentAt { get; set; } = null;
        public bool IsSent { get; set; } = false;
        private List<MailAttachament> _attachmentData;
        public List<MailAttachament> attachmentData
        {
            get
            {
                if (_attachmentData == null)
                {
                    _attachmentData = new List<MailAttachament>();
                }
                return _attachmentData;
            }
            set { _attachmentData = value; }
        }
    }
    public class MailAttachament : IEntity
    {
        public string fileName { get; set; }
        public byte[] fileData { get; set; }
    }
}
