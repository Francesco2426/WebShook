using System;
using Discord;
using Discord.Webhook;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;

namespace Webshook
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        string url, username, msg, avatar;
        bool tts;
        int times;
        readonly string agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";

        public Form1()
        {
            InitializeComponent();
            if(ttsBox.Checked)
            {
                tts = true;
            }
            else
            {
                tts = false;
            }
        }
        public void Spam()
        {
            url = webhookBox.Text;
            username = usernameBox.Text;
            msg = messageBox.Text;
            avatar = avatarBox.Text;
            DiscordWebhook hook = new DiscordWebhook();
            hook.Url = url;
            DiscordMessage message = new DiscordMessage();
            message.Content = msg;
            message.Username = username;
            message.TTS = tts;
            message.AvatarUrl = avatar;
            times = int.Parse(timeBox.Text);
            if (!int.TryParse(timeBox.Text, out times))
            {
                MessageBox.Show("That's not a number.");
            }
            else
            {
                if (url != "" || username != "" || msg != "")
                {
                    for (int i = 0; i <= times; i++)
                    {
                        try
                        {
                            hook.Send(message);
                        }
                        catch (Exception e)
                        {
                            if(e.Message.Contains("429"))
                            {
                                MessageBox.Show("You are being ratelimitted.");
                                Thread.Sleep(5000);
                            }
                            else
                            {
                                MessageBox.Show($"Error: {e}");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields.");
                }
            }
        }
        private void spamButton_Click(object sender, EventArgs e)
        {
            Spam();
        }

        private void silentButton_Click(object sender, EventArgs e)
        {
            url = webhookBox.Text;
            Delete(url);
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            WebDel();
        }

        public void WebDel()
        {
            url = webhookBox.Text;
            avatar = avatarBox.Text;
            DiscordWebhook hook = new DiscordWebhook();
            hook.Url = url;
            DiscordMessage message = new DiscordMessage();
            message.Content = "Say goodbye to your webhook!";
            message.TTS = false;
            message.Username = "Bye bye";
            message.AvatarUrl = avatar;
            hook.Send(message);
            Thread.Sleep(1000);
            Delete(url);
        }
        public string Delete(string webhook)
        {
            try
            {
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(url);
                byte[] bytes = Encoding.ASCII.GetBytes("{}");
                r.Method = "DELETE";
                r.UserAgent = agent;
                r.ContentLength = bytes.Length;
                using (Stream requestStream = r.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
                HttpWebResponse wr = (HttpWebResponse)r.GetResponse();
                return new StreamReader(wr.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                return null;
            }
        }
    }
}