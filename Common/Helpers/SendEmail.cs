using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
   public static class SendEmail
    {
        public static Boolean SendingMail(string From, string To, string Subject, string Body)
        {


            
            try
            {
                MailMessage m = new MailMessage("ivan.paul@coditas.com", To);
                m.Subject = Subject;
                m.Body = Body;
                m.IsBodyHtml = true;
                m.From = new MailAddress(From);

                m.To.Add(new MailAddress(To));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                

                NetworkCredential authinfo = new NetworkCredential("ivan.paul@coditas.com", "Ivanpaul25");
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = authinfo;
                smtp.Send(m);
                return true;




            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
