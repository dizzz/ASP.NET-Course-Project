using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace 实验11
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {   // 在应用程序启动时运行的代码
            // 建立用户列表
            string user = "";           // 用户列表
            Application["user"] = user;
            Application["userNum"] = 0;
            string chats = "";              // 聊天记录  
            Application["chats"] = chats;
            // 当前的聊天记录数
            Application["current"] = 0;
            string receive = "";            // 私聊接受者列表
            Application["receive"] = receive;
            string Owner = "";              // 私聊发送者列表
            Application["Owner"] = Owner;
            string chat = "";           // 私聊内容列表
            Application["chat"] = chat;
            Application["chatnum"] = 0;     // 私聊内容的当前记录数
            string chattime = "";       // 私聊信息发送时间
            Application["chattime"] = chattime;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}