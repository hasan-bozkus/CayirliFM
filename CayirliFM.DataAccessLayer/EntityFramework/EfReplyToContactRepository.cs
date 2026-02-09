using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.DtoLayer.Dtos.ContactDtos;
using CayirliFM.EntityLayer.Contrete;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ResultGetReplyToContactDto> GetReplyToContact(int id)
        {
            using(var context = new Context())
            {
                var value = await context.ReplyToContacts.Where(x => x.ReplyToContactID == id).Select(y => new ResultGetReplyToContactDto
                {
                    ReplyToContactID = y.ReplyToContactID,
                    Body = y.Body,
                    ReceiverEmail = y.ReceiverEmail,
                    SendingDate = y.SendingDate,
                    Subject = y.Subject
                }).FirstOrDefaultAsync();
                return value;
            }
        }

        public async Task<int> GetReplyToContactCountAsync()
        {
            using (var context = new Context())
            {
                var value = await context.ReplyToContacts.CountAsync();
                return value;
            }
        }

        public async Task<List<ResultReplyToContactWithDescDto>> GetReplyToContactsWithDesc()
        {
            using (var context = new Context())
            {
                var values = await context.ReplyToContacts.OrderByDescending(x => x.ReplyToContactID).Select(y => new ResultReplyToContactWithDescDto
                {
                    ReplyToContactID = y.ReplyToContactID,
                    ReceiverEmail = y.ReceiverEmail,
                    Subject = y.Subject,
                    Body = y.Body,
                    SendingDate = y.SendingDate
                }).ToListAsync();
                return values;
            }
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
