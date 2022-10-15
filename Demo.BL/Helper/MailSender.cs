
using Demo.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Demo.BL.Helper
{
   public static class MailSender
    {
        public static string SendMail(MailVM model)
        {
            try
            {

                SmtpClient smtp = new SmtpClient("smtp.sendgrid.net", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("apikey", "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");
                smtp.Send("engmedonasr@gmail.com", model.Mail, model.Title, model.Message);

                var result = "Mail Sent Successfully";
                return result;
            }

            catch (Exception ex)
            {


                var result = "Faild To send";

                return result;


            }



        }

        }
    }
 
