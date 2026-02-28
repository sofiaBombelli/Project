using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MimeKit;
using System.IO;
//using MailKit.Net.Smtp;
//using MailKit.Security;

public class Emailer : MonoBehaviour
{/*
    public void send()
    {
        string toEmail = "speedacidrain@gmail.com";
        string subject = "Asunto del correo";
        string body = "Cuerpo del correo";
        string filePath = "Ticket.pdf"; // Nombre del archivo PDF en la carpeta Assets

        string attachmentPath = Path.Combine(Application.persistentDataPath, filePath);

        SendEmail(toEmail, subject, body, attachmentPath);
    }
    
    public void SendEmail(string toEmail, string subject, string body, string attachmentPath)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Result sender", "myuserforapp456@gmail.com"));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = body };

        if (!string.IsNullOrEmpty(attachmentPath))
        {
            bodyBuilder.Attachments.Add(attachmentPath);
        }

        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Timeout = 10000; // Tiempo de espera en milisegundos (10 segundos)
            try
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                // Autenticación con las credenciales de tu correo Gmail
                client.Authenticate("sofiambombelli@gmail.com", "cnli ufky zrtv qoff");

                client.Send(message);
                client.Disconnect(true);
                Debug.Log("Correo enviado correctamente");
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error al enviar el correo: " + ex.Message);
            }
        }
    }
    */
}
