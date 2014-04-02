using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Mail;
using System.Net.Mime;
using System.Web.Http;

namespace Itgroup_SiteContact.Controllers
{
    public class ContactController : ApiController
    {
        // GET api/<controller>

        public string Get() 
        {
            return "Get!";
        }

        public string GetOld()
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
                mailMsg.Subject = "Assunto: " + DateTime.Now.ToShortTimeString(); ;
                string text = "Texto";
                string html = @"<p>Texto do Email</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_e848b0ff48010f88c67d17f60c2f07c4@azure.com", "3lX6JcJ17fX1lyQ");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);

                return "Ok";

            }
            catch (Exception ex)
            {

                return "Erro: " + ex.Message;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value2";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

            string teste = "teste";
        }



        // POST api/<controller>
        //public void Post([FromBody]string Nome, [FromBody]string Email, [FromBody]string Mensagem)
        //{
        // }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}