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
namespace SampleProject


{
    public class InitCls : ExcelCls
    {
        
        //private StringBuilder verificationErrors;
        //public string baseURL;




        public static IWebDriver getdriver
        {

            get;

            set;

        }

        
            
        ArrayList list = new ArrayList();


        //Method to read the data from excel and returns hastset object
        
        public IEnumerable TestData()
        {
            
            Dictionary<object, object> tempflow = new Dictionary<object, object>();
            HashSet<string> hs = new HashSet<string>();
            
            //before test activities
            tempflow = openExcel(@"C:\excel\TestSource.xlsx");
            string temp;
            var enumerator = tempflow.Keys.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var pair = enumerator.Current;
                temp = pair.ToString();
                hs.Add(temp.Substring(0, temp.IndexOf(":")));
            }
            return hs;
        }


        //calling methods at Runtime
        public static string CallMethod(string typeName, string methodName, string stringParam)
        {
            
            // Get the Type for the class
            Type calledType = Type.GetType(typeName);
            object instance = Activator.CreateInstance(calledType);
            // Invoke the method itself. The string returned by the method winds up in s.
            // Note that stringParam is passed via the last parameter of InvokeMember,
            // as an array of Objects.
            String s = (String)calledType.InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Default,

                            null,
                            instance,
                            stringParam == null ? null : new Object[] { stringParam });

           
            // Return the string that was returned by the called method.
            return s;
        }


        //Read the Json data from text file
        public ArrayList JsonParser(string strmethod)
        {
            string methodname = null;
            bool flag = false;

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

            return list;

        }



    }


}
