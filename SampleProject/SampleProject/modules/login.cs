using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using ReportProj;

namespace SampleProject.modules
{
    class login:InitCls
    {
        
        public void Loginmethod(string user,string pws)
        {
            Console.WriteLine(pws);
            System.Threading.Thread.Sleep(10000);
            getdriver.FindElement(By.Id("Username")).Clear();
            getdriver.FindElement(By.Id("Username")).SendKeys(user);
            Reporter.LogMessage("pass", "enter user name", "username is ss", "user name is" + user);
            getdriver.FindElement(By.Id("Password")).Clear();
            getdriver.FindElement(By.Id("Password")).SendKeys(pws);
            Reporter.LogMessage("pass", "enter user name", "password is ss", "password is" + pws);
            getdriver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
            
            
        }

        public void logout(string d)
        {
            Console.WriteLine("sss"+d);
        }

        public static void TheEditingUserUnderCustomerTest()
        {
           
        }

    }
}
