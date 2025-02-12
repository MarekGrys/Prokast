using AutoMapper;
using Prokast.Server.Entities;
using Prokast.Server.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Prokast.Server.Models;
using System.Web.Http;
using Prokast.Server.Models.ResponseModels;

namespace Prokast.Server.Services
{
    public class MailingService: IMailingService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly SmtpSettings _smtpSettings;
        Random random = new Random();

        public MailingService(ProkastServerDbContext dbContext, IMapper mapper, IOptions<SmtpSettings> smtpOptions)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _smtpSettings = smtpOptions.Value;
        }

        public Response SendEmail([FromBody] EmailMessage emailMessage)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Prokast", _smtpSettings.Email));
            message.To.Add(MailboxAddress.Parse(emailMessage.To));
            message.Subject = emailMessage.Subject;

            message.Body = new TextPart("plain")
            {
                Text = emailMessage.Body
            };

            using (var client = new SmtpClient())
            {
                var secureOption = _smtpSettings.UseSsl ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls;

                client.Connect(_smtpSettings.Server, _smtpSettings.Port, secureOption);

                client.Authenticate(_smtpSettings.Email, _smtpSettings.Password);

                client.Send(message);

                client.Disconnect(true);
            }

            var response = new EmailResponse() {ID = random.Next(1,100000), ClientID = -1, Model = emailMessage };
            return response;
        }
    }
}
