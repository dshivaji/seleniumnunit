using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SampleProject.modules
{    
    class samplemodule:InitCls
    {

            
        public  void testmethod()
        {

            //System.Threading.Thread.Sleep(5000);
            //getdriver.FindElement(By.LinkText("Resellers")).Click();
            //System.Threading.Thread.Sleep(5000);
            //getdriver.FindElement(By.LinkText(getdata("Test_2", "ResellerName"))).Click();
            //System.Threading.Thread.Sleep(5000);
            //getdriver.FindElement(By.LinkText("Customers")).Click();
            //System.Threading.Thread.Sleep(5000);
            //getdriver.FindElement(By.LinkText(getdata("Test_2", "CustomerName"))).Click();
            //System.Threading.Thread.Sleep(5000);
            //getdriver.FindElement(By.LinkText("Edit")).Click();
            //System.Threading.Thread.Sleep(5000);
            //getdriver.FindElement(By.Id("Name")).Clear();
            //getdriver.FindElement(By.Id("Name")).SendKeys(getdata("Test_2", "ModifiedCustomerName"));
            //getdriver.FindElement(By.XPath("//input[@value='Submit']")).Click();
        }

        
        public  void testmethod2(string s)
        {

            System.Console.WriteLine("this is test method2"+s);
        }


    }
}
