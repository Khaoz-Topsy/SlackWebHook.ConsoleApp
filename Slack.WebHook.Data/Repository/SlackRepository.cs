using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Slack.WebHook.Data.Repository
{
    public class SlackRepository
    {
        public void SendMessage(string slackWebhookURL, string color, string authorName, string link, string title)
        {
            string Result = string.Empty;

            try
            {
                WebRequest tRequest = WebRequest.Create(slackWebhookURL);
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";

                #region payload
                var msgContent = new
                {
                    attachments = new[]
                    { new {
                        color = color,
                        author_name = authorName,
                        author_link = link,
                        title = title
                    }}
                };
                #endregion

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(msgContent);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                Result = tReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }

            Console.WriteLine(Result);
            Console.WriteLine("\n\nHit Enter to Exit");
            Console.ReadLine();
        }

    }
}