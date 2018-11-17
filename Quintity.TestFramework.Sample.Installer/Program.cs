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

                    new ExeFileShortcut("Uninstall.SampleAutomation", "[System64Folder]msiexec.exe", "/x [ProductCode] /q"),
                    
                    new Dir("TestAssemblies",
                        new DirFiles($@"...\Quintity.TestFramework.TestLibrary\bin\Debug\*.dll"))
                
            ));

            // Place output *.msi to appropriate bin folder.
            //project.OutDir = $@".\bin\Debug\";

            // Suppress duplicate file warning
            project.LightOptions += "-sice:ICE30";

            // Minimal UI
            project.UI = WUI.WixUI_ProgressOnly;

            // Set installer GUID
            project.GUID = new Guid("7D54CC81-9CC6-4F95-98FC-7D2DC92C7105");

            // Build this bad boy
            project.BuildMsi();
        }
    }
}
