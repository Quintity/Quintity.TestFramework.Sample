using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WixSharp;

namespace Quintity.TestFramework.Sample.Installer
{
    class Program
    {
        static void Main(string[] args)
        {
            var project = new Project("Quintity.Sample.Tests",
                new Dir($@"C:\Quintity.TestFramework.Sample")
                );

            project.BuildMsi();
        }
    }
}
