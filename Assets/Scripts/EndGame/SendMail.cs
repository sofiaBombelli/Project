
using System.IO;
using UnityEngine;
using System.Net;
using System.Net.Mail;
public class SendMail : MonoBehaviour
{
    void Start()
    {
        string toEmail = "ire@sureksu.com";
        string subject = "Resultados encuesta";
        string body = "";
        string filePath = "Ticket.pdf"; // Ruta al archivo PDF

        string attachmentPath = Path.Combine(Application.dataPath, filePath);
        SendEmail(toEmail, subject, body, attachmentPath);
    }
    public void SendEmail(string toEmail, string subject, string body, string attachmentPath)
    {
        string fromEmail = "sofiambombelli@gmail.com";
        string fromPassword = "cnli ufky zrtv qoff";
        string smtpServer = "smtp.gmail.com";
        int smtpPort = 587;

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        if (!string.IsNullOrEmpty(attachmentPath))
        {
            Attachment attachment = new Attachment(attachmentPath);
            mail.Attachments.Add(attachment);
        }

        SmtpClient smtpClient = new SmtpClient(smtpServer);
        smtpClient.Port = smtpPort;
        smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mail);
            Debug.Log("Correo enviado correctamente");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al enviar el correo: " + ex.Message);
        }
    }
   

}
