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

            System.Console.WriteLine("this is test method");
        }

        
        public  void testmethod2(string s)
        {

            System.Console.WriteLine("this is test method2"+s);
        }


    }
}
