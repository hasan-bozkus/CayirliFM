using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.EntityFramework
{
    public class EfReplyToContactRepository : GenericRepository<ReplyToContact>, IReplyToContactDal
    {
        public EfReplyToContactRepository(Context context) : base(context)
        {
        }

        public async Task ReplyToContactForContactRequest(ReplyToContact replyToContact)
        {
            using (var context = new Context())
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "denememardin0147@gmail.com");

                 mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress("User", replyToContact.ReceiverEmail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                mimeMessage.Subject = replyToContact.Subject;

                bodyBuilder.TextBody = replyToContact.Body;

                mimeMessage.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new SmtpClient();
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("denememardin0147@gmail.com", "****************");
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);

                await context.ReplyToContacts.AddAsync(replyToContact);
                await context.SaveChangesAsync();
            }
        }
    }
}
