using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Webshook
{
    public class Utils
    {
        public static void ToastNotification(string message)
        {
            new ToastContentBuilder()
                .AddText("Webshook")
                .AddText(message)
                .Show();
        }

        #region Webhook Methods
        public static string DeleteWebhook(string webhook)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var req = httpClient.DeleteAsync(new Uri(webhook));
                return req.Result.Content.ToString();
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Invalid":
                        ToastNotification("Webhook is invalid");
                        return "Invalid";
                    case "404":
                            ToastNotification("Webhook doesn't exist.");
                        return "Doesn't Exist";
                    default:
                        MessageBox.Show($"Error: {ex}");
                        return null;
                }
            }
        }
        #endregion

    }
}
