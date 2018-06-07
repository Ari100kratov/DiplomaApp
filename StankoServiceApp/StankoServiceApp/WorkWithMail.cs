using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StankoServiceApp
{
    public static class WorkWithMail
    {
        public static void SendMessageFromMainMail(string sub, string body, string to)
        {
            using (var mm = new MailMessage("ООО ИЦ Станкосервис <stankoserviceorg@mail.ru>", to))
            {
                mm.Subject = sub;
                mm.Body = body;
                mm.IsBodyHtml = false;
                using (var sc = new SmtpClient("smtp.mail.ru", 587))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential("stankoserviceorg@mail.ru", "vladik123");
                    sc.Send(mm);
                }
            }
        }
    }
}
