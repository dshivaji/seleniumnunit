/*######################################################################################################
 Author: shivaji Doddapaneni
 Description:This class is init inherted the dataprovider class and all initialization should be happend
########################################################################################################*/
using System;
using System.Collections.Generic;
using NUnit.Framework;
using DataProviderCls;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using ReportProj;
namespace SampleProject


{
    public class InitCls : ExcelCls
    {

         

        public static IWebDriver getdriver
        {
            get;
            set;
        }

        public static Dictionary<object, object> getexceldata
        {
            get;
            set;
        }
            
        ArrayList list = new ArrayList();


        //Method to read the data from excel and returns hastset object
        
        public IEnumerable TestData
        {
            get
            {
                bool itemadd = false;
                Dictionary<object, object> tempflow = new Dictionary<object, object>();
                HashSet<string> hs = new HashSet<string>();
                getexceldata = tempflow = openExcel(@"C:\excel\TestSource.xlsx");
                string temp;
                var enumerator = tempflow.Keys.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var pair = enumerator.Current;                
                    temp = pair.ToString();
                    string[] rownum = temp.Substring(0, temp.IndexOf(":")).Split('}');
                    itemadd = hs.Add(rownum[1]);
                    if (itemadd) yield return new TestCaseData(rownum[1]).SetName(rownum[0]);
                }

            
            }
            
        }


        //calling methods at Runtime
        public static string CallMethod(string typeName, string methodName, string stringParam)
        {
            String RetVal = null;
            object[] obj = (stringParam != null) ? stringParam.Split(',') : null;
            // Get the Type for the class
            Type calledType = Type.GetType(typeName);
            object instance = Activator.CreateInstance(calledType);
            // Invoke the method itself. The string returned by the method winds up in s.
            // Note that stringParam is passed via the last parameter of InvokeMember,
            // as an array of Objects.
            try
            {
                RetVal = (String)calledType.InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static,

                            null,
                            instance,
                            obj);

            }
            catch (Exception e)
            {
                Reporter.LogMessage("fail", "An Exception was thrown CallMethod method", "", e.StackTrace.ToString());
            }
            // Return the string that was returned by the called method.
            return RetVal;
        }


        //Read the Json data from text file
        public ArrayList JsonParser(string strmethod)
        {
            string methodname = null;
            bool flag = false;


            try
            {
                list.Clear();
                JsonTextReader reader = new JsonTextReader(new StringReader(SampleProject.Properties.Resources.Mapping));

                while (reader.Read())
                {
                    if ((reader.Value != null) && (reader.TokenType.ToString() == "PropertyName"))
                    {
                        methodname = (string)reader.Value;
                        if (methodname == strmethod)
                            flag = true;

                    }
                    if (reader.Value != null && flag)
                    {
                        list.Add(reader.Value);
                    }
                }



            }
            catch (Exception e)
            {
                Reporter.LogMessage("fail", "An Exception was thrown JsonParser method", "", e.Message);
            }

        return list;
       }


    }


}
