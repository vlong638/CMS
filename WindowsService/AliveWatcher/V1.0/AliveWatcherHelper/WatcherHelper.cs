using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace AliveWatcherHelper
{
    public static class WatcherHelper
    {
        static LogHelper log = new LogHelper();
        static WatcherHelper()
        {
        }
        public static void SetLogPath(string path)
        {
            log.UpdatePath(path);
        }
        public static void SetLogOuter(OuterType type)
        {
            log.SetOuter(type);
        }
        public static void WriteLog(string message)
        {
            log.WriteLog(message);
        }

        public static void CreateXMLTemplate()
        {
            string Path1 = @"E:\工作文档\6.Project\MyWPF\AliveWatcherCA\TargetList.xml";
            string Path2 = @"E:\工作文档\6.Project\MyWPF\AliveWatcher\TargetList.xml";

            //邮件提醒信息
            XElement EmailInform = new XElement("Mails"
                , new XAttribute("关于多发", "同一发送邮箱内To及飞联Accounts用;隔开")
                , new XElement("Mail", new List<XElement>()
                {
                    new XElement("Host","smtp.qq.com"),
                    new XElement("Port","587"),
                    new XElement("EnableSSL","false"), 
                    new XElement("Account","419352357@qq.com"),
                    new XElement("Password","xia19100128"),
                    new XElement("From","419352357@qq.com"),
                    new XElement("To","419352357@qq.com"),
                    new XElement("Subject","主题"),
                    new XElement("Body","内容")
                })
                , new XElement("Mail", new List<XElement>()
                {
                    new XElement("Host","smtp.sina.com"),
                    new XElement("Port","25"),
                    new XElement("EnableSSL","false"),
                    new XElement("Account","vlong638@sina.cn"),
                    new XElement("Password","701616"),
                    new XElement("From","vlong638@sina.cn"),
                    new XElement("To","vlong638@sina.cn;vlong637@sina.cn"),
                    new XElement("Subject","主题"),
                    new XElement("Body","内容")
                }
            ));

            //飞联提醒信息
            XElement FLInform = new XElement("FeiLian"
                , new List<XElement>()
            {
                new XElement("Accounts","tina_071;lw_011"),
                new XElement("InformMessage","xx服务出现yy错误.")
            });

            //总提醒目录
            XElement doc = new XElement(
                                new XElement("ErrorInform"
                                    , new XAttribute("关于配置更改", "配置内容更改后需要重启服务以使其生效!")
                                    , new XAttribute("Interval", "1")
                                   , EmailInform, FLInform));

            doc.Save(Path1);
            doc.Save(Path2);
        }
        public static void CheckService()
        {
            try
            {
                if (!ServiceWatchedClient.ServiceHelper.ServiceClient.TryLogin())
                {
                    //数据库连接失败
                    ErrorInform("数据库请求失败,请检查数据库服务是否已启用");
                }
                else
                {
                    log.WriteLog("服务正在运行中...");
                }
            }
            catch (Exception ex)
            {
                //服务连接失败
                log.WriteLog(ex.Message);
                ErrorInform("服务方法调用失败,请检查服务是否已启用");
            }
        }
        private static void ErrorInform(string message)
        {
            log.WriteLog(message);
            EmailInform(message);
            MessageInform(message);
        }
        private static void EmailInform(string message)
        {
            string Path = Application.StartupPath + @"\TargetList.xml";
            XDocument doc = XDocument.Load(Path);

            var mails = doc.Descendants("Mail");
            foreach (var mail in mails)
            {
                //配置参数
                string Host;
                int Port;
                bool EnableSSL;
                string Account;
                string Password;
                string From;
                string To;
                string Subject;
                string Body;
                try
                {
                    Host = mail.Element("Host").Value;
                    Port = int.Parse(mail.Element("Port").Value);
                    EnableSSL = bool.Parse(mail.Element("EnableSSL").Value);
                    Account = mail.Element("Account").Value;
                    Password = mail.Element("Password").Value;
                    From = mail.Element("From").Value;
                    To = mail.Element("To").Value;
                    Subject = mail.Element("Subject").Value;
                    Body = message + "\r\n" + mail.Element("Body").Value;
                }
                catch
                {
                    log.WriteLog("邮件配置读取失败");
                    return;
                }
                //发送邮件
                MailMessage mailObj = new MailMessage();
                mailObj.From = new MailAddress(From); //发送人邮箱地址
                //检查多受众
                if (To.Contains(";"))
                {
                    string[] Tos = To.Split(';');
                    foreach (var to in Tos)
                    {
                        mailObj.To.Add(new MailAddress(to));
                    }
                }
                else
                {
                    mailObj.To.Add(new MailAddress(To));
                }
                mailObj.Subject = Subject;    //主题
                mailObj.Body = Body;    //正文
                mailObj.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpClient smtp = new SmtpClient(Host, Port);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(Account, Password);  //发送人的登录名和密码
                try
                {
                    smtp.Send(mailObj);

                    log.WriteLog("{0}邮件发送成功", Account);
                }
                catch (Exception ex)
                {
                    log.WriteLog(ex.Message);
                    log.WriteLog("{0}邮件发送失败", Account);
                }
            }
        }
        private static void MessageInform(string message)
        {
            string Path = Application.StartupPath + @"\TargetList.xml";
            XDocument doc = XDocument.Load(Path);
            var feilian = doc.Descendants("FeiLian").First();
            string modelName;
            string account;
            string flMessage;
            try
            {
                modelName = "服务检测";
                account = feilian.Element("Accounts").Value;//工号 分隔用;
                flMessage = message + "\r\n" + feilian.Element("InformMessage").Value;
            }
            catch
            {
                log.WriteLog("飞联配置读取失败");
                return;
            }
            try
            {
                //检查多受众
                if (account.Contains(";"))
                {
                    string[] accounts = account.Split(';');
                    foreach (var ac in accounts)
                    {
                        MsgSenderHelper.SendPersonnelMsg(modelName, ac, message);
                        log.WriteLog("{0}飞联消息发送成功", ac);
                    }
                }
                else
                {
                    MsgSenderHelper.SendPersonnelMsg(modelName, account, message);
                    log.WriteLog("{0}飞联消息发送成功", account);
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.ToString());
                log.WriteLog("飞联消息发送失败");
            }
        }
    }
}
