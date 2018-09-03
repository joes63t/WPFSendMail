using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;


namespace WpfApp5
{
    public static class SmtpServers
    {
        //public static string Yandex()
        //{
        //    return "smtp.yandex.ru";
        //}
        public static string Yandex
        {
            get { return "smtp.yandex.ru"; }
        }

        public static string Google
        {
            get { return "smtp.google.com"; }
        }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void btnSendEMail_Click(object sender, RoutedEventArgs e)
        {

            //список ящиков на которые будем отправлять письма
            List<string> listStrMails = new List<string> { "ufrc@yandex.ru" };
            string strPassword = PasswordBox.Password;
            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage("joess63t@yandex.ru", mail))
                {
                    mm.Subject = "First mail send on Csharp WPF program";
                    mm.Body = "This is mail sender on WPF program";
                    mm.IsBodyHtml = false;
                   // mm.Body = TextBox_TextChanged;

                    using (SmtpClient sc = new SmtpClient (SmtpServers.Yandex, 25))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("joess63t@yandex.ru", strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex.ToString());
                        }
                    }

                }
            }
            MessageBox.Show("Message send - OK");

        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
                     
            string TxtBox = Convert.ToString(TextMsgBox);
        }
    }
}
