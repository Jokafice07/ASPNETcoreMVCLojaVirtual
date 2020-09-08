using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            SmtpClient smtp = new SmtpClient("smtp.live.com", 25);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("jjoaojose@hotmail.com","Familia04");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Loja Virtual </h2>"+
                "<b>Nome : </b> {0} <br />" +
                "<b>Email : </b> {1} <br />"+
                "<b>Texto : </b> {2} <br />"+
                "<br />Email enviado automaticamente do site Loja Virtual.",
                contato.Nome,
                contato.Email,
                contato.Texto
                );

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("jjoaojose@hotmail.com");
            mensagem.To.Add("jjoaojose@hotmail.com");
            mensagem.Subject = "Contato Loja Virtual - E-mail: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //enviar mensagem smtp
            smtp.Send(mensagem);
        }
    }
}
