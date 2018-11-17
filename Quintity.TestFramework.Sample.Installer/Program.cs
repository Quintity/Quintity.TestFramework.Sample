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
            var productCode = "04D28F9E-9D23-47FE-8DDA-92DD61CA6FBD";
            //var commandLine = 

            var project = new Project("Quintity.Sample.Tests",
                new Dir($@"C:\Quintity TestEngineer 3.5",
                    
                    new ExeFileShortcut("Uninstall.SampleAutomation", "[System64Folder]msiexec.exe", $"/x {productCode} /q"),
                    
                    new Dir("TestAssemblies",
                        new DirFiles($@"...\Quintity.TestFramework.TestLibrary\bin\Debug\*.dll"))
                
            ));

            // Place output *.msi to appropriate bin folder.
            project.OutDir = $@".\bin\Debug\";

            // Suppress duplicate file warning
            project.LightOptions += "-sice:ICE30";

            // Minimal UI
            project.UI = WUI.WixUI_ProgressOnly;

            // Set installer GUID
            //project.GUID = new Guid("04D28F9E-9D23-47FE-8DDA-92DD61CA6FBD");
            project.GUID = new Guid(productCode);

            // Build this bad boy
            project.BuildMsi();
        }
    }
}
