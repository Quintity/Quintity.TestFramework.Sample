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
                new Dir($@"C:\Quintity TestEngineer 3.5",
                    
                    new Dir("TestAssemblies",
                        new DirFiles($@"...\Quintity.TestFramework.TestLibrary\bin\Debug\*.dll")),

                        new ExeFileShortcut("Uninstall.SampleAutomation", "[System64Folder]msiexec.exe", "/x [ProductCode] /q")

            ));

            // Place output *.msi to appropriate bin folder.
            project.OutDir = $@".\bin\Debug\";

            // Suppress duplicate file warning
            project.LightOptions += "-sice:ICE30";

            // Minimal UI
            project.UI = WUI.WixUI_ProgressOnly;

            // Set installer GUID
            project.GUID = new Guid("2B9CB1C5-210D-4DD3-B3D8-44CFC570FA01");

            // Build this bad boy
            project.BuildMsi();
        }
    }
}
