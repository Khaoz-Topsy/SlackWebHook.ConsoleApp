using Slack.WebHook.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slack.WebHook.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SlackRepository SR = new SlackRepository();
            SR.SendMessage("<webhookURL>", 
                "#882BD5", 
                "New Alert", 
                "<link>", 
                "AlertTitle!");
        }
    }
}
