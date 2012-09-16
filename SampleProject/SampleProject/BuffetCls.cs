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
            flow = openExcel(@"C:\excel\TestSource.xlsx");
        }

        //tear down method
        [TestFixtureTearDown]
        public void TeardownTest()
        {
            Console.WriteLine("end up test method");
            //end of test activities
        
        }

        //before every method
        [SetUp]
        public void  test2()
        {
            Console.WriteLine("before test");
        }


        //main test method to drive entire automation activities

        [TestCaseSource("TestData")]
        [Test]
        public void BuffetTable(string testCaseRow)
        {
            ArrayList list = null;
               
            foreach (object key in flow.Keys)
            {
                if (Convert.ToString(key).Substring(0, Convert.ToString(key).IndexOf(":")) == testCaseRow)
                {
                    list = JsonParser(Convert.ToString(key).Substring(Convert.ToString(key).IndexOf(":") + 1));
                    CallMethod(list[1] + "." + list[2], Convert.ToString(key).Substring(Convert.ToString(key).IndexOf(":") + 1), (Convert.ToString(flow[key]) == null || Convert.ToString(flow[key]) == "") ? null : Convert.ToString(flow[key]));
                }
                

            }

        }

    }
}
