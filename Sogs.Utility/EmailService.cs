using Microsoft.Extensions.Options;

using Sogs.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailKit.Net.Smtp;
using MimeKit;


namespace Sogs.Utility
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo, List<string> adjuntos)
        {
            var correo = new MimeMessage();
            correo.From.Add(new MailboxAddress("Oficina de Gestion en Salud", _smtpSettings.Username));            
            correo.To.Add(MailboxAddress.Parse(destinatario));
            correo.Subject = asunto;

            // Crear una parte del cuerpo principal con el texto del mensaje
            var cuerpoTexto = new TextPart("plain")
            {
                Text = cuerpo
            };

            // Crear una parte del cuerpo que contendrá el texto y los adjuntos
            var cuerpoConAdjuntos = new Multipart("mixed");
            cuerpoConAdjuntos.Add(cuerpoTexto);

            // Agregar cada archivo adjunto al cuerpo del mensaje
            foreach (var archivo in adjuntos)
            {
                var adjunto = new MimePart("application", "octet-stream")
                {
                    Content = new MimeContent(File.OpenRead(archivo)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(archivo)
                };
                cuerpoConAdjuntos.Add(adjunto);
            }

            // Asignar el cuerpo del mensaje al mensaje de correo
            correo.Body = cuerpoConAdjuntos;


            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                await client.SendAsync(correo);
                await client.DisconnectAsync(true);
            }
        }

    }
}
