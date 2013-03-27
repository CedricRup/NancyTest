using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;

namespace NancyHostingTest
{
    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get["/Hello"] = _ => View["index"];
        }
    }
}
