using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class CN_Correos
    {
        public void enviarCorreos(string ceHost, int cePort, string ceEmail,string cePassword, string asunto, string mensaje, string correo)
        {
            try
            {
                // Forzar TLS 1.2
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //correo origen
                //string Host = "smtp.gmail.com";
                string Host = ceHost;
                //int Puerto = 587;
                int Puerto = cePort;
                    //int.Parse(txtPuerto.Text);
                //string Usuario = "hsvp.facele.4@gmail.com";
                //Usuario que envía el correo
                string Usuario = ceEmail;
                //string Clave = "ujwjavollkbtmojd";//clave generada para aplicación en GMAIL
                string Clave = cePassword; //clave generada para aplicación en GMAIL

                //MessageBox.Show(Host + " : "+Puerto.ToString()+ " : "+Usuario+" : "+Clave);

                //PROPORCIONAMOS AUTENTICACION DE GMAIL
                SmtpClient smtp = new SmtpClient(Host, Puerto);
                MailMessage msg = new MailMessage();

                msg.From = new MailAddress(Usuario, "SO - Sucesos de Seguridad");
                msg.To.Clear();
                msg.To.Add(new MailAddress(correo));
                //msg.Attachments.Clear();
                //msg.Attachments.Add(new Attachment(adjunto));
                msg.Subject = asunto;
                msg.IsBodyHtml = true;
                msg.Body = mensaje;

                //ENVIA CORREO
                smtp.Credentials = new NetworkCredential(Usuario, Clave);
                smtp.EnableSsl = true;
                smtp.Send(msg);
                //outputFile.WriteLine(factura + "|" + txtCorreoOrigen.Text + "|" + DateTime.Now + "|Ok");

                //MessageBox.Show("Mensaje Enviado");
            }
            catch (Exception e)
            {
                MessageBox.Show("correo NO Enviado"+e);
                //outputFile.WriteLine(factura + "|" + txtCorreoOrigen.Text + "|" + DateTime.Now + "|Er");
            }
        }
    }
}
