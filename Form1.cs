using System;
using Discord;
using Discord.Webhook;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace Webshook
{
    public partial class Form1 : Form
    {
        public string url;
        public int amount;
        public DiscordWebhook hook = new DiscordWebhook();

        public Form1()
        {
            InitializeComponent();
        }

        #region On Click Events
        private void spamButton_Click(object sender, EventArgs e)
        {
            Spam(webhookBox.Text);
        }

        private void silentButton_Click(object sender, EventArgs e)
        {
            url = webhookBox.Text;
            if (url != "")
            {
                Delete(url);
                new ToastContentBuilder()
                    .AddText("Webshook")
                    .AddText("Webhook has been silently deleted ;)")
                    .Show();
            }
            else
            {
                MessageBox.Show("Put in a webhook.");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            url = delHookBox.Text;
            if (url != "")
            {
                WebDel(url);
                new ToastContentBuilder()
                    .AddText("Webshook")
                    .AddText("Webhook has been deleted ;)")
                    .Show();
            }
            else
            {
                MessageBox.Show("Put in a webhook.");
            }
        }
        private void loadHooksBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select the file with Webhooks";
            open.Filter = "Text files | *.txt";
            open.InitialDirectory = Directory.GetCurrentDirectory();

            if (open.ShowDialog() == DialogResult.OK)
            {
                string name = open.FileName;
                string[] lines = File.ReadAllLines(name);
                LoadHooks(lines);
            }

        }
        private void resetWebhooks_Click(object sender, EventArgs e)
        {
            hookList.DataSource = null;
            hookList.Items.Clear();
            new ToastContentBuilder()
                .AddText("Webshook")
                .AddText("Webhook box has been reset!")
                .Show();
        }

        private void multiSpamBtn_Click(object sender, EventArgs e)
        {
            if (hookList.Items.Count <= 1)
            {
                MessageBox.Show("Put more than one webhook, or just use single-hook.");
            }
            else
            {
                Parallel.ForEach(hookList.Items.Cast<string>().ToList(), hook =>
                {
                    Spam(hook);
                });
                new ToastContentBuilder()
                    .AddText("Webshook")
                    .AddText("Webhooks have been spammed :)")
                    .Show();
            }
        }

        private void multiSilentBtn_Click(object sender, EventArgs e)
        {
            if (hookList.Items.Count <= 1)
            {
                MessageBox.Show("Put more than one webhook, or just use single-hook.");
            }
            else
            {
                foreach (string hook in hookList.Items)
                {
                    try
                    {
                        Delete(hook);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                new ToastContentBuilder()
                    .AddText("Webshook")
                    .AddText("Webhooks have been silently deleted ;)")
                    .Show();
            }
        }

        private void multiDeleteBtn_Click(object sender, EventArgs e)
        {
            if (hookList.Items.Count <= 1)
            {
                MessageBox.Show("Put more than one webhook, or just use the single-hook.");
            }
            else
            {
                foreach (string hook in hookList.Items)
                {
                    try
                    {
                        WebDel(hook);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                new ToastContentBuilder()
                    .AddText("Webshook")
                    .AddText("Webhooks have been deleted ;)")
                    .Show();
            }
        }
        private void embedSpamBtn_Click(object sender, EventArgs e)
        {
            EmbedSpam(webhookBox.Text);
        }
        private void embedMultiSpam_Click(object sender, EventArgs e)
        {
            if (hookList.Items.Count <= 1)
            {
                MessageBox.Show("Put more than one webhook, or just use the single-hook.");
            }
            else
            {
                Parallel.ForEach(hookList.Items.Cast<string>().ToList(), hook =>
                {
                    EmbedSpam(hook);
                });
                new ToastContentBuilder()
                    .AddText("Webshook")
                    .AddText("Webhooks have been spammed :)")
                    .Show();
            }
        }
        #endregion
        #region Multi-Hook Check
        private void LoadHooks(string[] lines)
        {
            List<string> valid = new List<string>();
            foreach (string line in lines)
            {
                if (line.Contains("https://discord.com/api/webhooks/"))
                {
                    try
                    {
                        HttpWebRequest r = (HttpWebRequest)WebRequest.Create(line);
                        HttpWebResponse wr = (HttpWebResponse)r.GetResponse();
                        StreamReader sr = new StreamReader(wr.GetResponseStream());
                        if (!sr.ReadToEnd().Contains("Unknown"))
                        {
                            valid.Add(line);
                        }
                    }
                    catch { }
                }
            }
            hookList.DataSource = valid;
            webhooksLoadedLabel.Text = hookList.Items.Count.ToString();
            new ToastContentBuilder()
                .AddText("Webshook")
                .AddText("Webhooks Loaded!")
                .Show();
        }
        #endregion
        #region Delete Methods
        public async void WebDel(string url)
        {
            hook.Url = url;
            DiscordMessage message = new DiscordMessage();
            message.Content = "Say goodbye to your webhook!";
            message.Username = "Bye bye";
            message.AvatarUrl = avatarBox.Text;
            hook.Send(message);
            await Task.Delay(1000);
            Delete(url);
        }

        public string Delete(string webhook)
        {
            try
            {
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(webhook);
                r.Method = "DELETE";
                HttpWebResponse wr = (HttpWebResponse)r.GetResponse();
                return new StreamReader(wr.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Invalid"))
                {
                    new ToastContentBuilder()
                        .AddText("Webshook")
                        .AddText("Webhook is invalid.")
                        .Show();
                    return "Invalid";
                }
                else if (ex.Message.Contains("404"))
                {
                    new ToastContentBuilder()
                        .AddText("Webshook")
                        .AddText("Webhook doesn't exist.")
                        .Show();
                    return "Doesn't Exist";
                }
                else
                {
                    MessageBox.Show($"Error: {ex}");
                    return null;
                }
            }
        }
        #endregion
        #region Spam Methods
        public async void RealSpam(DiscordWebhook hook, DiscordMessage msg)
        {
            for (int i = 0; i < amount; i++)
            {
                try
                {
                    hook.Send(msg);
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("429"))
                    {
                        if (ratelimitCheck.Checked)
                        {
                            new ToastContentBuilder()
                                .AddText("Webshook")
                                .AddText("You are being Ratelimited")
                                .Show();
                            await Task.Delay(5000);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error: {e}");
                        break;
                    }
                }
            }
        }
        public void Spam(string webhook)
        {
            DiscordWebhook hook = new DiscordWebhook();
            hook.Url = webhook;
            DiscordMessage message = new DiscordMessage();
            message.Content = messageBox.Text;
            message.Username = usernameBox.Text;
            message.AvatarUrl = avatarBox.Text;
            amount = int.Parse(amountBox.Text);
            if (!int.TryParse(amountBox.Text, out amount))
            {
                MessageBox.Show("That's not a number.");
            }
            else
            {
                if (usernameBox.Text != "" || messageBox.Text != "")
                {
                    RealSpam(hook, message);
                }
                else
                {
                    MessageBox.Show("Please fill in all required fields (*)");
                }
            }
        }
        public void EmbedSpam(string webhook)
        {
            DiscordWebhook hook = new DiscordWebhook();
            DiscordMessage msg = new DiscordMessage();
            hook.Url = webhook;
            DiscordEmbed emb = new DiscordEmbed();
            emb.Title = titleText.Text;
            emb.Description = descriptionText.Text;
            emb.Image = new EmbedMedia() { Url = imageBox.Text };
            emb.Thumbnail = new EmbedMedia() { Url = thumbnailBox.Text };
            emb.Author = new EmbedAuthor() { Name = authorBox.Text };
            emb.Footer = new EmbedFooter() { Text = footerBox.Text };
            msg.Embeds = new[] { emb };

            amount = int.Parse(amountBox.Text);
            if (!int.TryParse(amountBox.Text, out amount))
            {
                MessageBox.Show("That's not a number.");
            }
            else
            {
                if (titleText.Text != "" || descriptionText.Text != "" || authorBox.Text != "" || footerBox.Text != "")
                {
                    RealSpam(hook, msg);
                }
                else
                {
                    MessageBox.Show("Please fill in atleast one field.");
                }
            }
        }
        #endregion

        #region Not mine
        private bool mouseDown;
        private Point lastLoc;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLoc = e.Location;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLoc.X) + e.X, (Location.Y - lastLoc.Y) + e.Y);
                Update();
            }
        }
        #endregion
    }
}