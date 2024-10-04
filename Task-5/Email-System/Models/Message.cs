using EmailSystemEnums;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;


namespace Email_System.Models
{
    public class Message : Parent
    {
        public string? Subject { get; private set; }
        public string ContentBody { get; private set; } = null!;
        public DateTime? SentDate { get; private set; }
        public Guid SenderId { get;private set; }
        public MessageStatus Status { get; set; }
        public List<MessageDestination>? Receivers { get; set;}
        public List<InboxMessages>? Inboxes { get; set; }
        
        public List<OutboxMessages>? Outboxes { get; set; }

        public List<TrashMessages>? Trashes { get; set; }
       

        private Message() { }

        private Message(Guid senderId ,  string subject, string contentBody)
        {
            SenderId = senderId;
            ContentBody = contentBody;
            Subject = subject;
            Status = MessageStatus.Draft;
            SentDate = null;
        }

        public static Message Create(Guid senderId , string subject, string contentBody)
        {
            if (senderId == Guid.Empty) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(subject)) { subject = "No Subject"; }
            if (string.IsNullOrEmpty(contentBody)) { throw new ArgumentNullException(); }
            return new Message(senderId  ,subject, contentBody);
        }

        public void SetSubject(string subject) { Subject = subject; }
        public void SetContentBody(string contentBody) { ContentBody = contentBody; }
        public void SetSentDate() { SentDate = DateTime.Now; }
        
        public void SetMessageStatus ()
        {
            Status = MessageStatus.Sent;
        }
        public void SetReceivers(List<MessageDestination> receivers)
        {
            Receivers = receivers;
        }
        public void SetInboxes(List<InboxMessages> inboxes)
        {
            Inboxes = inboxes;
        }
        public void SetOutboxes(List<OutboxMessages> outboxes)
        {
            Outboxes = outboxes;
        }
        public void SetTrashes(List<TrashMessages> trashes)
        {
            Trashes = trashes;
        }
    }
}
