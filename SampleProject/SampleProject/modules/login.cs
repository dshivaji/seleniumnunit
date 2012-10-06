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
            getdriver.FindElement(By.LinkText("Users")).Click();
            Assert.AreEqual("Users", getdriver.Title);
            Thread.Sleep(3000);
            getdriver.FindElement(By.LinkText("edit")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("Edit: administrator1023 User3 > 240812customer1 - intY Cascade Management Portal", getdriver.Title);
            Thread.Sleep(3000);
            getdriver.FindElement(By.Id("FirstName")).Clear();
            Thread.Sleep(3000);
            getdriver.FindElement(By.Id("FirstName")).SendKeys("administrator1023");
            Thread.Sleep(3000);
            getdriver.FindElement(By.Id("LastName")).Clear();
            Thread.Sleep(3000);
            getdriver.FindElement(By.Id("LastName")).SendKeys("User3");
            Thread.Sleep(3000);
            new SelectElement(getdriver.FindElement(By.Id("SecurityQuestions_UserResponses_0__SecurityQuestionId"))).SelectByText("What is your favourite food?");
            Thread.Sleep(3000);
            getdriver.FindElement(By.Id("SecurityQuestions_UserResponses_0__UserResponse")).Clear();
            Thread.Sleep(3000);
            getdriver.FindElement(By.Id("SecurityQuestions_UserResponses_0__UserResponse")).SendKeys("biryani");
            Thread.Sleep(3000);
            new SelectElement(getdriver.FindElement(By.Id("SecurityQuestions_UserResponses_1__SecurityQuestionId"))).SelectByText("What is your favourite holiday destination?");
            Thread.Sleep(3000);
            getdriver.FindElement(By.Id("SecurityQuestions_UserResponses_1__UserResponse")).Clear();
            Thread.Sleep(3000);
            getdriver.FindElement(By.Id("SecurityQuestions_UserResponses_1__UserResponse")).SendKeys("paris");
            Thread.Sleep(3000);
            getdriver.FindElement(By.XPath("//input[@value='Submit']")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("Users", getdriver.Title);
            Thread.Sleep(3000);
            Assert.AreEqual("Update successful", getdriver.FindElement(By.XPath("//div[@id='content']/div")).Text);
            Thread.Sleep(3000);
        }

    }
}
