using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using SchoolProject.Service.Abstracts;
using SchoolProject.Shared.Absractions;
namespace SchoolProject.Service.Implementation
{
    public class EmailService(IOptions<EmailBinding> _options) : IEmailService
    {
        private readonly EmailBinding _options = _options.Value;

        public async Task<Result> SendMassege(string Email, string Messege, string? reason)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_options.Host, _options.Port, SecureSocketOptions.StartTls);// الاتصال بسيرفر Gmail
                    client.Authenticate(_options.Mail, _options.Password); // تسجيل الدخول بحساب Gmail

                    var messageLink = $"<a href=\"{Messege}\">Click here to confirm your email</a>";

                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = Messege,
                        TextBody = Messege // لو فتح الإيميل كنص عادي
                    };

                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody() // إضافة المحتوى للرسالة
                    };

                    message.From.Add(new MailboxAddress(_options.DisplayName, _options.Mail)); // من
                    message.To.Add(new MailboxAddress("testing", Email)); // إلى

                    message.Subject = reason==null?"No Submitted":reason; // العنوان

                    await client.SendAsync(message); // إرسال الإيميل
                    client.Disconnect(true); // إنهاء الاتصال بالسيرفر
                }
                return Result.Success();
            }
            catch (Exception ex) {
                Console.WriteLine($"Email error: {ex}");

                return Result.Failure(new Error("Email.SendError", ex.Message, StatusCodes.Status400BadRequest));
            }

        }
    }
}
