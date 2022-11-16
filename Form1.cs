using System;
using Discord;
using Discord.Webhook;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Webshook
{
    public partial class Form1 : Form
    {
        private int amount;
        private DiscordWebhook hook = new DiscordWebhook();

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
            if (!string.IsNullOrEmpty(webhookBox.Text))
            {
                Utils.DeleteWebhook(webhookBox.Text);
                Utils.ToastNotification("Webhook has been silently deleted!");
            }
            else
            {
                MessageBox.Show("Put in a webhook.");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(delHookBox.Text))
            {
                WebDel(delHookBox.Text);
                Utils.ToastNotification("Webhook has been deleted!");
            }
            else
            {
                MessageBox.Show("Put in a webhook.");
            }
        }
        private void loadHooksBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Title = "Select the file with Webhooks",
                Filter = "Text files | *.txt",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                string name = open.FileName;
                string[] lines = System.IO.File.ReadAllLines(name);
                LoadHooks(lines);
            }

        }
        private void resetWebhooks_Click(object sender, EventArgs e)
        {
            hookList.DataSource = null;
            hookList.Items.Clear();
            Utils.ToastNotification("Webhook box has been reset!");
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
                Utils.ToastNotification("Webhooks have been spammed!");
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
                Parallel.ForEach(hookList.Items.Cast<string>().ToList(), hook =>
                {
                    Utils.DeleteWebhook(hook);
                });
                foreach (string hook in hookList.Items)
                {
                    try
                    {
                        Utils.DeleteWebhook(hook);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                Utils.ToastNotification("Webhooks have been silently deleted!");
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
                Utils.ToastNotification("Webhooks have been deleted");
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
                Utils.ToastNotification("Webhooks have been spammed!");
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
                        //Ill change to httpclient later
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
            Utils.ToastNotification("Webhooks Loaded!");
        }
        #endregion
        #region Delete Methods
        public async void WebDel(string url)
        {
            hook.Url = url;
            DiscordMessage message = new DiscordMessage()
            {
                Content = "Say goodbye to your webhook!",
                Username = "Bye bye",
                AvatarUrl = avatarBox.Text
            };
            hook.Send(message);
            await Task.Delay(1000);
            Utils.DeleteWebhook(url);
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
                            Utils.ToastNotification("You are being Ratelimited");
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
            DiscordWebhook hook = new DiscordWebhook() 
            {
                Url = webhook,
            };
            DiscordMessage message = new DiscordMessage()
            {
                Content = messageBox.Text,
                Username = usernameBox.Text,
                AvatarUrl = avatarBox.Text
            };
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
            DiscordWebhook hook = new DiscordWebhook()
            {
                Url = webhook,
            };
            DiscordEmbed emb = new DiscordEmbed()
            {
                Title = titleText.Text,
                Description = descriptionText.Text,
                Image = new EmbedMedia() { Url = imageBox.Text },
                Thumbnail = new EmbedMedia() { Url = thumbnailBox.Text },
                Author = new EmbedAuthor() { Name = authorBox.Text },
                Footer = new EmbedFooter() { Text = footerBox.Text }
            };

            DiscordMessage msg = new DiscordMessage
            {
                Embeds = new[] { emb }
            };

            amount = int.Parse(amountBox.Text);
            if (!int.TryParse(amountBox.Text, out amount))
            {
                MessageBox.Show("That's not a number.");
            }
            else
            {
                if (titleText.Text != "" || descriptionText.Text != "" ||
                    authorBox.Text != "" || footerBox.Text != "")
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
    }
}