using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //3lX6JcJ17fX1lyQ
                //    smtp.sendgrid.net
                //        azure_e848b0ff48010f88c67d17f60c2f07c4@azure.com


                string email = "plus.tiago@gmail.com";

                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(email, "Tiago"));

                // From
                mailMsg.From = new MailAddress(email, "Tiago");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "subject";
                string text = "text body";
                string html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_e848b0ff48010f88c67d17f60c2f07c4@azure.com", "3lX6JcJ17fX1lyQ");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);

                Console.Write("Ok");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

            }

            Console.ReadKey();

        }
    }
}
