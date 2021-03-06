/*######################################################################################################
 Author: shivaji Doddapaneni
 Description:This class is main driver class where it get all data to drive the automation activities
########################################################################################################*/
using NUnit.Framework;
using OpenQA.Selenium;
using SampleProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;
using System.Threading;
using ReportProj;

namespace SeleniumTests
{
    [TestFixture]
    public class BuffetCls : InitCls
    {
                
        Dictionary<object, object> flow = null;

        //set up method
        [TestFixtureSetUp]
        public void SetupTest()
        {  
            Console.WriteLine("set up at start");
            flow = getexceldata;
            
        }

        

        //tear down method
        [TestFixtureTearDown]
        public void TeardownTest()
        {
            Console.WriteLine("end up test method");
        
        }

        //before every method
        [SetUp]
        public void  TestSetUp()
        {
            getdriver = new FirefoxDriver();
            getdriver.Navigate().GoToUrl("");
            
            
        }

        [TearDown]
        public void TestTearDown()
        { 
           getdriver.Close();
           
        }

        //main test method to drive entire automation activities
        [ReportAction("Report")]
        [TestCaseSource("TestData")]
        [Test]
        public void BuffetTable(string testCaseRow)
        {                       
            ArrayList list = null;

            try
            {


                foreach (object key in flow.Keys)
                {
                    if (Convert.ToString(key).Substring(0, Convert.ToString(key).IndexOf(":")).Split('}')[1] == testCaseRow)
                    {
                        Console.WriteLine(Convert.ToString(flow[key]));
                        list = JsonParser(Convert.ToString(key).Substring(Convert.ToString(key).IndexOf(":") + 1));
                        CallMethod(list[1] + "." + list[2], Convert.ToString(key).Substring(Convert.ToString(key).IndexOf(":") + 1), (Convert.ToString(flow[key]) == null || Convert.ToString(flow[key]) == "") ? null : Convert.ToString(flow[key]));
                    }


                }
            }
            catch (Exception e)
            {
                Reporter.LogMessage("fail","An exception was thrown","",e.Message);
                
            }
        }

    }
}
