using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Conventions;
using Nancy.Hosting.Self;

namespace NancyHostingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var nancyHost = new NancyHost(new Uri("http://localhost/nancy/"), new Uri("http://127.0.0.1/nancy/"));
            nancyHost.Start();

            Console.WriteLine("Nancy now listening - navigating to http://localhost:8888/nancy/. Press enter to stop");
            Process.Start("http://localhost/nancy/Hello");
            Console.ReadKey();

            nancyHost.Stop();

            Console.WriteLine("Stopped. Good bye!");
        }
    }

    public class ApplicationBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Content", @"Content"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts", @"Scripts"));
            base.ConfigureConventions(nancyConventions);
        }
    }
}
