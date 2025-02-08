using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMail.Text = mail.ToString();
        }

        private void Btngonder_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Credentials =new System.Net.NetworkCredential ("emrehac256@gmail.com", "?????6789az");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            message.To.Add(txtMail.Text);
            message.From = new MailAddress("emrehac256@gmail.com");
            message.Subject = txtBaslik.Text;
            message.Body = rchMesaj.Text;
            client.Send(message);

        }
    }
}
